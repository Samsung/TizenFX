/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for the Tizen Input Generator.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/inputgenerator
    /// </privilege>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputGenerator : IDisposable
    {
        private IntPtr _handler;
        private bool disposed = false;

        /// <summary>
        /// Enumeration of input device types.
        /// </summary>
        public enum DeviceType
        {
            /// <summary>
            /// None.
            /// </summary>
            None = Interop.InputGenerator.DeviceType.None,

            /// <summary>
            /// Touchscreen device.
            /// </summary>
            Touchscreen = Interop.InputGenerator.DeviceType.Touchscreen,

            /// <summary>
            /// Keyboard device.
            /// </summary>
            Keyboard = Interop.InputGenerator.DeviceType.Keyboard,

            /// <summary>
            /// Pointer device.
            /// </summary>
            Pointer = Interop.InputGenerator.DeviceType.Pointer,

            /// <summary>
            /// Keyboard and Touchscreen device.
            /// </summary>
            All = Interop.InputGenerator.DeviceType.All,
        }

        /// <summary>
        /// Enumeration of touch event types.
        /// </summary>
        public enum TouchType
        {
            /// <summary>
            /// None.
            /// </summary>
            None = Interop.InputGenerator.TouchType.None,

            /// <summary>
            /// Touch begin.
            /// </summary>
            Begin = Interop.InputGenerator.TouchType.Begin,

            /// <summary>
            /// Touch move.
            /// </summary>
            Update = Interop.InputGenerator.TouchType.Update,

            /// <summary>
            /// Touch end.
            /// </summary>
            End = Interop.InputGenerator.TouchType.End,
        }

        /// <summary>
        /// Enumeration of pointer event types.
        /// </summary>
        public enum PointerType
        {
            /// <summary>
            /// Pointer down.
            /// </summary>
            Down = Interop.InputGenerator.PointerType.Down,

            /// <summary>
            /// Pointer up.
            /// </summary>
            Up = Interop.InputGenerator.PointerType.Up,

            /// <summary>
            /// Pointer move.
            /// </summary>
            Move = Interop.InputGenerator.PointerType.Move,
        }

        /// <summary>
        /// Enumeration of pointer wheel event types.
        /// </summary>
        public enum PointerWheelType
        {
            /// <summary>
            /// Vertical wheel.
            /// </summary>
            Vertical = Interop.InputGenerator.PointerWheelType.Vertical,

            /// <summary>
            /// Horizontal wheel.
            /// </summary>
            Horizontal = Interop.InputGenerator.PointerWheelType.Horizontal,
        }

        internal void ErrorCodeThrow(Interop.InputGenerator.ErrorCode error)
        {
            switch (error)
            {
                case Interop.InputGenerator.ErrorCode.None :
                    return;
                case Interop.InputGenerator.ErrorCode.OutOfMemory :
                    throw new Tizen.Applications.Exceptions.OutOfMemoryException("Out of Memory");
                case Interop.InputGenerator.ErrorCode.InvalidParameter :
                    throw new ArgumentException("Invalid Parameter");
                case Interop.InputGenerator.ErrorCode.PermissionDenied :
                    throw new Tizen.Applications.Exceptions.PermissionDeniedException("Permission denied");
                case Interop.InputGenerator.ErrorCode.NotSupported :
                    throw new NotSupportedException("Not Supported");
                case Interop.InputGenerator.ErrorCode.NoService :
                    throw new InvalidOperationException("No Service");
                default :
                    throw new InvalidOperationException("Unknown Error");
            }
        }

        /// <summary>
        /// Creates a new InputGenerator.
        /// </summary>
        /// <param name="devType">The Device type of the new input generator.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public InputGenerator(DeviceType devType)
        {
            if (devType == DeviceType.None)
            {
                throw new ArgumentException("Invalid device type");
            }

            _handler = Interop.InputGenerator.Init((int)devType);
        }

        public InputGenerator(DeviceType devType, string name, bool sync = false)
        {
            if (devType == DeviceType.None)
            {
                throw new ArgumentException("Invalid device type");
            }

            if (sync)
                _handler = Interop.InputGenerator.SyncInit((int)devType, name);
            else
                _handler = Interop.InputGenerator.InitWithName((int)devType, name);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~InputGenerator()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (_handler != IntPtr.Zero)
                {
                    Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.Deinit(_handler);
                    ErrorCodeThrow(res);
                    _handler = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Generate given key.
        /// </summary>
        /// <param name="keyName">The key name to generate.</param>
        /// <param name="pressed">Set the key is pressed or released.</param>
        public void GenerateKey(string keyName, int pressed)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateKey(_handler, keyName, pressed);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generate given pointer.
        /// </summary>
        /// <param name="buttons">The pointer button to generate.</param>
        /// <param name="pointerType">The type of the pointer.</param>
        /// <param name="x">X coordinate of the pointer.</param>
        /// <param name="y">Y coordinate of the pointer.</param>
        public void GeneratePointer(int buttons, PointerType pointerType, int x, int y)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GeneratePointer(_handler, buttons, (int)pointerType, x, y);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generate given wheel.
        /// </summary>
        /// <param name="wheelType">The wheel type to generate.</param>
        /// <param name="value">The value of the wheel.</param>
        public void GenerateWheel(PointerWheelType wheelType, int value)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateWheel(_handler, (int)wheelType, value);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generate given touch.
        /// </summary>
        /// <param name="idx">The touch index to generate.</param>
        /// <param name="touchType">The touch type to generate.</param>
        /// <param name="x">X coordinate of the touch.</param>
        /// <param name="y">Y coordinate of the touch.</param>
        public void GenerateTouch(int idx, TouchType touchType, int x, int y)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouch(_handler, idx, (int) touchType, x, y);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generate given touch with axis.
        /// </summary>
        /// <param name="idx">The touch index to generate.</param>
        /// <param name="touchType">The touch type to generate.</param>
        /// <param name="x">X coordinate of the touch.</param>
        /// <param name="y">Y coordinate of the touch.</param>
        /// <param name="radius_x">radius_x of the touch.</param>
        /// <param name="radius_y">radius_y of the touch.</param>
        /// <param name="pressure">pressure of the touch.</param>
        /// <param name="angle">angle of the touch.</param>
        /// <param name="palm">palm of the touch.</param>
        public void GenerateTouchAxis(int idx, TouchType touchType, int x, int y, double radius_x, double radius_y, double pressure, double angle, double palm)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouchAxis(_handler, idx, (int) touchType, x, y, radius_x, radius_y, pressure, angle, palm);
            ErrorCodeThrow(res);
        }
    }
}
