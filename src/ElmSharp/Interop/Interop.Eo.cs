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
    internal static partial class Eo
    {
        [DllImport(Libraries.Eo)]
        internal static extern IntPtr eo_class_get(IntPtr obj);

        [DllImport(Libraries.Eo, EntryPoint = "eo_class_name_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _eo_class_name_get(IntPtr klass);

        internal static string eo_class_name_get(IntPtr obj)
        {
            var name = _eo_class_name_get(obj);
            return Marshal.PtrToStringAnsi(name);
        }

    }

}