using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Expand state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyExpandMode
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Expandable state.
        /// </summary>
        On = 0x1,
        /// <summary>
        /// Not Expandable state.
        /// </summary>
        Off = 0x2,
    }
}
