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
    internal static partial class LottiePlayer
    {
        [DllImport(Libraries.LottiePlayer)]
        internal static extern IntPtr lottie_animation_from_file(string file);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern IntPtr lottie_animation_from_data(string data, string key);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern void lottie_animation_destroy(IntPtr animation);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern void lottie_animation_get_size(IntPtr animation, out int w, out int h);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern double lottie_animation_get_duration(IntPtr animation);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern int lottie_animation_get_totalframe(IntPtr animation);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern int lottie_animation_get_framerate(IntPtr animation);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern void lottie_animation_prepare_frame(IntPtr animation, int frameNo, int w, int h);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern void lottie_animation_render_async(IntPtr animation, int frameNo, IntPtr buffer, int w, int h, int bytesPerLine);

        [DllImport(Libraries.LottiePlayer)]
        internal static extern void lottie_animation_render_flush(IntPtr animation);
    }
}
