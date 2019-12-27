using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(CoreUI.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_add(IntPtr obj, IntPtr surface);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_disabled_set(IntPtr obj, bool disabled);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern bool eext_circle_object_disabled_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_line_width_set(IntPtr obj, int lineWidth);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern int eext_circle_object_line_width_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_angle_set(IntPtr obj, double angle);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_angle_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_angle_offset_set(IntPtr obj, double offset);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_angle_offset_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_angle_min_max_set(IntPtr obj, double min, double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_angle_min_max_get(IntPtr obj, out double min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_value_min_max_set(IntPtr obj, double min, double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_value_min_max_get(IntPtr obj, out double min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_value_set(IntPtr obj, double value);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_value_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_color_get(IntPtr obj, out int r, out int g, out int b, out int a);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_radius_set(IntPtr obj, double radius);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_radius_get(IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_line_width_set(IntPtr obj, string item, int lineWidth);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern int eext_circle_object_item_line_width_get(IntPtr obj, string item);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_set(IntPtr obj, string item, double angle);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_item_angle_get(IntPtr obj, string item);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_offset_set(IntPtr obj, string item, double offset);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_item_angle_offset_get(IntPtr obj, string item);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_set(IntPtr obj, string item, double min, double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, out double min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, out double min, IntPtr max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_angle_min_max_get(IntPtr obj, string item, IntPtr min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_set(IntPtr obj, string item, double min, double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, out double min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, out double min, IntPtr max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_min_max_get(IntPtr obj, string item, IntPtr min, out double max);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_value_set(IntPtr obj, string item, double value);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_item_value_get(IntPtr obj, string item);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_color_set(IntPtr obj, string item, int r, int g, int b, int a);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_color_get(IntPtr obj, string item, out int r, out int g, out int b, out int a);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_item_radius_set(IntPtr obj, string item, double radius);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern double eext_circle_object_item_radius_get(IntPtr obj, string item);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_connect(IntPtr surface, IntPtr obj);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern void eext_circle_object_disconnect(IntPtr surface, IntPtr obj);
    }
}