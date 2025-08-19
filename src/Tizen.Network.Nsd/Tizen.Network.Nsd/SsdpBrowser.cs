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
    /// This class is used for managing the network service discovery using SSDP.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class SsdpBrowser : INsdBrowser
    {
        private string _target;
        private uint _browserHandle;
        private event EventHandler<SsdpServiceFoundEventArgs> _serviceFound;
        private Interop.Nsd.Ssdp.ServiceFoundCallback _serviceFoundCallback;

        /// <summary>
        /// This event is raised when the service has become available or unavailable during a service discovery using SSDP.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
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
        /// A public constructor for the SsdpBrowser class to create a SsdpBrowser instance for the given target.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="target">The target to browse for the service.</param>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="ArgumentException">Thrown when the target is null.</exception>
        /// <exception cref="NotSupportedException">Thrown when SSDP is not supported.</exception>
        [Obsolete("Deprecated since API level 13")]
        public SsdpBrowser(string target)
        {
            SsdpInitializer ssdpInit = Globals.s_threadSsd.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<SsdpInitializer> instance = " + ssdpInit);
            if (target == null)
            {
                Log.Debug(Globals.LogTag, "target is null");
                NsdErrorFactory.ThrowSsdpException((int)SsdpError.InvalidParameter);
            }

            _target = target;
        }

        /// <summary>
        /// Starts browsing the SSDP remote service.
        /// </summary>
        /// <remarks>
        /// If there are any services available, the ServiceFound event will be invoked.
        /// The application will keep browsing for the available or unavailable services until it calls StopDiscovery().
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        /// <exception cref="NotSupportedException">Thrown when SSDP is not supported.</exception>
        [Obsolete("Deprecated since API level 13")]
        public void StartDiscovery()
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

        /// <summary>
        /// Stops browsing the SSDP remote service.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        /// <exception cref="NotSupportedException">Thrown when SSDP is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        [Obsolete("Deprecated since API level 13")]
        public void StopDiscovery()
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
