/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
    public class AnimationInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionData MotionData { get; internal set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MotionName { get; internal set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationInfo(MotionData motionData, string motionName)
        {
            MotionData = motionData;
            MotionName = motionName;
        }
    }
}
