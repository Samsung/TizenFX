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
        internal static extern IntPtr elm_win_add(IntPtr parent, string name, int type);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_util_standard_add(string name, string title);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_activate(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_title_set(IntPtr obj, string title);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_title_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_win_title_get(IntPtr obj);

        internal static string elm_win_title_get(IntPtr obj)
        {
            var text = _elm_win_title_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_screen_size_get(IntPtr obj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_resize_object_del(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_resize_object_add(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_autodel_set(IntPtr obj, bool autodel);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_autodel_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_indicator_opacity_set(IntPtr obj, int opacity);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_indicator_opacity_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_indicator_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_indicator_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_conformant_set(IntPtr obj, bool conformant);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_fullscreen_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_fullscreen_set(IntPtr obj, bool fullscreen);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_rotation_set(IntPtr obj, int rotation);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_rotation_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_wm_rotation_supported_get(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_wm_rotation_available_rotations_set")]
        internal static extern void _elm_win_wm_rotation_available_rotations_set(IntPtr obj, IntPtr rotations, uint count);

        internal static void elm_win_wm_rotation_available_rotations_set(IntPtr obj, int[] rotations)
        {
            IntPtr pRotations = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * rotations.Length);
            Marshal.Copy(rotations, 0, pRotations, rotations.Length);
            _elm_win_wm_rotation_available_rotations_set(obj, pRotations, (uint)rotations.Length);
            Marshal.FreeHGlobal(pRotations);
        }

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_wm_rotation_available_rotations_get")]
        internal static extern bool _elm_win_wm_rotation_available_rotations_get(IntPtr obj, out IntPtr rotations, out int count);

        internal static bool elm_win_wm_rotation_available_rotations_get(IntPtr obj, out int[] rotations)
        {
            IntPtr rotationArrPtr;
            int count;
            if (_elm_win_wm_rotation_available_rotations_get(obj, out rotationArrPtr, out count))
            {
                rotations = new int[count];
                Marshal.Copy(rotationArrPtr, rotations, 0, count);
                Libc.Free(rotationArrPtr);
                return true;
            }
            rotations = null;
            return false;
        }
    }
}
