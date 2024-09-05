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
using System.Linq;
using System.Runtime.InteropServices;
using static Interop;
using static Tizen.Security.WebAuthn.ErrorFactory;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// Public web authentication API
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public static class Authenticator
    {
        #region Public API
        /// <summary>
        /// Sets API version that the caller uses
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <remarks>This method must be called before other methods are called</remarks>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <param name="apiVersionNumber">API version number to set. Use <see cref="ApiVersionNumber"/> as an input</param>
        /// <exception cref="NotSupportedException">The specified API version or required feature is not supported</exception>
        public static void SetApiVersion(int apiVersionNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets information on authenticator types that the client platform supports
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <returns>An enum with the collection of all supported authenticator types</returns>
        /// <exception cref="NotSupportedException">The required feature is not supported</exception>
        public static AuthenticatorTransport SupportedAuthenticators()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Makes a new web authentication credential and stores it to authenticator
        /// </summary>
        /// <remarks>
        /// Refer to the following W3C specification for more information.
        /// https://www.w3.org/TR/webauthn-3/#sctn-createCredential
        /// </remarks>
        /// <since_tizen> 7 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>
        /// http://tizen.org/feature/security.webauthn
        /// http://tizen.org/feature/network.bluetooth.le
        /// and at least one of the following:
        /// http://tizen.org/feature/network.wifi
        /// http://tizen.org/feature/network.ethernet
        /// http://tizen.org/feature/network.telephony
        /// </feature>
        /// <param name="clientData">UTF-8 encoded JSON serialization of the client data</param>
        /// <param name="options">Specifies the desired attributes of the to-be-created public key credential</param>
        /// <param name="callbacks">The callback functions to be invoked</param>
        /// <exception cref="NotSupportedException">The required feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">Required privilege is missing</exception>
        /// <exception cref="ArgumentException">Input parameter is invalid</exception>
        /// <exception cref="InvalidOperationException">Operation invalid in current state</exception>
        /// <exception cref="OperationCanceledException">Canceled by a cancel request</exception>
        public static void MakeCredential(ClientData clientData, PubkeyCredCreationOptions options, McCallbacks callbacks)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets assertion from the authenticator
        /// </summary>
        /// <remarks>
        /// Refer to the following W3C specification for more information.
        /// https://www.w3.org/TR/webauthn-3/#sctn-getAssertion
        /// </remarks>
        /// <since_tizen> 7 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>
        /// http://tizen.org/feature/security.webauthn
        /// http://tizen.org/feature/network.bluetooth.le
        /// and at least one of the following:
        /// http://tizen.org/feature/network.wifi
        /// http://tizen.org/feature/network.ethernet
        /// http://tizen.org/feature/network.telephony
        /// </feature>
        /// <param name="clientData">UTF-8 encoded JSON serialization of the client data</param>
        /// <param name="options">Specifies the desired attributes of the public key credential to discover</param>
        /// <param name="callbacks">The callback functions to be invoked</param>
        /// <exception cref="NotSupportedException">The required feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">Required privilege is missing</exception>
        /// <exception cref="ArgumentException">Input parameter is invalid</exception>
        /// <exception cref="InvalidOperationException">Operation invalid in current state</exception>
        /// <exception cref="OperationCanceledException">Canceled by a cancel request</exception>
        public static void GetAssertion(ClientData clientData, PubkeyCredRequestOptions options, GaCallbacks callbacks)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the previous MakeCredential or GetAssertion call
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Not allowed in the current context</exception>
        public static void Cancel()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Current API version
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public static int ApiVersionNumber { get; } = 0x00000001;
    }
}