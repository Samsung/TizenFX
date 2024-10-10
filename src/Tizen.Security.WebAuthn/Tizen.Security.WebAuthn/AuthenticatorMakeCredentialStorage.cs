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
using System.Linq;
using static Interop;

namespace Tizen.Security.WebAuthn
{
    internal class AuthenticatorMakeCredentialStorage : AuthenticatorStorage
    {
        #region Internal unmanaged memory
        private UnmanagedMemory _rpNameUnmanaged = new();
        private UnmanagedMemory _rpIdUnmanaged = new();
        private UnmanagedMemory _rpUnmanaged = new();
        private UnmanagedMemory _userNameUnmanaged = new();
        private UnmanagedMemory _userIdDataUnmanaged = new();
        private UnmanagedMemory _userIdConstBufferUnmanaged = new();
        private UnmanagedMemory _userDisplayNameUnmanaged = new();
        private UnmanagedMemory _userUnmanaged = new();
        private UnmanagedMemory _pubkeyCredParamsParametersUnmanaged = new();
        private UnmanagedMemory _pubkeyCredParamsUnmanaged = new();
        private UnmanagedMemory _authenticatorSelectionUnmanaged = new();

        private WauthnMcOnResponseCallback _responseCallback;
        #endregion

        private bool _disposed = false;

        public AuthenticatorMakeCredentialStorage(ClientData clientData, PubkeyCredCreationOptions options)
        {
            CopyClientData(clientData);
            CopyCredCreationOptions(options);
        }

        public void SetCallbacks(
            WauthnDisplayQrcodeCallback qrcodeCallback,
            WauthnMcOnResponseCallback responseCallback,
            WauthnUpdateLinkedDataCallback linkedDataCallback)
        {
            _qrcodeCallback = qrcodeCallback;
            _responseCallback = responseCallback;
            _linkedDataCallback = linkedDataCallback;

            WauthnMcCallbacks = new WauthnMcCallbacks(_qrcodeCallback, _responseCallback, _linkedDataCallback);
        }

        public override void Dispose()
        {
            if (_disposed)
                return;

            _rpNameUnmanaged.Dispose();
            _rpIdUnmanaged.Dispose();
            _rpUnmanaged.Dispose();
            _userNameUnmanaged.Dispose();
            _userIdConstBufferUnmanaged.Dispose();
            _userDisplayNameUnmanaged.Dispose();
            _userUnmanaged.Dispose();
            _pubkeyCredParamsParametersUnmanaged.Dispose();
            _pubkeyCredParamsUnmanaged.Dispose();

            base.Dispose();

            _disposed = true;
        }

        #region Data marshalling
        private void CopyCredCreationOptions(PubkeyCredCreationOptions options)
        {
            CopyRp(options.Rp);
            CopyUser(options.User);
            CopyCredParams(options.PubkeyCredParams);
            CopyCredentials(options.ExcludeCredentials);
            CopyAuthenticatorSelection(options.AuthenticatorSelection);
            CopyHints(options.Hints);
            CopyAttestationFormats(options.AttestationFormats);
            CopyExtensions(options.Extensions);
            CopyLinkedDevice(options.LinkedDevice);

            WauthnPubkeyCredCreationOptions = new WauthnPubkeyCredCreationOptions(
                    _rpUnmanaged,
                    _userUnmanaged,
                    _pubkeyCredParamsUnmanaged,
                    (nuint)options.Timeout,
                    _credentialsUnmanaged,
                    _authenticatorSelectionUnmanaged,
                    _hintsUnmanaged,
                    options.Attestation,
                    _attestationFormatsUnmanaged,
                    _extensionsUnmanaged,
                    _linkedDeviceUnmanaged);
        }

        private void CopyRp(RelyingPartyEntity rp)
        {
            _rpNameUnmanaged = new UnmanagedMemory(rp.Name);
            _rpIdUnmanaged = new UnmanagedMemory(rp.Id);
            _rpUnmanaged = new UnmanagedMemory(new WauthnRpEntity(_rpNameUnmanaged, _rpIdUnmanaged));
        }

        private void CopyUser(UserEntity user)
        {
                _userNameUnmanaged = new UnmanagedMemory(user.Name);
                _userIdDataUnmanaged = UnmanagedMemory.PinArray(user.Id);
                _userIdConstBufferUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_userIdDataUnmanaged, (nuint)user.Id.Length));
                _userDisplayNameUnmanaged = new UnmanagedMemory(user.DisplayName);
                _userUnmanaged = new UnmanagedMemory(new WauthnUserEntity(
                    _userNameUnmanaged,
                    _userIdConstBufferUnmanaged,
                    _userDisplayNameUnmanaged));
        }

        private void CopyCredParams(IEnumerable<PubkeyCredParam> credParams)
        {
            if (credParams is null || !credParams.Any())
                return;

            WauthnPubkeyCredParam[] pubkeyCredParamStructArray = credParams.Select((PubkeyCredParam param) => new WauthnPubkeyCredParam(param.Type, param.Alg)).ToArray();
            _pubkeyCredParamsParametersUnmanaged = UnmanagedMemory.PinArray(pubkeyCredParamStructArray);
            _pubkeyCredParamsUnmanaged = new UnmanagedMemory(new WauthnPubkeyCredParams((nuint)pubkeyCredParamStructArray.Length, _pubkeyCredParamsParametersUnmanaged));
        }

        protected void CopyAuthenticatorSelection(AuthenticationSelectionCriteria selection)
        {
            if (selection is null)
                return;

            _authenticatorSelectionUnmanaged = new UnmanagedMemory(new WauthnAuthenticationSelCri(
                selection.Attachment,
                selection.ResidentKey,
                (byte)(selection.RequireResidentKey ? 1 : 0),
                selection.UserVerification));
        }
        #endregion

        public WauthnMcCallbacks WauthnMcCallbacks { get; private set; }
        public WauthnPubkeyCredCreationOptions WauthnPubkeyCredCreationOptions { get; private set; }
    }
}