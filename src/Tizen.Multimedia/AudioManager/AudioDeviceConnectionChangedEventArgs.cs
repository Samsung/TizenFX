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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="AudioManager.DeviceConnectionChanged"/> event.
    /// This event is triggered when there is a change in the connection status of an audio device,
    /// such as when a device is connected or disconnected from the system.
    /// The <see cref="AudioDeviceConnectionChangedEventArgs"/> class encapsulates information
    /// about the device involved in the connection change and its current connection state,
    /// allowing developers to easily respond to changes in the audio subsystem and update
    /// application behavior accordingly.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioDeviceConnectionChangedEventArgs : EventArgs
    {
        internal AudioDeviceConnectionChangedEventArgs(AudioDevice device, bool isConnected)
        {
            Device = device;
            IsConnected = isConnected;
        }

        /// <summary>
        /// Gets the device that is involved in the connection change.
        /// This property returns an instance of <see cref="AudioDevice"/>, which represents
        /// the specific audio device that has been connected or disconnected.
        /// This information is essential for applications that need to manage multiple audio devices,
        /// allowing them to identify the affected device and adjust their functionality accordingly.
        /// </summary>
        /// <value>The <see cref="AudioDevice"/>.</value>
        /// <since_tizen> 3 </since_tizen>
        public AudioDevice Device { get; }

        /// <summary>
        /// Gets the current connection state of the device.
        /// This property indicates whether the audio device is currently connected to the system.
        /// It will return <c>true</c> if the device is connected and <c>false</c> if it has
        /// been disconnected. This information is crucial for determining the audio routing and
        /// playback options, enabling applications to appropriately react to the presence
        /// or absence of audio devices in the environment.
        /// </summary>
        /// <value>true if the device is connected; otherwise, false.</value>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected { get; }
    }
}
