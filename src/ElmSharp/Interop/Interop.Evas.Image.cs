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
    internal static partial class Evas
    {

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_image_add(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_image_filled_add(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal unsafe static extern void evas_object_image_memfile_set(IntPtr obj, byte* img, long size, IntPtr format, IntPtr key);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_file_set(IntPtr obj, string file, string key);

        [DllImport(Libraries.Evas, EntryPoint = "evas_object_image_file_get")]
        internal static extern void _evas_object_image_file_get(IntPtr obj, out IntPtr file, out IntPtr key);

        internal static void evas_object_image_file_get(IntPtr obj, out string file, out string key)
        {
            IntPtr outFile, outKey;
            _evas_object_image_file_get(obj, out outFile, out outKey);
            file = Marshal.PtrToStringAnsi(outFile);
            key = Marshal.PtrToStringAnsi(outKey);
        }

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_set(IntPtr obj, int l, int r, int t, int b);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_get(IntPtr obj, out int l, out int r, out int t, out int b);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_image_border_center_fill_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_center_fill_set(IntPtr obj, int filled);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_filled_set(IntPtr obj, bool setting);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_filled_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_scale_set(IntPtr obj, double scale);

        [DllImport(Libraries.Evas)]
        internal static extern double evas_object_image_border_scale_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, IntPtr w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_image_stride_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_alpha_set(IntPtr obj, bool has_alpha);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_alpha_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_colorspace_set(IntPtr obj, Colorspace colorSpace);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_data_copy_set(IntPtr obj, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_image_data_get(IntPtr obj, bool forWriting);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_data_set(IntPtr obj, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_data_update_add(IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_fill_set(IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_pixels_dirty_set(IntPtr obj, bool dirty);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_save(IntPtr obj, string file, string key, string flags);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_scale_hint_set(IntPtr obj, ImageScaleHint hint);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_smooth_scale_set(IntPtr obj, bool smoothScale);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_smooth_scale_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_source_set(IntPtr obj, IntPtr src);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_source_visible_set(IntPtr obj, bool visible);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_source_visible_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_source_clip_set(IntPtr obj, bool source_clip);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_source_clip_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern LoadError evas_object_image_load_error_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_native_surface_set(IntPtr obj, IntPtr surface);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_load_scale_down_set(IntPtr obj, int scale);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_image_load_scale_down_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_reload(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_load_size_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_load_size_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_load_dpi_set(IntPtr obj, double dpi);

        [DllImport(Libraries.Evas)]
        internal static extern double evas_object_image_load_dpi_get(IntPtr obj);
    }
}