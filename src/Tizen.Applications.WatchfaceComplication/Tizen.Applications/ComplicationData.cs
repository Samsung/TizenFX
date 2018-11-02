using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Complication data class.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public abstract class ComplicationData
    {
        internal abstract ComplicationError UpdateSharedData(IntPtr sharedData);
    }
}