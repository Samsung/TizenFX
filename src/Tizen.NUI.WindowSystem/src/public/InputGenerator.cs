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

namespace Tizen.NUI.WindowSystem
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
        private TizenCoreWlDisplay _display;
        private bool disposed = false;
        private bool isDisposeQueued = false;

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
                case Interop.InputGenerator.ErrorCode.NotConnected :
                    throw new InvalidOperationException("Not Connected");
                default :
                    throw new InvalidOperationException($"Unknown Error: {error}");
            }
        }

        /// <summary>
        /// Creates a new InputGenerator.
        /// </summary>
        /// <param name="display">The TizenCoreWlDisplay instance.</param>
        /// <param name="devType">The Device type of the new input generator.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public InputGenerator(TizenCoreWlDisplay display, DeviceType devType)
        {
            if (display == null)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: display is null");
                throw new ArgumentNullException(nameof(display));
            }
            if (devType == DeviceType.None)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: Invalid device type (None)");
                throw new ArgumentException("Invalid device type");
            }

            IntPtr displayHandle = display.GetNativeHandle();
            if (displayHandle == IntPtr.Zero)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: display has been disposed");
                throw new ObjectDisposedException(nameof(display));
            }

            _display = display;
            Tizen.Log.Debug("InputGenerator", $"InputGenerator: Creating with devType={devType}");
            int ret = Interop.InputGenerator.Create(displayHandle, (int)devType, out _handler);
            if (ret != (int)Interop.InputGenerator.ErrorCode.None)
            {
                Tizen.Log.Error("InputGenerator", $"InputGenerator: Create() failed with error={ret}");
                disposed = true;
                GC.SuppressFinalize(this);
                ErrorCodeThrow((Interop.InputGenerator.ErrorCode)ret);
            }
            Tizen.Log.Debug("InputGenerator", $"InputGenerator: Create() succeeded, handler=0x{_handler:X}");
        }

        /// <summary>
        /// Creates a new InputGenerator with a custom device name.
        /// </summary>
        /// <param name="display">The TizenCoreWlDisplay instance.</param>
        /// <param name="devType">The Device type of the new input generator.</param>
        /// <param name="name">The device name.</param>
        /// <param name="sync">If true, creates synchronously.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public InputGenerator(TizenCoreWlDisplay display, DeviceType devType, string name, bool sync = false)
        {
            if (display == null)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: display is null");
                throw new ArgumentNullException(nameof(display));
            }
            if (devType == DeviceType.None)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: Invalid device type (None)");
                throw new ArgumentException("Invalid device type");
            }

            IntPtr displayHandle = display.GetNativeHandle();
            if (displayHandle == IntPtr.Zero)
            {
                Tizen.Log.Error("InputGenerator", "InputGenerator: display has been disposed");
                throw new ObjectDisposedException(nameof(display));
            }

            _display = display;
            Tizen.Log.Debug("InputGenerator", $"InputGenerator: Creating with devType={devType}, name={name}, sync={sync}");
            int ret;
            if (string.IsNullOrEmpty(name))
            {
                ret = Interop.InputGenerator.Create(displayHandle, (int)devType, out _handler);
            }
            else if (sync)
            {
                ret = Interop.InputGenerator.CreateWithSync(displayHandle, (int)devType, name, out _handler);
            }
            else
            {
                ret = Interop.InputGenerator.CreateWithName(displayHandle, (int)devType, name, out _handler);
            }
            if (ret != (int)Interop.InputGenerator.ErrorCode.None)
            {
                Tizen.Log.Error("InputGenerator", $"InputGenerator: Create with name failed, error={ret}");
                disposed = true;
                GC.SuppressFinalize(this);
                ErrorCodeThrow((Interop.InputGenerator.ErrorCode)ret);
            }
            Tizen.Log.Debug("InputGenerator", $"InputGenerator: Create with name succeeded, handler=0x{_handler:X}");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~InputGenerator()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            if (_handler != IntPtr.Zero)
            {
                if (_display != null && _display.GetNativeHandle() != IntPtr.Zero)
                {
                    try
                    {
                        int res = Interop.InputGenerator.Destroy(_handler);
                        if (res != (int)Interop.InputGenerator.ErrorCode.None)
                        {
                            Tizen.Log.Error("InputGenerator", $"Failed to destroy input generator, error={res}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Tizen.Log.Error("InputGenerator", $"Exception during destroy: {ex.Message}");
                    }
                }
                _handler = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Generate given key.
        /// </summary>
        /// <param name="keyName">The key name to generate.</param>
        /// <param name="pressed">Set the key is pressed or released.</param>
        public void GenerateKey(string keyName, bool pressed)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            int res = Interop.InputGenerator.GenerateKey(_handler, keyName, pressed);
            ErrorCodeThrow((Interop.InputGenerator.ErrorCode)res);
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
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            int res = Interop.InputGenerator.GeneratePointer(_handler, buttons, (int)pointerType, x, y);
            ErrorCodeThrow((Interop.InputGenerator.ErrorCode)res);
        }

        /// <summary>
        /// Generate given wheel.
        /// </summary>
        /// <param name="wheelType">The wheel type to generate.</param>
        /// <param name="value">The value of the wheel.</param>
        public void GenerateWheel(PointerWheelType wheelType, int value)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            int res = Interop.InputGenerator.GenerateWheel(_handler, (int)wheelType, value);
            ErrorCodeThrow((Interop.InputGenerator.ErrorCode)res);
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
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            int res = Interop.InputGenerator.GenerateTouch(_handler, idx, (int) touchType, x, y);
            ErrorCodeThrow((Interop.InputGenerator.ErrorCode)res);
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
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            int res = Interop.InputGenerator.GenerateTouchAxis(_handler, idx, (int) touchType, x, y, radius_x, radius_y, pressure, angle, palm);
            ErrorCodeThrow((Interop.InputGenerator.ErrorCode)res);
        }
    }
}
