/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// Circle scroller provides scrollbar with circular movement and is scrolled by rotary event.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CircleScroller : Scroller, IRotaryActionWidget
    {
        IntPtr _circleHandle;
        CircleSurface _surface;

        /// <summary>
        /// Creates and initializes a new instance of the CircleScroller class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new CircleScroller will be attached as a child.</param>
        /// <param name="surface">The surface for drawing circle features for this widget.</param>
        /// <since_tizen> preview </since_tizen>
        public CircleScroller(EvasObject parent, CircleSurface surface) : base()
        {
            Debug.Assert(parent == null || surface == null || parent.IsRealized);
            _surface = surface;
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the Circle Scroller class.
        /// </summary>
        /// <param name="parent">The parent of new Circle CircleScroller instance</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("It is not safe for guess circle surface from parent and create new surface by every new widget")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircleScroller(EvasObject parent) : this(parent, CircleSurface.CreateCircleSurface(parent))
        {
            ((IRotaryActionWidget)this).Activate();
        }

        /// <summary>
        /// Gets the handle for Circle Widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual IntPtr CircleHandle => _circleHandle;

        /// <summary>
        /// Gets the handle for Circle Surface used in this widget
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual CircleSurface CircleSurface => _surface;

        /// <summary>
        /// Sets or gets disabled state of this widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("Use IsEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Disabled
        {
            get => !IsEnabled;
            set => IsEnabled = !value;
        }

        /// <summary>
        /// Sets or gets the state of the widget, which might be enabled or disabled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override bool IsEnabled
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
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public override ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Eext.eext_circle_object_scroller_policy_get(CircleHandle, out policy, IntPtr.Zero);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy v = VerticalScrollBarVisiblePolicy;
                Interop.Eext.eext_circle_object_scroller_policy_set(CircleHandle, (int)value, (int)v);
            }
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public override ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Eext.eext_circle_object_scroller_policy_get(CircleHandle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Eext.eext_circle_object_scroller_policy_set(CircleHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets color of the vertical scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color VerticalScrollBarColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_color_get(CircleHandle, out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_color_set(CircleHandle, value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the horizontal scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color HorizontalScrollBarColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "horizontal,scroll,bar", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "horizontal,scroll,bar", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the vertical scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color VerticalScrollBackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "vertical,scroll,bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "vertical,scroll,bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the horizontal scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color HorizontalScrollBackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "horizontal,scroll,bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "horizontal,scroll,bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets line width of the vertical scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets line width of the horizontal scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets line width of the vertical scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets line width of the horizontal scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets radius of the vertical scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets radius of the horizontal scroll bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets radius of the vertical scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets radius of the horizontal scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = base.CreateHandle(parent);
            _circleHandle = Interop.Eext.eext_circle_object_scroller_add(RealHandle == IntPtr.Zero ? handle : RealHandle, CircleSurface.Handle);
            return handle;
        }
    }
}