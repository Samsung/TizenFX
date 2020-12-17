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
    /// The Circle DateTime Selector is a widget to display and handle datetime value by the Rotary event.
    /// Inherits <see cref="DateTimeSelector"/>.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CircleDateTimeSelector : DateTimeSelector, IRotaryActionWidget
    {
        IntPtr _circleHandle;
        CircleSurface _surface;

        /// <summary>
        /// Creates and initializes a new instance of the Circle DateTime class.
        /// </summary>
        /// <param name="parent">The parent of the new Circle DateTime instance.</param>
        /// <param name="surface">The surface for drawing circle features for this widget.</param>
        /// <since_tizen> preview </since_tizen>
        public CircleDateTimeSelector(EvasObject parent, CircleSurface surface) : base()
        {
            Debug.Assert(parent == null || surface == null || parent.IsRealized);
            _surface = surface;
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the Circle DateTimeSelector class.
        /// </summary>
        /// <param name="parent">The parent of the new Circle DateTimeSelector instance.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("It is not safe for guess circle surface from parent and create new surface by every new widget")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircleDateTimeSelector(EvasObject parent) : this(parent, CircleSurface.CreateCircleSurface(parent))
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
        /// Sets or gets the color of the marker.
        /// </summary>
        /// <remarks>
        /// MarkerColor is not supported on device or emulator which does not support marker in CircleDatetimeSelector and CircleSpinner.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("MarkerColor is obsolete as of version 6.0.0 and is no longer supported")]
        public Color MarkerColor
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
        /// Sets or gets the line width of the marker.
        /// </summary>
        /// <remarks>
        /// MarkerLineWidth is not supported on device or emulator which does not support marker in CircleDatetimeSelector and CircleSpinner.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("MarkerLineWidth is obsolete as of version 6.0.0 and is no longer supported")]
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

        /// <summary>
        /// Sets or gets the radius at which the center of the marker lies.
        /// </summary>
        /// <remarks>
        /// MarkerRadius is not supported on device or emulator which does not support marker in CircleDatetimeSelector and CircleSpinner.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("MarkerRadius is obsolete as of version 6.0.0 and is no longer supported")]
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

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            var handle = base.CreateHandle(parent);

            _circleHandle = Interop.Eext.eext_circle_object_datetime_add(RealHandle == IntPtr.Zero ? handle : RealHandle , CircleSurface.Handle);

            return handle;
        }
    }
}