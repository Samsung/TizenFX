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
    /// Public key credential descriptor.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialdescriptor
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class PubkeyCredDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PubkeyCredDescriptor"/> class.
        /// </summary>
        /// <param name="type">The type of the public key credential.</param>
        /// <param name="id">The credential ID of the public key credential.</param>
        /// <param name="transport">Transport types. To represent multiple transports, this enum can be ORed multiple times.</param>
        public PubkeyCredDescriptor(PubkeyCredType type, byte[] id, AuthenticatorTransport transport)
        {
            Type = type;
            Id = id;
            Transport = transport;
        }
        /// <summary>
        /// Gets the type of the public key credential.
        /// </summary>
        /// <value>
        /// The type of the public key credential.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public PubkeyCredType Type { get; init; }
        /// <summary>
        /// Gets the ID of the public key credential.
        /// </summary>
        /// <value>
        /// The binary ID of the public key credential.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] Id { get; init; }
        /// <summary>
        /// Gets the transport types.
        /// </summary>
        /// <value>
        /// The transport types describing communication between the client and the authenticator.
        /// To represent multiple transports, this enum can be ORed multiple times.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public AuthenticatorTransport Transport { get; init; }
    }
}
