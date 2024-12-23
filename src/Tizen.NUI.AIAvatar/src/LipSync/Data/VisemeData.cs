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
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace Tizen.NUI.AIAvatar
{
    internal class VisemeData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("visemeParameters")]
        public VisemeParameters visemeParameters { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("visemes")]
        public List<Viseme> visemes { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisemeData()
        {
            visemeParameters = new VisemeParameters();
            visemes = new List<Viseme>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<string, BlendShapeValue[]> GetVisemeMap()
        {
            Dictionary<string, BlendShapeValue[]> visemeMap
                = new Dictionary<string, BlendShapeValue[]>();

            foreach (var viseme in this.visemes)
            {
                if (!visemeMap.ContainsKey(viseme.name))
                {
                    visemeMap.Add(viseme.name, viseme.values.Select(v => new BlendShapeValue { nodeName = v.nodeName, id = v.id, value = (float)v.value }).ToArray());
                }
            }

            return visemeMap;
        }
    }

    internal class VisemeParameters
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("keyFormat")]
        public string keyFormat { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("nodeNames")]
        public List<string> nodeNames { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("blendShapeCount")]
        public List<int> blendShapeCount { get; set; }
    }

    internal class Viseme
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("symbol")]
        public string symbol { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonPropertyName("values")]
        public List<BlendShapeValue> values { get; set; }
    }


    internal class BlendShapeValue
    {
        [JsonPropertyName("nodeName")]
        public string nodeName { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("value")]
        public float value { get; set; }
    }
}
