using System;
using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Provides data for the <see cref="SoftkeyService.VisibleChanged"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyVisibleChangedEventArgs : EventArgs
    {
        internal SoftkeyVisibleChangedEventArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }

        /// <summary>
        /// Gets whether the softkey is visible.
        /// </summary>
        public bool IsVisible { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="SoftkeyService.ExpandChanged"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyExpandChangedEventArgs : EventArgs
    {
        internal SoftkeyExpandChangedEventArgs(bool isExpandable)
        {
            IsExpandable = isExpandable;
        }

        /// <summary>
        /// Gets whether the softkey is expandable.
        /// </summary>
        public bool IsExpandable { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="SoftkeyService.OpacityChanged"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyOpacityChangedEventArgs : EventArgs
    {
        internal SoftkeyOpacityChangedEventArgs(bool isOpaque)
        {
            IsOpaque = isOpaque;
        }

        /// <summary>
        /// Gets whether the softkey is opaque.
        /// </summary>
        public bool IsOpaque { get; }
    }
}
