/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Enumeration of device type generated events.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum InputDeviceType
    {
        /// <summary>
        /// Touch Screen device.
        /// </summary>
        TouchScreen = (1 << 0),

        /// <summary>
        /// Keyboard device.
        /// </summary>
        Keyboard = (1 << 1),

        /// <summary>
        /// Mouse Device.
        /// </summary>
        /// <remarks>
        /// Since 3.0.
        /// </remarks>
        Pointer = (1 << 2),
    }

    /// <summary>
    /// Enumeration of pointer event types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum InputPointerType
    {
        /// <summary>
        /// Mouse button press.
        /// </summary>
        MouseDown,

        /// <summary>
        /// Mouse button release.
        /// </summary>
        MouseUp,

        /// <summary>
        /// Mouse move
        /// </summary>
        Move,
    }

    /// <summary>
    /// Enumeration of touch event types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum InputTouchType
    {
        /// <summary>
        /// Finger press. It is same a behavior put your finger on touch screen.
        /// </summary>
        Begin = 1,

        /// <summary>
        /// Finger move. It is same a behavior move your finger on touch screen.
        /// </summary>
        Update,

        /// <summary>
        /// Finger release. It is same a behavior release your finger on touch screen.
        /// </summary>
        End,
    }

    /// <summary>
    /// InputGenerator provides functions to initialize/deinitialize input devices and to generation touch / key events.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/inputgenerator
    /// </privilege>
    /// <remarks>
    /// This is not for use by third-party applications.
    /// </remarks>
    /// <since_tizen> preview </since_tizen>
    public class InputGenerator : IDisposable
    {
        IntPtr _handle = IntPtr.Zero;
        bool _isDisposed = false;

        /// <summary>
        /// Creates and initializes a new instance of the InputGenerator class.
        /// </summary>
        /// <param name="deviceType">The device type want to generate events</param>
        /// <since_tizen> preview </since_tizen>
        public InputGenerator(InputDeviceType deviceType)
        {
            _handle = Interop.Eutil.efl_util_input_initialize_generator((int)deviceType);
        }

        /// <summary>
        /// Creates and initializes a new instance of the InputGenerator class with given name.
        /// </summary>
        /// <param name="deviceType">The device type want to generate events</param>
        /// <param name="name">The device name (maximum 31 characters)</param>
        /// <since_tizen> preview </since_tizen>
        public InputGenerator(InputDeviceType deviceType, string name)
        {
            _handle = Interop.Eutil.efl_util_input_initialize_generator_with_name((int)deviceType, name);
        }

        /// <summary>
        /// Destroys the InputGenerator object.
        /// </summary>
        ~InputGenerator()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                Interop.Eutil.efl_util_input_deinitialize_generator(_handle);
            }

            _isDisposed = true;
        }

        /// <summary>
        /// Generates all of key events using a opened device.
        /// </summary>
        /// <param name="key">The key name want to generate.</param>
        /// <param name="pressed">The value that select key press or release. (0: release, 1: press)</param>
        /// <since_tizen> preview </since_tizen>
        public void GenerateKeyEvent(string key, int pressed)
        {
            Interop.Eutil.efl_util_input_generate_key(_handle, key, pressed);
        }

        /// <summary>
        /// Generate a pointer event using a opened device
        /// </summary>
        /// <param name="buttons">The number of button.</param>
        /// <param name="type">The pointer type.</param>
        /// <param name="x">x coordination to move.</param>
        /// <param name="y">y coordination to move.</param>
        /// <since_tizen> preview </since_tizen>
        public void GenerateMouseEvent(int buttons, InputPointerType type, int x, int y)
        {
            Interop.Eutil.efl_util_input_generate_pointer(_handle, buttons, (int)type, x, y);
        }

        /// <summary>
        /// Generate a touch event using a opened device
        /// </summary>
        /// <param name="index">The index of touched finger.</param>
        /// <param name="type">The touch type.</param>
        /// <param name="x">The x axis of touch point.</param>
        /// <param name="y">The y axis of touch point.</param>
        /// <since_tizen> preview </since_tizen>
        public void GenerateTouchEvent(int index, InputTouchType type, int x, int y)
        {
            Interop.Eutil.efl_util_input_generate_touch(_handle, index, (int)type, x, y);
        }
    }
}
