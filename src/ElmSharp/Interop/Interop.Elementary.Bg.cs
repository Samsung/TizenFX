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

internal static partial class Interop
{
    internal static partial class Elementary
    {
        public enum BackgroundOptions
        {
            Center, Scale, Stretch, Tile
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_bg_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_color_set(IntPtr obj, int r, int g, int b);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_color_get(IntPtr obj, out int r, out int g, out int b);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_bg_file_set(IntPtr obj, string file, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_file_get(IntPtr obj, out IntPtr file, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_option_set(IntPtr obj, BackgroundOptions option);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_load_size_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern BackgroundOptions elm_bg_option_get(IntPtr obj);

        internal static string BackgroundFileGet(IntPtr obj)
        {
            elm_bg_file_get(obj, out IntPtr file, IntPtr.Zero);
            return Marshal.PtrToStringAnsi(file);
        }
    }
}