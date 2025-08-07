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
 */

using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tizen.NUI.AIAvatar
{
    internal class FaceAnimationData
    {
        public string name { get; set; }
        public string version { get; set; }
        public List<FaceAnimBlendShape> blendShapes { get; set; }
        public int shapesAmount { get; set; }
        public List<int> time { get; set; }
        public int frames { get; set; }
    }
    internal class FaceAnimBlendShape
    {
        public string name { get; set; }
        public string fullName { get; set; }
        public string blendShapeVersion { get; set; }
        public int morphtarget { get; set; }
        public List<string> morphname { get; set; }
        public List<List<float>> key { get; set; }
    }


    internal class Expression
    {
        public string name { get; set; }
        public List<string> filename { get; set; }
    }

    internal class IgnoreBlendShape
    {
        public string name { get; set; }
        public List<string> morphname { get; set; }
    }


    internal class EmotionConfig
    {
        public List<Expression> expressions { get; set; }
        public List<IgnoreBlendShape> ignoreBlendShapes { get; set; }
    }


}
