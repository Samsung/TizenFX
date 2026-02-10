using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of touch event types.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum TouchAction
    {
        /// <summary>
        /// Touch begin.
        /// </summary>
        Begin,

        /// <summary>
        /// Touch move.
        /// </summary>
        Update,

        /// <summary>
        /// Touch end.
        /// </summary>
        End,
    }
}
