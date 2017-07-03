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
    /// A class holding parameters for AES algorithm with GCM mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AesGcmCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesGcm.</remarks>
        public AesGcmCipherParameters() : base(CipherAlgorithmType.AesGcm)
        {
        }

        /// <summary>
        /// GCM tag length in bits.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>One of {32, 64, 96, 104, 112, 120, 128} (optional, if not present the length 128 is used.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">TagLength should be one of {32, 64, 96, 104, 112, 120, 128}</exception>
        public long TagLength
        {
            get
            {
                return GetInteger(CipherParameterName.TagLength);
            }
            set
            {
                if (value != 32 && value != 64 && value != 96 && value != 104 &&
                    value != 112 && value != 120 && value != 128)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("invalid value{0} on TagLength", value));
                }
                else
                {
                    Add(CipherParameterName.TagLength, value);
                }
            }
        }

        /// <summary>
        /// Additional authentication data(optional)
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] AAD
        {
            get { return GetBuffer(CipherParameterName.AAD); }
            set { Add(CipherParameterName.AAD, value); }
        }
    }
}
