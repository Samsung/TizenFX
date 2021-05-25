/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Telephony;
using static Tizen.Telephony.CallHandle;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The Call Interop class.
    /// </summary>
    internal static partial class Call
    {
        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_preferred_voice_subscription")]
        internal static extern Telephony.TelephonyError GetPreferredVoiceSubscription(IntPtr handle, out CallPreferredVoiceSubscription callSub);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_get_call_list")]
        internal static extern Telephony.TelephonyError GetCallList(IntPtr handle, out uint count, out IntPtr callList);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_call_release_call_list")]
        internal static extern Telephony.TelephonyError ReleaseCallList(uint count, ref IntPtr callList);

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
                ReleaseCallList(Count, ref this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }

            internal uint Count;
        }
    }
}
