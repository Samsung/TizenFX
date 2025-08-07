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
using static Interop;

namespace Tizen.Security.WebAuthn
{
    internal abstract class AuthenticatorStorage : IDisposable
    {
        #region Internal unmanaged memory
        protected UnmanagedMemory _credentialsUnmanaged = new();
        protected UnmanagedMemory _hintsUnmanaged = new();
        protected UnmanagedMemory _attestationFormatsUnmanaged = new();
        protected UnmanagedMemory _extensionsUnmanaged = new();
        protected UnmanagedMemory _linkedDeviceUnmanaged = new();

        protected WauthnDisplayQrcodeCallback _qrcodeCallback;
        protected WauthnUpdateLinkedDataCallback _linkedDataCallback;

        private UnmanagedMemory[] _credentialsIdUnmanagedDataArray;
        private UnmanagedMemory[] _credentialsIdUnmanagedConstBufferArray;
        private UnmanagedMemory[] _attestationFormatsUnmanagedDataArray;
        private UnmanagedMemory[] _attestationFormatsUnmanagedConstBufferArray;
        private UnmanagedMemory[] _extensionIdUnmanagedDataArray;
        private UnmanagedMemory[] _extensionIdUnmanagedConstBufferArray;
        private UnmanagedMemory[] _extensionValueUnmanagedDataArray;
        private UnmanagedMemory[] _extensionValueUnmanagedConstBufferArray;

        private UnmanagedMemory _jsonDataUnmanaged = new();
        private UnmanagedMemory _jsonDataConstBufferUnmanaged = new();
        private UnmanagedMemory _credentialsDescriptorsUnmanaged = new();
        private UnmanagedMemory _hintsArrayUnmanaged = new();
        private UnmanagedMemory _attestationFormatsArrayUnmanaged = new();
        private UnmanagedMemory _extensionsArrayUnmanaged = new();
        private UnmanagedMemory _contactIdDataUnmanaged = new();
        private UnmanagedMemory _contactIdUnmanaged = new();
        private UnmanagedMemory _linkIdDataUnmanaged = new();
        private UnmanagedMemory _linkIdUnmanaged = new();
        private UnmanagedMemory _linkSecretDataUnmanaged = new();
        private UnmanagedMemory _linkSecretUnmanaged = new();
        private UnmanagedMemory _authenticatorPubkeyDataUnmanaged = new();
        private UnmanagedMemory _authenticatorPubkeyUnmanaged = new();
        private UnmanagedMemory _authenticatorNameDataUnmanaged = new();
        private UnmanagedMemory _authenticatorNameUnmanaged = new();
        private UnmanagedMemory _signatureDataUnmanaged = new();
        private UnmanagedMemory _signatureUnmanaged = new();
        private UnmanagedMemory _tunnelServerDomainDataUnmanaged = new();
        private UnmanagedMemory _tunnelServerDomainUnmanaged = new();
        private UnmanagedMemory _identityKeyDataUnmanaged = new();
        private UnmanagedMemory _identityKeyUnmanaged = new();
        #endregion

        private bool _disposed = false;

        public virtual void Dispose()
        {
            if (_disposed)
                return;

            CleanupArray(_credentialsIdUnmanagedDataArray);
            CleanupArray(_credentialsIdUnmanagedConstBufferArray);
            CleanupArray(_attestationFormatsUnmanagedDataArray);
            CleanupArray(_attestationFormatsUnmanagedConstBufferArray);
            CleanupArray(_extensionIdUnmanagedDataArray);
            CleanupArray(_extensionIdUnmanagedConstBufferArray);
            CleanupArray(_extensionValueUnmanagedDataArray);
            CleanupArray(_extensionValueUnmanagedConstBufferArray);

            _jsonDataUnmanaged.Dispose();
            _jsonDataConstBufferUnmanaged.Dispose();
            _credentialsDescriptorsUnmanaged.Dispose();
            _credentialsUnmanaged.Dispose();
            _hintsArrayUnmanaged.Dispose();
            _hintsUnmanaged.Dispose();
            _attestationFormatsArrayUnmanaged.Dispose();
            _attestationFormatsUnmanaged.Dispose();
            _extensionsArrayUnmanaged.Dispose();
            _extensionsUnmanaged.Dispose();
            _contactIdDataUnmanaged.Dispose();
            _contactIdUnmanaged.Dispose();
            _linkIdDataUnmanaged.Dispose();
            _linkIdUnmanaged.Dispose();
            _linkSecretDataUnmanaged.Dispose();
            _linkSecretUnmanaged.Dispose();
            _authenticatorPubkeyDataUnmanaged.Dispose();
            _authenticatorPubkeyUnmanaged.Dispose();
            _authenticatorNameDataUnmanaged.Dispose();
            _authenticatorNameUnmanaged.Dispose();
            _signatureDataUnmanaged.Dispose();
            _signatureUnmanaged.Dispose();
            _tunnelServerDomainDataUnmanaged.Dispose();
            _tunnelServerDomainUnmanaged.Dispose();
            _identityKeyDataUnmanaged.Dispose();
            _identityKeyUnmanaged.Dispose();
            _linkedDeviceUnmanaged.Dispose();

            _disposed = true;
        }

