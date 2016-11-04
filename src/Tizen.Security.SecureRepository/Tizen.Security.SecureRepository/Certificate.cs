/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

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
        /// Load Certificate from the given file path.
        /// </summary>
        /// <param name="filePath">The path of certificate file to be loaded.</param>
        /// <returns>Loaded certificate class instance.</returns>
        /// <exception cref="InvalidOperationException">Invalid certificate file format. Provided file path does not exist or cannot be accessed.</exception>
        static public Certificate Load(string filePath)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcTypes.LoadCertFromFile(filePath, out ptr);
            Interop.CheckNThrowException(ret, "Failed to load Certificate. file=" + filePath);

            return new Certificate(ptr);
        }

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

            CkmcCert ckmcCert = Marshal.PtrToStructure<CkmcCert>(ptrCkmcCert);
            Binary = new byte[(int)ckmcCert.size];
            Marshal.Copy(ckmcCert.rawCert, Binary, 0, Binary.Length);
            Format = (DataFormat)ckmcCert.dataFormat;
        }

        internal IntPtr GetHandle()
        {
            if (this.handle == IntPtr.Zero)
            {
                int ret = Interop.CkmcTypes.CertNew(this.Binary,
                                                    (UIntPtr)this.Binary.Length,
                                                    (int)this.Format,
                                                    out this.handle);
                Interop.CheckNThrowException(ret, "Failed to create cert");
            }

            return this.handle;
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
            byte[] bin = (Binary != null) ? Binary : new byte[0];
            return new Interop.CkmcCert(new PinnedObject(bin), bin.Length, (int)Format);
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
        /// <returns>true if the handle is released successfully.</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.CertFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
