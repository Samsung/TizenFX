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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Class that represents a PKCS#12 contents.
    /// It has a private key or its certificate or all the members of a chain of trust.
    /// </summary>
    public class Pkcs12 : SafeHandle
    {
        /// <summary>
        /// Creates a new Pkcs12from a given PKCS#12 file and returns it.
        /// </summary>
        /// <param name="filePath">The path of PKCS12 file to be loaded.</param>
        /// <param name="filePassword">The passphrase used to decrypt the PCKS12 file.
        /// If PKCS12 file is not encrypted, passphrase can be null.</param>
        static public Pkcs12 LoadPkcs12(string filePath, string filePassword)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcTypes.Pkcs12Load(filePath, filePassword, out ptr);
            Interop.CheckNThrowException(ret, "Failed to load PKCS12. file=" + filePath);

            return new Pkcs12(ptr);
        }

        /// <summary>
        /// A constructor of Key that takes a private key.
        /// </summary>
        /// <param name="privateKey">A private key.</param>
        public Pkcs12(Key privateKey) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);

            this.PrivateKey = privateKey;
            this.Certificate = null;
            this.CaChain = null;
        }

        /// <summary>
        /// A constructor of Key that takes a private key and its corresponding certicate.
        /// </summary>
        /// <param name="privateKey">A private key.</param>
        /// <param name="certificate">A certificate corresponding the private key</param>
        public Pkcs12(Key privateKey, Certificate certificate) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);

            this.PrivateKey = privateKey;
            this.Certificate = certificate;
            this.CaChain = null;
        }

        /// <summary>
        /// A constructor of Key that takes a private key, its corresponding certicate, and CA's certificate chain.
        /// </summary>
        /// <param name="privateKey">A private key.</param>
        /// <param name="certificate">A certificate corresponding the private key</param>
        /// <param name="caChain">A certificate chain of CA(Certificate Authority) that issued the certificate.</param>
        public Pkcs12(Key privateKey, Certificate certificate, IEnumerable<Certificate> caChain) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);

            this.PrivateKey = privateKey;
            this.Certificate = certificate;
            this.CaChain = caChain;
        }

        internal Pkcs12(IntPtr ptrCkmcPkcs12, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            this.SetHandle(ptrCkmcPkcs12);

            CkmcPkcs12 ckmcPkcs12 = (CkmcPkcs12)Marshal.PtrToStructure(handle, typeof(CkmcPkcs12));
            this.PrivateKey = new Key(ckmcPkcs12.privateKey, false);
            if (ckmcPkcs12.certificate != IntPtr.Zero)
                this.Certificate = new Certificate(ckmcPkcs12.certificate, false);
            if (ckmcPkcs12.caChain != IntPtr.Zero)
                this.CaChain = new SafeCertificateListHandle(ckmcPkcs12.caChain, false).Certificates;
        }

        /// <summary>
        /// A private key.
        /// </summary>
        public Key PrivateKey
        {
            get; set;
        }

        /// <summary>
        /// A certificate corresponding the private key.
        /// </summary>
        public Certificate Certificate
        {
            get; set;
        }

        /// <summary>
        /// A certificate chain of CA(Certificate Authority) that issued the certificate.
        /// </summary>
        public IEnumerable<Certificate> CaChain
        {
            get; set;
        }

        internal CkmcPkcs12 ToCkmcPkcs12()
        {
            Interop.CkmcKey ckmcKey = new Interop.CkmcKey(new PinnedObject(PrivateKey.Binary),
                                            PrivateKey.Binary.Length,
                                            (int)PrivateKey.Type,
                                            new PinnedObject(PrivateKey.BinaryPassword));
            Interop.CkmcCert ckmcCert = new Interop.CkmcCert(new PinnedObject(Certificate.Binary),
                                            Certificate.Binary.Length,
                                            (int)Certificate.Format);
            SafeCertificateListHandle ckmcCaCerts = new SafeCertificateListHandle(CaChain);

            return new Interop.CkmcPkcs12(new PinnedObject(ckmcKey),
                                            new PinnedObject(ckmcCert),
                                            ckmcCaCerts.ToCkmcCertificateListPtr());
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

            Interop.CkmcTypes.Pkcs12Free(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
