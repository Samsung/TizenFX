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
    /// Enumeration for key types of key manager.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum KeyType : int
    {
        /// <summary>
        /// Key type not specified.
        /// </summary>
        None = 0,
        /// <summary>
        /// The RSA public key.
        /// </summary>
        RsaPublic,
        /// <summary>
        /// The RSA private key.
        /// </summary>
        RsaPrivate,
        /// <summary>
        /// The ECDSA public key.
        /// </summary>
        EcdsaPublic,
        /// <summary>
        /// The ECDSA private key.
        /// </summary>
        EcdsaPrivate,
        /// <summary>
        /// The DSA public key.
        /// </summary>
        DsaPublic,
        /// <summary>
        /// The DSA private key.
        /// </summary>
        DsaPrivate,
        /// <summary>
        /// The AES key.
        /// </summary>
        Aes
    }
}
