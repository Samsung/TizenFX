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
    internal class BlendShapeInfo
    {
        public BlendShapeModelInfo blendShape;
        public BlendShapeVisemeInfo[] visemes;

        public BlendShapeInfo() { }

        public string[] GetNodeNames()
        {
            return blendShape.nodeNames;
        }

        public int[] GetBlendShapeCounts()
        {
            return blendShape.blendShapeCount;
        }

        public Dictionary<string, BlendShapeValue[]> GetVisemeMap()
        {
            Dictionary<string, BlendShapeValue[]> visemeMap
                = new Dictionary<string, BlendShapeValue[]>();

            foreach (var visemeInfo in this.visemes)
            {
                visemeMap.Add(visemeInfo.name, visemeInfo.values);
            }

            return visemeMap;
        }
    }

    internal class BlendShapeModelInfo
    {
        public string keyFormat;
        public string[] nodeNames;
        public int[] blendShapeCount;

        public BlendShapeModelInfo(string keyFormat, string[] nodeNames, int[] blendShapeCount)
        {
            this.keyFormat = keyFormat;
            this.nodeNames = nodeNames;
            this.blendShapeCount = blendShapeCount;
        }
    }

    internal class BlendShapeVisemeInfo
    {
        public string name;
        public BlendShapeValue[] values;
    }

    internal class BlendShapeValue
    {
        public string nodeName;
        public int blendIndex;
        public float blendValue;
    }
}
