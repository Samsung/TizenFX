// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    internal class SafePackageManagerHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafePackageManagerHandle class.
        /// </summary>
        public SafePackageManagerHandle() : base(IntPtr.Zero, true)
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
        /// Executes the code required to free the SafePackageManagerHandle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.PackageManager.PackageManagerDestroy(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
