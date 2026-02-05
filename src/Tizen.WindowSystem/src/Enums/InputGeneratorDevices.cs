using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of input device types.
    /// </summary>
    [Flags]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum InputGeneratorDevices
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Touchscreen device.
        /// </summary>
        Touchscreen = (1 << 0),

        /// <summary>
        /// Keyboard device.
        /// </summary>
        Keyboard = (1 << 1),

        /// <summary>
        /// Pointer device.
        /// </summary>
        Pointer = (1 << 2),

        /// <summary>
        /// Keyboard and Touchscreen device.
        /// </summary>
        All = Touchscreen | Keyboard,
    }
}
