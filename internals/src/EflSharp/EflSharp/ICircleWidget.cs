using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// The ICircleWidget is the interface for a widget to display and handle with the CircleSurface.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public interface ICircleWidget
            {
                /// <summary>
                /// Gets the handle for the Circle widget.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                IntPtr CircleHandle { get; }

                /// <summary>
                /// Gets the CircleSurface used in this widget.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                CircleSurface CircleSurface { get; }
            }

            /// <summary>
            /// The IRotaryActionWidget is the interface for a widget that has action by the Rotary event.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public interface IRotaryActionWidget : ICircleWidget
            {
            }
        }
    }
}
