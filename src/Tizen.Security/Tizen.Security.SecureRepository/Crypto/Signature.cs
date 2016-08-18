/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// This class provides the methods creating and verifying a signature.
    /// </summary>
    public class Signature
    {
        private SignatureParameters _parameters;

        /// <summary>
        /// A constructor of Signature that takes the algorithm specific parameters.
        /// </summary>
        /// <param name="parameters">The algorithm specific parameters.</param>
        public Signature(SignatureParameters parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// The algorithm specific parameters.
        /// </summary>
        public SignatureParameters Parameters
        {
            get { return _parameters; }
        }

        /// <summary>
        /// Creates a signature on a given message using a private key and returns the signature.
        /// </summary>
        /// <param name="privateKeyAlias">The name of private key.</param>
        /// <param name="password">The password used in decrypting a private key value.</param>
        /// <param name="message.">The message that is signed with a private key.</param>
        /// <returns>A newly created signature.</returns>
        /// <remarks>The key type specified by privateKeyAlias should be compatible with the algorithm specified in Parameters.</remarks>
        /// <remarks>If password of policy is provided during storing a key, the same password should be provided.</remarks>
        public byte[] Sign(string privateKeyAlias, string password, byte[] message)
        {
            int hash = (int)HashAlgorithm.None;
            try
            {
                hash = (int)Parameters.Get(SignatureParameterName.HashAlgorithm);
            }
            catch { }

            int rsaPadding = (int)RsaPaddingAlgorithm.None;
            try
            {
                rsaPadding = (int)Parameters.Get(SignatureParameterName.RsaPaddingAlgorithm);
            }
            catch { }

            IntPtr ptrSignature = new IntPtr();
            Interop.CkmcRawBuffer messageBuff = new Interop.CkmcRawBuffer(new PinnedObject(message), message.Length);

            int ret = Interop.CkmcManager.CkmcCreateSignature(privateKeyAlias, password, messageBuff,
                                                            hash, rsaPadding, out ptrSignature);
            Interop.CheckNThrowException(ret, "Failed to generate signature");

            return new SafeRawBufferHandle(ptrSignature).Data;
        }

        /// <summary>
        /// Verifies a given signature on a given message using a public key and returns the signature status.
        /// </summary>
        /// <param name="publicKeyAlias">The name of public key.</param>
        /// <param name="password">The password used in decrypting a public key value.</param>
        /// <param name="message.">The input on which the signature is created.</param>
        /// <param name="signature.">The signature that is verified with public key.</param>
        /// <returns>The signature statue. True is returned when the signature is valid</returns>
        /// <remarks>The key type specified by publicKeyAlias should be compatible with the algorithm specified in Parameters.</remarks>
        /// <remarks>If password of policy is provided during storing a key, the same password should be provided.</remarks>
        public bool Verify(string publicKeyAlias, string password, byte[] message, byte[] signature)
        {
            int hash = (int)HashAlgorithm.None;
            try
            {
                hash = (int)Parameters.Get(SignatureParameterName.HashAlgorithm);
            }
            catch { }

            int rsaPadding = (int)RsaPaddingAlgorithm.None;
            try
            {
                rsaPadding = (int)Parameters.Get(SignatureParameterName.RsaPaddingAlgorithm);
            }
            catch { }

            Interop.CkmcRawBuffer messageBuff = new Interop.CkmcRawBuffer(new PinnedObject(message), message.Length);
            Interop.CkmcRawBuffer signatureBuff = new Interop.CkmcRawBuffer(new PinnedObject(signature), signature.Length);

            int ret = Interop.CkmcManager.CkmcVerifySignature(publicKeyAlias, password, messageBuff,
                                                        signatureBuff, hash, rsaPadding);
            if (ret == (int)Interop.KeyManagerError.VerificationFailed)
                return false;
            Interop.CheckNThrowException(ret, "Failed to verify signature");

            return true;
        }
    }
}
