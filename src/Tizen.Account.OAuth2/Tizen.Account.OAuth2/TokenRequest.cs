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
using System.Collections.Generic;

namespace Tizen.Account.OAuth2
{
    /// <summary>
    /// Abstract wrapper class containing OAuth 2.0 request parameters for requesting an access token.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete]
    public abstract class TokenRequest
    {
        /// <summary>
        /// The Grant type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public abstract string GrantType { get; }

        /// <summary>
        /// The client credentials
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public ClientCredentials ClientSecrets { get; set; }

        /// <summary>
        /// The access token end point URL.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public Uri TokenEndpoint { get; set; }

        /// <summary>
        /// The redirection endpoint of the auhorization flow.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public Uri RedirectionEndPoint { get; set; }

        /// <summary>
        /// The scope of the access request as described by https://tools.ietf.org/html/rfc6749#section-3.3
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public IEnumerable<string> Scopes { get; set; }

        /// <summary>
        /// Custom key-value parameters to be sent to the server
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public IEnumerable<KeyValuePair<string, string>> CustomData { get; set; }

        /// <summary>
        /// Client authentication scheme. Default is Basic
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public AuthenticationScheme AuthenticationScheme { get; set; } = AuthenticationScheme.Basic;

        /// <summary>
        /// The client's state which is maintained between request and response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public string State { get; set; }
    }
}
