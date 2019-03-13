using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleGenlistVerticalBar : CircleColorPart
            {
                public CircleGenlistVerticalBar(IntPtr CircleHandle) : base(CircleHandle) { }
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

            public class CircleGenlistVerticalBarBackground : CircleColorPart
            {
                public CircleGenlistVerticalBarBackground(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "vertical,scroll,bg", r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "vertical,scroll,bg", out r, out g, out b, out a);
                }
            }

            public class CircleGenlist : Efl.Ui.List, ICircleWidget
            {
                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                public CircleGenlistVerticalBar VerticalBar;
                public CircleGenlistVerticalBarBackground VerticalBarBackgournd;

                public CircleGenlist(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_genlist_add(this.NativeHandle, IntPtr.Zero);

                    VerticalBar = new CircleGenlistVerticalBar(_handle);
                    VerticalBarBackgournd = new CircleGenlistVerticalBarBackground(_handle);

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

                public int VerticalScrollBackgroundLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "vertical,scroll,bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "vertical,scroll,bg", value);
                    }
                }

                public double VerticalScrollBackgroundRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "vertical,scroll,bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "vertical,scroll,bg", value);
                    }
                }

                public int VerticalScrollBarLineWidth
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

                public double VerticalScrollBarRadius
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

                public ScrollbarMode VerticalScrollBarVisiblePolicy
                {
                    get
                    {
                        int policy;
                        Interop.Eext.eext_circle_object_genlist_scroller_policy_get(CircleHandle, IntPtr.Zero, out policy);
                        return (ScrollbarMode)policy;
                    }
                    set
                    {
                        int h;
                        Interop.Eext.eext_circle_object_genlist_scroller_policy_get(CircleHandle, out h, IntPtr.Zero);
                        Interop.Eext.eext_circle_object_genlist_scroller_policy_set(CircleHandle, (int)h, (int)value);
                    }
                }
            }
        }
    }
}
