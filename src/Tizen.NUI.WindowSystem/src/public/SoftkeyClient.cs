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
    /// Class for the Tizen softkey client.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyClient : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _softkeyClient;
        private int _tzshWin;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        /// <summary>
        /// Creates a new Softkey Client handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the quickpanel.</param>
        /// <privilege>http://tizen.org/privilege/windowsystem.admin</privilege>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have privilege to use this method.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public SoftkeyClient(TizenShell tzShell, Window win)
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
            _softkeyClient = Interop.SoftkeyClient.Create(_tzsh.GetNativeHandle(), (IntPtr)_tzshWin);
            if (_softkeyClient == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~SoftkeyClient()
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
                if (_softkeyClient != IntPtr.Zero)
                {
                    int res = Interop.SoftkeyClient.Destroy(_softkeyClient);
                    _softkeyClient = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Gets the visible state of a softkey service window.
        /// </summary>
        /// <returns>The visible state of the softkey service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        public SoftkeyVisibleState Visible
        {
            get
            {
                return GetVisible();
            }
        }

        /// <summary>
        /// Gets the expand state of a softkey service window.
        /// </summary>
        /// <returns>The expand state of the softkey service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        public SoftkeyExpandState Expand
        {
            get
            {
                return GetExpand();
            }
            set
            {
                SetExpand(value);
            }
        }

        /// <summary>
        /// Gets the opacity state of a softkey service window.
        /// </summary>
        /// <returns>The opacity state of the softkey service window.</returns>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        public SoftkeyOpacityState Opacity
        {
            get
            {
                return GetOpacity();
            }
            set
            {
                SetOpacity(value);
            }
        }

        /// <summary>
        /// Requests to show the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        public void Show()
        {
            int res = Interop.SoftkeyClient.Show(_softkeyClient);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to hide the softkey service window.
        /// </summary>
        /// <exception cref="ArgumentException" > Thrown when failed of invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        public void Hide()
        {
            int res = Interop.SoftkeyClient.Hide(_softkeyClient);
            _tzsh.ErrorCodeThrow(res);
        }

        private SoftkeyVisibleState GetVisible()
        {
            int res = Interop.SoftkeyClient.GetVisibleState(_softkeyClient, out int vis);

            _tzsh.ErrorCodeThrow(res);

            return ChangeVisibleStateToPublic((Interop.SoftkeyClient.VisibleState)vis);
        }

        private SoftkeyExpandState GetExpand()
        {
            int res = Interop.SoftkeyClient.GetExpandState(_softkeyClient, out int expand);

            _tzsh.ErrorCodeThrow(res);

            return ChangeExpandStateToPublic((Interop.SoftkeyClient.ExpandState)expand);
        }

        private void SetExpand(SoftkeyExpandState expand)
        {
            int res = Interop.SoftkeyClient.SetExpandState(_softkeyClient, (int)(ChangeExpandStateToInternal(expand)));

            _tzsh.ErrorCodeThrow(res);
        }

        private SoftkeyOpacityState GetOpacity()
        {
            int res = Interop.SoftkeyClient.GetOpacityState(_softkeyClient, out int opacity);

            _tzsh.ErrorCodeThrow(res);

            return ChangeOpacityStateToPublic((Interop.SoftkeyClient.OpacityState)opacity);
        }

        private void SetOpacity(SoftkeyOpacityState opacity)
        {
            int res = Interop.SoftkeyClient.SetOpacityState(_softkeyClient, (int)(ChangeOpacityStateToInternal(opacity)));

            _tzsh.ErrorCodeThrow(res);
        }

        private SoftkeyVisibleState ChangeVisibleStateToPublic(Interop.SoftkeyClient.VisibleState state)
        {
            if (state == Interop.SoftkeyClient.VisibleState.Shown)
                return SoftkeyVisibleState.Shown;
            else if (state == Interop.SoftkeyClient.VisibleState.Hidden)
                return SoftkeyVisibleState.Hidden;
            else
                return SoftkeyVisibleState.Unknown;
        }

        private Interop.SoftkeyClient.VisibleState ChangeVisibleStateToInternal(SoftkeyVisibleState state)
        {
            if (state == SoftkeyVisibleState.Shown)
                return Interop.SoftkeyClient.VisibleState.Shown;
            else if (state == SoftkeyVisibleState.Hidden)
                return Interop.SoftkeyClient.VisibleState.Hidden;
            else
                return Interop.SoftkeyClient.VisibleState.Unknown;
        }

        private SoftkeyExpandState ChangeExpandStateToPublic(Interop.SoftkeyClient.ExpandState state)
        {
            if (state == Interop.SoftkeyClient.ExpandState.On)
                return SoftkeyExpandState.On;
            else if (state == Interop.SoftkeyClient.ExpandState.Off)
                return SoftkeyExpandState.Off;
            else
                return SoftkeyExpandState.Unknown;
        }

        private Interop.SoftkeyClient.ExpandState ChangeExpandStateToInternal(SoftkeyExpandState state)
        {
            if (state == SoftkeyExpandState.On)
                return Interop.SoftkeyClient.ExpandState.On;
            else if (state == SoftkeyExpandState.Off)
                return Interop.SoftkeyClient.ExpandState.Off;
            else
                return Interop.SoftkeyClient.ExpandState.Unknown;
        }

        private SoftkeyOpacityState ChangeOpacityStateToPublic(Interop.SoftkeyClient.OpacityState state)
        {
            if (state == Interop.SoftkeyClient.OpacityState.Opaque)
                return SoftkeyOpacityState.Opaque;
            else if (state == Interop.SoftkeyClient.OpacityState.Transparent)
                return SoftkeyOpacityState.Transparent;
            else
                return SoftkeyOpacityState.Unknown;
        }

        private Interop.SoftkeyClient.OpacityState ChangeOpacityStateToInternal(SoftkeyOpacityState state)
        {
            if (state == SoftkeyOpacityState.Opaque)
                return Interop.SoftkeyClient.OpacityState.Opaque;
            else if (state == SoftkeyOpacityState.Transparent)
                return Interop.SoftkeyClient.OpacityState.Transparent;
            else
                return Interop.SoftkeyClient.OpacityState.Unknown;
        }
    }
}
