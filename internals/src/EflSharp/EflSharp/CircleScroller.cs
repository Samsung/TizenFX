using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleScrollerVerticalBar : CircleColorPart
            {
                public CircleScrollerVerticalBar(IntPtr CircleHandle) : base(CircleHandle) { }
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

            public class CircleScrollerVerticalBarBackground : CircleColorPart
            {
                public CircleScrollerVerticalBarBackground(IntPtr CircleHandle) : base(CircleHandle) { }
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

            public class CircleScrollerHorizontalBar : CircleColorPart
            {
                public CircleScrollerHorizontalBar(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bar", r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bar", out r, out g, out b, out a);
                }
            }

            public class CircleScrollerHorizontalBarBackground : CircleColorPart
            {
                public CircleScrollerHorizontalBarBackground(IntPtr CircleHandle) : base(CircleHandle) { }
                public override void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bg", r, g, b, a);
                }

                public override void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bg", out r, out g, out b, out a);
                }
            }

            public class CircleScroller : Efl.Ui.Scroller, ICircleWidget
            {
                IntPtr _handle;
                public virtual IntPtr CircleHandle => _handle;

                public CircleScrollerVerticalBar VerticalBar;
                public CircleScrollerVerticalBarBackground VerticalBarBackground;
                public CircleScrollerHorizontalBar HorizontalBar;
                public CircleScrollerHorizontalBarBackground HorizontalBarBackground;

                public CircleScroller(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_scroller_add(this.NativeHandle, IntPtr.Zero);

                    VerticalBar = new CircleScrollerVerticalBar(_handle);
                    VerticalBarBackground = new CircleScrollerVerticalBarBackground(_handle);
                    HorizontalBar = new CircleScrollerHorizontalBar(_handle);
                    HorizontalBarBackground = new CircleScrollerHorizontalBarBackground(_handle);

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

                public ScrollbarMode HorizontalScrollBarVisiblePolicy
                {
                    get
                    {
                        int policy;
                        Interop.Eext.eext_circle_object_scroller_policy_get(CircleHandle, out policy, IntPtr.Zero);
                        return (ScrollbarMode)policy;
                    }
                    set
                    {
                        ScrollbarMode v = VerticalScrollBarVisiblePolicy;
                        Interop.Eext.eext_circle_object_scroller_policy_set(CircleHandle, (int)value, (int)v);
                    }
                }

                public ScrollbarMode VerticalScrollBarVisiblePolicy
                {
                    get
                    {
                        int policy;
                        Interop.Eext.eext_circle_object_scroller_policy_get(CircleHandle, IntPtr.Zero, out policy);
                        return (ScrollbarMode)policy;
                    }
                    set
                    {
                        ScrollbarMode h = HorizontalScrollBarVisiblePolicy;
                        Interop.Eext.eext_circle_object_scroller_policy_set(CircleHandle, (int)h, (int)value);
                    }
                }

                public int VerticalScrollBarLineWidth
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

                public int HorizontalScrollBarLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "horizontal,scroll,bar");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "horizontal,scroll,bar", value);
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

                public int HorizontalScrollBackgroundLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "horizontal,scroll,bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "horizontal,scroll,bg", value);
                    }
                }

                public double VerticalScrollBarRadius
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

                public double HorizontalScrollBarRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "horizontal,scroll,bar");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "horizontal,scroll,bar", value);
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

                public double HorizontalScrollBackgroundRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "horizontal,scroll,bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "horizontal,scroll,bg", value);
                    }
                }
            }
        }
    }
}
