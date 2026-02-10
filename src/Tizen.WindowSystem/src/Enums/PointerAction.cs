using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of pointer event types.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PointerAction
    {
        /// <summary>
        /// Pointer down.
        /// </summary>
        Down,

        /// <summary>
        /// Pointer up.
        /// </summary>
        Up,

        /// <summary>
        /// Pointer move.
        /// </summary>
        Move,
    }
}
