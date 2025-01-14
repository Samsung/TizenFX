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

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for the elliptic curve.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum EllipticCurveType : int
    {
        /// <summary>
        /// Elliptic curve domain "secp192r1" listed in "SEC 2" recommended elliptic curve domain.
        /// </summary>
        Prime192V1 = 0,
        /// <summary>
        /// "SEC 2" recommended elliptic curve domain - secp256r1.
        /// </summary>
        Prime256V1,
        /// <summary>
        /// NIST curve P-384(covers "secp384r1", the elliptic curve domain listed in See SEC 2.
        /// </summary>
        Secp384R1
    }
}
