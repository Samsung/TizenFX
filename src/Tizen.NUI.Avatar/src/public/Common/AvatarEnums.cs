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

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Avatar
{
    /// <summary>
    /// The type of predefined skeletal joint. We can customize each type name by "TODO_mapper"
    /// TODO : Explain me
    /// TODO : Need to check each joint exist in AR Emoji
    /// Note : This is temperal name of joints.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum JointType
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

    /// <summary>
    /// The type of predefined blendshape. We can customize each type name by "TODO_mapper"
    /// TODO : Explain me
    /// TODO : Need to check each joint exist in AR Emoji
    /// Note : This is temperal name of joints.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BlendShapeType
    {
    #region Left Eyes
        /// <summary>
        /// EyeBlinkLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeBlinkLeft = 0,

        /// <summary>
        /// EyeSquintLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeSquintLeft,

        /// <summary>
        /// EyeDownLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeDownLeft,

        /// <summary>
        /// EyeInLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeInLeft,

        /// <summary>
        /// EyeOpenLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeOpenLeft,

        /// <summary>
        /// EyeOutLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeOutLeft,

        /// <summary>
        /// EyeUpLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeUpLeft,
    #endregion

    #region Right Eyes
        /// <summary>
        /// EyeBlinkRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeBlinkRight,

        /// <summary>
        /// EyeSquintRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeSquintRight,

        /// <summary>
        /// EyeDownRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeDownRight,

        /// <summary>
        /// EyeInRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeInRight,

        /// <summary>
        /// EyeOpenRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeOpenRight,

        /// <summary>
        /// EyeOutRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeOutRight,

        /// <summary>
        /// EyeUpRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyeUpRight,
    #endregion

    #region Mouth and Jaw
        /// <summary>
        /// JawForward blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        JawForward,

        /// <summary>
        /// JawOpen blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        JawOpen,

        /// <summary>
        /// JawChew blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        JawChew,

        /// <summary>
        /// JawLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        JawLeft,

        /// <summary>
        /// JawRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        JawRight,

        /// <summary>
        /// MouthLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthLeft,

        /// <summary>
        /// MouthFrownLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthFrownLeft,

        /// <summary>
        /// MouthSmileLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthSmileLeft,

        /// <summary>
        /// MouthDimpleLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthDimpleLeft,

        /// <summary>
        /// MouthRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthRight,

        /// <summary>
        /// MouthFrownRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthFrownRight,

        /// <summary>
        /// MouthSmileRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthSmileRight,

        /// <summary>
        /// MouthDimpleRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthDimpleRight,
    #endregion

    #region Lips
        /// <summary>
        /// LipsStretchLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsStretchLeft,

        /// <summary>
        /// LipsStretchRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsStretchRight,

        /// <summary>
        /// LipsUpperClose blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsUpperClose,

        /// <summary>
        /// LipsLowerClose blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsLowerClose,

        /// <summary>
        /// LipsUpperUp blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsUpperUp,

        /// <summary>
        /// LipsLowerDown blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsLowerDown,

        /// <summary>
        /// LipsUpperOpen blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsUpperOpen,

        /// <summary>
        /// LipsLowerOpen blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsLowerOpen,

        /// <summary>
        /// LipsFunnel blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsFunnel,

        /// <summary>
        /// LipsPucker blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LipsPucker,
    #endregion

    #region Eyebrows, Cheeks, and Chin
        /// <summary>
        /// BrowDownLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BrowDownLeft,

        /// <summary>
        /// BrowDownRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BrowDownRight,

        /// <summary>
        /// BrowUpCenter blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BrowUpCenter,

        /// <summary>
        /// BrowUpLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BrowUpLeft,

        /// <summary>
        /// BrowUpRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BrowUpRight,

        /// <summary>
        /// CheekSquintLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CheekSquintLeft,

        /// <summary>
        /// CheekSquintRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CheekSquintRight,

        /// <summary>
        /// ChinLowerRaise blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ChinLowerRaise,

        /// <summary>
        /// ChinUpperRaise blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ChinUpperRaise,
    #endregion

    #region Tongue
        /// <summary>
        /// TongueOut blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TongueOut,

        /// <summary>
        /// TongueUp blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TongueUp,

        /// <summary>
        /// TongueDown blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TongueDown,

        /// <summary>
        /// TongueLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TongueLeft,

        /// <summary>
        /// TongueRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TongueRight,
    #endregion

    #region ETC
        /// <summary>
        /// Sneer blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Sneer,

        /// <summary>
        /// Puff blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Puff,

        /// <summary>
        /// PuffLeft blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PuffLeft,

        /// <summary>
        /// PuffRight blendshape
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PuffRight,
    #endregion
        /// <summary>
        /// Max value of default blendshape. It will be used when we determine the motion index is default or custom.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DefaultBlendShapeMax,
    }
}
