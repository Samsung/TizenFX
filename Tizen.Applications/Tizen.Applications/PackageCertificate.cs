// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides information about package certification.
    /// </summary>
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
        /// Root certificate
        /// </summary>
        public string Root { get { return _root;  } }

        /// <summary>
        /// Intermediate certificate
        /// </summary>
        public string Intermediate { get { return _intermediate; } }

        /// <summary>
        /// Signer certificate
        /// </summary>
        public string Signer { get { return _signer; } }

        internal static IReadOnlyDictionary<CertificateType, PackageCertificate> GetPackageCertificates(IntPtr packageInfoHandle)
        {
            Dictionary<Interop.Package.CertificateType, string> nativeCertificates = new Dictionary<Interop.Package.CertificateType, string>();
            Interop.Package.PackageInfoCertificateInfoCallback certificateInfoCb = (handle, certType, certValue, userData) =>
            {
                if (certValue == null) certValue = string.Empty;
                nativeCertificates.Add(certType, certValue);
                return true;
            };

            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoForeachCertificateInfo(packageInfoHandle, certificateInfoCb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get certificate info. err = {0}", err));
            }

            Dictionary<CertificateType, PackageCertificate> certificates = new Dictionary<CertificateType, PackageCertificate>();
            string authorRootCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.AuthorRootCertificate);
            string authorIntermediateCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.AuthorIntermediateCertificate);
            string aurthorSignerCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.AuthorSignerCertificate);
            certificates.Add(CertificateType.Author, new PackageCertificate(authorRootCertificate, authorIntermediateCertificate, aurthorSignerCertificate));

            string distRootCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.DistributorRootCertificate);
            string distIntermediateCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.DistributorIntermediateCertificate);
            string distSignerCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.DistributorSignerCertificate);
            certificates.Add(CertificateType.Distributor, new PackageCertificate(distRootCertificate, distIntermediateCertificate, distSignerCertificate));

            string dist2RootCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.Distributor2RootCertificate);
            string dist2IntermediateCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.Distributor2RootCertificate);
            string dist2SignerCertificate = GetValue(nativeCertificates, Interop.Package.CertificateType.Distributor2RootCertificate);
            certificates.Add(CertificateType.Distributor2, new PackageCertificate(dist2RootCertificate, dist2IntermediateCertificate, dist2SignerCertificate));

            return certificates;
        }

        private static string GetValue(IDictionary<Interop.Package.CertificateType, string> dict, Interop.Package.CertificateType key)
        {
            string value = string.Empty;
            dict.TryGetValue(key, out value);
            return value;
        }
    }
}