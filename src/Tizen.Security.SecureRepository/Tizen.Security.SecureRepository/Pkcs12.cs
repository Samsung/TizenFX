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
    /// The class that represents a PKCS#12 contents.
    /// It has a private key or its certificate or all the members of a chain of trust.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Pkcs12
    {
        private SafeCertificateListHandle _certChainHandle = null;

        /// <summary>
        /// Loads the Pkcs12 from the given PKCS#12 file path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filePath">The path of the PKCS12 file to be loaded.</param>
        /// <param name="filePassword">The passphrase used to decrypt the PCKS12 file.
        /// If the PKCS12 file is not encrypted, passphrase can be null.</param>
        /// <exception cref="ArgumentNullException">The filePath is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// No file on filePath.
        /// No permission to access file.
        /// File is in the invalid PKCS12 format.
        /// File cannot be extracted with provided filePassword.
        /// </exception>
        static public Pkcs12 Load(string filePath, string filePassword)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath should not be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcTypes.Pkcs12Load(filePath, filePassword, out ptr),
                    "Failed to load PKCS12. file=" + filePath);
                return new Pkcs12(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.Pkcs12Free(ptr);
            }
        }

        /// <summary>
        /// A constructor of Key that takes a private key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="privateKey">A private key.</param>
        public Pkcs12(Key privateKey)
        {
            this.PrivateKey = privateKey;
            this.Certificate = null;
            this.CaChain = null;
        }

        /// <summary>
        /// A constructor of Key that takes a private key, its corresponding certicate,
        /// and CA's certificate chain.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="privateKey">A private key.</param>
        /// <param name="certificate">A certificate corresponding the private key.</param>
        /// <param name="caChain">
        /// A certificate chain of CA(Certificate Authority) that issued the certificate.
        /// </param>
        public Pkcs12(Key privateKey,
                      Certificate certificate,
                      IEnumerable<Certificate> caChain)
        {
            this.PrivateKey = privateKey;
            this.Certificate = certificate;
            this.CaChain = caChain;
        }

        internal Pkcs12(IntPtr ptr)
        {
            var ckmcPkcs12 = Marshal.PtrToStructure<Interop.CkmcPkcs12>(ptr);

            this.PrivateKey = new Key(ckmcPkcs12.privateKey);
            if (ckmcPkcs12.certificate != IntPtr.Zero)
                this.Certificate = new Certificate(ckmcPkcs12.certificate);
            if (ckmcPkcs12.caChain != IntPtr.Zero)
                this._certChainHandle = new SafeCertificateListHandle(ckmcPkcs12.caChain);
        }

        internal IntPtr GetHandle()
        {
            IntPtr keyPtr = IntPtr.Zero;
            IntPtr certPtr = IntPtr.Zero;
            IntPtr cacertPtr = IntPtr.Zero;
            IntPtr p12Ptr = IntPtr.Zero;
            try
            {
                keyPtr = this.PrivateKey.GetHandle();

                if (this.Certificate != null)
                    certPtr = this.Certificate.GetHandle();

                if (this._certChainHandle != null)
                    cacertPtr = this._certChainHandle.GetHandle();

                Interop.CheckNThrowException(
                    Interop.CkmcTypes.Pkcs12New(keyPtr, certPtr, cacertPtr, out p12Ptr),
                    "Failed to create pkcs12");

                return p12Ptr;
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
        /// <since_tizen> 3 </since_tizen>
        public Key PrivateKey
        {
            get; set;
        }

        /// <summary>
        /// A certificate corresponding to the private key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Certificate Certificate
        {
            get; set;
        }

        /// <summary>
        /// A certificate chain of CA(Certificate Authority) that issued the certificate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
    }
}
