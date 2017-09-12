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
    [Flags]
    public enum SyncOption
    {
        /// <summary>
        /// The sync job will be operated normally.
        /// </summary>
        None = 0,

        /// <summary>
        /// The sync job will be operated as soon as possible.
        /// </summary>
        Expedited = 0X01,

        /// <summary>
        /// The sync job will not be performed again when it fails.
        /// </summary>
        NoRetry = 0X02,
    }

	/// <summary>
	/// Enumeration for the sync period.
	/// </summary>
    public enum SyncPeriod
    {
        /// <summary>
        /// Sync within 30 minutes.
        /// </summary>
        ThirtyMin = 0,

        /// <summary>
        /// Sync within 1 hour.
        /// </summary>
        OneHour,

        /// <summary>
        /// Sync within 2 hours.
        /// </summary>
        TwoHours,

        /// <summary>
        /// Sync within 3 hours.
        /// </summary>
        ThreeHours,

        /// <summary>
        /// Sync within 6 hours.
        /// </summary>
        SixHours,

        /// <summary>
        /// Sync within 12 hours.
        /// </summary>
        TwelveHours,

        /// <summary>
        /// Sync within 1 day.
        /// </summary>
        OneDay,
    }
}

