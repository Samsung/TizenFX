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


namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents event arguments of the PlatformInformationFound event.
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public class PlatformInformationFoundEventArgs
    {
        internal PlatformInformationFoundEventArgs() { }

        /// <summary>
        /// Indicates the request id
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>The request id.</value>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates to continuously receive the event for finding platform information.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Continuously receive the event for finding platform information.</value>
        public bool EventContinue { get; set; }

        /// <summary>
        /// Indicates the platform identifier
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>The platform identifier.</value>
        public string PlatformId { get; internal set; }

        /// <summary>
        /// Indicates the name of manufacturer
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>The name of manufacturer.</value>
        public string ManufacturerName { get; internal set; }

        /// <summary>
        /// Indicates URL of the manufacturer
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>URL of the manufacturer.</value>
        public string ManufacturerURL { get; internal set; }

        /// <summary>
        /// Indicates model number as designated by manufacturer
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Model number as designated by manufacturer.</value>
        public string ModelNumber { get; internal set; }

        /// <summary>
        /// Indicates manufacturing date of the device
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Manufacturing date of the device.</value>
        public string DateOfManufacture { get; internal set; }

        /// <summary>
        /// Indicates version of platfrom defined by manufacturer
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Version of platfrom defined by manufacturer.</value>
        public string PlatformVersion { get; internal set; }

        /// <summary>
        /// Indicates version of platfrom resident OS
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Version of platfrom resident OS.</value>
        public string OsVersion { get; internal set; }

        /// <summary>
        /// Indicates version of platform Hardware
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Version of platform Hardware.</value>
        public string HardwareVersion { get; internal set; }

        /// <summary>
        /// Indicates version of device firmware
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Version of device firmware.</value>
        public string FirmwareVersion { get; internal set; }

        /// <summary>
        /// Indicates URL that points to support information from manufacturer
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>URL that points to support information from manufacturer.</value>
        public string SupportUrl { get; internal set; }

        /// <summary>
        /// Indicates reference time of the device
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Reference time of the device.</value>
        public string SystemTime { get; internal set; }
    }
}
