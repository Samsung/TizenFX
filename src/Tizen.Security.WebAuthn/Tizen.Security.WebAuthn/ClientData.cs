/*
 *  Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// Client data JSON.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification about how to encode jsonData.
    /// https://www.w3.org/TR/webauthn-3/#collectedclientdata-json-compatible-serialization-of-client-data
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class ClientData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientData"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="jsonData">UTF-8 encoded JSON serialization of the client data.</param>
        /// <param name="hashAlgo">Hash algorithm used to hash the jsonData parameter.</param>
        public ClientData(byte[] jsonData, HashAlgorithm hashAlgo)
        {
            JsonData = jsonData;
            HashAlgo = hashAlgo;
        }

        /// <summary>
        /// Gets the serialized client data json.
        /// </summary>
        /// <value>
        /// A UTF-8 encoded JSON serialization of the client data.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] JsonData { get; init; }
        /// <summary>
        /// Gets the hash algorithm.
        /// </summary>
        /// <value>
        /// The hash algorithm used to hash the JsonData property.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public HashAlgorithm HashAlgo{ get; init; }
    }
}
