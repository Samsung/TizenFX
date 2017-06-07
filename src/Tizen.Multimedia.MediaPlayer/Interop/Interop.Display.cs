/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Display
    {

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_mode")]
        internal static extern PlayerErrorCode SetMode(IntPtr player, PlayerDisplayMode mode);

        [DllImport(Libraries.Player, EntryPoint = "player_get_display_mode")]
        internal static extern PlayerErrorCode GetMode(IntPtr player, out int mode);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_visible")]
        internal static extern PlayerErrorCode SetVisible(IntPtr player, bool visible);

        [DllImport(Libraries.Player, EntryPoint = "player_is_display_visible")]
        internal static extern PlayerErrorCode IsVisible(IntPtr player, out bool visible);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_rotation")]
        internal static extern PlayerErrorCode SetRotation(IntPtr player, PlayerDisplayRotation rotation);

        [DllImport(Libraries.Player, EntryPoint = "player_get_display_rotation")]
        internal static extern PlayerErrorCode GetRotation(IntPtr player, out int rotation);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_roi_area")]
        internal static extern PlayerErrorCode SetRoi(IntPtr player, int x, int y, int width, int height);
    }
}
