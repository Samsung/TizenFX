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
    /// This class provides the methods storing and retrieving data.
    /// </summary>
    public class DataManager : Manager
    {
        /// <summary>
        /// Gets data from secure repository.
        /// </summary>
        /// <param name="alias">The name of a certificate to retrieve.</param>
        /// <param name="password">The password used in decrypting a data value.
        /// If password of policy is provided in SaveData(), the same password should be provided
        /// </param>
        /// <returns>data specified by alias.</returns>
        static public byte[] GetData(string alias, string password)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcManager.CkmcGetData(alias, password, out ptr);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get certificate. alias=" + alias);

            return new SafeRawBufferHandle(ptr).Data;
        }

        /// <summary>
        /// Gets all alias of data which the client can access.
        /// </summary>
        /// <returns>all alias of data which the client can access.</returns>
        static public IEnumerable<string> GetDataAliases()
        {
            IntPtr ptr = new IntPtr();
            int ret = Interop.CkmcManager.CkmcGetDataAliasList(out ptr);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get data aliases");

            return new SafeAliasListHandle(ptr).Aliases;
        }

        /// <summary>
        /// Stores data inside secure repository based on the provided policy.
        /// </summary>
        /// <param name="alias">The name of data to be stored.</param>
        /// <param name="data">The binary value to be stored.</param>
        /// <param name="policy">The policy about how to store data securely.</param>
        static public void SaveData(string alias, byte[] data, Policy policy)
        {
            Interop.CkmcRawBuffer rawBuff = new Interop.CkmcRawBuffer(new PinnedObject(data), data.Length);

            int ret = Interop.CkmcManager.CkmcSaveData(alias, rawBuff, policy.ToCkmcPolicy());
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to save data. alias=" + alias);
        }
    }
}
