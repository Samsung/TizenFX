/*
 *  Copyright (c) 2016 - 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// <since_tizen> 3 </since_tizen>
    public class CertificateManager : Manager
    {
        /// <summary>
        /// Gets a certificate from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of a certificate to be retrieved.</param>
        /// <param name="password">
        /// The password used in decrypting a certificate value. If password of
        /// policy is provided in SaveCertificate(), the same password should be
        /// provided.
        /// </param>
        /// <returns>A certificate specified by alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// The alias argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The certificate does not exist with the alias or certificate-protecting
        /// password isn't matched.
        /// </exception>
        static public Certificate Get(string alias, string password)
        {
            if (alias == null)
                throw new ArgumentNullException("alias cannot be null");

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
        /// Gets all aliases of certificates, which the client can access.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>All aliases of certificates, which the client can access.</returns>
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
        /// Stores a certificate inside the secure repository based on the provided policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of a certificate to be stored.</param>
        /// <param name="cert">The certificate's binary value to be stored.</param>
        /// <param name="policy">
        /// The policy about how to store a certificate securely.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in the invalid format. cert argument is in the invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The certificate with alias already exist.
        /// </exception>
        static public void Save(string alias, Certificate cert, Policy policy)
        {
            if (alias == null || cert == null || policy == null)
                throw new ArgumentNullException("More than one of argument is null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.SaveCert(
                    alias, cert.ToCkmcCert(), policy.ToCkmcPolicy()),
                "Failed to save certificate. alias=" + alias);
        }

        /// <summary>
        /// Verifies a certificate chain and returns that chain.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="certificate">The certificate to be verified.</param>
        /// <param name="untrustedCertificates">
        /// The untrusted CA certificates to be used in verifying a certificate chain.
        /// </param>
        /// <returns>A newly created certificate chain.</returns>
        /// <exception cref="ArgumentNullException">
        /// The certificate argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Some of the certificates in arguments are invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Some of the certificates in arguments are expired or not valid yet.
        /// Certificate cannot build chain.
        /// The root certificate is not in the trusted system certificate store.
        /// </exception>
        /// <remarks>
        /// The trusted root certificate of the chain should exist in the system's
        /// certificate storage.
        /// </remarks>
        /// <remarks>
        /// The trusted root certificate of the chain in the system's certificate storage
        /// is added to the certificate chain.
        /// </remarks>
        static public IEnumerable<Certificate> GetCertificateChain(
            Certificate certificate, IEnumerable<Certificate> untrustedCertificates)
        {
            if (certificate == null)
                throw new ArgumentNullException("Certificate is null");

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
        /// Verifies a certificate chain and returns that chain using user entered
        /// trusted and untrusted CA certificates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="certificate">The certificate to be verified.</param>
        /// <param name="untrustedCertificates">
        /// The untrusted CA certificates to be used in verifying a certificate chain.
        /// </param>
        /// <param name="trustedCertificates">
        /// The trusted CA certificates to be used in verifying a certificate chain.
        /// </param>
        /// <param name="useTrustedSystemCertificates">
        /// The flag indicating the use of the trusted root certificates in the
        /// system's certificate storage.
        /// </param>
        /// <returns>A newly created certificate chain.</returns>
        /// <exception cref="ArgumentNullException">
        /// The certificate argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Some of the certificates in arguments are invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Some of the certificates in arguments are expired or not valid yet.
        /// Certificate cannot build chain.
        /// The root certificate is not in the trusted system certificate store.
        /// </exception>
        /// <remarks>
        /// The trusted root certificate of the chain in the system's certificate storage
        /// is added to the certificate chain.
        /// </remarks>
        static public IEnumerable<Certificate> GetCertificateChain(
            Certificate certificate, IEnumerable<Certificate> untrustedCertificates,
            IEnumerable<Certificate> trustedCertificates,
            bool useTrustedSystemCertificates)
        {
            if (certificate == null)
                throw new ArgumentNullException("Certificate is null");

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
        /// Perform OCSP, which checks whether the certificate is revoked or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="certificateChain">
        /// Valid certificate chain to perform the OCSP check.
        /// </param>
        /// <returns>A status result of the OCSP check.</returns>
        /// <exception cref="ArgumentNullException">
        /// The certificateChain argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The certificateChain is not valid chain or certificate.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Some of the certificates in chain are expired or not valid yet.
        /// </exception>
        [Obsolete("Please do not use! This will be deprecated with API9 and removed with API11! Please use raw OpenSSL instead!")]
        static public OcspStatus CheckOcsp(IEnumerable<Certificate> certificateChain)
        {
            if (certificateChain == null)
                throw new ArgumentNullException("Certificate chain is null");

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
