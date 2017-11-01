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

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for Ambient tick type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum AmbientTickType
    {
        /// <summary>
        /// No peridoic ambient tick.
        /// </summary>
        NoTick,
        /// <summary>
        /// Every minute.
        /// </summary>
        EveryMinute,
        /// <summary>
        /// Every 5 minutes.
        /// </summary>
        EveryFiveMinutes,
        /// <summary>
        /// Every 15 minutes.
        /// </summary>
        EveryFiftenMinutes,
        /// <summary>
        /// Every 30 minutes.
        /// </summary>
        EveryThirtyMinutes,
        /// <summary>
        /// Every hour.
        /// </summary>
        EveryHour,
        /// <summary>
        /// Every 3 hours.
        /// </summary>
        EveryThreeHours,
        /// <summary>
        /// Every 6 hours.
        /// </summary>
        EverySixHours,
        /// <summary>
        /// Every 12 hours.
        /// </summary>
        EveryTwelveHours,
        /// <summary>
        /// Every day.
        /// </summary>
        EveryDay
    }
}
