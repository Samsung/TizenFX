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
    /// A class for managing the Stc Rules to match applications.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class StcRule : IDisposable
    {
        internal IntPtr _ruleHandle = IntPtr.Zero;
        internal bool _disposed;

        /// <summary>
        /// Creates a StcRule object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public StcRule()
        {
            Log.Debug(Globals.LogTag, "New StcRule.");
            int ret = Interop.Stc.Rule.Create(StcManagerImpl.Instance.GetSafeHandle(), out _ruleHandle);
            if(ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create Rule handle, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// Destroy the StcRule object
        /// </summary>
        ~StcRule()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed StcRule objects.
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
            {
                return;
            }

            int ret = Interop.Stc.Rule.Destroy(_ruleHandle);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy Rule handle, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }

            _ruleHandle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// A property for Application ID for statistics rule.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>AppId.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string AppId
        {
            get
            {
                string appId;
                int ret = Interop.Stc.Rule.GetAppId(_ruleHandle, out appId);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get AppId, Error - " + (StcError)ret);
                    return string.Empty;
                }
                return appId;
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
                }
                int ret = Interop.Stc.Rule.SetAppId(_ruleHandle, value);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set AppId, Error - " + (StcError)ret);
                    StcErrorFactory.ThrowStcException(ret);
                }
            }
        }

        /// <summary>
        /// Set the time interval for statistics rule.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="from">The beginning of the time interval.</param>
        /// <param name="to">The end of the time interval.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetTimeInterval(DateTime from, DateTime to)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
            }
            int ret = Interop.Stc.Rule.SetTimeInterval(_ruleHandle, from, to);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set time interval, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// A property to get "from" value(start) of time interval for statistics rule.
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
                int ret = Interop.Stc.Rule.GetTimeInterval(_ruleHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(from value) for rule, Error - " + (StcError)ret);
                }
                return from;
            }
        }

        /// <summary>
        /// A property to get "to" value(end) of time interval for statistics rule.
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
                int ret = Interop.Stc.Rule.GetTimeInterval(_ruleHandle, out from, out to);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time interval(to value) for rule, Error - " + (StcError)ret);
                }
                return to;
            }
        }

        /// <summary>
        /// A property for Interface type for statistics rule.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public NetworkInterface InterfaceType
        {
            get
            {
                NativeNetworkInterface ifaceType;
                int ret = Interop.Stc.Rule.GetInterfaceType(_ruleHandle, out ifaceType);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Interface type, Error - " + (StcError)ret);
                }
                if (ifaceType == NativeNetworkInterface.Unknown)
                {
                    throw new InvalidOperationException("Interface Type is Unknown.");
                }
                else
                {
                    return (NetworkInterface)ifaceType;
                }
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
                }
                int ret = Interop.Stc.Rule.SetInterfaceType(_ruleHandle, (NativeNetworkInterface)value);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set Interface type, Error - " + (StcError)ret);
                    StcErrorFactory.ThrowStcException(ret);
                }
            }
        }

        /// <summary>
        /// A property for Time period for statistics rule.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Time period.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public TimePeriodType TimePeriod
        {
            get
            {
                NativeTimePeriodType timePeriod;
                int ret = Interop.Stc.Rule.GetTimePeriod(_ruleHandle, out timePeriod);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Time period, Error - " + (StcError)ret);
                }
                if (timePeriod == NativeTimePeriodType.Unknown)
                {
                    throw new InvalidOperationException("Time period is Unknown.");
                }
                else
                {
                    return (TimePeriodType)timePeriod;
                }
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
                }
                int ret = Interop.Stc.Rule.SetTimePeriod(_ruleHandle, (NativeTimePeriodType)value);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set Time period, Error - " + (StcError)ret);
                    StcErrorFactory.ThrowStcException(ret);
                }
            }
        }
    }
}
