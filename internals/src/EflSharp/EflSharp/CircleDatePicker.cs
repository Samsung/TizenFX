using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleDatePickerMarker : CircleColorPart
            {
                public CircleDatePickerMarker(IntPtr CircleHandle) : base(CircleHandle) { }
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

            public class CircleDatePicker : Efl.Ui.Datepicker, ICircleWidget
            {
                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                public CircleDatePickerMarker Marker;

                public CircleDatePicker(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_datetime_add(this.NativeHandle, IntPtr.Zero);
                    Marker = new CircleDatePickerMarker(_handle);
                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

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
