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
    internal static partial class ConvChannel
    {
        [DllImport(Libraries.Convergence, EntryPoint = "conv_channel_create")]
        internal static extern int Create(out ConvChannelHandle /* conv_channel_h */ handle);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_channel_destroy")]
        internal static extern int Destroy(IntPtr /* conv_channel_h */ handle);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_channel_get_string")]
        internal static extern int GetString(ConvChannelHandle /* conv_channel_h */ handle, string key, out IntPtr value);

        [DllImport(Libraries.Convergence, EntryPoint = "conv_channel_set_string")]
        internal static extern int SetString(ConvChannelHandle /* conv_channel_h */ handle, string key, string value);
    }

    internal class ConvChannelHandle : TizenSafeHandle
    {
        private bool _ownsHandle = true;

        public ConvChannelHandle(): base()
        {

        }

        public ConvChannelHandle(IntPtr handle)
            : base(handle)
        {
        }

        public ConvChannelHandle(IntPtr handle, bool ownsHandle)
            : base(handle)
        {
            _ownsHandle = ownsHandle;
        }

        public override void Destroy()
        {
            if (_ownsHandle && handle != IntPtr.Zero)
            {
                var err = ConvChannel.Destroy(this.handle);
                if (err != (int)ConvErrorCode.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Failed to destroy conv channel handle");
                    throw ErrorFactory.GetException(err);
                }
            }
        }
    }
}
