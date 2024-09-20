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
    /// Holds parameters for the AES algorithm with the CBC mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AesCbcCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// Initializes an instance of AesCbcCipherParameters class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCbc.</remarks>
        public AesCbcCipherParameters() : base(CipherAlgorithmType.AesCbc)
        {
        }
    }
}
