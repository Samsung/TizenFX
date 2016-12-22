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

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// An extended EventArgs class which contains changed device state.
    /// </summary>
    public class DeviceStateChangedEventArgs : EventArgs
    {
        private WiFiDeviceState _state = WiFiDeviceState.Deactivated;

        internal DeviceStateChangedEventArgs(WiFiDeviceState s)
        {
            _state = s;
        }

        /// <summary>
        /// The wifi device state.
        /// </summary>
        public WiFiDeviceState State
        {
            get
            {
                return _state;
            }
        }
    }
}
