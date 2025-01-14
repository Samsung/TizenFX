﻿/*
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
    /// Provides methods for storing and retrieving data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DataManager : Manager
    {
        /// <summary>
        /// Gets data from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">Name of a certificate to retrieve.</param>
        /// <param name="password">
        /// Password used in decrypting a data value.
        /// If password of policy is provided in SaveData(), the same password should
        /// be provided.
        /// </param>
        /// <returns>Data specified by alias.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="alias"/> argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> argument has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when data does not exist with the <paramref name="alias"/>
        /// or data-protecting password does not match.
        /// </exception>
        static public byte[] Get(string alias, string password)
        {
            if (alias == null)
                throw new ArgumentNullException("alias cannot be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetData(alias, password, out ptr),
                    "Failed to get certificate. alias=" + alias);
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Gets all aliases of data accessible by the client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>All aliases of data accessible by the client.</returns>
        /// <exception cref="ArgumentException">Thrown when there's no alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetDataAliasList(out ptr),
                    "Failed to get data aliases");
                return new SafeAliasListHandle(ptr).Aliases;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.AliasListAllFree(ptr);
            }
        }

        /// <summary>
        /// Stores data inside the secure repository based on the provided policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">Name of data to be stored.</param>
        /// <param name="data">Binary value to be stored.</param>
        /// <param name="policy">Data stoting policy.</param>
        /// <exception cref="ArgumentNullException">Any argument is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> argument has an invalid format.
        /// Thrown when <paramref name="policy"/> cannot be unextractable.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when data with given <paramref name="alias"/> already exists.
        /// </exception>
        static public void Save(string alias, byte[] data, Policy policy)
        {
            if (alias == null || data == null || policy == null)
                throw new ArgumentNullException("alias and policy should be null");
            else if (policy.Extractable == false)
                throw new ArgumentException("Data should be extractable");

            Interop.CheckNThrowException(
                Interop.CkmcManager.SaveData(
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
