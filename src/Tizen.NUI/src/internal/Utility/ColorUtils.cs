/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Modified by Woochan Lee(wc0917.lee@samsung.com)
 */

using System;

namespace Tizen.NUI
{
    internal sealed class ColorUtils
    {
        private const int minAlphaSearchMaxIterations = 10;
        private const int minAlphaSearchPrecision = 1;

        /// <summary>
        /// Convert the ARGB color to its CIE XYZ representative components.
        ///
        /// The resulting XYZ representation will use the D65 illuminant and the CIE
        /// 2° Standard Observer (1931).
        ///
        /// outXyz[0] is X [0 ...95.047)
        /// outXyz[1] is Y [0...100)
        /// outXyz[2] is Z [0...108.883)
        ///
        /// param color  the ARGB color to convert. The alpha component is ignored
        /// param outXyz 3-element array which holds the resulting LAB components
        /// </summary>
        public static void ColorToXyz(int color, double[] outXyz)
        {
            System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(color);
            RgbToXyz(rgbColor.R, rgbColor.G, rgbColor.B, outXyz);
        }

        /// <summary>
        /// Convert RGB components to its CIE XYZ representative components.
        ///
        /// The resulting XYZ representation will use the D65 illuminant and the CIE
        /// 2° Standard Observer (1931).
        ///
        /// outXyz[0] is X [0 ...95.047)
        /// outXyz[1] is Y [0...100)
        /// outXyz[2] is Z [0...108.883)
        ///
        /// r      red component value [0..255]
        /// g      green component value [0..255]
        /// b      blue component value [0..255]
        /// outXyz 3-element array which holds the resulting XYZ components
        /// </summary>
        public static void RgbToXyz(int red, int green, int blue, double[] outXyz)
        {
            if (outXyz.Length != 3)
            {
                throw new ArgumentException("Array legnth must be 3", nameof(outXyz));
            }

            double floatRed = red / 255.0;
            floatRed = floatRed < 0.04045 ? floatRed / 12.92 : Math.Pow((floatRed + 0.055) / 1.055, 2.4);
            double floatGreen = green / 255.0;
            floatGreen = floatGreen < 0.04045 ? floatGreen / 12.92 : Math.Pow((floatGreen + 0.055) / 1.055, 2.4);
            double floatBlue = blue / 255.0;
            floatBlue = floatBlue < 0.04045 ? floatBlue / 12.92 : Math.Pow((floatBlue + 0.055) / 1.055, 2.4);

            outXyz[0] = 100 * (floatRed * 0.4124 + floatGreen * 0.3576 + floatBlue * 0.1805);
            outXyz[1] = 100 * (floatRed * 0.2126 + floatGreen * 0.7152 + floatBlue * 0.0722);
            outXyz[2] = 100 * (floatRed * 0.0193 + floatGreen * 0.1192 + floatBlue * 0.9505);
        }

        /// <summary>
        /// Returns the luminance of a color as a float between 0.0 and 1.0
        /// Defined as the Y component in the XYZ representation of color.
        /// </summary>
        public static double CalculateLuminance(int color)
        {
            double[] result = new double[3];
            ColorToXyz(color, result);
            // Luminance is the Y component
            return result[1] / 100;
        }

        /// <summary>
        /// Composite two potentially translucent colors over each other and returns the result.
        /// </summary>
        public static int CompositeColors(int foreground, int background)
        {
            System.Drawing.Color foreColor = System.Drawing.Color.FromArgb(foreground);
            System.Drawing.Color backColor = System.Drawing.Color.FromArgb(background);
            int bgAlpha = backColor.A;
            int fgAlpha = foreColor.A;

            int alpha = CompositeAlpha(fgAlpha, bgAlpha);

            int red = CompositeComponent(foreColor.R, fgAlpha,
                    backColor.R, bgAlpha, alpha);
            int green = CompositeComponent(foreColor.G, fgAlpha,
                    backColor.G, bgAlpha, alpha);
            int blue = CompositeComponent(foreColor.B, fgAlpha,
                    backColor.B, bgAlpha, alpha);

            return ((alpha & 0xff) << 24 | (red & 0xff) << 16 | (green & 0xff) << 8 | (blue & 0xff));
        }

        /// <summary>
        /// Returns the contrast ratio between foreground and background.
        /// background must be opaque.
        ///
        /// Formula defined
        /// <a href="http://www.w3.org/TR/2008/REC-WCAG20-20081211/#contrast-ratiodef">here</a>.
        /// </summary>
        public static double CalculateContrast(int foreground, int background)
        {
            if (((background >> 24) & 0xff) != 255)
            {
                throw new ArgumentException("background can not be translucent.");
            }
            if (((foreground >> 24) & 0xff) < 255)
            {
                System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(foreground);

                // If the foreground is translucent, composite the foreground over the background
                foreground = CompositeColors(foreground, background);
                rgbColor = System.Drawing.Color.FromArgb(foreground);
            }

            double luminance1 = CalculateLuminance(foreground) + 0.05;
            double luminance2 = CalculateLuminance(background) + 0.05;

            // Now return the lighter luminance divided by the darker luminance
            return Math.Max(luminance1, luminance2) / Math.Min(luminance1, luminance2);
        }

        /// <summary>
        /// Set the alpha component of color to be alpha.
        /// </summary>
        public static int SetAlphaComponent(int color, int alpha)
        {
            if (alpha < 0 || alpha > 255)
            {
                throw new ArgumentException("alpha must be between 0 and 255.");
            }

            return (color & 0x00ffffff) | (alpha << 24);
        }

