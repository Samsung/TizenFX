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
using static Interop;

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
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetCert(alias, password, out ptr),
                    "Failed to get certificate. alias=" + alias);
                return new Certificate(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.CertFree(ptr);
            }
        }

        /// <summary>
        /// Gets all alias of certificates which the client can access.
        /// </summary>
        /// <returns>All alias of certificates which the client can access.</returns>
        /// <exception cref="ArgumentException">No alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetCertAliasList(out ptr),
                    "Failed to get certificate aliases.");
                return new SafeAliasListHandle(ptr).Aliases;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.AliasListAllFree(ptr);
            }
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
            Interop.CheckNThrowException(
                Interop.CkmcManager.SaveCert(
                    alias, cert.ToCkmcCert(), policy.ToCkmcPolicy()),
                "Failed to save certificate. alias=" + alias);
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
            IntPtr ptrCertChain = IntPtr.Zero;
            IntPtr certPtr = IntPtr.Zero;
            IntPtr untrustedPtr = IntPtr.Zero;

            try
            {
                var untrusted = new SafeCertificateListHandle(untrustedCertificates);

                certPtr = certificate.GetHandle();
                untrustedPtr = untrusted.GetHandle();

                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetCertChain(
                        certPtr, untrustedPtr,
                        out ptrCertChain),
                    "Failed to get certificate chain");

                return new SafeCertificateListHandle(ptrCertChain).Certificates;
            }
            finally
            {
                if (certPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertFree(certPtr);
                if (untrustedPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertListAllFree(untrustedPtr);
            }
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
            IntPtr certPtr = IntPtr.Zero;
            IntPtr untrustedPtr = IntPtr.Zero;
            IntPtr trustedPtr = IntPtr.Zero;
            IntPtr ptrCertChain = IntPtr.Zero;

            try
            {
                var untrusted = new SafeCertificateListHandle(untrustedCertificates);
                var trusted = new SafeCertificateListHandle(trustedCertificates);

                certPtr = certificate.GetHandle();
                untrustedPtr = untrusted.GetHandle();
                trustedPtr = trusted.GetHandle();

                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetCertChainWithTrustedCerts(
                        certPtr, untrustedPtr, trustedPtr,
                        useTrustedSystemCertificates, out ptrCertChain),
                    "Failed to get certificate chain with trusted certificates");
                return new SafeCertificateListHandle(ptrCertChain).Certificates;
            }
            finally
            {
                if (certPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertFree(certPtr);
                if (untrustedPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertListAllFree(untrustedPtr);
                if (trustedPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertListAllFree(trustedPtr);
            }
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
            IntPtr ptr = IntPtr.Zero;

            try
            {
                int ocspStatus = (int)OcspStatus.Good;
                var certChain = new SafeCertificateListHandle(certificateChain);

                ptr = certChain.GetHandle();

                Interop.CheckNThrowException(
                    Interop.CkmcManager.OcspCheck(ptr, ref ocspStatus),
                    "Failed to get certificate chain with trusted certificates");
                return (OcspStatus)ocspStatus;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.CertListAllFree(ptr);
            }
        }

        // to be static class safely
        internal CertificateManager()
        {
        }
    }
}
