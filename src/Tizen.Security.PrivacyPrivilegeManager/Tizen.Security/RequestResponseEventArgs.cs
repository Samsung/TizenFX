/*
 * Copyright (c) 2017 - 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security
{
    /// <summary>
    /// This class is an event argument of the RequestResponse event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>

    public class RequestResponseEventArgs : EventArgs
    {
        /// <summary>
        /// The cause of a triggered response.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CallCause cause { get; internal set; }

        /// <summary>
        /// The result of a permission request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public RequestResult result { get; internal set; }

        /// <summary>
        /// The privilege for which a permission was requested for.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string privilege { get; internal set; }

        /// <summary>
        /// The response for privilege request
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PermissionRequestResponse Response
        {
            get
            {
                return new PermissionRequestResponse
                {
                    Result = result,
                    Privilege = privilege,
                };
            }
        }
    }
}
