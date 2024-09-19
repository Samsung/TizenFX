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
    /// Public web authentication API.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public static class Authenticator
    {
        private static bool _apiVersionSet = false;
        private static bool _busy = false;
        private static object _userData = null;
        private static WauthnDisplayQrcodeCallback _qrCodeCallback;
        private static WauthnMcOnResponseCallback _mcResponseCallback;
        private static WauthnGaOnResponseCallback _gaResponseCallback;
        private static WauthnUpdateLinkedDataCallback _linkedDataCallback;
        private static WauthnMcCallbacks _wauthnMcCallbacks;
        private static WauthnGaCallbacks _wauthnGaCallbacks;

        #region Public API
        /// <summary>
        /// Sets API version that the caller uses.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <remarks>This method must be called before other methods are called.</remarks>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <param name="apiVersionNumber">API version number to set. Use <see cref="ApiVersionNumber"/> as an input.</param>
        /// <exception cref="NotSupportedException">The specified API version or required feature is not supported.</exception>
        public static void SetApiVersion(int apiVersionNumber)
        {
            int ret = Libwebauthn.SetApiVersion(apiVersionNumber);
            CheckErrNThrow(ret, "Set API version");
            _apiVersionSet = true;
        }

        /// <summary>
        /// Gets information on authenticator types that the client platform supports.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <returns>An enum with the collection of all supported authenticator types.</returns>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static AuthenticatorTransport SupportedAuthenticators()
        {
            int ret = Libwebauthn.SupportedAuthenticators(out uint supported);
            CheckErrNThrow(ret, "Get supported authenticators");

            return (AuthenticatorTransport)supported;
        }

        /// <summary>
        /// Makes a new web authentication credential and stores it to authenticator.
        /// </summary>
        /// <remarks>
        /// Refer to the following W3C specification for more information.
        /// https://www.w3.org/TR/webauthn-3/#sctn-createCredential
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
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
        /// <param name="clientData">UTF-8 encoded JSON serialization of the client data.</param>
        /// <param name="options">Specifies the desired attributes of the to-be-created public key credential.</param>
        /// <param name="callbacks">The callback functions to be invoked.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Required privilege is missing.</exception>
        /// <exception cref="ArgumentException">Input parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Operation invalid in current state.</exception>
        /// <exception cref="OperationCanceledException">Canceled by a cancel request.</exception>
        public static void MakeCredential(ClientData clientData, PubkeyCredCreationOptions options, McCallbacks callbacks)
        {
            CheckPreconditions();
            try
            {
                CheckNullNThrow(clientData);
                CheckNullNThrow(clientData.JsonData);
                CheckNullNThrow(options);
                CheckNullNThrow(options.Rp);
                CheckNullNThrow(options.User);
                CheckNullNThrow(options.PubkeyCredParams);
                CheckNullNThrow(callbacks);
                CheckNullNThrow(callbacks.QrcodeCallback);
                CheckNullNThrow(callbacks.ResponseCallback);
                CheckNullNThrow(callbacks.LinkedDataCallback);

                // Create callback wrappers
                WrapMcCallbacks(callbacks);
                AuthenticatorStorage.SetDataForMakeCredential(clientData, options);

                int ret = Libwebauthn.MakeCredential(
                    AuthenticatorStorage.WauthnClientData,
                    AuthenticatorStorage.WauthnPubkeyCredCreationOptions,
                    _wauthnMcCallbacks);
                CheckErrNThrow(ret, "Make Credential");
            }
            catch
            {
                Cleanup();
                throw;
            }
        }

        /// <summary>
        /// Gets assertion from the authenticator.
        /// </summary>
        /// <remarks>
        /// Refer to the following W3C specification for more information.
        /// https://www.w3.org/TR/webauthn-3/#sctn-getAssertion
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
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
        /// <param name="clientData">UTF-8 encoded JSON serialization of the client data.</param>
        /// <param name="options">Specifies the desired attributes of the public key credential to discover.</param>
        /// <param name="callbacks">The callback functions to be invoked.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Required privilege is missing.</exception>
        /// <exception cref="ArgumentException">Input parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Operation invalid in current state.</exception>
        /// <exception cref="OperationCanceledException">Canceled by a cancel request.</exception>
        public static void GetAssertion(ClientData clientData, PubkeyCredRequestOptions options, GaCallbacks callbacks)
        {
            CheckPreconditions();
            try
            {
                CheckNullNThrow(clientData);
                CheckNullNThrow(clientData.JsonData);
                CheckNullNThrow(options);
                CheckNullNThrow(callbacks);
                CheckNullNThrow(callbacks.QrcodeCallback);
                CheckNullNThrow(callbacks.ResponseCallback);
                CheckNullNThrow(callbacks.LinkedDataCallback);

                // Create callback wrappers
                WrapGaCallbacks(callbacks);
                AuthenticatorStorage.SetDataForGetAssertion(clientData, options);

                int ret = Libwebauthn.GetAssertion(
                    AuthenticatorStorage.WauthnClientData,
                    AuthenticatorStorage.WauthnPubkeyCredRequestOptions,
                    _wauthnGaCallbacks);
                CheckErrNThrow(ret, "Get Assertion");
            }
            catch
            {
                Cleanup();
                throw;
            }
        }

        /// <summary>
        /// Stops the previous <see cref="MakeCredential"/> or <see cref="GetAssertion"/> call.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Not allowed in the current context.</exception>
        public static void Cancel()
        {
            int ret = Libwebauthn.Cancel();
            CheckErrNThrow(ret, "Cancel operation");
        }

        #endregion
        #region Helper methods

        private static void WrapMcCallbacks(McCallbacks callbacks)
        {
            _userData = callbacks.UserData;

            void qrCodeWrapper(string qrContents, IntPtr _)
            {
                callbacks.QrcodeCallback(qrContents, _userData);
            }

            void onResponseWrapper(WauthnPubkeyCredentialAttestation pubkeyCred, WauthnError result, IntPtr _)
            {
                PubkeyCredentialAttestation pubkeyCredManaged = pubkeyCred is not null ? new(pubkeyCred) : null;
                callbacks.ResponseCallback(pubkeyCredManaged, result, _userData);

                if (result != WauthnError.None)
                    Cleanup();
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    Cleanup();
            }

            _qrCodeCallback = new WauthnDisplayQrcodeCallback(qrCodeWrapper);
            _mcResponseCallback = new WauthnMcOnResponseCallback(onResponseWrapper);
            _linkedDataCallback = new WauthnUpdateLinkedDataCallback(linkedDataWrapper);

            _wauthnMcCallbacks = new WauthnMcCallbacks(_qrCodeCallback, _mcResponseCallback, _linkedDataCallback);
        }

        private static void WrapGaCallbacks(GaCallbacks callbacks)
        {
            _userData = callbacks.UserData;

            void qrCodeWrapper(string qrContents, IntPtr _)
            {
                callbacks.QrcodeCallback(qrContents, _userData);
            }

            void onResponseWrapper(WauthnPubkeyCredentialAssertion pubkeyCred, WauthnError result, IntPtr _)
            {
                PubkeyCredentialAssertion pubkeyCredManaged = pubkeyCred is not null ? new(pubkeyCred) : null;
                callbacks.ResponseCallback(pubkeyCredManaged, result, _userData);

                if (result != WauthnError.None)
                    Cleanup();
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    Cleanup();
            }
            _qrCodeCallback = new WauthnDisplayQrcodeCallback(qrCodeWrapper);
            _gaResponseCallback = new WauthnGaOnResponseCallback(onResponseWrapper);
            _linkedDataCallback = new WauthnUpdateLinkedDataCallback(linkedDataWrapper);

            _wauthnGaCallbacks = new WauthnGaCallbacks(_qrCodeCallback, _gaResponseCallback, _linkedDataCallback);
        }

        private static void CheckPreconditions()
        {
            if (!_apiVersionSet)
                throw new InvalidOperationException("API version not set");
            if (_busy)
                throw new InvalidOperationException("Authenticator busy");

            _busy = true;
        }

        private static void Cleanup()
        {
            _busy = false;
            AuthenticatorStorage.Cleanup();
        }

        #endregion

        /// <summary>
        /// Current API version.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public static int ApiVersionNumber { get; } = 0x00000001;
    }
}