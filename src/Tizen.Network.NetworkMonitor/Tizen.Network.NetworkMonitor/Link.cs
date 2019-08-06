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
using System.Collections.Generic;

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which manages network link information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Link : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        internal Link(IntPtr h)
        {
            _handle = h;
            Log.Debug(Globals.LogTag, "New Link. Handle: " + h.GetHashCode());
        }

        /// <summary>
        /// The interface name of the link.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The interface name </value>
        public string InterfaceName
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkGetInterfaceName(_handle);
            }
        }

        /// <summary>
        /// The link flags
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The link flags, values of LinkFlag combied with bitwise 'or' </value>
        public int Flags
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkGetFlags(_handle);
            }
        }

        /// <summary>
        /// The operation state of the link
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The operation state of the link </value>
        public LinkOperationState LinkOperationState
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkGetOperationState(_handle);
            }
        }

        /// <summary>
        /// The bytes received by the link.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> the bytes received by the link </value>
        public ulong ReceivedBytes
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkGetReceivedBytes(_handle);
            }
        }

        /// <summary>
        /// The bytes sent by the link.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The bytes sent by the link </value>
        public ulong SentBytes
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkGetSentBytes(_handle);
            }
        }

        /// <summary>
        /// All address information of the link.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The list of address information of the link </value>
        public IEnumerable<LinkAddress> GetAddresses()
        {
            return NetworkMonitorImpl.Instance.LinkGetAddresses(_handle);
        }

        /// <summary>
        /// All route tables of the link.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The list of route infomration of the link </value>
        public IEnumerable<Route> GetRoutes()
        {
            return NetworkMonitorImpl.Instance.LinkGetRoutes(_handle);
        }

        /// <summary>
        /// Clones this link
        /// </summary>
        /// <returns> The cloned link </returns>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        public Link Clone()
        {
            return NetworkMonitorImpl.Instance.LinkClone(_handle);
        }

        /// <summary>
        /// Destructor of the Link class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Link()
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
                NetworkMonitorImpl.Instance.LinkDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
