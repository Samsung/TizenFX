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
    /// This class is used for managing local service registration and its properties using SSDP.
    /// </summary>
    public class SsdpService : INsdService
    {
        private uint _serviceHandle;
        private string _target;
        private Interop.Nsd.Ssdp.ServiceRegisteredCallback _serviceRegisteredCallback;

        /// <summary>
        /// Constructor to create SsdpService instance that sets the target to a given value.
        /// </summary>
        /// <param name="target">The SSDP local service's target. It may be a device type or a service type.</param>
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
        /// Unique Service Name of SSDP service.
        /// </summary>
        /// <remarks>
        /// Set Name for only unregistered service created locally. If service is already registered, Name will not be set.
        /// In case of error, null will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown while setting this property when SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occured.</exception>
        public string Name
        {
            get
            {
                string name;
                int ret = Interop.Nsd.Ssdp.GetUsn(_serviceHandle, out name);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name of service, Error: " + (SsdpError)ret);
                    return null;
                }

                return name;
            }

            set
            {
                if (Globals.s_threadSsd.IsValueCreated)
                {
                    SsdpInitializeCreateService();
                }

                int ret = Interop.Nsd.Ssdp.SetUsn(_serviceHandle, value.ToString());
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set name of service, Error: " + (SsdpError)ret);
                    NsdErrorFactory.ThrowSsdpException(ret);
                }
            }
        }

        /// <summary>
        /// Type of SSDP service.
        /// </summary>
        /// <remarks>
        /// In case of error, null will be returned.
        /// </remarks>
        public string Type
        {
            get
            {
                string type;
                int ret = Interop.Nsd.Ssdp.GetTarget(_serviceHandle, out type);
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get type of service, Error: " + (SsdpError)ret);
                    return null;
                }

                return type;
            }
        }

        /// <summary>
        /// URL of SSDP service.
        /// </summary>
        /// <remarks>
        /// Set Url for only unregistered service created locally. If service is already registered, Url will not be set.
        /// In case of error, null will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown while setting this property when SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occured.</exception>
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
                if (Globals.s_threadSsd.IsValueCreated)
                {
                    SsdpInitializeCreateService();
                }

                int ret = Interop.Nsd.Ssdp.SetUrl(_serviceHandle, value.ToString());
                if (ret != (int)SsdpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set url of Ssdp service, Error: " + (SsdpError)ret);
                    NsdErrorFactory.ThrowSsdpException(ret);
                }
            }
        }

        internal void RegisterService()
        {
            if (Globals.s_threadSsd.IsValueCreated)
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

        internal void DeregisterService()
        {
            int ret = Interop.Nsd.Ssdp.DeregisterService(_serviceHandle);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deregister the Ssdp local service, Error: " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        ~SsdpService()
        {
            int ret = Interop.Nsd.Ssdp.DestroyService(_serviceHandle);
            if (ret != (int)SsdpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy the local Ssdp service handle, Error - " + (SsdpError)ret);
            }
        }
    }
}
