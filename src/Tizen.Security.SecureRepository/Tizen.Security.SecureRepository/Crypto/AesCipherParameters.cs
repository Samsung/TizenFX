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

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Holds parameters for the AES algorithm.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class AesCipherParameters : CipherParameters
    {
        /// <summary>
        /// Gets and sets initialization vector.
        /// </summary>
        /// <value>
        /// Initialization vector for AES cipher.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public byte[] IV
        {
            get { return this.GetBuffer(CipherParameterName.IV); }
            set { this.Add(CipherParameterName.IV, value); }
        }

        // for inherited in internal only
        internal AesCipherParameters()
        {
        }

        internal AesCipherParameters(CipherAlgorithmType algorithm) : base(algorithm)
        {
        }
    }
}
