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
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tizen.Network.Stc
{
    /// <summary>
    /// A class for managing the Stc Info (statistics information).
    /// </summary>
    /// <since_tizen> tizen_5.5 </since_tizen>

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
        /// <since_tizen> tizen_5.5 </since_tizen>
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
        /// <since_tizen> tizen_5.5 </since_tizen>
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
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <value>Interface name.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string IfaceName
        {
            get
            {
                string ifaceName;
                int ret = Interop.Stc.Info.GetIfaceName(_infoHandle, out ifaceName);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get interface name from info, Error - " + (StcError)ret);
                    return "";
                }
                return ifaceName;
            }
        }

        /// <summary>
        /// Get the time interval from statistics information.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="from">The beginning of the time interval.</param>
        /// <param name="to">The end of the time interval.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void GetTimeInterval(out long from, out long to)
        {
            int ret = Interop.Stc.Info.GetTimeInterval(_infoHandle, out from, out to);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get time interval from info, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// A property to get the interface type from statistics information.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <value>Interface type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcIfaceType Iface
        {
            get
            {
                StcIfaceType iface;
                int ret = Interop.Stc.Info.GetIface(_infoHandle, out iface);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Interface type from info, Error - " + (StcError)ret);
                }
                return iface;
            }
        }

        /// <summary>
        /// Get the counters from statistics information.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="incoming">The incoming counter.</param>
        /// <param name="outgoing">The outgoing counter.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void GetCounter(out long incoming, out long outgoing)
        {
            int ret = Interop.Stc.Info.GetCounter(_infoHandle, out incoming, out outgoing);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get  counters from info, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// A property to get the roaming type from statistics information.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
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
        /// <since_tizen> tizen_5.5 </since_tizen>
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
        /// <since_tizen> tizen_5.5 </since_tizen>
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
