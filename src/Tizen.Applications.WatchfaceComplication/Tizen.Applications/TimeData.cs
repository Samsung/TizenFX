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
    /// Represents the time data for a complication.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TimeData : ComplicationData
    {
        /// <summary>
        /// Initializes the TimeData class.
        /// </summary>
        /// <param name="timestamp">The timestamp value.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.Time)
        ///         {
        ///             return new TimeData((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, "icon path", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public TimeData(long timestamp, string iconPath, string extraData)
        {
            if (timestamp < 0)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "Invalid value time(" + timestamp + ")");
            Type = ComplicationTypes.Time;
            Timestamp = timestamp;
            IconPath = iconPath;
            ExtraData = extraData;
        }

        /// <summary>
        /// The information about the timestamp of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new long Timestamp
        {
            get
            {
                return base.Timestamp;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid time(" + value + ")");
                base.Timestamp = value;
            }
        }

        /// <summary>
        /// The icon path data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string IconPath
        {
            get
            {
                return base.IconPath;
            }
            set
            {
                base.IconPath = value;
            }
        }

        /// <summary>
        /// The extra data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ExtraData
        {
            get
            {
                return base.ExtraData;
            }
            set
            {
                base.ExtraData = value;
            }
        }

        /// <summary>
        /// The information about the screen reader text of complication data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ScreenReaderText
        {
            get
            {
                return base.ScreenReaderText;
            }
            set
            {
                base.ScreenReaderText = value;
            }
        }

    }
}