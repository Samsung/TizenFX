/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tizen.Network.Stc
{
    /// <summary>
    /// A class for managing the Stc handle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class SafeStcHandle : SafeHandle
    {
        internal SafeStcHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Checks the validity of the handle.
        /// </summary>
        /// <value>Represents the validity of the handle.</value>
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        protected override bool ReleaseHandle()
        {
            Interop.Stc.Deinitialize(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }

    /// <summary>
    /// A class which is used to manage Smart Traffic control (Stc).<br/>
    /// </summary>
    internal static class StcManager
    {
        /// <summary>
        /// Gets the Stc safe handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The instance of the SafeStcHandle.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        internal static SafeStcHandle GetStcHandle()
        {
            return StcManagerImpl.Instance.GetSafeHandle();
        }
    }
}
