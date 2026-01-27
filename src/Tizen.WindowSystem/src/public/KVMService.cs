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
        private TizenShell _tzsh;
        private IntPtr _kvmService;
        private int _tzshWin;
        private bool disposed = false;

        private Interop.KVMService.KVMDragStartEventCallback _onDragStarted;
        private Interop.KVMService.KVMDragEndEventCallback _onDragEnded;

        private event EventHandler _dragStarted;
        private event EventHandler _dragEnded;


        /// <summary>
        /// Drop target type of PerformDrop request of KVM Service.
        /// </summary>
        public enum DropTarget
        {
            /// <summary>
            /// Drop to KVM Service window self.
            /// </summary>
            KVMServiceWin = 0,
            /// <summary>
            /// Drop to the window that under pointer.
            /// </summary>
            UnderPointer = 1,
        };

        /// <summary>
        /// Creates a new KVM Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the quickpanel.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        public KVMService(TizenShell tzShell, int win)
        {
            if (tzShell == null)
            {
                throw new ArgumentNullException(nameof(tzShell));
            }
            if (tzShell.GetNativeHandle() == IntPtr.Zero)
            {
                throw new ArgumentException("tzShell is not initialized.");
            }

            _tzsh = tzShell;
            _tzshWin = win;
            _kvmService = Interop.KVMService.Create(_tzsh.GetNativeHandle(), (uint)_tzshWin);
            if (_kvmService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }



        /// <summary>
        /// Destructor.
        /// </summary>
        ~KVMService()
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
            if (!disposed)
            {
                if (_kvmService != IntPtr.Zero)
                {
                    int res = Interop.KVMService.Destroy(_kvmService);
                    _kvmService = IntPtr.Zero;
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
                    _tzsh.ErrorCodeThrow(res);
                }
                _dragStarted += value;
            }
            remove
            {
                _dragStarted -= value;
                if (_dragStarted == null)
                {
                    int res = Interop.KVMService.SetDragStartEventHandler(_kvmService, null, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
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
                    _tzsh.ErrorCodeThrow(res);
                }
                _dragEnded += value;
            }
            remove
            {
                _dragEnded -= value;
                if (_dragEnded == null)
                {
                    int res = Interop.KVMService.SetDragEndEventHandler(_kvmService, null, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
            }
        }

        private void OnDragStarted(IntPtr data, IntPtr softkeyService)
        {
            _dragStarted?.Invoke(this, EventArgs.Empty);
        }

        private void OnDragEnded(IntPtr data, IntPtr softkeyService)
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
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to perform drop to given target.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void PerformDrop(DropTarget target)
        {
            int res = Interop.KVMService.PerformDropTarget(_kvmService, (uint)target);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to cancel current drag.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void CancelDrag()
        {
            int res = Interop.KVMService.CancelDrag(_kvmService);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to receive the current drag data.
        /// the drag data will be received by the DragEvent of the window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReceiveDragData(string mimeType)
        {
            int res = Interop.KVMService.ReceiveDragData(_kvmService, mimeType);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to receive the mimetype list of drag source.
        /// </summary>
        /// <returns>
        /// The list of mimetype.
        /// If there are no mimetype, returns null.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public List<string> GetSourceMimetypes()
        {
            int res = Interop.KVMService.GetSourceMimetypes(_kvmService, out string[] mimetypes, out int mimeTypeCount);
            _tzsh.ErrorCodeThrow(res);

            if (mimetypes == null) return null;
            return new List<string>(mimetypes);
        }

        /// <summary>
        /// Requests to set KVM window as secondary selection window.
        /// The request name has typo and will remove soon.
        /// Please use SetSecondarySelection.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetSecondarySelction()
        {
           SetSecondarySelection();
        }

        /// <summary>
        /// Requests to unset secondary selection window of KVM window.
        /// The request name has typo and will remove soon.
        /// Please use UnsetSecondarySelection.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void UnsetSecondarySelction()
        {
           UnsetSecondarySelection();
        }

        /// <summary>
        /// Requests to set KVM window as secondary selection window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetSecondarySelection()
        {
            int res = Interop.KVMService.SetSecondarySelection(_kvmService);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to unset secondary selection window of KVM window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void UnsetSecondarySelection()
        {
            int res = Interop.KVMService.UnsetSecondarySelection(_kvmService);
            _tzsh.ErrorCodeThrow(res);
        }
    }
}
