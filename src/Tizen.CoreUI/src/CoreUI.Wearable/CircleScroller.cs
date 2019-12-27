using System;
using System.Collections.Generic;
using System.Text;

namespace CoreUI
{
    namespace Wearable
    {
        /// <since_tizen> 6 </since_tizen>
        public class CircleScroller : CoreUI.UI.Scroller, ICircleWidget
        {
            IntPtr _handle;

            IntPtr ICircleWidget.CircleHandle => _handle;

            /// <summary>
            /// Sets or gets the color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) VerticalScrollBarColor
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
            /// Sets or gets the background color of the vertical bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) VerticalScrollBackgroundColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "vertical,scroll,bg", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "vertical,scroll,bg", value.r, value.g, value.b, value.a);
                }
            }

            /// <summary>
            /// Sets or gets the color of the horizontal bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) HorizontalScrollBarColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bar", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bar", value.r, value.g, value.b, value.a);
                }
            }

            /// <summary>
            /// Sets or gets the background color of the horizontal bar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public (int r, int b, int g, int a) HorizontalScrollBackgroundColor
            {
                get
                {
                    int r, g, b, a;
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "horizontal,scroll,bg", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "horizontal,scroll,bg", value.r, value.g, value.b, value.a);
                }
            }

            /// <summary>
            /// Creates and initializes a new instance of the CircleScroller class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleScroller will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleScroller(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_scroller_add(this.NativeHandle, IntPtr.Zero);
                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);
            }

            [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)]
            internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

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
            /// Sets or gets the value of HorizontalScrollBarVisiblePolicy.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public UI.ScrollBarMode HorizontalScrollBarVisiblePolicy
            {
                get
                {
                    int policy;
                    Interop.Eext.eext_circle_object_scroller_policy_get(_handle, out policy, IntPtr.Zero);
                    return (UI.ScrollBarMode)policy;
                }
                set
                {
                    UI.ScrollBarMode v = VerticalScrollBarVisiblePolicy;
                    Interop.Eext.eext_circle_object_scroller_policy_set(_handle, (int)value, (int)v);
                }
            }

            /// <summary>
            /// Sets or gets the value of VerticalScrollBarVisiblePolicy.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public UI.ScrollBarMode VerticalScrollBarVisiblePolicy
            {
                get
                {
                    int policy;
                    Interop.Eext.eext_circle_object_scroller_policy_get(_handle, IntPtr.Zero, out policy);
                    return (UI.ScrollBarMode)policy;
                }
                set
                {
                    UI.ScrollBarMode h = HorizontalScrollBarVisiblePolicy;
                    Interop.Eext.eext_circle_object_scroller_policy_set(_handle, (int)h, (int)value);
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
                    return Interop.Eext.eext_circle_object_line_width_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_line_width_set(_handle, value);
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
                    return Interop.Eext.eext_circle_object_item_line_width_get(_handle, "horizontal,scroll,bar");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_line_width_set(_handle, "horizontal,scroll,bar", value);
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
                    return Interop.Eext.eext_circle_object_item_line_width_get(_handle, "vertical,scroll,bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_line_width_set(_handle, "vertical,scroll,bg", value);
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
                    return Interop.Eext.eext_circle_object_item_line_width_get(_handle, "horizontal,scroll,bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_line_width_set(_handle, "horizontal,scroll,bg", value);
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
                    return Interop.Eext.eext_circle_object_radius_get(_handle);
                }
                set
                {
                    Interop.Eext.eext_circle_object_radius_set(_handle, value);
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
                    return Interop.Eext.eext_circle_object_item_radius_get(_handle, "horizontal,scroll,bar");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_radius_set(_handle, "horizontal,scroll,bar", value);
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
                    return Interop.Eext.eext_circle_object_item_radius_get(_handle, "vertical,scroll,bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_radius_set(_handle, "vertical,scroll,bg", value);
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
                    return Interop.Eext.eext_circle_object_item_radius_get(_handle, "horizontal,scroll,bg");
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_radius_set(_handle, "horizontal,scroll,bg", value);
                }
            }
        }
    }
}