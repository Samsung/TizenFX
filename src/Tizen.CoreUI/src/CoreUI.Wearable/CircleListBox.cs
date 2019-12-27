using System;
using System.Collections.Generic;
using System.Text;

namespace CoreUI
{
    namespace Wearable
    {
        /// <summary>
        /// The CircleListBox is a widget to display and handle the genlist items by the rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class CircleListBox : CoreUI.UI.ListBox, ICircleWidget
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
                    Interop.Eext.eext_circle_object_item_color_get(_handle, "default", out r, out g, out b, out a);
                    return (r, g, b, a);
                }
                set
                {
                    Interop.Eext.eext_circle_object_item_color_set(_handle, "default", value.r, value.g, value.b, value.a);
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
            /// Creates and initializes a new instance of the CircleListBox class.
            /// </summary>
            /// <param name="parent">The CoreUI.UI.Widget to which the new CircleListBox will be attached as a child.</param>
            /// <since_tizen> 6 </since_tizen>
            public CircleListBox(CoreUI.Object parent) : base(parent)
            {
                _handle = Interop.Eext.eext_circle_object_genlist_add(this.NativeHandle, IntPtr.Zero);
                elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", _handle);

                this.SetPositionManager(new PositionManager.CircleList());
                this.ScrollDestinationFinalized += (object sender, CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs e) =>
                {
                    CoreUI.DataTypes.Position2D vPos;
                    CoreUI.DataTypes.Rect iPos, view;
                    CoreUI.Wearable.CircleListBox list = sender as CircleListBox;
                    int ix, iy, iw, ih;

                    view = list.ViewportGeometry;
                    vPos = list.ContentPos;

                    int idx = ((PositionManager.CircleList) list.PositionManager).GetPositionedItem(new CoreUI.DataTypes.Position2D(e.Arg.X, (view.H / 2)));
                    iPos = list.PositionManager.PositionSingleItem(idx);
                    ix = iPos.X;
                    iy = iPos.Y + vPos.Y - view.Y - ((view.H - iPos.H) / 2);
                    iw = iPos.W;
                    ih = view.H;
                    list.Scroll(new CoreUI.DataTypes.Rect(ix, iy, iw, ih), true);
                };
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
            /// Sets or gets the line width of the scroll background.
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
            /// Sets or gets the radius of the scroll background.
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
            /// Sets or gets the line width of the scrollbar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public int VerticalScrollBarLineWidth
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
            /// Sets or gets the radius of the scrollbar.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public double VerticalScrollBarRadius
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
            /// Sets or gets the policy if the scrollbar is visible.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public UI.ScrollBarMode VerticalScrollBarVisiblePolicy
            {
                get
                {
                    int policy;
                    Interop.Eext.eext_circle_object_genlist_scroller_policy_get(_handle, IntPtr.Zero, out policy);
                    return (UI.ScrollBarMode)policy;
                }
                set
                {
                    int h;
                    Interop.Eext.eext_circle_object_genlist_scroller_policy_get(_handle, out h, IntPtr.Zero);
                    Interop.Eext.eext_circle_object_genlist_scroller_policy_set(_handle, (int)h, (int)value);
                }
            }
        }
    }
}
