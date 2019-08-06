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
using Tizen.Network;

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which manages connection information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Connection : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        internal Connection(IntPtr h)
        {
            _handle = h;
        }

        /// <summary>
        /// ConnectionStateChanged event is raised when connection state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ConnectionStateEventArgs> ConnectionStateChanged
        {
            add
            {
                NetworkMonitorImpl.Instance.ConnectionStateChanged += value;
                NetworkMonitorImpl.Instance.RegisterConnectionStateChanged(_handle);
            }
            remove
            {
               NetworkMonitorImpl.Instance.ConnectionStateChanged -= value;
               NetworkMonitorImpl.Instance.UnregisterConnectionStateChanged(_handle);
            }
        }

        /// <summary>
        /// The ID of the connection.
        /// Two different connections can have the same name.
        /// So, you must use 'ID' instead of 'Name' if you want to get the unique identification.
        /// </summary>
        /// <value> The connection ID </value>
        /// <since_tizen> 6 </since_tizen>
        public string ID
        {
            get
            {
                return NetworkMonitorImpl.Instance.ConnectionGetId(_handle);
            }
        }

        /// <summary>
        /// The name of the connection
        /// </summary>
        /// <value> The connection name </value>
        /// <since_tizen> 6 </since_tizen>
        public string Name
        {
            get
            {
                return NetworkMonitorImpl.Instance.ConnectionGetName(_handle);
            }
        }

        /// <summary>
        /// The network type of the connection
        /// </summary>
        /// <value> The network type of the connection </value>
        /// <since_tizen> 6 </since_tizen>
        public ConnectionType Type
        {
            get
            {
                return NetworkMonitorImpl.Instance.ConnectionGetType(_handle);
            }
        }

        /// <summary>
        /// The name of the network interface
        /// </summary>
        /// <value> The interface name of the connection(e.g. eth0 and pdp0) </value>
        /// <since_tizen> 6 </since_tizen>
        public string InterfaceName
        {
            get
            {
                return NetworkMonitorImpl.Instance.ConnectionGetIfaceName(_handle);
            }
        }

        /// <summary>
        /// The proxy type
        /// </summary>
        /// <value> The proxy type </value>
        /// <since_tizen> 6 </since_tizen>
        public ProxyType ProxyType
        {
            get
            {
                return NetworkMonitorImpl.Instance.ConnectionGetProxyType(_handle);
            }
        }

        /// <summary>
        /// Refreshes the connection information
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void Refresh()
        {
            NetworkMonitorImpl.Instance.ConnectionRefresh(_handle);
        }


        /// <summary>
        /// Gets the link for this connection.
        /// </summary>
        /// <returns> The link </returns>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        public Link GetLink()
        {
            return NetworkMonitorImpl.Instance.GetLink(_handle);
        }

        /// <summary>
        /// Clones this connection
        /// </summary>
        /// <returns> The cloned connection </returns>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        public Connection Clone()
        {
            return NetworkMonitorImpl.Instance.ConnectionClone(_handle);
        }

        /// <summary>
        /// Destructor of Connection class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Connection()
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
                NetworkMonitorImpl.Instance.ConnectionDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
