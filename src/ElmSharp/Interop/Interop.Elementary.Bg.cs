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
        public enum BackgroundOptions
        {
            Center, Scale, Stretch, Tile
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_bg_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_color_set(IntPtr obj, int r, int g, int b);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_color_get(IntPtr obj, out int r, out int g, out int b);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_bg_file_set(IntPtr obj, string file, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_file_get(IntPtr obj, ref IntPtr file, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_bg_option_set(IntPtr obj, BackgroundOptions option);

        [DllImport(Libraries.Elementary)]
        internal static extern BackgroundOptions elm_bg_option_get(IntPtr obj);

        internal static string BackgroundFileGet(IntPtr obj)
        {
            IntPtr file = IntPtr.Zero;
            elm_bg_file_get(obj, ref file, IntPtr.Zero);
            string r = Marshal.PtrToStringAnsi(file);
            Marshal.FreeHGlobal(file);
            return r;
        }
    }
}
