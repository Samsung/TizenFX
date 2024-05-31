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

namespace Tizen.AIAvatar
{
    internal class KeyFrame
    {
        public KeyFrame(float t, float v)
        {
            time = t;
            value = v;
        }
        public float time;
        public float value;
    }

    internal class AnimationKeyFrame
    {
        private Dictionary<string, List<KeyFrame>[]> _animationKeyFrames;

        public string[] NodeNames { get; private set; }
        public int[] BlendShapeCounts { get; private set; }
        public string BlendShapeKeyFormat { get; private set; }
        public float AnimationTime { get; private set; }

        public AnimationKeyFrame(string[] nodeNames,
                                 int[] blendShapeCounts,
                                 string blendShapeKeyFormat)
        {
            _animationKeyFrames = new Dictionary<string, List<KeyFrame>[]>();
            NodeNames = nodeNames;
            BlendShapeCounts = blendShapeCounts;
            BlendShapeKeyFormat = blendShapeKeyFormat;

            InitializeAnimation(nodeNames, blendShapeCounts);
        }

        public void SetAnimationTime(float animationTime)
        {
            AnimationTime = animationTime;
        }

        public List<KeyFrame> GetKeyFrames(string nodeName, int blendIndex)
        {
            return _animationKeyFrames[nodeName][blendIndex];
        }

        public void AddKeyFrame(string nodeName, int blendIndex, float time, float value)
        {
            _animationKeyFrames[nodeName][blendIndex].Add(new KeyFrame(time, value));
        }

        public void AddKeyFrame(string nodeName, int blendIndex, KeyFrame value)
        {
            _animationKeyFrames[nodeName][blendIndex].Add(value);
        }

        public void InitializeAnimation(string[] nodeNames, int[] blendShapeCounts)
        {
            ClearAnimation();

            for (int i = 0; i < nodeNames.Length; i++)
            {
                var nodeName = nodeNames[i];
                var blendShapeCount = blendShapeCounts[i];

                _animationKeyFrames.Add(nodeName, new List<KeyFrame>[blendShapeCount]);

                for (int j = 0; j < blendShapeCount; j++)
                {
                    _animationKeyFrames[nodeName][j] = new List<KeyFrame>();
                }
            }
        }

        public void ClearAnimation()
        {
            foreach (KeyValuePair<string, List<KeyFrame>[]> kvp in _animationKeyFrames)
            {
                foreach (List<KeyFrame> kf in kvp.Value)
                {
                    kf.Clear();
                }
            }
        }
    }
}
