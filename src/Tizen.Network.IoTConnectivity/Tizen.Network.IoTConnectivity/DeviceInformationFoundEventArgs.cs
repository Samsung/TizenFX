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
    /// This class is an event arguments of the DeviceInformationFound event.
    /// </summary>
    public class DeviceInformationFoundEventArgs
    {
        internal DeviceInformationFoundEventArgs() { }

        /// <summary>
        /// The request id
        /// </summary>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates human friendly name for device
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Indicates spec version of the core specification
        /// </summary>
        public string SpecVersion { get; internal set; }

        /// <summary>
        /// Indicates unique identifier for OIC device
        /// </summary>
        public string DeviceId { get; internal set; }

        /// <summary>
        /// Indicates version of the specs this device data model is implemented to
        /// </summary>
        public string DataModelVersion { get; internal set; }
    }
}
