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
    /// Enumeration for the time tick resolution.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum TimeTickResolution
    {
        /// <summary>
        /// 1 ~ 60 ticks per second.
        /// </summary>
        TimeTicksPerSecond,
        /// <summary>
        /// 1 ~ 60 ticks per minute.
        /// </summary>
        TimeTicksPerMinute,
        /// <summary>
        /// 1 ~ 60 ticks per hour.
        /// </summary>
        TimeTicksPerHour
    }
}
