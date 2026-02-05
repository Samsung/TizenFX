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
        private SafeHandles.InputGeneratorHandle _handler;
        private bool disposed = false;


        internal void ThrowIfError(Interop.InputGenerator.ErrorCode error)
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
        public InputGenerator(InputGeneratorDevices devType)
        {
            if (devType == InputGeneratorDevices.None)
            {
                throw new ArgumentException("Invalid device type");
            }

            _handler = Interop.InputGenerator.Init(devType);
        }

        /// <summary>
        /// Creates a new InputGenerator.
        /// </summary>
        /// <param name="devType">The Device type of the new input generator.</param>
        /// <param name="name">The name of the new input generator.</param>
        /// <param name="sync"></param>
        /// <exception cref="ArgumentException"></exception>
        public InputGenerator(InputGeneratorDevices devType, string name, bool sync = false)
        {
            if (devType == InputGeneratorDevices.None)
            {
                throw new ArgumentException("Invalid device type");
            }

            if (sync)
                _handler = Interop.InputGenerator.SyncInit(devType, name);
            else
                _handler = Interop.InputGenerator.InitWithName(devType, name);
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
                    _handler?.Dispose();
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
            ThrowIfError(res);
        }

        /// <summary>
        /// Generate given pointer.
        /// </summary>
        /// <param name="buttons">The pointer button to generate.</param>
        /// <param name="pointerType">The type of the pointer.</param>
        /// <param name="x">X coordinate of the pointer.</param>
        /// <param name="y">Y coordinate of the pointer.</param>
        public void GeneratePointer(int buttons, PointerAction pointerType, int x, int y)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GeneratePointer(_handler, buttons, pointerType, x, y);
            ThrowIfError(res);
        }

        /// <summary>
        /// Generate given wheel.
        /// </summary>
        /// <param name="wheelType">The wheel type to generate.</param>
        /// <param name="value">The value of the wheel.</param>
        public void GenerateWheel(WheelDirection wheelType, int value)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateWheel(_handler, wheelType, value);
            ThrowIfError(res);
        }

        /// <summary>
        /// Generate given touch.
        /// </summary>
        /// <param name="idx">The touch index to generate.</param>
        /// <param name="touchType">The touch type to generate.</param>
        /// <param name="x">X coordinate of the touch.</param>
        /// <param name="y">Y coordinate of the touch.</param>
        public void GenerateTouch(int idx, TouchAction touchType, int x, int y)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouch(_handler, idx, touchType, x, y);
            ThrowIfError(res);
        }

        /// <summary>
        /// Generate given touch with axis.
        /// </summary>
        /// <param name="idx">The touch index to generate.</param>
        /// <param name="touchType">The touch type to generate.</param>
        /// <param name="x">X coordinate of the touch.</param>
        /// <param name="y">Y coordinate of the touch.</param>
        /// <param name="radiusX">radius_x of the touch.</param>
        /// <param name="radiusY">radius_y of the touch.</param>
        /// <param name="pressure">pressure of the touch.</param>
        /// <param name="angle">angle of the touch.</param>
        /// <param name="palm">palm of the touch.</param>
        public void GenerateTouchAxis(int idx, TouchAction touchType, int x, int y, double radiusX, double radiusY, double pressure, double angle, double palm)
        {
            Interop.InputGenerator.ErrorCode res = Interop.InputGenerator.GenerateTouchAxis(_handler, idx, touchType, x, y, radiusX, radiusY, pressure, angle, palm);
            ThrowIfError(res);
        }
    }
}

