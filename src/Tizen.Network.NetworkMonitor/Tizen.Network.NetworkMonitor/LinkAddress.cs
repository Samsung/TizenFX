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
    /// A class that contains address information such as IP address, prefix length and link scope.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class LinkAddress : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// IP Address.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> IP Address </value>
        public System.Net.IPAddress IP
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkAddressGetIP(_handle);
            }
        }

        /// <summary>
        /// Link scope.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> Link scope </value>
        public LinkScope Scope
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkAddressGetScope(_handle);
            }
        }

        /// <summary>
        /// Address prefix length.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> Address prefix length </value>
        public int PrefixLength
        {
            get
            {
                return NetworkMonitorImpl.Instance.LinkAddressGetPrefixLength(_handle);
            }
        }

        /// <summary>
        /// Clones this address
        /// </summary>
        /// <returns> The cloned address </returns>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        public LinkAddress Clone()
        {
            return NetworkMonitorImpl.Instance.LinkAddressClone(_handle);
        }

        internal LinkAddress(IntPtr h)
        {
            _handle = h;
            Log.Debug(Globals.LogTag, "New LinkAddress. Handle: " + h.GetHashCode());
            // TODO: Need to check family?
        }

        /// <summary>
        /// Destructor of LinkAddress class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~LinkAddress()
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
                NetworkMonitorImpl.Instance.LinkAddressDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
