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
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods for storing and retrieving data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DataManager : Manager
    {
        /// <summary>
        /// Gets data from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of a certificate to retrieve.</param>
        /// <param name="password">
        /// The password used in decrypting a data value.
        /// If password of policy is provided in SaveData(), the same password should
        /// be provided.
        /// </param>
        /// <returns>Data specified by alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// The alias argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in the invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Data does not exist with the alias or data-protecting password isn't matched.
        /// </exception>
        static public byte[] Get(string alias, string password)
        {
            if (alias == null)
                throw new ArgumentNullException("alias cannot be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                CheckNThrowException(
                    CkmcManager.GetData(alias, password, out ptr),
                    "Failed to get certificate. alias=" + alias);
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Checks for alias existence
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="alias">The name of a certificate to retrieve.</param>
        /// <returns>Boolean indicating the exitsance of the alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// The alias argument is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Indicates failure to communicate with the Keystore. Check the errorcode for details
        /// </exception>
        static public bool AliasExists(string alias)
        {
            if (alias == null)
                throw new ArgumentNullException("alias cannot be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                var errorCode = CkmcManager.GetData(alias, string.Empty, out ptr);
                if((int)KeyManagerError.UnknownAlias == errorCode)
                    return false;

                if((int)KeyManagerError.AuthenticationFailed == errorCode ||
                   (int)KeyManagerError.None == errorCode) // Key already exists, we just may have used the incorrect password
                    return true;
                CheckNThrowException(errorCode, "Failed to determine alias existence.");
                throw new InvalidOperationException("Unreachable"); //Unreachable. Interop.CheckNThrow will throw an Exception as we test for KeyManagerError.None
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Gets all aliases of data, which the client can access.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>All aliases of data, which the client can access.</returns>
        /// <exception cref="ArgumentException">No alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                CheckNThrowException(
                    CkmcManager.GetDataAliasList(out ptr),
                    "Failed to get data aliases");
                return new SafeAliasListHandle(ptr).Aliases;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    CkmcTypes.AliasListAllFree(ptr);
            }
        }

        /// <summary>
        /// Stores data inside the secure repository based on the provided policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">The name of data to be stored.</param>
        /// <param name="data">The binary value to be stored.</param>
        /// <param name="policy">The policy about how to store data securely.</param>
        /// <exception cref="ArgumentNullException">
        /// Any of argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The alias argument is in the invalid format. Data policy cannot be unextractable.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Data with alias already exist.
        /// </exception>
        static public void Save(string alias, byte[] data, Policy policy)
        {
            if (alias == null || data == null || policy == null)
                throw new ArgumentNullException("alias and policy should be null");
            else if (policy.Extractable == false)
                throw new ArgumentException("Data should be extractable");

            CheckNThrowException(
                CkmcManager.SaveData(
                    alias,
                    new Interop.CkmcRawBuffer(new PinnedObject(data), data.Length),
                    policy.ToCkmcPolicy()),
                "Failed to save data. alias=" + alias);
        }

        // to be static class safely
        internal DataManager()
        {
        }
    }
}
