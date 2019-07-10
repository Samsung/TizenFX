using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The extended class from AppControl to support components.
    /// </summary>
    public class CBAppControl : AppControl
    {
        /// <summary>
        /// Component ID
        /// </summary>
        public string ComponentId { get; set; }
    }
}
