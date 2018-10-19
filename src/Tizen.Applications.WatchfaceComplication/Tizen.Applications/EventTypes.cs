using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Enumeration for the complication event type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [Flags]
    public enum EventTypes
    {
        /// <summary>
        /// The complication event none.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        EventNone = 0x01,
        /// <summary>
        /// The complication event tap.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        EventTap = 0x02,
        /// <summary>
        /// The complication event double tap.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        EventDoubleTap = 0x04
    }
}
