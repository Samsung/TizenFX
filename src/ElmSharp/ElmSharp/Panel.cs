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
        Interop.SmartEvent _toggled;
        public Panel(EvasObject parent) : base(parent)
        {
            _toggled = new Interop.SmartEvent(this, Handle, "toggled");
            _toggled.On += (s, e) => Toggled?.Invoke(this, EventArgs.Empty);
        }

        public bool IsOpen
        {
            get
            {
                return !Interop.Elementary.elm_panel_hidden_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panel_hidden_set(Handle, !value);
            }
        }

        public PanelDirection Direction
        {
            get
            {
                return (PanelDirection)Interop.Elementary.elm_panel_orient_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panel_orient_set(Handle, (int)value);
            }
        }

        public event EventHandler Toggled;

        public void SetScrollable(bool enable)
        {
            Interop.Elementary.elm_panel_scrollable_set(Handle, enable);
        }

        public void SetScrollableArea(double ratio)
        {
            Interop.Elementary.elm_panel_scrollable_content_size_set(Handle, ratio);
        }

        public void Toggle()
        {
            Interop.Elementary.elm_panel_toggle(Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_panel_add(parent);
        }
    }
}
