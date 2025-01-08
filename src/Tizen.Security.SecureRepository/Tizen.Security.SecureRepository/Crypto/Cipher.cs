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
    /// Provides the methods for encrypting and decrypting data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Cipher
    {
        private readonly CipherParameters _parameters;

        /// <summary>
        /// Initializes an instance of Cipher class with CipherParameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="parameters">Algorithm specific parameters.</param>
        public Cipher(CipherParameters parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// Gets algorithm specific parameters.
        /// </summary>
        /// <value>
        /// Algorithm specific parameters.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public CipherParameters Parameters
        {
            get { return _parameters; }
        }

        /// <summary>
        /// Decrypts data using selected key and the algorithm.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Key type specified by keyAlias should be compatible with the algorithm
        /// specified in Parameters.
        /// </remarks>
        /// <remarks>
        /// If password of policy is provided in SaveKey(), the same password should be provided.
        /// </remarks>
        /// <remarks>
        /// Some algorithms may require additional information embedded in encrypted data.
        /// AES GCM is an example.
        /// </remarks>
        /// <param name="keyAlias">Alias of the key to be used for decryption.</param>
        /// <param name="password">Password used in decrypting a key value.</param>
        /// <param name="cipherText">Data to be decrypted.</param>
        /// <returns>Decrypted data.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="keyAlias"/> or <paramref name="cipherText"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when mandatory algorithm parameter is missing or invalid.
        /// Thrown when optional algorithm parameter is invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key-protecting password does not match.
        /// Thrown when key does not exist with given keyAlias.
        /// </exception>
        public byte[] Decrypt(string keyAlias, string password, byte[] cipherText)
        {
            if (keyAlias == null || cipherText == null)
                throw new ArgumentNullException("alias and ciphertxt should not be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.DecryptData(
                        Parameters.Ptr, keyAlias, password,
                        new Interop.CkmcRawBuffer(
                            new PinnedObject(cipherText), cipherText.Length),
                        out ptr),
                    "Failed to decrypt data");
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Encrypts data using selected key and algorithm.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Key type specified by the keyAlias should be compatible with the algorithm
        /// specified in Parameters.
        /// </remarks>
        /// <remarks>
        /// If password of policy is provided in SaveKey(), the same password should be provided.
        /// </remarks>
        /// <remarks>
        /// In case of the AES algorithm, there are no restrictions on
        /// the size of plaintext data. For RSA, the size must be smaller or equal to (key_size_in
        /// bytes - 42). Example: For 1024 RSA key, the maximum data size is
        /// 1024/8 - 42 = 86.
        /// </remarks>
        /// <param name="keyAlias">Alias of the key to be used for encryption.</param>
        /// <param name="password">Password used in decrypting a key value.</param>
        /// <param name="plainText">Data to be encrypted.</param>
        /// <returns>Encrypted data.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="keyAlias"/> or <paramref name="plainText"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when mandatory algorithm parameter is missing or invalid.
        /// Thrown when optional algorithm parameter is invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key-protecting password does not match.
        /// Thrown when key does not exist with given <paramref name="keyAlias"/>.
        /// </exception>
        public byte[] Encrypt(string keyAlias, string password, byte[] plainText)
        {
            if (keyAlias == null || plainText == null)
                throw new ArgumentNullException("alias or plaintxt should not be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.EncryptData(
                        Parameters.Ptr, keyAlias, password,
                        new Interop.CkmcRawBuffer(
                            new PinnedObject(plainText), plainText.Length),
                        out ptr),
                    "Failed to encrypt data");
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }
    }
}
