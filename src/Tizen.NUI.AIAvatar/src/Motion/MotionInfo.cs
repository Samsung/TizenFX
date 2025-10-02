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
using System.ComponentModel;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The AnimationInfo class manages animation data for an Avatar, including motion data and names. It is not meant to be directly edited by users or editors.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionInfo
    {
        /// <summary>
        /// Gets the motion data associated with this animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionData MotionData { get; private set; }

        /// <summary>
        /// Gets the name of this animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MotionName { get; private set; }


        /// <summary>
        /// Initializes a new instance of the AnimationInfo class with the specified motion data and name.
        /// </summary>
        /// <param name="motionData">The motion data associated with this animation.</param>
        /// <param name="motionName">The name of this animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionInfo(MotionData motionData, string motionName)
        {
            if (motionData == null)
            {
                throw new ArgumentNullException(nameof(motionData));
            }

            MotionData = motionData;
            MotionName = motionName;
        }
    }
}
