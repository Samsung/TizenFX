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
    /// Enumeration for the PanelDirection types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum PanelDirection
    {
        /// <summary>
        /// Top to bottom.
        /// </summary>
        Top = 0,
        /// <summary>
        /// Bottom to top.
        /// </summary>
        Bottom,
        /// <summary>
        /// Left to right.
        /// </summary>
        Left,
        /// <summary>
        /// Right to left.
        /// </summary>
        Right,
    }

    /// <summary>
    /// The Panel is a container that can contain subobjects.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Panel : Layout
    {
        SmartEvent _toggled;

        /// <summary>
        /// Creates and initializes a new instance of the Panel class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new panel will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Panel(EvasObject parent) : base(parent)
        {
            _toggled = new SmartEvent(this, this.RealHandle, "toggled");
            _toggled.On += (s, e) => Toggled?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets or gets the hidden status of a given Panel widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsOpen
        {
            get
            {
                return !Interop.Elementary.elm_panel_hidden_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panel_hidden_set(RealHandle, !value);
            }
        }

        /// <summary>
        /// Sets or gets the direction of a given Panel widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public PanelDirection Direction
        {
            get
            {
                return (PanelDirection)Interop.Elementary.elm_panel_orient_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panel_orient_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Toggled will be triggered when the panel is toggled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Toggled;

        /// <summary>
        /// Enable or disable scrolling in the panel.
        /// </summary>
        /// <param name="enable">
        /// Bool value can be false or true.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public void SetScrollable(bool enable)
        {
            Interop.Elementary.elm_panel_scrollable_set(RealHandle, enable);
        }

        /// <summary>
        /// Sets the scroll size of the panel.
        /// </summary>
        /// <param name="ratio">
        /// The size of the scroll area.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public void SetScrollableArea(double ratio)
        {
            Interop.Elementary.elm_panel_scrollable_content_size_set(RealHandle, ratio);
        }

        /// <summary>
        /// Toggles the hidden state of the panel.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Toggle()
        {
            Interop.Elementary.elm_panel_toggle(RealHandle);
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

            RealHandle = Interop.Elementary.elm_panel_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
