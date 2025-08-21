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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents event arguments of the ObserverNotified event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class ObserverNotifiedEventArgs : EventArgs
    {
        internal ObserverNotifiedEventArgs() { }

        /// <summary>
        /// Result of the observe response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Result of the observe response.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResponseCode Result { get; internal set; }

        /// <summary>
        /// Representation of the resource being observed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Representation of the resource being observed.</value>
        [Obsolete("Deprecated since API level 13")]
        public Representation Representation { get; internal set; }
    }
}
