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
    /// A class for managing the callback delegate of statistics information.
    /// </summary>
    /// <since_tizen> tizen_5.5 </since_tizen>
    public static class StatsInfoObjectCb
    {
        public delegate StcCallbackRet InfoCallback(StcInfo info, IntPtr userData);
    }

    /// <summary>
    /// A class for managing the Stc Rules to match applications.
    /// </summary>
    /// <since_tizen> tizen_5.5 </since_tizen>
    public class StcRule : IDisposable
    {
        private IntPtr _ruleHandle = IntPtr.Zero;
        private bool _disposed = false;
        private StatsInfoObjectCb.InfoCallback _getStatsObjectCb;
        private StatsInfoObjectCb.InfoCallback _foreachStatsObjectCb;
        private StatsInfoObjectCb.InfoCallback _getTotalStatsObjectCb;
        private Interop.Stc.StatsInfoCallback _getStatsCb;
        private Interop.Stc.StatsInfoCallback _foreachStatsCb;
        private Interop.Stc.StatsInfoCallback _getTotalStatsCb;

        /// <summary>
        /// Creates a StcRule object.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
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

        ~StcRule()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed StcRule objects.
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
                Interop.Stc.Rule.Destroy(_ruleHandle);
                _ruleHandle = IntPtr.Zero;
            }
            _disposed = true;
        }

        /// <summary>
        /// A property for Application ID for statistics rule.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
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
                    return "";
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
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="from">The beginning of the time interval.</param>
        /// <param name="to">The end of the time interval.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetTimeInterval(long from, long to)
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
        /// Get the time interval for statistics rule.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="from">The beginning of the time interval.</param>
        /// <param name="to">The end of the time interval.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void GetTimeInterval(out long from, out long to)
        {
            int ret = Interop.Stc.Rule.GetTimeInterval(_ruleHandle, out from, out to);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get time interval, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// A property for Interface type for statistics rule.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <value>Interface type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcIfaceType IfaceType
        {
            get
            {
                StcIfaceType ifaceType;
                int ret = Interop.Stc.Rule.GetIfaceType(_ruleHandle, out ifaceType);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Interface type, Error - " + (StcError)ret);
                }
                return ifaceType;
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
                }
                int ret = Interop.Stc.Rule.SetIfaceType(_ruleHandle, value);
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
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <value>Time period.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Stc is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public StcTimePeriod TimePeriod 
        {
            get
            {
                StcTimePeriod timePeriod ;
                int ret = Interop.Stc.Rule.GetTimePeriod(_ruleHandle, out timePeriod);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Time period, Error - " + (StcError)ret);
                }
                return timePeriod;
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
                }
                int ret = Interop.Stc.Rule.SetTimePeriod(_ruleHandle, value);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set Time period, Error - " + (StcError)ret);
                    StcErrorFactory.ThrowStcException(ret);
                }
            }
        }

        /// <summary>
        /// Gets the statistics information an application matched rule asynchronously.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="infoCb">The callback is called for each application that used network in between timestamps specified.</param>
        /// <param name="userData">The user data passed to the callback function.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void GetStats(StatsInfoObjectCb.InfoCallback infoCb, IntPtr userData)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
            }

            _getStatsObjectCb = infoCb;

            _getStatsCb = (int result, IntPtr info, IntPtr userDataBack) =>
            {
                if(result != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "GetStats failed, Error - " + (StcError)result);
                    StcErrorFactory.ThrowStcException(result);
                }
                return _getStatsObjectCb(new StcInfo(info), userDataBack);
            };

            int ret = Interop.Stc.Rule.GetStats(StcManagerImpl.Instance.GetSafeHandle(), _ruleHandle, _getStatsCb, userData);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "GetStats() failed , Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// Gets the statistics information of each application asynchronously. The callback is called for each application that used network in between timestamps specified.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="infoCb">The callback is called for each application that used network in between timestamps specified.</param>
        /// <param name="userData">The user data passed to the callback function.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void ForeachStats(StatsInfoObjectCb.InfoCallback infoCb, IntPtr userData)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
            }

            _foreachStatsObjectCb = infoCb;

            _foreachStatsCb = (int result, IntPtr info, IntPtr userDataBack) =>
            {
                if(result != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "ForeachStats failed, Error - " + (StcError)result);
                    StcErrorFactory.ThrowStcException(result);
                }
                return _foreachStatsObjectCb(new StcInfo(info), userDataBack);
            };

            int ret = Interop.Stc.Rule.ForeachStats(StcManagerImpl.Instance.GetSafeHandle(), _ruleHandle, _foreachStatsCb, userData);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "ForeachStats() failed , Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }

        /// <summary>
        /// Gets the total statistics information by interface type asynchronously.
        /// </summary>
        /// <since_tizen> tizen_5.5 </since_tizen>
        /// <param name="infoCb">The callback is called for each application that used network in between timestamps specified.</param>
        /// <param name="userData">The user data passed to the callback function.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Stc is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void GetTotalStats(StatsInfoObjectCb.InfoCallback infoCb, IntPtr userData)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid StcRule instance (Object may have been disposed or released)");
            }

            _getTotalStatsObjectCb = infoCb;

            _getTotalStatsCb = (int result, IntPtr info, IntPtr userDataBack) =>
            {
                if(result != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "GetTotalStats failed, Error - " + (StcError)result);
                    StcErrorFactory.ThrowStcException(result);
                }
                return _getTotalStatsObjectCb(new StcInfo(info), userDataBack);
            };

            int ret = Interop.Stc.Rule.GetTotalStats(StcManagerImpl.Instance.GetSafeHandle(), _ruleHandle, _getTotalStatsCb, userData);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "GetTotalStats() failed , Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
        }
    }
}
