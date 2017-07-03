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
using System.Collections.Generic;
using System.Linq;

namespace Tizen.System
{
    /// <summary>
    /// The IR API provides functions to control a IR transmitter.
    /// The IR API provides the way to get the information whether IR is available and transmit IR command.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/use_ir
    /// </privilege>
    /// <code>
    ///     Console.WriteLine("IR availablity for this device is: {0}", IR.IsAvailable);
    /// </code>
    public static class IR
    {
        /// <summary>
        /// Gets the information whether IR module is available.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsAvailable
        {
            get
            {
                bool available = false;
                DeviceError res = (DeviceError)Interop.Device.DeviceIRIsAvailable(out available);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get ir status.");
                }
                return available;
            }
        }

        /// <summary>
        /// Transmits IR command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="carrierFreequency">
        /// Carrier frequency to transmit IR command (Hertz).
        /// </param>
        /// <param name="pattern">
        /// IR command list of type interger.
        /// </param>
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "InvalidOperationException"> In case of any system error.</exception>
        /// <exception cref = "NotSupportedException"> In case of device does not support this behavior.</exception>
        /// <code>
        ///    try
        ///    {
        ///       List<int> pattern = new List<int>();
        ///       pattern.Add(10);
        ///       pattern.Add(50);
        ///       IR.Transmit(60657, pattern);
        ///    }
        ///    catch(Exception e)
        ///    {
        ///    }
        /// </code>
        public static void Transmit(int carrierFreequency, IList<int> pattern)
        {
            int[] patternArray = pattern.ToArray();
            DeviceError res = (DeviceError)Interop.Device.DeviceIRTransmit(carrierFreequency, patternArray, pattern.Count());
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to trasmit IR command.");
            }
        }
    }
}
