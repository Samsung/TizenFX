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
    public class PalmCoverData : IDisposable
    {
        private InputGesture _gesture;
        internal SafeGestureHandle _handle;
        private bool disposed = false;

        /// <summary>
        /// Creates a new PalmCoverData.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public PalmCoverData(InputGesture gesture)
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
            _handle = PalmCoverNew(_gesture.GetNativeHandle());
            if (_handle.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _gesture.ErrorCodeThrow((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "PalmCoverData Created");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~PalmCoverData()
        {
            Dispose(false);
            Log.Debug(LogTag, "PalmCoverData Destroyed");
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
                Interop.InputGesture.ErrorCode res = Interop.InputGesture.PalmCoverFree(_gesture.GetNativeHandle(), _handle);
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
