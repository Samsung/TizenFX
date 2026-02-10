using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Enumeration for placed type of taskbar service window.
    /// </summary>
    public enum TaskbarPosition
    {
        /// <summary>
        /// Place to Bottom of Screen. Default type.
        /// </summary>
        Bottom = 0x0,
        /// <summary>
        /// Place to Top of Screen.
        /// </summary>
        Top = 0x1,
        /// <summary>
        /// Place to Left Side of Screen.
        /// </summary>
        Left = 0x2,
        /// <summary>
        /// Place to Right Side of Screen.
        /// </summary>
        Right = 0x3,
    }
}
