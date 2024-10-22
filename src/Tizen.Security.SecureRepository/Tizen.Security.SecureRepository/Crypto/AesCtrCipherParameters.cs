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
    /// Holds parameters for the AES algorithm with the counter mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AesCtrCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// Initializes an instance of AesCtrCipherParameters class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCtr.</remarks>
        public AesCtrCipherParameters() : base(CipherAlgorithmType.AesCtr)
        {
        }

        /// <summary>
        /// Gets and sets the length of the counter block in bits.
        /// </summary>
        /// <value>
        /// Length of the counter block in bits. Optional, only 128b is supported at the moment.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is not positive.</exception>
        public long CounterLength
        {
            get
            {
                return GetInteger(CipherParameterName.CounterLength);
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        string.Format("invalid value{0} on CounterLength", value));
                Add(CipherParameterName.CounterLength, value);
            }
        }
    }
}
