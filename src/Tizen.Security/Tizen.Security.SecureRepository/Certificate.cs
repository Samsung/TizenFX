using System;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Class that represents a certificate.
    /// </summary>
    public class Certificate : SafeHandle
    {
        /// <summary>
        /// A constructor of Certificate that takes the binary and its format.
        /// </summary>
        /// <param name="binary">The binary data of a certificate.</param>
        /// <param name="format">The format of the binary data.</param>
        public Certificate(byte[] binary, DataFormat format) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);
            Binary = binary;
            Format = format;
        }

        internal Certificate(IntPtr ptrCkmcCert, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            base.SetHandle(ptrCkmcCert);

            CkmcCert ckmcCert = (CkmcCert)Marshal.PtrToStructure(ptrCkmcCert, typeof(CkmcCert));
            Binary = new byte[ckmcCert.size];
            Marshal.Copy(ckmcCert.rawCert, Binary, 0, Binary.Length);
            Format = (DataFormat)ckmcCert.dataFormat;
        }

        /// <summary>
        /// The binary value of a certificate.
        /// </summary>
        public byte[] Binary
        {
            get; set;
        }

        /// <summary>
        /// The format of the binary value.
        /// </summary>
        public DataFormat Format
        {
            get; set;
        }

        internal CkmcCert ToCkmcCert()
        {
            return new Interop.CkmcCert(new PinnedObject(Binary), Binary.Length, (int)Format);
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
            Interop.CkmcTypes.CkmcCertFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
