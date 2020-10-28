﻿/*
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
    /// Enumeration for the complication event type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Flags]
    public enum EventTypes
    {
        /// <summary>
        /// The complication event none.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        EventNone = 0x01,
        /// <summary>
        /// The complication event tap.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        EventTap = 0x02,
        /// <summary>
        /// The complication event double tap.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        EventDoubleTap = 0x04
    }
}
