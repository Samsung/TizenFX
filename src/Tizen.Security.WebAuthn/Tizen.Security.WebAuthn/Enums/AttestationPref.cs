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
    /// WebAuthn attestation preference.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#enumdef-attestationconveyancepreference
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public enum AttestationPref
    {
        /// <summary>
        /// Relying party not interested in authenticator attestation.
        /// </summary>
        None                        = 0,
        /// <summary>
        /// Indirect attestation preferred.
        /// </summary>
        Indirect                    = 1,
        /// <summary>
        /// Direct attestation preferred.
        /// </summary>
        Direct                      = 2,
        /// <summary>
        /// Enterprise attestation preferred.
        /// </summary>
        Enterprise                  = 3,
    }
}