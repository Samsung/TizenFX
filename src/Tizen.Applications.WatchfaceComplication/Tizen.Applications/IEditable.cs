using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Editable interface.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
	public interface IEditable
	{
        /// <summary>
        /// The information about editable's ID.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        int EditableId { get; set; }

        /// <summary>
        /// The information about editable's name.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        string Name { get; set; }

        /// <summary>
        /// The information about editable's geomatry.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Highlight Highlight { get; set; }

        /// <summary>
        /// The information about editable's current data index.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        int GetCurrentDataIndex();

        /// <summary>
        /// The information about editable's current data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Bundle GetCurrentData();
    }
}