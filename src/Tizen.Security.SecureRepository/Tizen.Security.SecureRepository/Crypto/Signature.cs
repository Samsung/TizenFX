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
    /// <since_tizen> 3 </since_tizen>
    public class Signature
    {
        private SignatureParameters _parameters;

        /// <summary>
        /// A constructor of Signature that takes the algorithm specific parameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="parameters">The algorithm specific parameters.</param>
        public Signature(SignatureParameters parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// The algorithm specific parameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SignatureParameters Parameters
        {
            get { return _parameters; }
        }

        /// <summary>
        /// Creates a signature on a given message using a private key and returns
        /// the signature.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="privateKeyAlias">The name of private key.</param>
        /// <param name="password">
        /// The password used in decrypting a private key value.
        /// </param>
        /// <param name="message">The message that is signed with a private key.</param>
        /// <returns>A newly created signature.</returns>
        /// <exception cref="ArgumentNullException">
        /// privateKeyAlias or message is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// privateKeyAlias is invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Key-protecting password isn't matched.
        /// Key does not exist with privateKeyAlias.
        /// </exception>
        /// <remarks>
        /// The key type specified by privateKeyAlias should be compatible with the
        /// algorithm specified in Parameters.
        /// </remarks>
        /// <remarks>
        /// If password of policy is provided during storing a key, the same password
        /// should be provided.
        /// </remarks>
        public byte[] Sign(string privateKeyAlias, string password, byte[] message)
        {
            if (privateKeyAlias == null || message == null)
                throw new ArgumentNullException("alias and message should not be null");

            int hash = (int)HashAlgorithm.None;
            try
            {
                hash = (int)Parameters.Get(SignatureParameterName.HashAlgorithm);
            }
            catch {}

            int rsaPadding = (int)RsaPaddingAlgorithm.None;
            try
            {
                rsaPadding = (int)Parameters.Get(SignatureParameterName.RsaPaddingAlgorithm);
            }
            catch {}

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.CreateSignature(
                        privateKeyAlias, password,
                        new Interop.CkmcRawBuffer(
                            new PinnedObject(message), message.Length),
                        hash, rsaPadding, out ptr),
                    "Failed to generate signature");
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Verifies a given signature on a given message using a public key and returns
        /// the signature status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="publicKeyAlias">The name of public key.</param>
        /// <param name="password">
        /// The password used in decrypting a public key value.
        /// </param>
        /// <param name="message">The input on which the signature is created.</param>
        /// <param name="signature">The signature that is verified with public key.</param>
        /// <returns>
        /// The signature status. True is returned when the signature is valid.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// publicKeyAlias, message or signature is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// publicKeyAlias is invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Key-protecting password isn't matched.
        /// Key does not exist with publicKeyAlias.
        /// </exception>
        /// <remarks>
        /// The key type specified by publicKeyAlias should be compatible with the
        /// algorithm specified in Parameters.
        /// </remarks>
        /// <remarks>
        /// If password of policy is provided during storing a key, the same password
        /// should be provided.
        /// </remarks>
        public bool Verify(
            string publicKeyAlias, string password, byte[] message, byte[] signature)
        {
            if (publicKeyAlias == null || message == null || signature == null)
                throw new ArgumentNullException("mandatory arg should not be null");

            int hash = (int)HashAlgorithm.None;
            try
            {
                hash = (int)Parameters.Get(SignatureParameterName.HashAlgorithm);
            }
            catch {}

            int rsaPadding = (int)RsaPaddingAlgorithm.None;
            try
            {
                rsaPadding = (int)Parameters.Get(SignatureParameterName.RsaPaddingAlgorithm);
            }
            catch {}


            int ret = Interop.CkmcManager.VerifySignature(
                publicKeyAlias,
                password,
                new Interop.CkmcRawBuffer(new PinnedObject(message), message.Length),
                new Interop.CkmcRawBuffer(new PinnedObject(signature), signature.Length),
                hash,
                rsaPadding);

            if (ret == (int)Interop.KeyManagerError.VerificationFailed)
                return false;
            Interop.CheckNThrowException(ret, "Failed to verify signature");

            return true;
        }
    }
}
