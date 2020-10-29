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
using System.Runtime.Serialization;
using System.Text;
using Tizen.Applications.Exceptions;

namespace Tizen.NUI.WindowSystem.Shell
{
    /// <summary>
    /// Tizen Window System Shell.
    /// This is a basic handle class for others in WsShell.
    /// Others class in WsShell using this basic class to use TIzen Window System Shell.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class TizenShell : IDisposable
    {
        private IntPtr _tzsh;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        internal void ErrorCodeThrow(int error)
        {
            if (error == (int)Interop.TizenShell.ErrorCode.None)
            {
                return;
            }
            else if (error == (int)Interop.TizenShell.ErrorCode.OutOfMemory)
            {
                throw new Tizen.Applications.Exceptions.OutOfMemoryException("Out of Memory");
            }
            else if (error == (int)Interop.TizenShell.ErrorCode.InvalidParameter)
            {
                throw new ArgumentException("Invalid Parameter");
            }
            else if (error == (int)Interop.TizenShell.ErrorCode.PermissionDenied)
            {
                throw new PermissionDeniedException("Permission denied");
            }
            else if (error == (int)Interop.TizenShell.ErrorCode.NotSupported)
            {
                throw new NotSupportedException("Not Supported");
            }
            else if (error == (int)Interop.TizenShell.ErrorCode.NoService)
            {
                throw new InvalidOperationException("No Service");
            }
            else
            {
                throw new InvalidOperationException("Unknown Error");
            }
        }

        /// <summary>
        /// Creates a new Tizen Shell handle.
        /// </summary>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <since_tizen> 8 </since_tizen>
        public TizenShell()
        {
            _tzsh = Interop.TizenShell.Create((int)Interop.TizenShell.ToolKitType.Efl);
            if (_tzsh == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorCodeThrow(err);
            }
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        ~TizenShell()
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
        /// <since_tizen> 8 </since_tizen>
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
            int res;

            if (!disposed)
            {
                if (_tzsh != IntPtr.Zero)
                {
                    res = Interop.TizenShell.Destroy(_tzsh);
                    try
                    {
                        ErrorCodeThrow(res);
                    }
                    catch (ArgumentException)
                    {
                        throw new MemberAccessException("TizehShell is a corrupted");
                    }
                    _tzsh = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        internal IntPtr GetNativeHandle()
        {
            return _tzsh;
        }
    }
}
