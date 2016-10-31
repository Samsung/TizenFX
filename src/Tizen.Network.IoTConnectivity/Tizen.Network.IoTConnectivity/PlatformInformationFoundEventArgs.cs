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
    /// This class is an event arguments of the PlatformInformationFound event.
    /// </summary>
    public class PlatformInformationFoundEventArgs
    {
        internal PlatformInformationFoundEventArgs() { }

        /// <summary>
        /// Indicates the request id
        /// </summary>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates the platform identifier
        /// </summary>
        public string PlatformId { get; internal set; }

        /// <summary>
        /// Indicates the name of manufacturer
        /// </summary>
        public string ManufacturerName { get; internal set; }

        /// <summary>
        /// Indicates URL of the manufacturer
        /// </summary>
        public string ManufacturerURL { get; internal set; }

        /// <summary>
        /// Indicates model number as designated by manufacturer
        /// </summary>
        public string ModelNumber { get; internal set; }

        /// <summary>
        /// Indicates manufacturing date of the device
        /// </summary>
        public string DateOfManufacture { get; internal set; }

        /// <summary>
        /// Indicates version of platfrom defined by manufacturer
        /// </summary>
        public string PlatformVersion { get; internal set; }

        /// <summary>
        /// Indicates version of platfrom resident OS
        /// </summary>
        public string OsVersion { get; internal set; }

        /// <summary>
        /// Indicates version of platform Hardware
        /// </summary>
        public string HardwareVersion { get; internal set; }

        /// <summary>
        /// Indicates version of device firmware
        /// </summary>
        public string FirmwareVersion { get; internal set; }

        /// <summary>
        /// Indicates URL that points to support information from manufacturer
        /// </summary>
        public string SupportUrl { get; internal set; }

        /// <summary>
        /// Indicates reference time of the device
        /// </summary>
        public string SystemTime { get; internal set; }
    }
}
