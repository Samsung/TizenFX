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

using System.Collections.Generic;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// Make credential options.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialcreationoptions
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class PubkeyCredCreationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PubkeyCredCreationOptions"/> class.
        /// </summary>
        /// /// <since_tizen> 12 </since_tizen>
        /// <param name="rp">Contains a name and an identifier for the Relying Party responsible for the request.</param>
        /// <param name="user">Contains names and an identifier for the user account performing the registration.</param>
        /// <param name="pubkeyCredParams">
        /// Lists the key types and signature algorithms the Relying Party supports,
        /// ordered from most preferred to least preferred.
        /// </param>
        /// <param name="timeout">
        /// Specifies a time, in milliseconds,
        /// that the Relying Party is willing to wait for the call to complete.
        /// This is treated as a hint, and MAY be overridden by the client.
        /// The value, '0', means no timeout is set. (optional)
        /// </param>
        /// <param name="excludeCredentials">
        /// The Relying Party SHOULD use this argument to list any existing credentials mapped
        /// to this user account (as identified by user.id). (optional)
        /// </param>
        /// <param name="authenticatorSelection">
        /// The Relying Party MAY use his argument to specify capabilities and settings that the
        /// authenticator MUST or SHOULD satisfy to participate in this operation. (optional)
        /// </param>
        /// <param name="hints">
        /// Contains zero or more elements from <see cref="PubkeyCredHint"/> to
        /// guide the user agent in interacting with the user. (optional)
        /// </param>
        /// <param name="attestation">
        /// The Relying Party MAY use this argument to specify a preference regarding attestation conveyance.
        /// The default value is <see cref="AttestationPref.None"/>. (optional)
        /// </param>
        /// <param name="attestationFormats">
        /// The Relying Party MAY use this argument to specify a preference regarding the attestation
        /// statement format used by the authenticator. The default value is the empty list, which
        /// indicates no preference. (optional)
        /// </param>
        /// <param name="extensions">
        /// The Relying Party MAY use this argument to provide client extension inputs requesting
        /// additional processing by the client and authenticator. (optional)
        /// </param>
        /// <param name="linkedDevice">
        /// Linked Device Connection Info. Optional.
        /// If not null, the state assisted transaction will start.
        /// </param>
        public PubkeyCredCreationOptions(
            RelyingPartyEntity rp,
            UserEntity user,
            IEnumerable<PubkeyCredParam> pubkeyCredParams,
            ulong timeout = 0,
            IEnumerable<PubkeyCredDescriptor> excludeCredentials = null,
            AuthenticationSelectionCriteria authenticatorSelection = null,
            IEnumerable<PubkeyCredHint> hints = null,
            AttestationPref attestation = AttestationPref.None,
            IEnumerable<byte[]> attestationFormats = null,
            IEnumerable<AuthenticationExtension> extensions = null,
            HybridLinkedData linkedDevice = null)
        {
            Rp = rp;
            User = user;
            PubkeyCredParams = pubkeyCredParams;
            Timeout = timeout;
            ExcludeCredentials = excludeCredentials;
            AuthenticatorSelection = authenticatorSelection;
            Hints = hints;
            Attestation = attestation;
            AttestationFormats = attestationFormats;
            Extensions = extensions;
            LinkedDevice = linkedDevice;
        }

        /// <summary>
        /// Gets the Relying Party data.
        /// </summary>
        /// <value>
        /// The name and identifier for the Relying Party responsible for the request.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public RelyingPartyEntity Rp { get; init; }
        /// <summary>
        /// Gets user account data.
        /// </summary>
        /// <value>
        /// The names and identifier for the user account performing the registration.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public UserEntity User { get; init; }
        /// <summary>
        /// Gets the key parameters the Relying Party supports.
        /// </summary>
        /// <value>
        /// The key types and signature algorithms the Relying Party supports,
        /// ordered from most preferred to least preferred.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<PubkeyCredParam> PubkeyCredParams { get; init; }
        /// <summary>
        /// Gets the timeout requested by the Relying Party.
        /// </summary>
        /// <value>
        /// The time, in milliseconds, that the Relying Party is willing to wait for the
        /// call to complete. This is treated as a hint, and MAY be overridden by the client.
        /// The value, '0', means no timeout is set.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public ulong Timeout { get; init; }
        /// <summary>
        /// Gets the existing credentials mapped to this user account.
        /// </summary>
        /// <value>
        /// Any existing credentials mapped to this user account (as identified by user.id).
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<PubkeyCredDescriptor> ExcludeCredentials { get; init; }
        /// <summary>
        /// Gets the criteria for authenticator selection.
        /// </summary>
        /// <value>
        /// The capabilities and settings that the authenticator MUST or SHOULD satisfy
        /// to participate in this operation.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public AuthenticationSelectionCriteria AuthenticatorSelection { get; init; }
        /// <summary>
        /// Gets hints used to guide the user agent in interacting with the user.
        /// </summary>
        /// <value>
        /// Contains zero or more elements from <see cref="PubkeyCredHint"/> to
        /// guide the user agent in interacting with the user.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<PubkeyCredHint> Hints { get; init; }
        /// <summary>
        /// Gets the attestation conveyance preference.
        /// </summary>
        /// <value>
        /// Specifies a preference regarding attestation conveyance.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public AttestationPref Attestation { get; init; }
        /// <summary>
        /// Gets the attestation format preference.
        /// </summary>
        /// <value>
        /// Specifies a preference regarding the attestation statement format used by the authenticator.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<byte[]> AttestationFormats { get; init; }
        /// <summary>
        /// Gets the client extension inputs.
        /// </summary>
        /// <value>
        /// Client extension inputs requesting additional processing by the client and authenticator.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<AuthenticationExtension> Extensions { get; init; }
        /// <summary>
        /// Gets the Linked Device Connection Info.
        /// </summary>
        /// <value>
        /// Linked Device Connection Info. If not null, the state assisted transaction will start.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public HybridLinkedData LinkedDevice { get; init; }
    }
}
