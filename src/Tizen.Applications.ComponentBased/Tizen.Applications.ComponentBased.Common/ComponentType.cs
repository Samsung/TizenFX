using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// Component types.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ComponentType
    {
        /// <summary>
        /// The frame component.
        /// </summary>
        Frame = Interop.CBApplication.NativeComponentType.Frame,

        /// <summary>
        /// The service component.
        /// </summary>
        Service = Interop.CBApplication.NativeComponentType.Service
    }
}
