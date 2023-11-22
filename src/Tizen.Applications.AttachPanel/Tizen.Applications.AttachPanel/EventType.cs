using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Enumeration for the attach panel event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
    public enum EventType
    {
        /// <summary>
        /// Attach panel starts the effect to show.
        /// </summary>
        ShowStart = 1,

        /// <summary>
        /// Attach panel finishes the effect to show.
        /// </summary>
        ShowFinish,

        /// <summary>
        /// Attach panel starts the effect to hide the panel.
        /// </summary>
        HideStart,

        /// <summary>
        /// Attach panel finishes the effect to hide the panel.
        /// </summary>
        HideFinish,
    }
}
