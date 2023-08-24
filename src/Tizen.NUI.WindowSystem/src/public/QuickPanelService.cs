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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen quickpanel service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class QuickPanelService : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _tzshQpService;
        private int _tzshWin;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        /// <summary>
        /// QuickPanel Type.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// Unknown type. There is no quickpanel service.
            /// </summary>
            Unknown = 0x0,
            /// <summary>
            /// System default type.
            /// </summary>
            SystemDefault = 0x1,
            /// <summary>
            /// Context menu type.
            /// </summary>
            ContextMenu = 0x2,
            /// <summary>
            /// Apps menu type.
            /// </summary>
            AppsMenu = 0x3,
        }

        /// <summary>
        /// Effect type.
        /// </summary>
        public enum EffectType
        {
            /// <summary>
            /// Swipe effect
            /// </summary>
            Swipe = 0,
            /// <summary>
            /// Move effect
            /// </summary>
            Move = 1,
            /// <summary>
            /// App control effect
            /// </summary>
            Custom = 2,
        }

        /// <summary>
        /// Creates a new Quickpanel Service handle.
        /// </summary>
        /// <param name="tzShell">The TzShell instance.</param>
        /// <param name="win">The window to provide service of the quickpanel.</param>
        /// <param name="type">The type of quickpanel service.</param>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public QuickPanelService(TizenShell tzShell, Window win, Types type)
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
            _tzshQpService = Interop.QuickPanelService.CreateWithType(_tzsh.GetNativeHandle(), (IntPtr)_tzshWin, (int)type);
            if (_tzshQpService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        ~QuickPanelService()
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
        /// <exception cref="MemberAccessException">Thrown when private memeber is a corrupted.</exception>
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
        protected virtual void Dispose(DisposeTypes disposing)
        {
            int res;
            if (!disposed)
            {
                if (_tzshQpService != IntPtr.Zero)
                {
                    res = Interop.QuickPanelService.Destroy(_tzshQpService);
                    try
                    {
                        _tzsh.ErrorCodeThrow(res);
                    }
                    catch (ArgumentException)
                    {
                        throw new MemberAccessException("QuickPanelService is a corrupted");
                    }
                    _tzshQpService = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Gets the type of the quickpanel service handle.
        /// </summary>
        /// <returns>The type of the quickpanel service handle</returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public Types ServiceType
        {
            get
            {
                return GetType();
            }
        }

        private new Types GetType()
        {
            int res;
            int type;

            res = Interop.QuickPanelService.GetType(_tzshQpService, out type);

            _tzsh.ErrorCodeThrow(res);

            return (Types)type;
        }

        /// <summary>
        /// Requests to show the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Show()
        {
            int res;

            res = Interop.QuickPanelService.Show(_tzshQpService);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to hide the quickpanel service window.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Hide()
        {
            int res;

            res = Interop.QuickPanelService.Hide(_tzshQpService);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Sets the content region of the quickpanel service handle.
        /// </summary>
        /// <param name="angle">The angle setting the region</param>
        /// <param name="region">The region of the content</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void SetContentRegion(uint angle, TizenRegion region)
        {
            int res;

            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            res = Interop.QuickPanelService.SetContentRegion(_tzshQpService, angle, region.GetNativeHandle());
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Sets the handler region of the quickpanel service handle.
        /// </summary>
        /// <param name="angle">The angle setting the region</param>
        /// <param name="region">The region of the content</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void SetHandlerRegion(uint angle, TizenRegion region)
        {
            int res;

            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            res = Interop.QuickPanelService.SetHandlerRegion(_tzshQpService, angle, region.GetNativeHandle());
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to change the effect of animation.
        /// </summary>
        /// <param name="type">The type of effect, enumeration for effect type.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetEffectType(EffectType type)
        {
            int res;

            res = Interop.QuickPanelService.SetEffectType(_tzshQpService, (int)type);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Requests to lock/unlock scrolling the quickpanel service window.
        /// </summary>
        /// <param name="locked">The scroll lock state</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void LockScroll(bool locked)
        {
            int res;

            res = Interop.QuickPanelService.LockScroll(_tzshQpService, locked);
            _tzsh.ErrorCodeThrow(res);
        }
    }
}
