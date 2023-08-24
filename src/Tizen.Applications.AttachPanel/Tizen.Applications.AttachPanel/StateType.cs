using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Enumeration for the attach panel's window state.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API Level 10. Will be removed in API Level 12.")]
    public enum StateType
    {
        /// <summary>
        /// Attach panel is not visible.
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// Attach panel is in the partial window mode.
        /// </summary>
        Partial,

        /// <summary>
        /// Attach panel is in the full screen mode.
        /// </summary>
        Full,
    }
}