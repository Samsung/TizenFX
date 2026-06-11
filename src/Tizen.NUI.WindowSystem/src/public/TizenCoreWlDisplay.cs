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

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// Class for the Tizen Core Wayland Display.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TizenCoreWlDisplay : IDisposable
    {
        private static int _initRefCount = 0;
        private static readonly object _refCountLock = new object();

        private IntPtr _display;
        private bool disposed = false;
        private bool isDisposeQueued = false;
        private bool _connected = false;
        private readonly object _instanceLock = new object();

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
                case Interop.TizenCoreWl.ErrorCode.NoResourceAvailable:
                    throw new InvalidOperationException("No Resource Available");
                default:
                    throw new InvalidOperationException($"Unknown Error: {error}");
            }
        }

        /// <summary>
        /// Creates a new TizenCoreWlDisplay.
        /// </summary>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public TizenCoreWlDisplay()
        {
            bool initialized = false;
            lock (_refCountLock)
            {
                Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_init()");
                if (_initRefCount == 0)
                {
                    int initRet = Interop.TizenCoreWl.Init();
                    if (initRet != (int)Interop.TizenCoreWl.ErrorCode.None)
                    {
                        Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: tizen_core_wl_init() failed with error={initRet}");
                        disposed = true;
                        GC.SuppressFinalize(this);
                        ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)initRet);
                    }
                }
                _initRefCount++;
                initialized = true;
            }

            try
            {
                int ret = Interop.TizenCoreWl.DisplayCreate(out _display);
                if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
                {
                    Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() failed with error={ret}");
                    ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)ret);
                }
                Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayCreate() succeeded, handle=0x{_display:X}");
            }
            catch
            {
                disposed = true;
                GC.SuppressFinalize(this);
                if (initialized)
                {
                    lock (_refCountLock)
                    {
                        _initRefCount--;
                        if (_initRefCount == 0)
                        {
                            try
                            {
                                Interop.TizenCoreWl.Shutdown();
                            }
                            catch (Exception ex)
                            {
                                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Shutdown() failed during exception recovery: {ex.Message}");
                            }
                        }
                    }
                }
                throw;
            }
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
                if (disposed || _display == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(TizenCoreWlDisplay));
                }

                if (_connected)
                {
                    throw new InvalidOperationException("Display is already connected");
                }

                Tizen.Log.Debug("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Connect(name={name ?? "null"}) called");
                int ret = Interop.TizenCoreWl.DisplayConnect(_display, name);
                if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
                {
                    Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayConnect() failed with error={ret}");
                    ErrorCodeThrow((Interop.TizenCoreWl.ErrorCode)ret);
                }
                _connected = true;
                Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: DisplayConnect() succeeded");
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~TizenCoreWlDisplay()
        {
            if (!isDisposeQueued)
            { 
                isDisposeQueued = true;
                try
                {
                    DisposeQueue.Instance.Add(this);
                }
                catch (Exception ex)
                {
                    Tizen.Log.Error("TIZEN_CORE_WL", $"Failed to queue dispose: {ex.Message}");
                    Dispose(DisposeTypes.Implicit);
                }
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
            lock (_instanceLock)
            {
                if (disposed)
                {
                    return;
                }

                disposed = true;
                if (_display != IntPtr.Zero)
                { 
                    Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: Disconnecting and destroying display");
                    if (_connected)
                    { 
                        try
                        { 
                            int ret = Interop.TizenCoreWl.DisplayDisconnect(_display);
                            if (ret != (int)Interop.TizenCoreWl.ErrorCode.None)
                            {
                                Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayDisconnect() failed with error={ret}");
                            }
                        }
                        catch (Exception ex)
                        { 
                            Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayDisconnect() threw exception: {ex.Message}");
                        }
                        _connected = false;
                    }
                    try
                    { 
                        int destroyRet = Interop.TizenCoreWl.DisplayDestroy(_display);
                        if (destroyRet != (int)Interop.TizenCoreWl.ErrorCode.None)
                        {
                            Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayDestroy() failed with error={destroyRet}");
                        }
                    }
                    catch (Exception ex)
                    { 
                        Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: DisplayDestroy() threw exception: {ex.Message}");
                    }
                    _display = IntPtr.Zero;
                }
            }

            lock (_refCountLock)
            {
                _initRefCount--;
                if (_initRefCount == 0)
                {
                    Tizen.Log.Debug("TIZEN_CORE_WL", "TizenCoreWlDisplay: calling tizen_core_wl_shutdown()");
                    try
                    {
                        int shutdownRet = Interop.TizenCoreWl.Shutdown();
                        if (shutdownRet != (int)Interop.TizenCoreWl.ErrorCode.None)
                        {
                            Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Shutdown() failed with error={shutdownRet}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Tizen.Log.Error("TIZEN_CORE_WL", $"TizenCoreWlDisplay: Shutdown() threw exception: {ex.Message}");
                    }
                }
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
