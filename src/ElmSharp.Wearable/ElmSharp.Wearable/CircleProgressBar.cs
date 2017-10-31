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
    /// The Circle ProgressBar is a widget for visually representing the progress status of a given job/task with the circular design.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CircleProgressBar : Widget, ICircleWidget
    {
        CircleSurface _surface;

        /// <summary>
        /// Creates and initializes a new instance of the Circle Progressbar class.
        /// </summary>
        /// <param name="parent">The parent of new Circle Progressbar instance</param>
        /// <param name="surface">The surface for drawing circle features for this widget.</param>
        /// <since_tizen> preview </since_tizen>
        public CircleProgressBar(EvasObject parent, CircleSurface surface) : base()
        {
            Debug.Assert(parent == null || surface == null || parent.IsRealized);
            _surface = surface;
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the Circle Progressbar class.
        /// </summary>
        /// <param name="parent">The parent of new Circle Progressbar instance</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("It is not safe for guess circle surface from parent and create new surface by every new widget")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircleProgressBar(EvasObject parent) : this(parent, CircleSurface.CreateCircleSurface(parent))
        {
        }

        /// <summary>
        /// Gets the handle for Circle Widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual IntPtr CircleHandle => Handle;

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
        /// Sets or gets the value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Value
        {
            get
            {
                return Interop.Eext.eext_circle_object_value_get(CircleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_value_set(CircleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the maximum value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Maximum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                return max;
            }
            set
            {
                double min = Minimum;
                Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, min, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Minimum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                return min;
            }
            set
            {
                double max = Maximum;
                Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, value, max);
            }
        }

        /// <summary>
        /// Sets or gets the angle value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BarAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_get(CircleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_set(CircleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle value of Background ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BackgroundAngle
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_get(CircleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_set(CircleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BarAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_angle_offset_get(CircleHandle);
            }
            set
            {
                Interop.Eext.eext_circle_object_angle_offset_set(CircleHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the angle offset value of Background ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BackgroundAngleOffset
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_angle_offset_get(CircleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_angle_offset_set(CircleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets the maximum angle value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BarAngleMaximum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                return max;
            }
            set
            {
                double min = BarAngleMinimum;
                Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, min, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum angle value of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BarAngleMinimum
        {
            get
            {
                double max = 0;
                double min = 0;
                Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                return min;
            }
            set
            {
                double max = BarAngleMaximum;
                Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, value, max);
            }
        }

        /// <summary>
        /// Sets or gets color of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color BarColor
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
        /// Sets or gets color of Background ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color BackgroundColor
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "bg", out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "bg", value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets line width of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int BarLineWidth
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
        /// Sets or gets line width of Background ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int BackgroundLineWidth
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "bg", value);
            }
        }

        /// <summary>
        /// Sets or gets radius of ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BarRadius
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
        /// Sets or gets radius of Background ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BackgroundRadius
        {
            get
            {
                return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "bg");
            }
            set
            {
                Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "bg", value);
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
            return Interop.Eext.eext_circle_object_progressbar_add(parent, CircleSurface.Handle);
        }
    }
}