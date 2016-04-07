using System;

namespace Tizen.System.SystemSettings
{
    /// <summary>
    /// EventArgs type for the event IncomingCallRingtoneChanged
    /// </summary>
    public class IncomingCallRingtoneChangedEventArgs : EventArgs
    {
        private readonly string _incomingCallRingtone = null;
        /// <summary>
        /// The enum for IncomingCallRingtone system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.IncomingCallRingtone;
            }
        }

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
        /// <summary>
        /// The enum for WallpaperHomeScreen system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.WallpaperHomeScreen;
            }
        }

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
        /// <summary>
        /// The enum for WallpaperLockScreen system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.WallpaperLockScreen;
            }
        }

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
        /// <summary>
        /// The enum for FontSize system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.FontSize;
            }
        }
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
        /// <summary>
        /// The enum for FontType system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.FontType;
            }
        }
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
    public class MotionActivationChangedEventArgs : EventArgs
    {
        private readonly bool _motionActivation;
        /// <summary>
        /// The enum for MotionActivation system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.MotionActivation;
            }
        }
        internal MotionActivationChangedEventArgs(bool val)
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
        /// <summary>
        /// The enum for EmailAlertRingtone system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.EmailAlertRingtone;
            }
        }
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
        /// <summary>
        /// The enum for UsbDebuggingEnabled system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.UsbDebuggingEnabled;
            }
        }
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
        /// <summary>
        /// The enum for Data3GNetworkEnabled system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.Data3GNetworkEnabled;
            }
        }
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
        /// <summary>
        /// The enum for LockscreenApp system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LockscreenApp;
            }
        }
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
    /// EventArgs type for the event DefaultFontTypeChanged
    /// </summary>
    public class DefaultFontTypeChangedEventArgs : EventArgs
    {
        private readonly string _defaultFontType = null;
        /// <summary>
        /// The enum for DefaultFontType system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.DefaultFontType;
            }
        }
        internal DefaultFontTypeChangedEventArgs(string val)
        {
            _defaultFontType = val;
        }

        /// <summary>
        /// The current system default font type
        /// </summary>
        public string Value
        {
            get
            {
                return _defaultFontType;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleCountryChanged
    /// </summary>
    public class LocaleCountryChangedEventArgs : EventArgs
    {
        private readonly string _localeCountry = null;
        /// <summary>
        /// The enum for LocaleCountry system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LocaleCountry;
            }
        }
        internal LocaleCountryChangedEventArgs(string val)
        {
            _localeCountry = val;
        }

        /// <summary>
        /// Indicates the current country setting in the <LANGUAGE>_<REGION> syntax.
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
        /// <summary>
        /// The enum for LocaleLanguage system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LocaleLanguage;
            }
        }
        internal LocaleLanguageChangedEventArgs(string val)
        {
            _localeLanguage = val;
        }

        /// <summary>
        /// Indicates the current language setting in the <LANGUAGE>_<REGION> syntax.
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
    /// EventArgs type for the event LocaleTimeformat24HourChanged
    /// </summary>
    public class LocaleTimeformat24HourChangedEventArgs : EventArgs
    {
        private readonly bool _localeTimeformat24Hour;
        /// <summary>
        /// The enum for LocaleTimeformat24Hour system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LocaleTimeformat24Hour;
            }
        }
        internal LocaleTimeformat24HourChangedEventArgs(bool val)
        {
            _localeTimeformat24Hour = val;
        }

        /// <summary>
        /// Indicates whether the 24-hour clock is used. If the value is false, the 12-hour clock is used.
        /// </summary>
        public bool Value
        {
            get
            {
                return _localeTimeformat24Hour;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event LocaleTimezoneChanged
    /// </summary>
    public class LocaleTimezoneChangedEventArgs : EventArgs
    {
        private readonly string _localeTimezone = null;
        /// <summary>
        /// The enum for LocaleTimezone system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LocaleTimezone;
            }
        }
        internal LocaleTimezoneChangedEventArgs(string val)
        {
            _localeTimezone = val;
        }

        /// <summary>
        /// Indicates the current time zone
        /// </summary>
        public string Value
        {
            get
            {
                return _localeTimezone;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event TimeChanged
    /// </summary>
    public class TimeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The enum for Time system setting event
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.Time;
            }
        }
    }

    /// <summary>
    /// EventArgs type for the event SoundLockChanged
    /// </summary>
    public class SoundLockChangedEventArgs : EventArgs
    {
        private readonly bool _soundLock;
        /// <summary>
        /// The enum for SoundLock system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.SoundLock;
            }
        }
        internal SoundLockChangedEventArgs(bool val)
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
    public class SoundSilentModeChangedEventArgs : EventArgs
    {
        private readonly bool _soundSilentMode;
        /// <summary>
        /// The enum for SoundSilentMode system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.SoundSilentMode;
            }
        }
        internal SoundSilentModeChangedEventArgs(bool val)
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
    public class SoundTouchChangedEventArgs : EventArgs
    {
        private readonly bool _soundTouch;
        /// <summary>
        /// The enum for SoundTouch system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.SoundTouch;
            }
        }
        internal SoundTouchChangedEventArgs(bool val)
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
    public class DisplayScreenRotationAutoChangedEventArgs : EventArgs
    {
        private readonly bool _displayScreenRotationAuto;
        /// <summary>
        /// The enum for DisplayScreenRotationAuto system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.DisplayScreenRotationAuto;
            }
        }
        internal DisplayScreenRotationAutoChangedEventArgs(bool val)
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
        /// <summary>
        /// The enum for DeviceName system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.DeviceName;
            }
        }
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
        /// <summary>
        /// The enum for MotionEnabled system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.MotionEnabled;
            }
        }
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
    public class NetworkWifiNotificationChangedEventArgs : EventArgs
    {
        private readonly bool _networkWifiNotification;
        /// <summary>
        /// The enum for NetworkWifiNotification system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.NetworkWifiNotification;
            }
        }
        internal NetworkWifiNotificationChangedEventArgs(bool val)
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
    public class NetworkFlightModeChangedEventArgs : EventArgs
    {
        private readonly bool _networkFlightMode;
        /// <summary>
        /// The enum for NetworkFlightMode system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.NetworkFlightMode;
            }
        }
        internal NetworkFlightModeChangedEventArgs(bool val)
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
        /// <summary>
        /// The enum for ScreenBacklightTime system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.ScreenBacklightTime;
            }
        }
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
        /// <summary>
        /// The enum for SoundNotification system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.SoundNotification;
            }
        }
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
        /// <summary>
        /// The enum for SoundNotificationRepetitionPeriod system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.SoundNotificationRepetitionPeriod;
            }
        }
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
        /// <summary>
        /// The enum for LockState system setting key
        /// </summary>
        public SystemSettingsKeys Key
        {
            get
            {
                return SystemSettingsKeys.LockState;
            }
        }
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
