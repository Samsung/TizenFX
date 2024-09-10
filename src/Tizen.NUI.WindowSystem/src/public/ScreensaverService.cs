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
using Tizen.Applications;

namespace Tizen.NUI.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen screensaver service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScreensaverService : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _screensaverService;
        private int _tzshWin;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        /// <summary>
        /// Creates a new Screensaver Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the screensaver.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        public ScreensaverService(TizenShell tzShell, Window win)
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
            _screensaverService = Interop.ScreensaverService.Create(_tzsh.GetNativeHandle(), (uint)_tzshWin);
            if (_screensaverService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Creates a new Screensaver Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the screensaver service.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        public ScreensaverService(TizenShell tzShell, IWindowProvider win)
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
            _screensaverService = Interop.ScreensaverService.Create(_tzsh.GetNativeHandle(), (uint)_tzshWin);
            if (_screensaverService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~ScreensaverService()
        {
            Dispose(disposing: false);
        }
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            if (disposed)
                return;

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ReleaseHandle(_screensaverService);
                }
                else
                {
                    var handle = _screensaverService;
                    CoreApplication.Post(() => ReleaseHandle(handle));
                }
                disposed = true;
            }
        }

        private void ReleaseHandle(IntPtr handle)
        {
            Interop.ScreensaverService.Destroy(handle);
        }
    }
}
