/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// A class for managing the Stc Info (statistics information).
    /// </summary>
    /// <since_tizen> 6 </since_tizen>

    public class StcInfo : IDisposable
    {
        private IntPtr _infoHandle = IntPtr.Zero;
        private bool _disposed = false;

        internal StcInfo(IntPtr handle)
        {
            Log.Debug(Globals.LogTag, "New Info. Handle: " + handle);
            _infoHandle = handle;
        }

        ~StcInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed StcInfo objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _infoHandle = IntPtr.Zero;
            }
            _disposed = true;
        }

        /// <summary>
        /// A property to get the application ID from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Application ID.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string AppId
        {
            get
            {
                string appId;
                int ret = Interop.Stc.Info.GetAppId(_infoHandle, out appId);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get AppId from Info, Error - " + (StcError)ret);
                    return "";
                }
                return appId;
            }
        }

        /// <summary>
        /// A property to get interface name from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface name.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string InterfaceName
        {
            get
            {
                string ifaceName;
                int ret = Interop.Stc.Info.GetInterfaceName(_infoHandle, out ifaceName);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get interface name from info, Error - " + (StcError)ret);
                    return "";
                }
                return ifaceName;
            }
        }

        /// <summary>
        /// A property to get "from" value(start) of time interval from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>from(start) of time interval.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public DateTime From
        {
            get
            {
                DateTime from;
                DateTime to;
                int ret = Interop.Stc.Info.GetTimeInterval(_infoHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(from value) from info, Error - " + (StcError)ret);
                }
                return from;
            }
        }

        /// <summary>
        /// A property to get "to" value(end) of time interval from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>to(end) of time interval.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public DateTime To
        {
            get
            {
                DateTime from;
                DateTime to;
                int ret = Interop.Stc.Info.GetTimeInterval(_infoHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(to value) from info, Error - " + (StcError)ret);
                }
                return to;
            }
        }

        /// <summary>
        /// A property to get the interface type from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcInterfaceType InterfaceType
        {
            get
            {
                StcInterfaceType iface;
                int ret = Interop.Stc.Info.GetInterfaceType(_infoHandle, out iface);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Interface type from info, Error - " + (StcError)ret);
                }
                return iface;
            }
        }

        /// <summary>
        /// A property to get incoming counter from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>incoming counter.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public long IncomingCounter
        {
            get
            {
                long incoming;
                long outgoing;
                int ret = Interop.Stc.Info.GetCounter(_infoHandle, out incoming, out outgoing);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get incoming counter from info, Error - " + (StcError)ret);
                }
                return incoming;
            }
        }

        /// <summary>
        /// A property to get outgoing counter from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>outgoing counter.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public long OutgoingCounter
        {
            get
            {
                long incoming;
                long outgoing;
                int ret = Interop.Stc.Info.GetCounter(_infoHandle, out incoming, out outgoing);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get outgoing counter from info, Error - " + (StcError)ret);
                }
                return outgoing;
            }
        }

        /// <summary>
        /// A property to get the roaming type from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Roaming type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcRoamingType Roaming
        {
            get
            {
                StcRoamingType roaming;
                int ret = Interop.Stc.Info.GetRoaming(_infoHandle, out roaming);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Roaming type from info, Error - " + (StcError)ret);
                }
                return roaming;
            }
        }

        /// <summary>
        /// A property to get the protocol type from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Protocol type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcProtocolType Protocol
        {
            get
            {
                StcProtocolType protocol;
                int ret = Interop.Stc.Info.GetProtocol(_infoHandle, out protocol);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Protocol type from info, Error - " + (StcError)ret);
                }
                return protocol;
            }
        }

        /// <summary>
        /// A property to get the process state from statistics information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Process state.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcProcessState State
        {
            get
            {
                StcProcessState state;
                int ret = Interop.Stc.Info.GetProcessState(_infoHandle, out state);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Process state from info, Error - " + (StcError)ret);
                }
                return state;
            }
        }
    }
}
