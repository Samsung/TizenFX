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

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;

namespace Tizen.AIAvatar
{
    internal enum Viseme
    {
        sil, AE, Ah, B_M_P, Ch_J, EE, Er, IH, Oh, W_OO, S_Z, F_V, TH,
        T_L_D_N, K_G_H_NG, R
    };

    internal class AnimationConverter
    {
        private Dictionary<string, string> VowelToViseme
            = new Dictionary<string, string> {
            { "A", "Ah" },
            { "E", "AE" },
            { "I", "EE" },
            { "O", "R" },
            { "ER", "R" },
            { "U", "W_OO" },
            { "HM", "B_M_P" },
            { "sil", "sil" }
        };

        private AnimationKeyFrame _animationKeyFrame;
        private BlendShapeInfo _visemBlendShapeInfo;
        private Dictionary<string, BlendShapeValue[]> _visemeMap;

        private bool _isInitialized;

        public AnimationConverter() { }

        public void InitializeVisemeInfo(string info_path)
        {
            try
            {
                StreamReader v = new StreamReader(info_path);
                var jsonString = v.ReadToEnd();

                _visemBlendShapeInfo = JsonConvert.DeserializeObject<BlendShapeInfo>(jsonString);
                _visemeMap = _visemBlendShapeInfo.GetVisemeMap();

                var nodeNames = _visemBlendShapeInfo.GetNodeNames();
                var blendShapeCounts = _visemBlendShapeInfo.GetBlendShapeCounts();
                var blendShapeKeyFormat = _visemBlendShapeInfo.blendShape.keyFormat;

                _animationKeyFrame = new AnimationKeyFrame(nodeNames,
                                                           blendShapeCounts,
                                                           blendShapeKeyFormat);
                _isInitialized = true;
            }
            catch (Exception)
            {
                throw new FailedPersonalizeException(info_path);
            }
        }

        public AnimationKeyFrame ConvertVowelsToAnimation(string[] vowels,
                                                          float stepDuration)
        {
            if (!_isInitialized) throw new NotInitializedException();

            _animationKeyFrame.ClearAnimation();
            ConvertVowelsToVisemes(vowels, out var visemes);
            ConvertVisemesToAnimationKeyFrame(visemes, stepDuration);

            return _animationKeyFrame;
        }

        public AnimationKeyFrame ConvertVowelsToAnimationMic(string[] vowels,
                                                             float stepDuration)
        {
            if (!_isInitialized) throw new NotInitializedException();

            _animationKeyFrame.ClearAnimation();
            ConvertVowelsToVisemes(vowels, out var visemes);
            ConvertVisemesToAnimationKeyFrameMic(visemes, stepDuration);

            return _animationKeyFrame;
        }

        private void ConvertVowelsToVisemes(in string[] vowels,
                                            out string[] visemes)
        {
            visemes = new string[vowels.Length];

            for (var i = 0; i < vowels.Length; i++)
            {
                if (!VowelToViseme.TryGetValue(vowels[i], out visemes[i]))
                {
                    throw new InvalidVowelTypeException(vowels[i]);
                }
            }
        }

        private void ConvertVisemesToAnimationKeyFrame(in string[] visemes,
                                                       float stepDuration)
        {
            float animationTime = visemes.Length * stepDuration;
            _animationKeyFrame.SetAnimationTime(animationTime);

            for (int i = 0; i < visemes.Length; i++)
            {
                float timeStamp = GetTimeStamp(i, stepDuration) / animationTime;

                foreach (var info in _visemeMap[visemes[i]])
                {
                    _animationKeyFrame.AddKeyFrame(info.nodeName,
                                                   info.blendIndex,
                                                   timeStamp,
                                                   info.blendValue);
                }
            }
        }

        private void ConvertVisemesToAnimationKeyFrameMic(in string[] visemes,
                                                          float stepDuration)
        {
            float animationTime = (visemes.Length - 1) * stepDuration;
            _animationKeyFrame.SetAnimationTime(animationTime);

            for (int i = 0; i < visemes.Length; i++)
            {
                float timeStamp = GetTimeStamp(i, stepDuration) / animationTime;

                foreach (var info in _visemeMap[visemes[i]])
                {
                    _animationKeyFrame.AddKeyFrame(info.nodeName,
                                                   info.blendIndex,
                                                   timeStamp,
                                                   info.blendValue);
                }
            }
        }

        private float GetTimeStamp(int idx, float stepDuration)
        {
            if (idx > 0)
                return (idx * stepDuration) - (stepDuration / 2.0f);
            else
                return 0;
        }
    }
}