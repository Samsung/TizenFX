using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// Indicates Provider Interval Changed callback.
    /// </summary>
    public class ProviderIntervalChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Provider Interval Changed callback.
        /// </summary>
        internal ProviderIntervalChangedEventArgs(IntPtr _userData, uint intervalMs) {
            IntervalMs = intervalMs;
            UserData = _userData;
        }

        /// <summary>
        /// Interval
        /// </summary>
        public uint IntervalMs { get; private set; }
        /// <summary>
        /// Indicates userdata sent by provider Interval changed callback
        /// </summary>
        public IntPtr UserData { get; private set; }
    }
}
