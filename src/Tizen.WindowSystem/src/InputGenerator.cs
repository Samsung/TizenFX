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
        private SafeHandles.InputGeneratorHandle _inputGeneratorHandle;
        private TizenCoreWlDisplay _display;
        private bool _disposed = false;
        private readonly InputGeneratorDevices _deviceType;

        /// <summary>
        /// Creates a new InputGenerator.
        /// </summary>
        /// <param name="display">The TizenCoreWlDisplay instance.</param>
        /// <param name="deviceType">The device types to initialize.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public InputGenerator(TizenCoreWlDisplay display, InputGeneratorDevices deviceType)
            : this(display, deviceType, null, false)
        {
        }

        /// <summary>
        /// Creates a new InputGenerator with a custom device name.
        /// </summary>
        /// <param name="display">The TizenCoreWlDisplay instance.</param>
        /// <param name="deviceType">The device types to initialize.</param>
        /// <param name="name">The device name.</param>
        /// <param name="sync">If true, creates synchronously.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public InputGenerator(TizenCoreWlDisplay display, InputGeneratorDevices deviceType, string name, bool sync = false)
        {
            if (display == null)
            {
                throw new ArgumentNullException(nameof(display));
            }

            if (display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new ArgumentException("The display is not initialized or has been disposed.", nameof(display));
            }

            _deviceType = deviceType;
            _display = display;
            int ret;
            IntPtr handle;
            if (sync)
            {
                ret = Interop.InputGenerator.CreateWithSync(display.GetNativeHandle(), deviceType, name, out handle);
            }
            else
            {
                if (name == null)
                    ret = Interop.InputGenerator.Create(display.GetNativeHandle(), deviceType, out handle);
                else
                    ret = Interop.InputGenerator.CreateWithName(display.GetNativeHandle(), deviceType, name, out handle);
            }

            if (ret != (int)Interop.InputGenerator.ErrorCode.None)
            {
                ErrorUtils.ThrowIfError(ret, "Failed to create InputGenerator");
            }
            _inputGeneratorHandle = new SafeHandles.InputGeneratorHandle(handle, true);
        }

        /// <summary>
        /// Gets the device types initialized for this InputGenerator.
        /// </summary>
        public InputGeneratorDevices DeviceType => _deviceType;

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
            if (_disposed) return;

            if (disposing)
            {
                _inputGeneratorHandle?.Dispose();
            }
            _disposed = true;
        }

        /// <summary>
        /// Send given key.
        /// </summary>
        /// <param name="keyName">The key name to generate.</param>
        /// <param name="isPressed">Set the key is pressed or released.</param>
        /// <exception cref="InvalidOperationException">Thrown when the InputGenerator was not initialized with <see cref="InputGeneratorDevices.Keyboard"/>.</exception>
        public void SendKey(string keyName, bool isPressed)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }

            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            EnsureDeviceSupported(InputGeneratorDevices.Keyboard);
            int res = Interop.InputGenerator.GenerateKey(_inputGeneratorHandle, keyName, isPressed);
            ErrorUtils.ThrowIfError(res, "Unknown Error");
        }

        /// <summary>
        /// Send given pointer.
        /// </summary>
        /// <param name="index">The pointer button or touch index to generate.</param>
        /// <param name="action">The pointer action to generate.</param>
        /// <param name="x">X coordinate of the pointer.</param>
        /// <param name="y">Y coordinate of the pointer.</param>
        /// <param name="device">The device type to generate.</param>
        /// <exception cref="InvalidOperationException">Thrown when the InputGenerator was not initialized with the specified device type.</exception>
        public void SendPointer(int index, PointerAction action, int x, int y, InputGeneratorDevices device = InputGeneratorDevices.Pointer)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }

            EnsureDeviceSupported(device);
            if (device == InputGeneratorDevices.Touchscreen)
            {
                int touchAction = 0; // None
                switch (action)
                {
                    case PointerAction.Down: touchAction = 1; break; // Begin
                    case PointerAction.Up: touchAction = 3; break; // End
                    case PointerAction.Move: touchAction = 2; break; // Update
                }
                int res = Interop.InputGenerator.GenerateTouch(_inputGeneratorHandle, index, touchAction, x, y);
                ErrorUtils.ThrowIfError(res, "Unknown Error");
            }
            else
            {
                int res = Interop.InputGenerator.GeneratePointer(_inputGeneratorHandle, index, (int)action, x, y);
                ErrorUtils.ThrowIfError(res, "Unknown Error");
            }
        }

        /// <summary>
        /// Send given wheel.
        /// </summary>
        /// <param name="wheelType">The wheel type to generate.</param>
        /// <param name="value">The offset value of rolling (positive value means roll down or clockwise, and negative value means roll up or counter-clockwise).</param>
        /// <exception cref="InvalidOperationException">Thrown when the InputGenerator was not initialized with <see cref="InputGeneratorDevices.Pointer"/>.</exception>
        public void SendWheel(WheelDirection wheelType, int value)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }

            EnsureDeviceSupported(InputGeneratorDevices.Pointer);
            int res = Interop.InputGenerator.GenerateWheel(_inputGeneratorHandle, wheelType, value);
            ErrorUtils.ThrowIfError(res, "Unknown Error");
        }

        /// <summary>
        /// Send given touch with axis.
        /// </summary>
        /// <param name="index">The touch index to generate.</param>
        /// <param name="action">The touch action to generate.</param>
        /// <param name="x">X coordinate of the touch.</param>
        /// <param name="y">Y coordinate of the touch.</param>
        /// <param name="radiusX">radius_x of the touch.</param>
        /// <param name="radiusY">radius_y of the touch.</param>
        /// <param name="pressure">pressure of the touch.</param>
        /// <param name="angle">angle of the touch.</param>
        /// <param name="palm">palm of the touch.</param>
        /// <exception cref="InvalidOperationException">Thrown when the InputGenerator was not initialized with <see cref="InputGeneratorDevices.Touchscreen"/>.</exception>
        public void SendPointer(int index, PointerAction action, int x, int y, double radiusX, double radiusY, double pressure, double angle, double palm)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(InputGenerator));
            }

            EnsureDeviceSupported(InputGeneratorDevices.Touchscreen);
            int touchAction = 0; // None
            switch (action)
            {
                case PointerAction.Down: touchAction = 1; break; // Begin
                case PointerAction.Up: touchAction = 3; break; // End
                case PointerAction.Move: touchAction = 2; break; // Update
            }

            int res = Interop.InputGenerator.GenerateTouchAxis(_inputGeneratorHandle, index, touchAction, x, y, radiusX, radiusY, pressure, angle, palm);
            ErrorUtils.ThrowIfError(res, "Unknown Error");
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> if the required device type is not initialized.
        /// </summary>
        private void EnsureDeviceSupported(InputGeneratorDevices required)
        {
            if ((_deviceType & required) == 0)
            {
                throw new InvalidOperationException(
                    $"This InputGenerator was initialized with {_deviceType} " +
                    $"and does not support {required} operations. " +
                    $"Create an InputGenerator with {required} device to use this method.");
            }
        }
    }
}
