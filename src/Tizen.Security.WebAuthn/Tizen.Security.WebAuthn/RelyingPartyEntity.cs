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
    /// Relying Party entity.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialrpentity
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class RelyingPartyEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelyingPartyEntity"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="name">The name of the Relying Party.</param>
        /// <param name="id">The ID of the Relying Party.</param>
        public RelyingPartyEntity(string name, string id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Gets the name of the Relying Party.
        /// </summary>
        /// <value>
        /// The name of the Relying Party.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public string Name { get; init; }
        /// <summary>
        /// Gets the ID of the Relying Party.
        /// </summary>
        /// <value>
        /// The ID of the Relying Party.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public string Id { get; init; }
    }
}
