// Copyright 2016 by Samsung Electronics, Inc.
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Modem Interop Class
    /// </summary>
    internal static partial class Modem
    {
        [DllImport(Libraries.Telephony, EntryPoint = "telephony_modem_get_imei")]
        internal static extern Telephony.TelephonyError GetImei(IntPtr handle, out string imei);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_modem_get_power_status")]
        internal static extern Telephony.TelephonyError GetPowerStatus(IntPtr handle, out Tizen.Telephony.Modem.PowerStatus status);

        [DllImport(Libraries.Telephony, EntryPoint = "telephony_modem_get_meid")]
        internal static extern Telephony.TelephonyError GetMeid(IntPtr handle, out string meid);
    }
}
