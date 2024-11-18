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
using static Tizen.Security.WebAuthn.ErrorFactory;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// Linked device data.
    /// </summary>
    /// <remarks>
    /// The linked device data is used for state assisted transaction.
    /// From the successful QR initiated transaction, the linked device data
    /// might be returned from an authenticator to a webauthn client
    /// via <see cref="PubkeyCredAttestation"/> or <see cref="PubkeyCredAssertion"/>.
    /// Then the client can store the linked device data and use it in the next call
    /// for <see cref="PubkeyCredCreationOptions"/> or <see cref="PubkeyCredRequestOptions"/>.
    /// Then the stated assisted transaction will start instead of QR initiated transaction.
    ///
    /// For more information, find a section with the keyword, "linking map",
    /// from the following specification.
    /// https://fidoalliance.org/specs/fido-v2.2-rd-20230321/fido-client-to-authenticator-protocol-v2.2-rd-20230321.html
    ///
    /// For more information about state assisted transaction, refer to the following.
    /// https://fidoalliance.org/specs/fido-v2.2-rd-20230321/fido-client-to-authenticator-protocol-v2.2-rd-20230321.html#hybrid-state-assisted
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class HybridLinkedData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HybridLinkedData"/> class.
        /// </summary>
        /// <remarks>
        /// More information on the CBOR format can be found in the following specification:
        /// https://www.rfc-editor.org/rfc/rfc8949.html
        /// </remarks>
        /// <param name="contactId">CBOR:"1".</param>
        /// <param name="linkId">CBOR:"2".</param>
        /// <param name="linkSecret">CBOR:"3".</param>
        /// <param name="authenticatorPubkey">CBOR:"4".</param>
        /// <param name="authenticatorName">CBOR:"5".</param>
        /// <param name="signature">CBOR:"6".</param>
        /// <param name="tunnelServerDomain">Domain String of tunnel server.</param>
        /// <param name="identityKey">Identity Key created during QR initiated transaction.</param>
        public HybridLinkedData(
            byte[] contactId,
            byte[] linkId,
            byte[] linkSecret,
            byte[] authenticatorPubkey,
            byte[] authenticatorName,
            byte[] signature,
            byte[] tunnelServerDomain,
            byte[] identityKey)
        {
            ContactId = contactId;
            LinkId = linkId;
            LinkSecret = linkSecret;
            AuthenticatorPubkey = authenticatorPubkey;
            AuthenticatorName = authenticatorName;
            Signature = signature;
            TunnelServerDomain = tunnelServerDomain;
            IdentityKey = identityKey;
        }

        internal HybridLinkedData(WauthnHybridLinkedData linkedData)
        {
            ContactId = NullSafeMarshal.PtrToArray(linkedData.contactId);
            LinkId = NullSafeMarshal.PtrToArray(linkedData.linkId);
            LinkSecret = NullSafeMarshal.PtrToArray(linkedData.linkSecret);
            AuthenticatorPubkey = NullSafeMarshal.PtrToArray(linkedData.authenticatorPubkey);
            AuthenticatorName = NullSafeMarshal.PtrToArray(linkedData.authenticatorName);
            Signature = NullSafeMarshal.PtrToArray(linkedData.signature);
            TunnelServerDomain = NullSafeMarshal.PtrToArray(linkedData.tunnelServerDomain);
            IdentityKey = NullSafeMarshal.PtrToArray(linkedData.identityKey);
        }

        /// <summary>
        /// Gets the contact id (CBOR:"1").
        /// </summary>
        public byte[] ContactId { get; init; }
        /// <summary>
        /// Gets the link id (CBOR:"3").
        /// </summary>
        public byte[] LinkId { get; init; }
        /// <summary>
        /// Gets the link secret (CBOR:"3").
        /// </summary>
        public byte[] LinkSecret { get; init; }
        /// <summary>
        /// Gets the authenticator public key (CBOR:"4").
        /// </summary>
        public byte[] AuthenticatorPubkey { get; init; }
        /// <summary>
        /// Gets the authenticator name (CBOR:"5").
        /// </summary>
        public byte[] AuthenticatorName { get; init; }
        /// <summary>
        /// Gets the signature (CBOR:"6").
        /// </summary>
        public byte[] Signature { get; init; }
        /// <summary>
        /// Gets the Domain String of tunnel server.
        /// </summary>
        public byte[] TunnelServerDomain { get; init; }
        /// <summary>
        /// Gets the identity Key created during QR initiated transaction.
        /// </summary>
        public byte[] IdentityKey { get; init; }
    }
}
