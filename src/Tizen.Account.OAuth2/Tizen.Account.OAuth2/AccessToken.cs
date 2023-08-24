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
    /// Class containing access token and related information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete]
    public class AccessToken
    {
        internal AccessToken()
        {
        }

        /// <summary>
        /// The lifetime in seconds of the access token.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public long ExpiresIn { get; internal set;}

        /// <summary>
        /// The access token issued by the authorization server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public string Token { get; internal set;}

        /// <summary>
        /// The scope of the access token.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public IEnumerable<string> Scope { get; internal set;}

        /// <summary>
        /// The type of the access token.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public string TokenType { get; internal set;}
    }
}
