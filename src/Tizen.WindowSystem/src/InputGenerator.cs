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
        private bool disposed = false;
        private readonly InputGeneratorDevices _deviceType;

        /// <summary>
        /// Creates a new InputGenerator with all device types.
        /// </summary>
        /// <param name="name">The name of the new input generator.</param>
        /// <param name="sync">Whether to use synchronous initialization.</param>
        /// <exception cref="ArgumentException"></exception>
        public InputGenerator(string name = null, bool sync = false)
            : this(InputGeneratorDevices.All, name, sync)
        {
        }

        /// <summary>
        /// Creates a new InputGenerator with specified device types.
        /// By specifying only the required device types instead of <see cref="InputGeneratorDevices.All"/>,
        /// internal native resource overhead can be reduced.
        /// </summary>
        /// <remarks>
        /// When a specific device type is specified, only methods corresponding to that device type can be called.
        /// Calling a method that does not match the initialized device type will throw an <see cref="InvalidOperationException"/>.
        /// For example, if initialized with <see cref="InputGeneratorDevices.Keyboard"/> only,
        /// calling <see cref="SendPointer(int, PointerAction, int, int, InputGeneratorDevices)"/> will throw an exception.
        /// </remarks>
        /// <param name="deviceType">The device types to initialize. Only methods matching the specified device types can be used.</param>
        /// <param name="name">The name of the new input generator.</param>
        /// <param name="sync">Whether to use synchronous initialization.</param>
        /// <exception cref="ArgumentException"></exception>
        public InputGenerator(InputGeneratorDevices deviceType, string name = null, bool sync = false)
        {
            _deviceType = deviceType;
            if (sync)
            {
                _inputGeneratorHandle = Interop.InputGenerator.SyncInit(deviceType, name);
            }
            else
            {
                if (name == null)
                    _inputGeneratorHandle = Interop.InputGenerator.Init(deviceType);
                else
                    _inputGeneratorHandle = Interop.InputGenerator.InitWithName(deviceType, name);
            }
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
            if (!disposed)
            {
                if (disposing)
                {
                    _inputGeneratorHandle?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Send given key.
        /// </summary>
        /// <param name="keyName">The key name to generate.</param>
        /// <param name="isPressed">Set the key is pressed or released.</param>
        /// <exception cref="InvalidOperationException">Thrown when the InputGenerator was not initialized with <see cref="InputGeneratorDevices.Keyboard"/>.</exception>
        public void SendKey(string keyName, bool isPressed)
        {
            EnsureDeviceSupported(InputGeneratorDevices.Keyboard);
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateKey(_inputGeneratorHandle, keyName, isPressed);
            ErrorUtils.ThrowIfError((int)res, "Unknown Error");
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
                Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouch(_inputGeneratorHandle, index, touchAction, x, y);
                ErrorUtils.ThrowIfError((int)res, "Unknown Error");
            }
            else
            {
                Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GeneratePointer(_inputGeneratorHandle, index, (int)action, x, y);
                ErrorUtils.ThrowIfError((int)res, "Unknown Error");
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
            EnsureDeviceSupported(InputGeneratorDevices.Pointer);
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateWheel(_inputGeneratorHandle, wheelType, value);
            ErrorUtils.ThrowIfError((int)res, "Unknown Error");
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
            EnsureDeviceSupported(InputGeneratorDevices.Touchscreen);
            int touchAction = 0; // None
            switch (action)
            {
                case PointerAction.Down: touchAction = 1; break; // Begin
                case PointerAction.Up: touchAction = 3; break; // End
                case PointerAction.Move: touchAction = 2; break; // Update
            }

            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouchAxis(_inputGeneratorHandle, index, touchAction, x, y, radiusX, radiusY, pressure, angle, palm);
            ErrorUtils.ThrowIfError((int)res, "Unknown Error");
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
