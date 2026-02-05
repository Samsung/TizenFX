using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Opacity state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyOpacity
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Opaque state.
        /// </summary>
        Opaque = 0x1,
        /// <summary>
        /// Transparent state.
        /// </summary>
        Transparent = 0x2,
    }
}
