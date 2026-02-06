using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture states.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureState
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Begin.
        /// </summary>
        Begin,

        /// <summary>
        /// Update.
        /// </summary>
        Update,

        /// <summary>
        /// End.
        /// </summary>
        End,

        /// <summary>
        /// Done.
        /// </summary>
        Done,
    }
}
