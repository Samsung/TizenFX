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
    /// This class contains the application usage statistics information retrieved by UsageStatistics.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class UsageStatisticsData : AppStatisticsData
    {
        internal UsageStatisticsData(string appId, int duration, int launchCount, DateTime lastLaunchTime)
        {
            AppId = appId;
            Duration = duration;
            LaunchCount = launchCount;
            LastLaunchTime = lastLaunchTime;
        }

        /// <summary>
        /// Gets the time when the application is being displayed in the foreground in seconds.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>Duration when the application is used in the foreground in seconds.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int Duration { get; private set; }

        /// <summary>
        /// Gets how many times the application is used in the foreground.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>How many times the application is used in the foreground.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int LaunchCount { get; private set; }

        /// <summary>
        /// Gets the last time when the application has been used.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The last time when the application has been used.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public DateTime LastLaunchTime { get; private set; }
    }
}
