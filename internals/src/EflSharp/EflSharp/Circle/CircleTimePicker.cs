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
            /// CircleTimepicker is a circular designed widget to display and handle time picker value by the rotary event.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleTimepicker : Efl.Ui.Timepicker, ICircleWidget
            {
                IntPtr _handle;

                /// <summary>
                /// Get the handle for the circle widget.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public IntPtr CircleHandle => _handle;

                /// <summary>
                /// Sets or gets the color of the marker.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public Efl.Gfx.Color32 MarkerColor
                {
                    get
                    {
                        int r, g, b, a;
                        Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "default", out r, out g, out b, out a);
                        return new Efl.Gfx.Color32((byte)r, (byte)g, (byte)b, (byte)a);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "default", value.R, value.G, value.B, value.A);
                    }
                }

                /// <summary>
                /// Creates and initializes a new instance of the CircleTimepicker class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new CircleTimepicker will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public CircleTimepicker(Efl.Object parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_datetime_add(this.NativeHandle, IntPtr.Zero);
                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                /// <summary>Enables or disables this widget.
                /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
                /// </summary>
                /// <param name="disabled"><c>true</c> if the widget is disabled.<br/>The default value is <c>false</c>.</param>
                /// <since_tizen> 6 </since_tizen>
                public override void SetDisabled(bool disabled)
                {
                    base.SetDisabled(disabled);
                    Interop.Eext.eext_circle_object_disabled_set(CircleHandle, disabled);
                }

                /// <summary>
                /// Sets or gets the line width of the marker.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public int MarkerLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "default");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "default", value);
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
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "default");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "default", value);
                    }
                }
            }
        }
    }
}
