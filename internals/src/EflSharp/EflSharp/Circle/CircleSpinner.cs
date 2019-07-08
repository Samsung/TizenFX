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
            /// CircleSpinnerMarker is a part used to set the color of the marker.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleSpinnerMarker : ICircleColor
            {
                IntPtr _handle;
                public CircleSpinnerMarker(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the color of the marker on the circle spinner.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "default", r, g, b, a);
                }

                /// <summary>
                /// Gets the color of the marker on the circle spinner.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "default", out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// The CircleSpinner is a widget to display and handle the spinner value by the rotary event.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleSpinner : Efl.Ui.Spin, ICircleWidget
            {
                double _angleRatio = -1.0;

                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                /// <summary>
                /// Sets or gets the color of the marker.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleSpinnerMarker Marker;

                /// <summary>
                /// Creates and initializes a new instance of the CircleSpinner class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new CircleSpinner will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public CircleSpinner(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_spinner_add(this.NativeHandle, IntPtr.Zero);

                    Marker = new CircleSpinnerMarker(_handle);

                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                /// <summary>
                /// Sets or gets the circle spinner angle per each spinner value.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double AngleRatio
                {
                    get
                    {
                        if (_angleRatio <= 0)
                        {
                            double Minimum, Maximum;

                            GetRangeLimits(out Minimum, out Maximum);
                            if (Maximum == Minimum)
                            {
                                return 0.0;
                            }
                            else
                            {
                                return 360 / (Maximum - Minimum);
                            }
                        }

                        return _angleRatio;
                    }
                    set
                    {
                        if (value > 0)
                        {
                            if (_angleRatio == value) return;

                            _angleRatio = value;

                            Interop.Eext.eext_circle_object_spinner_angle_set(CircleHandle, _angleRatio);
                        }
                    }
                }

                /// <summary>
                /// Sets or gets the disabled state of the circle spinner.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool Disable
                {
                    get => !Enable;
                    set => Enable = !value;
                }

                /// <summary>
                /// Sets or gets the enabled state of the circle spinner.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool Enable
                {
                    get
                    {
                        return !Interop.Eext.eext_circle_object_disabled_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_disabled_set(CircleHandle, !value);
                    }
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
