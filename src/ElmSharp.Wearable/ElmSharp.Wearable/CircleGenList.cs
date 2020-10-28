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
    /// The Circle GenList Selector is a widget to display and handle the genlist items by the Rotary event.
    /// Inherits <see cref="GenList"/>.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CircleGenList : GenList, IRotaryActionWidget
    {
        IntPtr _circleHandle;
        CircleSurface _surface;

        /// <summary>
        /// Creates and initializes a new instance of the Circle GenList class.
        /// </summary>
        /// <param name="parent">The parent of the new Circle GenList instance.</param>
        /// <param name="surface">The surface for drawing the circle features for this widget.</param>
        /// <since_tizen> preview </since_tizen>
        public CircleGenList(EvasObject parent, CircleSurface surface) : base()
        {
            Debug.Assert(parent == null || surface == null || parent.IsRealized);
            _surface = surface;
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the Circle GenList class.
        /// </summary>
        /// <param name="parent">The parent of the new Circle CircleGenList instance.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("It is not safe for guess circle surface from parent and create new surface by every new widget")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircleGenList(EvasObject parent) : this(parent, CircleSurface.CreateCircleSurface(parent))
        {
            ((IRotaryActionWidget)this).Activate();
        }

        /// <summary>
        /// Gets the handle for the Circle widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual IntPtr CircleHandle => _circleHandle;

        /// <summary>
        /// Gets the handle for the circle surface used in this widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual CircleSurface CircleSurface => _surface;

        /// <summary>
        /// Sets or gets the disabled state of this widget.
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
        /// Sets or gets the color of the scroll background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color VerticalScrollBackgroundColor
        {
            get
            {
                int r, g, b, a;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "vertical,scroll,bg", out r, out g, out b, out a);
                return new Color(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "vertical,scroll,bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets the line width of the scroll background.
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
        /// Sets or gets the radius of the scroll background.
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
        /// Sets or gets the color of the scrollbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color VerticalScrollBarColor
        {
            get
            {
                int r, g, b, a;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "default", out r, out g, out b, out a);
                return new Color(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "default", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets the line width of the scrollbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, or otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public new ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Eext.eext_circle_object_genlist_scroller_policy_get(CircleHandle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                int h;
                Interop.Eext.eext_circle_object_genlist_scroller_policy_get(CircleHandle, out h, IntPtr.Zero);
                Interop.Eext.eext_circle_object_genlist_scroller_policy_set(CircleHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            var handle = base.CreateHandle(parent);
            _circleHandle = Interop.Eext.eext_circle_object_genlist_add(RealHandle == IntPtr.Zero ? handle : RealHandle, CircleSurface.Handle);

            return handle;
        }
    }
}
