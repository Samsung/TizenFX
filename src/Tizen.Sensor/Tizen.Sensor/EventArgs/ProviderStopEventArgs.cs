using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// Indicates Provider stop callback.
    /// </summary>
    public class ProviderStopEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Provider Stop callback.
        /// </summary>
        internal ProviderStopEventArgs(IntPtr userData) {
            UserData = userData;
        }

        /// <summary>
        /// Indicates userdata sent by provider stop callback
        /// </summary>
        public IntPtr UserData { get; private set; }
    }
}
