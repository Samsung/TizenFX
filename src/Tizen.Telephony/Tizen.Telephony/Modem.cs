/// Copyright 2016 by Samsung Electronics, Inc.
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using static Interop.Telephony;
namespace Tizen.Telephony
{
    /// <summary>
    /// This Class provides API's to obtain information from the modem.
    /// </summary>
    public class Modem
    {
        internal IntPtr _handle;

        /// <summary>
        /// Modem Class Constructor
        /// </summary>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if handle provided is null
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
        /// Enumeration for Modem Power Status.
        /// </summary>
        public enum PowerStatus
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// Modem power ON
            /// </summary>
            On,
            /// <summary>
            /// Modem power OFF
            /// </summary>
            Off,
            /// <summary>
            /// Modem power RESET
            /// </summary>
            Reset,
            /// <summary>
            /// Modem power LOW
            /// </summary>
            Low
        };

        /// <summary>
        /// Gets the IMEI (International Mobile Station Equipment Identity) of a mobile phone.
        /// The IMEI number is used by a GSM network to identify valid devices and therefore can be used for stopping a stolen phone from accessing that network.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The International Mobile Station Equipment Identity
        /// empty string if unable to complete the operation
        /// </returns>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The Modem power status (0=on,1=off,2=reset,3=low)
        /// </returns>
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
        /// Gets the MEID (Mobile Equipment Identifier) of a mobile phone. (for CDMA)
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The Mobile Equipment Identifier
        /// empty string if unable to complete the operation
        /// </returns>
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
