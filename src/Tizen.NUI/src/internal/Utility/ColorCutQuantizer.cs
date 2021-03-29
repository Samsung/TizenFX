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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI
{
    internal sealed class ColorCutQuantizer
    {
        private const float blackMaxLightness = 0.05f;
        private const float whiteMinLightness = 0.95f;
        private const int componentRed = -3;
        private const int componentGreen = -2;
        private const int componentBlue = -1;

        private static Dictionary<int, int> colorPopulations;
        private static int[] colors;
        private List<Palette.Swatch> quantizedColors;
        private float[] tempHsl = new float[3];

        private ColorCutQuantizer(ColorHistogram colorHistogram, int maxColors)
        {
            if (colorHistogram == null)
            {
                throw new ArgumentNullException(nameof(colorHistogram), "colorHistogram should not be null.");
            }

            if (maxColors < 1)
            {
                throw new ArgumentNullException(nameof(maxColors), "maxColors should not be null.");
            }

            int rawColorCount = colorHistogram.GetNumberOfColors();
            int[] rawColors = colorHistogram.GetColors();
            int[] rawColorCounts = colorHistogram.GetColorCounts();

            // First, lets pack the populations into a SparseIntArray so that they can be easily
            // retrieved without knowing a color's index
            colorPopulations = new Dictionary<int, int>();

            for (int i = 0; i < rawColors.Length; i++)
            {
                colorPopulations.Add(rawColors[i], rawColorCounts[i]);
            }

            // Now go through all of the colors and keep those which we do not want to ignore
            colors = new int[rawColorCount];
            int validColorCount = 0;

            foreach (int color in rawColors)
            {
                if (!ShouldIgnoreColor(color))
                {
                    colors[validColorCount++] = color;
                }
            }

            Tizen.Log.Info("Palette", "ValidColorCount = " + validColorCount + "\n");
            if (validColorCount <= maxColors)
            {
                // The image has fewer colors than the maximum requested, so just return the colors
                quantizedColors = new List<Palette.Swatch>();

                for (int i = 0; i < validColorCount; i++)
                {
                    quantizedColors.Add(new Palette.Swatch(colors[i], colorPopulations[colors[i]]));
                }
            }
            else
            {

                Tizen.Log.Info("Palette", "validColorCount = " + validColorCount + " maxColors = " + maxColors + "\n");
                // We need use quantization to reduce the number of colors
                quantizedColors = QuantizePixels(validColorCount - 1, maxColors);
            }
        }

        /// <summary>
        /// Factory-method to generate a ColorCutQuantizer from a  PixelBuffer object.
        /// </summary>
      public static ColorCutQuantizer FromBitmap(PixelBuffer pixelBuffer, Rectangle region, int maxColors)
        {
            int width;
            int height;
            int[] pixels;
            int i, j, index = 0;

            if (region == null)
            {
                width = (int)pixelBuffer.GetWidth(); height = (int)pixelBuffer.GetHeight(); i = 0; j = 0;
            }

            else
            {
                width = region.Width; height = region.Height; i = region.X; j = region.Y;
            }

            Tizen.Log.Info("Palette", "Get pixels raw data from (" + i + " " + j + " " + width + " " + height + ")" + "\n");

            pixels = new int[width * height];
            PixelFormat format = pixelBuffer.GetPixelFormat();
            int pixelLength = (int)ColorUtils.GetBytesPerPixel(format);
            IntPtr bufferIntPtr = pixelBuffer.GetBuffer();

            unsafe
            {
                byte *rawdata = (byte *)bufferIntPtr.ToPointer();
                int totalLength = width * height * pixelLength;
                for (i = 0; i < totalLength; i += pixelLength)
                {
                    //RGB888
                    if (pixelLength == 3)
                        pixels[index++] = (255 & 0xff) << 24 | (rawdata[i] & 0xff) << 16 | (rawdata[i+1] & 0xff) << 8 | (rawdata[i+2] & 0xff);
                    //RGBA8888
                    else
                        pixels[index++] = (rawdata[i + 3]  & 0xff) << 24 | (rawdata[i] & 0xff) << 16 | (rawdata[i+1] & 0xff) << 8 | (rawdata[i+2] & 0xff);
                }
            }

            return new ColorCutQuantizer(new ColorHistogram(pixels), maxColors);
        }

        /// <summary>
        /// return the list of quantized colors
        /// </summary>
        public List<Palette.Swatch> GetQuantizedColors()
        {
            return quantizedColors;
        }

        private List<Palette.Swatch> QuantizePixels(int maxColorIndex, int maxColors)
        {
            // Create the priority queue which is sorted by volume descending. This means we always
            // split the largest box in the queue
            CustomHeap<Vbox> customHeap = new CustomHeap<Vbox>(new VboxComparatorVolume());
            // To start, offer a box which contains all of the colors
            customHeap.Offer(new Vbox(0, maxColorIndex));
            // Now go through the boxes, splitting them until we have reached maxColors or there are no
            // more boxes to split
            SplitBoxes(customHeap, maxColors);
            // Finally, return the average colors of the color boxes
            return GenerateAverageColors(customHeap);
        }

        /// <summary>
        /// Iterate through the queue, popping
        /// ColorCutQuantizer.Vbox objects from the queue
        /// and splitting them. Once split, the new box and the remaining box are offered back to the
        /// queue.
        ///
        /// param queue PriorityQueue to poll for boxes
        /// param maxSize Maximum amount of boxes to split
        /// </summary>
        private void SplitBoxes(CustomHeap<Vbox> queue, int maxSize)
        {
            int i = 0;
            while (queue.count < maxSize)
            {
                i++;
                Vbox vbox = queue.Poll();
                if (vbox != null && vbox.CanSplit())
                {
                    // First split the box, and offer the result
                    queue.Offer(vbox.SplitBox());
                    // Then offer the box back
                    queue.Offer(vbox);
                }
                else
                {
                    // If we get here then there are no more boxes to split, so return
                    return;
                }   
            }
        }

        private List<Palette.Swatch> GenerateAverageColors(CustomHeap<Vbox> vboxes)
        {
            List<Palette.Swatch> colors = new List<Palette.Swatch>(vboxes.count);
            foreach (Vbox vbox in vboxes)
            {
                Palette.Swatch color = vbox.GetAverageColor();
                if (!ShouldIgnoreColor(color))
                {
                    // As we're averaging a color box, we can still get colors which we do not want, so
                    // we check again here
                    colors.Add(color);
                }
            }

            Tizen.Log.Info("Palette", "Final generated color count = " + colors.Count + "\n");
            return colors;
        }

        private Boolean ShouldIgnoreColor(int color)
        {
            ColorUtils.RgbToHsl((color >> 16) & 0xff, (color >> 8) & 0xff, color & 0xff, tempHsl);
            return ShouldIgnoreColor(tempHsl);
        }

        private static Boolean ShouldIgnoreColor(Palette.Swatch color)
        {
            return ShouldIgnoreColor(color.GetHsl());
        }

        private static Boolean ShouldIgnoreColor(float[] hslColor)
        {
            return IsWhite(hslColor) || IsBlack(hslColor) || IsNearRedILine(hslColor);
        }

        /// <summary>
        ///return true if the color represents a color which is close to black.
        /// </summary>
        private static Boolean IsBlack(float[] hslColor)
        {
            return hslColor[2] <= blackMaxLightness;
        }

        /// <summary>
        /// return true if the color represents a color which is close to white.
        /// </summary>
        private static Boolean IsWhite(float[] hslColor)
        {
            return hslColor[2] >= whiteMinLightness;
        }

        /// <summary>
        /// return true if the color lies close to the red side of the I line.
        /// </summary>
        private static Boolean IsNearRedILine(float[] hslColor)
        {
            return hslColor[0] >= 10f && hslColor[0] <= 37f && hslColor[1] <= 0.82f;
        }

        private sealed class CustomHeap<T> : IEnumerable<T>
        {
            private const int initialcapacity = 0;
            private const int growFactor = 2;
            private const int minGrow = 1;

            private int capacity = initialcapacity;
            private int tail = 0;
            private T[] heap = Array.Empty<T>();

            public CustomHeap(Comparer<T> comparer)
            {
                if (comparer == null) throw new ArgumentNullException(nameof(comparer), "comparer is null");
                Comparer = comparer;
            }

            private Comparer<T> Comparer { get; set; }

            public IEnumerator<T> GetEnumerator()
            {
                return heap.Take(count).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int count { get { return tail; } }

            public void Offer(T item)
            {
                if (count == capacity)
                    Grow();

                heap[tail++] = item;
                BubbleUp(tail - 1);
            }

            public T Peek()
            {
                if (count == 0) throw new InvalidOperationException("CustomHeap is empty");
                return heap[0];
            }

            public T Poll()
            {
                if (count == 0) throw new InvalidOperationException("CustomHeap is empty");
                T ret = heap[0];

                tail--;
                Swap(tail, 0);
                BubbleDown(0);

                return ret;
            }

            private void BubbleDown(int i)
            {
                int dominatingNode = Dominating(i);

                if (dominatingNode == i) return;
                Swap(i, dominatingNode);
                BubbleDown(dominatingNode);
            }

            private void BubbleUp(int i)
            {
                if (i == 0 || Dominates(heap[Parent(i)], heap[i]))
                    return;

                Swap(i, Parent(i));
                BubbleUp(Parent(i));
            }

            private int Dominating(int i)
            {
                int dominatingNode = i;

                dominatingNode = GetDominating(YoungChild(i), dominatingNode);
                dominatingNode = GetDominating(OldChild(i), dominatingNode);
                return dominatingNode;
            }

            private int GetDominating(int newNode, int dominatingNode)
            {
                if (newNode < tail && !Dominates(heap[dominatingNode], heap[newNode]))
                    return newNode;
                else
                    return dominatingNode;
            }

            private void Swap(int i, int j)
            {
                T tmp = heap[i];

                heap[i] = heap[j];
                heap[j] = tmp;
            }

            private static int Parent(int i)
            {
                return (i + 1) / 2 - 1;
            }

            private static int YoungChild(int i)
            {
                return (i + 1) * 2 - 1;
            }

            private static int OldChild(int i)
            {
                return YoungChild(i) + 1;
            }

            private void Grow()
            {
                int newcapacity = capacity * growFactor + minGrow;
                var newHeap = new T[newcapacity];

                Array.Copy(heap, newHeap, capacity);
                heap = newHeap;
                capacity = newcapacity;
            }

            private bool Dominates(T x, T y)
            {
                return Comparer.Compare(x, y) <= 0;
            }

        }

        /// <summary>
        /// Comparator which sorts Vbox instances based on their volume, in descending order
        /// </summary>
        private sealed class VboxComparatorVolume : Comparer<Vbox>
        {
            public override int Compare(Vbox lhs, Vbox rhs)
            {
                return rhs.GetVolume() - lhs.GetVolume();
            }
        }

        /// <summary>
        /// Represents a tightly fitting box around a color space.
        /// </summary>
        private sealed class Vbox
        {
            private int lowerIndex;
            private int upperIndex;
            private int minRed, maxRed, minGreen, maxGreen, minBlue, maxBlue;

            public Vbox(int lowerIndex, int upperIndex)
            {
                this.lowerIndex = lowerIndex;
                this.upperIndex = upperIndex;
                FitBox();
            }

            public int GetVolume()
            {
                return (maxRed - minRed + 1) * (maxGreen - minGreen + 1) * (maxBlue - minBlue + 1);
            }

            public Boolean CanSplit()
            {
                return GetColorCount() > 1;
            }

            public int GetColorCount()
            {
                return upperIndex - lowerIndex;
            }

            /// <summary>
            /// Recomputes the boundaries of this box to tightly fit the colors within the box.
            /// </summary>
            public void FitBox()
            {
                // Reset the min and max to opposite values
                minRed = minGreen = minBlue = 0xff;
                maxRed = maxGreen = maxBlue = 0x0;
                for (int i = lowerIndex; i <= upperIndex; i++)
                {
                    int red = (colors[i] >> 16) & 0xff;
                    int green = (colors[i] >> 8) & 0xff;
                    int blue = colors[i] & 0xff;
 
                    maxRed = red > maxRed ? red : maxRed;
                    minRed = red < minRed ? red : minRed;
                    maxGreen = green > maxGreen ? green : maxGreen;
                    minGreen = green < minGreen ? green : minGreen;
                    maxBlue = blue > maxBlue ? blue : maxBlue;
                    minBlue = blue < minBlue ? blue : minBlue;
                }
            }

            /// <summary>
            /// Split this color box at the mid-point along it's longest dimension
            ///
            /// return the new ColorBox
            /// </summary>
            public Vbox SplitBox()
            {
                if (!CanSplit())
                {
                    throw new InvalidOperationException("Can not split a box with only 1 color");
                }

                // find median along the longest dimension
                int splitPoint = FindSplitPoint();

                Vbox newBox = new Vbox(splitPoint + 1, upperIndex);
                // Now change this box's upperIndex and recompute the color boundaries
                upperIndex = splitPoint;
                FitBox();

                return newBox;
            }

            /// <summary>
            /// return the dimension which this box is largest in
            /// </summary>
            public int GetLongestColorDimension()
            {
                int redLength = maxRed - minRed;
                int greenLength = maxGreen - minGreen;
                int blueLength = maxBlue - minBlue;

                if (redLength >= greenLength && redLength >= blueLength)
                {
                    return componentRed;
                }
                else if (greenLength >= redLength && greenLength >= blueLength)
                {
                    return componentGreen;
                }
                else
                {
                    return componentBlue;
                }
            }

            /// <summary>
            /// Finds the point within this box's lowerIndex and upperIndex index of where to split.
            ///
            /// This is calculated by finding the longest color dimension, and then sorting the
            /// sub-array based on that dimension value in each color. The colors are then iterated over
            /// until a color is found with at least the midpoint of the whole box's dimension midpoint.
            ///
            /// return the index of the colors array to split from
            /// </summary>
            public int FindSplitPoint()
            {
                int longestDimension = GetLongestColorDimension();

                // We need to sort the colors in this box based on the longest color dimension.
                // As we can't use a Comparator to define the sort logic, we modify each color so that
                // it's most significant is the desired dimension
                ModifySignificantOctet(longestDimension, lowerIndex, upperIndex);

                Array.Sort(colors, lowerIndex, upperIndex + 1 - lowerIndex);
                
                // Now revert all of the colors so that they are packed as RGB again
                ModifySignificantOctet(longestDimension, lowerIndex, upperIndex);

                int dimensionMidPoint = MidPoint(longestDimension);
                for (int i = lowerIndex; i < upperIndex; i++)
                {
                    switch (longestDimension)
                    {
                        case componentRed:
                            if (((colors[i] >> 16) & 0xff) >= dimensionMidPoint)
                            {
                                return i;
                            }
                            break;
                        case componentGreen:
                            if (((colors[i] >> 8) & 0xff) >= dimensionMidPoint)
                            {
                                return i;
                            }
                            break;
                        case componentBlue:
                            if ((colors[i] &0xff) > dimensionMidPoint)
                            {
                                return i;
                            }
                            break;
                    }
                }

                return lowerIndex;
            }

            /// <summary>
            /// return the average color of this box.
            /// </summary>
            public Palette.Swatch GetAverageColor()
            {
                int redSum = 0;
                int greenSum = 0;
                int blueSum = 0;
                int totalPopulation = 0;

                for (int i = lowerIndex; i <= upperIndex; i++)
                {
                    int colorPopulation = colorPopulations[colors[i]];
                    totalPopulation += colorPopulation;
                    redSum += colorPopulation * ((colors[i] >> 16) & 0xff);
                    greenSum += colorPopulation * ((colors[i] >> 8) & 0xff);
                    blueSum += colorPopulation * (colors[i] & 0xff);
                }

                int redAverage = (int)Math.Round(redSum / (float)totalPopulation);
                int greenAverage = (int)Math.Round(greenSum / (float)totalPopulation);
                int blueAverage = (int)Math.Round(blueSum / (float)totalPopulation);

                return new Palette.Swatch(redAverage, greenAverage, blueAverage, totalPopulation);
            }

            /// <summary>
            /// return the midpoint of this box in the given dimension
            /// </summary>
            private int MidPoint(int dimension)
            {
                switch (dimension)
                {
                    case componentRed:
                    default:
                        return (minRed + maxRed) / 2;
                    case componentGreen:
                        return (minGreen + maxGreen) / 2;
                    case componentBlue:
                        return (minBlue + maxBlue) / 2;
                }
            }

            /// <summary>
            /// Modify the significant octet in a packed color int. Allows sorting based on the value of a
            /// single color component.
            ///
            /// see Vbox#findSplitPoint()
            /// </summary>
            private void ModifySignificantOctet(int dimension, int lowIndex, int highIndex)
            {
                switch (dimension)
                {
                    case componentRed:
                        // Already in RGB, no need to do anything
                        break;
                    case componentGreen:
                        // We need to do a RGB to GRB swap, or vice-versa
                        for (int i = lowIndex; i <= highIndex; i++)
                        {
                            int color = colors[i];
                            colors[i] = 255 << 24 | (color >> 8 & 0xff) << 16 | (color >> 16 & 0xff) << 8 | (color & 0xff);
                        }

                        break;
                    case componentBlue:
                        // We need to do a RGB to BGR swap, or vice-versa
                        for (int i = lowIndex; i <= highIndex; i++)
                        {
                            int color = colors[i];
                            colors[i] = 255 << 24 | (color & 0xff) << 16 | (color >> 8 & 0xff) << 8 | (color >> 16 & 0xff);
                        }
                        break;
                }
            }
        }
    }
}
