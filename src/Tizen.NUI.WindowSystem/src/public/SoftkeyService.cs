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

namespace Tizen.NUI.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen softkey service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyService : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _softkeyService;
        private int _tzshWin;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        private Interop.SoftkeyService.SoftkeyVisibleEventCallback _onVisibleChanged;
        private Interop.SoftkeyService.SoftkeyExpandEventCallback _onExpandChanged;
        private Interop.SoftkeyService.SoftkeyOpacityEventCallback _onOpacityChanged;
        
        private event EventHandler<SoftkeyVisibleState> _visibleChanged;        
        private event EventHandler<SoftkeyExpandState> _expandChanged;        
        private event EventHandler<SoftkeyOpacityState> _opacityChanged;

        /// <summary>
        /// Creates a new Softkey Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the quickpanel.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public SoftkeyService(TizenShell tzShell, Window win)
        {
            if (tzShell == null)
            {
                throw new ArgumentNullException(nameof(tzShell));
            }
            if (tzShell.GetNativeHandle() == IntPtr.Zero)
            {
                throw new ArgumentException("tzShell is not initialized.");
            }
            if (win == null)
            {
                throw new ArgumentNullException(nameof(win));
            }

            _tzsh = tzShell;
            _tzshWin = win.GetNativeId();
            _softkeyService = Interop.SoftkeyService.Create(_tzsh.GetNativeHandle(), (IntPtr)_tzshWin);
            if (_softkeyService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~SoftkeyService()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
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
            if (!disposed)
            {
                if (_softkeyService != IntPtr.Zero)
                {
                    int res = Interop.SoftkeyService.Destroy(_softkeyService);
                    _softkeyService = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Emits the event when the visible state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyVisibleState> VisibleChanged
        {
            add
            {
                if (_visibleChanged == null)
                {
                    _onVisibleChanged = OnVisibleChanged;
                    int res = Interop.SoftkeyService.SetVisibleEventHandler(_softkeyService, _onVisibleChanged, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
                _visibleChanged += value;
            }
            remove
            {
                _visibleChanged -= value;
                if (_visibleChanged == null)
                {
                    int res = Interop.SoftkeyService.SetVisibleEventHandler(_softkeyService, null, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the expand state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyExpandState> ExpandChanged
        {
            add
            {
                if (_expandChanged == null)
                {
                    _onExpandChanged = OnExpandChanged;
                    int res = Interop.SoftkeyService.SetExpandEventHandler(_softkeyService, _onExpandChanged, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
                _expandChanged += value;
            }
            remove
            {
                _expandChanged -= value;
                if (_expandChanged == null)
                {
                    int res = Interop.SoftkeyService.SetExpandEventHandler(_softkeyService, null, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the opacity state of the softkey service window is changed.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<SoftkeyOpacityState> OpacityChanged
        {
            add
            {
                if (_opacityChanged == null)
                {
                    _onOpacityChanged = OnOpacityChanged;
                    int res = Interop.SoftkeyService.SetOpacityEventHandler(_softkeyService, _onOpacityChanged, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
                _opacityChanged += value;
            }
            remove
            {
                _opacityChanged -= value;
                if (_opacityChanged == null)
                {
                    int res = Interop.SoftkeyService.SetOpacityEventHandler(_softkeyService, null, IntPtr.Zero);
                    _tzsh.ErrorCodeThrow(res);
                }
            }
        }

        private void OnVisibleChanged(IntPtr data, IntPtr softkeyService, int visible)
        {
            _visibleChanged?.Invoke(this, ChangeVisibleStateToPublic((Interop.SoftkeyService.VisibleState)visible));
        }

        private void OnExpandChanged(IntPtr data, IntPtr softkeyService, int expand)
        {
            _expandChanged?.Invoke(this, ChangeExpandStateToPublic((Interop.SoftkeyService.ExpandState)expand));
        }

        private void OnOpacityChanged(IntPtr data, IntPtr softkeyService, int opacity)
        {
            _opacityChanged?.Invoke(this, ChangeOpacityStateToPublic((Interop.SoftkeyService.OpacityState)opacity));
        }

        /// <summary>
        /// Requests to show the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Show()
        {
            int res = Interop.SoftkeyService.Show(_softkeyService);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to hide the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Hide()
        {
            int res = Interop.SoftkeyService.Hide(_softkeyService);
            _tzsh.ErrorCodeThrow(res);
        }

        private SoftkeyVisibleState ChangeVisibleStateToPublic(Interop.SoftkeyService.VisibleState state)
        {
            if (state == Interop.SoftkeyService.VisibleState.Show)
                return SoftkeyVisibleState.Shown;
            else
                return SoftkeyVisibleState.Hidden;
        }

        private Interop.SoftkeyService.VisibleState ChangeVisibleStateToInternal(SoftkeyVisibleState state)
        {
            if (state == SoftkeyVisibleState.Shown)
                return Interop.SoftkeyService.VisibleState.Show;
            else
                return Interop.SoftkeyService.VisibleState.Hide;
        }

        private SoftkeyExpandState ChangeExpandStateToPublic(Interop.SoftkeyService.ExpandState state)
        {
            if (state == Interop.SoftkeyService.ExpandState.On)
                return SoftkeyExpandState.On;
            else
                return SoftkeyExpandState.Off;
        }

        private Interop.SoftkeyService.ExpandState ChangeExpandStateToInternal(SoftkeyExpandState state)
        {
            if (state == SoftkeyExpandState.On)
                return Interop.SoftkeyService.ExpandState.On;
            else
                return Interop.SoftkeyService.ExpandState.Off;
        }

        private SoftkeyOpacityState ChangeOpacityStateToPublic(Interop.SoftkeyService.OpacityState state)
        {
            if (state == Interop.SoftkeyService.OpacityState.Opaque)
                return SoftkeyOpacityState.Opaque;
            else
                return SoftkeyOpacityState.Transparent;
        }

        private Interop.SoftkeyService.OpacityState ChangeOpacityStateToInternal(SoftkeyOpacityState state)
        {
            if (state == SoftkeyOpacityState.Opaque)
                return Interop.SoftkeyService.OpacityState.Opaque;
            else
                return Interop.SoftkeyService.OpacityState.Transparent;
        }
    }
}
