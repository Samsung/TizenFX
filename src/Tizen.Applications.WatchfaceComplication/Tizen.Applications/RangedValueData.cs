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
    /// Represents the RangedValueData class for the RangedValue type complication.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    class RangedValueData : ComplicationData
    {
        /// <summary>
        /// Initializes the ShortTextData class.
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <param name="shortText">The short text.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="title">The title.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.RangedValue)
        ///         {
        ///             return new RangedValueData(50, 0, 100, "short", "icon path", "title", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public RangedValueData(double currentValue, double minValue, double maxValue, string shortText, string iconPath, string title, string extraData)
        {
            if (minValue > maxValue || currentValue < minValue || currentValue > maxValue)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "Invalid value range min(" + minValue + "), cur(" + currentValue + "), max(" + maxValue + ")");
            Type = ComplicationTypes.RangedValue;
            RangeCurrent = currentValue;
            RangeMin = minValue;
            RangeMax = maxValue;
            ShortText = shortText;
            IconPath = iconPath;
            Title = title;
            ExtraData = extraData;
        }

        /// <summary>
        /// The information about the current range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new double RangeCurrent
        {
            get
            {
                return base.RangeCurrent;
            }
            set
            {
                if (value > base.RangeMax)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), current value can not bigger than max(" + base.RangeMax + ")");
                if (value < base.RangeMin)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not smaller than min(" + base.RangeMin + ")");
                base.RangeCurrent = value;
            }
        }

        /// <summary>
        /// The information about the min range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new double RangeMin
        {
            get
            {
                return base.RangeMin;
            }
            set
            {
                if (value > base.RangeCurrent)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not bigger than current(" + base.RangeCurrent + ")");
                base.RangeMin = value;
            }
        }

        /// <summary>
        /// The information about the max range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new double RangeMax
        {
            get
            {
                return base.RangeMax;
            }
            set
            {
                if (value < base.RangeCurrent)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not smaller than current(" + base.RangeCurrent + ")");
                base.RangeMax = value;
            }
        }

        /// <summary>
        /// The short text data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new string ShortText
        {
            get
            {
                return base.ShortText;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "fail to create short text");
                base.ShortText = value;
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
        /// The title data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string Title
        {
            get
            {
                return base.Title;
            }
            set
            {
                base.Title = value;
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
