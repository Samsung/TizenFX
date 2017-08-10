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
        internal enum ServiceType
        {
            /// <summary>
            /// Undefined service
            /// </summary>
            None = -1,

            /// <summary>
            /// App-to-app communication service
            /// </summary>
            AppCommunication = 0,

            /// <summary>
            /// Remote app-control service
            /// </summary>
            RemoteAppControl,
        }

        internal static partial class ConvService
        {
            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_create")]
            internal static extern int Create(out ConvServiceHandle /* conv_service_h */ handle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_clone")]
            internal static extern int Clone(IntPtr /* conv_service_h */ originalHandle, out ConvServiceHandle /* conv_service_h */ targetHandle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_destroy")]
            internal static extern int Destroy(IntPtr /* conv_service_h */ handle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_get_property_string")]
            internal static extern int GetPropertyString(ConvServiceHandle /* conv_service_h */ handle, string key, out IntPtr value);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_set_property_string")]
            internal static extern int SetPropertyString(ConvServiceHandle /* conv_service_h */ handle, string key, string value);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_get_type")]
            internal static extern int GetType(IntPtr /* conv_service_h */ handle, out int /* conv_service_e */ value);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_set_type")]
            internal static extern int SetType(ConvServiceHandle /* conv_service_h */ handle, int /* conv_service_e */ value);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_start")]
            internal static extern int Start(ConvServiceHandle /* conv_service_h */ handle, ConvChannelHandle channel, ConvPayloadHandle payload);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_read")]
            internal static extern int Read(ConvServiceHandle /* conv_service_h */ handle, ConvChannelHandle channel, ConvPayloadHandle payload);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_publish")]
            internal static extern int Publish(ConvServiceHandle /* conv_service_h */ handle, ConvChannelHandle channel, ConvPayloadHandle payload);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_stop")]
            internal static extern int Stop(ConvServiceHandle /* conv_service_h */ handle, ConvChannelHandle channel, ConvPayloadHandle payload);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_set_listener_cb")]
            internal static extern int SetListenerCb(ConvServiceHandle /* conv_service_h */ handle, ConvServiceListenerCallback callback, IntPtr /* void */ userData);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_service_unset_listener_cb")]
            internal static extern int UnsetListenerCb(ConvServiceHandle /* conv_service_h */ handle);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void ConvServiceListenerCallback(IntPtr /* conv_service_h */ serviceHandle, IntPtr channelHandle, int error, IntPtr result, IntPtr /* void */ userData);
        }

        internal class ConvServiceHandle : TizenSafeHandle
        {
            public ConvServiceHandle(): base()
            {

            }

            public ConvServiceHandle(IntPtr handle)
                : base(handle)
            {
            }

            public override void Destroy()
            {
                if (handle != IntPtr.Zero)
                {
                    var err = ConvService.Destroy(this.handle);
                    if (err != (int)ConvErrorCode.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to destroy conv service handle");
                        throw ErrorFactory.GetException(err);
                    }
                }
            }
        }
    }
}