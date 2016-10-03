// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        public delegate void GestureEventCallback(IntPtr data, IntPtr event_info);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gesture_layer_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gesture_layer_attach(IntPtr obj, IntPtr target);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_zoom_step_set(IntPtr obj, double step);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_zoom_step_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_tap_finger_size_set(IntPtr obj, int sz);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gesture_layer_tap_finger_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_hold_events_set(IntPtr obj, bool hold_events);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gesture_layer_hold_events_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_rotate_step_set(IntPtr obj, double step);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_rotate_step_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_cb_set(IntPtr obj, ElmSharp.GestureLayer.GestureType idx, ElmSharp.GestureLayer.GestureState cb_type, GestureEventCallback cb, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_line_min_length_set(IntPtr obj, int line_min_length);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gesture_layer_line_min_length_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_zoom_distance_tolerance_set(IntPtr obj, int zoom_distance_tolerance);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gesture_layer_zoom_distance_tolerance_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_line_distance_tolerance_set(IntPtr obj, int line_distance_tolerance);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gesture_layer_line_distance_tolerance_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_line_angular_tolerance_set(IntPtr obj, double line_angular_tolerance);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_line_angular_tolerance_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_zoom_wheel_factor_set(IntPtr obj, double zoom_wheel_factor);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_zoom_wheel_factor_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_zoom_finger_factor_set (IntPtr obj, double zoom_finger_factor);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_zoom_finger_factor_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_rotate_angular_tolerance_set (IntPtr obj, double rotate_angular_tolerance);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_rotate_angular_tolerance_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_flick_time_limit_ms_set (IntPtr obj, UInt32 flick_time_limit_ms);

        [DllImport(Libraries.Elementary)]
        internal static extern UInt32 elm_gesture_layer_flick_time_limit_ms_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_long_tap_start_timeout_set(IntPtr obj, double long_tap_start_timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_long_tap_start_timeout_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_continues_enable_set(IntPtr obj, bool continues_enable);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gesture_layer_continues_enable_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gesture_layer_double_tap_timeout_set (IntPtr obj, double double_tap_timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_gesture_layer_double_tap_timeout_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_config_glayer_long_tap_start_timeout_get ();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_glayer_long_tap_start_timeout_set(double long_tap_timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_config_glayer_double_tap_timeout_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_glayer_double_tap_timeout_set(double double_tap_timeout);
    }
}

