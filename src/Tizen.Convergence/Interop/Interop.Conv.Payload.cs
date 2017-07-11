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
    internal static partial class ConvPayload
    {
        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_create")]
        internal static extern int Create(out ConvPayloadHandle /* conv_payload_h */ handle);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_destroy")]
        internal static extern int Destroy(IntPtr /* conv_payload_h */ handle);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_set_string")]
        internal static extern int SetString(ConvPayloadHandle /* conv_payload_h */ handle, string key, string value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_get_string")]
        internal static extern int GetString(ConvPayloadHandle /* conv_payload_h */ handle, string key, out IntPtr value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_set_byte")]
        internal static extern int SetByte(ConvPayloadHandle /* conv_payload_h */ handle, string key, int length, byte[] value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_get_byte")]
        internal static extern int GetByte(ConvPayloadHandle /* conv_payload_h */ handle, string key, out int length, out IntPtr value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_set_binary")]
        internal static extern int SetBinary(ConvPayloadHandle /* conv_payload_h */ handle, int length, byte[] value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_payload_get_binary")]
        internal static extern int GetBinary(ConvPayloadHandle /* conv_payload_h */ handle, out int length, out IntPtr value);
    }

    internal class ConvPayloadHandle : TizenSafeHandle
    {
        private bool _ownsHandle = true;

        public ConvPayloadHandle(): base()
        {

        }

        public ConvPayloadHandle(IntPtr handle)
            : base(handle)
        {
        }

        public ConvPayloadHandle(IntPtr handle, bool ownsHandle)
            : base(handle)
        {
            _ownsHandle = ownsHandle;
        }

        public override void Destroy()
        {
            if (_ownsHandle && handle != IntPtr.Zero)
            {
                var err = ConvPayload.Destroy(this.handle);
                if (err != (int)ConvErrorCode.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Failed to destroy conv payload handle");
                    throw ErrorFactory.GetException(err);
                }
            }
        }
    }
}
