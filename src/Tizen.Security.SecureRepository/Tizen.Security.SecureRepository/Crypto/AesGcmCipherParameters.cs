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
    /// A class holding parameters for AES algorithm with GCM mode.
    /// </summary>
    public class AesGcmCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesGcm.</remarks>
        public AesGcmCipherParameters() : base(CipherAlgorithmType.AesGcm)
        {
        }

        /// <summary>
        /// GCM tag length in bits.
        /// </summary>
        /// <remarks>One of {32, 64, 96, 104, 112, 120, 128} (optional, if not present the length 128 is used.</remarks>
        public long TagLength
        {
            get { return GetInteger(CipherParameterName.TagLength); }
            set { Add(CipherParameterName.TagLength, value); }
        }

        /// <summary>
        /// Additional authentication data(optional)
        /// </summary>
        public byte[] AAD
        {
            get { return GetBuffer(CipherParameterName.AAD); }
            set { Add(CipherParameterName.AAD, value); }
        }
    }
}
