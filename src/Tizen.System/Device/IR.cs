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
