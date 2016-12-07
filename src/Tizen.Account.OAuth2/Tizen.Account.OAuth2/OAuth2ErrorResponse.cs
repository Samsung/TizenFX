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
    /// Exception wrapper for OAuth2 related exception
    /// </summary>
    public class OAuth2Exception : Exception
    {
        internal OAuth2Exception()
        {
        }

        /// <summary>
        /// The error response.
        /// </summary>
        public OAuth2ErrorResponse Error { get; internal set; }
    }

    /// <summary>
    /// Wrapper class contaning OAuth2 related error information
    /// </summary>
    public class OAuth2ErrorResponse
    {
        internal OAuth2ErrorResponse ()
        {

        }

        /// <summary>
        /// The server error code
        /// </summary>
        public int ServerErrorCode { get; internal set; }

        /// <summary>
        /// The platform error cocde
        /// </summary>
        public int PlatformErrorCode { get; internal set; }

        /// <summary>
        /// Error description
        /// </summary>
        public string Error { get; internal set; }

        /// <summary>
        /// URI of the error page.
        /// </summary>
        public string ErrorUri { get; internal set; }
    }
}
