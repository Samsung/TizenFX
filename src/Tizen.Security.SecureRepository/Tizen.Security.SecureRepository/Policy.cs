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
    /// Stores policy for key, certificate, and binary data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Policy
    {
        /// <summary>
        /// Initializes an instance of Policy class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Default value for Password is null and default value for Extractable is false.</remarks>
        public Policy()
        {
            Password = null;
            Extractable = true;
        }

        /// <summary>
        /// Initializes an instance of Policy class with password and extractable flag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="password">Used to encrypt data in secure repository.</param>
        /// <param name="extractable">If true, key may be extracted from the secure repository.</param>
        public Policy(String password, bool extractable)
        {
            Password = password;
            Extractable = extractable;
        }

        /// <summary>
        /// Gets and sets password.
        /// </summary>
        /// <value>
        /// Used to encrypt data in secure repository. If it is not null, the data
        /// (or key, or certificate) is stored encrypted with this password inside secure repository.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public String Password
        {
            get; set;
        }

        /// <summary>
        /// Gets and sets Extractable flag.
        /// </summary>
        /// <value>
        /// Extractable flag. If true, key may be extracted from the secure repository.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public bool Extractable
        {
            get; set;
        }

        internal CkmcPolicy ToCkmcPolicy()
        {
            return new Interop.CkmcPolicy(Password, Extractable);
        }
    }
}
