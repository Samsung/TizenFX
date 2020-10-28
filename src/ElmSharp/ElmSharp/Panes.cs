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

namespace ElmSharp
{
    /// <summary>
    /// The Panes is a widget that adds a draggable bar between two contents.
    /// When dragged, this bar resizes the contents' size.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Panes : Layout
    {
        SmartEvent _press;
        SmartEvent _unpressed;

        /// <summary>
        /// Creates and initializes a new instance of the Panes class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Panes will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Panes(EvasObject parent) : base(parent)
        {
            _press = new SmartEvent(this, this.RealHandle, "press");
            _unpressed = new SmartEvent(this, this.RealHandle, "unpress");

            _press.On += (s, e) => Pressed?.Invoke(this, e);
            _unpressed.On += (s, e) => Unpressed?.Invoke(this, e);
        }

        /// <summary>
        /// Pressed will be triggered when the panes have been pressed (button isn't released yet).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Pressed;

        /// <summary>
        /// Unpressed will be triggered when the panes are released after being pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Unpressed;

        /// <summary>
        /// Sets or gets the resize mode of a given Panes widget.
        /// True means the left and right panes resize homogeneously.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsFixed
        {
            get
            {
                return Interop.Elementary.elm_panes_fixed_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_fixed_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the size proportion of the Panes widget's left side.
        /// </summary>
        /// <remarks>
        /// By default, it's homogeneous, i.e., both sides have the same size. If something different is required,
        /// it can be set with this function. For example, if the left content should be displayed over 75% of the panes size,
        /// the size should be passed as 0.75. This way, the right content is resized to 25% of the panes size.
        /// If displayed vertically, left content is displayed at the top and right content at the bottom.
        /// This proportion changes when the user drags the panes bar.
        ///
        /// The float type value between 0.0 and 1.0 represents the size proportion of the left side.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double Proportion
        {
            get
            {
                return Interop.Elementary.elm_panes_content_left_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_left_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the orientation of a given Panes widget.
        /// </summary>
        /// <remarks>
        /// Use this function to change how your panes are to be disposed: vertically or horizontally.
        /// Horizontal panes have "top" and "bottom" contents, vertical panes have "left" and "right" contents.
        /// By default, the panes are in a vertical mode.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_panes_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the absolute minimum size of panes widget's left side.
        /// If displayed vertically, left content is displayed at the top.
        /// The value represents minimum size of the left side in pixels.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int LeftMinimumSize
        {
            get
            {
                return Interop.Elementary.elm_panes_content_left_min_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_left_min_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the relative minimum size of the panes widget's left side.
        /// The proportion of minimum size of the left side.
        /// If displayed vertically, left content is displayed at the top.
        /// The value between 0.0 and 1.0 represents size proportion of the minimum size of the left side.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double LeftMinimumRelativeSize
        {
            get
            {
                return Interop.Elementary.elm_panes_content_left_min_relative_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_left_min_relative_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the absolute minimum size of the panes widget's right side.
        /// If displayed vertically, right content is displayed at the top.
        /// The value represents the minimum size of the right side in pixels.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int RightMinimumSize
        {
            get
            {
                return Interop.Elementary.elm_panes_content_right_min_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_right_min_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the relative minimum size of the panes widget's right side.
        /// Proportion of the minimum size of the right side.
        /// If displayed vertically, right content is displayed at the top.
        /// The value between 0.0 and 1.0 represents size proportion of the minimum size of the right side.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double RightMinimumRelativeSize
        {
            get
            {
                return Interop.Elementary.elm_panes_content_right_min_relative_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_right_min_relative_size_set(RealHandle, value);
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
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_panes_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}