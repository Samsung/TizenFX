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

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// publickey_credential response for MakeCredential()
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#iface-pkcredential
    /// https://www.w3.org/TR/webauthn-3/#sctn-credentialcreationoptions-extension
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    public class PubkeyCredentialAttestation
    {
        internal PubkeyCredentialAttestation(WauthnPubkeyCredentialAttestation attestation)
        {
            Id = NullSafeMarshal.PtrToArray(attestation.id);
            Type = attestation.type;
            RawId = NullSafeMarshal.PtrToArray(attestation.rawId);
            Response = attestation.response != IntPtr.Zero ?
                new AuthenticatorAttestationResponse(Marshal.PtrToStructure<WauthnAuthenticatorAttestationResponse>(attestation.response)) :
                null;
            AuthenticatorAttachment = attestation.authenticatorAttachment;

            if (attestation.extensions != IntPtr.Zero)
            {
                var wauthnExts = Marshal.PtrToStructure<WauthnAuthenticationExts>(attestation.extensions);
                var extensionsArray = new AuthenticationExt[wauthnExts.size];
                unsafe
                {
                    var extPtr = (WauthnAuthenticationExt*)wauthnExts.descriptors;
                    for (int i = 0; i < (int)wauthnExts.size; i++)
                    {
                        var wauthnExt = Marshal.PtrToStructure<WauthnAuthenticationExt>(new IntPtr(extPtr + i * sizeof(WauthnAuthenticationExt)));
                        extensionsArray[i] = new AuthenticationExt(wauthnExt);
                    }
                }
                Extensions = extensionsArray;
            }
            else
            {
                Extensions = null;
            }

            LinkedDevice = attestation.linkedDevice != IntPtr.Zero ?
                new HybridLinkedData(Marshal.PtrToStructure<WauthnHybridLinkedData>(attestation.linkedDevice)) :
                null;
        }

        /// <summary>
        /// The base64url encoding of credential’s identifier
        /// </summary>
        public byte[] Id { get; init; }
        /// <summary>
        /// The credential’s type
        /// </summary>
        public PubkeyCredType Type { get; init; }
        /// <summary>
        /// The raw value of credential’s identifier
        /// </summary>
        public byte[] RawId { get; init; }
        /// <summary>
        /// Authenticator's response
        /// </summary>
        public AuthenticatorAttestationResponse Response { get; init; }
        /// <summary>
        /// Authenticator attachment modality
        /// </summary>
        public AuthenticatorAttachment AuthenticatorAttachment { get; init; }
        /// <summary>
        /// The results of processing client extensions requested by the Relying Party
        /// upon the Relying Party's invocation of MakeCredential(). (optional)
        /// </summary>
        public IEnumerable<AuthenticationExt> Extensions { get; init; }
        /// <summary>
        /// Linked Device Connection Info (optional).
        /// If not null, the caller has to store this value and use thi
        /// in the next transaction to invoke state assisted transaction.
        /// </summary>
        public HybridLinkedData LinkedDevice { get; init; }
    }
}
