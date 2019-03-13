using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleSpinnerMarker : CircleColorPart
            {
                public CircleSpinnerMarker(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "default", r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "default", out r, out g, out b, out a);
                }
            }

            public class CircleSpinner : Efl.Ui.Spin, ICircleWidget
            {
                double _angleRatio = -1.0;

                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                public CircleSpinnerMarker Marker;

                public CircleSpinner(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_spinner_add(this.NativeHandle, IntPtr.Zero);

                    Marker = new CircleSpinnerMarker(_handle);

                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                public double AngleRatio
                {
                    get
                    {
                        if (_angleRatio <= 0)
                        {
                            double Minimum, Maximum;

                            GetRangeMinMax(out Minimum, out Maximum);
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
