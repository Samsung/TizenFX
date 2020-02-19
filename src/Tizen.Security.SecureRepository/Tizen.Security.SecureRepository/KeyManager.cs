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
using System.Collections.Generic;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods for storing, retrieving, and creating keys.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class KeyManager : Manager
    {
        /// <summary>
        /// Gets a key from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of a key to retrieve.</param>
        /// <param name="password">
        /// The password used in decrypting a key value.
        /// If password of policy is provided in SaveKey(), the same password should
        /// be provided.
        /// </param>
        /// <returns>A key specified by alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// The alias argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in the invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key does not exist with the alias or the key-protecting password isn't matched.
        /// </exception>
        static public Key Get(string alias, string password)
        {
            if (alias == null)
                throw new ArgumentNullException("alias cannot be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetKey(alias, password, out ptr),
                    "Failed to get key. alias=" + alias);
                return new Key(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.KeyFree(ptr);
            }
        }

        /// <summary>
        /// Gets all aliases of keys, which the client can access.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>All aliases of keys, which the client can access.</returns>
        /// <exception cref="ArgumentException">No alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetKeyAliasList(out ptr),
                    "Failed to get key aliases.");
                return new SafeAliasListHandle(ptr).Aliases;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.AliasListAllFree(ptr);
            }
        }

        /// <summary>
        /// Stores a key inside the secure repository based on the provided policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of a key to be stored.</param>
        /// <param name="key">The key's binary value to be stored.</param>
        /// <param name="policy">The policy about how to store a key securely.</param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in the invalid format. key argument is in the invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key with alias does already exist.
        /// </exception>
        /// <remarks>
        /// The type in key may be set to KeyType.None as an input.
        /// The type is determined inside the secure reposioty during storing keys.
        /// </remarks>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        static public void Save(string alias, Key key, Policy policy)
        {
            if (alias == null || key == null || policy == null)
                throw new ArgumentNullException("More than one of argument is null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.SaveKey(
                    alias, key.ToCkmcKey(), policy.ToCkmcPolicy()),
                "Failed to save Key. alias=" + alias);
        }

        /// <summary>
        /// Checks for alias existence
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="alias">The name of a key to retrieve.</param>
        /// <returns>Boolean indicating the existence of the alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// The alias argument is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Failed to determine the alias existence. Check the errorcode for details
        /// </exception>
        static public bool AliasExists(string alias)
        {
            if (alias == null)
                throw new ArgumentNullException(nameof(alias));

            IntPtr ptr = IntPtr.Zero;

            try
            {
                var errorCode = Interop.CkmcManager.GetKey(alias, string.Empty, out ptr);
                return Interop.CheckForExistingAlias(errorCode);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.KeyFree(ptr);
            }
        }

        /// <summary>
        /// Creates the RSA private/public key pair and stores them inside the secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="size">
        /// The size of key strength to be created. 1024, 2048, and 4096 are supported.
        /// </param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">
        /// The policy about how to store a private key securely.
        /// </param>
        /// <param name="publicKeyPolicy">
        /// The policy about how to store a public key securely.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The size is invalid. privateKeyAlias or publicKeyAlias is invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key with privateKeyAlias or publicKeyAlias does already exist.
        /// </exception>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with the
        /// password in policy.
        /// </remarks>
        static public void CreateRsaKeyPair(
            int size, string privateKeyAlias, string publicKeyAlias,
            Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            if (size != 1024 && size != 2048 && size != 4096)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));
            else if (privateKeyAlias == null || publicKeyAlias == null ||
                privateKeyPolicy == null || publicKeyPolicy == null)
                throw new ArgumentNullException("alias and policy should not be null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.CreateKeyPairRsa(
                    (UIntPtr)size, privateKeyAlias, publicKeyAlias,
                    privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy()),
                "Failed to Create RSA Key Pair");
        }

        /// <summary>
        /// Creates the DSA private/public key pair and stores them inside the secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="size">
        /// The size of key strength to be created. 1024, 2048, 3072, and 4096 are
        /// supported.
        /// </param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">
        /// The policy about how to store a private key securely.
        /// </param>
        /// <param name="publicKeyPolicy">
        /// The policy about how to store a public key securely.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The size is invalid. privateKeyAlias or publicKeyAlias is invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key with privateKeyAlias or publicKeyAlias does already exist.
        /// </exception>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        static public void CreateDsaKeyPair(
            int size, string privateKeyAlias, string publicKeyAlias,
            Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            if (size != 1024 && size != 2048 && size != 3072 && size != 4096)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));
            else if (privateKeyAlias == null || publicKeyAlias == null ||
                privateKeyPolicy == null || publicKeyPolicy == null)
                throw new ArgumentNullException("alias and policy should not be null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.CreateKeyPairDsa(
                    (UIntPtr)size, privateKeyAlias, publicKeyAlias,
                    privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy()),
                "Failed to Create DSA Key Pair");
        }

        /// <summary>
        /// Creates the ECDSA private/public key pair and stores them inside secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The type of elliptic curve of ECDSA.</param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">
        /// The policy about how to store a private key securely.
        /// </param>
        /// <param name="publicKeyPolicy">
        /// The policy about how to store a public key securely.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The elliptic curve type is invalid. privateKeyAlias or publicKeyAlias is in the
        /// invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key with privateKeyAlias or publicKeyAlias does already exist.
        /// </exception>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        static public void CreateEcdsaKeyPair(
            EllipticCurveType type, string privateKeyAlias, string publicKeyAlias,
            Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            if (privateKeyAlias == null || publicKeyAlias == null ||
                privateKeyPolicy == null || publicKeyPolicy == null)
                throw new ArgumentNullException("alias and policy should not be null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.CreateKeyPairEcdsa(
                    (int)type, privateKeyAlias, publicKeyAlias,
                    privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy()),
                "Failed to Create ECDSA Key Pair");
        }

        /// <summary>
        /// Creates the AES key and stores it inside the secure repository based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="size">
        /// The size of the key strength to be created. 128, 192 and 256 are supported.
        /// </param>
        /// <param name="keyAlias">The name of key to be stored.</param>
        /// <param name="policy">The policy about how to store the key securely.</param>
        /// <exception cref="ArgumentNullException">
        /// The keyAlias or policy is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The key size is invalid. keyAlias is in the invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The key with privateKeyAlias or publicKeyAlias does already exist.
        /// </exception>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        static public void CreateAesKey(int size, string keyAlias, Policy policy)
        {
            if (size != 128 && size != 192 && size != 256)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));
            else if (keyAlias == null || policy == null)
                throw new ArgumentNullException("alias and policy should not be null");

            Interop.CheckNThrowException(
                Interop.CkmcManager.CreateKeyAes(
                    (UIntPtr)size, keyAlias, policy.ToCkmcPolicy()),
                "Failed to AES Key");
        }

        // to be static class safely
        internal KeyManager()
        {
        }
    }
}
