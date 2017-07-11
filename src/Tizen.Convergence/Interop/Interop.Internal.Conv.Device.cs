// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Convergence;

internal static partial class Interop
{
    internal static partial class Internal
    {
        internal static partial class ConvDevice
        {
            [DllImport(Libraries.Convergence, EntryPoint = "conv_device_clone")]
            internal static extern int Clone(IntPtr /* conv_device_h */ originalHandle, out ConvDeviceHandle /* conv_device_h */ targetHandle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_device_destroy")]
            internal static extern int Destroy(IntPtr /* conv_device_h */ handle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_device_get_property_string")]
            internal static extern int GetPropertyString(ConvDeviceHandle /* conv_device_h */ handle, string key, out IntPtr value);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_device_foreach_service")]
            internal static extern int ForeachService(ConvDeviceHandle /* conv_device_h */ handle, ConvServiceForeachCallback cb, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void ConvServiceForeachCallback(IntPtr serviceHandle, IntPtr /* void */ userData);
        }

        internal class ConvDeviceHandle : TizenSafeHandle
        {
            public ConvDeviceHandle() : base()
            {

            }

            public ConvDeviceHandle(IntPtr handle)
                : base(handle)
            {
            }

            public override void Destroy()
            {
                if (handle != IntPtr.Zero)
                {
                    var err = ConvDevice.Destroy(this.handle);
                    if (err != (int)ConvErrorCode.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to destroy conv device handle");
                        throw ErrorFactory.GetException(err);
                    }
                }
            }
        }
    }
}
