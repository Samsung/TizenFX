using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture grab modes.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureGrabMode
    {
        /// <summary>
        /// mode none.
        /// </summary>
        None,

        /// <summary>
        /// mode exclusive.
        /// </summary>
        Exclusive,

        /// <summary>
        /// mode shared.
        /// </summary>
        Shared,
    }
}
