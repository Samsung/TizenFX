using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The ICircleWidget is the interface for a widget to display and handle with circle surface
    /// </summary>
    public interface ICircleWidget
    {
        /// <summary>
        /// Gets the handle for Circle Widget.
        /// </summary>
        IntPtr CircleHandle { get; }

        /// <summary>
        /// Gets the CircleSurface used in this widget
        /// </summary>
        CircleSurface CircleSurface { get; }
    }

    /// <summary>
    /// The IRotaryActionWidget is the interface for a widget has action by rotary event
    /// </summary>
    public interface IRotaryActionWidget : ICircleWidget
    {
    }
}
