using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Enumeration for scroll mode of quickpanel service window.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum QuickPanelScrollMode
    {
        /// <summary>
        /// Unknown state. There is no quickpanel service.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Unknown = 0x0,
        /// <summary>
        /// Scrollable state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Scrollable = 0x1,
        /// <summary>
        /// Not scrollable state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        NotScrollable = 0x2,
        /// <summary>
        /// Retain scroll mode.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Retain = 0x3,
    }
}
