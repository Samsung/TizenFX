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
    internal class AuthenticatorGetAssertionStorage : AuthenticatorStorage
    {
        private WauthnGaOnResponseCallback _responseCallback;
        private bool _disposed = false;

        public AuthenticatorGetAssertionStorage(ClientData clientData, PubkeyCredRequestOptions options)
        {
            CopyClientData(clientData);
            CopyCredRequestOptions(options);
        }

        public void SetCallbacks(
            WauthnDisplayQrcodeCallback qrcodeCallback,
            WauthnGaOnResponseCallback responseCallback,
            WauthnUpdateLinkedDataCallback linkedDataCallback)
        {
            _qrcodeCallback = qrcodeCallback;
            _responseCallback = responseCallback;
            _linkedDataCallback = linkedDataCallback;

            WauthnGaCallbacks = new WauthnGaCallbacks(_qrcodeCallback, _responseCallback, _linkedDataCallback);
        }

        public override void Dispose()
        {
            if (_disposed)
                return;

            base.Dispose();

            _disposed = true;
        }

        private void CopyCredRequestOptions(PubkeyCredRequestOptions options)
        {
            CopyCredentials(options.AllowCredentials);
            CopyHints(options.Hints);
            CopyAttestationFormats(options.AttestationFormats);
            CopyExtensions(options.Extensions);
            CopyLinkedDevice(options.LinkedDevice);
            WauthnPubkeyCredRequestOptions = new WauthnPubkeyCredRequestOptions(
                (nuint)options.Timeout,
                options.RpId,
                _credentialsUnmanaged,
                options.UserVerification,
                _hintsUnmanaged,
                options.Attestation,
                _attestationFormatsUnmanaged,
                _extensionsUnmanaged,
                _linkedDeviceUnmanaged);
        }

        public WauthnGaCallbacks WauthnGaCallbacks { get; private set; }
        public WauthnPubkeyCredRequestOptions WauthnPubkeyCredRequestOptions { get; private set; }
    }
}