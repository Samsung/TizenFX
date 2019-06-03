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
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tizen.Network.Stc
{
    /// <summary>
    /// A class for managing the Stc statistics information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>

    public class NetworkStatistics : IDisposable
    {
        private Interop.Stc.SafeStatsHandle _infoHandle;
        private bool _disposed;

        internal NetworkStatistics(Interop.Stc.SafeStatsHandle handle)
        {
            Log.Debug(Globals.LogTag, "New Statistics Handle: " + handle);
            _infoHandle = handle;
        }

        /// <summary>
        /// Destroy the NetworkStatistics object
        /// </summary>
        ~NetworkStatistics()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed NetworkStatistics objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the NetworkStatistics.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if(disposing)
            {
                _infoHandle.Dispose();
                _infoHandle = null;
            }

            _disposed = true;
        }

        /// <summary>
        /// A property to get the application ID from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Application ID.</value>
        public string AppId
        {
            get
            {
                string appId;
                int ret = Interop.Stc.Info.GetAppId(_infoHandle, out appId);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get AppId from NetworkStatistics, Error - " + (StcError)ret);
                    return string.Empty;
                }
                return appId;
            }
        }

        /// <summary>
        /// A property to get interface name from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface name.</value>
        public string InterfaceName
        {
            get
            {
                string ifaceName;
                int ret = Interop.Stc.Info.GetInterfaceName(_infoHandle, out ifaceName);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get interface name from NetworkStatistics, Error - " + (StcError)ret);
                    return string.Empty;
                }
                return ifaceName;
            }
        }

        /// <summary>
        /// A property to get "from" value(start) of time interval from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>from(start) of time interval.</value>
        public DateTime From
        {
            get
            {
                DateTime from;
                DateTime to;
                int ret = Interop.Stc.Info.GetTimeInterval(_infoHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(from value) from NetworkStatistics, Error - " + (StcError)ret);
                }
                return from;
            }
        }

        /// <summary>
        /// A property to get "to" value(end) of time interval from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>to(end) of time interval.</value>
        public DateTime To
        {
            get
            {
                DateTime from;
                DateTime to;
                int ret = Interop.Stc.Info.GetTimeInterval(_infoHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(to value) from NetworkStatistics, Error - " + (StcError)ret);
                }
                return to;
            }
        }

        /// <summary>
        /// A property to get the interface type from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface type.</value>
        public NetworkInterface InterfaceType
        {
            get
            {
                NetworkInterface ifaceType;
                int ret = Interop.Stc.Info.GetInterfaceType(_infoHandle, out ifaceType);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Interface type from NetworkStatistics, Error - " + (StcError)ret);
                }
                return ifaceType;
            }
        }

        /// <summary>
        /// A property to get incoming counter from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>incoming counter.</value>
        public long IncomingCounter
        {
            get
            {
                long incoming;
                long outgoing;
                int ret = Interop.Stc.Info.GetCounter(_infoHandle, out incoming, out outgoing);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get incoming counter from NetworkStatistics, Error - " + (StcError)ret);
                }
                return incoming;
            }
        }

        /// <summary>
        /// A property to get outgoing counter from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>outgoing counter.</value>
        public long OutgoingCounter
        {
            get
            {
                long incoming;
                long outgoing;
                int ret = Interop.Stc.Info.GetCounter(_infoHandle, out incoming, out outgoing);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get outgoing counter from NetworkStatistics, Error - " + (StcError)ret);
                }
                return outgoing;
            }
        }

        /// <summary>
        /// A property to get the roaming type from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>IsRoaming.</value>
        public bool IsRoaming
        {
            get
            {
                RoamingType roaming;
                int ret = Interop.Stc.Info.GetRoaming(_infoHandle, out roaming);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Roaming type from NetworkStatistics, Error - " + (StcError)ret);
                }

                return roaming == RoamingType.Enabled;
            }
        }

        /// <summary>
        /// A property to get the network protocol type from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Network Protocol type.</value>
        public NetworkProtocol Protocol
        {
            get
            {
                NetworkProtocol protocol;
                int ret = Interop.Stc.Info.GetProtocol(_infoHandle, out protocol);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Protocol type from NetworkStatistics, Error - " + (StcError)ret);
                }
                return protocol;
            }
        }

        /// <summary>
        /// A property to get the application state from NetworkStatistics.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Monitored application state.</value>
        public ApplicationStateType ApplicationState
        {
            get
            {
                ApplicationStateType state;
                int ret = Interop.Stc.Info.GetProcessState(_infoHandle, out state);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ApplicationState from NetworkStatistics, Error - " + (StcError)ret);
                }
                return state;
            }
        }
    }
}