        /// <summary>
        /// Calculates the minimum alpha value which can be applied to foreground so that would
        /// have a contrast value of at least minContrastRatio when compared to
        /// background.
        ///
        /// param foreground       the foreground color
        /// param background       the opaque background color
        /// param minContrastRatio the minimum contrast ratio
        /// return the alpha value in the range 0-255, or -1 if no value could be calculated
        /// </summary>
        public static int CalculateMinimumAlpha(int foreground, int background,
                float minContrastRatio)
        {
            if (((background >> 24) & 0xff) != 255)
            {
                throw new ArgumentException("background can not be translucent");
            }

            // First lets check that a fully opaque foreground has sufficient contrast
            int testForeground = SetAlphaComponent(foreground, 255);
            System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(testForeground);
            double testRatio = CalculateContrast(testForeground, background);

            if (testRatio < minContrastRatio)
            {
                // Fully opaque foreground does not have sufficient contrast, return error
                return -1;
            }

            // Binary search to find a value with the minimum value which provides sufficient contrast
            int numIterations = 0;
            int minAlpha = 0;
            int maxAlpha = 255;

            while (numIterations <= minAlphaSearchMaxIterations &&
                    (maxAlpha - minAlpha) > minAlphaSearchPrecision)
            {
                int testAlpha = (minAlpha + maxAlpha) / 2;

                testForeground = SetAlphaComponent(foreground, testAlpha);
                rgbColor = System.Drawing.Color.FromArgb(testForeground);
                testRatio = CalculateContrast(testForeground, background);
                if (testRatio < minContrastRatio)
                {
                    minAlpha = testAlpha;
                }
                else
                {
                    maxAlpha = testAlpha;
                }

                numIterations++;
            }

            // Conservatively return the max of the range of possible alphas, which is known to pass.
            return maxAlpha;
        }

        public static void RgbToHsl(int red, int green, int blue, float[] hsl)
        {
            float floatRed = red / 255f;
            float floatGreen = green / 255f;
            float floatBlue = blue / 255f;
            float max = Math.Max(floatRed, Math.Max(floatGreen, floatBlue));
            float min = Math.Min(floatRed, Math.Min(floatGreen, floatBlue));
            float deltaMaxMin = max - min;
            float hue, saturation;
            float lightness = (max + min) / 2f;
            if (max == min)
            {
                // Monochromatic
                hue = saturation = 0f;
            }
            else
            {
                if (max == floatRed)
                {
                    hue = ((floatGreen - floatBlue) / deltaMaxMin) % 6f;
                }
                else if (max == floatGreen)
                {
                    hue = ((floatBlue - floatRed) / deltaMaxMin) + 2f;
                }
                else
                {
                    hue = ((floatRed - floatGreen) / deltaMaxMin) + 4f;
                }
                saturation = deltaMaxMin / (1f - Math.Abs(2f * lightness - 1f));
            }
            hsl[0] = ((hue * 60f) + 360f) % 360f;
            hsl[1] = saturation;
            hsl[2] = lightness;
        }

        public static int HslToRgb(float[] hsl)
        {
            float hue = hsl[0];
            float saturation = hsl[1];
            float lightness = hsl[2];
            float constC = (1f - Math.Abs(2 * lightness - 1f)) * saturation;
            float constM = lightness - 0.5f * constC;
            float constX = constC * (1f - Math.Abs((hue / 60f % 2f) - 1f));
            int hueSegment = (int)hue / 60;
            int red = 0, green = 0, blue = 0;
            switch (hueSegment)
            {
                case 0:
                    red = (int)Math.Round(255 * (constC + constM));
                    green = (int)Math.Round(255 * (constX + constM));
                    blue = (int)Math.Round(255 * constM);
                    break;
                case 1:
                    red = (int)Math.Round(255 * (constX + constM));
                    green = (int)Math.Round(255 * (constC + constM));
                    blue = (int)Math.Round(255 * constM);
                    break;
                case 2:
                    red = (int)Math.Round(255 * constM);
                    green = (int)Math.Round(255 * (constC + constM));
                    blue = (int)Math.Round(255 * (constX + constM));
                    break;
                case 3:
                    red = (int)Math.Round(255 * constM);
                    green = (int)Math.Round(255 * (constX + constM));
                    blue = (int)Math.Round(255 * (constC + constM));
                    break;
                case 4:
                    red = (int)Math.Round(255 * (constX + constM));
                    green = (int)Math.Round(255 * constM);
                    blue = (int)Math.Round(255 * (constC + constM));
                    break;
                case 5:
                case 6:
                    red = (int)Math.Round(255 * (constC + constM));
                    green = (int)Math.Round(255 * constM);
                    blue = (int)Math.Round(255 * (constX + constM));
                    break;
            }
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            //ARGB Encoding
            return (255 << 24 | (red & 0xff) << 16 | (green & 0xff) << 8 | (blue & 0xff));
        }

        /// <summary>
        /// return luma value according to to XYZ color space in the range 0.0 - 1.0
        /// </summary>
        private static int CompositeAlpha(int foregroundAlpha, int backgroundAlpha)
        {
            return 0xFF - (((0xFF - backgroundAlpha) * (0xFF - foregroundAlpha)) / 0xFF);
        }

        private static int CompositeComponent(int fgC, int fgA, int bgC, int bgA, int alpha)
        {
            if (alpha == 0) return 0;
            return ((0xFF * fgC * fgA) + (bgC * bgA * (0xFF - fgA))) / (alpha * 0xFF);
        }
    }
}
