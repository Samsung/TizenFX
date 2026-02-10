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
    /// Class for the Tizen quickpanel service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class QuickPanelService : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.QuickPanelServiceHandle _tzshQpService;
        int _tzshWin;
        bool disposed = false;
        QuickPanelEffect _currentEffect;
        bool _isLocked;

        /// <summary>
        /// Creates a new Quickpanel Service handle.
        /// </summary>
        /// <param name="tzShell">The TzShell instance.</param>
        /// <param name="win">The window provider for the quickpanel service.</param>
        /// <param name="type">The type of quickpanel service.</param>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public QuickPanelService(TizenShell tzShell, IWindowProvider win, QuickPanelCategory type)
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
            _tzshQpService = Interop.QuickPanelService.CreateWithType(_tzsh.SafeHandle, (uint)_tzshWin, type);
            if (_tzshQpService.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(err);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <exception cref="MemberAccessException">Thrown when private memeber is a corrupted.</exception>
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
                    _tzshQpService?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Gets or sets the effect type of the quickpanel service.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public QuickPanelEffect Effect
        {
            get
            {
                return _currentEffect;
            }
            set
            {
                int res = Interop.QuickPanelService.SetEffectType(_tzshQpService, value);
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                _currentEffect = value;
            }
        }

        /// <summary>
        /// Gets or sets whether scrolling is locked for the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                int res = Interop.QuickPanelService.LockScroll(_tzshQpService, value);
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                _isLocked = value;
            }
        }

        /// <summary>
        /// Gets the type of the quickpanel service handle.
        /// </summary>
        /// <returns>The type of the quickpanel service handle</returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public QuickPanelCategory ServiceType
        {
            get
            {
                return GetServiceType();
            }
        }

        QuickPanelCategory GetServiceType()
        {
            int res;
            int type;

            res = Interop.QuickPanelService.GetType(_tzshQpService, out type);

            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);

            return (QuickPanelCategory)type;
        }

        /// <summary>
        /// Requests to show the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Show()
        {
            int res;

            res = Interop.QuickPanelService.Show(_tzshQpService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Requests to hide the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Hide()
        {
            int res;

            res = Interop.QuickPanelService.Hide(_tzshQpService);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Sets the content region of the quickpanel service.
        /// </summary>
        /// <param name="angle">The angle setting the region</param>
        /// <param name="region">The region of the content</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void SetContentRegion(uint angle, ShellRegion region)
        {
            int res;

            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            res = Interop.QuickPanelService.SetContentRegion(_tzshQpService, angle, region.SafeHandle);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }

        /// <summary>
        /// Sets the handler region of the quickpanel service.
        /// </summary>
        /// <param name="angle">The angle setting the region</param>
        /// <param name="region">The region of the content</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void SetHandlerRegion(uint angle, ShellRegion region)
        {
            int res;

            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            res = Interop.QuickPanelService.SetHandlerRegion(_tzshQpService, angle, region.SafeHandle);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }
    }
}
