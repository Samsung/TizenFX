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
    /// Enumeration for the crypto cipher algorithm types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CipherAlgorithmType : int
    {
        /// <summary>
        /// AES-CTR algorithm.
        /// </summary>
        /// <remarks>
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesCtr (mandatory),
        /// - ParameterName.IV = 16 - byte initialization vector (mandatory)
        /// - ParameterName.CounterLength = length of counter block in bits
        ///   (optional, only 128b is supported at the moment).
        /// </remarks>
        AesCtr = 0x01,
        /// <summary>
        /// AES-CBC algorithm.
        /// </summary>
        /// <remarks>
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesCbc (mandatory),
        /// - ParameterName.IV = 16-byte initialization vector (mandatory).
        /// </remarks>
        AesCbc,
        /// <summary>
        /// AES-GCM algorithm.
        /// </summary>
        /// <remarks>
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesGcm (mandatory),
        /// - ParameterName.IV = initialization vector (mandatory)
        /// - ParameterName.TagLength = GCM tag length in bits. One of
        ///   {32, 64, 96, 104, 112, 120, 128} (optional, if not present the length of 128 is used)
        /// - CKMC_PARAM_ED_AAD = additional authentication data (optional).
        /// </remarks>
        AesGcm,
        /// <summary>
        /// AES-CFB algorithm.
        /// </summary>
        /// <remarks>
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesCfb (mandatory),
        /// - ParameterName.IV = 16-byte initialization vector (mandatory).
        /// </remarks>
        AesCfb,
        /// <summary>
        /// RSA-OAEP algorithm.
        /// </summary>
        /// <remarks>
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = RsaOaep (mandatory),
        /// - ParameterName.Label = label to be associated with the message
        ///   (optional, not supported at the moment).
        /// </remarks>
        RsaOaep
    }
}
