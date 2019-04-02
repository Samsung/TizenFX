using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    public class SensorRemovedEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Sensor Removed callback.
        /// </summary>
        internal SensorRemovedEventArgs(IntPtr userData) {
            UserData = userData;
        }

        /// <summary>
        /// Indicates userdata sent by provider sensor removed callback
        /// </summary>
        public IntPtr UserData { get; private set; }
    }
}
