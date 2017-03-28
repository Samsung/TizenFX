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

namespace Tizen.System
{
    /// <summary>
    /// EventArgs type for the event IncomingCallRingtoneChanged
    /// </summary>
    public class IncomingCallRingtoneChangedEventArgs : EventArgs
    {
        private readonly string _incomingCallRingtone = null;
        internal IncomingCallRingtoneChangedEventArgs(string val)
        {
            _incomingCallRingtone = val;
        }

        /// <summary>
        /// The file path of the current ringtone
        /// </summary>
        public string Value
        {
            get
            {
                return _incomingCallRingtone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event WallpaperHomeScreenChanged
    /// </summary>
    public class WallpaperHomeScreenChangedEventArgs : EventArgs
    {
        private readonly string _wallpaperHomeScreen = null;
        internal WallpaperHomeScreenChangedEventArgs(string val)
        {
            _wallpaperHomeScreen = val;
        }

        /// <summary>
        /// The file path of the current home screen wallpaper
        /// </summary>
        public string Value
        {
            get
            {
                return _wallpaperHomeScreen;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event WallpaperLockScreenChanged
    /// </summary>
    public class WallpaperLockScreenChangedEventArgs : EventArgs
    {
        private readonly string _wallpaperLockScreen = null;
        internal WallpaperLockScreenChangedEventArgs(string val)
        {
            _wallpaperLockScreen = val;
        }

        /// <summary>
        /// The file path of the current lock screen wallpaper
        /// </summary>
        public string Value
        {
            get
            {
                return _wallpaperLockScreen;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event FontSizeChanged
    /// </summary>
    public class FontSizeChangedEventArgs : EventArgs
    {
        private readonly SystemSettingsFontSize _fontSize;
        internal FontSizeChangedEventArgs(SystemSettingsFontSize val)
        {
            _fontSize = val;
        }

        /// <summary>
        /// The current system font size
        /// </summary>
        public SystemSettingsFontSize Value
        {
            get
            {
                return _fontSize;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event FontTypeChanged
    /// </summary>
    public class FontTypeChangedEventArgs : EventArgs
    {
        private readonly string _fontType = null;
        internal FontTypeChangedEventArgs(string val)
        {
            _fontType = val;
        }

        /// <summary>
        /// The current system font type
        /// </summary>
        public string Value
        {
            get
            {
                return _fontType;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event MotionActivationChanged
    /// </summary>
    public class MotionActivationSettingChangedEventArgs : EventArgs
    {
        private readonly bool _motionActivation;
        internal MotionActivationSettingChangedEventArgs(bool val)
        {
            _motionActivation = val;
        }

        /// <summary>
        /// Indicates whether the motion service is activated
        /// </summary>
        public bool Value
        {
            get
            {
                return _motionActivation;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event EmailAlertRingtoneChanged
    /// </summary>
    public class EmailAlertRingtoneChangedEventArgs : EventArgs
    {
        private readonly string _emailAlertRingtone = null;
        internal EmailAlertRingtoneChangedEventArgs(string val)
        {
            _emailAlertRingtone = val;
        }

        /// <summary>
        /// The file path of the current email alert ringtone
        /// </summary>
        public string Value
        {
            get
            {
                return _emailAlertRingtone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event UsbDebuggingSettingChanged
    /// </summary>
    public class UsbDebuggingSettingChangedEventArgs : EventArgs
    {
        private readonly bool _usbDebuggingEnabled;
        internal UsbDebuggingSettingChangedEventArgs(bool val)
        {
            _usbDebuggingEnabled = val;
        }

        /// <summary>
        /// Indicates whether the USB debugging is enabled
        /// </summary>
        public bool Value
        {
            get
            {
                return _usbDebuggingEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event Data3GNetworkSettingChanged
    /// </summary>
    public class Data3GNetworkSettingChangedEventArgs : EventArgs
    {
        private readonly bool _data3GNetworkEnabled;
        internal Data3GNetworkSettingChangedEventArgs(bool val)
        {
            _data3GNetworkEnabled = val;
        }

        /// <summary>
        /// Indicates whether the 3G data network is enabled
        /// </summary>
        public bool Value
        {
            get
            {
                return _data3GNetworkEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LockscreenAppChanged
    /// </summary>
    public class LockscreenAppChangedEventArgs : EventArgs
    {
        private readonly string _lockscreenApp = null;
        internal LockscreenAppChangedEventArgs(string val)
        {
            _lockscreenApp = val;
        }

        /// <summary>
        /// Indicates lockscreen app pkg name
        /// </summary>
        public string Value
        {
            get
            {
                return _lockscreenApp;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleCountryChanged
    /// </summary>
    public class LocaleCountryChangedEventArgs : EventArgs
    {
        private readonly string _localeCountry = null;
        internal LocaleCountryChangedEventArgs(string val)
        {
            _localeCountry = val;
        }

        /// <summary>
        /// Indicates the current country setting in the \<LANGUAGE\>_\<REGION\> syntax.
        /// The country setting is in the ISO 639-2 format, and the region setting is in the ISO 3166-1 alpha-2 format
        /// </summary>
        public string Value
        {
            get
            {
                return _localeCountry;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleLanguageChanged
    /// </summary>
    public class LocaleLanguageChangedEventArgs : EventArgs
    {
        private readonly string _localeLanguage = null;
        internal LocaleLanguageChangedEventArgs(string val)
        {
            _localeLanguage = val;
        }

        /// <summary>
        /// Indicates the current language setting in the \<LANGUAGE\>_\<REGION\> syntax.
        /// The language setting is in the ISO 639-2 format and the region setting is in the ISO 3166-1 alpha-2 format
        /// </summary>
        public string Value
        {
            get
            {
                return _localeLanguage;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleTimeFormat24HourChanged
    /// </summary>
    public class LocaleTimeFormat24HourSettingChangedEventArgs : EventArgs
    {
        private readonly bool _localeTimeFormat24Hour;
        internal LocaleTimeFormat24HourSettingChangedEventArgs(bool val)
        {
            _localeTimeFormat24Hour = val;
        }

        /// <summary>
        /// Indicates whether the 24-hour clock is used. If the value is false, the 12-hour clock is used.
        /// </summary>
        public bool Value
        {
            get
            {
                return _localeTimeFormat24Hour;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleTimeZoneChanged
    /// </summary>
    public class LocaleTimeZoneChangedEventArgs : EventArgs
    {
        private readonly string _localeTimeZone = null;
        internal LocaleTimeZoneChangedEventArgs(string val)
        {
            _localeTimeZone = val;
        }

        /// <summary>
        /// Indicates the current time zone
        /// </summary>
        public string Value
        {
            get
            {
                return _localeTimeZone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event TimeChanged
    /// </summary>
    public class TimeChangedEventArgs : EventArgs
    {
        internal TimeChangedEventArgs()
        {
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundLockChanged
    /// </summary>
    public class SoundLockSettingChangedEventArgs : EventArgs
    {
        private readonly bool _soundLock;
        internal SoundLockSettingChangedEventArgs(bool val)
        {
            _soundLock = val;
        }

        /// <summary>
        ///  Indicates whether the screen lock sound is enabled on the device. ex) LCD on/off sound
        /// </summary>
        public bool Value
        {
            get
            {
                return _soundLock;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundSilentModeChanged
    /// </summary>
    public class SoundSilentModeSettingChangedEventArgs : EventArgs
    {
        private readonly bool _soundSilentMode;
        internal SoundSilentModeSettingChangedEventArgs(bool val)
        {
            _soundSilentMode = val;
        }

        /// <summary>
        /// Indicates whether the device is in the silent mode.
        /// </summary>
        public bool Value
        {
            get
            {
                return _soundSilentMode;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundTouchChanged
    /// </summary>
    public class SoundTouchSettingChangedEventArgs : EventArgs
    {
        private readonly bool _soundTouch;
        internal SoundTouchSettingChangedEventArgs(bool val)
        {
            _soundTouch = val;
        }

        /// <summary>
        /// Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        public bool Value
        {
            get
            {
                return _soundTouch;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event DisplayScreenRotationAutoChanged
    /// </summary>
    public class DisplayScreenRotationAutoSettingChangedEventArgs : EventArgs
    {
        private readonly bool _displayScreenRotationAuto;
        internal DisplayScreenRotationAutoSettingChangedEventArgs(bool val)
        {
            _displayScreenRotationAuto = val;
        }

        /// <summary>
        /// Indicates whether rotation control is automatic
        /// </summary>
        public bool Value
        {
            get
            {
                return _displayScreenRotationAuto;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event DeviceNameChanged
    /// </summary>
    public class DeviceNameChangedEventArgs : EventArgs
    {
        private readonly string _deviceName = null;
        internal DeviceNameChangedEventArgs(string val)
        {
            _deviceName = val;
        }

        /// <summary>
        /// Indicates device name
        /// </summary>
        public string Value
        {
            get
            {
                return _deviceName;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event MotionSettingChanged
    /// </summary>
    public class MotionSettingChangedEventArgs : EventArgs
    {
        private readonly bool _motionEnabled;
        internal MotionSettingChangedEventArgs(bool val)
        {
            _motionEnabled = val;
        }

        /// <summary>
        /// Indicates whether the device user has enabled motion feature
        /// </summary>
        public bool Value
        {
            get
            {
                return _motionEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event NetworkWifiNotificationChanged
    /// </summary>
    public class NetworkWifiNotificationSettingChangedEventArgs : EventArgs
    {
        private readonly bool _networkWifiNotification;
        internal NetworkWifiNotificationSettingChangedEventArgs(bool val)
        {
            _networkWifiNotification = val;
        }

        /// <summary>
        /// Indicates whether Wi-Fi-related notifications are enabled on the device
        /// </summary>
        public bool Value
        {
            get
            {
                return _networkWifiNotification;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event NetworkFlightModeChanged
    /// </summary>
    public class NetworkFlightModeSettingChangedEventArgs : EventArgs
    {
        private readonly bool _networkFlightMode;
        internal NetworkFlightModeSettingChangedEventArgs(bool val)
        {
            _networkFlightMode = val;
        }

        /// <summary>
        /// Indicates whether the device is in the flight mode
        /// </summary>
        public bool Value
        {
            get
            {
                return _networkFlightMode;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event ScreenBacklightTimeChanged
    /// </summary>
    public class ScreenBacklightTimeChangedEventArgs : EventArgs
    {
        private readonly int _screenBacklightTime;
        internal ScreenBacklightTimeChangedEventArgs(int val)
        {
            _screenBacklightTime = val;
        }

        /// <summary>
        /// Indicates the backlight time (in seconds)
        /// </summary>
        public int Value
        {
            get
            {
                return _screenBacklightTime;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundNotificationChanged
    /// </summary>
    public class SoundNotificationChangedEventArgs : EventArgs
    {
        private readonly string _soundNotification = null;
        internal SoundNotificationChangedEventArgs(string val)
        {
            _soundNotification = val;
        }

        /// <summary>
        /// Indicates the file path of the current notification tone set by the user
        /// </summary>
        public string Value
        {
            get
            {
                return _soundNotification;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundNotificationRepetitionPeriodChanged
    /// </summary>
    public class SoundNotificationRepetitionPeriodChangedEventArgs : EventArgs
    {
        private readonly int _soundNotificationRepetitionPeriod;
        internal SoundNotificationRepetitionPeriodChangedEventArgs(int val)
        {
            _soundNotificationRepetitionPeriod = val;
        }

        /// <summary>
        /// Indicates the time period for notification repetitions
        /// </summary>
        public int Value
        {
            get
            {
                return _soundNotificationRepetitionPeriod;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LockStateChanged
    /// </summary>
    public class LockStateChangedEventArgs : EventArgs
    {
        private readonly SystemSettingsIdleLockState _lockState;
        internal LockStateChangedEventArgs(SystemSettingsIdleLockState val)
        {
            _lockState = val;
        }

        /// <summary>
        /// Indicates the current lock state
        /// </summary>
        public SystemSettingsIdleLockState Value
        {
            get
            {
                return _lockState;
            }
        }
    }
}
