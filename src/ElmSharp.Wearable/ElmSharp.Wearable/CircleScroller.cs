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

namespace ElmSharp.Wearable
{
    /// <summary>
    /// Circle scroller provides scrollbar with circular movement and is scrolled by rotary event.
    /// </summary>
    public class CircleScroller : Scroller
    {
        private IntPtr _circleHandle;

        /// <summary>
        /// Creates and initializes a new instance of the CircleScroller class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new CircleScroller will be attached as a child.</param>
        public CircleScroller(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets disabled state of the circle scroller object.
        /// </summary>
        public bool Disabled
        {
            get
            {
                return Interop.Eext.eext_circle_object_disabled_get(_circleHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_disabled_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public override ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Eext.eext_circle_object_scroller_policy_get(_circleHandle, out policy, IntPtr.Zero);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy v = VerticalScrollBarVisiblePolicy;
                Interop.Eext.eext_circle_object_scroller_policy_set(_circleHandle, (int)value, (int)v);
            }
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public override ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Eext.eext_circle_object_scroller_policy_get(_circleHandle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Eext.eext_circle_object_scroller_policy_set(_circleHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets color of the vertical scroll bar.
        /// </summary>
        public Color VerticalScrollBarColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_color_get(_circleHandle, out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_color_set(_circleHandle, value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the horizontal scroll bar.
        /// </summary>
        public Color HorizontalScrollBarColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(_circleHandle, "horizontal,scroll,bar", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(_circleHandle, "horizontal,scroll,bar", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the vertical scroll background.
        /// </summary>
        public Color VerticalScrollBackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(_circleHandle, "vertical,scroll,bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(_circleHandle, "vertical,scroll,bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the horizontal scroll background.
        /// </summary>
        public Color HorizontalScrollBackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(_circleHandle, "horizontal,scroll,bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(_circleHandle, "horizontal,scroll,bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets line width of the vertical scroll bar.
        /// </summary>
        public int VerticalScrollBarLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_line_width_get(_circleHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_line_width_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets line width of the horizontal scroll bar.
        /// </summary>
        public int HorizontalScrollBarLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(_circleHandle, "horizontal,scroll,bar");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(_circleHandle, "horizontal,scroll,bar", value);
            }
        }

        /// <summary>
        /// Sets or gets line width of the vertical scroll background.
        /// </summary>
        public int VerticalScrollBackgroundLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(_circleHandle, "vertical,scroll,bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(_circleHandle, "vertical,scroll,bg", value);
            }
        }

        /// <summary>
        /// Sets or gets line width of the horizontal scroll background.
        /// </summary>
        public int HorizontalScrollBackgroundLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(_circleHandle, "horizontal,scroll,bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(_circleHandle, "horizontal,scroll,bg", value);
            }
        }

        /// <summary>
        /// Sets or gets radius of the vertical scroll bar.
        /// </summary>
        public double VerticalScrollBarRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_radius_get(_circleHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_radius_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets radius of the horizontal scroll bar.
        /// </summary>
        public double HorizontalScrollBarRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(_circleHandle, "horizontal,scroll,bar"); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(_circleHandle, "horizontal,scroll,bar", value);
            }
        }

        /// <summary>
        /// Sets or gets radius of the vertical scroll background.
        /// </summary>
        public double VerticalScrollBackgroundRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(_circleHandle, "vertical,scroll,bg"); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(_circleHandle, "vertical,scroll,bg", value);
            }
        }

        /// <summary>
        /// Sets or gets radius of the horizontal scroll background.
        /// </summary>
        public double HorizontalScrollBackgroundRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(_circleHandle, "horizontal,scroll,bg"); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(_circleHandle, "horizontal,scroll,bg", value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = base.CreateHandle(parent);
            IntPtr surface = IntPtr.Zero;
            if (parent is Conformant)
            {
                surface = Interop.Eext.eext_circle_surface_conformant_add(parent);
            }
            else if (parent is Layout)
            {
                surface = Interop.Eext.eext_circle_surface_layout_add(parent);
            }
            else if (parent is Naviframe)
            {
                surface = Interop.Eext.eext_circle_surface_naviframe_add(parent.RealHandle);
            }

            _circleHandle = Interop.Eext.eext_circle_object_scroller_add(RealHandle, surface);
            if (surface == IntPtr.Zero)
            {
                EvasObject p = parent;
                while (!(p is Window))
                {
                    p = p.Parent;
                }
                var w = (p as Window).ScreenSize.Width;
                var h = (p as Window).ScreenSize.Height;
                Interop.Evas.evas_object_resize(_circleHandle, w, h);
            }
            Interop.Eext.eext_rotary_object_event_activated_set(_circleHandle, true);
            return handle;
        }
    }
}