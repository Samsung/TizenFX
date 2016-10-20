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

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods handling certificates.
    /// </summary>
    public class CertificateManager : Manager
    {
        /// <summary>
        /// Gets a certificate from secure repository.
        /// </summary>
        /// <param name="alias">The name of a certificate to retrieve.</param>
        /// <param name="password">The password used in decrypting a certificate value.
        /// If password of policy is provided in SaveCertificate(), the same password should be provided.
        /// </param>
        /// <returns>A certificate specified by alias.</returns>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">
        /// Certificate does not exist with the alias or certificate-protecting password isn't matched.
        /// </exception>
        static public Certificate Get(string alias, string password)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcManager.GetCert(alias, password, out ptr);
            Interop.CheckNThrowException(ret, "Failed to get certificate. alias=" + alias);

            return new Certificate(ptr);
        }

        /// <summary>
        /// Gets all alias of certificates which the client can access.
        /// </summary>
        /// <returns>All alias of certificates which the client can access.</returns>
        /// <exception cref="ArgumentException">No alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = new IntPtr();
            int ret = Interop.CkmcManager.GetCertAliasList(out ptr);
            Interop.CheckNThrowException(ret, "Failed to get certificate aliases.");

            return new SafeAliasListHandle(ptr).Aliases;
        }

        /// <summary>
        /// Stores a certificate inside secure repository based on the provided policy.
        /// </summary>
        /// <param name="alias">The name of a certificate to be stored.</param>
        /// <param name="cert">The certificate's binary value to be stored.</param>
        /// <param name="policy">The policy about how to store a certificate securely.</param>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format. cert argument is invalid format.</exception>
        /// <exception cref="InvalidOperationException">Certificate with alias does already exist.</exception>
        static public void Save(string alias, Certificate cert, Policy policy)
        {
            int ret = Interop.CkmcManager.SaveCert(alias, cert.ToCkmcCert(), policy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to save certificate. alias=" + alias);
        }

        /// <summary>
        /// Verifies a certificate chain and returns that chain.
        /// </summary>
        /// <param name="certificate">The certificate to be verified.</param>
        /// <param name="untrustedCertificates">The untrusted CA certificates to be used in verifying a certificate chain.</param>
        /// <returns>A newly created certificate chain.</returns>
        /// <exception cref="ArgumentException">Some of certificate in arguments is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// Some of certificate in arguments is expired or not valid yet.
        /// Certificate cannot build chain.
        /// Root certificate is not in trusted system certificate store.
        /// </exception>
        /// <remarks>The trusted root certificate of the chain should exist in the system's certificate storage.</remarks>
        /// <remarks>The trusted root certificate of the chain in system's certificate storage is added to the certificate chain.</remarks>
        static public IEnumerable<Certificate> GetCertificateChain(Certificate certificate,
                                                                    IEnumerable<Certificate> untrustedCertificates)
        {
            IntPtr ptrCertChain = new IntPtr();

            SafeCertificateListHandle untrustedCerts = new SafeCertificateListHandle(untrustedCertificates);

            int ret = Interop.CkmcManager.GetCertChain(new PinnedObject(certificate.ToCkmcCert()),
                                                        untrustedCerts.ToCkmcCertificateListPtr(), out ptrCertChain);
            Interop.CheckNThrowException(ret, "Failed to get certificate chain");

            SafeCertificateListHandle certChain = new SafeCertificateListHandle(ptrCertChain);
            return certChain.Certificates;
        }

        /// <summary>
        /// Verifies a certificate chain and returns that chain using user entered trusted and untrusted CA certificates.
        /// </summary>
        /// <param name="certificate">The certificate to be verified.</param>
        /// <param name="untrustedCertificates">The untrusted CA certificates to be used in verifying a certificate chain.</param>
        /// <param name="trustedCertificates">The trusted CA certificates to be used in verifying a certificate chain.</param>
        /// <param name="useTrustedSystemCertificates">The flag indicating the use of the trusted root certificates in the system's certificate storage.</param>
        /// <returns>A newly created certificate chain.</returns>
        /// <exception cref="ArgumentException">Some of certificate in arguments is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// Some of certificate in arguments is expired or not valid yet.
        /// Certificate cannot build chain.
        /// Root certificate is not in trusted system certificate store.
        /// </exception>
        /// <remarks>The trusted root certificate of the chain in system's certificate storage is added to the certificate chain.</remarks>
        static public IEnumerable<Certificate> GetCertificateChain(Certificate certificate,
                                                                    IEnumerable<Certificate> untrustedCertificates,
                                                                    IEnumerable<Certificate> trustedCertificates,
                                                                    bool useTrustedSystemCertificates)
        {
            IntPtr ptrCertChain = new IntPtr();
            SafeCertificateListHandle untrustedCerts = new SafeCertificateListHandle(untrustedCertificates);
            SafeCertificateListHandle trustedCerts = new SafeCertificateListHandle(trustedCertificates);

            int ret = Interop.CkmcManager.GetCertChainWithTrustedCerts(new PinnedObject(certificate.ToCkmcCert()),
                            untrustedCerts.ToCkmcCertificateListPtr(), trustedCerts.ToCkmcCertificateListPtr(), useTrustedSystemCertificates,
                            out ptrCertChain);
            Interop.CheckNThrowException(ret, "Failed to get certificate chain with trusted certificates");

            SafeCertificateListHandle certChain = new SafeCertificateListHandle(ptrCertChain);

            return certChain.Certificates;
        }

        /// <summary>
        /// Perform OCSP which checks certificate is whether revoked or not.
        /// </summary>
        /// <param name="certificateChain">Valid certificate chain to perform OCSP check.</param>
        /// <returns>A status result of OCSP check.</returns>
        /// <exception cref="ArgumentException">certificateChain is not valid chain or certificate.</exception>
        /// <exception cref="InvalidOperationException">some of certificate in chain is expired or not valid yet.</exception>
        static public OcspStatus CheckOcsp(IEnumerable<Certificate> certificateChain)
        {
            int ocspStatus = (int)OcspStatus.Good;
            SafeCertificateListHandle certChain = new SafeCertificateListHandle(certificateChain);
            int ret = Interop.CkmcManager.OcspCheck(certChain.ToCkmcCertificateListPtr(), ref ocspStatus);
            Interop.CheckNThrowException(ret, "Failed to get certificate chain with trusted certificates");
            return (OcspStatus)ocspStatus;
        }
    }
}
