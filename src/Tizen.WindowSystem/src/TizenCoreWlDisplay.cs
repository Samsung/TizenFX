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
        private bool disposed = false;

        internal void ErrorCodeThrow(Interop.TizenCoreWl.ErrorCode error)
        {
            switch (error)
            {
                case Interop.TizenCoreWl.ErrorCode.None:
                    return;
                case Interop.TizenCoreWl.ErrorCode.OutOfMemory:
                    throw new Tizen.Applications.Exceptions.OutOfMemoryException("Out of Memory");
                case Interop.TizenCoreWl.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid Parameter");
                case Interop.TizenCoreWl.ErrorCode.PermissionDenied:
                    throw new Tizen.Applications.Exceptions.PermissionDeniedException("Permission denied");
                case Interop.TizenCoreWl.ErrorCode.NotSupported:
                    throw new NotSupportedException("Not Supported");
                case Interop.TizenCoreWl.ErrorCode.NotConnected:
                    throw new InvalidOperationException("Not Connected");
                default:
                    throw new InvalidOperationException("Unknown Error");
            }
        }

        /// <summary>
        /// Creates a new TizenCoreWlDisplay.
        /// </summary>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public TizenCoreWlDisplay()
        {
            Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_init()");
            int initRet = Interop.TizenCoreWl.Init();
            if (initRet != (int)Interop.TizenCoreWl.ErrorCode.None)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: tizen_core_wl_init() failed with error={initRet}");
                ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)initRet);
            }

            int ret = Interop.TizenCoreWl.DisplayCreate(out _display);
            if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() failed with error={ret}");
                ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)ret);
            }
            Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() succeeded, handle=0x{_display:X}");
        }

        /// <summary>
        /// Connects to the Wayland display server.
        /// </summary>
        /// <param name="name">The name of the display to connect to, or null for the default display.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to connect.</exception>
        public void Connect(string name = null)
        {
            Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Connect(name={name ?? "null"}) called");
            int ret = Interop.TizenCoreWl.DisplayConnect(_display, name);
            if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
            {
                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayConnect() failed with error={ret}");
                ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)ret);
            }
            Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: DisplayConnect() succeeded");
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
                if (_display != IntPtr.Zero)
                {
                    Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: Disconnecting and destroying display");
                    Interop.TizenCoreWl.DisplayDisconnect(_display);
                    Interop.TizenCoreWl.DisplayDestroy(_display);
                    _display = IntPtr.Zero;
                }
                Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_shutdown()");
                Interop.TizenCoreWl.Shutdown();
                disposed = true;
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
