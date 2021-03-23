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
    internal sealed class ColorHistogram
    {
        private int numberColors;
        private int[] colors;
        private int[] colorCounts;

        /// <summary>
        /// A new ColorHistogram instance.
        /// </summary>
        public ColorHistogram(int[] pixels)
        {
            // Sort the pixels to enable counting below
            Array.Sort(pixels);

            // Count number of distinct colors
            numberColors = CountDistinctColors(pixels);
            Tizen.Log.Info("Palette", "DistinctColor Num = " + numberColors + "\n");

            // Create arrays
            colors = new int[numberColors];
            colorCounts = new int[numberColors];

            // Finally count the frequency of each color
            CountFrequencies(pixels);
        }

        /// <summary>
        /// return number of distinct colors in the image.
        /// </summary>
        public int GetNumberOfColors()
        {
            return numberColors;
        }

        /// <summary>
        /// return an array containing all of the distinct colors in the image.
        /// </summary>
        public int[] GetColors()
        {
            return colors;
        }

        /// <summary>
        /// return an array containing the frequency of a distinct colors within the image.
        /// </summary>
        public int[] GetColorCounts()
        {
            return colorCounts;
        }

        private static int CountDistinctColors(int[] pixels)
        {
            if (pixels.Length < 2)
            {
                // If we have less than 2 pixels we can stop here
                return pixels.Length;
            }
            // If we have at least 2 pixels, we have a minimum of 1 color...
            int colorCount = 1;
            int currentColor = pixels[0];

            // Now iterate from the second pixel to the end, counting distinct colors
            for (int i = 1; i < pixels.Length; i++)
            {
                // If we encounter a new color, increase the population
                if (pixels[i] != currentColor)
                {
                    currentColor = pixels[i];
                    colorCount++;
                }
            }

            return colorCount;
        }

        private void CountFrequencies(int[] pixels)
        {
            if (pixels.Length == 0)
            {
                return;
            }

            int currentColorIndex = 0;
            int currentColor = pixels[0];

            colors[currentColorIndex] = currentColor;
            colorCounts[currentColorIndex] = 1;

            if (pixels.Length == 1)
            {
                // If we only have one pixel, we can stop here
                return;
            }

            // Now iterate from the second pixel to the end, population distinct colors
            for (int i = 1; i < pixels.Length; i++)
            {
                if (pixels[i] == currentColor)
                {
                    // We've hit the same color as before, increase population
                    colorCounts[currentColorIndex]++;
                }
                else
                {
                    // We've hit a new color, increase index
                    currentColor = pixels[i];
                    currentColorIndex++;
                    colors[currentColorIndex] = currentColor;
                    colorCounts[currentColorIndex] = 1;
                }
            }
        }
    }
}
