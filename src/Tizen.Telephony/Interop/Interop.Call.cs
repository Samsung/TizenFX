// Copyright 2016 by Samsung Electronics, Inc.
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Telephony;
using static Tizen.Telephony.CallHandle;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Call Interop Class
    /// </summary>
    internal static partial class Call
    {
        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_preferred_voice_subscription")]
        internal static extern Telephony.TelephonyError GetPreferredVoiceSubscription(IntPtr handle, out CallPreferredVoiceSubsubscription callSub);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_call_list")]
        internal static extern Telephony.TelephonyError GetCallList(IntPtr handle, out uint count, out IntPtr callList);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_release_call_list")]
        internal static extern Telephony.TelephonyError ReleaseCallList(uint count, IntPtr callList);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_handle_id")]
        internal static extern Telephony.TelephonyError GetHandleId(IntPtr callHandle, out uint handleId);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_number")]
        internal static extern Telephony.TelephonyError GetNumber(IntPtr callHandle, out string number);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_type")]
        internal static extern Telephony.TelephonyError GetType(IntPtr callHandle, out CallType type);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_status")]
        internal static extern Telephony.TelephonyError GetStatus(IntPtr callHandle, out CallStatus status);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_direction")]
        internal static extern Telephony.TelephonyError GetDirection(IntPtr callHandle, out CallDirection direction);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_conference_status")]
        internal static extern Telephony.TelephonyError GetConferenceStatus(IntPtr callHandle, out bool conferenceStatus);

        internal sealed class SafeCallList : SafeHandle
        {
            public SafeCallList()
                : base(IntPtr.Zero, true)
            {
            }

            public SafeCallList(IntPtr handle, uint count)
                : base(handle, true)
            {
                Count = count;
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                ReleaseCallList(Count, this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }

            internal uint Count;
        }
    }
}
