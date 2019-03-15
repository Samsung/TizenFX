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
        internal static extern double elm_animation_view_progress_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_progress_set(IntPtr obj, double progress);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_animation_view_frame_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_frame_set(IntPtr obj, int frame_num);

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

        [DllImport(Libraries.Elementary, EntryPoint = "elm_animation_view_default_size_get")]
        internal static extern Eina.Size2D _elm_animation_view_default_size_get(IntPtr obj);

        internal static void elm_animation_view_default_size_get(IntPtr obj, out int w, out int h)
        {
            var info = _elm_animation_view_default_size_get(obj);
            w = info.w;
            h = info.h;
        }

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_animation_view_state_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_is_playing_back(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_animation_view_frame_count_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_animation_view_min_progress_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_min_progress_set(IntPtr obj, double min_progress);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_animation_view_max_progress_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_max_progress_set(IntPtr obj, double max_progress);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_animation_view_min_frame_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_min_frame_set(IntPtr obj, int min_frame);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_animation_view_max_frame_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_animation_view_max_frame_set(IntPtr obj, int max_frame);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_animation_view_file_set(IntPtr obj, string file, string key);
    }
}
