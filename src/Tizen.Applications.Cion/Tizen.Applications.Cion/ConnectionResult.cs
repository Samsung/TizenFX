/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.Cion
{
    /// <summary>
    /// A class to represent result of connection.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ConnectionResult
    {
        private readonly string _reason;
        private readonly ConnectionStatus _status;

        internal ConnectionResult(IntPtr handle)
        {
            Interop.CionConnectionResult.CionConnectionResultGetReason(handle, out _reason);
            Interop.CionConnectionResult.CionConnectionResultGetStatus(handle, out _status);
        }

        /// <summary>
        /// Gets the connection status.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ConnectionStatus Status
        {
            get
            {
                return _status;
            }
        }

        /// <summary>
        /// Gets the reason of the connection result.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Reason
        {
            get
            {
                return _reason;
            }
        }
    }
}
