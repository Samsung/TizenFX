
using System;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The MoreOptionItemEventArgs is a event args class for MoreOptionItem.
    /// Inherits EventArgs
    /// </summary>
    public class MoreOptionItemEventArgs : EventArgs
    {
        /// <summary>
        /// Sets or gets the more option item
        /// </summary>
        public MoreOptionItem Item { get; set; }
    }
}
