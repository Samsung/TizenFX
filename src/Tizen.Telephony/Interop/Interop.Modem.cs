﻿/*
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
    /// The Modem Interop class.
    /// Deprecated since API13.
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
