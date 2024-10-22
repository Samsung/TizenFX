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
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Provides methods for storing and retrieving Pkcs12 contents.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Pkcs12Manager : Manager
    {
        /// <summary>
        /// Gets Pkcs12 contents from the secure repository.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If password of keyPolicy is provided in SavePkcs12(),
        /// the same password should be provided in as keyPassword argument.
        /// </remarks>
        /// <remarks>
        /// If password of certificatePolicy is provided in SavePkcs12(),
        /// the same password should be provided in as cerificatePassword argument.
        /// </remarks>
        /// <param name="alias">Name of data to retrieve.</param>
        /// <param name="keyPassword">Password used in decrypting a private key value.</param>
        /// <param name="cerificatePassword">
        /// Password used in decrypting a certificate value.
        /// </param>
        /// <returns>Pkcs12 data specified by alias.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="alias"/> argument is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> argument has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when Pkcs12 does not exist with given <paramref name="alias"/>.
        /// Thrown when optional password of key in Pkcs12 does not match.
        /// Thrown when optional password of certificate in Pkcs12 does not match.
        /// </exception>
        static public Pkcs12 Get(
            string alias, string keyPassword, string cerificatePassword)
        {
            if (alias == null)
                throw new ArgumentNullException("alias should not be null");

            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetPkcs12(
                        alias, keyPassword, cerificatePassword, out ptr),
                    "Failed to get PKCS12. alias=" + alias);
                return new Pkcs12(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.Pkcs12Free(ptr);
            }
        }

        /// <summary>
        /// Stores PKCS12's contents inside key manager based on provided policies.
        /// All items from PKCS12 will use the same alias.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="alias">Name of a data to be stored.</param>
        /// <param name="pkcs12">pkcs12 data to be stored.</param>
        /// <param name="keyPolicy">Pkcs' private key storing policy.</param>
        /// <param name="certificatePolicy">Pkcs' certificate storing policy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any provided argument is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="alias"/> or
        /// <paramref name="pkcs12"/> argument has an invalid format.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when pkcs12 with given <paramref name="alias"/> already exists.
        /// </exception>
        static public void Save(
            string alias, Pkcs12 pkcs12, Policy keyPolicy, Policy certificatePolicy)
        {
            if (alias == null || pkcs12 == null || keyPolicy == null ||
                certificatePolicy == null)
                throw new ArgumentNullException("any of argument is null");

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = pkcs12.GetHandle();

                Interop.CheckNThrowException(
                    Interop.CkmcManager.SavePkcs12(
                        alias, ptr, keyPolicy.ToCkmcPolicy(),
                        certificatePolicy.ToCkmcPolicy()),
                    "Failed to save PKCS12. alias=" + alias);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.Pkcs12Free(ptr);
            }
        }

        // to be static class safely
        internal Pkcs12Manager()
        {
        }
    }
}
