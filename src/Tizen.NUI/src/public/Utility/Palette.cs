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
using System.Drawing;
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
    ///
    /// Palette supports both synchronous and asynchronous generation:
    ///
    /// Synchronous
    /// Palette P = Palette.Generate(bitmap);
    ///
    /// Asynchronous
    /// Palette.GenerateAsync(bitmap, (Palette p) => {
    ///     // Use generated instance
    /// }};
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
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

            // To get swatch infomation as string.
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

        public delegate void PaletteGeneratedEventHandler(Palette palette);

        /// <summary>
        /// Generate a Palette asynchronously using bitmap as source.
        /// </summary>
        /// <param name="bitmap">A Target image's bitmap.</param>
        /// <param name="paletteGeneratedEventHandler">A method will be called with the palette when generated.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument bitmap, PaletteGeneratedEventHandler is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void GenerateAsync(Bitmap bitmap, PaletteGeneratedEventHandler paletteGeneratedEventHandler)
        {
            _ = AsyncTask(bitmap, null, paletteGeneratedEventHandler);
        }

        /// <summary>
        /// Generate a Palette asynchronously using bitmap as source.
        /// And set a region of the bitmap to be used exclusively when calculating the palette.
        /// </summary>
        /// <param name="bitmap">A Target image's bitmap.</param>
        /// <param name="region">A rectangle used for region.</param>    
        /// <param name="paletteGeneratedEventHandler">A method will be called with the palette when generated.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument bitmap, PaletteGeneratedEventHandler is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void GenerateAsync(Bitmap bitmap, Tizen.NUI.Rectangle region, PaletteGeneratedEventHandler paletteGeneratedEventHandler)
        {
            _ = AsyncTask(bitmap, region, paletteGeneratedEventHandler);
        }

        /// <summary>
        /// Generate a Palette synchronously using bitmap as source.
        /// </summary>
        /// <param name="bitmap">A Target image's bitmap.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument bitmap is null.</exception>
        /// <returns>the palette instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Palette generate(Bitmap bitmap)
        {
            return Generate(bitmap, null);
        }

        /// <summary>
        /// Generate a Palette synchronously using bitmap as source.
        /// And set a region of the bitmap to be used exclusively when calculating the palette.
        /// </summary>
        /// <param name="bitmap">A Target image's bitmap.</param>
        /// <param name="region">A rectangle used for region.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument bitmap is null.</exception>
        /// <returns>the palette instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Palette Generate(Bitmap bitmap, Tizen.NUI.Rectangle region)
        {
            Tizen.Log.Info("Palette", "bitmap generate start with region: " + region + "\n");
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap), "bitmap should not be null.");
            }

            // First we'll scale down the bitmap so it's shortest dimension is 100px
            // NOTE: scaledBitmap can gets bitmap origin value and new bitmap instance as well
            //       When ScaleBitmap created newly it will be dispose below.
            //       otherwise it should not disposed because of this instance from user side.
            Bitmap scaledBitmap = ScaleBitmapDown(bitmap);

            // Region set
            if (scaledBitmap != bitmap && region != null)
            {
                double scale = scaledBitmap.Width / (double)bitmap.Width;
                region.X = (int)Math.Floor(region.X * scale);
                region.Y = (int)Math.Floor(region.Y * scale);
                region.Width = Math.Min((int)Math.Ceiling(region.Width * scale), bitmap.Width);
                region.Height = Math.Min((int)Math.Ceiling(region.Height * scale), bitmap.Height);
            }

            // Now generate a Quantizer from the Bitmap
            // FIXME: defaultCalculateNumberColors should be changeable?
            ColorCutQuantizer quantizer = ColorCutQuantizer.FromBitmap(scaledBitmap, region, defaultCalculateNumberColors);

            if (scaledBitmap != bitmap) scaledBitmap.Dispose();

            // Now return a ColorExtractor instance
            return new Palette(quantizer.GetQuantizedColors());
        }

        /// <summary>
        /// Returns all of the swatches which make up the palette.
        /// </summary>
        /// <returns>The swatch list</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<Swatch> GetSwatches()
        {
            return new ReadOnlyCollection<Swatch>(swatches);
        }

        /// <summary>
        /// Returns the dominant swatch from the palette.
        /// The dominant swatch is defined as the swatch with the greatest population (frequency) within the palette.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetVibrantSwatch()
        {
            return vibrantSwatch;
        }

        /// <summary>
        /// Returns a light and vibrant swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetLightVibrantSwatch()
        {
            return lightVibrantSwatch;
        }

        /// <summary>
        /// Returns a dark and vibrant swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetDarkVibrantSwatch()
        {
            return darkVibrantSwatch;
        }

        /// <summary>
        /// Returns a muted swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetMutedSwatch()
        {
            return mutedSwatch;
        }

        /// <summary>
        /// Returns a muted and light swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetLightMutedSwatch()
        {
            return lightMutedColor;
        }

        /// <summary>
        /// Returns a muted and dark swatch from the palette. Might be null.
        /// </summary>
        /// <returns>The swatch instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Swatch GetDarkMutedSwatch()
        {
            return darkMutedSwatch;
        }

		private static async Task<Palette> AsyncTask(Bitmap bitmap, Tizen.NUI.Rectangle region, PaletteGeneratedEventHandler paletteGeneratedEventHandler)
        {
            if (paletteGeneratedEventHandler == null)
            {
                throw new ArgumentNullException(nameof(paletteGeneratedEventHandler), "PaletteGeneratedEventHandlergate should not be null.");
            }

            var GenerateTask = Task.Run(() =>
            {
                return Generate(bitmap, region);
            }).ConfigureAwait(false);

            Palette ret = await GenerateTask;
            paletteGeneratedEventHandler(ret);

            return null; ;
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
        private static Bitmap ScaleBitmapDown(Bitmap bitmap)
        {
            int minDimension = Math.Min(bitmap.Width, bitmap.Height);

            if (minDimension <= calculateBitmapMinDimension)
            {
                // If the bitmap is small enough already, just return it
                return bitmap;
            }

            float scaleRatio = calculateBitmapMinDimension / (float)minDimension;

            int width = (int)Math.Round(bitmap.Width * scaleRatio);
            int height = (int)Math.Round(bitmap.Height * scaleRatio);

            System.Drawing.Size Resize = new System.Drawing.Size(width, height);
            Tizen.Log.Info("Palette", "bitmap resize to  " + width + " " + height + "\n");

            return new Bitmap(bitmap, Resize);
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
        // Futher confirmantion need of this architect.

        /// <summary>
        /// Represents a color swatch generated from an image's palette. The RGB color can be retrieved calling getRgb()
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class Swatch
        {
            private const float minContrastTitleText = 3.0f;
            private const float minContrastBodyText = 4.5f;

            private int red, green, blue;
            private int colorInt, bodyTextColor, titleTextColor;
            private int population;
            private bool generatedTextColors;
            private System.Drawing.Color rgbDrawingColor;
            private float[] hsl;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Swatch(int rgbcolorInt, int populationOfSwatch)
            {
                System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(rgbcolorInt);
                red = rgbColor.R;
                green = rgbColor.G;
                blue = rgbColor.B;
                rgbDrawingColor = rgbColor;
                colorInt = rgbcolorInt;
                population = populationOfSwatch;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public Swatch(int redValueOfSwatch, int greenValueOfSwatch, int blueValueOfSwatch, int populationOfSwatch)
            {
                red = redValueOfSwatch;
                green = greenValueOfSwatch;
                blue = blueValueOfSwatch;
                rgbDrawingColor = System.Drawing.Color.FromArgb(red, green, blue);
                colorInt = Convert.ToInt32(rgbDrawingColor.ToArgb());
                population = populationOfSwatch;
            }

            /// <summary>
            /// return this swatch's RGB color value
            /// </summary>
            /// <returns>A Tizen.NUI.Color value.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Tizen.NUI.Color GetRgb()
            {
                return new Tizen.NUI.Color((float)red / 255, (float)green / 255, (float)blue / 255, 1.0f);
            }

            /// <summary>
            /// Return this swatch's hsl values.
            ///    hsv[0] is Hue [0 .. 360)
            ///    hsv[1] is Saturation [0...1]
            ///    hsv[2] is Lightness [0...1]
            /// </summary>
            /// <returns>A float array value.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Tizen.NUI.Color GetTitleTextColor()
            {
                EnsureTextColorsGenerated();

                System.Drawing.Color titleRgbColor = System.Drawing.Color.FromArgb(titleTextColor);
                Tizen.Log.Info("Palette", "Swatch Title Text Color = " + titleRgbColor + "\n");

                return new Tizen.NUI.Color((float)titleRgbColor.R / 255, (float)titleRgbColor.G / 255, (float)titleRgbColor.B / 255, (float)titleRgbColor.A / 255);
            }

            /// <summary>
            /// Returns an appropriate color to use for any 'body' text which is displayed over this
            /// Palette.Swatchs color. This color is guaranteed to have sufficient contrast.
            /// </summary>
            /// <returns>A Tizen.NUI.Color value.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Tizen.NUI.Color GetBodyTextColor()
            {
                EnsureTextColorsGenerated();

                System.Drawing.Color bodyRgbColor = System.Drawing.Color.FromArgb(bodyTextColor);
                Tizen.Log.Info("Palette", "Swatch Body Text Color = " + bodyRgbColor + "\n");

                return new Tizen.NUI.Color((float)bodyRgbColor.R / 255, (float)bodyRgbColor.G / 255, (float)bodyRgbColor.B / 255, (float)bodyRgbColor.A / 255);
            }

            /// <summary>
            /// return the number of pixels represented by this swatch.
            /// </summary>
            /// <returns>A number of pixels value.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPopulation()
            {
                return population;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override String ToString()
            {
                return rgbDrawingColor + " " + population;
            }

            private void EnsureTextColorsGenerated()
            {
                if (!generatedTextColors)
                {
                    int colorWhite = (255 & 0xff) << 24 | (255 & 0xff) << 16 | (255 & 0xff) << 8 | (255 & 0xff);
                    int colorBlack = (255 & 0xff) << 24 | (0 & 0xff) << 16 | (0 & 0xff) << 8 | (0 & 0xff);

                    // First check white, as most colors will be dark
                    System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(colorInt);
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
