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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;

namespace Tizen.NUI
{
    /// <summary>
    /// A helper class to extract prominent colors from an image.
    ///
    /// A number of colors with different profiles are extracted from the image:
    /// Vibrant, Vibrant Dark, Vibrant Light, Muted, Muted Dark, Muted Light
    ///
    /// These can be retrieved from the appropriate getter method.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public sealed class Palette
    {
        private const int defaultCalculateNumberColors = 16;
        private const int calculateBitmapMinDimension = 100;
        private const float targetDarkLuma = 0.26f;
        private const float maxDarkLuma = 0.45f;
        private const float minLightLuma = 0.55f;
        private const float targetLightLuma = 0.74f;
        private const float minNormalLuma = 0.3f;
        private const float targetNormalLuma = 0.5f;
        private const float maxNormalLuma = 0.7f;
        private const float targetMutedSaturation = 0.3f;
        private const float maxMutedSaturation = 0.4f;
        private const float targetVibrantSaturation = 1f;
        private const float minVibrantSaturation = 0.35f;

        private int highestPopulation;
        private Swatch dominantSwatch;
        private Swatch vibrantSwatch;
        private Swatch mutedSwatch;
        private Swatch darkVibrantSwatch;
        private Swatch darkMutedSwatch;
        private Swatch lightVibrantSwatch;
        private Swatch lightMutedColor;
        private List<Swatch> swatches;

        private Palette() { }

        private Palette(List<Swatch> swatcheList)
        {
            swatches = swatcheList;
            highestPopulation = FindMaxPopulation();
            vibrantSwatch = FindColor(targetNormalLuma, minNormalLuma, maxNormalLuma,
                    targetVibrantSaturation, minVibrantSaturation, 1f);

            lightVibrantSwatch = FindColor(targetLightLuma, minLightLuma, 1f,
                    targetVibrantSaturation, minVibrantSaturation, 1f);

            darkVibrantSwatch = FindColor(targetDarkLuma, 0f, maxDarkLuma,
                    targetVibrantSaturation, minVibrantSaturation, 1f);

            mutedSwatch = FindColor(targetNormalLuma, minNormalLuma, maxNormalLuma,
                    targetMutedSaturation, 0f, maxMutedSaturation);

            lightMutedColor = FindColor(targetLightLuma, minLightLuma, 1f,
                    targetMutedSaturation, 0f, maxMutedSaturation);

            darkMutedSwatch = FindColor(targetDarkLuma, 0f, maxDarkLuma,
                    targetMutedSaturation, 0f, maxMutedSaturation);
            // Now try and generate any missing colors
            GenerateEmptyswatches();

            // To get swatch information as string.
            String[] swatchInfo = new String[6];

            if (vibrantSwatch != null) swatchInfo[0] = vibrantSwatch.ToString();
            if (lightVibrantSwatch != null) swatchInfo[1] = lightVibrantSwatch.ToString();
            if (darkVibrantSwatch != null) swatchInfo[2] = darkVibrantSwatch.ToString();
            if (mutedSwatch != null) swatchInfo[3] = mutedSwatch.ToString();
            if (lightMutedColor != null) swatchInfo[4] = lightMutedColor.ToString();
            if (darkMutedSwatch != null) swatchInfo[5] = darkMutedSwatch.ToString();

            Tizen.Log.Info("Palette", "VibrantSwatch [" + swatchInfo[0] + "] " +
                                      "lightVibrantSwatch [" + swatchInfo[1] + "] " +
                                      "darkVibrantSwatch [" + swatchInfo[2] + "] " +
                                      "MutedSwatch [" + swatchInfo[3] + "] " +
                                      "lightMutedColor [" + swatchInfo[4] + "] " +
                                      "darkMutedSwatch [" + swatchInfo[5] + "] \n");
        }

        /// <summary>
        /// Generate a Palette asynchronously using bitmap as source.
        /// </summary>
        /// <param name="pixelBuffer">A Target image's pixelBuffer.</param>
        /// <returns>A task that represents the asynchronous pixelBuffer generate operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument pixelBuffer is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static async Task<Palette> GenerateAsync(PixelBuffer pixelBuffer)
        {
            return await Task.Run(() =>
            {
                return Generate(pixelBuffer);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Generate a Palette asynchronously using pixelBuffer as source.
        /// And set a region of the pixelBuffer to be used exclusively when calculating the palette.
        /// </summary>
        /// <param name="pixelBuffer">A Target image's pixelBuffer.</param>
        /// <param name="region">A rectangle used for region.</param>
        /// <returns>A task that represents the asynchronous pixelBuffer generate operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument pixelBuffer is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static async Task<Palette> GenerateAsync(PixelBuffer pixelBuffer, Rectangle region)
        {
            return await Task.Run(() =>
            {
                return Generate(pixelBuffer, region);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Generate a Palette synchronously using pixelBuffer as source.
        /// </summary>
        /// <param name="pixelBuffer">A Target image's pixelBuffer.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument pixelBuffer is null.</exception>
        /// <returns>the palette instance.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static Palette Generate(PixelBuffer pixelBuffer)
        {
            return Generate(pixelBuffer, null);
        }

        /// <summary>
        /// Generate a Palette synchronously using pixelBuffer as source.
        /// And set a region of the pixelBuffer to be used exclusively when calculating the palette.
        /// </summary>
        /// <param name="pixelBuffer">A Target image's pixelBuffer.</param>
        /// <param name="region">A rectangle used for region.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument pixelBuffer is null.</exception>
        /// <returns>the palette instance.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static Palette Generate(PixelBuffer pixelBuffer, Rectangle region)
        {
            Tizen.Log.Info("Palette", "pixelBuffer generate start with region: " + region + "\n");
            if (pixelBuffer == null)
            {
                throw new ArgumentNullException(nameof(pixelBuffer), "pixelBuffer should not be null.");
            }

            // First we'll scale down the bitmap so it's shortest dimension is 100px
            // NOTE: scaledBitmap can gets bitmap origin value and new bitmap instance as well
            //       When ScaleBitmap created newly it will be dispose below.
            //       otherwise it should not disposed because of this instance from user side.
            bool resized = ScaleBitmapDown(pixelBuffer);

            // Region set
            if (resized && region != null)
            {
                double scale = pixelBuffer.GetWidth() / (double)pixelBuffer.GetHeight();
                region.X = (int)Math.Floor(region.X * scale);
                region.Y = (int)Math.Floor(region.Y * scale);
                region.Width = Math.Min((int)Math.Ceiling(region.Width * scale), (int)pixelBuffer.GetWidth() );
                region.Height = Math.Min((int)Math.Ceiling(region.Height * scale), (int)pixelBuffer.GetHeight());
            }

            // Now generate a Quantizer from the Bitmap
            // FIXME: defaultCalculateNumberColors should be changeable?
            ColorCutQuantizer quantizer = ColorCutQuantizer.FromBitmap(pixelBuffer, region, defaultCalculateNumberColors);

            // Now return a ColorExtractor instance
            return new Palette(quantizer.GetQuantizedColors());
        }

        /// <summary>
        /// Returns all of the swatches which make up the palette.
        /// </summary>
        /// <returns>The swatch list</returns>
        /// <since_tizen> 9 </since_tizen>
        public IReadOnlyCollection<Swatch> GetSwatches()
        {
            return swatches;
        }

        /// <summary>
        /// Returns the dominant swatch from the palette.
        /// The dominant swatch is defined as the swatch with the greatest population (frequency) within the palette.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetDominantSwatch()
        {
            String swatchInfo = null;
            if (dominantSwatch == null)
                dominantSwatch = FinddominantSwatch();

            if (dominantSwatch != null) swatchInfo = dominantSwatch.ToString();
            Tizen.Log.Info("Palette", "dominantSwatch [" + swatchInfo + "] \n");

            return dominantSwatch;
        }

        /// <summary>
        /// Returns the most vibrant swatch in the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetVibrantSwatch()
        {
            return vibrantSwatch;
        }

        /// <summary>
        /// Returns a light and vibrant swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetLightVibrantSwatch()
        {
            return lightVibrantSwatch;
        }

        /// <summary>
        /// Returns a dark and vibrant swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetDarkVibrantSwatch()
        {
            return darkVibrantSwatch;
        }

        /// <summary>
        /// Returns a muted swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetMutedSwatch()
        {
            return mutedSwatch;
        }

        /// <summary>
        /// Returns a muted and light swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetLightMutedSwatch()
        {
            return lightMutedColor;
        }

        /// <summary>
        /// Returns a muted and dark swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        /// <since_tizen> 9 </since_tizen>
        public Swatch GetDarkMutedSwatch()
        {
            return darkMutedSwatch;
        }

        /// <summary>
        /// Try and generate any missing swatches from the swatches we did find.
        /// </summary>
        private void GenerateEmptyswatches()
        {
            if (vibrantSwatch == null)
            {
                // If we do not have a vibrant color...
                if (darkVibrantSwatch != null)
                {
                    // ...but we do have a dark vibrant, generate the value by modifying the luma
                    float[] newHsl = CopyhslValues(darkVibrantSwatch);
                    newHsl[2] = targetNormalLuma;
                    vibrantSwatch = new Swatch(ColorUtils.HslToRgb(newHsl), 0);
                    Tizen.Log.Info("Palette", "Generate Vibrant Swatch \n");
                }
            }
            if (darkVibrantSwatch == null)
            {
                // If we do not have a dark vibrant color...
                if (vibrantSwatch != null)
                {
                    // ...but we do have a vibrant, generate the value by modifying the luma
                    float[] newHsl = CopyhslValues(vibrantSwatch);
                    newHsl[2] = targetDarkLuma;
                    darkVibrantSwatch = new Swatch(ColorUtils.HslToRgb(newHsl), 0);
                    Tizen.Log.Info("Palette", "Generate DarkVibrant Swatch \n");
                }
            }
        }

        /// <summary>
        /// Copy a Swatch's hsl values into a new float[].
        /// </summary>
        private static float[] CopyhslValues(Swatch color)
        {
            float[] newHsl = new float[3];
            Array.Copy(color.GetHsl(), 0, newHsl, 0, 3);

            return newHsl;
        }

        /// <summary>
        /// return true if we have already selected swatch
        /// </summary>
        private bool IsAlreadySelected(Swatch swatch)
        {
            return vibrantSwatch == swatch || darkVibrantSwatch == swatch ||
                   lightVibrantSwatch == swatch || mutedSwatch == swatch ||
                   darkMutedSwatch == swatch || lightMutedColor == swatch;
        }

        private Swatch FindColor(float targetLuma, float minLuma, float maxLuma,
                                 float targetSaturation, float minSaturation, float maxSaturation)
        {
            Swatch max = null;
            float maxValue = 0f;

            foreach (Swatch swatch in swatches)
            {
                float sat = swatch.GetHsl()[1];
                float luma = swatch.GetHsl()[2];
                if (sat >= minSaturation && sat <= maxSaturation &&
                    luma >= minLuma && luma <= maxLuma &&
                    !IsAlreadySelected(swatch))
                {
                    float thisValue = CreateComparisonValue(sat, targetSaturation, luma, targetLuma,
                        swatch.GetPopulation(), highestPopulation);
                    if (max == null || thisValue > maxValue)
                    {
                        max = swatch;
                        maxValue = thisValue;
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// Find the Swatch with the highest population value and return the population.
        /// </summary>
        private int FindMaxPopulation()
        {
            int population = 0;

            foreach (Swatch swatch in swatches)
            {
                population = Math.Max(population, swatch.GetPopulation());
            }

            return population;
        }

        private Swatch FinddominantSwatch()
        {
            int maxPop = -1;
            Swatch maxSwatch = null;

            foreach (Swatch swatch in swatches)
            {
                if (swatch.GetPopulation() > maxPop)
                {
                    maxSwatch = swatch;
                    maxPop = swatch.GetPopulation();
                }
            }

            return maxSwatch;
        }

        /// <summary>
        /// Scale the bitmap down so that it's smallest dimension is
        /// calculateBitmapMinDimensionpx. If bitmap is smaller than this, than it
        /// is returned.
        /// </summary>
        private static bool ScaleBitmapDown(PixelBuffer pixelBuffer)
        {
            int minDimension = Math.Min((int)pixelBuffer.GetWidth(), (int)pixelBuffer.GetHeight());

            if (minDimension <= calculateBitmapMinDimension)
            {
                // If the bitmap is small enough already, just return it
                return false;
            }

            float scaleRatio = calculateBitmapMinDimension / (float)minDimension;

            int width = (int)Math.Round((int)pixelBuffer.GetWidth() * scaleRatio);
            int height = (int)Math.Round((int)pixelBuffer.GetHeight() * scaleRatio);

            Tizen.Log.Info("Palette", "pixelBuffer resize to  " + width + " " + height + "\n");
            pixelBuffer.Resize((ushort)width, (ushort)height);

            return true;
        }

        private static float CreateComparisonValue(float saturation, float targetSaturation,
                float luma, float targetLuma,
                int population, int highestPopulation)
        {
            return WeightedMean(InvertDiff(saturation, targetSaturation), 3f,
                                InvertDiff(luma, targetLuma), 6.5f,
                                population / (float)highestPopulation, 0.5f);
        }

        /// <summary>
        /// Returns a value in the range 0-1. 1 is returned when value equals the
        /// targetValue and then decreases as the absolute difference between value and
        /// targetValue increases.
        ///
        /// param value the item's value
        /// param targetValue the value which we desire
        /// </summary>
        private static float InvertDiff(float value, float targetValue)
        {
            return 1f - Math.Abs(value - targetValue);
        }

        private static float WeightedMean(params float[] values)
        {
            float sum = 0f;
            float sumWeight = 0f;

            for (int i = 0; i < values.Length; i += 2)
            {
                float value = values[i];
                float weight = values[i + 1];
                sum += (value * weight);
                sumWeight += weight;
            }

            return sum / sumWeight;
        }

        // This is nested class for use by other internal classes(Color*), but is declared public.
        // Further confirmation need of this architect.

        /// <summary>
        /// Represents a color swatch generated from an image's palette. The RGB color can be retrieved calling getRgb()
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public sealed class Swatch
        {
            private const float minContrastTitleText = 3.0f;
            private const float minContrastBodyText = 4.5f;

            private int red, green, blue;
            private int colorInt, bodyTextColor, titleTextColor;
            private int population;
            private bool generatedTextColors;
            private float[] hsl;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Swatch(int rgbcolorInt, int populationOfSwatch)
            {
                red = (int)((rgbcolorInt >> 16) & 0xff);
                green = (int)((rgbcolorInt >> 8) & 0xff);
                blue = (int)(rgbcolorInt & 0xff);
                colorInt = rgbcolorInt;
                population = populationOfSwatch;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Swatch(int redValueOfSwatch, int greenValueOfSwatch, int blueValueOfSwatch, int populationOfSwatch)
            {
                red = redValueOfSwatch;
                green = greenValueOfSwatch;
                blue = blueValueOfSwatch;
                colorInt = (255 & 0xff) << 24 | (red & 0xff) << 16 | (green & 0xff) << 8 | (blue & 0xff);
                population = populationOfSwatch;
            }

            /// <summary>
            /// return this swatch's RGB color value
            /// </summary>
            /// <returns>A Tizen.NUI.Color value.</returns>
            /// <since_tizen> 9 </since_tizen>
            public Color GetRgb()
            {
                return new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1.0f);
            }

            /// <summary>
            /// Return this swatch's hsl values.
            ///    hsv[0] is Hue [0 .. 360)
            ///    hsv[1] is Saturation [0...1]
            ///    hsv[2] is Lightness [0...1]
            /// </summary>
            /// <returns>A float array value.</returns>
            /// <since_tizen> 9 </since_tizen>
            public float[] GetHsl()
            {
                if (hsl == null)
                {
                    // Lazily generate hsl values from RGB
                    hsl = new float[3];
                    ColorUtils.RgbToHsl(red, green, blue, hsl);
                }

                return hsl;
            }

            /// <summary>
            /// Returns an appropriate color to use for any 'title' text which is displayed over this
            /// Palette.Swatchs color. This color is guaranteed to have sufficient contrast.
            /// </summary>
            /// <returns>A Tizen.NUI.Color value.</returns>
            /// <since_tizen> 9 </since_tizen>
            public Color GetTitleTextColor()
            {
                EnsureTextColorsGenerated();

                return new Color((float)(((titleTextColor >> 16) & 0xff) / 255.0f), (float)(((titleTextColor >> 8) & 0xff) / 255.0f), (float)((titleTextColor & 0xff) / 255.0f), (float)(((titleTextColor >> 24) & 0xff) / 255.0f));
            }

            /// <summary>
            /// Returns an appropriate color to use for any 'body' text which is displayed over this
            /// Palette.Swatchs color. This color is guaranteed to have sufficient contrast.
            /// </summary>
            /// <returns>A Tizen.NUI.Color value.</returns>
            /// <since_tizen> 9 </since_tizen>
            public Color GetBodyTextColor()
            {
                EnsureTextColorsGenerated();

                return new Color((float)(((bodyTextColor >> 16) & 0xff) / 255.0f), (float)(((bodyTextColor >> 8) & 0xff) / 255.0f), (float)((bodyTextColor & 0xff) / 255.0f), (float)(((bodyTextColor >> 24) & 0xff) / 255.0f));
    
            }

            /// <summary>
            /// Returns the number of pixels detected in this swatch.
            /// </summary>
            /// <returns>A number of pixels value.</returns>
            /// <since_tizen> 9 </since_tizen>
            public int GetPopulation()
            {
                return population;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override String ToString()
            {
                return "[ R=" + red + " G=" + green + " B=" + blue + " ] " + population;
            }

            private void EnsureTextColorsGenerated()
            {
                if (!generatedTextColors)
                {
                    int colorWhite = (255 & 0xff) << 24 | (255 & 0xff) << 16 | (255 & 0xff) << 8 | (255 & 0xff);
                    int colorBlack = (255 & 0xff) << 24 | (0 & 0xff) << 16 | (0 & 0xff) << 8 | (0 & 0xff);

                    // First check white, as most colors will be dark
                    int lightBodyAlpha = ColorUtils.CalculateMinimumAlpha(
                            colorWhite, colorInt, minContrastBodyText);
                    int lightTitleAlpha = ColorUtils.CalculateMinimumAlpha(
                            colorWhite, colorInt, minContrastTitleText);

                    if (lightBodyAlpha != -1 && lightTitleAlpha != -1)
                    {
                        // If we found valid light values, use them and return
                        bodyTextColor = ColorUtils.SetAlphaComponent(colorWhite, lightBodyAlpha);
                        titleTextColor = ColorUtils.SetAlphaComponent(colorWhite, lightTitleAlpha);
                        generatedTextColors = true;

                        return;
                    }

                    int darkBodyAlpha = ColorUtils.CalculateMinimumAlpha(
                            colorBlack, colorInt, minContrastBodyText);
                    int darkTitleAlpha = ColorUtils.CalculateMinimumAlpha(
                            colorBlack, colorInt, minContrastTitleText);

                    if (darkBodyAlpha != -1 && darkTitleAlpha != -1)
                    {
                        // If we found valid dark values, use them and return
                        bodyTextColor = ColorUtils.SetAlphaComponent(colorBlack, darkBodyAlpha);
                        titleTextColor = ColorUtils.SetAlphaComponent(colorBlack, darkTitleAlpha);
                        generatedTextColors = true;

                        return;
                    }

                    // If we reach here then we can not find title and body values which use the same
                    // lightness, we need to use mismatched values
                    bodyTextColor = lightBodyAlpha != -1
                            ? ColorUtils.SetAlphaComponent(colorWhite, lightBodyAlpha)
                            : ColorUtils.SetAlphaComponent(colorWhite, darkBodyAlpha);
                    titleTextColor = lightTitleAlpha != -1
                            ? ColorUtils.SetAlphaComponent(colorWhite, lightTitleAlpha)
                            : ColorUtils.SetAlphaComponent(colorWhite, darkTitleAlpha);
                    generatedTextColors = true;
                }
            }
        }
    }
}
