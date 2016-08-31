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
    internal static partial class MediaKey
    {
        internal enum KeyValue
        {
            Play,
            Stop,
            Pause,
            Previous,
            Next,
            FastForward,
            Rewind,
            PlayPause,
            Media,
            Unknown
        }

        internal enum KeyStatus
        {
            Pressed,
            Released,
            Unknown
        }

        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OperationFailed = -0x02420000 | 0x01
        }

        internal delegate void EventCallback(KeyValue value, KeyStatus status, IntPtr userData);

        [DllImport(Libraries.MediaKey, EntryPoint = "media_key_reserve")]
        internal static extern ErrorCode Reserve(EventCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaKey, EntryPoint = "media_key_release")]
        internal static extern ErrorCode Release();
    }
}
