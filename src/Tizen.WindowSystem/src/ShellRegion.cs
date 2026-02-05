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

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Tizen Window System Shell.
    /// This is a basic handle class for others in WsShell.
    /// Others class in WsShell using this basic class to use TIzen Window System Shell.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ShellRegion : IDisposable
    {
        TizenShell _tzsh;
        SafeHandles.ShellRegionHandle _region;
        bool disposed = false;

        /// <summary>
        /// Creates a new Tizen region object.
        /// </summary>
        /// <param name="tzShell">The TzShell instance.</param>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public ShellRegion(TizenShell tzShell)
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
            _region = Interop.TizenShellRegion.Create(_tzsh.SafeHandle);
            if (_region.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                _tzsh.ThrowIfError(err);
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
                    _region?.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Adds the rectangle to the region.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="w">The width</param>
        /// <param name="h">The height</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Add(int x, int y, int w, int h)
        {
            int res;

            res = Interop.TizenShellRegion.Add(_region, x, y, w, h);
            _tzsh.ThrowIfError(res);
        }

        /// <summary>
        /// Substracts the rectangle to the tizen region.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="w">The width</param>
        /// <param name="h">The height</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void Subtract(int x, int y, int w, int h)
        {
            int res;

            res = Interop.TizenShellRegion.Subtract(_region, x, y, w, h);
            _tzsh.ThrowIfError(res);
        }

        internal IntPtr GetNativeHandle()
        {
            return _region?.DangerousGetHandle() ?? IntPtr.Zero;
        }
    }
}
