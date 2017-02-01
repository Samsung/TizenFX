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
    public class FloatingButton : Layout
    {
        SmartEvent _clicked;

        public FloatingButton(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, Handle, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Clicked;

        public FloatingButtonMode Mode
        {
            get
            {
                return (FloatingButtonMode)Interop.Eext.eext_floatingbutton_mode_get(Handle);
            }
            set
            {
                Interop.Eext.eext_floatingbutton_mode_set(Handle, (int)value);
            }
        }

        public FloatingButtonPosition Position
        {
            get
            {
                return (FloatingButtonPosition)Interop.Eext.eext_floatingbutton_pos_get(Handle);
            }
        }

        public bool MovementBlock
        {
            get
            {
                return Interop.Eext.eext_floatingbutton_movement_block_get(Handle);
            }
            set
            {
                Interop.Eext.eext_floatingbutton_movement_block_set(Handle, value);
            }
        }

        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }

            set
            {
                Console.WriteLine("FloatingButton instance doesn't support to set Opacity.");
            }
        }

        public void SetPosition(FloatingButtonPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Eext.eext_floatingbutton_pos_bring_in(Handle, (int)position);
            }
            else
            {
                Interop.Eext.eext_floatingbutton_pos_set(Handle, (int)position);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Eext.eext_floatingbutton_add(parent.Handle);
        }

        public enum FloatingButtonMode
        {
            All,
            LeftRightOnly,
        }

        public enum FloatingButtonPosition
        {
            LeftOut,
            Left,
            Center,
            Right,
            RightOut,
        }
    }
}