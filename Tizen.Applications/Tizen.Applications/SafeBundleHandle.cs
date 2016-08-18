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
    /// <summary>
    /// Represents a wrapper class for a unmanaged Bundle handle.
    /// </summary>
    public sealed class SafeBundleHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeBundleHandle class.
        /// </summary>
        public SafeBundleHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SafeBundleHandle class.
        /// </summary>
        /// <param name="existingHandle">An IntPtr object that represents the pre-existing handle to use.</param>
        /// <param name="ownsHandle">true to reliably release the handle during the finalization phase; false to prevent reliable release.</param>
        public SafeBundleHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(existingHandle);
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
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
            Interop.Bundle.DangerousFree(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
