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
    /// The Circle ProgressBar is a widget for visually representing the progress status of a given job/task with the circular design.
    /// </summary>
    public class CircleProgressBar : EvasObject
    {
        private IntPtr _circleHandle;

        /// <summary>
        /// Creates and initializes a new instance of the Circle Progressbar class.
        /// </summary>
        /// <param name="parent">The parent of new Circle Progressbar instance</param>
        public CircleProgressBar(EvasObject parent) : base(parent)
        {
        }


        /// <summary>
        /// Sets or gets the value of ProgressBar.
        /// </summary>
        public double Value
        {
            get
            {
                return Interop.Eext.eext_circle_object_value_get(_circleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_value_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the maximum value of ProgressBar.
        /// </summary>
        public double Maximum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_value_min_max_get(_circleHandle, out min, out max);
                return max;
            }
            set
            {
                double min = Minimum;
                Interop.Eext.eext_circle_object_value_min_max_set(_circleHandle, min, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum value of ProgressBar.
        /// </summary>
        public double Minimum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_value_min_max_get(_circleHandle, out min, out max);
                return min;
            }
            set
            {
                double max = Maximum;
                Interop.Eext.eext_circle_object_value_min_max_set(_circleHandle, value, max);
            }
        }

        /// <summary>
        /// Sets or gets the angle value of ProgressBar.
        /// </summary>
        public double BarAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_get(_circleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle value of Background ProgressBar.
        /// </summary>
        public double BackgroundAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_get(_circleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_set(_circleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset value of ProgressBar.
        /// </summary>
        public double BarAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_offset_get(_circleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_offset_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset value of Background ProgressBar.
        /// </summary>
        public double BackgroundAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_offset_get(_circleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_offset_set(_circleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the maximum angle value of ProgressBar.
        /// </summary>
        public double BarAngleMaximum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_angle_min_max_get(_circleHandle, out min, out max);
                return max;
            }
            set
            {
                double min = BarAngleMinimum;
                Interop.Eext.eext_circle_object_angle_min_max_set(_circleHandle, min, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum angle value of ProgressBar.
        /// </summary>
        public double BarAngleMinimum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_angle_min_max_get(_circleHandle, out min, out max);
                return min;
            }
            set
            {
                double max = BarAngleMaximum;
                Interop.Eext.eext_circle_object_angle_min_max_set(_circleHandle, value, max);
            }
        }

        /// <summary>
        /// Sets or gets disable status of Circle ProgressBar.
        /// </summary>
        public bool Disabled
        {
            get
            {
                return Interop.Eext.eext_circle_object_disabled_get(_circleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_disabled_set(_circleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets color of ProgressBar.
        /// </summary>
        public Color BarColor
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
        /// Sets or gets color of Background ProgressBar.
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(_circleHandle, "bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(_circleHandle, "bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets line width of ProgressBar.
        /// </summary>
        public int BarLineWidth
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
        /// Sets or gets line width of Background ProgressBar.
        /// </summary>
        public int BackgroundLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(_circleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(_circleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets radius of ProgressBar.
        /// </summary>
        public double BarRadius
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
        /// Sets or gets radius of Background ProgressBar.
        /// </summary>
        public double BackgroundRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(_circleHandle, "bg"); ;
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(_circleHandle, "bg", value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr surface = IntPtr.Zero;

            if (parent is Conformant)
            {
                surface = Interop.Eext.eext_circle_surface_conformant_add(parent.Handle);
            }
            else if (parent is Layout)
            {
                surface = Interop.Eext.eext_circle_surface_layout_add(parent.Handle);
            }
            else if (parent is Naviframe)
            {
                surface = Interop.Eext.eext_circle_surface_naviframe_add(parent.RealHandle);
            }

            _circleHandle = Interop.Eext.eext_circle_object_progressbar_add(parent.Handle, surface);
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
            return parent.Handle;
        }
    }
}