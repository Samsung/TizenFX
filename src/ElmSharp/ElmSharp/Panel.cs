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
    public enum PanelDirection
    {
        /// <summary>
        /// Top to bottom
        /// </summary>
        Top = 0,
        /// <summary>
        /// Bottom to top
        /// </summary>
        Bottom,
        /// <summary>
        /// Left to right
        /// </summary>
        Left,
        /// <summary>
        /// Right to left
        /// </summary>
        Right,
    }

    public class Panel : Layout
    {
        SmartEvent _toggled;
        public Panel(EvasObject parent) : base(parent)
        {
            _toggled = new SmartEvent(this, this.RealHandle, "toggled");
            _toggled.On += (s, e) => Toggled?.Invoke(this, EventArgs.Empty);
        }

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

        public event EventHandler Toggled;

        public void SetScrollable(bool enable)
        {
            Interop.Elementary.elm_panel_scrollable_set(RealHandle, enable);
        }

        public void SetScrollableArea(double ratio)
        {
            Interop.Elementary.elm_panel_scrollable_content_size_set(RealHandle, ratio);
        }

        public void Toggle()
        {
            Interop.Elementary.elm_panel_toggle(RealHandle);
        }
        
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_panel_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
