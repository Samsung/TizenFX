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

namespace Tizen.Account.SyncManager
{
	/// <summary>
	/// Enumeration for the sync option.
	/// </summary>
	/// <since_tizen> 4 </since_tizen>
    [Flags]
    public enum SyncOption
    {
        /// <summary>
        /// The sync job will be operated normally.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        None = 0,

        /// <summary>
        /// The sync job will be operated as soon as possible.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Expedited = 0X01,

        /// <summary>
        /// The sync job will not be performed again when it fails.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        NoRetry = 0X02,
    }

	/// <summary>
	/// Enumeration for the sync period.
	/// </summary>
	/// <since_tizen> 4 </since_tizen>
    public enum SyncPeriod
    {
        /// <summary>
        /// Sync within 30 minutes.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ThirtyMin = 0,

        /// <summary>
        /// Sync within 1 hour.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        OneHour,

        /// <summary>
        /// Sync within 2 hours.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        TwoHours,

        /// <summary>
        /// Sync within 3 hours.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ThreeHours,

        /// <summary>
        /// Sync within 6 hours.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        SixHours,

        /// <summary>
        /// Sync within 12 hours.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        TwelveHours,

        /// <summary>
        /// Sync within 1 day.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        OneDay,
    }
}

