using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for OCSP status.
    /// </summary>
    public enum OcspStatus : int
    {
        /// <summary>
        /// OCSP status is good
        /// </summary>
        Good = 0x00,
        /// <summary>
        /// The certificate is revoked
        /// </summary>
        Revoked = 0x01,
        /// <summary>
        /// Unknown error
        /// </summary>
        Unknown = 0x02,
        /// <summary>
        /// The certificate does not provide OCSP extension
        /// </summary>
        Unsupported = 0x03,
        /// <summary>
        /// The invalid URL in certificate OCSP extension
        /// </summary>
        InvalidUrl = 0x04,
        /// <summary>
        /// The invalid response from OCSP server
        /// </summary>
        InvalidResponse = 0x05,
        /// <summary>
        /// OCSP remote server error
        /// </summary>
        RemoteError = 0x06,
        /// <summary>
        /// Network connection error
        /// </summary>
        NetworkError = 0x07,
        /// <summary>
        /// Internal error
        /// </summary>
        InternalError = 0x08
    }
}
