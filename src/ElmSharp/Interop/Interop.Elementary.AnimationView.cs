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
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_animation_view_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_auto_play_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_auto_play_set(IntPtr obj, bool auto_play);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_auto_repeat_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_auto_repeat_set(IntPtr obj, bool auto_repeat);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_animation_view_speed_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_speed_set(IntPtr obj, double speed);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_animation_view_duration_time_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_animation_view_keyframe_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_keyframe_set(IntPtr obj, double keyframe);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_play(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_play_back(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_pause(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_resume(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_stop(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_file_set(IntPtr obj, string file, string key);
    }
}