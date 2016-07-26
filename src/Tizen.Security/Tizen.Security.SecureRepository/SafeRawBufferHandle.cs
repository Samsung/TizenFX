using System;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeRawBufferHandle : SafeHandle
    {
        public SafeRawBufferHandle(IntPtr ptrRawBuffer, bool ownsHandle = true) : base(IntPtr.Zero, true)
        {
            this.SetHandle(ptrRawBuffer);

            if (ptrRawBuffer == IntPtr.Zero)
                return;

            CkmcRawBuffer buff = (CkmcRawBuffer)Marshal.PtrToStructure(ptrRawBuffer, typeof(CkmcRawBuffer));
            byte[] data = new byte[buff.size];
            Marshal.Copy(buff.data, data, 0, data.Length);

            this.Data = data;
        }

        public byte[] Data
        {
            get; set;
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            if (IsInvalid) // do not release
                return true;

            Interop.CkmcTypes.CkmcBufferFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
