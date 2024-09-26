/*
 *  Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// WebAuthn COSE (CBOR Object Signing and Encryption) algorithms.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#sctn-alg-identifier
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public enum CoseAlgorithm
    {
        /// <summary>
        /// ES256
        /// </summary>
        EcdsaP256WithSha256         = -7,
        /// <summary>
        /// ES384
        /// </summary>
        EcdsaP384WithSha384         = -35,
        /// <summary>
        /// ES512
        /// </summary>
        EcdsaP521WithSha512         = -36,
        /// <summary>
        /// EdDSA
        /// </summary>
        Eddsa                       = -8,
        /// <summary>
        /// PS256
        /// </summary>
        RsaPssWithSha256            = -37,
        /// <summary>
        /// PS384
        /// </summary>
        RsaPssWithSha384            = -38,
        /// <summary>
        /// PS512
        /// </summary>
        RsaPssWithSha512            = -39,
        /// <summary>
        /// RS256
        /// </summary>
        RsaSsaPkcs1V1_5WithSha256   = -257,
        /// <summary>
        /// RS384
        /// </summary>
        RsaSsaPkcs1V1_5WithSha384   = -258,
        /// <summary>
        /// RS512
        /// </summary>
        RsaSsaPkcs1V1_5WithSha512   = -259,
    }
}