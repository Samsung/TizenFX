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
    /// The Circle Spinner is a widget to display and handle spinner value by rotary event
    /// Inherits <see cref="Spinner"/>.
    /// </summary>
    public class CircleSpinner : Spinner
    {
        private IntPtr _circleHandle;
        private double _angleRatio = 1.0;

        /// <summary>
        /// Creates and initializes a new instance of the Circle Spinner class.
        /// </summary>
        /// <param name="parent">The parent of new Circle Spinner instance</param>
        public CircleSpinner(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets the circle spinner angle per each spinner value.
        /// </summary>
        public double AngleRatio
        {
            get
            {
                return _angleRatio;
            }
            set
            {
                _angleRatio = value;
                Interop.Eext.eext_circle_object_spinner_angle_set(_circleHandle, _angleRatio);
            }
        }

        /// <summary>
        /// Sets or gets disabled state of the circle spinner object.
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
        /// Sets or gets the line width of the marker
        /// </summary>
        public int MarkerLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(_circleHandle, "default");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(_circleHandle, "default", value);
            }
        }

        /// <summary>
        /// Sets or gets the color of the marker
        /// </summary>
        public Color MarkerColor
        {
            get
            {
                int r, g, b, a;
                Interop.Eext.eext_circle_object_item_color_get(_circleHandle, "default", out r, out g, out b, out a);
                return new Color(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(_circleHandle, "default", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets the radius at which the center of the marker lies
        /// </summary>
        public double MarkerRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(_circleHandle, "default");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(_circleHandle, "default", value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = base.CreateHandle(parent);

            IntPtr surface = IntPtr.Zero;

            if (parent is Conformant)
            {
                surface = Interop.Eext.eext_circle_surface_conformant_add(parent.Handle);
            }
            else if (parent is Naviframe)
            {
                surface = Interop.Eext.eext_circle_surface_naviframe_add(parent.RealHandle);
            }
            else if (parent is Layout)
            {
                surface = Interop.Eext.eext_circle_surface_layout_add(parent.Handle);
            }

            _circleHandle = Interop.Eext.eext_circle_object_spinner_add(RealHandle, surface);
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