using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Editable state.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum State
    {
        /// <summary>
        /// The editable editing is complete.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Complete,
        /// <summary>
        /// The editable editing is on going now.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        OnGoing,

        /// <summary>
        /// The editable editing is canceled.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Cancel
    }
}
