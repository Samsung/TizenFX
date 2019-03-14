/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// Represents a wrapper class for a unmanaged Account handle.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public sealed class SafeAccountHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeAppControlHandle class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public SafeAccountHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SafeAccountHandle class.
        /// </summary>
        /// <param name="existingHandle">An IntPtr object that represents the pre-existing handle to use.</param>
        /// <param name="ownsHandle">true to reliably release the handle during the finalization phase; false to prevent reliable release.</param>
        /// <since_tizen> 4 </since_tizen>
        public SafeAccountHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(existingHandle);
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.Account.Destroy(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
