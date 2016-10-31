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
    /// This class is an event arguments of the PresenceReceived event.
    /// </summary>
    public class PresenceReceivedEventArgs : EventArgs
    {
        internal PresenceReceivedEventArgs() { }

        /// <summary>
        /// Indicates request id of presence event.
        /// </summary>
        public int PresenceId { get; internal set; }

        /// <summary>
        /// Indicates event type
        /// </summary>
        public PresenceEventType EventType { get; internal set; }

        /// <summary>
        /// Indicates host address of resource
        /// </summary>
        public string HostAddress { get; internal set; }

        /// <summary>
        /// Indicates type of the resource
        /// </summary>
        public string Type { get; internal set; }
    }
}
