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
    /// Class extending EventArgs which contains parameters to be passed to event handler of DeviceConnected event
    /// </summary>
    public class AudioDeviceConnectionChangedEventArgs : EventArgs
    {
        internal AudioDeviceConnectionChangedEventArgs(AudioDevice device, bool isConnected)
        {
            Device = device;
            IsConnected = isConnected;
        }

        /// <summary>
        /// The object of sound device
        /// </summary>
        public AudioDevice Device { get; }

        /// <summary>
        /// The state of device connection: (true = connected, false = disconnected)
        /// </summary>
        public bool IsConnected { get; }
    }
}
