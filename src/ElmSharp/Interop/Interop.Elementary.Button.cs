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
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_button_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_initial_timeout_set(IntPtr obj, double t);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_button_autorepeat_initial_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_gap_timeout_set(IntPtr obj, double t);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_button_autorepeat_gap_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_set(IntPtr obj, bool on);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_button_autorepeat_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_radio_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_group_add(IntPtr obj, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_state_value_set(IntPtr obj, int value);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_radio_state_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_value_set(IntPtr obj, int value);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_radio_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_radio_selected_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_check_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_check_state_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_check_state_set(IntPtr obj, bool value);
    }
}
