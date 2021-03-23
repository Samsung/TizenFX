/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tizen.NUI
{
    namespace Constants
    {
        /// <summary>
        /// Enumeration for texture types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum TextureType
        {
            /// <summary>
            /// One 2D image
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Texture2D = Tizen.NUI.TextureType.TEXTURE_2D,
            /// <summary>
            /// Six 2D images arranged in a cube-shape
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TextureCube = Tizen.NUI.TextureType.TEXTURE_CUBE
        }

        /// <summary>
        /// Enumeration for the direction
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct Direction
        {
            /// <summary>
            /// Enumeration for the Direction types.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public enum Type
            {
                /// <summary>
                /// from Left to Right
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                LeftToRight = Tizen.NUI.DirectionType.LEFT_TO_RIGHT,
                /// <summary>
                /// from Right to Left
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                RightToLeft = Tizen.NUI.DirectionType.RIGHT_TO_LEFT
            }
        }

        /// <summary>
        /// Tooltip
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct Tooltip
        {
            /// <summary>
            /// The properties used for a Tooltip.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
            public struct Property
            {
                /// <summary>
                /// The content to display.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Content = NDalic.TooltipContent;
                /// <summary>
                /// The layout of the content.
                /// </summary>\
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Layout = NDalic.TooltipLayout;
                /// <summary>
                /// Time to wait in seconds before a tooltip is shown while the is movement is within the allowed threshold.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int WaitTime = NDalic.TooltipWaitTime;
                /// <summary>
                /// The background of the tooltip.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Background = NDalic.TooltipBackground;
                /// <summary>
                /// The tail used by the tooltip.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Tail = NDalic.TooltipTail;
                /// <summary>
                /// The position of the tooltip in relation to the control.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Position = NDalic.TooltipPosition;
                /// <summary>
                /// If Tooltip::Position::HOVER_POINT is used for the POSITION, then this is the offset the tooltip is displayed at from the hover point.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int HoverPointOffset = NDalic.TooltipHoverPointOffset;
                /// <summary>
                /// The movement threshold allowed before showing (or hiding a popup).
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int MovementThreshold = NDalic.TooltipMovementThreshold;
                /// <summary>
                /// If true, the tooltip will disappear after hover movement beyond a certain distance.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int DisappearOnMovement = NDalic.TooltipDisappearOnMovement;
            }

            /// <summary>
            /// Background Property
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public struct BackgroundProperty
            {
                /// <summary>
                /// The image to use as the background.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Visual = NDalic.TooltipBackgroundVisual;
                /// <summary>
                /// The size of the borders in the order: left, right, bottom, top.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Border = NDalic.TooltipBackgroundBorder;
            }

            /// <summary>
            /// The properties of the tail used by the tooltip.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public struct TailProperty
            {
                /// <summary>
                /// Whether to show the tail or not.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int Visibility = NDalic.TooltipTailVisibility;
                /// <summary>
                /// The image used for the tail if it is above the tooltip.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int AboveVisual = NDalic.TooltipTailAboveVisual;
                /// <summary>
                /// The image used for the tail if it is below the tooltip.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                public static readonly int BelowVisual = NDalic.TooltipTailBelowVisual;
            }
        }

        /// <summary>
        /// Enumeration for stereoscopic view modes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Not used.
        /// </remarks>
        [Obsolete("Please do not use this ViewMode(Deprecated).")]
        public enum ViewMode
        {
            /// <summary>
            /// Monoscopic (single camera). This is the default.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <remarks>
            /// Deprecated.(API Level 6) Not used.
            /// </remarks>
            [Obsolete("Please do not use this ViewMode.Mono(Deprecated).")]
            Mono,
            /// <summary>
            /// Stereoscopic. Frame buffer is split horizontally with the left and right camera views in their respective sides.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <remarks>
            /// Deprecated.(API Level 6) Not used.
            /// </remarks>
            [Obsolete("Please do not use this ViewMode.StereoHorizontal(Deprecated).")]
            StereoHorizontal,
            /// <summary>
            /// Stereoscopic. Frame buffer is split vertically with the left camera view at the top and the right camera view at the bottom.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <remarks>
            /// Deprecated.(API Level 6) Not used.
            /// </remarks>
            [Obsolete("Please do not use this ViewMode.StereoVertical(Deprecated).")]
            StereoVertical,
            /// <summary>
            /// Stereoscopic. Left/Right camera views are rendered into the framebuffer on alternate frames.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// <remarks>
            /// Deprecated.(API Level 6) Not used.
            /// </remarks>
            [Obsolete("Please do not use this ViewMode.StereoInterlaced(Deprecated).")]
            StereoInterlaced
        }

    } // namespace Constants


    internal class NUILog
    {
        [Conditional("NUI_DEBUG_ON")]
        public static void Debug(string msg,
            [CallerLineNumber] int lineNum = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string file = null
        )
        {
            Tizen.Log.Debug("NUI", $"{msg} (at line {lineNum} of {caller} in {file})\n");
        }

        public static void Error(string msg,
            [CallerLineNumber] int lineNum = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string file = null
        )
        {
            Tizen.Log.Error("NUI", $"{msg} (at line {lineNum} of {caller} in {file})\n");
        }
    }

#if !(NUI_DEBUG_ON)
    internal class tlog
    {
        internal static void Fatal(string tag, string msg) { _ = tag; _ = msg; }
        internal static void Error(string tag, string msg) { _ = tag; _ = msg; }
    }
#endif

}
