using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CoreUI
{
    namespace Wearable
    {
        /// <summary>
        /// CircleSlider is a circular designed widget used to select a value in a range by the rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class CircleSlider : CoreUI.UI.Layout, CoreUI.UI.IRangeInteractive, ICircleWidget
        {
            IntPtr _handle;

            IntPtr ICircleWidget.CircleHandle => _handle;

            /// <summary>
            /// Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> is getting changed.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler Changed;
            const string ChangedEventName = "value,changed";
            private Interop.Evas.SmartCallback smartChanged;

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
            /// Called when the widget&apos;s value has changed and has remained unchanged for 0.2s.
            /// This allows filtering out unwanted &quot;noise&quot; from the widget if you are only interested in its final position.
            /// Use this event instead of <see cref="CoreUI.UI.IRangeDisplay.Changed"/>
            /// if you are going to perform a costly operation on its handler.</summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler Steady;

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
            /// Creates and initializes a new instance of the CircleSlider class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleSlider will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleSlider(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_slider_add(parent.NativeHandle, IntPtr.Zero);
                smartChanged = new Interop.Evas.SmartCallback((d, o, e) =>
                {
                    Changed?.Invoke(this, EventArgs.Empty);
                    double ori_value = Interop.Eext.eext_circle_object_value_get(_handle);
                    SetRangeValue(ori_value);
                });

                Interop.Evas.evas_object_smart_callback_add(_handle, ChangedEventName, smartChanged, IntPtr.Zero);

                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);

                Interop.Eext.eext_circle_object_value_min_max_set(_handle, 0.0, 10.0);
                Interop.Eext.eext_circle_object_value_set(_handle, 0.0);
            }

            [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)]
            internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

            public override CoreUI.Object FinalizeAdd()
            {
                this.SetTheme("circle_slider", null, null);
                return this;
            }

            /// <summary>
            /// Enables or disables this widget.
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
            /// Control the step used to increment or decrement values for given widget.
            /// This value will be incremented or decremented to the displayed value.
            ///
            /// By default step value is equal to 1.
            ///
            /// Warning: The step value should be bigger than 0.</summary>
            /// <value>The step value.</value>
            /// <since_tizen> 6 </since_tizen>
            public double RangeStep
            {
                get { return GetRangeStep(); }
                set { SetRangeStep(value); }
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
            /// Control the step used to increment or decrement values for given widget.
            /// This value will be incremented or decremented to the displayed value.
            ///
            /// By default step value is equal to 1.
            ///
            /// Warning: The step value should be bigger than 0.</summary>
            /// <returns>The step value.</returns>
            /// <since_tizen> 6 </since_tizen>
            public virtual double GetRangeStep()
            {
                return Interop.Eext.eext_circle_object_slider_step_get(_handle);
            }

            /// <summary>
            /// Control the step used to increment or decrement values for given widget.
            /// This value will be incremented or decremented to the displayed value.
            ///
            /// By default step value is equal to 1.
            ///
            /// Warning: The step value should be bigger than 0.</summary>
            /// <param name="step">The step value.</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void SetRangeStep(double step)
            {
                Interop.Eext.eext_circle_object_slider_step_set(_handle, step);
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

                if (val == min)
                    MinReached?.Invoke(this, EventArgs.Empty);
                if (val == max)
                    MaxReached?.Invoke(this, EventArgs.Empty);

                CoreUI.LoopTimer timer = new CoreUI.LoopTimer(this, 0.2);
                timer.TimerTick += (object sender, EventArgs e) =>
                {
                    Steady?.Invoke(this, EventArgs.Empty);
                    timer.Del();
                };
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
            /// Sets or gets the line width of the circle slider bar.
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
            /// Sets or gets the line width of the circle slider background.
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
            /// Sets or gets the angle in degree of the circle slider bar.
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
            /// Sets or gets the angle in degree of the circle slider background.
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
            /// Sets or gets the angle offset for the slider bar.
            /// Offset value means start position of the slider bar.
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
            /// Sets or gets the angle offset for the circle slider background.
            /// Offset value means start position of the circle slider background.
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
            /// Sets or gets the minimum angle of the circle slider bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double BarAngleMinimum
            {
                get
                {
                    double min;
                    double max;
                    Interop.Eext.eext_circle_object_angle_min_max_get(_handle, out min, out max);
                    return min;
                }
                set
                {
                    double max = BarAngleMaximum;
                    Interop.Eext.eext_circle_object_angle_min_max_set(_handle, (double)value, max);
                }
            }

            /// <summary>
            /// Sets or gets the maximum angle of the circle slider bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double BarAngleMaximum
            {
                get
                {
                    double min;
                    double max;
                    Interop.Eext.eext_circle_object_angle_min_max_get(_handle, out min, out max);
                    return max;
                }
                set
                {
                    double min = BarAngleMinimum;
                    Interop.Eext.eext_circle_object_angle_min_max_set(_handle, min, (double)value);
                }
            }

            /// <summary>
            /// Sets or gets the radius value for the circle slider bar.
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
                    Interop.Eext.eext_circle_object_radius_set(_handle, (double)value);
                }
            }

            /// <summary>
            /// Sets or gets the radius value for the circle slider background.
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
