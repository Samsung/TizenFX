using System;

namespace Tizen.System
{
    /// <summary>
    /// The IR API provides functions to control a IR transmitter.
    /// The IR API provides the way to get the information whether IR is available and transmit IR command.
    /// </summary>
    public static class IR
    {
        /// <summary>
        /// Gets the information whether IR module is available.
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                bool available = false;
                DeviceError res = (DeviceError) Interop.Device.DeviceIRIsAvailable(out available);
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
        public void Transmit(int carrierFreequency, IList<int> pattern)
        {
            int[] patternArray = pattern.toArray();
            DeviceError res = (DeviceError) Interop.Device.DeviceIRTransmit(carrierFreequency, patternArray, pattern.Count());
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to trasmit IR command.");
            }
        }
    }
}
