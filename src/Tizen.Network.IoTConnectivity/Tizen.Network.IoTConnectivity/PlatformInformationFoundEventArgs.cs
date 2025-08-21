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
    /// This class represents event arguments of the PlatformInformationFound event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class PlatformInformationFoundEventArgs
    {
        internal PlatformInformationFoundEventArgs() { }

        /// <summary>
        /// Indicates the request ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The request ID.</value>
        [Obsolete("Deprecated since API level 13")]
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates to continuously receive the event for finding the platform information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Continuously receive the event for finding the platform information.</value>
        [Obsolete("Deprecated since API level 13")]
        public bool EventContinue { get; set; }

        /// <summary>
        /// Indicates the platform identifier.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The platform identifier.</value>
        [Obsolete("Deprecated since API level 13")]
        public string PlatformId { get; internal set; }

        /// <summary>
        /// Indicates the name of the manufacturer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The name of the manufacturer.</value>
        [Obsolete("Deprecated since API level 13")]
        public string ManufacturerName { get; internal set; }

        /// <summary>
        /// Indicates the URL of the manufacturer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The URL of the manufacturer.</value>
        [Obsolete("Deprecated since API level 13")]
        public string ManufacturerURL { get; internal set; }

        /// <summary>
        /// Indicates the model number as designated by the manufacturer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The model number as designated by the manufacturer.</value>
        [Obsolete("Deprecated since API level 13")]
        public string ModelNumber { get; internal set; }

        /// <summary>
        /// Indicates the manufacturing date of the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The manufacturing date of the device.</value>
        [Obsolete("Deprecated since API level 13")]
        public string DateOfManufacture { get; internal set; }

        /// <summary>
        /// Indicates the version of the platfrom defined by the manufacturer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The version of platfrom defined by manufacturer.</value>
        [Obsolete("Deprecated since API level 13")]
        public string PlatformVersion { get; internal set; }

        /// <summary>
        /// Indicates the version of the platfrom resident OS.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The version of the platfrom resident OS.</value>
        [Obsolete("Deprecated since API level 13")]
        public string OsVersion { get; internal set; }

        /// <summary>
        /// Indicates the version of the platform Hardware.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The version of the platform Hardware.</value>
        [Obsolete("Deprecated since API level 13")]
        public string HardwareVersion { get; internal set; }

        /// <summary>
        /// Indicates the version of the device firmware.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The version of the device firmware.</value>
        [Obsolete("Deprecated since API level 13")]
        public string FirmwareVersion { get; internal set; }

        /// <summary>
        /// Indicates the URL that points to support information from the manufacturer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The URL that points to support information from the manufacturer.</value>
        [Obsolete("Deprecated since API level 13")]
        public string SupportUrl { get; internal set; }

        /// <summary>
        /// Indicates the reference time of the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The reference time of the device.</value>
        [Obsolete("Deprecated since API level 13")]
        public string SystemTime { get; internal set; }
    }
}
