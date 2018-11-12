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
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Enumeration for the complication type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Flags]
    public enum ComplicationTypes
    {
        /// <summary>
        /// The complication type NoData do not displays anything.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        NoData = 0x01,
        /// <summary>
        /// The complication type ShortText displays short text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ShortText = 0x02,
        /// <summary>
        /// The complication type LongText displays long text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        LongText = 0x04,
        /// <summary>
        /// The complication type RangedValue displays minimum, maximum, current value.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        RangedValue = 0x08,
        /// <summary>
        /// The complication type Time displays time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Time = 0x10,
        /// <summary>
        /// The complication type Icon displays icon.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Icon = 0x20,
        /// <summary>
        /// The complication type Image displays image.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Image = 0x40
    }
}