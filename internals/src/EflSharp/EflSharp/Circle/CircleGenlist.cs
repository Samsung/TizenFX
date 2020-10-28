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
            /// CircleGenlistVerticalBar is a part used to set the color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleGenlistVerticalBar : ICircleColor
            {
                IntPtr _handle;
                public CircleGenlistVerticalBar(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the color of the vertical bar on the circle genlist.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "default", r, g, b, a);
                }

                /// <summary>
                /// Gets the color of the vertical bar on the circle genlist.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void GetColor(out int r, out int g, out int b, out int a)
                {
                    r = g = b = a = -1;
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_get(_handle, "default", out r, out g, out b, out a);
                }
            }

            /// <summary>
            /// CircleGenlistVerticalBarBackground is a part used to set the background color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleGenlistVerticalBarBackground : ICircleColor
            {
                IntPtr _handle;
                public CircleGenlistVerticalBarBackground(IntPtr CircleHandle) { _handle = CircleHandle; }

                /// <summary>
                /// Sets the background color of the vertial bar on the circle genlist.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void SetColor(int r, int g, int b, int a)
                {
                    if (_handle != null)
                        Interop.Eext.eext_circle_object_item_color_set(_handle, "vertical,scroll,bg", r, g, b, a);
                }

                /// <summary>
                /// Gets the background color of the vertial bar on the circle genlist.
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
            /// The CircleGenList is a widget to display and handle the genlist items by the rotary event.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleGenlist : Efl.Ui.List, ICircleWidget
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
                public CircleGenlistVerticalBar VerticalBar;

                /// <summary>
                /// Sets or gets the background color of the vertical bar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public CircleGenlistVerticalBarBackground VerticalBarBackgournd;

                /// <summary>
                /// Creates and initializes a new instance of the CircleGenlist class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new CircleGenlist will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public CircleGenlist(Efl.Ui.Widget parent) : base(parent)
                {
                    _handle = Interop.Eext.eext_circle_object_genlist_add(this.NativeHandle, IntPtr.Zero);

                    VerticalBar = new CircleGenlistVerticalBar(_handle);
                    VerticalBarBackgournd = new CircleGenlistVerticalBarBackground(_handle);

                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                /// <summary>
                /// Sets or gets the disabled state of the circle genlist.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool Disable
                {
                    get => !Enable;
                    set => Enable = !value;
                }

                /// <summary>
                /// Sets or gets the enabled state of the circle genlist.
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
                /// Sets or gets the line width of the scroll background.
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
                /// Sets or gets the radius of the scroll background.
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
                /// Sets or gets the line width of the scrollbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the radius of the scrollbar.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the policy if the scrollbar is visible.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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
