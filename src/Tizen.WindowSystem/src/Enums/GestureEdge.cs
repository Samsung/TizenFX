using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture edges.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureEdge
    {
        /// <summary>
        /// edge none.
        /// </summary>
        None,

        /// <summary>
        /// edge top.
        /// </summary>
        Top,

        /// <summary>
        /// edge right.
        /// </summary>
        Right,

        /// <summary>
        /// edge bottom.
        /// </summary>
        Bottom,

        /// <summary>
        /// edge left.
        /// </summary>
        Left,
    }
}
