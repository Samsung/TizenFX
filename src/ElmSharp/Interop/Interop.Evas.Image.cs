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
        internal static extern void evas_object_image_file_set(IntPtr obj, string file, string key);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_set(IntPtr obj, int l, int r, int t, int b);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_image_border_center_fill_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_border_center_fill_set(IntPtr obj, int filled);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_alpha_set(IntPtr obj, bool has_alpha);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_alpha_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern LoadError evas_object_image_load_error_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, IntPtr x, out int y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int x, IntPtr y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int x, out int y);
    }
}