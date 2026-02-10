using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Enumeration for visible state of quickpanel service window.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum QuickPanelVisibility
    {
        /// <summary>
        /// Unknown state. There is no quickpanel service.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Unknown = 0x0,
        /// <summary>
        /// Shown state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Shown = 0x1,
        /// <summary>
        /// Hidden state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Hidden = 0x2,
    }
}
