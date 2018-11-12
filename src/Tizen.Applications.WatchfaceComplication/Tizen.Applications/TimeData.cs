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

namespace Tizen.Applications.WatchfaceComplication.Tizen.Applications
{
    /// <summary>
    /// Represents the TimeData class for the Time type complication.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    class TimeData : ComplicationData
    {
        private long _timestamp;
        private string _iconPath;
        private string _extraData;
        private string _screenReaderText;

        /// <summary>
        /// Initializes the ShortTextData class.
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
        ///             return new TimeData(10, "icon path", "extra");
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
            _iconPath = iconPath;
            _extraData = extraData;
        }

        /// <summary>
        /// The information about the timestamp of complication data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public long Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid time(" + value + ")");
                _timestamp = value;
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
            err = Interop.WatchfaceComplication.ProviderSetDataType(sharedData, ComplicationTypes.Time);
            if (err != ComplicationError.None)
                return err;

            err = Interop.WatchfaceComplication.ProviderSetTimestamp(sharedData, _timestamp);
            if (err != ComplicationError.None)
                return err;
            Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
            Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            return ComplicationError.None;
        }
    }
}
