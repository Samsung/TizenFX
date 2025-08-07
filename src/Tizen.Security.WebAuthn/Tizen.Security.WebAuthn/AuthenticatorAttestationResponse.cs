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
    /// The response of <see cref="Authenticator.MakeCredential"/>.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#authenticatorattestationresponse
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
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
        /// Gets the serialized client data json.
        /// </summary>
        /// <value>
        /// A JSON-compatible serialization of client data.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] ClientDataJson { get; init; }
        /// <summary>
        /// Gets the Attestation Object to be returned to the Relying Party.
        /// </summary>
        /// <value>
        /// A CBOR-encoded Attestation Object.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] AttestationObject { get; init; }
        /// <summary>
        /// Gets an enum containing a list of transports.
        /// </summary>
        /// <value>
        /// A list of transports. To represent multiple transports,
        /// <see cref="AuthenticatorTransport"/> can be ORed multiple times.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public AuthenticatorTransport Transports { get; init; }
        /// <summary>
        /// Gets the authenticator data contained within the Attestation Object.
        /// </summary>
        /// <value>
        /// Authenticator data contained within the Attestation Object.
        /// For more information, refer to https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] AuthenticatorData { get; init; }
        /// <summary>
        /// Gets the DER SubjectPublicKeyInfo of the new credential.
        /// </summary>
        /// <value>
        /// DER SubjectPublicKeyInfo of the new credential, or null if this is not available.
        /// For more information, refer to https://datatracker.ietf.org/doc/html/rfc5280#section-4.1.2.7
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] SubjectPubkeyInfo { get; init; }
        /// <summary>
        /// Gets the COSE algorithm identifier of the new credential.
        /// </summary>
        /// <value>
        /// The COSE algorithm identifier of the new credential.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public CoseAlgorithm PubkeyAlg { get; init; }

    }
}
