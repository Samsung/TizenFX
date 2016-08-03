/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

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
