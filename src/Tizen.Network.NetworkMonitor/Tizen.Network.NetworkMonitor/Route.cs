/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which manages route information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Route : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        internal Route(IntPtr h)
        {
            _handle = h;
        }

        /// <summary>
        /// The destination address of the route.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The destination address of the route </value>
        public string Destination
        {
            get
            {
                return NetworkMonitorImpl.Instance.RouteGetDestination(_handle);
            }
        }

        /// <summary>
        /// The Gateway address of the route.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The IP address of the gateway </value>
        public System.Net.IPAddress Gateway
        {
            get
            {
                return NetworkMonitorImpl.Instance.RouteGetGateway(_handle);
            }
        }

        /// <summary>
        /// The interface name of the route.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The interface name of the route </value>
        public string InterfaceName
        {
            get
            {
                return NetworkMonitorImpl.Instance.RouteGetInterfaceName(_handle);
            }
        }

        /// <summary>
        /// A property to check whether the route is default or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> True if the route is default, otherwise false </value>
        public bool IsDefault
        {
            get
            {
                return NetworkMonitorImpl.Instance.RouteIsDefault(_handle);
            }
        }

        /// <summary>
        /// The route type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The route type </value>
        public RouteType Type
        {
            get
            {
                return NetworkMonitorImpl.Instance.RouteGetType(_handle);
            }
        }

        /// <summary>
        /// Clones this route
        /// </summary>
        /// <returns> The cloned route </returns>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        public Route Clone()
        {
            return NetworkMonitorImpl.Instance.RouteClone(_handle);
        }

        /// <summary>
        /// Destructor of the Route class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Route()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the allocated memory.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (_handle != IntPtr.Zero)
            {
                NetworkMonitorImpl.Instance.RouteDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
