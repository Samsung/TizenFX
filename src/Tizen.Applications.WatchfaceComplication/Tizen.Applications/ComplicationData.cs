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
        private Bundle _compData = new Bundle();
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
                Interop.WatchfaceComplication.ProviderSetIconPath(_compData.SafeBundleHandle.DangerousGetHandle(), _shortText);
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
                Interop.WatchfaceComplication.ProviderSetLongText(_compData.SafeBundleHandle.DangerousGetHandle(), _longText);
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
                Interop.WatchfaceComplication.ProviderSetIconPath(_compData.SafeBundleHandle.DangerousGetHandle(), _iconPath);
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
                Interop.WatchfaceComplication.ProviderSetImagePath(_compData.SafeBundleHandle.DangerousGetHandle(), _imagePath);
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
                Interop.WatchfaceComplication.ProviderSetTitle(_compData.SafeBundleHandle.DangerousGetHandle(), _title);
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
                Interop.WatchfaceComplication.ProviderSetExtraData(_compData.SafeBundleHandle.DangerousGetHandle(), _extraData);
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
                Interop.WatchfaceComplication.ProviderSetScreenReaderText(_compData.SafeBundleHandle.DangerousGetHandle(), _screenReaderText);
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
                Interop.WatchfaceComplication.ProviderSetTimestamp(_compData.SafeBundleHandle.DangerousGetHandle(), _timestamp);
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
                Interop.WatchfaceComplication.ProviderSetRangedValue(_compData.SafeBundleHandle.DangerousGetHandle(), _currentValue, _minValue, _maxValue);
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
                Interop.WatchfaceComplication.ProviderSetRangedValue(_compData.SafeBundleHandle.DangerousGetHandle(), _currentValue, _minValue, _maxValue);
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
                Interop.WatchfaceComplication.ProviderSetRangedValue(_compData.SafeBundleHandle.DangerousGetHandle(), _currentValue, _minValue, _maxValue);
            }
        }

        private bool IsDataValid()
        {
            bool isValid = false;
            ComplicationError err = Interop.WatchfaceComplication.ProviderSharedDataIsValid(_compData.SafeBundleHandle.DangerousGetHandle(), out isValid);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check shared data validation");
            return isValid;
        }

        internal ComplicationError UpdateSharedData(IntPtr sharedData)
        {
            try
            {
                if (!IsDataValid())
                    return ComplicationError.IO;
            }
            catch (Exception ex)
            {
                Log.Error(LogTag, "valid check fail : " + ex.ToString());
                return ComplicationError.IO;
            }


            Bundle shared = new Bundle(new SafeBundleHandle(sharedData, false));
            foreach (string key in _compData.Keys)
            {
                shared.AddItem(key, _compData.GetItem(key)?.ToString());
            }

            return ComplicationError.None;
        }
    }
}