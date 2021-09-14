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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for the OCSP status.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Please do not use! This will be deprecated with API9 and removed with API11! Please use raw OpenSSL instead!")]
    public enum OcspStatus : int
    {
        /// <summary>
        /// The OCSP status is good.
        /// </summary>
        Good = 0x00,
        /// <summary>
        /// The certificate is revoked.
        /// </summary>
        Revoked = 0x01,
        /// <summary>
        /// Unknown error.
        /// </summary>
        Unknown = 0x02,
        /// <summary>
        /// The certificate does not provide the OCSP extension.
        /// </summary>
        Unsupported = 0x03,
        /// <summary>
        /// The invalid URL in the certificate OCSP extension.
        /// </summary>
        InvalidUrl = 0x04,
        /// <summary>
        /// The invalid response from the OCSP server.
        /// </summary>
        InvalidResponse = 0x05,
        /// <summary>
        /// The OCSP remote server error.
        /// </summary>
        RemoteError = 0x06,
        /// <summary>
        /// The Network connection error.
        /// </summary>
        NetworkError = 0x07,
        /// <summary>
        /// An Internal error.
        /// </summary>
        InternalError = 0x08
    }
}
