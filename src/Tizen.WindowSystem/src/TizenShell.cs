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
    [EditorBrowsable(EditorBrowsableState.Never)]
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
#if BUILD_TCORE_ENABLE
            _tizenShell = Interop.TizenShell.Create((int)Interop.TizenShell.ToolKitType.TcoreWayland);
#else
            _tizenShell = Interop.TizenShell.Create((int)Interop.TizenShell.ToolKitType.Efl);
#endif
            if (_tizenShell.IsInvalid)
            {
                int error = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(error, "Unknown Error");
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

        internal int GetWindowId(IntPtr window)
        {
#if BUILD_TCORE_ENABLE
            int result = global::Tizen.WindowSystem.Interop.TizenCoreWl.WindowGetNativeSurface(window, out IntPtr surface);
            ErrorUtils.ThrowIfError(result, "Failed to get native window surface");
            if (surface == IntPtr.Zero)
                throw new InvalidOperationException("Failed to get native window surface");

            uint id = global::Tizen.WindowSystem.Interop.TizenCoreWl.ProxyGetId(surface);
            if (id == 0)
                throw new InvalidOperationException("Native window surface has no Wayland object ID");

            return unchecked((int)id);
#else
            return global::Tizen.WindowSystem.Interop.EcoreWl2.GetWindowId(window);
#endif
        }

        internal void GetWindowScreenSize(IntPtr window, out int width, out int height)
        {
#if BUILD_TCORE_ENABLE
            width = 0;
            height = 0;

            int result = global::Tizen.WindowSystem.Interop.TizenCoreWl.WindowGetDisplay(window, out IntPtr display);
            ErrorUtils.ThrowIfError(result, "Failed to get window display");
            if (display == IntPtr.Zero)
            {
                return;
            }

            // Output handles are borrowed; only the returned GList nodes are freed below.
            IntPtr outputList = IntPtr.Zero;
            try
            {
                result = global::Tizen.WindowSystem.Interop.TizenCoreWl.DisplayGetOutputDeviceList(display, out outputList);
                ErrorUtils.ThrowIfError(result, "Failed to get display output devices");
                if (outputList == IntPtr.Zero)
                {
                    return;
                }

                global::Tizen.WindowSystem.Interop.TizenCoreWl.GList firstOutput = global::System.Runtime.InteropServices.Marshal.PtrToStructure<global::Tizen.WindowSystem.Interop.TizenCoreWl.GList>(outputList);
                if (firstOutput.Data != IntPtr.Zero)
                {
                    result = global::Tizen.WindowSystem.Interop.TizenCoreWl.OutputDeviceGetGeometry(firstOutput.Data, out width, out height);
                    ErrorUtils.ThrowIfError(result, "Failed to get output geometry");
                }
            }
            finally
            {
                if (outputList != IntPtr.Zero)
                {
                    global::Tizen.WindowSystem.Interop.TizenCoreWl.GListFree(outputList);
                }
            }
#else
            width = 0;
            height = 0;
            IntPtr display = global::Tizen.WindowSystem.Interop.EcoreWl2.GetDisplay(window);
            if (display != IntPtr.Zero)
            {
                global::Tizen.WindowSystem.Interop.EcoreWl2.GetScreenSize(display, out width, out height);
            }
#endif
        }
    }
}
