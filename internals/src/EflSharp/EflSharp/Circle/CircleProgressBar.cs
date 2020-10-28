using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// CircleProgressBarBar is a part used to set the color of the bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleProgressBarBar : ICircleColor
            {
                IntPtr _handle;
                public CircleProgressBarBar(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the color of the bar on the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_color_set(_handle, r, g, b, a);
                }

                /// <summary>
                /// Gets the color of the bar on the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_color_get(_handle, out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// CircleProgressBarBarBackground is a part used to set the background color of the bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleProgressBarBarBackground : ICircleColor
            {
                IntPtr _handle;
                public CircleProgressBarBarBackground(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the background color of the bar on the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "bg", r, g, b, a);
                }

                /// <summary>
                /// Gets the background color of the bar on the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "bg", out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// The CircleProgressBar is a widget for visually representing the progress status of a given job or task with the circular design.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleProgressBar : Efl.Ui.Layout, ICircleWidget
            {
                IntPtr _handle;

                /// <summary>
                /// Get the handle for the circle widget.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public virtual IntPtr CircleHandle => _handle;

                /// <summary>
                /// Sets or gets the color of the bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleProgressBarBar Bar;

                /// <summary>
                /// Sets or gets the background color of the bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleProgressBarBarBackground BarBackground;

                /// <summary>
                /// Creates and initializes a new instance of the CircleProgressBar class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new CircleProgressBar will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public CircleProgressBar(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_progressbar_add(parent.NativeHandle, IntPtr.Zero);

                    Bar = new CircleProgressBarBar(_handle);
                    BarBackground = new CircleProgressBarBarBackground(_handle);

                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                public override Efl.Object FinalizeAdd()
                {
                    this.SetTheme("circle_progressbar", null, null);
                    return this;
                }

                /// <summary>
                /// Sets or gets the disabled state of the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool Disable
                {
                    get => !IsEnable;
                    set => IsEnable = !value;
                }

                /// <summary>
                /// Sets or gets the enabled state of the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool IsEnable
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
                /// Gets or sets the value displayed by the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double Value
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_value_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_value_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the maximum values for the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double Maximum
                {
                    get
                    {
                        double max = 0;
                        double min = 0;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = Minimum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, min, value);
                    }
                }

                /// <summary>
                /// Sets or gets the minimum values for the circle progressbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double Minimum
                {
                    get
                    {
                        double max = 0;
                        double min = 0;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = Maximum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, value, max);
                    }
                }

                /// <summary>
                /// Sets or gets the angle in degree of the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BarAngle
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_angle_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_angle_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle in degree of the circle progressbar background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BackgroundAngle
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_angle_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_angle_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle offset for the circle progressbar bar.
                /// Offset value means start position of the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BarAngleOffset
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_angle_offset_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_angle_offset_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle offset for the circle progressbar background.
                /// Offset value means start position of the circle progressbar background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BackgroundAngleOffset
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_angle_offset_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_angle_offset_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Sets or gets the maximum angle of the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BarAngleMaximum
                {
                    get
                    {
                        double max = 0;
                        double min = 0;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = BarAngleMinimum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, min, value);
                    }
                }

                /// <summary>
                /// Sets or gets the minimum angle of the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BarAngleMinimum
                {
                    get
                    {
                        double max = 0;
                        double min = 0;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = BarAngleMaximum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, value, max);
                    }
                }

                /// <summary>
                /// Sets or gets the line width of the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public int BarLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_line_width_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_line_width_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the line width of the circle progressbar background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public int BackgroundLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Gets or sets the radius value for the circle progressbar bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BarRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_radius_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_radius_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Gets or sets the radius value for the circle progressbar background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public double BackgroundRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "bg", value);
                    }
                }
            }
        }
    }
}
