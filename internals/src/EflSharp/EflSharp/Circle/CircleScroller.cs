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
            /// CircleScrollerVerticalBar is a part used to set the color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleScrollerVerticalBar : ICircleColor
            {
                IntPtr _handle;
                public CircleScrollerVerticalBar(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the color of the vertical bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_color_set(_handle, r, g, b, a);
                }

                /// <summary>
                /// Gets the color of the vertical bar on the circle scroller.
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
            /// CircleScrollerVerticalBarBackground is a part used to set the background color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleScrollerVerticalBarBackground : ICircleColor
            {
                IntPtr _handle;
                public CircleScrollerVerticalBarBackground(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the background color of the vertical bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "vertical,scroll,bg", r, g, b, a);
                }

                /// <summary>
                /// Gets the background color of the vertical bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "vertical,scroll,bg", out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// CircleScrollerHorizontalBar is a part used to set the color of the horizontal bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleScrollerHorizontalBar : ICircleColor
            {
                IntPtr _handle;
                public CircleScrollerHorizontalBar(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the color of the horizontal bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bar", r, g, b, a);
                }

                /// <summary>
                /// Gets the color of the horizontal bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bar", out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// CircleScrollerHorizontalBarBackground is a part used to set the background color of the horizontal bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleScrollerHorizontalBarBackground : ICircleColor
            {
                IntPtr _handle;
                public CircleScrollerHorizontalBarBackground(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the background color of the horizontal bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bg", r, g, b, a);
                }

                /// <summary>
                /// Gets the background color of the horizontal bar on the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bg", out r, out g, out b, out a);
                }
            }

            public class CircleScroller : Efl.Ui.Scroller, ICircleWidget
            {
                IntPtr _handle;

                /// <summary>
                /// Get the handle for the circle widget.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public virtual IntPtr CircleHandle => _handle;

                /// <summary>
                /// Sets or gets the color of the vertical bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleScrollerVerticalBar VerticalBar;

                /// <summary>
                /// Sets or gets the background color of the vertical bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleScrollerVerticalBarBackground VerticalBarBackground;

                /// <summary>
                /// Sets or gets the color of the horizontal bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleScrollerHorizontalBar HorizontalBar;

                /// <summary>
                /// Sets or gets the background color of the horizontal bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleScrollerHorizontalBarBackground HorizontalBarBackground;

                /// <summary>
                /// Creates and initializes a new instance of the CircleScroller class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new CircleScroller will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the disabled state of the circle scroller.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool Disable
                {
                    get => !Enable;
                    set => Enable = !value;
                }

                /// <summary>
                /// Sets or gets the enabled state of the circle scroller.
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
                /// Sets or gets the value of HorizontalScrollBarVisiblePolicy.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the value of VerticalScrollBarVisiblePolicy.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the line width of the vertical scroll bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the line width of the horizontal scroll bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the line width of the vertical scroll background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the line width of the horizontal scroll background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the radius of the vertical scroll bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the radius of the horizontal scroll bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the radius of the vertical scroll background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the radius of the horizontal scroll background.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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
