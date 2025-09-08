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
using System.Threading;

namespace Tizen.Network.Nsd
{
    internal class SsdpInitializer
    {
        internal SsdpInitializer()
        {
            Globals.SsdpInitialize();
        }

        ~SsdpInitializer()
        {
            int ret = Interop.Nsd.Ssdp.Deinitialize();
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize Ssdp, Error - " + (SsdpError)ret);
            }
        }
    }

    /// <summary>
    /// This class is used for managing the local service registration and its properties using SSDP.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class SsdpService : INsdService
    {
        private uint _serviceHandle;
        private string _target;
        private Interop.Nsd.Ssdp.ServiceRegisteredCallback _serviceRegisteredCallback;

        /// <summary>
        /// The constructor to create the SsdpService instance that sets the target to a given value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="target">The SSDP local service's target. It may be a device type or a service type.</param>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when SSDP is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the target is set to null.</exception>
        [Obsolete("Deprecated since API level 13")]
        public SsdpService(string target)
        {
            _target = target;
            SsdpInitializeCreateService();
        }

        internal SsdpService(uint service)
        {
            _serviceHandle = service;
        }

        internal void SsdpInitializeCreateService()
        {
            SsdpInitializer ssdpInit = Globals.s_threadSsd.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<SsdpInitializer> instance = " + ssdpInit);
            int ret = Interop.Nsd.Ssdp.CreateService(_target, out _serviceHandle);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create a local Ssdp service handle, Error - " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        /// <summary>
        /// Unique Service Name of the SSDP service.
        /// </summary>
        /// <remarks>
        /// Set the USN for only an unregistered service created locally. If the service is already registered, the USN will not be set.
        /// In case of an error, null will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when SSDP is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when USN value is set to null.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occurred.</exception>
        [Obsolete("Deprecated since API level 13")]
        public string Usn
        {
            get
            {
                string usn;
                int ret = Interop.Nsd.Ssdp.GetUsn(_serviceHandle, out usn);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get usn of service, Error: " + (SsdpError)ret);
                    return null;
                }

                return usn;
            }

            set
            {
                if (!Globals.s_threadSsd.IsValueCreated)
                {
                    SsdpInitializeCreateService();
                }

                int ret = Interop.Nsd.Ssdp.SetUsn(_serviceHandle, value);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set usn of service, Error: " + (SsdpError)ret);
                    NsdErrorFactory.ThrowSsdpException(ret);
                }
            }
        }

        /// <summary>
        /// Target of the SSDP service.
        /// </summary>
        /// <remarks>
        /// It may be a device type or a service type specified in the UPnP forum (http://upnp.org).
        /// In case of an error, null will be returned.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public string Target
        {
            get
            {
                string target;
                int ret = Interop.Nsd.Ssdp.GetTarget(_serviceHandle, out target);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get target of service, Error: " + (SsdpError)ret);
                    return null;
                }

                return target;
            }
        }

        /// <summary>
        /// URL of the SSDP service.
        /// </summary>
        /// <remarks>
        /// Set the URL for only an unregistered service created locally. If the service is already registered, the URL will not be set.
        /// In case of an error, null will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when SSDP is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the URL value is set to null.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occurred.</exception>
        [Obsolete("Deprecated since API level 13")]
        public string Url
        {
            get
            {
                string url;
                int ret = Interop.Nsd.Ssdp.GetUrl(_serviceHandle, out url);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get url of Ssdp service, Error: " + (SsdpError)ret);
                    return null;
                }

                return url;
            }

            set
            {
                if (!Globals.s_threadSsd.IsValueCreated)
                {
                    SsdpInitializeCreateService();
                }

                int ret = Interop.Nsd.Ssdp.SetUrl(_serviceHandle, value);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set url of Ssdp service, Error: " + (SsdpError)ret);
                    NsdErrorFactory.ThrowSsdpException(ret);
                }
            }
        }

        /// <summary>
        /// Registers the SSDP local service for publishing.
        /// </summary>
        /// <remarks>
        /// A service created locally must be passed.
        /// URL and USN of the service must be set before the RegisterService is called.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when the SSDP is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        [Obsolete("Deprecated since API level 13")]
        public void RegisterService()
        {
            if (!Globals.s_threadSsd.IsValueCreated)
            {
                SsdpInitializeCreateService();
            }

            _serviceRegisteredCallback = (SsdpError result, uint service, IntPtr userData) =>
            {
            };

            int ret = Interop.Nsd.Ssdp.RegisterService(_serviceHandle, _serviceRegisteredCallback, IntPtr.Zero);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to register the Ssdp local service, Error: " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        /// <summary>
        /// Deregisters the SSDP local service.
        /// </summary>
        /// <remarks>
        /// A local service registered using RegisterService() must be passed.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when the SSDP is not supported.</exception>
        [Obsolete("Deprecated since API level 13")]
        public void DeregisterService()
        {
            int ret = Interop.Nsd.Ssdp.DeregisterService(_serviceHandle);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deregister the Ssdp local service, Error: " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_serviceHandle != 0)
                    {
                        int ret = Interop.Nsd.Ssdp.DestroyService(_serviceHandle);
                        if (ret != (int)SsdpError.None)
                        {
                            Log.Error(Globals.LogTag, "Failed to destroy the local Ssdp service handle, Error - " + (SsdpError)ret);
                        }
                    }
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Destroys the SsdpService object.
        /// </summary>
        ~SsdpService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the memory allocated to unmanaged resources.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
