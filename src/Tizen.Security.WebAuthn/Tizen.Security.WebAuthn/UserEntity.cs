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
    /// User entity.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialuserentity
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class UserEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelyingPartyEntity"/> class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        /// <param name="name">A human-palatable name for the entity.</param>
        /// <param name="id">
        /// The ID of the user account. An ID is a byte sequence with a maximum size of 64 bytes,
        /// and is not meant to be displayed to the user.
        /// </param>
        /// <param name="displayName">A human-palatable name for the user account, intended only for display.</param>
        public UserEntity(string name, byte[] id, string displayName)
        {
            Name = name;
            Id = id;
            DisplayName = displayName;
        }

        /// <summary>
        /// Gets the name of the user entity.
        /// </summary>
        /// <value>
        /// A human-palatable name for the entity.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public string Name { get; init; }
        /// <summary>
        /// Gets the user ID.
        /// </summary>
        /// <value>
        /// The ID of the user account.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public byte[] Id { get; init; }
        /// <summary>
        /// Gets the dispay name of the user entity.
        /// </summary>
        /// <value>
        /// A human-palatable name for the user account, intended only for display.
        /// </value>
        /// <since_tizen> 12 </since_tizen>
        public string DisplayName { get; init; }
    }
}
