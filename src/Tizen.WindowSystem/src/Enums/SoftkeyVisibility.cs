using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Visible state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyVisibility
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Shown state.
        /// </summary>
        Shown = 0x1,
        /// <summary>
        /// Hidden state.
        /// </summary>
        Hidden = 0x2,
    }
}
