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
using static Interop.Telephony;
namespace Tizen.Telephony
{
    /// <summary>
    /// This class provides APIs to obtain information from the modem.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Modem
    {
        internal IntPtr _handle;

        /// <summary>
        /// The Modem class constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API.
        /// </param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if the handle provided is null.
        /// </exception>
        public Modem(SlotHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException();
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Enumeration for the Modem Power Status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum PowerStatus
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// Modem power ON.
            /// </summary>
            On,
            /// <summary>
            /// Modem power OFF.
            /// </summary>
            Off,
            /// <summary>
            /// Modem power RESET.
            /// </summary>
            Reset,
            /// <summary>
            /// Modem power LOW.
            /// </summary>
            Low
        };

        /// <summary>
        /// Gets the IMEI (International Mobile Station Equipment Identity) of a mobile phone.
        /// The IMEI number is used by a GSM network to identify valid devices and therefore, can be used for stopping a stolen phone from accessing that network.
        /// </summary>
        /// <remarks>
        /// For avoding the unexpected behavior of old version applications that have http://tizen.org/privilege/telephony privilege. There is an exceptional handling in case of permission denied.
        /// For an application with API version 6 or higer, if an application doesn't have http://tizen.org/privilege/securesysteminfo privilege, it sets with empty string.
        /// For an application with API version lower than 6. if an application has http://tizen.org/privilege/telephony privilege, it sets with a pseudo value.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/securesysteminfo</privilege>
        /// <privlevel>partner</privlevel>
        /// <value>
        /// The International Mobile Station Equipment Identity.
        /// Empty string if unable to complete the operation.
        /// </value>
        public string Imei
        {
            get
            {
                string imei;
                TelephonyError error = Interop.Modem.GetImei(_handle, out imei);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetImei Failed with error " + error);
                    return "";
                }

                return imei;
            }
        }

        /// <summary>
        /// Gets the power status of the modem.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The Modem power status (0=on,1=off,2=reset,3=low).
        /// </value>
        public PowerStatus CurrentPowerStatus
        {
            get
            {
                PowerStatus status;
                TelephonyError error = Interop.Modem.GetPowerStatus(_handle, out status);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetImei Failed with error " + error);
                    return PowerStatus.Unknown;
                }

                return status;
            }

        }

        /// <summary>
        /// Gets the MEID (Mobile Equipment Identifier) of a mobile phone (for CDMA).
        /// </summary>
        /// <remarks>
        /// For avoding the unexpected behavior of old version applications that have http://tizen.org/privilege/telephony privilege. There is an exceptional handling in case of permission denied.
        /// For an application with API version 6 or higer, if an application doesn't have http://tizen.org/privilege/securesysteminfo privilege, it sets with empty string.
        /// For an application with API version lower than 6. if an application has http://tizen.org/privilege/telephony privilege, it sets with a pseudo value.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/securesysteminfo</privilege>
        /// <privlevel>partner</privlevel>
        /// <value>
        /// The Mobile Equipment Identifier.
        /// Empty string if unable to complete the operation.
        /// </value>
        public string Meid
        {
            get
            {
                string meid;
                TelephonyError error = Interop.Modem.GetMeid(_handle, out meid);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetMeid Failed with error " + error);
                    return "";
                }

                return meid;
            }

        }
    }
}
