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

using System.ComponentModel;
using Tizen.NUI.Scene3D;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionBehaviorData : IAnimationModuleData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionDataType Type { get; set; } = MotionDataType.AnimationInfo;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationInfo AnimationInfo { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionData MotionData { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Duration { get; set; } = 3000;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsLooping { get; set; } = false;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount { get; set; } = 1;
    }
}
