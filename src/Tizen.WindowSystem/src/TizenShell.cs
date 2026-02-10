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
using Tizen.Applications.Exceptions;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Basic handle of Tizen Window System Shell.
    /// </summary>
    /// <remarks>
    /// This class is a basic handle class for other class in Tizen Window System Shell.
    /// TizenShell serves as the entry point for interacting with the other subclass of Tizen Window System Shell.
    /// </remarks>
    /// <since_tizen> 8 </since_tizen>
    public class TizenShell : IDisposable
    {
        SafeHandles.TizenShellHandle _tizenShell;
        bool disposed = false;

        /// <summary>
        /// The constructor of TizenShell class.
        /// </summary>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public TizenShell()
        {
            _tizenShell = Interop.TizenShell.Create((int)Interop.TizenShell.ToolKitType.Efl);
            if (_tizenShell.IsInvalid)
            {
                int error = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                Tizen.WindowSystem.ErrorUtils.ThrowIfError(error, "Unknown Error");
            }
        }

        /// <summary>
        /// Dispose the TizenShell instance explicitly.
        /// </summary>
        /// <exception cref="MemberAccessException">Thrown when private memeber is a corrupted.</exception>
        /// <since_tizen> 8 </since_tizen>
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
                    _tizenShell?.Dispose();
                }
                disposed = true;
            }
        }

        internal SafeHandles.TizenShellHandle SafeHandle
        {
            get { return _tizenShell; }
        }
    }
}
