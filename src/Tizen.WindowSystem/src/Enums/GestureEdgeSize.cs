using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture edge sizes.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureEdgeSize
    {
        /// <summary>
        /// edge size none.
        /// </summary>
        None,

        /// <summary>
        /// edge size full.
        /// </summary>
        Full,

        /// <summary>
        /// edge size partial.
        /// </summary>
        Partial,
    }
}
