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

using static Interop;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// The response of GetAssertion().
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#authenticatorassertionresponse
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class AuthenticatorAssertionResponse
    {
        internal AuthenticatorAssertionResponse(WauthnAuthenticatorAssertionResponse wauthnResponse)
        {
            ClientDataJson = NullSafeMarshal.PtrToArray(wauthnResponse.clientDataJson);
            AuthenticatorData = NullSafeMarshal.PtrToArray(wauthnResponse.attestationObject);
            Signature = NullSafeMarshal.PtrToArray(wauthnResponse.signature);
            UserHandle = NullSafeMarshal.PtrToArray(wauthnResponse.userHandle);
            AttestationObject = NullSafeMarshal.PtrToArray(wauthnResponse.attestationObject);
        }

        /// <summary>
        /// JSON-compatible serialization of client data.
        /// </summary>
        public byte[] ClientDataJson { get; init; }
        /// <summary>
        /// The authenticator data contained within attestation_object.
        /// For more information, refer to https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data
        /// </summary>
        public byte[] AuthenticatorData { get; init; }
        /// <summary>
        /// The raw signature returned from the authenticator.
        /// For more information, refer to https://www.w3.org/TR/webauthn-3/#sctn-op-get-assertion
        /// </summary>
        public byte[] Signature { get; init; }
        /// <summary>
        /// The user handle returned from the authenticator,
        /// or null if the authenticator did not return a user handle.
        /// </summary>
        public byte[] UserHandle { get; init; }
        /// <summary>
        /// This OPTIONAL attribute contains an attestation object,
        /// if the authenticator supports attestation in assertions.
        /// </summary>
        public byte[] AttestationObject { get; init; }
    }
}