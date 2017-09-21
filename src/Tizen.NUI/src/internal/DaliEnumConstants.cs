/** Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tizen.NUI
{
  namespace Constants
  {
    /// <summary>
    /// Enumeration for texture types.
    /// </summary>
    public enum TextureType
    {
      Texture2D     = Tizen.NUI.TextureType.TEXTURE_2D,   ///< One 2D image
      TextureCube   = Tizen.NUI.TextureType.TEXTURE_CUBE  ///< Six 2D images arranged in a cube-shape
    }

    /// <summary>
    /// Enumeration for stereoscopic view modes.
    /// </summary>
    public enum ViewMode
    {
      Mono              = Tizen.NUI.ViewMode.MONO,                          ///< Monoscopic (single camera). This is the default.
      StereoHorizontal  = Tizen.NUI.ViewMode.STEREO_HORIZONTAL, ///< Stereoscopic. Frame buffer is split horizontally with the left and right camera views in their respective sides.
      StereoVertical    = Tizen.NUI.ViewMode.STEREO_VERTICAL,     ///< Stereoscopic. Frame buffer is split vertically with the left camera view at the top and the right camera view at the bottom.
      StereoInterlaced  = Tizen.NUI.ViewMode.STEREO_INTERLACED  ///< Stereoscopic. Left/Right camera views are rendered into the framebuffer on alternate frames.
    }

        public struct Direction
        {
            public enum Type
            {
                LeftToRight = Tizen.NUI.DirectionType.LEFT_TO_RIGHT,
                RightToLeft = Tizen.NUI.DirectionType.RIGHT_TO_LEFT
            }
        }




        public struct Tooltip
        {
            public struct Property
            {
                public static readonly int Content = NDalic.TOOLTIP_CONTENT;
                public static readonly int Layout = NDalic.TOOLTIP_LAYOUT;
                public static readonly int WaitTime = NDalic.TOOLTIP_WAIT_TIME;
                public static readonly int Background = NDalic.TOOLTIP_BACKGROUND;
                public static readonly int Tail = NDalic.TOOLTIP_TAIL;
                public static readonly int Position = NDalic.TOOLTIP_POSITION;
                public static readonly int HoverPointOffset = NDalic.TOOLTIP_HOVER_POINT_OFFSET;
                public static readonly int MovementThreshold = NDalic.TOOLTIP_MOVEMENT_THRESHOLD;
                public static readonly int DisappearOnMovement = NDalic.TOOLTIP_DISAPPEAR_ON_MOVEMENT;
            }

            public struct BackgroundProperty
            {
                public static readonly int Visual = NDalic.TOOLTIP_BACKGROUND_VISUAL;
                public static readonly int Border = NDalic.TOOLTIP_BACKGROUND_BORDER;
            }

            public struct TailProperty
            {
                public static readonly int Visibility = NDalic.TOOLTIP_TAIL_VISIBILITY;
                public static readonly int AboveVisual = NDalic.TOOLTIP_TAIL_ABOVE_VISUAL;
                public static readonly int BelowVisual = NDalic.TOOLTIP_TAIL_BELOW_VISUAL;
            }
        }
    } // namespace Constants


internal class NUILog
{
    [Conditional("DEBUG_ON")]
    public static void Debug(string msg,
        [CallerLineNumber] int lineNum = 0,
        [CallerMemberName] string caller = null,
        [CallerFilePath] string file = null
    )
    {
        Tizen.Log.Fatal("NUI", $"{msg} (at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")} line {lineNum} of {caller} in {file})" );
    }

    public static void Error(string msg,
        [CallerLineNumber] int lineNum = 0,
        [CallerMemberName] string caller = null,
        [CallerFilePath] string file = null
    )
    {
        Tizen.Log.Fatal("NUI", $"[ERROR] {msg} (at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")} line {lineNum} of {caller} in {file})" );
    }
}

} // namesapce Dali
