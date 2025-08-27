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

namespace Tizen.Network.Nsd
{
    /// <summary>
    /// An extended EventArgs class, which contains the changed service state during a service discovery using DNS-SD.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class DnssdServiceFoundEventArgs : EventArgs
    {
        private DnssdServiceState _state;
        private DnssdService _service;

        internal DnssdServiceFoundEventArgs(DnssdServiceState state, DnssdService service)
        {
            _state = state;
            _service = service;
        }

        /// <summary>
        /// The DNS-SD service state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public DnssdServiceState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The DNS-SD service instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public DnssdService Service
        {
            get
            {
                return _service;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class, which contains the changed service state during a service discovery using SSDP.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class SsdpServiceFoundEventArgs : EventArgs
    {
        private SsdpServiceState _state;
        private SsdpService _service;

        internal SsdpServiceFoundEventArgs(SsdpServiceState state, SsdpService service)
        {
            _state = state;
            _service = service;
        }

        /// <summary>
        /// The SSDP service state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public SsdpServiceState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The SSDP service instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public SsdpService Service
        {
            get
            {
                return _service;
            }
        }
    }
}
