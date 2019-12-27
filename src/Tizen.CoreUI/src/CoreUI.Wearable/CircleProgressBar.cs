using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CoreUI
{
    namespace Wearable
    {
        /// <summary>
        /// The CircleProgressBar is a widget for visually representing the progress status of a given job or task with the circular design.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class CircleProgressBar : CoreUI.UI.Layout, CoreUI.UI.IRangeDisplay, ICircleWidget
        {
            IntPtr _handle;

            IntPtr ICircleWidget.CircleHandle => _handle;
            private double _current_value;

            /// <summary>
            /// Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> is getting changed.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler Changed;

            /// <summary>
            /// Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> has reached the maximum of <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/>.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler MaxReached;

            /// <summary>
            /// Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/>.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler MinReached;

            /// <summary>
            /// Sets or gets the color of the bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) BarColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_color_get(_handle, out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_color_set(_handle, value.r, value.g, value.b, value.a);
                }
            }

            /// <summary>
            /// Sets or gets the background color of the bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) BackgroundColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "bg", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "bg", value.r, value.g, value.b, value.a);
                }
            }

            /// <summary>
            /// Creates and initializes a new instance of the CircleProgressBar class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleProgressBar will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleProgressBar(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_progressbar_add(parent.NativeHandle, IntPtr.Zero);
                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);

                _current_value = 0.0;
                Interop.Eext.eext_circle_object_value_min_max_set(_handle, 0.0, 10.0);
                Interop.Eext.eext_circle_object_value_set(_handle, _current_value);
            }

            [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)]
            internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

            public override CoreUI.Object FinalizeAdd()
            {
                this.SetTheme("circle_progressbar", null, null);
                return this;
            }

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
            /// Control the value (position) of the widget within its valid range.
            /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
            /// <returns>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/>).</returns>
            /// <since_tizen> 6 </since_tizen>
            public virtual double GetRangeValue()
            {
                return Interop.Eext.eext_circle_object_value_get(_handle);
            }

            /// <summary>
            /// Set the minimum and maximum values for given range widget.
            /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
            ///
            /// The default minimum and maximum values may be different for each class.
            ///
            /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
            /// <param name="min">The minimum value.</param>
            /// <param name="max">The maximum value.</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void GetRangeLimits(out double min, out double max)
            {
                Interop.Eext.eext_circle_object_value_min_max_get(_handle, out min, out max);
            }

            /// <summary>
            /// Set the minimum and maximum values for given range widget.
            /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
            ///
            /// The default minimum and maximum values may be different for each class.
            ///
            /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
            /// <param name="min">The minimum value.</param>
            /// <param name="max">The maximum value.</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void SetRangeLimits(double min, double max)
            {
                Interop.Eext.eext_circle_object_value_min_max_set(_handle, min, max);
            }

            /// <summary>
            /// Control the value (position) of the widget within its valid range.
            /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
            /// <param name="val">The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/>).</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void SetRangeValue(double val)
            {
                double min, max;
                Interop.Eext.eext_circle_object_value_min_max_get(_handle, out min, out max);
                Interop.Eext.eext_circle_object_value_set(_handle, val);

                if (_current_value != val)
                {
                    _current_value = val;
                    Changed?.Invoke(this, EventArgs.Empty);
                }

                if (val == min)
                    MinReached?.Invoke(this, EventArgs.Empty);
                if (val == max)
                    MaxReached?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            /// Control the value (position) of the widget within its valid range.
            /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
            /// <value>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.GetRangeLimits"/>).</value>
            /// <since_tizen> 6 </since_tizen>
            public double RangeValue
            {
                get { return GetRangeValue(); }
                set { SetRangeValue(value); }
            }

            /// <summary>
            /// Set the minimum and maximum values for given range widget.
            /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
            ///
            /// The default minimum and maximum values may be different for each class.
            ///
            /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
            /// <value>The minimum value.</value>
            /// <since_tizen> 6 </since_tizen>
            public (double, double) RangeLimits
            {
                get
                {
                    double _out_min = default(double);
                    double _out_max = default(double);
                    GetRangeLimits(out _out_min, out _out_max);
                    return (_out_min, _out_max);
                }
                set { SetRangeLimits(value.Item1, value.Item2); }
            }

            /// <summary>
            /// Sets or gets the angle in degree of the circle progressbar bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double BarAngle
            {
                get
                {
                    return Interop.Eext.eext_circle_object_angle_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_angle_set(_handle, value);
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
                    return Interop.Eext.eext_circle_object_item_angle_get(_handle, "bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_angle_set(_handle, "bg", value);
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
                    return Interop.Eext.eext_circle_object_angle_offset_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_angle_offset_set(_handle, value);
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
                    return Interop.Eext.eext_circle_object_item_angle_offset_get(_handle, "bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_angle_offset_set(_handle, "bg", value);
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
                    Interop.Eext.eext_circle_object_angle_min_max_get(_handle, out min, out max);
                    return max;
                }
                set
                {
                    double min = BarAngleMinimum;
                    Interop.Eext.eext_circle_object_angle_min_max_set(_handle, min, value);
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
                    Interop.Eext.eext_circle_object_angle_min_max_get(_handle, out min, out max);
                    return min;
                }
                set
                {
                    double max = BarAngleMaximum;
                    Interop.Eext.eext_circle_object_angle_min_max_set(_handle, value, max);
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
                    return Interop.Eext.eext_circle_object_line_width_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_line_width_set(_handle, value);
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
                    return Interop.Eext.eext_circle_object_item_line_width_get(_handle, "bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_line_width_set(_handle, "bg", value);
                }
            }

            /// <summary>
            /// Sets or gets the radius value for the circle progressbar bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double BarRadius
            {
                get
                {
                    return Interop.Eext.eext_circle_object_radius_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_radius_set(_handle, value);
                }
            }

            /// <summary>
            /// Sets or gets the radius value for the circle progressbar background.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double BackgroundRadius
            {
                get
                {
                    return Interop.Eext.eext_circle_object_item_radius_get(_handle, "bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_radius_set(_handle, "bg", value);
                }
            }
        }
    }
}
