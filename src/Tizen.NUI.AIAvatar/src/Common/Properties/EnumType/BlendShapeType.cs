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
    /// The type of predefined blendshape. We can customize each type name by "TODO_mapper"
    /// The basic names provided by AIAvatar to control the default avatar of AREmoji.
    /// Contains the BlendShape information of AIAvatar.  
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum BlendShapeType
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
