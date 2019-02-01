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
    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_add(IntPtr obj, IntPtr surface);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_disabled_set(IntPtr obj, bool disabled);

        [DllImport(efl.Libs.Eext)]
        internal static extern bool eext_circle_object_disabled_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_line_width_set(IntPtr obj, int lineWidth);

        [DllImport(efl.Libs.Eext)]
        internal static extern int eext_circle_object_line_width_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_angle_set(IntPtr obj, double angle);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_angle_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_angle_offset_set(IntPtr obj, double offset);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_angle_offset_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_angle_min_max_set(IntPtr obj, double min, double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_angle_min_max_get(IntPtr obj, out double min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_value_min_max_set(IntPtr obj, double min, double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_value_min_max_get(IntPtr obj, out double min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_value_set(IntPtr obj, double value);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_value_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_color_get(IntPtr obj, out int r, out int g, out int b, out int a);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_radius_set(IntPtr obj, double radius);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_radius_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_line_width_set(IntPtr obj, string item, int lineWidth);

        [DllImport(efl.Libs.Eext)]
        internal static extern int eext_circle_object_item_line_width_get(IntPtr obj, string item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_set(IntPtr obj, string item, double angle);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_item_angle_get(IntPtr obj, string item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_offset_set(IntPtr obj, string item, double offset);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_item_angle_offset_get(IntPtr obj, string item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_set(IntPtr obj, string item, double min, double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, out double min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, out double min, IntPtr max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, IntPtr min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_set(IntPtr obj, string item, double min, double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, out double min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, out double min, IntPtr max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, IntPtr min, out double max);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_set(IntPtr obj, string item, double value);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_item_value_get(IntPtr obj, string item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_color_set(IntPtr obj, string item, int r, int g, int b, int a);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_color_get(IntPtr obj, string item, out int r, out int g, out int b, out int a);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_item_radius_set(IntPtr obj, string item, double radius);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_item_radius_get(IntPtr obj, string item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_connect(IntPtr surface, IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_disconnect(IntPtr surface, IntPtr obj);
    }
}