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
using System.Linq;

namespace Tizen.AIAvatar
{
    internal class VowelClassifier
    {
        private readonly int vowelForecastRange = 6;
        private readonly string[] vowelName = { "A", "E", "I", "O", "U", "HM", "ER" };

        private readonly int sampleRate;
        private readonly int featureCount;

        private float stepTime = 0.0f;
        private const int DefaultFeatureMeanCount = 8;

        private CustomMfccExtractor mfccExtractor;


        internal VowelClassifier(int sampleRate, float frameDuration = 0.025f, float hopDuration = 0.01f, int featureCount = 12)
        {
            this.sampleRate = sampleRate;
            this.featureCount = featureCount;
            stepTime = (float)(hopDuration * DefaultFeatureMeanCount);
            mfccExtractor = new CustomMfccExtractor(sampleRate, frameDuration, hopDuration, featureCount);
        }

        internal float GetStepTime()
        {
            return stepTime;
        }


        internal string[] Inference(byte[] audio, ISingleShotModel model)
        {
            int length = PreprocessInput(audio, out float[] features, out List<float> audioEnergy);
            var outputData = InferenceModel(features, length, model);
            var result = ProcessOutput(outputData, audioEnergy);

            return result.ToArray();
        }

        internal int PreprocessInput(byte[] audioByte, out float[] flattenedArray, out List<float> audioEnergy)
        {
            ConvertAudioToFloat(audioByte, out var audio);

            var mfccFeatures = mfccExtractor.ComputeFrom(audio, sampleRate);

            int featureLength = (int)Math.Ceiling((double)mfccFeatures.Count / DefaultFeatureMeanCount);
            flattenedArray = new float[featureLength * featureCount];
            audioEnergy = new List<float>();

            for (int i = 0; i < featureLength; i++)
            {
                CalculateFeatureMean(mfccFeatures, out var featureMean, out var energy, i * DefaultFeatureMeanCount);
                Array.Copy(featureMean, 0, flattenedArray, i * featureCount, featureCount);
                audioEnergy.Add(energy);
            }

            return featureLength;
        }

        internal List<float[]> InferenceModel(float[] input, int length, ISingleShotModel model)
        {
            byte[] inputBuffer = new byte[4 * 12 * 1 * 1];
            byte[] outputBuffer;

            int srcOffset = 0;
            List<float[]> fullOutput = new List<float[]>();

            for (int i = 0; i < length; i++)
            {
                float[] output = new float[7];

                Buffer.BlockCopy(input, srcOffset, inputBuffer, 0, inputBuffer.Length);
                srcOffset += inputBuffer.Length;

                model.SetTensorData(0, inputBuffer);

                model.Invoke();

                outputBuffer = model.GetTensorData(0);

                Buffer.BlockCopy(outputBuffer, 0, output, 0, outputBuffer.Length);

                fullOutput.Add(output);

            }

            return fullOutput;
        }

        private void ConvertAudioToFloat(in byte[] audioBytes, out float[] audioFloat)
        {
            audioFloat = new float[audioBytes.Length / 2];

            for (int i = 0, j = 0; i < audioBytes.Length; i += 2, j++)
            {
                short sample = BitConverter.ToInt16(audioBytes, i);
                audioFloat[j] = sample / 32768.0f;
            }
        }

        private List<string> ProcessOutput(List<float[]> outputData, List<float> audioEnergy)
        {
            var result = new List<string>();

            for (int i = 0; i < outputData.Count; i++)
            {
                // Softmax 연산 수행
                if (audioEnergy[i] > -1.0f)
                {
                    var scores = Enumerable.Range(0, vowelForecastRange).
                       Select(j => outputData[i][j]).SoftMax().ToArray();
                    int maxIndex = Array.IndexOf(scores, scores.Max());
                    result.Add(vowelName[maxIndex]);
                }
                else
                {
                    result.Add("sil");
                }

            }

            return result;
        }

        private void CalculateFeatureMean(in List<float[]> features,
                                  out float[] featureMean,
                                  out float energy,
                                  int offset)
        {
            featureMean = new float[featureCount];
            int featureLength = (DefaultFeatureMeanCount < features.Count - offset
                                    ? DefaultFeatureMeanCount
                                    : features.Count - offset);

            float sum = 0f;
            for (int fc = 0; fc < featureCount; fc++)
            {
                for (int dc = offset; dc < offset + DefaultFeatureMeanCount && dc < features.Count; dc++)
                {
                    featureMean[fc] += features[dc][fc];
                }
                featureMean[fc] /= featureLength;
                sum += featureMean[fc];
            }
            energy = sum / featureCount;
        }
    }
}
