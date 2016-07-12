using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a wrapper class for a unmanaged AppControl handle.
    /// </summary>
    public sealed class SafeAppControlHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeAppControlHandle class.
        /// </summary>
        public SafeAppControlHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SafeAppControlHandle class.
        /// </summary>
        /// <param name="existingHandle">An IntPtr object that represents the pre-existing handle to use.</param>
        /// <param name="ownsHandle">true to reliably release the handle during the finalization phase; false to prevent reliable release.</param>
        public SafeAppControlHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
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
            Interop.AppControl.DangerousDestroy(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
