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
    /// Enumeration for the cipher algorithm parameters.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CipherParameterName : int
    {
        /// <summary>
        /// Algorithm Type.
        /// </summary>
        AlgorithmType = 0x01,
        /// <summary>
        /// Initial Vector.
        /// </summary>
        /// <remarks>
        /// 16B buffer (up to 2^64-1 bytes long in case of AES GCM).
        /// </remarks>
        IV = 101,
        /// <summary>
        /// Integer - ctr length in bits.
        /// </summary>
        CounterLength = 102,
        /// <summary>
        /// Additional authenticated data(AAD).
        /// </summary>
        AAD = 103,
        /// <summary>
        /// Tag Length.
        /// </summary>
        TagLength = 104,
        /// <summary>
        /// Label.
        /// </summary>
        Label = 105
    }

}
