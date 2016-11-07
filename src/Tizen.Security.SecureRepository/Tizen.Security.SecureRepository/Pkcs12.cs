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
        private SafeCertificateListHandle _certChainHandle = null;

        /// <summary>
        /// Load Pkcs12 from the given PKCS#12 file path.
        /// </summary>
        /// <param name="filePath">The path of PKCS12 file to be loaded.</param>
        /// <param name="filePassword">The passphrase used to decrypt the PCKS12 file.
        /// If PKCS12 file is not encrypted, passphrase can be null.</param>
        /// <exception cref="ArgumentException">filePath is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// No file on filePath.
        /// No permission to access file.
        /// File is invalid PKCS12 format.
        /// File cannot be extracted with provided filePassword.
        /// </exception>
        static public Pkcs12 Load(string filePath, string filePassword)
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
            this.PrivateKey = privateKey;
            this.Certificate = null;
            this.CaChain = null;
        }

        /// <summary>
        /// A constructor of Key that takes a private key, its corresponding certicate,
        /// and CA's certificate chain.
        /// </summary>
        /// <param name="privateKey">A private key.</param>
        /// <param name="certificate">A certificate corresponding the private key</param>
        /// <param name="caChain">
        /// A certificate chain of CA(Certificate Authority) that issued the certificate.
        /// </param>
        public Pkcs12(Key privateKey,
                      Certificate certificate,
                      IEnumerable<Certificate> caChain) : base(IntPtr.Zero, true)
        {
            this.PrivateKey = privateKey;
            this.Certificate = certificate;
            this.CaChain = caChain;
        }

        internal Pkcs12(IntPtr ptr, bool ownsHandle = true) : base(ptr, ownsHandle)
        {
            var ckmcPkcs12 = Marshal.PtrToStructure<Interop.CkmcPkcs12>(ptr);

            this.PrivateKey = new Key(ckmcPkcs12.privateKey, false);
            if (ckmcPkcs12.certificate != IntPtr.Zero)
                this.Certificate = new Certificate(ckmcPkcs12.certificate, false);
            if (ckmcPkcs12.caChain != IntPtr.Zero)
                this._certChainHandle = new SafeCertificateListHandle(ckmcPkcs12.caChain,
                                                                      false);
        }

        internal IntPtr GetHandle()
        {
            IntPtr keyPtr = IntPtr.Zero;
            IntPtr certPtr = IntPtr.Zero;
            IntPtr cacertPtr = IntPtr.Zero;
            IntPtr p12Ptr = IntPtr.Zero;
            try
            {
                int ret = Interop.CkmcTypes.KeyNew(
                    this.PrivateKey.Binary, (UIntPtr)this.PrivateKey.Binary.Length,
                    (int)this.PrivateKey.Type, this.PrivateKey.BinaryPassword, out keyPtr);
                Interop.CheckNThrowException(ret, "Failed to duplicate key");

                if (this.Certificate != null)
                {
                    ret = Interop.CkmcTypes.CertNew(
                        this.Certificate.Binary, (UIntPtr)this.Certificate.Binary.Length,
                        (int)this.Certificate.Format, out certPtr);
                    Interop.CheckNThrowException(ret, "Failed to duplicate cert");
                }

                if (this.CaChain != null)
                {
                    var safeCertsHandle = new SafeCertificateListHandle(this.CaChain);
                    // handle should not be updated in SafeCertificateListHandle
                    // because it'll be freed with Pkcs12Free
                    cacertPtr = safeCertsHandle.ToCkmcCertificateListPtr(false);
                }

                ret = Interop.CkmcTypes.Pkcs12New(keyPtr, certPtr, cacertPtr, out p12Ptr);
                Interop.CheckNThrowException(ret, "Failed to create pkcs12");

                if (!this.IsInvalid && !this.ReleaseHandle())
                    throw new InvalidOperationException("Failed to release p12 handle");

                this.SetHandle(p12Ptr);
                return this.handle;
            }
            catch
            {
                if (p12Ptr != IntPtr.Zero)
                {
                    Interop.CkmcTypes.Pkcs12Free(p12Ptr);
                }
                else
                {
                    if (keyPtr != IntPtr.Zero)
                        Interop.CkmcTypes.KeyFree(keyPtr);
                    if (certPtr != IntPtr.Zero)
                        Interop.CkmcTypes.CertFree(certPtr);
                    if (cacertPtr != IntPtr.Zero)
                        Interop.CkmcTypes.CertListAllFree(cacertPtr);
                }

                throw;
            }
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
            get
            {
                if (this._certChainHandle == null)
                    return null;
                else
                    return this._certChainHandle.Certificates;
            }
            set
            {
                if (value == null)
                    this._certChainHandle = null;
                else
                    this._certChainHandle = new SafeCertificateListHandle(value);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free
        /// the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.Pkcs12Free(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
