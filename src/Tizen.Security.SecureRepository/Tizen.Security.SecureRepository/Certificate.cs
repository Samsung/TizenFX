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
    public class Certificate
    {
        /// <summary>
        /// Load Certificate from the given file path.
        /// </summary>
        /// <param name="filePath">The path of certificate file to be loaded.</param>
        /// <returns>Loaded certificate class instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// filePath should not be null
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Invalid certificate file format. Provided file path does not exist or
        /// cannot be accessed.
        /// </exception>
        static public Certificate Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filepath should not be null");

            IntPtr ptr = IntPtr.Zero;

            Interop.CheckNThrowException(
                CkmcTypes.LoadCertFromFile(filePath, out ptr),
                "Failed to load Certificate: " + filePath);

            return new Certificate(ptr);
        }

        /// <summary>
        /// A constructor of Certificate that takes the binary and its format.
        /// </summary>
        /// <param name="binary">The binary data of a certificate.</param>
        /// <param name="format">The format of the binary data.</param>
        public Certificate(byte[] binary, DataFormat format)
        {
            this.Binary = binary;
            this.Format = format;
        }

        internal Certificate(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException("Returned ptr from CAPI cannot be null");

            var ckmcCert = Marshal.PtrToStructure<CkmcCert>(ptr);
            this.Binary = new byte[(int)ckmcCert.size];
            Marshal.Copy(ckmcCert.rawCert, this.Binary, 0, this.Binary.Length);
            this.Format = (DataFormat)ckmcCert.dataFormat;
        }

        // Refresh handle(IntPtr) always. Because C# layer
        // properties(Binary, Format) could be changed.
        internal IntPtr GetHandle()
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                CheckNThrowException(
                    CkmcTypes.CertNew(
                        this.Binary, (UIntPtr)this.Binary.Length, (int)this.Format,
                        out ptr),
                    "Failed to create cert");

                return ptr;
            }
            catch
            {
                if (ptr != IntPtr.Zero)
                    CkmcTypes.CertFree(ptr);

                throw;
            }
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
            return new Interop.CkmcCert(
                (Binary == null) ? IntPtr.Zero : new PinnedObject(this.Binary),
                (Binary == null) ? 0 : this.Binary.Length,
                (int)Format);
        }
    }
}
