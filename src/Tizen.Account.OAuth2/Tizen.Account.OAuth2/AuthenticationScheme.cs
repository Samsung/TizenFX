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
    /// Enumerations for Client authentication scheme, used to sign client id and client secret accordingly.
    /// Default is Basic (http://tools.ietf.org/html/rfc2617#section-2)
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <remarks>Facebook and Google does not support HTTP Basic Authentication, instead they require client credentials to be sent via request body.</remarks>
    [Obsolete]
    public enum AuthenticationScheme
    {
        /// <summary>
        /// HTTP Basic Authentication for client authentication
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Basic = 0,

        /// <summary>
        /// HTTP Basic Authentication for client authentication
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Digest,

        /// <summary>
        /// Client credentials are sent via request body
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RequestBody
    }
}
