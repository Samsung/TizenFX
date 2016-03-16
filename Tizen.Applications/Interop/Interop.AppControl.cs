/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class AppControl
    {
        [DllImport(Libraries.Application, EntryPoint = "app_control_create")]
        internal static extern int Create(out SafeAppControlHandle handle);

        [DllImport(Libraries.Application, EntryPoint = "app_control_get_app_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAppId(IntPtr app_control, out IntPtr app_id);

        [DllImport(Libraries.Application, EntryPoint = "app_control_get_operation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOperation(SafeAppControlHandle handle, out string operation);

        [DllImport(Libraries.Application, EntryPoint = "app_control_get_uri", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetUri(SafeAppControlHandle handle, out string uri);

        [DllImport(Libraries.Application, EntryPoint = "app_control_get_mime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMime(SafeAppControlHandle handle, out string mime);

        [DllImport(Libraries.Application, EntryPoint = "app_control_destroy", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DangerousDestroy(IntPtr handle);

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
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                AppControl.DangerousDestroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
