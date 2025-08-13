/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Context.AppHistory
{
    /// <summary>
    /// This class contains the battery statistics information retrieved by BatteryStatistics.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class BatteryStatisticsData : AppStatisticsData
    {
        internal BatteryStatisticsData(string appId, double consumption)
        {
            AppId = appId;
            Consumption = consumption;
        }

        /// <summary>
        /// Gets how much percentage of battery capacity was used by the application.
        /// </summary>
        /// <value>Battery consumption used by the application.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public double Consumption { get; private set; }
    }
}
