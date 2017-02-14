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
    /// A class for manager the network information of the access point(AP). It allows applications to manager network informaiton.
    /// </summary>
    public class WiFiAP : IDisposable
    {
        private IntPtr _apHandle = IntPtr.Zero;
        private WiFiNetwork _network;
        private WiFiSecurity _security;
        private bool disposed = false;

        /// <summary>
        /// The network information of the access point(AP).
        /// </summary>
        public WiFiNetwork NetworkInformation
        {
            get
            {
                return _network;
            }
        }
        /// <summary>
        /// The security information of the access point(AP).
        /// </summary>
        public WiFiSecurity SecurityInformation
        {
            get
            {
                return _security;
            }
        }

        internal WiFiAP(IntPtr handle)
        {
            Log.Debug(Globals.LogTag, "New WiFiAP. Handle: " + handle);
            _apHandle = handle;
            Initialize();
        }
        /// <summary>
        /// Creates a object for the access point.
        /// </summary>
        /// <param name="essid">The ESSID (Extended Service Set Identifier) can be UTF-8 encoded </param>
        public WiFiAP(string essid)
        {
            Log.Debug(Globals.LogTag, "New WiFiAP. Essid: " + essid);
            createHandle(essid, true);
            Initialize();
        }
        /// <summary>
        /// Creates a object for the hidden access point.
        /// </summary>
        /// <param name="essid">The ESSID (Extended Service Set Identifier) can be UTF-8 encoded </param>
        /// <param name="hidden">The value to set hidden AP</param>
        public WiFiAP(string essid, bool hidden)
        {
            createHandle(essid, hidden);
            Initialize();
        }

        ~WiFiAP()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _network.Dispose();
                _security.Dispose();
                Interop.WiFi.AP.Destroy(_apHandle);
                _apHandle = IntPtr.Zero;
            }
            disposed = true;
        }

        private void createHandle(string id, bool hidden)
        {
            int ret = -1;
            if (hidden)
            {
                ret = Interop.WiFi.AP.CreateHiddenAP(WiFiManagerImpl.Instance.GetHandle(), id, out _apHandle);
            }
            else
            {
                ret = Interop.WiFi.AP.Create(WiFiManagerImpl.Instance.GetHandle(), id, out _apHandle);
            }

            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        private void Initialize()
        {
            _network = new WiFiNetwork(_apHandle);
            _security = new WiFiSecurity(_apHandle);
        }

        /// <summary>
        /// Refreshes the access point information.
        /// </summary>
        public void Refresh()
        {
            int ret = Interop.WiFi.AP.Refresh(_apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to refresh ap handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }

        internal IntPtr GetHandle()
        {
            return _apHandle;
        }
    }
}
