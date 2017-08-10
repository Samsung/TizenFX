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
    /// Circle slider is circular designed widget to select a value in a range by rotary event.
    /// </summary>
    public class CircleSlider : EvasObject
    {
        public event EventHandler Changed;

        SmartEvent _changedEvent;

        /// <summary>
        /// Creates and initializes a new instance of the CircleSlider class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new CircleSlider will be attached as a child.</param>
        public CircleSlider(EvasObject parent) : base(parent)
        {
            _changedEvent = new SmartEvent(this, "value,changed");

            _changedEvent.On += (s, e) => Changed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets or gets the step by which the circle slider bar moves.
        /// </summary>
        /// <remarks>
        /// This value is used when circle slider value is changed by an drag or rotary event
        /// The value of the slider is increased/decreased by the step value.
        /// </remarks>
        public double Step
        {
            get
            {
                return Interop.Eext.eext_circle_object_slider_step_get(RealHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_slider_step_set(RealHandle, (double)value);
            }
        }

        /// <summary>
        /// Sets or gets disabled state of the circle slider object.
        /// </summary>
        public bool Disabled
        {
            get
            {
                return Interop.Eext.eext_circle_object_disabled_get(RealHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_disabled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets color of the circle slider bar.
        /// </summary>
        public Color BarColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_color_get(RealHandle, out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_color_set(RealHandle, value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets color of the circle slider background.
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(RealHandle, "bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(RealHandle, "bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets the line with of the circle slider bar.
        /// </summary>
        public int BarLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_line_width_get(RealHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_line_width_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the line with of the circle slider background.
        /// </summary>
        public int BackgroundLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(RealHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(RealHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the angle in degree of the circle slider bar.
        /// </summary>
        public double BarAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_get(RealHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle in degree of the circle slider background.
        /// </summary>
        public double BackgroundAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_get(RealHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_set(RealHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset for the slider bar.
        /// offset value means start position of the slider bar.
        /// </summary>
        public double BarAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_offset_get(RealHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_offset_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset for the circle slider background.
        /// offset value means start position of the slider background.
        /// </summary>
        public double BackgroundAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_offset_get(RealHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_offset_set(RealHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum angle of the circle slider bar.
        /// </summary>
        public double BarAngleMinimum
        {
            get
            {
                double min;
                double max;
                Interop.Eext.eext_circle_object_angle_min_max_get(RealHandle, out min, out max);
                return min;
            }
            set
            {
                double max = BarAngleMaximum;
                Interop.Eext.eext_circle_object_angle_min_max_set(RealHandle, (double)value, max);
            }
        }

        /// <summary>
        /// Sets or gets the maximum angle of the circle slider bar.
        /// </summary>
        public double BarAngleMaximum
        {
            get
            {
                double min;
                double max;
                Interop.Eext.eext_circle_object_angle_min_max_get(RealHandle, out min, out max);
                return max;
            }
            set
            {
                double min = BarAngleMinimum;
                Interop.Eext.eext_circle_object_angle_min_max_set(RealHandle, min, (double)value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum values for the circle slider.
        /// </summary>
        /// <remarks>
        /// This defines the allowed minimum values to be selected by the user.
        /// If the actual value is less than min, it is updated to min.
        /// Actual value can be obtained with Value.By default, min is equal to 0.0.
        /// </remarks>
        public double Minimum
        {
            get
            {
                double min;
                double max;
                Interop.Eext.eext_circle_object_value_min_max_get(RealHandle, out min, out max);
                return min;
            }
            set
            {
                double max = Maximum;
                Interop.Eext.eext_circle_object_value_min_max_set(RealHandle, (double)value, max);
            }
        }

        /// <summary>
        /// Sets or gets the maximum values for the circle slider.
        /// </summary>
        /// <remarks>
        /// This defines the allowed maximum values to be selected by the user.
        /// If the actual value is bigger then max, it is updated to max.
        /// Actual value can be obtained with Value.By default, min is equal to 0.0, and max is equal to 1.0.
        /// Maximum must be greater than minimum, otherwise the behavior is undefined.
        /// </remarks>
        public double Maximum
        {
            get
            {
                double min;
                double max;
                Interop.Eext.eext_circle_object_value_min_max_get(RealHandle, out min, out max);
                return max;
            }
            set
            {
                double min = Minimum;
                Interop.Eext.eext_circle_object_value_min_max_set(RealHandle, min, (double)value);
            }
        }

        /// <summary>
        /// Gets or sets the value displayed by the circle slider.
        /// </summary>
        /// <remarks>
        /// The value must to be between Minimum and Maximum values.
        /// </remarks>
        public double Value
        {
            get
            {
                return Interop.Eext.eext_circle_object_value_get(RealHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_value_set(RealHandle, (double)value);
            }
        }

        /// <summary>
        /// Gets or sets the radius value for the circle slider bar.
        /// </summary>
        public double BarRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_radius_get(RealHandle); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_radius_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius value for the circle slider background.
        /// </summary>
        public double BackgroundRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(RealHandle, "bg"); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(RealHandle, "bg", value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
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

            IntPtr handle = Interop.Eext.eext_circle_object_slider_add(parent, surface);
            if (surface == IntPtr.Zero)
            {
                EvasObject p = parent;
                while (!(p is Window))
                {
                    p = p.Parent;
                }
                var w = (p as Window).ScreenSize.Width;
                var h = (p as Window).ScreenSize.Height;
                Interop.Evas.evas_object_resize(handle, w, h);
            }

            Interop.Eext.eext_rotary_object_event_activated_set(handle, true);
            return handle;
        }
    }
}