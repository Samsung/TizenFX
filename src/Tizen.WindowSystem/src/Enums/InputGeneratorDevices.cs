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
        /// All devices.
        /// </summary>
        All = Touchscreen | Keyboard | Pointer
    }
}
