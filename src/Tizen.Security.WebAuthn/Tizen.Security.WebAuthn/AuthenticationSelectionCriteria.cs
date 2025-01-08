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
    /// Authenticator selection criteria.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class AuthenticationSelectionCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationSelectionCriteria"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="attachment">Authenticator attachment modality.</param>
        /// <param name="residentKey">Specifies the extent to which the Relying Party desires to create a client-side discoverable credential.</param>
        /// <param name="requireResidentKey">Relying Parties SHOULD set it to true if, and only if, residentKey is set to required.</param>
        /// <param name="userVerification">Specifies the Relying Party's requirements regarding user verification.</param>
        public AuthenticationSelectionCriteria(
            AuthenticatorAttachment attachment,
            ResidentKeyRequirement residentKey,
            bool requireResidentKey,
            UserVerificationRequirement userVerification)
        {
            Attachment = attachment;
            ResidentKey = residentKey;
            RequireResidentKey = requireResidentKey;
            UserVerification = userVerification;
        }

        /// <summary>
        /// Gets the authenticator attachment modality.
        /// </summary>
        /// <value>
        /// The attachment modality - the usage of platform or roaming authenticators.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public AuthenticatorAttachment Attachment { get; init; }
        /// <summary>
        /// Gets the Relying Party's requirement regarding client-side discoverable credentials.
        /// </summary>
        /// <value>
        /// The extent to which the Relying Party desires to create a client-side discoverable credential.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public ResidentKeyRequirement ResidentKey { get; init; }
        /// <summary>
        /// Gets a value indicating whether a ResidentKey is required.
        /// </summary>
        /// <value>
        /// A boolean value indicating whether a ResidentKey is required.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public bool RequireResidentKey { get; init; }
        /// <summary>
        /// Gets the user verification requirements.
        /// </summary>
        /// <value>
        /// The Relying Party's requirements regarding user verification.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public UserVerificationRequirement UserVerification { get; init; }
    }
}
