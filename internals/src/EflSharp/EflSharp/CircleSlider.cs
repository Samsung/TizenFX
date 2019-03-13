using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleSliderBar : CircleColorPart
            {
                public CircleSliderBar(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_color_set(_handle, r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_color_get(_handle, out r, out g, out b, out a);
                }
            }

            public class CircleSliderBarBackground : CircleColorPart
            {
                public CircleSliderBarBackground(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "bg", r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "bg", out r, out g, out b, out a);
                }
            }

            public class CircleSlider : Efl.Ui.Layout, ICircleWidget
            {
                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                public event EventHandler Changed;
                const string ChangedEventName = "value,changed";

                public CircleSliderBar Bar;
                public CircleSliderBarBackground BarBackground;

                public CircleSlider(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_slider_add(parent.NativeHandle, IntPtr.Zero);

                    Bar = new Efl.Ui.Wearable.CircleSliderBar(_handle);
                    BarBackground = new Efl.Ui.Wearable.CircleSliderBarBackground(_handle);

                    Interop.Evas.SmartCallback _smartChanged = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        Changed?.Invoke(this, EventArgs.Empty);
                    });

                    Interop.Evas.evas_object_smart_callback_add(_handle, ChangedEventName, _smartChanged, IntPtr.Zero);

                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                public override Efl.Object FinalizeAdd()
                {
                    this.SetTheme("circle_slider", null, null);
                    return this;
                }

                public double Step
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_slider_step_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_slider_step_set(CircleHandle, (double)value);
                    }
                }

                public bool Disable
                {
                    get => !Enable;
                    set => Enable = !value;
                }

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

                public double BarAngleMinimum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = BarAngleMaximum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, (double)value, max);
                    }
                }

                public double BarAngleMaximum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = BarAngleMinimum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, min, (double)value);
                    }
                }

                public double Minimum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = Maximum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, (double)value, max);
                    }
                }

                public double Maximum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = Minimum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, min, (double)value);
                    }
                }

                public double Value
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_value_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_value_set(CircleHandle, (double)value);
                    }
                }

                public double BarRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_radius_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_radius_set(CircleHandle, (double)value);
                    }
                }

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
