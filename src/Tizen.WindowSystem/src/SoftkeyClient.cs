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
    /// Class for the Tizen softkey client.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SoftkeyClient : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.SoftkeyClientHandle _softkeyClient;
        int _tzshWin;
        bool disposed = false;

        /// <summary>
        /// Creates a new Softkey Client handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the quickpanel service.</param>
        /// <privilege>http://tizen.org/privilege/windowsystem.admin</privilege>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation or no service.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have privilege to use this method.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 12 </since_tizen>        
        public SoftkeyClient(TizenShell tzShell, IWindowProvider win)
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
            _tzshWin = WindowSystem.Interop.EcoreWl2.GetWindowId(win.WindowHandle);
            _softkeyClient = Interop.SoftkeyClient.Create(_tzsh.SafeHandle, (uint)_tzshWin);
            if (_softkeyClient.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ThrowIfError(err);
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
                    _softkeyClient?.Dispose();
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
        public SoftkeyVisibility Visibility
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
        public SoftkeyExpandMode ExpandMode
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
        public SoftkeyOpacity Opacity
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
            _tzsh.ThrowIfError(res);
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
            _tzsh.ThrowIfError(res);
        }

        SoftkeyVisibility GetVisible()
        {
            int res = Interop.SoftkeyClient.GetVisibleState(_softkeyClient, out int vis);

            _tzsh.ThrowIfError(res);

            return (SoftkeyVisibility)vis;
        }

        SoftkeyExpandMode GetExpand()
        {
            int res = Interop.SoftkeyClient.GetExpandState(_softkeyClient, out int expand);

            _tzsh.ThrowIfError(res);

            return (SoftkeyExpandMode)expand;
        }

        void SetExpand(SoftkeyExpandMode expand)
        {
            int res = Interop.SoftkeyClient.SetExpandState(_softkeyClient, expand);

            _tzsh.ThrowIfError(res);
        }

        SoftkeyOpacity GetOpacity()
        {
            int res = Interop.SoftkeyClient.GetOpacityState(_softkeyClient, out int opacity);

            _tzsh.ThrowIfError(res);

            return (SoftkeyOpacity)opacity;
        }

        void SetOpacity(SoftkeyOpacity opacity)
        {
            int res = Interop.SoftkeyClient.SetOpacityState(_softkeyClient, opacity);

            _tzsh.ThrowIfError(res);
        }
    }
}
