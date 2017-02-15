/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    internal class SafePackageManagerRequestHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafePackageManagerRequestHandle class.
        /// </summary>
        public SafePackageManagerRequestHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// Executes the code required to free the SafePackageManagerRequestHandle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.PackageManager.PackageManagerRequestDestroy(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}