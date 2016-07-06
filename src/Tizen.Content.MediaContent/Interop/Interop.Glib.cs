/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Glib
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool GSourceFunc(IntPtr userData);

        [DllImport(Libraries.Glib, EntryPoint = "g_idle_add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint IdleAdd(GSourceFunc d, IntPtr data);
    }
}
