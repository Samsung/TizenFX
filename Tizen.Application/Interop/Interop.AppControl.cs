/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

internal static partial class Interop
{
    internal static partial class AppControl
    {
        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_create(out SafeAppControlHandle handle);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_destroy(IntPtr handle);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_clone(out IntPtr clone, IntPtr handle);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_get_app_id(IntPtr app_control, out IntPtr app_id);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_get_operation(SafeAppControlHandle handle, out IntPtr operation);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_get_uri(SafeAppControlHandle handle, out IntPtr uri);

        [DllImport(Libraries.Application, CallingConvention = CallingConvention.Cdecl)]
        private static extern int app_control_get_mime(SafeAppControlHandle handle, out IntPtr mime);

        internal static SafeAppControlHandle CreateHandle()
        {
            SafeAppControlHandle handle;
            int err = app_control_create(out handle);
            if (err == 0)
            {
                return handle;
            }
            else
            {
                Debug.WriteLine("Failed to create app_control handle. err = {0}", err);
                return null;
            }
        }

        internal static string GetOperation(SafeAppControlHandle handle)
        {
            IntPtr value = IntPtr.Zero;
            try
            {
                int err = app_control_get_operation(handle, out value);
                if (err == 0)
                {
                    return Marshal.PtrToStringAuto(value);
                }
            }
            finally
            {
                if (value != IntPtr.Zero)
                {
                    Sys.Free(value);
                }
            }
            return null;
        }

        internal static string GetMime(SafeAppControlHandle handle)
        {
            IntPtr value = IntPtr.Zero;
            try
            {
                int err = app_control_get_mime(handle, out value);
                if (err == 0)
                {
                    return Marshal.PtrToStringAuto(value);
                }
            }
            finally
            {
                if (value != IntPtr.Zero)
                {
                    Sys.Free(value);
                }
            }
            return null;
        }

        internal static string GetScheme(SafeAppControlHandle handle)
        {
            IntPtr value = IntPtr.Zero;
            try
            {
                int err = app_control_get_uri(handle, out value);
                if (err == 0)
                {
                    return Marshal.PtrToStringAuto(value);
                }
            }
            finally
            {
                if (value != IntPtr.Zero)
                {
                    Sys.Free(value);
                }
            }
            return null;
        }

        internal sealed class SafeAppControlHandle : SafeHandle
        {
            public SafeAppControlHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeAppControlHandle(IntPtr handle) : base(handle, false)
            {
            }

            public override bool IsInvalid
            {
                get { return handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                app_control_destroy(handle);
                SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
