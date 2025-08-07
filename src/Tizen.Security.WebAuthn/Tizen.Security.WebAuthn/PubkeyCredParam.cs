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
    /// Parameter for credential generation.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialparameters
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class PubkeyCredParam
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PubkeyCredParam"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="type">Well-known credential type specifying a credential to create.</param>
        /// <param name="alg">Well-known COSE algorithm specifying the algorithm to use for the credential.</param>
        public PubkeyCredParam(PubkeyCredType type, CoseAlgorithm alg)
        {
            Type = type;
            Alg = alg;
        }
        /// <summary>
        /// Gets the type of the credential to create.
        /// </summary>
        /// <value>
        /// Well-known credential type specifying the credential to create.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public PubkeyCredType Type { get; init; }
        /// <summary>
        /// Gets the algotithm used for the credential.
        /// </summary>
        /// <value>
        /// Well-known COSE algorithm specifying the algorithm to use for the credential.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public CoseAlgorithm Alg { get; init; }
    }
}
