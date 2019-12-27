using System;
using System.Collections.Generic;
using System.Text;

namespace CoreUI
{
    namespace Wearable
    {
        /// <summary>
        /// The CircleSpinner is a widget to display and handle the spinner value by the rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class CircleSpinner : CoreUI.UI.Spin, CoreUI.UI.IRangeInteractive, ICircleWidget
        {
            double _angleRatio = -1.0;
            double _step = 1.0;

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
            /// Called when the widget&apos;s value has changed and has remained unchanged for 0.2s.
            /// This allows filtering out unwanted &quot;noise&quot; from the widget if you are only interested in its final position.
            /// Use this event instead of <see cref="CoreUI.UI.IRangeDisplay.Changed"/>
            /// if you are going to perform a costly operation on its handler.</summary>
            /// <since_tizen> 6 </since_tizen>
            public event EventHandler Steady;

            /// <summary>
            /// Creates and initializes a new instance of the CircleSpinner class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleSpinner will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleSpinner(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_spinner_add(this.NativeHandle, IntPtr.Zero);
                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);

                this.Changed += (object sender, EventArgs e) => {
                    CoreUI.LoopTimer timer = new CoreUI.LoopTimer(this, 0.2);
                    timer.TimerTick +=(object timer_sender, EventArgs timer_e) =>
                    {
                        Steady?.Invoke(this, EventArgs.Empty);
                        timer.Del();
                    };
                };
            }

            [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)]
            internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

            /// <summary>
            /// Sets or gets the circle spinner angle per each spinner value.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double AnglePerValue
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

                        Interop.Eext.eext_circle_object_spinner_angle_set(_handle, _angleRatio);
                    }
                }
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
                return _step;
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
                _step = step;
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
        }
    }
}
