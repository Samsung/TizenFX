using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Tizen.NUI.WindowSystem.Shell
{
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
