/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides information about the package certification.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PackageCertificate
    {
        private const string LogTag = "Tizen.Applications";

        private readonly string _root;
        private readonly string _intermediate;
        private readonly string _signer;

        internal PackageCertificate(string root, string intermediate, string signer)
        {
            _root = root;
            _intermediate = intermediate;
            _signer = signer;
        }

        /// <summary>
        /// Root certificate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Root { get { return _root;  } }

        /// <summary>
        /// Intermediate certificate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Intermediate { get { return _intermediate; } }

        /// <summary>
        /// Signer certificate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Signer { get { return _signer; } }

        internal static IReadOnlyDictionary<CertificateType, PackageCertificate> GetPackageCertificates(string packageId)
        {
            Dictionary<CertificateType, PackageCertificate> certificates = new Dictionary<CertificateType, PackageCertificate>();

            int ret = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoCreateCertinfo(out IntPtr handle);
            if (ret != 0)
            {
                Log.Error(LogTag, string.Format("Failed to create cert info handle"));
                return certificates;
            }

            ret = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoLoadCertinfo(packageId, handle, Interop.PackageManagerInfoInternal.GetUID());
            if (ret != 0)
            {
                Log.Error(LogTag, string.Format("Failed to load cert info of {0}", packageId));
                return certificates;
            }

            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.AuthorRootCertificate, out IntPtr authorRootCertificatePtr);
            string authorRootCertificate = authorRootCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(authorRootCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.AuthorIntermediateCertificate, out IntPtr authorIntermediateCertificatePtr);
            string authorIntermediateCertificate = authorIntermediateCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(authorIntermediateCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.AuthorSignerCertificate, out IntPtr aurthorSignerCertificatePtr);
            string aurthorSignerCertificate = aurthorSignerCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(aurthorSignerCertificatePtr) : string.Empty;
            certificates.Add(CertificateType.Author, new PackageCertificate(authorRootCertificate, authorIntermediateCertificate, aurthorSignerCertificate));

            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.DistributorRootCertificate, out IntPtr distRootCertificatePtr);
            string distRootCertificate = distRootCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(distRootCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.DistributorIntermediateCertificate, out IntPtr distIntermediateCertificatePtr);
            string distIntermediateCertificate = distIntermediateCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(distIntermediateCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.DistributorSignerCertificate, out IntPtr distSignerCertificatePtr);
            string distSignerCertificate = distSignerCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(distSignerCertificatePtr) : string.Empty;
            certificates.Add(CertificateType.Distributor, new PackageCertificate(distRootCertificate, distIntermediateCertificate, distSignerCertificate));

            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.Distributor2RootCertificate, out IntPtr dist2RootCertificatePtr);
            string dist2RootCertificate = dist2RootCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(dist2RootCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.Distributor2IntermediateCertificate, out IntPtr dist2IntermediateCertificatePtr);
            string dist2IntermediateCertificate = dist2IntermediateCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(dist2IntermediateCertificatePtr) : string.Empty;
            _ = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoGetCertValue(handle, Interop.Package.CertificateType.Distributor2SignerCertificate, out IntPtr dist2SignerCertificatePtr);
            string dist2SignerCertificate = dist2SignerCertificatePtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(dist2SignerCertificatePtr) : string.Empty;
            certificates.Add(CertificateType.Distributor2, new PackageCertificate(dist2RootCertificate, dist2IntermediateCertificate, dist2SignerCertificate));

            ret = Interop.PackageManagerInfoInternal.PkgmgrinfoPkginfoDestroyCertinfo(handle);
            if (ret != 0)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy cert info handle"));
            }

            return certificates;
        }
    }
}
