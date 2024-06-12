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

using System.Collections.Generic;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class VowelConverter
    {
        private TFVowel6 vowelClassfierModel = null;
        private VowelClassifier vowelClassifier = null;
        private Dictionary<int, VowelClassifier> vowelClassifiers;
        private AnimationConverter animationConverter = new AnimationConverter();

        internal VowelConverter()
        {
            vowelClassifiers = new Dictionary<int, VowelClassifier>();
            vowelClassifier = GetVowelClassifier(CurrentAudioOptions.SampleRate);
            vowelClassfierModel = new TFVowel6(new int[4] { 12, 1, 1, 1 }, new int[4] { 7, 1, 1, 1 });
            animationConverter.InitializeVisemeInfo(VisemeInfo);
        }

        internal AnimationKeyFrame CreateKeyFrames(string[] vowels, int sampleRate, bool isMic = false)
        {
            vowelClassifier = GetVowelClassifier(sampleRate);

            if (isMic)
            {
                return animationConverter.ConvertVowelsToAnimationMic(vowels, vowelClassifier.GetStepTime());
            }
            else
            {
                return animationConverter.ConvertVowelsToAnimation(vowels, vowelClassifier.GetStepTime());
            }
        }

        internal AnimationKeyFrame CreateKeyFrames(byte[] audioData, int sampleRate, bool isMic = false)
        {
            vowelClassifier = GetVowelClassifier(sampleRate);

            if (vowelClassifier == null)
            {
                Log.Error(LogTag, "Failed to play Buffer");
                return null;
            }
            var vowels = PredictVowels(audioData);
            Log.Info(LogTag, $"vowelRecognition: {string.Join(", ", vowels)}");

            if (isMic) return animationConverter.ConvertVowelsToAnimationMic(vowels, vowelClassifier.GetStepTime());
            else return animationConverter.ConvertVowelsToAnimation(vowels, vowelClassifier.GetStepTime());
        }

        internal string[] PredictVowels(byte[] audioData)
        {
            var vowels = vowelClassifier.Inference(audioData, vowelClassfierModel);
            return vowels;
        }

        internal VowelClassifier GetVowelClassifier(int sampleRate)
        {
            if (vowelClassifiers.ContainsKey(sampleRate))
            {
                return vowelClassifiers[sampleRate];
            }
            else
            {
                vowelClassifiers[sampleRate] = new VowelClassifier(sampleRate);
                return vowelClassifiers[sampleRate];
            }
        }
    }
}
