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
        TizenShell _tzsh;
        SafeHandles.TaskbarServiceHandle _taskbarService;
        TaskbarPosition _taskbarPosition;
        int _tzshWin;
        bool disposed = false;

        /// <summary>
        /// Creates a new Taskbar Service handle.
        /// </summary>
        /// <param name="tzShell">The TizenShell instance.</param>
        /// <param name="win">The window provider for the taskbar service.</param>
        /// <param name="position">The selected, predefined location on the screen the Taskbar should be placed on the screen.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public TaskbarService(TizenShell tzShell, IWindowProvider win, TaskbarPosition position = TaskbarPosition.Bottom)
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
            _taskbarService = Interop.TaskbarService.Create(_tzsh.SafeHandle, (uint)_tzshWin);
            if (_taskbarService.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(err);
            }

            Position = position;
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
                    _taskbarService?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Gets or sets the current place type.
        /// The window manager can use this to determine the geometry of another applications.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public TaskbarPosition Position
        {
            get => _taskbarPosition;
            set
            {
                if (_taskbarPosition != value)
                {
                    int res = Interop.TaskbarService.SetPlaceType(_taskbarService, value);
                    Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
                    _taskbarPosition = value;
                }
            }
        }

        /// <summary>
        /// Set the size of the taskbar.
        /// This may be different from the actual size. The window manager can use this to  
        /// determine the geometry of another applications.
        /// </summary>
        /// <param name="width">The width of the taskbar area.</param>
        /// <param name="height">The height of the taskbar area.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>		
        public void SetSize(int width, int height)
        {
            int res;

            res = Interop.TaskbarService.SetSize(_taskbarService, width, height);
            Tizen.WindowSystem.ErrorUtils.ThrowIfError(res);
        }
    }
}
