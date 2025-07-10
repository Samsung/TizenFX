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
    /// EventArgs type for the IncomingCallRingtoneChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.incoming_call</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class IncomingCallRingtoneChangedEventArgs : EventArgs
    {
        private readonly string _incomingCallRingtone = null;
        internal IncomingCallRingtoneChangedEventArgs(string val)
        {
            _incomingCallRingtone = val;
        }

        /// <summary>
        /// The file path of the current ringtone.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _incomingCallRingtone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the WallpaperHomeScreenChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.home_screen</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class WallpaperHomeScreenChangedEventArgs : EventArgs
    {
        private readonly string _wallpaperHomeScreen = null;
        internal WallpaperHomeScreenChangedEventArgs(string val)
        {
            _wallpaperHomeScreen = val;
        }

        /// <summary>
        /// The file path of the current home screen wallpaper.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _wallpaperHomeScreen;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the WallpaperLockScreenChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.lock_screen</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class WallpaperLockScreenChangedEventArgs : EventArgs
    {
        private readonly string _wallpaperLockScreen = null;
        internal WallpaperLockScreenChangedEventArgs(string val)
        {
            _wallpaperLockScreen = val;
        }

        /// <summary>
        /// The file path of the current lock screen wallpaper.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _wallpaperLockScreen;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the FontSizeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.font</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class FontSizeChangedEventArgs : EventArgs
    {
        private readonly SystemSettingsFontSize _fontSize;
        internal FontSizeChangedEventArgs(SystemSettingsFontSize val)
        {
            _fontSize = val;
        }

        /// <summary>
        /// The current system font size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SystemSettingsFontSize Value
        {
            get
            {
                return _fontSize;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the FontTypeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.font</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class FontTypeChangedEventArgs : EventArgs
    {
        private readonly string _fontType = null;
        internal FontTypeChangedEventArgs(string val)
        {
            _fontType = val;
        }

        /// <summary>
        /// The current system font type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _fontType;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the MotionActivationChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class MotionActivationSettingChangedEventArgs : EventArgs
    {
        private readonly bool _motionActivation;
        internal MotionActivationSettingChangedEventArgs(bool val)
        {
            _motionActivation = val;
        }

        /// <summary>
        /// Indicates whether the motion service is activated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _motionActivation;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the EmailAlertRingtoneChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.notification_email</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class EmailAlertRingtoneChangedEventArgs : EventArgs
    {
        private readonly string _emailAlertRingtone = null;
        internal EmailAlertRingtoneChangedEventArgs(string val)
        {
            _emailAlertRingtone = val;
        }

        /// <summary>
        /// The file path of the current email alert ringtone.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _emailAlertRingtone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the UsbDebuggingSettingChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class UsbDebuggingSettingChangedEventArgs : EventArgs
    {
        private readonly bool _usbDebuggingEnabled;
        internal UsbDebuggingSettingChangedEventArgs(bool val)
        {
            _usbDebuggingEnabled = val;
        }

        /// <summary>
        /// Indicates whether the USB debugging is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _usbDebuggingEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the Data3GNetworkSettingChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class Data3GNetworkSettingChangedEventArgs : EventArgs
    {
        private readonly bool _data3GNetworkEnabled;
        internal Data3GNetworkSettingChangedEventArgs(bool val)
        {
            _data3GNetworkEnabled = val;
        }

        /// <summary>
        /// Indicates whether the 3G data network is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _data3GNetworkEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LockScreenAppChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.lock_screen</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 4 </since_tizen>
    public class LockScreenAppChangedEventArgs : EventArgs
    {
        private readonly string _lockscreenApp = null;
        internal LockScreenAppChangedEventArgs(string val)
        {
            _lockscreenApp = val;
        }

        /// <summary>
        /// Indicates the lock screen application package name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Value
        {
            get
            {
                return _lockscreenApp;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LocaleCountryChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class LocaleCountryChangedEventArgs : EventArgs
    {
        private readonly string _localeCountry = null;
        internal LocaleCountryChangedEventArgs(string val)
        {
            _localeCountry = val;
        }

        /// <summary>
        /// Indicates the current country setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The country setting is in the ISO 639-2 format, and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _localeCountry;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LocaleLanguageChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class LocaleLanguageChangedEventArgs : EventArgs
    {
        private readonly string _localeLanguage = null;
        internal LocaleLanguageChangedEventArgs(string val)
        {
            _localeLanguage = val;
        }

        /// <summary>
        /// Indicates the current language setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The language setting is in the ISO 639-2 format and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _localeLanguage;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LocaleTimeFormat24HourChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _localeTimeFormat24Hour;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LocaleTimeZoneChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class LocaleTimeZoneChangedEventArgs : EventArgs
    {
        private readonly string _localeTimeZone = null;
        internal LocaleTimeZoneChangedEventArgs(string val)
        {
            _localeTimeZone = val;
        }

        /// <summary>
        /// Indicates the current time zone.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _localeTimeZone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the TimeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class TimeChangedEventArgs : EventArgs
    {
        private readonly int _time;
        internal TimeChangedEventArgs(int val)
        {
            _time = val;
        }

        /// <summary>
        /// Indicates the current time.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Value
        {
            get
            {
                return _time;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the SoundLockChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class SoundLockSettingChangedEventArgs : EventArgs
    {
        private readonly bool _soundLock;
        internal SoundLockSettingChangedEventArgs(bool val)
        {
            _soundLock = val;
        }

        /// <summary>
        /// Indicates whether the screen lock sound is enabled on the device, for example, the LCD on or off sound.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _soundLock;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the SoundSilentModeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _soundSilentMode;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the SoundTouchChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _soundTouch;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the DisplayScreenRotationAutoChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class DisplayScreenRotationAutoSettingChangedEventArgs : EventArgs
    {
        private readonly bool _displayScreenRotationAuto;
        internal DisplayScreenRotationAutoSettingChangedEventArgs(bool val)
        {
            _displayScreenRotationAuto = val;
        }

        /// <summary>
        /// Indicates whether the rotation control is automatic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _displayScreenRotationAuto;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the DeviceNameChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class DeviceNameChangedEventArgs : EventArgs
    {
        private readonly string _deviceName = null;
        internal DeviceNameChangedEventArgs(string val)
        {
            _deviceName = val;
        }

        /// <summary>
        /// Indicates the device name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _deviceName;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the MotionSettingChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class MotionSettingChangedEventArgs : EventArgs
    {
        private readonly bool _motionEnabled;
        internal MotionSettingChangedEventArgs(bool val)
        {
            _motionEnabled = val;
        }

        /// <summary>
        /// Indicates whether the device user has enabled the motion feature.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _motionEnabled;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the NetworkWifiNotificationChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/network.wifi</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class NetworkWifiNotificationSettingChangedEventArgs : EventArgs
    {
        private readonly bool _networkWifiNotification;
        internal NetworkWifiNotificationSettingChangedEventArgs(bool val)
        {
            _networkWifiNotification = val;
        }

        /// <summary>
        /// Indicates whether Wi-Fi-related notifications are enabled on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _networkWifiNotification;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the NetworkFlightModeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class NetworkFlightModeSettingChangedEventArgs : EventArgs
    {
        private readonly bool _networkFlightMode;
        internal NetworkFlightModeSettingChangedEventArgs(bool val)
        {
            _networkFlightMode = val;
        }

        /// <summary>
        /// Indicates whether the device is in the flight mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value
        {
            get
            {
                return _networkFlightMode;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the ScreenBacklightTimeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class ScreenBacklightTimeChangedEventArgs : EventArgs
    {
        private readonly int _screenBacklightTime;
        internal ScreenBacklightTimeChangedEventArgs(int val)
        {
            _screenBacklightTime = val;
        }

        /// <summary>
        /// Indicates the backlight time (in seconds).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Value
        {
            get
            {
                return _screenBacklightTime;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the SoundNotificationChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.incoming_call</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class SoundNotificationChangedEventArgs : EventArgs
    {
        private readonly string _soundNotification = null;
        internal SoundNotificationChangedEventArgs(string val)
        {
            _soundNotification = val;
        }

        /// <summary>
        /// Indicates the file path of the current notification tone set by the user.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _soundNotification;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the SoundNotificationRepetitionPeriodChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class SoundNotificationRepetitionPeriodChangedEventArgs : EventArgs
    {
        private readonly int _soundNotificationRepetitionPeriod;
        internal SoundNotificationRepetitionPeriodChangedEventArgs(int val)
        {
            _soundNotificationRepetitionPeriod = val;
        }

        /// <summary>
        /// Indicates the time period for notification repetitions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Value
        {
            get
            {
                return _soundNotificationRepetitionPeriod;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the LockStateChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsetting.incoming_call</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class LockStateChangedEventArgs : EventArgs
    {
        private readonly SystemSettingsIdleLockState _lockState;
        internal LockStateChangedEventArgs(SystemSettingsIdleLockState val)
        {
            _lockState = val;
        }

        /// <summary>
        /// Indicates the current lock state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SystemSettingsIdleLockState Value
        {
            get
            {
                return _lockState;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the AdsIdChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class AdsIdChangedEventArgs : EventArgs
    {
        private readonly string _adsId = null;
        internal AdsIdChangedEventArgs(string val)
        {
            _adsId = val;
        }

        /// <summary>
        /// Indicates the current lock state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _adsId;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the UltraDataSaveChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/network.telephony</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class UltraDataSaveChangedEventArgs : EventArgs
    {
        private readonly SystemSettingsUdsState _ultraDataSave = SystemSettingsUdsState.UdsOff;
        internal UltraDataSaveChangedEventArgs(SystemSettingsUdsState val)
        {
            _ultraDataSave = val;
        }

        /// <summary>
        /// Indicates the current lock state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SystemSettingsUdsState Value
        {
            get
            {
                return _ultraDataSave;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the UltraDataSavePackageListChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/network.telephony</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 3 </since_tizen>
    public class UltraDataSavePackageListChangedEventArgs : EventArgs
    {
        private readonly string _ultraDataSavePackageList = null;
        internal UltraDataSavePackageListChangedEventArgs(string val)
        {
            _ultraDataSavePackageList = val;
        }

        /// <summary>
        /// Indicates the current lock state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value
        {
            get
            {
                return _ultraDataSavePackageList;
            }
        }
    }
    /// <summary>
    /// EventArgs type for the AccessibilityTtsChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 4 </since_tizen>
    public class AccessibilityTtsSettingChangedEventArgs : EventArgs
    {
        private readonly bool _AccessibilityTts;
        internal AccessibilityTtsSettingChangedEventArgs(bool val)
        {
            _AccessibilityTts = val;
        }

        /// <summary>
        /// Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Value
        {
            get
            {
                return _AccessibilityTts;
            }
        }
    }


    /// <summary>
    /// EventArgs type for the VibrationChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 5 </since_tizen>
    public class VibrationChangedEventArgs : EventArgs
    {
        private readonly bool _vibration;
        internal VibrationChangedEventArgs(bool val)
        {
            _vibration = val;
        }

        /// <summary>
        /// Indicates whether the vibration is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool Value
        {
            get
            {
                return _vibration;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the AutomaticTimeUpdateChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/network.telephony</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 5 </since_tizen>
    public class AutomaticTimeUpdateChangedEventArgs : EventArgs
    {
        private readonly bool _automaticTimeUpdate;
        internal AutomaticTimeUpdateChangedEventArgs(bool val)
        {
            _automaticTimeUpdate = val;
        }

        /// <summary>
        /// Indicates whether the updating time is automatically enabled on the device or not.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool Value
        {
            get
            {
                return _automaticTimeUpdate;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the DeveloperOptionStateChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 5 </since_tizen>
    public class DeveloperOptionStateChangedEventArgs : EventArgs
    {
        private readonly bool _developerOptionState;
        internal DeveloperOptionStateChangedEventArgs(bool val)
        {
            _developerOptionState = val;
        }

        /// <summary>
        /// Indicates whether developer option state is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool Value
        {
            get
            {
                return _developerOptionState;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the AccessibilityGrayscaleChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/accessibility.grayscale</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 6 </since_tizen>
    public class AccessibilityGrayscaleChangedEventArgs : EventArgs
    {
        private readonly bool _accessibilityGrayscale;
        internal AccessibilityGrayscaleChangedEventArgs(bool val)
        {
            _accessibilityGrayscale = val;
        }

        /// <summary>
        /// Indicates whether accessibility grayscale is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Value
        {
            get
            {
                return _accessibilityGrayscale;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the AccessibilityNegativeColorChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/accessibility.negative</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 6 </since_tizen>
    public class AccessibilityNegativeColorChangedEventArgs : EventArgs
    {
        private readonly bool _accessibilityNegativeColor;
        internal AccessibilityNegativeColorChangedEventArgs(bool val)
        {
            _accessibilityNegativeColor = val;
        }

        /// <summary>
        /// Indicates whether accessibility negative color is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Value
        {
            get
            {
                return _accessibilityNegativeColor;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the RotaryEventEnabledChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/input.rotating_bezel</feature>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <remarks>
    /// http://tizen.org/privilege/systemsettings.admin is needed only for setting value. When getting the value, it isn't needed.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    public class RotaryEventEnabledChangedEventArgs : EventArgs
    {
        internal RotaryEventEnabledChangedEventArgs(bool val)
        {
            Value = val;
        }

        /// <summary>
        /// Indicates whether rotary event enable is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Value { get; }
    }

    /// <summary>
    /// This is EventArgs type for the OobeChanged event.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
    /// <privlevel>platform</privlevel>
    /// <feature>http://tizen.org/feature/systemsetting</feature>
    /// <feature>http://tizen.org/feature/systemsettings.oobe</feature>
    /// <exception cref="ArgumentException">Invalid Argument</exception>
    /// <exception cref="NotSupportedException">Not Supported feature</exception>
    /// <exception cref="InvalidOperationException">Invalid operation</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
    /// <since_tizen> 6 </since_tizen>
    public class OobeChangedEventArgs : EventArgs
    {
        private readonly bool _oobe;
        internal OobeChangedEventArgs(bool val)
        {
            _oobe = val;
        }

        /// <summary>
        /// Indicates whether accessibility negative color is enabled on the device or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public bool Value
        {
            get
            {
                return _oobe;
            }
        }
    }
}