        #region Data marshalling
        protected void CopyClientData(ClientData clientData)
        {
            _jsonDataUnmanaged = UnmanagedMemory.PinArray(clientData.JsonData);
            _jsonDataConstBufferUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_jsonDataUnmanaged, (nuint)clientData.JsonData.Length));
            WauthnClientData = new WauthnClientData(_jsonDataConstBufferUnmanaged, clientData.HashAlgo);
        }

        protected void CopyCredentials(IEnumerable<PubkeyCredDescriptor> credentials)
        {
            if (credentials is null || !credentials.Any())
                return;

            var credentialsCount = credentials.Count();
            _credentialsIdUnmanagedDataArray = new UnmanagedMemory[credentialsCount];
            _credentialsIdUnmanagedConstBufferArray = new UnmanagedMemory[credentialsCount];
            var credentialsStructArray = new WauthnPubkeyCredDescriptor[credentialsCount];

            for (int i = 0; i < credentialsCount; i++)
            {
                PubkeyCredDescriptor descriptor = credentials.ElementAt(i);
                _credentialsIdUnmanagedDataArray[i] = UnmanagedMemory.PinArray(descriptor.Id);
                var credentialIdUnmanagedConstBuffer = new UnmanagedMemory(new WauthnConstBuffer(_credentialsIdUnmanagedDataArray[i], (nuint)descriptor.Id.Length));
                _credentialsIdUnmanagedConstBufferArray[i] = credentialIdUnmanagedConstBuffer;
                credentialsStructArray[i] = new WauthnPubkeyCredDescriptor(descriptor.Type, credentialIdUnmanagedConstBuffer, descriptor.Transport);
            }
            _credentialsDescriptorsUnmanaged = UnmanagedMemory.PinArray(credentialsStructArray);
            _credentialsUnmanaged = new UnmanagedMemory(new WauthnPubkeyCredDescriptors((nuint)credentialsCount, _credentialsDescriptorsUnmanaged));
        }

        protected void CopyHints(IEnumerable<PubkeyCredHint> hints)
        {
            if (hints is null || !hints.Any())
                return;

            int[] hintsArray = hints.Select((PubkeyCredHint hint) => (int)hint).ToArray();
            _hintsArrayUnmanaged = UnmanagedMemory.PinArray(hintsArray);
            _hintsUnmanaged = new UnmanagedMemory(new WauthnPubkeyCredHints((nuint)hintsArray.Length, _hintsArrayUnmanaged));
        }

        protected void CopyAttestationFormats(IEnumerable<byte[]> attestationFormats)
        {
            if (attestationFormats is null || !attestationFormats.Any())
                return;

            var attestationFormatsCount = attestationFormats.Count();
            _attestationFormatsUnmanagedDataArray = new UnmanagedMemory[attestationFormatsCount];
            _attestationFormatsUnmanagedConstBufferArray = new UnmanagedMemory[attestationFormatsCount];
            var attestationFormatConstBufferStructArray = new WauthnConstBuffer[attestationFormatsCount];


            for (int i = 0; i < attestationFormatsCount; i++)
            {
                byte[] attestationFormat = attestationFormats.ElementAt(i);
                _attestationFormatsUnmanagedDataArray[i] = UnmanagedMemory.PinArray(attestationFormat);
                attestationFormatConstBufferStructArray[i] = new WauthnConstBuffer(_attestationFormatsUnmanagedDataArray[i], (nuint)attestationFormat.Length);
                _attestationFormatsUnmanagedConstBufferArray[i] = new UnmanagedMemory(attestationFormatConstBufferStructArray[i]);
            }
            _attestationFormatsArrayUnmanaged = UnmanagedMemory.PinArray(attestationFormatConstBufferStructArray);
            _attestationFormatsUnmanaged = new UnmanagedMemory(new WauthnAttestationFormats((nuint)attestationFormatsCount, _attestationFormatsArrayUnmanaged));
        }

        protected void CopyExtensions(IEnumerable<AuthenticationExtension> extensions)
        {
            if (extensions is null || !extensions.Any())
                return;

            var extensionCount = extensions.Count();
            var extensionStructArray = new WauthnAuthenticationExt[extensionCount];
            _extensionIdUnmanagedDataArray = new UnmanagedMemory[extensionCount];
            _extensionIdUnmanagedConstBufferArray = new UnmanagedMemory[extensionCount];
            _extensionValueUnmanagedDataArray = new UnmanagedMemory[extensionCount];
            _extensionValueUnmanagedConstBufferArray = new UnmanagedMemory[extensionCount];

            for (int i = 0; i < extensionCount; i++)
            {
                AuthenticationExtension ext = extensions.ElementAt(i);
                _extensionIdUnmanagedDataArray[i] = UnmanagedMemory.PinArray(ext.ExtensionId);
                var extensionIdUnmanagedConstBuffer = new UnmanagedMemory(new WauthnConstBuffer(_extensionIdUnmanagedDataArray[i], (nuint)ext.ExtensionId.Length));
                _extensionIdUnmanagedConstBufferArray[i] = extensionIdUnmanagedConstBuffer;

                _extensionValueUnmanagedDataArray[i] = UnmanagedMemory.PinArray(ext.ExtensionValue);
                var extensionValueUnmanagedConstBuffer = new UnmanagedMemory(new WauthnConstBuffer(_extensionValueUnmanagedDataArray[i], (nuint)ext.ExtensionValue.Length));
                _extensionValueUnmanagedConstBufferArray[i] = extensionValueUnmanagedConstBuffer;

                extensionStructArray[i] = new WauthnAuthenticationExt(extensionIdUnmanagedConstBuffer, extensionValueUnmanagedConstBuffer);
            }
            _extensionsArrayUnmanaged = UnmanagedMemory.PinArray(extensionStructArray);
            _extensionsUnmanaged = new UnmanagedMemory(new WauthnAuthenticationExts((nuint)extensionCount, _extensionsArrayUnmanaged));
        }

        protected void CopyLinkedDevice(HybridLinkedData linkedDevice)
        {
            if (linkedDevice is null)
                return;

            _contactIdDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.ContactId);
            _contactIdUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_contactIdDataUnmanaged, (nuint)linkedDevice.ContactId.Length));

            _linkIdDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.LinkId);
            _linkIdUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_linkIdDataUnmanaged, (nuint)linkedDevice.LinkId.Length));

            _linkSecretDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.LinkSecret);
            _linkSecretUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_linkSecretDataUnmanaged, (nuint)linkedDevice.LinkSecret.Length));

            _authenticatorPubkeyDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.AuthenticatorPubkey);
            _authenticatorPubkeyUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_authenticatorPubkeyDataUnmanaged, (nuint)linkedDevice.AuthenticatorPubkey.Length));

            _authenticatorNameDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.AuthenticatorName);
            _authenticatorNameUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_authenticatorNameDataUnmanaged, (nuint)linkedDevice.AuthenticatorName.Length));

            _signatureDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.Signature);
            _signatureUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_signatureDataUnmanaged, (nuint)linkedDevice.Signature.Length));

            _tunnelServerDomainDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.TunnelServerDomain);
            _tunnelServerDomainUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_tunnelServerDomainDataUnmanaged, (nuint)linkedDevice.TunnelServerDomain.Length));

            _identityKeyDataUnmanaged = UnmanagedMemory.PinArray(linkedDevice.IdentityKey);
            _identityKeyUnmanaged = new UnmanagedMemory(new WauthnConstBuffer(_identityKeyDataUnmanaged, (nuint)linkedDevice.IdentityKey.Length));

            _linkedDeviceUnmanaged = new UnmanagedMemory(new WauthnHybridLinkedData(
                _contactIdUnmanaged,
                _linkIdUnmanaged,
                _linkSecretUnmanaged,
                _authenticatorPubkeyUnmanaged,
                _authenticatorNameUnmanaged,
                _signatureUnmanaged,
                _tunnelServerDomainUnmanaged,
                _identityKeyUnmanaged));
        }
        #endregion

        protected static void CleanupArray(UnmanagedMemory[] array)
        {
            if (array is null)
                return;
            foreach (var memory in array)
                memory.Dispose();
        }

        public WauthnClientData WauthnClientData { get; private set; }
    }
}