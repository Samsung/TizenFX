/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static class TcoreVideoShell
        {
            private const string Library = "libtizen-core-wl.so.0";

            [DllImport(Library, EntryPoint = "tizen_core_wl_video_shell_surface_create")]
            internal static extern int Create(IntPtr window, out IntPtr surface);
            [DllImport(Library, EntryPoint = "tizen_core_wl_video_shell_surface_destroy")]
            internal static extern int Destroy(IntPtr surface);
            [DllImport(Library, EntryPoint = "tizen_core_wl_video_shell_surface_place_below")]
            internal static extern int PlaceBelow(IntPtr surface, IntPtr sibling);
            [DllImport(Library, EntryPoint = "tizen_core_wl_video_shell_surface_map")]
            internal static extern int Map(IntPtr surface);
            [DllImport(Library, EntryPoint = "tizen_core_wl_video_shell_surface_get_handle")]
            internal static extern int GetHandle(IntPtr surface, out IntPtr handle);
        }
    }
}
