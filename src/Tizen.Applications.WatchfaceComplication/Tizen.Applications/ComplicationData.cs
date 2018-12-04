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
    /// Represents the Complication data class.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ComplicationData
    {
        private long _timestamp;
        private string _imagePath;
        private double _currentValue;
        private double _minValue;
        private double _maxValue;
        private string _iconPath;
        private string _longText;
        private string _shortText;
        private string _extraData;
        private string _screenReaderText;
        private string _title;
        private ComplicationTypes _type;
        private const string LogTag = "WatchfaceComplication";

        internal string ShortText
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

        internal string LongText
        {
            get
            {
                return _longText;
            }
            set
            {
                _longText = value;
            }
        }

        internal string IconPath
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

        internal string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        internal string Title
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

        internal string ExtraData
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

        internal string ScreenReaderText
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

        internal long Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
            }
        }

        internal double RangeCurrent
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
            }
        }

        internal double RangeMin
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }

        internal double RangeMax
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        internal ComplicationTypes Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private bool IsDataValid(IntPtr sharedData)
        {
            bool isValid = false;
            ComplicationError err = Interop.WatchfaceComplication.ProviderSharedDataIsValid(sharedData, out isValid);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check shared data validation");
            return isValid;
        }

        internal ComplicationError UpdateSharedData(IntPtr sharedData)
        {
            ComplicationError err = ComplicationError.None;
            switch (_type)
            {
                case ComplicationTypes.ShortText:
                    err = Interop.WatchfaceComplication.ProviderSetShortText(sharedData, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationTypes.LongText:
                    err = Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _longText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationTypes.RangedValue:
                    Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    err = Interop.WatchfaceComplication.ProviderSetRangedValue(sharedData, _currentValue, _minValue, _maxValue);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationTypes.Time:
                    err = Interop.WatchfaceComplication.ProviderSetTimestamp(sharedData, _timestamp);
                    Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationTypes.Icon:
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationTypes.Image:
                    err = Interop.WatchfaceComplication.ProviderSetImagePath(sharedData, _imagePath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
            }
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            try
            {
                if (!IsDataValid(sharedData))
                    return ComplicationError.IO;
            }
            catch (Exception ex)
            {
                Log.Error(LogTag, "valid check fail : " + ex);
                return ComplicationError.IO;
            }

            return err;
        }
    }
}