/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Account.OAuth2
{
    /// <summary>
    /// The class contains request parameters for refreshing an access token.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete]
    public class RefreshTokenRequest : TokenRequest
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public RefreshTokenRequest()
        {

        }

        /// <summary>
        /// The grant type to be used
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public override string GrantType { get; } = "refresh_token";

        /// <summary>
        /// The refresh token issued by authorization server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public string RefreshToken { get; set; }
    }
}
