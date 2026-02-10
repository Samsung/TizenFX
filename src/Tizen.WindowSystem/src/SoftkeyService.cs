/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.Common;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen softkey service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyService : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.SoftkeyServiceHandle _softkeyService;
        int _tzshWin;
        bool disposed = false;

        Interop.SoftkeyService.SoftkeyVisibleEventCallback _onVisibleChanged;
        Interop.SoftkeyService.SoftkeyExpandEventCallback _onExpandChanged;
        Interop.SoftkeyService.SoftkeyOpacityEventCallback _onOpacityChanged;
        
        event EventHandler<SoftkeyVisibleChangedEventArgs> _visibleChanged;
        event EventHandler<SoftkeyExpandChangedEventArgs> _expandChanged;
        event EventHandler<SoftkeyOpacityChangedEventArgs> _opacityChanged;

        /// <summary>
        /// Creates a new Softkey Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the quickpanel service.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public SoftkeyService(TizenShell tzShell, IWindowProvider win)
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
            _softkeyService = Interop.SoftkeyService.Create(_tzsh.SafeHandle, (uint)_tzshWin);
            if (_softkeyService.IsInvalid)
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
                    _softkeyService?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Emits the event when the visible state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyVisibleChangedEventArgs> VisibleChanged
        {
            add
            {
                if (_visibleChanged == null)
                {
                    _onVisibleChanged = OnVisibleChanged;
                    int res = Interop.SoftkeyService.SetVisibleEventHandler(_softkeyService, _onVisibleChanged, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
                _visibleChanged += value;
            }
            remove
            {
                _visibleChanged -= value;
                if (_visibleChanged == null)
                {
                    int res = Interop.SoftkeyService.SetVisibleEventHandler(_softkeyService, null, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the expand state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyExpandChangedEventArgs> ExpandChanged
        {
            add
            {
                if (_expandChanged == null)
                {
                    _onExpandChanged = OnExpandChanged;
                    int res = Interop.SoftkeyService.SetExpandEventHandler(_softkeyService, _onExpandChanged, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
                _expandChanged += value;
            }
            remove
            {
                _expandChanged -= value;
                if (_expandChanged == null)
                {
                    int res = Interop.SoftkeyService.SetExpandEventHandler(_softkeyService, null, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the opacity state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyOpacityChangedEventArgs> OpacityChanged
        {
            add
            {
                if (_opacityChanged == null)
                {
                    _onOpacityChanged = OnOpacityChanged;
                    int res = Interop.SoftkeyService.SetOpacityEventHandler(_softkeyService, _onOpacityChanged, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res, "Unknown Error");
                }
                _opacityChanged += value;
            }
            remove
            {
                _opacityChanged -= value;
                if (_opacityChanged == null)
                {
                    int res = Interop.SoftkeyService.SetOpacityEventHandler(_softkeyService, null, IntPtr.Zero);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                }
            }
        }

        void OnVisibleChanged(IntPtr data, IntPtr softkeyService, int visible)
        {
            bool isVisible = (Interop.SoftkeyService.VisibleState)visible == Interop.SoftkeyService.VisibleState.Show;
            _visibleChanged?.Invoke(this, new SoftkeyVisibleChangedEventArgs(isVisible));
        }

        void OnExpandChanged(IntPtr data, IntPtr softkeyService, int expand)
        {
            bool isExpandable = (Interop.SoftkeyService.ExpandState)expand == Interop.SoftkeyService.ExpandState.On;
            _expandChanged?.Invoke(this, new SoftkeyExpandChangedEventArgs(isExpandable));
        }

        void OnOpacityChanged(IntPtr data, IntPtr softkeyService, int opacity)
        {
            bool isOpaque = (Interop.SoftkeyService.OpacityState)opacity == Interop.SoftkeyService.OpacityState.Opaque;
            _opacityChanged?.Invoke(this, new SoftkeyOpacityChangedEventArgs(isOpaque));
        }

        /// <summary>
        /// Requests to show the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Show()
        {
            int res = Interop.SoftkeyService.Show(_softkeyService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to hide the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Hide()
        {
            int res = Interop.SoftkeyService.Hide(_softkeyService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }
    }
}
