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
        private string _shortText;
        private double _currentValue;
        private double _minValue;
        private double _maxValue;
        private string _iconPath;
        private string _title;
        private string _extraData;
        private string _screenReaderText;

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
            _currentValue = currentValue;
            _minValue = minValue;
            _maxValue = maxValue;
            _shortText = shortText;
            _iconPath = iconPath;
            _title = title;
            _extraData = extraData;
        }

        /// <summary>
        /// The information about the current range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double RangeCurrent
        {
            get
            {
                return _currentValue;
            }
            set
            {
                if (value > _maxValue)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), current value can not bigger than max(" + _maxValue + ")");
                if (value < _minValue)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not smaller than min(" + _minValue + ")");
                _currentValue = value;
            }
        }

        /// <summary>
        /// The information about the min range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double RangeMin
        {
            get
            {
                return _minValue;
            }
            set
            {
                if (value > _currentValue)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not bigger than current(" + _currentValue + ")");
                _minValue = value;
            }
        }

        /// <summary>
        /// The information about the max range value of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double RangeMax
        {
            get
            {
                return _maxValue;
            }
            set
            {
                if (value < _currentValue)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                        "invalid min(" + value + "), min value can not smaller than current(" + _currentValue + ")");
                _maxValue = value;
            }
        }

        /// <summary>
        /// The short text data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ShortText
        {
            get
            {
                return _shortText;
            }
            set
            {
                _shortText = value;
            }
        }

        /// <summary>
        /// The icon path data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
            }
        }

        /// <summary>
        /// The title data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// The extra data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ExtraData
        {
            get
            {
                return _extraData;
            }
            set
            {
                _extraData = value;
            }
        }

        /// <summary>
        /// The information about the screen reader text of complication data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ScreenReaderText
        {
            get
            {
                return _screenReaderText;
            }
            set
            {
                _screenReaderText = value;
            }
        }

        internal override ComplicationError UpdateSharedData(IntPtr sharedData)
        {
            Bundle b = new Bundle();
            ComplicationError err = ComplicationError.None;
            err = Interop.WatchfaceComplication.ProviderSetDataType(b.SafeBundleHandle.DangerousGetHandle(), ComplicationTypes.RangedValue);
            if (err != ComplicationError.None)
                return err;

            Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _shortText);
            Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
            Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
            err = Interop.WatchfaceComplication.ProviderSetRangedValue(sharedData, _currentValue, _minValue, _maxValue);
            Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            return ComplicationError.None;
        }
    }
}
