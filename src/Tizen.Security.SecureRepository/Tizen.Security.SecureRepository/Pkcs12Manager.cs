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

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods storing, retrieving Pkcs12 contents.
    /// </summary>
    public class Pkcs12Manager : Manager
    {
        /// <summary>
        /// Gets Pkcs12 contents from secure repository.
        /// </summary>
        /// <param name="alias">The name of data to retrieve.</param>
        /// <param name="keyPassword">The password used in decrypting a private key value.
        /// If password of keyPolicy is provided in SavePkcs12(), the same password should be provided
        /// </param>
        /// <param name="cerificatePassword">The password used in decrypting a certificate value.
        /// If password of certificatePolicy is provided in SavePkcs12(), the same password should be provided
        /// </param>
        /// <returns>A Pkcs12 data specified by alias.</returns>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">
        /// Pkcs12 does not exist with the alias.
        /// Optional password of key in Pkcs12 isn't matched.
        /// Optional password of certificate in Pkcs12 isn't matched.
        /// </exception>
        static public Pkcs12 Get(string alias, string keyPassword, string cerificatePassword)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcManager.GetPkcs12(alias, keyPassword, cerificatePassword, out ptr);
            Interop.CheckNThrowException(ret, "Failed to get PKCS12. alias=" + alias);

            return new Pkcs12(ptr);
        }

        /// <summary>
        /// Stores PKCS12's contents inside key manager based on the provided policies.
        /// All items from the PKCS12 will use the same alias.
        /// </summary>
        /// <param name="alias">The name of a data to be stored.</param>
        /// <param name="pkcs12">The pkcs12 data to be stored.</param>
        /// <param name="keyPolicy">The policy about how to store pkcs's private key.</param>
        /// <param name="certificatePolicy">The policy about how to store pkcs's certificate.</param>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format. Pkcs12 argument is invalid format.</exception>
        /// <exception cref="InvalidOperationException">Pkcs12 with alias does already exist.</exception>
        static public void Save(string alias, Pkcs12 pkcs12, Policy keyPolicy, Policy certificatePolicy)
        {
            int ret = Interop.CkmcManager.SavePkcs12(alias,
                                                     new PinnedObject(pkcs12.ToCkmcPkcs12()),
                                                     keyPolicy.ToCkmcPolicy(),
                                                     certificatePolicy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to save PKCS12. alias=" + alias);
        }
    }
}
