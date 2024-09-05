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
    /// The response of MakeCredential()
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#authenticatorattestationresponse
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    public class AuthenticatorAttestationResponse
    {
        internal AuthenticatorAttestationResponse(WauthnAuthenticatorAttestationResponse wauthnResponse)
        {
            ClientDataJson = NullSafeMarshal.PtrToArray(wauthnResponse.clientDataJson);
            AttestationObject = NullSafeMarshal.PtrToArray(wauthnResponse.attestationObject);
            Transports = (AuthenticatorTransport)wauthnResponse.transports;
            AuthenticatorData = NullSafeMarshal.PtrToArray(wauthnResponse.authenticatorData);
            SubjectPubkeyInfo = NullSafeMarshal.PtrToArray(wauthnResponse.subjectPubkeyInfo);
            PubkeyAlg = wauthnResponse.pubkeyAlg;
        }

        /// <summary>
        /// JSON-compatible serialization of client data
        /// </summary>
        public byte[] ClientDataJson { get; init; }
        /// <summary>
        /// The CBOR encoded Attestation Object to be returned to the RP
        /// </summary>
        public byte[] AttestationObject { get; init; }
        /// <summary>
        /// To represent multiple transports, <see cref="AuthenticatorTransport"/> can be ORed multiple times
        /// </summary>
        public AuthenticatorTransport Transports { get; init; }
        /// <summary>
        /// The authenticator data contained within attestation_object.
        /// For more information, refer to https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data
        /// </summary>
        public byte[] AuthenticatorData { get; init; }
        /// <summary>
        /// DER SubjectPublicKeyInfo of the new credential, or null if this is not available.
        /// For more information, refer to https://datatracker.ietf.org/doc/html/rfc5280#section-4.1.2.7
        /// </summary>
        public byte[] SubjectPubkeyInfo { get; init; }
        /// <summary>
        /// The COSEAlgorithmIdentifier of the new credential
        /// </summary>
        public CoseAlgorithm PubkeyAlg { get; init; }

    }
}
