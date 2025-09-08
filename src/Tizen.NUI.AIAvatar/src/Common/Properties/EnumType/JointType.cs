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

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The type of predefined skeleton joint. We can customize each type name by "TODO_mapper"
    /// The basic names provided by AIAvatar to control the default avatar of AREmoji.
    /// Contains the joint information of AIAvatar.  
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum JointType
    {
        #region Head
        /// <summary>
        /// Head joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Head = 0,

        /// <summary>
        /// Neck joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Neck,

        /// <summary>
        /// EyeLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeLeft,

        /// <summary>
        /// EyeRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeRight,
        #endregion

        #region Left Upper Body
        /// <summary>
        /// ShoulderLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ShoulderLeft,

        /// <summary>
        /// ElbowLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ElbowLeft,

        /// <summary>
        /// WristLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        WristLeft,
        #endregion

        #region Right Upper Body
        /// <summary>
        /// ShoulderRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ShoulderRight,

        /// <summary>
        /// ElbowRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ElbowRight,

        /// <summary>
        /// WristRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        WristRight,
        #endregion

        #region Left Lower Body
        /// <summary>
        /// HipLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HipLeft,

        /// <summary>
        /// KneeLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        KneeLeft,

        /// <summary>
        /// AnkleLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AnkleLeft,

        /// <summary>
        /// ForeFootLeft joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ForeFootLeft,
        #endregion

        #region Right Lower Body
        /// <summary>
        /// HipRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HipRight,

        /// <summary>
        /// KneeRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        KneeRight,

        /// <summary>
        /// AnkleRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AnkleRight,

        /// <summary>
        /// ForeFootRight joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ForeFootRight,
        #endregion

        #region Left Hand Finger
        /// <summary>
        /// FingerThumb1Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb1Left,

        /// <summary>
        /// FingerThumb2Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb2Left,

        /// <summary>
        /// FingerThumb3Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb3Left,

        /// <summary>
        /// FingerThumb4Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb4Left,

        /// <summary>
        /// FingerIndex1Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex1Left,

        /// <summary>
        /// FingerIndex2Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex2Left,

        /// <summary>
        /// FingerIndex3Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex3Left,

        /// <summary>
        /// FingerIndex4Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex4Left,

        /// <summary>
        /// FingerMiddle1Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle1Left,

        /// <summary>
        /// FingerMiddle2Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle2Left,

        /// <summary>
        /// FingerMiddle3Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle3Left,

        /// <summary>
        /// FingerMiddle4Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle4Left,

        /// <summary>
        /// FingerRing1Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing1Left,

        /// <summary>
        /// FingerRing2Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing2Left,

        /// <summary>
        /// FingerRing3Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing3Left,

        /// <summary>
        /// FingerRing4Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing4Left,

        /// <summary>
        /// FingerPinky1Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky1Left,

        /// <summary>
        /// FingerPinky2Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky2Left,

        /// <summary>
        /// FingerPinky3Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky3Left,

        /// <summary>
        /// FingerPinky4Left joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky4Left,
        #endregion

        #region Right Hand Finger
        /// <summary>
        /// FingerThumb1Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb1Right,

        /// <summary>
        /// FingerThumb2Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb2Right,

        /// <summary>
        /// FingerThumb3Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb3Right,

        /// <summary>
        /// FingerThumb4Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerThumb4Right,

        /// <summary>
        /// FingerIndex1Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex1Right,

        /// <summary>
        /// FingerIndex2Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex2Right,

        /// <summary>
        /// FingerIndex3Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex3Right,

        /// <summary>
        /// FingerIndex4Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerIndex4Right,

        /// <summary>
        /// FingerMiddle1Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle1Right,

        /// <summary>
        /// FingerMiddle2Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle2Right,

        /// <summary>
        /// FingerMiddle3Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle3Right,

        /// <summary>
        /// FingerMiddle4Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerMiddle4Right,

        /// <summary>
        /// FingerRing1Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing1Right,

        /// <summary>
        /// FingerRing2Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing2Right,

        /// <summary>
        /// FingerRing3Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing3Right,

        /// <summary>
        /// FingerRing4Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerRing4Right,

        /// <summary>
        /// FingerPinky1Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky1Right,

        /// <summary>
        /// FingerPinky2Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky2Right,

        /// <summary>
        /// FingerPinky3Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky3Right,

        /// <summary>
        /// FingerPinky4Right joint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FingerPinky4Right,
        #endregion

        /// <summary>
        /// Max value of default joint. It will be used when we determine the motion index is default or custom.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DefaultJointMax,
    }

}
