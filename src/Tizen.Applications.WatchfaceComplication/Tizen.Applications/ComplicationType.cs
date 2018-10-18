using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Enumeration for the complication type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [Flags]
    public enum ComplicationType
    {
        /// <summary>
        /// The complication type NoData do not displays anything.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NoData = 0x01,
        /// <summary>
        /// The complication type ShortText displays short text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ShortText = 0x02,
        /// <summary>
        /// The complication type LongText displays long text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        LongText = 0x04,
        /// <summary>
        /// The complication type RangedValue displays minimum, maximum, current value.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        RangedValue = 0x08,
        /// <summary>
        /// The complication type Time displays time.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Time = 0x10,
        /// <summary>
        /// The complication type Icon displays icon.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Icon = 0x20,
        /// <summary>
        /// The complication type Image displays image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Image = 0x40
    }
}