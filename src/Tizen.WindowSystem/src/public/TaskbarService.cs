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
using Tizen.Common;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Class for the Tizen taskbar service.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TaskbarService : IDisposable
    {
        private TizenShell _tzsh;
        private IntPtr _taskbarService;
        private int _tzshWin;
        private bool disposed = false;


        /// <summary>
        /// Enumeration for placed type of taskbar service window.
        /// </summary>
        public enum PlaceType
        {
            /// <summary>
            /// Place to Bottom of Screen. Default type.
            /// </summary>
            Bottom = 0x0,
            /// <summary>
            /// Place to Top of Screen.
            /// </summary>
            Top = 0x1,
            /// <summary>
            /// Place to Left Side of Screen.
            /// </summary>
            Left = 0x2,
            /// <summary>
            /// Place to Right Side of Screen.
            /// </summary>
            Right = 0x3,
        }

        /// <summary>
        /// Creates a new Taskbar Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window to provide service of the taskbar.</param>
        /// <param name="type">The type to be placed on the screen.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public TaskbarService(TizenShell tzShell, int win, PlaceType type = PlaceType.Bottom)
        {
            if (tzShell == null)
            {
                throw new ArgumentNullException(nameof(tzShell));
            }
            if (tzShell.GetNativeHandle() == IntPtr.Zero)
            {
                throw new ArgumentException("tzShell is not initialized.");
            }
            if (win < 0)
            {
                throw new ArgumentException("Invalid window ID");
            }

            _tzsh = tzShell;
            _tzshWin = win;
            _taskbarService = Interop.TaskbarService.Create(_tzsh.GetNativeHandle(), (uint)_tzshWin);
            if (_taskbarService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }

            Interop.TaskbarService.SetPlaceType(_taskbarService, (int)type);
        }

        /// <summary>
        /// Creates a new Taskbar Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the taskbar service.</param>
        /// <param name="type">The selected, predefined location on the screen the Taskbar should be placed on the screen.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public TaskbarService(TizenShell tzShell, IWindowProvider win, PlaceType type = PlaceType.Bottom)
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
            _taskbarService = Interop.TaskbarService.Create(_tzsh.GetNativeHandle(), (uint)_tzshWin);
            if (_taskbarService == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ErrorCodeThrow(err);
            }

            Interop.TaskbarService.SetPlaceType(_taskbarService, (int)type);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~TaskbarService()
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
                if (_taskbarService != IntPtr.Zero)
                {
                    int res = Interop.TaskbarService.Destroy(_taskbarService);
                    _taskbarService = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Set the current place type.
        /// The window manager can use this to determine the geometry of another applications.
        /// </summary>
        /// <param name="type">The type of placement, enumeration for the place type.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetPlaceType(PlaceType type)
        {
            int res;

            res = Interop.TaskbarService.SetPlaceType(_taskbarService, (int)type);
            _tzsh.ErrorCodeThrow(res);
        }

        /// <summary>
        /// Set the size of the taskbar.
        /// This may be different from the actual size. The window manager can use this to  
        /// determine the geometry of another applications.
        /// </summary>
        /// <param name="width">The width of the taskbar area.</param>
        /// <param name="height">The height of the taskbar area.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>		
        public void SetSize(uint width, uint height)
        {
            int res;

            res = Interop.TaskbarService.SetSize(_taskbarService, width, height);
            _tzsh.ErrorCodeThrow(res);
        }
    }
}
