using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// Indicates Sensor Added callback.
    /// </summary>
    public class SensorAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Sensor Added Callback.
        /// </summary>
        internal SensorAddedEventArgs(IntPtr userData) {
            UserData = UserData;
        }

        /// <summary>
        /// Indicates userdata sent by provider sensor added callback
        /// </summary>
        public IntPtr UserData { get; private set; }
    }
}
