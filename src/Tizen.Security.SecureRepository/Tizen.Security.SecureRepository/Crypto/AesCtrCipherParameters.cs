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
    /// A class for holding parameters for the AES algorithm with the counter mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AesCtrCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCtr.</remarks>
        public AesCtrCipherParameters() : base(CipherAlgorithmType.AesCtr)
        {
        }

        /// <summary>
        /// Length of the counter block in bits.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Optional, only 128b is supported at the moment.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value should be positive.</exception>
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
