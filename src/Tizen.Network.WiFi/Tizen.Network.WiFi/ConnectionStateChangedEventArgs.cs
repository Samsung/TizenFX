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
    /// An extended EventArgs class which contains changed connection state.
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        private WiFiConnectionState _state = WiFiConnectionState.Disconnected;
        private WiFiAP _ap;

        internal ConnectionStateChangedEventArgs(WiFiConnectionState s, IntPtr apHandle)
        {
            _state = s;
            _ap = new WiFiAP(apHandle);
        }

        /// <summary>
        /// The wifi connection state.
        /// </summary>
        public WiFiConnectionState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The access point
        /// </summary>
        public WiFiAP AP
        {
            get
            {
                return _ap;
            }
        }
    }
}
