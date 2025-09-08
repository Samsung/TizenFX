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
    /// This class represents event arguments of the DeviceInformationFound event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class DeviceInformationFoundEventArgs
    {
        internal DeviceInformationFoundEventArgs() { }

        /// <summary>
        /// The request ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The request ID.</value>
        [Obsolete("Deprecated since API level 13")]
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates to continuously receive the event for finding device information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Continuously receive the event for finding device information.</value>
        [Obsolete("Deprecated since API level 13")]
        public bool EventContinue { get; set; }

        /// <summary>
        /// Indicates the human friendly name for device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Human friendly name for device.</value>
        [Obsolete("Deprecated since API level 13")]
        public string Name { get; internal set; }

        /// <summary>
        /// Indicates the spec version of the core specification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Spec version of the core specification.</value>
        [Obsolete("Deprecated since API level 13")]
        public string SpecVersion { get; internal set; }

        /// <summary>
        /// Indicates an unique identifier for the OIC device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Unique identifier for OIC device.</value>
        [Obsolete("Deprecated since API level 13")]
        public string DeviceId { get; internal set; }

        /// <summary>
        /// Indicates version of the specs this device data model is implemented to.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Version of the specs this device data model is implemented to.</value>
        [Obsolete("Deprecated since API level 13")]
        public string DataModelVersion { get; internal set; }
    }
}
