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
    /// The FloatingButton is a widget to add the floating area for buttons.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FloatingButton : Layout
    {
        /// <summary>
        /// Creates and initializes a new instance of the FloatingButton class.
        /// </summary>
        /// <param name="parent">Created on this parent container.</param>
        /// <since_tizen> preview </since_tizen>
        public FloatingButton(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets the floatingbutton mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets the floatingbutton position.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FloatingButtonPosition Position
        {
            get
            {
                return (FloatingButtonPosition)Interop.Eext.eext_floatingbutton_pos_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets the movability for a given FloatingButton widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets the opacity's value of the given FloatingButton.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Set the floatingbutton position with or without animation.
        /// </summary>
        /// <param name="position">Button position.</param>
        /// <param name="animated">Animation flag.</param>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Eext.eext_floatingbutton_add(parent.Handle);
        }
    }

    /// <summary>
    /// Enumeration for the FloatingButtonMode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum FloatingButtonMode
    {
        /// <summary>
        /// Allows all positions.
        /// </summary>
        All,

        /// <summary>
        /// Allows left and right positions only.
        /// </summary>
        LeftRightOnly,
    }

    /// <summary>
    /// Enumeration for the FloatingButtonPosition.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum FloatingButtonPosition
    {
        /// <summary>
        /// Hides in the left, but only the small handler will show.
        /// </summary>
        LeftOut,

        /// <summary>
        /// Shows all of the buttons, but lies on the left.
        /// </summary>
        Left,

        /// <summary>
        /// Shows all of the buttons, but lies on the center.
        /// </summary>
        Center,

        /// <summary>
        /// Shows all of the buttons, but lies on the right.
        /// </summary>
        Right,

        /// <summary>
        /// Hides in the right, but only the small handler will show.
        /// </summary>
        RightOut,
    }
}