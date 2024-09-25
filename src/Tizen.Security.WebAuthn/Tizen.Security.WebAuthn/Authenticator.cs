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
        private const int API_VERSION_NUMBER = 0x00000001;
        private static bool _apiVersionSet = false;
        private static bool _busy = false;
        private static bool _allowGetAssertionCall = false;
        private static object _userData = null;
        private static WauthnDisplayQrcodeCallback _mcQrCodeCallback;
        private static WauthnDisplayQrcodeCallback _gaQrCodeCallback;
        private static WauthnMcOnResponseCallback _mcResponseCallback;
        private static WauthnGaOnResponseCallback _gaResponseCallback;
        private static WauthnUpdateLinkedDataCallback _mcLinkedDataCallback;
        private static WauthnUpdateLinkedDataCallback _gaLinkedDataCallback;
        private static WauthnMcCallbacks _wauthnMcCallbacks;
        private static WauthnGaCallbacks _wauthnGaCallbacks;

        #region Public API
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
        public static void MakeCredential(ClientData clientData, PubkeyCredCreationOptions options, MakeCredentialCallbacks callbacks)
        {
            CheckPreconditionsMc();
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
                AuthenticatorMakeCredentialStorage.SetDataForMakeCredential(clientData, options);

                int ret = Libwebauthn.MakeCredential(
                    AuthenticatorMakeCredentialStorage.WauthnClientData,
                    AuthenticatorMakeCredentialStorage.WauthnPubkeyCredCreationOptions,
                    _wauthnMcCallbacks);
                CheckErrNThrow(ret, "Make Credential");
            }
            catch
            {
                CleanupMc();
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
        public static void GetAssertion(ClientData clientData, PubkeyCredRequestOptions options, GetAssertionCallbacks callbacks)
        {
            CheckPreconditionsGa();
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
                AuthenticatorGetAssertionStorage.SetDataForGetAssertion(clientData, options);

                int ret = Libwebauthn.GetAssertion(
                    AuthenticatorGetAssertionStorage.WauthnClientData,
                    AuthenticatorGetAssertionStorage.WauthnPubkeyCredRequestOptions,
                    _wauthnGaCallbacks);
                CheckErrNThrow(ret, "Get Assertion");
            }
            catch
            {
                CleanupGa();
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

        private static void SetApiVersion(int apiVersionNumber)
        {
            int ret = Libwebauthn.SetApiVersion(apiVersionNumber);
            CheckErrNThrow(ret, "Set API version");
            _apiVersionSet = true;
        }
        private static void WrapMcCallbacks(MakeCredentialCallbacks callbacks)
        {
            _userData = callbacks.UserData;

            void qrCodeWrapper(string qrContents, IntPtr _)
            {
                callbacks.QrcodeCallback(qrContents, _userData);
            }

            void onResponseWrapper(WauthnPubkeyCredentialAttestation pubkeyCred, WauthnError result, IntPtr _)
            {
                // Since receiving this response, the user can make a GetAssertion call even though the authenticator is technically busy
                _allowGetAssertionCall = true;

                PubkeyCredAttestation pubkeyCredManaged = pubkeyCred is not null ? new(pubkeyCred) : null;
                callbacks.ResponseCallback(pubkeyCredManaged, result, _userData);

                if (result != WauthnError.None)
                    CleanupMc();
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    CleanupMc();
            }

            _mcQrCodeCallback = new WauthnDisplayQrcodeCallback(qrCodeWrapper);
            _mcResponseCallback = new WauthnMcOnResponseCallback(onResponseWrapper);
            _mcLinkedDataCallback = new WauthnUpdateLinkedDataCallback(linkedDataWrapper);

            _wauthnMcCallbacks = new WauthnMcCallbacks(_mcQrCodeCallback, _mcResponseCallback, _mcLinkedDataCallback);
        }

        private static void WrapGaCallbacks(GetAssertionCallbacks callbacks)
        {
            _userData = callbacks.UserData;

            void qrCodeWrapper(string qrContents, IntPtr _)
            {
                callbacks.QrcodeCallback(qrContents, _userData);
            }

            void onResponseWrapper(WauthnPubkeyCredentialAssertion pubkeyCred, WauthnError result, IntPtr _)
            {
                PubkeyCredAssertion pubkeyCredManaged = pubkeyCred is not null ? new(pubkeyCred) : null;
                callbacks.ResponseCallback(pubkeyCredManaged, result, _userData);

                if (result != WauthnError.None)
                    CleanupGa();
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    CleanupGa();
            }
            _gaQrCodeCallback = new WauthnDisplayQrcodeCallback(qrCodeWrapper);
            _gaResponseCallback = new WauthnGaOnResponseCallback(onResponseWrapper);
            _gaLinkedDataCallback = new WauthnUpdateLinkedDataCallback(linkedDataWrapper);

            _wauthnGaCallbacks = new WauthnGaCallbacks(_gaQrCodeCallback, _gaResponseCallback, _gaLinkedDataCallback);
        }

        private static void CheckPreconditionsMc()
        {
            if (!_apiVersionSet)
                SetApiVersion(API_VERSION_NUMBER);
            if (_busy)
                throw new InvalidOperationException("Authenticator busy");

            _busy = true;
        }

        private static void CheckPreconditionsGa()
        {
            if (!_apiVersionSet)
                SetApiVersion(API_VERSION_NUMBER);
            if (_busy && !_allowGetAssertionCall)
                throw new InvalidOperationException("Authenticator busy");

            if (_allowGetAssertionCall)
                _allowGetAssertionCall = false;
            _busy = true;
        }

        private static void CleanupMc()
        {
            _busy = false;
            _allowGetAssertionCall = false;
            AuthenticatorMakeCredentialStorage.Cleanup();
        }

        private static void CleanupGa()
        {
            _busy = false;
            AuthenticatorGetAssertionStorage.Cleanup();
        }

        #endregion
    }
}