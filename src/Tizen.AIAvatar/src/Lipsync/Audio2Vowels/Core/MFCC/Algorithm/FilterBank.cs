/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using System;
using System.Linq;

namespace Tizen.AIAvatar
{
    internal struct bangDouble
    {
        public double left;
        public double center;
        public double right;

        public bangDouble(double l, double c, double r)
        {
            left = l;
            center = c;
            right = r;
        }

    }

    internal class FilterBank
    {
        private float[][] _filterBank;
        private int _filterBankSize;

        public FilterBank(int filterBankSize, int samplingRate, int blockSize)
        {
            _filterBankSize = filterBankSize;
            var melBands = MelBands(filterBankSize, samplingRate);
            _filterBank = Triangular(blockSize, samplingRate, melBands, HerzToMel);
        }

        public void Apply(float[] input, float[] output)
        {
            for (var i = 0; i < _filterBankSize; i++)
            {
                var sum = 0.0f;

                for (var j = 0; j < input.Length; j++)
                {
                    sum += _filterBank[i][j] * input[j];
                }

                output[i] = (float)Math.Log10(Math.Max(sum, float.Epsilon));
            }
        }

        public static void Apply(float[][] filterBank, float[] spectrum, float[] filtered)
        {
            for (var i = 0; i < filterBank.Length; i++)
            {
                var en = 0.0f;

                for (var j = 0; j < spectrum.Length; j++)
                {
                    en += filterBank[i][j] * spectrum[j];
                }

                filtered[i] = en;
            }
        }

        public static bangDouble[] MelBands(
            int melFilterCount, int samplingRate, float lowFreq = 0, float highFreq = 0, bool overlap = true)
        {
            return UniformBands(HerzToMel, MelToHerz, melFilterCount, samplingRate, lowFreq, highFreq, overlap);
        }

        public static float[][] Triangular(int fftSize,
                                           int samplingRate,
                                           bangDouble[] frequencies,
                                           Func<double, double> mapper = null)
        {
            if (mapper is null) mapper = x => x;

            var herzResolution = (float)samplingRate / fftSize;
            var herzFrequencies = Enumerable.Range(0, fftSize / 2 + 1)
                                            .Select(f => f * herzResolution)
                                            .ToArray();

            var filterCount = frequencies.Length;
            var filterBank = new float[filterCount][];

            for (var i = 0; i < filterCount; i++)
            {
                filterBank[i] = new float[fftSize / 2 + 1];

                var left = frequencies[i].left;
                var center = frequencies[i].center;
                var right = frequencies[i].right;

                left = mapper(left);
                center = mapper(center);
                right = mapper(right);

                var j = 0;
                for (; mapper(herzFrequencies[j]) <= left; j++) ;
                for (; mapper(herzFrequencies[j]) <= center; j++)
                {
                    filterBank[i][j] = (float)((mapper(herzFrequencies[j]) - left) / (center - left));
                }
                for (; j < herzFrequencies.Length && mapper(herzFrequencies[j]) < right; j++)
                {
                    filterBank[i][j] = (float)((right - mapper(herzFrequencies[j])) / (right - center));
                }
            }

            return filterBank;
        }

        private static bangDouble[] UniformBands(
                                                    Func<double, double> scaleMapper,
                                                    Func<double, double> inverseMapper,
                                                    int filterCount,
                                                    int samplingRate,
                                                    float lowFreq = 0,
                                                    float highFreq = 0,
                                                    bool overlap = true)
        {
            if (lowFreq < 0) lowFreq = 0;
            if (highFreq <= lowFreq) highFreq = samplingRate * 0.5f;

            var startingFrequency = scaleMapper(lowFreq);
            var frequencyTuples = new bangDouble[filterCount];

            if (overlap)
            {
                var newResolution = (scaleMapper(highFreq) - scaleMapper(lowFreq)) / (filterCount + 1);
                var frequencies = Enumerable.Range(0, filterCount + 2)
                                            .Select(i => inverseMapper(startingFrequency + i * newResolution))
                                            .ToArray();
                for (var i = 0; i < filterCount; i++)
                {
                    frequencyTuples[i].left = frequencies[i];
                    frequencyTuples[i].center = frequencies[i + 1];
                    frequencyTuples[i].right = frequencies[i + 2];
                }
            }
            else
            {
                var newResolution = (scaleMapper(highFreq) - scaleMapper(lowFreq)) / filterCount;
                var frequencies = Enumerable.Range(0, filterCount + 1)
                                            .Select(i => inverseMapper(startingFrequency + i * newResolution))
                                            .ToArray();

                for (var i = 0; i < filterCount; i++)
                {
                    frequencyTuples[i].left = frequencies[i];
                    frequencyTuples[i].center = (frequencies[i] + frequencies[i + 1]) / 2;
                    frequencyTuples[i].right = frequencies[i + 2];
                }
            }

            return frequencyTuples;
        }

        public static double HerzToMel(double herz)
        {
            return 1127 * Math.Log(herz / 700 + 1);
        }

        public static double MelToHerz(double mel)
        {
            return (Math.Exp(mel / 1127) - 1) * 700;
        }
    }
}