using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Enumeration for type of quickpanel service window.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum QuickPanelCategory
    {
        /// <summary>
        /// Unknown type. There is no quickpanel service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// System default type.
        /// </summary>
        SystemDefault = 0x1,
        /// <summary>
        /// Context menu type.
        /// </summary>
        ContextMenu = 0x2,
        /// <summary>
        /// Apps menu type.
        /// </summary>
        AppsMenu = 0x3,
    }
}
