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
using System.ComponentModel;

namespace Tizen.NUI.AIAvatar
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

    internal class LipData
    {
        private Dictionary<string, List<KeyFrame>[]> blendShapeKeyFrames;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] NodeNames { get; private set; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int[] BlendShapeCounts { get; private set; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BlendShapeKeyFormat { get; private set; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Duration { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipData(string[] nodeNames,
                                 int[] blendShapeCounts,
                                 string blendShapeKeyFormat)
        {
            blendShapeKeyFrames = new Dictionary<string, List<KeyFrame>[]>();
            NodeNames = nodeNames;
            BlendShapeCounts = blendShapeCounts;
            BlendShapeKeyFormat = blendShapeKeyFormat;

            Initialize(nodeNames, blendShapeCounts);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDuration(float duration)
        {
            Duration = duration;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<KeyFrame> GetKeyFrames(string nodeName, int blendShapeId)
        {
            return blendShapeKeyFrames[nodeName][blendShapeId];
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddKeyFrame(string nodeName, int blendShapeId, float time, float value)
        {
            blendShapeKeyFrames[nodeName][blendShapeId].Add(new KeyFrame(time, value));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddKeyFrame(string nodeName, int blendShapeId, KeyFrame value)
        {
            blendShapeKeyFrames[nodeName][blendShapeId].Add(value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Initialize(string[] nodeNames, int[] blendShapeCounts)
        {
            Clear();

            for (int i = 0; i < nodeNames.Length; i++)
            {
                var nodeName = nodeNames[i];
                var blendShapeCount = blendShapeCounts[i];

                blendShapeKeyFrames.Add(nodeName, new List<KeyFrame>[blendShapeCount]);

                for (int j = 0; j < blendShapeCount; j++)
                {
                    blendShapeKeyFrames[nodeName][j] = new List<KeyFrame>();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            foreach (KeyValuePair<string, List<KeyFrame>[]> blendShapeData in blendShapeKeyFrames)
            {
                foreach (List<KeyFrame> keyFrames in blendShapeData.Value)
                {
                    keyFrames.Clear();
                }
            }
        }
    }
}
