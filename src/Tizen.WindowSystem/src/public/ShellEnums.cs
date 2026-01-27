using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Enumeration for the window orientation.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum WindowOrientation
    {
        /// <summary>
        /// Portrait.
        /// </summary>
        Portrait = 0,

        /// <summary>
        /// Landscape.
        /// </summary>
        Landscape = 90,

        /// <summary>
        /// Portrait inverse.
        /// </summary>
        PortraitInverse = 180,

        /// <summary>
        /// Landscape inverse.
        /// </summary>
        LandscapeInverse = 270,
    }

    /// <summary>
    /// Visible state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyVisibleState
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Shown state.
        /// </summary>
        Shown = 0x1,
        /// <summary>
        /// Hidden state.
        /// </summary>
        Hidden = 0x2,
    }

    /// <summary>
    /// Expand state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyExpandState
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Expandable state.
        /// </summary>
        On = 0x1,
        /// <summary>
        /// Not Expandable state.
        /// </summary>
        Off = 0x2,
    }

    /// <summary>
    /// Opacity state of softkey.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SoftkeyOpacityState
    {
        /// <summary>
        /// Unknown state. There is no softkey service.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// Opaque state.
        /// </summary>
        Opaque = 0x1,
        /// <summary>
        /// Transparent state.
        /// </summary>
        Transparent = 0x2,
    }
}
