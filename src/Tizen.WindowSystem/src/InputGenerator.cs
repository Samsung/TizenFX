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

        /// <summary>
        /// Creates a new InputGenerator.
        /// </summary>
        /// <param name="name">The name of the new input generator.</param>
        /// <param name="sync"></param>
        /// <exception cref="ArgumentException"></exception>
        public InputGenerator(string name = null, bool sync = false)
        {
            if (sync)
            {
                _inputGeneratorHandle = Interop.InputGenerator.SyncInit(InputGeneratorDevices.All, name);
            }
            else
            {
                if (name == null)
                    _inputGeneratorHandle = Interop.InputGenerator.Init(InputGeneratorDevices.All);
                else
                    _inputGeneratorHandle = Interop.InputGenerator.InitWithName(InputGeneratorDevices.All, name);
            }
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
        public void SendKey(string keyName, bool isPressed)
        {
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
        public void SendPointer(int index, PointerAction action, int x, int y, InputGeneratorDevices device = InputGeneratorDevices.Pointer)
        {
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
        /// <param name="value">The value of the wheel.</param>
        public void SendWheel(WheelDirection wheelType, int value)
        {
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

        public void SendPointer(int index, PointerAction action, int x, int y, double radiusX, double radiusY, double pressure, double angle, double palm)
        {
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
    }
}
