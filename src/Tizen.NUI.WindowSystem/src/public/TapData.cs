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
using System.Runtime.InteropServices;
using static Tizen.NUI.WindowSystem.Interop.InputGesture;

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// Represents a wrapper class for a unmanaged gesture data handle.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TapData : IDisposable
    {
        private InputGesture _gesture;
        internal SafeGestureHandle _handle;
        private bool disposed = false;

        /// <summary>
        /// Creates a new TapData.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public TapData(InputGesture gesture, int fingers, int repeats)
        {
            if (gesture == null)
            {
                throw new ArgumentNullException(nameof(gesture));
            }
            if (gesture.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("InputGesture is not initialized.");
            }
            _gesture = gesture;
            _handle = TapNew(_gesture.GetNativeHandle(), fingers, repeats);
            if (_handle.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _gesture.ErrorCodeThrow((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "TapData Created");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~TapData()
        {
            Dispose(false);
            Log.Debug(LogTag, "TapData Destroyed");
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
                Interop.InputGesture.ErrorCode res = Interop.InputGesture.TapFree(_gesture.GetNativeHandle(), _handle);
                _gesture.ErrorCodeThrow(res);

                if (disposing)
                {
                    _handle?.Dispose();
                    _handle = null;
                }
                disposed = true;
            }
        }

        internal SafeGestureHandle GetNativeHandle()
        {
            return _handle;
        }
    }
}
