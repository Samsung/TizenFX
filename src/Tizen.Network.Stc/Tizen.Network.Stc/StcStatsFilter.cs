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
    /// A class for managing the Statistics Filters to match applications.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class StatisticsFilter
    {
        /// <summary>
        /// A property for App Id for statistics filter. AppId can be provided to get statistics for a specific application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Application id.</value>
        public string AppId { get; set; }

        /// <summary>
        /// A property for "from" value of time interval for statistics filter.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>from(start) of time interval.</value>
        public DateTime? From { get; set; }

        /// <summary>
        /// A property for "to" value of time interval for statistics filter.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>to(end) of time interval.</value>
        public DateTime? To { get; set; }

        /// <summary>
        /// A property for Interface type for statistics filter.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Interface type.</value>
        public NetworkInterface? InterfaceType { get; set; }

        /// <summary>
        /// A property for Time period for statistics filter. This is used to granulate the statistics data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Time period.</value>
        public TimePeriodType? TimePeriod { get; set; }

        internal Interop.Stc.SafeFilterHandle ConvertToNativeFilter()
        {
            Interop.Stc.SafeFilterHandle handle;
            Interop.Stc.Filter.Create(StcManagerImpl.Instance.GetSafeHandle(), out handle);

            Interop.Stc.Filter.SetAppId(handle, AppId);
            if (From.HasValue && To.HasValue)
            {
                Interop.Stc.Filter.SetTimeInterval(handle, From.Value, To.Value);
            }
            if (InterfaceType.HasValue)
            {
                Interop.Stc.Filter.SetInterfaceType(handle, InterfaceType.Value);
            }
            if (TimePeriod.HasValue)
            {
                Interop.Stc.Filter.SetTimePeriod(handle, (NativeTimePeriodType)TimePeriod.Value);
            }
            return handle;
        }
    }
}
