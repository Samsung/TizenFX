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
    /// Class extending EventArgs which contains parameters to be passed to event handler of DeviceInformationChanged event
    /// </summary>
    public class AudioDevicePropertyChangedEventArgs : EventArgs
    {
        private AudioDevice _device;
        private AudioDeviceProperty _changedProperty;

        internal AudioDevicePropertyChangedEventArgs(AudioDevice device, AudioDeviceProperty changedInfo)
        {
            _device = device;
            _changedProperty = changedInfo;
        }

        /// <summary>
        /// The object of sound device
        /// </summary>
        public AudioDevice Device
        {
            get
            {
                return _device;
            }
        }

        /// <summary>
        /// The entry of sound device information
        /// </summary>
        public AudioDeviceProperty ChangedInfo
        {
            get
            {
                return _changedProperty;
            }
        }
    }
}
