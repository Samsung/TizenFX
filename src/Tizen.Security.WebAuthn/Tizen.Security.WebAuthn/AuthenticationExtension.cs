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
    /// Authenticator extension.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class AuthenticationExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationExtension"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="extensionId">
        /// Extension Identifier defined in the following registry:
        /// https://www.iana.org/assignments/webauthn/webauthn.xhtml#webauthn-extension-ids
        /// </param>
        /// <param name="extensionValue">Extension value.</param>
        public AuthenticationExtension(byte[] extensionId, byte[] extensionValue)
        {
            ExtensionId = extensionId;
            ExtensionValue = extensionValue;
        }

        internal AuthenticationExtension(WauthnAuthenticationExt ext)
        {
            ExtensionId = NullSafeMarshal.PtrToArray(ext.extensionId);
            ExtensionValue = NullSafeMarshal.PtrToArray(ext.extensionValue);
        }

        /// <summary>
        /// Gets the extension identifier.
        /// </summary>
        /// <value>
        /// The binary data of the extension indentifier.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] ExtensionId { get; init; }
        /// <summary>
        /// Gets the extension value.
        /// </summary>
        /// <value>
        /// The binary data of the extension value.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] ExtensionValue { get; init; }
    }
}
