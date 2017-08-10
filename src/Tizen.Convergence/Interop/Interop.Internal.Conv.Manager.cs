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
        public enum ConvDiscoveryResult
        {
            /// <summary>
            /// Discovery Error
            /// </summary>
            Error = -1,
            /// <summary>
            /// Discovery Success
            /// </summary>
            Success = 0,
            /// <summary>
            /// Discovery finished
            /// </summary>
            Finished,
            /// <summary>
            /// Discovery lost
            /// </summary>
            Lost,
        }

        internal static partial class ConvManager
        {
            [DllImport(Libraries.Convergence, EntryPoint = "conv_create")]
            internal static extern int ConvCreate(out ConvManagerHandle /* conv_h */ handle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_destroy")]
            internal static extern int ConvDestroy(IntPtr /* conv_h */ handle);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_discovery_start")]
            internal static extern int ConvDiscoveryStart(ConvManagerHandle /* conv_h */ handle, int timeoutSeconds, ConvDiscoveryCallback callback, IntPtr /* void */ userData);

            [DllImport(Libraries.Convergence, EntryPoint = "conv_discovery_stop")]
            internal static extern int ConvDiscoveryStop(ConvManagerHandle /* conv_h */ handle);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void ConvDiscoveryCallback(IntPtr /* conv_device_h */ deviceHandle, ConvDiscoveryResult /* conv_discovery_result_e */ result, IntPtr /* void */ userData);
        }

        internal class ConvManagerHandle : TizenSafeHandle
        {
            public ConvManagerHandle() : base()
            {

            }

            public ConvManagerHandle(IntPtr handle)
                : base(handle)
            {
            }

            public override void Destroy()
            {
                var err = ConvManager.ConvDestroy(this.handle);
                if (err != (int)ConvErrorCode.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Failed to destroy conv manager handle");
                    throw ErrorFactory.GetException(err);
                }
            }
        }
    }
}