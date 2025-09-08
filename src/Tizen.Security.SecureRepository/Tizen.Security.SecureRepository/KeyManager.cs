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
    /// Provides methods for storing, retrieving, and creating keys.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class KeyManager : Manager
    {
        /// <summary>
        /// Gets a key from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">Name of a key to retrieve.</param>
        /// <param name="password">
        /// Password used in decrypting key value.
        /// If password of policy is provided in SaveKey(), the same password should
        /// be provided.
        /// </param>
        /// <returns>Key specified by alias.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="alias"/> argument is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> argument has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key does not exist with given <paramref name="alias"/>
        /// or the key-protecting password does not match.
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
        /// Gets all aliases of keys accessible by the client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>All aliases of keys accessible by the client.</returns>
        /// <exception cref="ArgumentException">Thrown when there's no alias to get.</exception>
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
        /// <remarks>
        /// Type in key may be set to KeyType. None as an input.
        /// Type is determined inside the secure repository during storing keys.
        /// </remarks>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        /// <param name="alias">Name of a key to be stored.</param>
        /// <param name="key">Key's binary value to be stored.</param>
        /// <param name="policy">Key storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any provided argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> or <paramref name="key"/> argument has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key with given alias already exists.
        /// </exception>
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
        /// Creates RSA private/public key pair and stores them inside the secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// 1024, 2048, and 4096 sizes are supported.
        /// </remarks>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with the
        /// password in policy.
        /// </remarks>
        /// <param name="size">Size of key strength to be created.</param>
        /// <param name="privateKeyAlias">Name of a private key to be stored.</param>
        /// <param name="publicKeyAlias">Name of a public key to be stored.</param>
        /// <param name="privateKeyPolicy">Private key storing policy.</param>
        /// <param name="publicKeyPolicy">Public key storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any provided argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="size"/> is invalid.
        /// Thrown when <paramref name="privateKeyAlias"/> or
        /// <paramref name="publicKeyAlias"/> has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key with <paramref name="privateKeyAlias"/> or <paramref name="publicKeyAlias"/> already exists.
        /// </exception>
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
        /// Creates DSA private/public key pair and stores them inside the secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// 1024, 2048, 3072, and 4096 sizes are supported.
        /// </remarks>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        /// <param name="size">Size of key strength to be created.</param>
        /// <param name="privateKeyAlias">Name of a private key to be stored.</param>
        /// <param name="publicKeyAlias">Name of a public key to be stored.</param>
        /// <param name="privateKeyPolicy">Private key storing policy.</param>
        /// <param name="publicKeyPolicy">Public key storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any provided argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="size"/> is invalid.
        /// Thrown when <paramref name="privateKeyAlias"/> or
        /// <paramref name="publicKeyAlias"/> has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key with <paramref name="privateKeyAlias"/> or
        /// <paramref name="publicKeyAlias"/> already exists.
        /// </exception>
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
        /// Creates ECDSA private/public key pair and stores them inside secure repository
        /// based on each policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        /// <param name="type">Type of elliptic curve of ECDSA.</param>
        /// <param name="privateKeyAlias">Name of private key to be stored.</param>
        /// <param name="publicKeyAlias">Name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">Private key storing policy.</param>
        /// <param name="publicKeyPolicy">Public key storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any provided argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="type"/> is invalid.
        /// Thrown when <paramref name="privateKeyAlias"/> or
        /// <paramref name="publicKeyAlias"/> has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key with <paramref name="privateKeyAlias"/> or
        /// <paramref name="publicKeyAlias"/> already exists.
        /// </exception>
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
        /// Creates AES key and stores it inside the secure repository based on policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// 128, 192 and 256 sizes are supported.
        /// </remarks>
        /// <remarks>
        /// If the password in policy is provided, the key is additionally encrypted with
        /// the password in policy.
        /// </remarks>
        /// <param name="size">Size of the key strength to be created.</param>
        /// <param name="keyAlias">The name of key to be stored.</param>
        /// <param name="policy">Key storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="keyAlias"/> or <paramref name="policy"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="size"/> is invalid.
        /// Thrown when <paramref name="keyAlias"/> has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when key with <paramref name="keyAlias"/> already exists.
        /// </exception>
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
