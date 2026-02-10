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
using System.Collections.Generic;
using Tizen.Common;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen KVM service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class KVMService : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.KVMServiceHandle _kvmService;
        int _tzshWin;
        bool disposed = false;

        Interop.KVMService.KVMDragStartEventCallback _onDragStarted;
        Interop.KVMService.KVMDragEndEventCallback _onDragEnded;

        event EventHandler _dragStarted;
        event EventHandler _dragEnded;

        /// <summary>
        /// Creates a new KVM Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the quickpanel service.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public KVMService(TizenShell tzShell, IWindowProvider win)
        {
            if (tzShell == null)
            {
                throw new ArgumentNullException(nameof(tzShell));
            }
            if (tzShell.SafeHandle == null || tzShell.SafeHandle.IsInvalid)
            {
                throw new ArgumentException("tzShell is not initialized.");
            }
            if (win == null)
            {
                throw new ArgumentNullException(nameof(win));
            }

            _tzsh = tzShell;
            _tzshWin = WindowSystem.Interop.EcoreWl2.GetWindowId(win.WindowHandle);
            _kvmService = Interop.KVMService.Create(_tzsh.SafeHandle, (uint)_tzshWin);
            if (_kvmService.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(err);
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
                    _kvmService?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Emits the event when the drag started from any window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler DragStarted
        {
            add
            {
                if (_dragStarted == null)
                {
                    _onDragStarted = OnDragStarted;
                    int res = Interop.KVMService.SetDragStartEventHandler(_kvmService, _onDragStarted, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
                _dragStarted += value;
            }
            remove
            {
                _dragStarted -= value;
                if (_dragStarted == null)
                {
                    int res = Interop.KVMService.SetDragStartEventHandler(_kvmService, null, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the drag ended on any window except KVM window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler DragEnded
        {
            add
            {
                if (_dragEnded == null)
                {
                    _onDragEnded = OnDragEnded;
                    int res = Interop.KVMService.SetDragEndEventHandler(_kvmService, _onDragEnded, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
                _dragEnded += value;
            }
            remove
            {
                _dragEnded -= value;
                if (_dragEnded == null)
                {
                    int res = Interop.KVMService.SetDragEndEventHandler(_kvmService, null, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
            }
        }

        void OnDragStarted(IntPtr data, IntPtr softkeyService)
        {
            _dragStarted?.Invoke(this, EventArgs.Empty);
        }

        void OnDragEnded(IntPtr data, IntPtr softkeyService)
        {
            _dragEnded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Requests to perform drop to KVM window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void PerformDrop()
        {
            int res = Interop.KVMService.PerformDrop(_kvmService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to perform drop to given target.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void PerformDrop(DropTarget target)
        {
            int res = Interop.KVMService.PerformDropTarget(_kvmService, (uint)target);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to cancel current drag.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void CancelDrag()
        {
            int res = Interop.KVMService.CancelDrag(_kvmService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to receive the current drag data.
        /// the drag data will be received by the DragEvent of the window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReceiveDragData(string mimeType)
        {
            int res = Interop.KVMService.ReceiveDragData(_kvmService, mimeType);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to receive the mimetype collection of drag source.
        /// </summary>
        /// <returns>
        /// The collection of mimetype.
        /// If there are no mimetype, returns null.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public IEnumerable<string> GetSourceMimetypes()
        {
            int res = Interop.KVMService.GetSourceMimetypes(_kvmService, out IntPtr mimeTypesPtr, out int mimeTypeCount);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);

            if (mimeTypesPtr == IntPtr.Zero || mimeTypeCount == 0)
            {
                return null;
            }
            List<string> mimetypes = new List<string>();
            for (int i = 0; i < mimeTypeCount; i++)
            {
                IntPtr strPtr = global::System.Runtime.InteropServices.Marshal.ReadIntPtr(mimeTypesPtr, i * IntPtr.Size);
                mimetypes.Add(global::System.Runtime.InteropServices.Marshal.PtrToStringAnsi(strPtr));
            }
            return mimetypes;
        }

        /// <summary>
        /// Requests to set KVM window as secondary selection window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetSecondarySelection()
        {
            int res = Interop.KVMService.SetSecondarySelection(_kvmService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to unset secondary selection window of KVM window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void UnsetSecondarySelection()
        {
            int res = Interop.KVMService.UnsetSecondarySelection(_kvmService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }
    }
}
