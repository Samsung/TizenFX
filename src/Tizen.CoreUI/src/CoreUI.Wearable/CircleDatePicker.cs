using System;
using System.Collections.Generic;
using System.Text;

namespace CoreUI
{
    namespace Wearable
    {
        /// <summary>
        /// CircleDatePicker is a circular designed widget to display and handle date picker value by the rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class CircleDatePicker : CoreUI.UI.DatePicker, ICircleWidget
        {
            IntPtr _handle;

            IntPtr ICircleWidget.CircleHandle => _handle;

            /// <summary>
            /// Sets or gets the color of the marker.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) MarkerColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "default", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "default", value.r, value.g, value.b, value.a);
                }
            }
            /// <summary>
            /// Creates and initializes a new instance of the CircleDatePicker class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleDatePicker will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleDatePicker(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_datetime_add(this.NativeHandle, IntPtr.Zero);
                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);
            }

            [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)]
            internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

            /// <summary>Enables or disables this widget.
            /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
            /// </summary>
            /// <param name="disabled"><c>true</c> if the widget is disabled.<br/>The default value is <c>false</c>.</param>
            /// <since_tizen> 6 </since_tizen>
            public override void SetDisabled(bool disabled)
            {
                base.SetDisabled(disabled);
                Interop.Eext.eext_circle_object_disabled_set(_handle, disabled);
            }

            /// <summary>
            /// Sets or gets the line width of the marker.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public int MarkerLineWidth
            {
                get
                {
                    return Interop.Eext.eext_circle_object_item_line_width_get(_handle, "default");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_line_width_set(_handle, "default", value);
                }
            }

            /// <summary>
            /// Sets or gets the radius of the marker.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double MarkerRadius
            {
                get
                {
                    return Interop.Eext.eext_circle_object_item_radius_get(_handle, "default");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_radius_set(_handle, "default", value);
                }
            }
        }
    }
}