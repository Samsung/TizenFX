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
        private static object _userData = null;
        private static Dictionary<int, AuthenticatorStorage> _apiCalls = new();
        private static int _callId = 0;

        #region Public API
        /// <summary>
        /// Gets information on authenticator types that the client platform supports.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <returns>An enum with the collection of all supported authenticator types.</returns>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not supported.</exception>
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
        /// <exception cref="NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a required privilege is missing.</exception>
        /// <exception cref="ArgumentException">Thrown when an input parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid in current state.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the call is canceled by a cancel request.</exception>
        public static void MakeCredential(ClientData clientData, PubkeyCredCreationOptions options, MakeCredentialCallbacks callbacks)
        {
            CheckPreconditions();
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

            int id = unchecked(_callId++);
            // Copy data to unmanaged memory
            var storage = new AuthenticatorMakeCredentialStorage(clientData, options);
            // Create callback wrappers
            WrapMcCallbacks(callbacks, storage, id);
            // Add the storage to a static dictionary to prevent GC from premature collecting
            _apiCalls.Add(id, storage);

            try
            {
                int ret = Libwebauthn.MakeCredential(
                    storage.WauthnClientData,
                    storage.WauthnPubkeyCredCreationOptions,
                    storage.WauthnMcCallbacks);
                CheckErrNThrow(ret, "Make Credential");
            }
            catch
            {
                Cleanup(id);
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
        /// <exception cref="NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a required privilege is missing.</exception>
        /// <exception cref="ArgumentException">Thrown when an input parameter is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid in current state.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the call is canceled by a cancel request.</exception>
        public static void GetAssertion(ClientData clientData, PubkeyCredRequestOptions options, GetAssertionCallbacks callbacks)
        {
            CheckPreconditions();
            CheckNullNThrow(clientData);
            CheckNullNThrow(clientData.JsonData);
            CheckNullNThrow(options);
            CheckNullNThrow(callbacks);
            CheckNullNThrow(callbacks.QrcodeCallback);
            CheckNullNThrow(callbacks.ResponseCallback);
            CheckNullNThrow(callbacks.LinkedDataCallback);

            int id = unchecked(_callId++);
            // Copy data to unmanaged memory
            var storage =  new AuthenticatorGetAssertionStorage(clientData, options);
            // Create callback wrappers
            WrapGaCallbacks(callbacks, storage, id);
            // Add the storage to a static dictionary to prevent GC from premature collecting
            _apiCalls.Add(id, storage);

            try
            {
                int ret = Libwebauthn.GetAssertion(
                    storage.WauthnClientData,
                    storage.WauthnPubkeyCredRequestOptions,
                    storage.WauthnGaCallbacks);
                CheckErrNThrow(ret, "Get Assertion");
            }
            catch
            {
                Cleanup(id);
                throw;
            }
        }

        /// <summary>
        /// Stops the previous <see cref="MakeCredential"/> or <see cref="GetAssertion"/> call.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <feature>http://tizen.org/feature/security.webauthn</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid in current state.</exception>
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
        private static void WrapMcCallbacks(MakeCredentialCallbacks callbacks, AuthenticatorMakeCredentialStorage storage, int id)
        {
            _userData = callbacks.UserData;

            void qrCodeWrapper(string qrContents, IntPtr _)
            {
                callbacks.QrcodeCallback(qrContents, _userData);
            }

            void onResponseWrapper(WauthnPubkeyCredentialAttestation pubkeyCred, WauthnError result, IntPtr _)
            {
                PubkeyCredAttestation pubkeyCredManaged = pubkeyCred is not null ? new(pubkeyCred) : null;
                callbacks.ResponseCallback(pubkeyCredManaged, result, _userData);

                if (result != WauthnError.None)
                    Cleanup(id);
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    Cleanup(id);
            }

            storage.SetCallbacks(
                new WauthnDisplayQrcodeCallback(qrCodeWrapper),
                new WauthnMcOnResponseCallback(onResponseWrapper),
                new WauthnUpdateLinkedDataCallback(linkedDataWrapper)
            );
        }

        private static void WrapGaCallbacks(GetAssertionCallbacks callbacks, AuthenticatorGetAssertionStorage storage, int id)
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
                    Cleanup(id);
            }

            void linkedDataWrapper(IntPtr linkedData, WauthnError result, IntPtr _)
            {
                HybridLinkedData linkedDataManaged = linkedData != IntPtr.Zero ? new(Marshal.PtrToStructure<WauthnHybridLinkedData>(linkedData)) : null;
                callbacks.LinkedDataCallback(linkedDataManaged, result, _userData);

                if (result != WauthnError.NoneAndWait)
                    Cleanup(id);
            }

            storage.SetCallbacks(
                new WauthnDisplayQrcodeCallback(qrCodeWrapper),
                new WauthnGaOnResponseCallback(onResponseWrapper),
                new WauthnUpdateLinkedDataCallback(linkedDataWrapper)
            );
        }

        private static void CheckPreconditions()
        {
            if (!_apiVersionSet)
                SetApiVersion(API_VERSION_NUMBER);
        }

        private static void Cleanup(int id)
        {
            _apiCalls[id]?.Dispose();
            _apiCalls.Remove(id);
        }

        #endregion
    }
}