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
using System.Collections.Generic;

namespace Tizen.AIAvatar
{
    internal class CustomMfccExtractor : IMfccExtractor
    {
        private readonly int FilterBankSize = 24;

        private int featureCount = 12;

        private int blockSize;
        private int frameSize;
        private int hopSize;

        private Window window;
        private FFT fft;
        private FilterBank filterBank;
        private DCT dct;

        private float[] block;
        private float[] spectrum;
        private float[] melSpectrum;

        public CustomMfccExtractor(int samplingRate, float frameDuration, float hopDuration, int featureCount)
        {
            this.featureCount = featureCount;

            frameSize = (int)Math.Round(samplingRate * frameDuration, 1);
            hopSize = (int)Math.Round(samplingRate * hopDuration, 1);
            blockSize = (int)Math.Pow(2, Math.Ceiling(Math.Log(frameSize, 2)));

            window = new Window(frameSize);
            fft = new FFT(blockSize);
            filterBank = new FilterBank(FilterBankSize, samplingRate, blockSize);
            dct = new DCT(FilterBankSize, this.featureCount);

            block = new float[blockSize];
            spectrum = new float[blockSize / 2 + 1];
            melSpectrum = new float[FilterBankSize];
        }

        public List<float[]> ComputeFrom(float[] audio, int sampleRate)
        {
            int totalCount = (audio.Length - frameSize) / hopSize + 1;
            List<float[]> mfccs = new List<float[]>(totalCount);

            for (var i = 0; i < totalCount; i++)
            {
                mfccs.Add(new float[featureCount]);
            }

            var lastSample = audio.Length - frameSize;
            for (int sample = 0, i = 0; sample <= lastSample; sample += hopSize, i++)
            {
                // 1. Framing
                Buffer.BlockCopy(audio, sample * sizeof(float), block, 0, frameSize * sizeof(float));

                for (var k = frameSize; k < blockSize; block[k++] = 0) { }

                // 2. PreEmphasis
                // PreEmphasis.PreEmphasize(ref block, 0.97f);

                // 3. HammingWindow
                window.Apply(block);

                // 4. FFT
                fft.Direct(block, spectrum);

                // 5. MelFilterBank
                filterBank.Apply(spectrum, melSpectrum);

                // 6. DCT
                dct.DirectNorm(melSpectrum, mfccs[i]);
            }

            return mfccs;
        }
    }

    //DLL Interface
    internal class Extractor
    {
        public static float[][] ComputeFrom(float[] audio, int samplingRate, float frameDuration, float hopDuration, int featureCount)
        {
            CustomMfccExtractor cme = new CustomMfccExtractor(samplingRate, frameDuration, hopDuration, featureCount);
            List<float[]> mfccFeatures = cme.ComputeFrom(audio, samplingRate);

            return mfccFeatures.ToArray();
        }
    }

}
