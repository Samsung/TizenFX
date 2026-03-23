using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Orientation of the window.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum WindowOrientation
    {
        /// <summary>
        /// Portrait orientation.
        /// </summary>
        Portrait = 0,
        /// <summary>
        /// Landscape orientation.
        /// </summary>
        Landscape = 90,
        /// <summary>
        /// Inverse portrait orientation.
        /// </summary>
        PortraitInverse = 180,
        /// <summary>
        /// Inverse landscape orientation.
        /// </summary>
        LandscapeInverse = 270,
    }
}
