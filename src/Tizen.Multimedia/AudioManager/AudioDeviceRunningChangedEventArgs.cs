/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Provides the data for the <see cref="AudioManager.DeviceRunningChanged"/> event,
    /// which is triggered when the running state of an audio device changes.
    /// This class encapsulates information about the specific audio device
    /// that has undergone a state change, as well as its current running status,
    /// allowing subscribers to respond appropriately to changes in audio device activity.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class AudioDeviceRunningChangedEventArgs : EventArgs
    {
        internal AudioDeviceRunningChangedEventArgs(AudioDevice device, bool isRunning)
        {
            Device = device;
            IsRunning = isRunning;
        }

        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <value>The <see cref="AudioDevice"/>.</value>
        /// <since_tizen> 5 </since_tizen>
        public AudioDevice Device { get; }

        /// <summary>
        /// Gets the running state of the device.
        /// </summary>
        /// <value>true if the audio stream of device is running actually; otherwise, false.</value>
        /// <since_tizen> 5 </since_tizen>
        public bool IsRunning { get; }
    }
}
