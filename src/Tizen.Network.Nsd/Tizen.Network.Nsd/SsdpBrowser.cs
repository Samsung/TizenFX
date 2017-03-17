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
    /// This class is used for managing network service discovery using SSDP.
    /// </summary>
    public class SsdpBrowser : INsdBrowser
    {
        private string _target;
        private uint _browserHandle;
        private event EventHandler<SsdpServiceFoundEventArgs> _serviceFound;
        private Interop.Nsd.Ssdp.ServiceFoundCallback _serviceFoundCallback;

        /// <summary>
        /// This event is raised when service has become available or unavailable during service discovery using SSDP.
        /// </summary>
        public event EventHandler<SsdpServiceFoundEventArgs> ServiceFound
        {
            add
            {
                _serviceFound += value;
            }

            remove
            {
                _serviceFound -= value;
            }
        }

        /// <summary>
        /// A public constructor for SsdpBrowser class to create a SsdpBrowser instance for the given target.
        /// </summary>
        /// <param name="target">The target to browse for the service.</param>
        public SsdpBrowser(string target)
        {
            SsdpInitializer ssdpInit = Globals.s_threadSsd.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<SsdpInitializer> instance = " + ssdpInit);

            _target = target;
        }

        internal void StartDiscovery()
        {
            SsdpInitializer ssdpInit = Globals.s_threadSsd.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<SsdpInitializer> instance = " + ssdpInit);

            _serviceFoundCallback = (SsdpServiceState state, uint service, IntPtr userData) =>
            {
                if (_serviceFound != null)
                {
                    Log.Info(Globals.LogTag, "Inside Service found callback");
                    SsdpService ssdpService = new SsdpService(service);
                    _serviceFound(null, new SsdpServiceFoundEventArgs(state, ssdpService));
                }
            };

            int ret = Interop.Nsd.Ssdp.StartBrowsing(_target, out _browserHandle, _serviceFoundCallback, IntPtr.Zero);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to discover Ssdp remote service, Error - " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        internal void StopDiscovery()
        {
            int ret = Interop.Nsd.Ssdp.StopBrowsing(_browserHandle);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to stop discovery of Ssdp remote service, Error - " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }
    }
}
