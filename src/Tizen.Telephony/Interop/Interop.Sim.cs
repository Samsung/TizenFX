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

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The SIM Interop class.
    /// </summary>
    internal static partial class Sim
  {
    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_icc_id")]
    internal static extern Telephony.TelephonyError GetIccId(IntPtr handle, out string iccId); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_operator")]
    internal static extern Telephony.TelephonyError GetOperator(IntPtr handle, out string simOperator); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_msin")]
    internal static extern Telephony.TelephonyError GetMsin(IntPtr handle, out string msin); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_spn")]
    internal static extern Telephony.TelephonyError GetSpn(IntPtr handle, out string spn); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_is_changed")]
    internal static extern Telephony.TelephonyError IsChanged(IntPtr handle, out int isChanged); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_state")]
    internal static extern Telephony.TelephonyError GetState(IntPtr handle, out Tizen.Telephony.Sim.State simState); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_application_list")]
    internal static extern Telephony.TelephonyError GetApplicationList(IntPtr handle, out uint appList); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_subscriber_number")]
    internal static extern Telephony.TelephonyError GetSubscriberNumber(IntPtr handle, out string subscriberNumber); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_subscriber_id")]
    internal static extern Telephony.TelephonyError GetSubscriberId(IntPtr handle, out string subscriberId); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_lock_state")]
    internal static extern Telephony.TelephonyError GetLockState(IntPtr handle, out Tizen.Telephony.Sim.LockState lockState); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_group_id1")]
    internal static extern Telephony.TelephonyError GetGroupId1(IntPtr handle, out string gid1); // Deprecated since API13

    [DllImport(Libraries.Telephony, EntryPoint = "telephony_sim_get_call_forwarding_indicator_state")]
    internal static extern Telephony.TelephonyError GetCallForwardingIndicatorState(IntPtr handle, out bool state); // Deprecated since API13
  }
}
