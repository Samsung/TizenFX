/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
    /// Class for the Tizen Core Wayland Display.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TizenCoreWlDisplay : IDisposable
    {
        private IntPtr _display;
        private bool _disposed = false;
        private bool _connected = false;
        private readonly int _creationThreadId;
        private readonly object _instanceLock = new object();

        /// <summary>
        /// Creates a new TizenCoreWlDisplay.
        /// </summary>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public TizenCoreWlDisplay()
        {
            _creationThreadId = Environment.CurrentManagedThreadId;
            Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_init()");
            int initRet = Interop.TizenCoreWl.Init();
            if (initRet != (int)Interop.TizenCoreWl.ErrorCode.None)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: tizen_core_wl_init() failed with error={initRet}");
                GC.SuppressFinalize(this);
                ErrorUtils.ThrowIfError(initRet, "Failed to initialize Tizen Core Wayland");
            }

            int ret = Interop.TizenCoreWl.DisplayCreate(out _display);
            if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() failed with error={ret}");
                Interop.TizenCoreWl.Shutdown();
                GC.SuppressFinalize(this);
                ErrorUtils.ThrowIfError(ret, "Failed to create display");
            }
            Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() succeeded, handle=0x{_display:X}");
        }

        /// <summary>
        /// Connects to the Wayland display server.
        /// </summary>
        /// <param name="name">The name of the display to connect to, or null for the default display.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to connect.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the instance is already disposed.</exception>
        public void Connect(string name = null)
        {
            lock (_instanceLock)
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(TizenCoreWlDisplay));
                }

                if (Environment.CurrentManagedThreadId != _creationThreadId)
                {
                    throw new InvalidOperationException("Connect must be called on the creation thread.");
                }

                if (_connected)
                {
                    throw new InvalidOperationException("Already connected to the display server.");
                }

                Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Connect(name={name ?? "null"}) called");
                int ret = Interop.TizenCoreWl.DisplayConnect(_display, name);
                if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
                {
                    Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayConnect() failed with error={ret}");
                    ErrorUtils.ThrowIfError(ret, "Failed to connect display");
                }
                _connected = true;
                Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: DisplayConnect() succeeded");
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TizenCoreWlDisplay"/> class.
        /// </summary>
        ~TizenCoreWlDisplay()
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
            if (_disposed)
            {
                return;
            }

            if (Environment.CurrentManagedThreadId != _creationThreadId)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", "TizenCoreWlDisplay: Dispose called from a different thread or finalizer. Wayland display destruction is thread-affine and must be done on the creation thread. Skipping cleanup to avoid crash.");
                return;
            }

            lock (_instanceLock)
            {
                if (_display != IntPtr.Zero)
                {
                    Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: Disconnecting and destroying display");
                    if (_connected)
                    {
                        Interop.TizenCoreWl.DisplayDisconnect(_display);
                        _connected = false;
                    }
                    Interop.TizenCoreWl.DisplayDestroy(_display);
                    _display = IntPtr.Zero;
                }
                Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_shutdown()");
                Interop.TizenCoreWl.Shutdown();
                _disposed = true;
            }
        }

        /// <summary>
        /// Gets the native display handle.
        /// </summary>
        internal IntPtr GetNativeHandle()
        {
            return _display;
        }
    }
}
