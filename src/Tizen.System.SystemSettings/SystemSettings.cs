using System;

namespace Tizen.System.SystemSettings
{
    /// <summary>
    /// The System Settings API provides APIs for sharing configuration over a system
    /// </summary>
    /// <remarks>
    /// System Settings API provides functions for getting the system configuration related to user preferences.
    /// The main features of the System Settings API include accessing system-wide configurations, such as ringtones, wallpapers, and etc
    /// </remarks>
    public static class SystemSettings
    {
        /// <summary>
        /// The file path of the current ringtone
        /// </summary>
        public static string IncomingCallRingtone
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.IncomingCallRingtone, out filePath);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get IncomingCallRingtone system setting value.");
                }
                return filePath;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.IncomingCallRingtone, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set IncomingCallRingtone system setting.");
                }
            }
        }

        /// <summary>
        /// The file path of the current home screen wallpaper
        /// </summary>
        public static string WallpaperHomeScreen
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.WallpaperHomeScreen, out filePath);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get WallpaperHomeScreen system setting value.");
                }
                return filePath;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.WallpaperHomeScreen, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set WallpaperHomeScreen system setting.");
                }
            }
        }

        /// <summary>
        /// The file path of the current lock screen wallpaper
        /// </summary>
        public static string WallpaperLockScreen
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.WallpaperLockScreen, out filePath);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get WallpaperLockScreen system setting value.");
                }
                return filePath;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.WallpaperLockScreen, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set WallpaperLockScreen system setting.");
                }
            }
        }

        /// <summary>
        /// The current system font size
        /// </summary>
        public static SystemSettingsFontSize FontSize
        {
            get
            {
                int fontSize;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.FontSize, out fontSize);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get FontSize system setting value.");
                }
                return (SystemSettingsFontSize)fontSize;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueInt(SystemSettingsKeys.FontSize, (int)value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set FontSize system setting.");
                }
            }
        }

        /// <summary>
        /// The current system font type
        /// </summary>
        public static string FontType
        {
            get
            {
                string fontType;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.FontType, out fontType);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get FontType system setting value.");
                }
                return fontType;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.FontType, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set FontType system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the motion service is activated
        /// </summary>
        public static bool MotionActivation
        {
            get
            {
                bool isMotionServiceActivated;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.MotionActivation, out isMotionServiceActivated);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get MotionActivation system setting value.");
                }
                return isMotionServiceActivated;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.MotionActivation, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set MotionActivation system setting.");
                }
            }
        }

        /// <summary>
        /// The file path of the current email alert ringtone
        /// </summary>
        public static string EmailAlertRingtone
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.EmailAlertRingtone, out filePath);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get EmailAlertRingtone system setting value.");
                }
                return filePath;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.EmailAlertRingtone, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set EmailAlertRingtone system setting.");
                }
            }
        }
        /// <summary>
        /// Indicates whether the USB debugging is enabled (Since 2.4)
        /// </summary>
        public static bool UsbDebuggingEnabled
        {
            get
            {
                bool isusbDebuggingEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.UsbDebuggingEnabled, out isusbDebuggingEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get UsbDebuggingEnabled system setting value.");
                }
                return isusbDebuggingEnabled;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.UsbDebuggingEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set UsbDebuggingEnabled system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the 3G data network is enabled (Since 2.4)
        /// </summary>
        public static bool Data3GNetworkEnabled
        {
            get
            {
                bool is3GDataEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.Data3GNetworkEnabled, out is3GDataEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get Data3GNetworkEnabled system setting value.");
                }
                return is3GDataEnabled;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.Data3GNetworkEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set Data3GNetworkEnabled system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates lockscreen app pkg name
        /// </summary>
        public static string LockscreenApp
        {
            get
            {
                string pkgName;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LockscreenApp, out pkgName);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LockscreenApp system setting value.");
                }
                return pkgName;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LockscreenApp, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LockscreenApp system setting.");
                }
            }
        }

        /// <summary>
        /// The current system default font type (only support Get)
        /// </summary>
        public static string DefaultFontType
        {
            get
            {
                string defaultFontType;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.DefaultFontType, out defaultFontType);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get DefaultFontType system setting value.");
                }
                return defaultFontType;
            }
        }

        /// <summary>
        /// Indicates the current country setting in the <LANGUAGE>_<REGION> syntax.
        /// The country setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format
        /// </summary>
        public static string LocaleCountry
        {
            get
            {
                string countrySetting;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleCountry, out countrySetting);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LocaleCountry system setting value.");
                }
                return countrySetting;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LocaleCountry, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleCountry system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the current language setting in the <LANGUAGE>_<REGION> syntax.
        /// The language setting is in the ISO 639-2 format
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        public static string LocaleLanguage
        {
            get
            {
                string languageSetting;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleLanguage, out languageSetting);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LocaleLanguage system setting value.");
                }
                return languageSetting;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LocaleLanguage, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleLanguage system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the 24-hour clock is used.
        /// If the value is false, the 12-hour clock is used.
        /// </summary>
        public static bool LocaleTimeformat24Hour
        {
            get
            {
                bool is24HrFormat;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.LocaleTimeformat24Hour, out is24HrFormat);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LocaleTimeformat24Hour system setting value.");
                }
                return is24HrFormat;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.LocaleTimeformat24Hour, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleTimeformat24Hour system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the current time zone.
        /// </summary>
        public static string LocaleTimezone
        {
            get
            {
                string timeZone;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleTimezone, out timeZone);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LocaleTimezone system setting value.");
                }
                return timeZone;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LocaleTimezone, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleTimezone system setting.");
                }
            }
        }
        /// <summary>
        /// Indicates whether the screen lock sound is enabled on the device. ex) LCD on/off sound
        /// </summary>
        public static bool SoundLock
        {
            get
            {
                bool isSoundLockEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundLock, out isSoundLockEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get SoundLock system setting value.");
                }
                return isSoundLockEnabled;
            }
        }

        /// <summary>
        /// Indicates whether the device is in the silent mode.
        /// </summary>
        public static bool SoundSilentMode
        {
            get
            {
                bool isSilent;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundSilentMode, out isSilent);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get SoundSilentMode system setting value.");
                }
                return isSilent;
            }
        }

        /// <summary>
        /// Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        public static bool SoundTouch
        {
            get
            {
                bool isTouchSoundEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundTouch, out isTouchSoundEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get SoundTouch system setting value.");
                }
                return isTouchSoundEnabled;
            }
        }

        /// <summary>
        /// Indicates whether rotation control is automatic.
        /// </summary>
        public static bool DisplayScreenRotationAuto
        {
            get
            {
                bool isRotationAutomatic;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.DisplayScreenRotationAuto, out isRotationAutomatic);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get DisplayScreenRotationAuto system setting value.");
                }
                return isRotationAutomatic;
            }
        }

        /// <summary>
        /// Indicates device name.
        /// </summary>
        public static string DeviceName
        {
            get
            {
                string deviceName;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.DeviceName, out deviceName);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get DeviceName system setting value.");
                }
                return deviceName;
            }
        }
        /// <summary>
        /// Indicates whether the device user has enabled motion feature.
        /// </summary>
        public static bool MotionEnabled
        {
            get
            {
                bool isMotionEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.MotionEnabled, out isMotionEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get MotionEnabled system setting value.");
                }
                return isMotionEnabled;
            }
        }

        /// <summary>
        /// Indicates whether Wi-Fi-related notifications are enabled on the device.
        /// </summary>
        public static bool NetworkWifiNotification
        {
            get
            {
                bool isWifiNotificationEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.NetworkWifiNotification, out isWifiNotificationEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get NetworkWifiNotification system setting value.");
                }
                return isWifiNotificationEnabled;
            }
        }

        /// <summary>
        /// Indicates whether the device is in the flight mode.
        /// </summary>
        public static bool NetworkFlightMode
        {
            get
            {
                bool isFlightModeEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.NetworkFlightMode, out isFlightModeEnabled);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get NetworkFlightMode system setting value.");
                }
                return isFlightModeEnabled;
            }
        }

        /// <summary>
        /// Indicates the backlight time (in seconds). The following values can be used: 15, 30, 60, 120, 300, and 600.
        /// </summary>
        public static int ScreenBacklightTime
        {
            get
            {
                int backlightTime;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.ScreenBacklightTime, out backlightTime);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get ScreenBacklightTime system setting value.");
                }
                return backlightTime;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueInt(SystemSettingsKeys.ScreenBacklightTime, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set ScreenBacklightTime system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the file path of the current notification tone set by the user.
        /// </summary>
        public static string SoundNotification
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.SoundNotification, out filePath);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get SoundNotification system setting value.");
                }
                return filePath;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.SoundNotification, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set SoundNotification system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the time period for notification repetitions.
        /// </summary>
        public static int SoundNotificationRepetitionPeriod
        {
            get
            {
                int notificationRepetitionPeriod;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.SoundNotificationRepetitionPeriod, out notificationRepetitionPeriod);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get SoundNotificationRepetitionPeriod system setting value.");
                }
                return notificationRepetitionPeriod;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueInt(SystemSettingsKeys.SoundNotificationRepetitionPeriod, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set SoundNotificationRepetitionPeriod system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the current lock state
        /// </summary>
        public static SystemSettingsIdleLockState LockState
        {
            get
            {
                int LockState;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.LockState, out LockState);
                if (res != SystemSettingsError.None)
                {
                    Log.Warn(SystemSettingsExceptionFactory.LogTag, "unable to get LockState system setting value.");
                }
                return (SystemSettingsIdleLockState)LockState;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueInt(SystemSettingsKeys.LockState, (int)value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LockState system setting.");
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_incomingCallRingtoneChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string path = SystemSettings.IncomingCallRingtone;
            IncomingCallRingtoneChangedEventArgs eventArgs = new IncomingCallRingtoneChangedEventArgs(path);
            s_incomingCallRingtoneChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<IncomingCallRingtoneChangedEventArgs> s_incomingCallRingtoneChanged;
        /// <summary>
        /// IncomingCallRingtoneChanged event is triggered when the file path of the incoming ringtone is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A IncomingCallRingtoneChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<IncomingCallRingtoneChangedEventArgs> IncomingCallRingtoneChanged
        {
            add
            {
                if (s_incomingCallRingtoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.IncomingCallRingtone, s_incomingCallRingtoneChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_incomingCallRingtoneChanged += value;
            }

            remove
            {
                s_incomingCallRingtoneChanged -= value;
                if (s_incomingCallRingtoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.IncomingCallRingtone);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_wallpaperHomeScreenChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string path = SystemSettings.WallpaperHomeScreen;
            WallpaperHomeScreenChangedEventArgs eventArgs = new WallpaperHomeScreenChangedEventArgs(path);
            s_wallpaperHomeScreenChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<WallpaperHomeScreenChangedEventArgs> s_wallpaperHomeScreenChanged;
        /// <summary>
        /// WallpaperHomeScreenChanged event is triggered when the file path of the current home screen wallpaper is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A WallpaperHomeScreenChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<WallpaperHomeScreenChangedEventArgs> WallpaperHomeScreenChanged
        {
            add
            {
                if (s_wallpaperHomeScreenChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.WallpaperHomeScreen, s_wallpaperHomeScreenChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_wallpaperHomeScreenChanged += value;
            }

            remove
            {
                s_wallpaperHomeScreenChanged -= value;
                if (s_wallpaperHomeScreenChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.WallpaperHomeScreen);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_wallpaperLockScreenChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string path = SystemSettings.WallpaperLockScreen;
            WallpaperLockScreenChangedEventArgs eventArgs = new WallpaperLockScreenChangedEventArgs(path);
            s_wallpaperLockScreenChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<WallpaperLockScreenChangedEventArgs> s_wallpaperLockScreenChanged;
        /// <summary>
        /// WallpaperLockScreenChanged event is triggered when the file path of the current lock screen wallpaper is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A WallpaperLockScreenChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<WallpaperLockScreenChangedEventArgs> WallpaperLockScreenChanged
        {
            add
            {
                if (s_wallpaperLockScreenChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.WallpaperLockScreen, s_wallpaperLockScreenChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_wallpaperLockScreenChanged += value;
            }

            remove
            {
                s_wallpaperLockScreenChanged -= value;
                if (s_wallpaperLockScreenChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.WallpaperLockScreen);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_fontSizeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            SystemSettingsFontSize fontSize = SystemSettings.FontSize;
            FontSizeChangedEventArgs eventArgs = new FontSizeChangedEventArgs(fontSize);
            s_fontSizeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<FontSizeChangedEventArgs> s_fontSizeChanged;
        /// <summary>
        /// FontSizeChanged event is triggered when the current system font size is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A FontSizeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<FontSizeChangedEventArgs> FontSizeChanged
        {
            add
            {
                if (s_fontSizeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.FontSize, s_fontSizeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_fontSizeChanged += value;
            }

            remove
            {
                s_fontSizeChanged -= value;
                if (s_fontSizeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.FontSize);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_fontTypeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string fontType = SystemSettings.FontType;
            FontTypeChangedEventArgs eventArgs = new FontTypeChangedEventArgs(fontType);
            s_fontTypeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<FontTypeChangedEventArgs> s_fontTypeChanged;
        /// <summary>
        /// FontTypeChanged event is triggered when the current system font type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A FontTypeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<FontTypeChangedEventArgs> FontTypeChanged
        {
            add
            {
                if (s_fontTypeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.FontType, s_fontTypeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_fontTypeChanged += value;
            }

            remove
            {
                s_fontTypeChanged -= value;
                if (s_fontTypeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.FontType);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_motionActivationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool motionActivation = SystemSettings.MotionActivation;
            MotionActivationChangedEventArgs eventArgs = new MotionActivationChangedEventArgs(motionActivation);
            s_motionActivationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<MotionActivationChangedEventArgs> s_motionActivationChanged;
        /// <summary>
        /// MotionActivationChanged event is triggered when the motion service status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A MotionActivationChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<MotionActivationChangedEventArgs> MotionActivationChanged
        {
            add
            {
                if (s_motionActivationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.MotionActivation, s_motionActivationChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_motionActivationChanged += value;
            }

            remove
            {
                s_motionActivationChanged -= value;
                if (s_motionActivationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.MotionActivation);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_emailAlertRingtoneChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string emailAlertRingtone = SystemSettings.EmailAlertRingtone;
            EmailAlertRingtoneChangedEventArgs eventArgs = new EmailAlertRingtoneChangedEventArgs(emailAlertRingtone);
            s_emailAlertRingtoneChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<EmailAlertRingtoneChangedEventArgs> s_emailAlertRingtoneChanged;
        /// <summary>
        /// EmailAlertRingtoneChanged event is triggered when the file path of the current email alert ringtone is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A EmailAlertRingtoneChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<EmailAlertRingtoneChangedEventArgs> EmailAlertRingtoneChanged
        {
            add
            {
                if (s_emailAlertRingtoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.EmailAlertRingtone, s_emailAlertRingtoneChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_emailAlertRingtoneChanged += value;
            }

            remove
            {
                s_emailAlertRingtoneChanged -= value;
                if (s_emailAlertRingtoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.EmailAlertRingtone);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_usbDebuggingSettingChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool usbDebuggingEnabled = SystemSettings.UsbDebuggingEnabled;
            UsbDebuggingSettingChangedEventArgs eventArgs = new UsbDebuggingSettingChangedEventArgs(usbDebuggingEnabled);
            s_usbDebuggingSettingChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<UsbDebuggingSettingChangedEventArgs> s_usbDebuggingSettingChanged;
        /// <summary>
        /// UsbDebuggingSettingChangedEventArgs event is triggered when the USB debugging status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A UsbDebuggingSettingChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<UsbDebuggingSettingChangedEventArgs> UsbDebuggingSettingChanged
        {
            add
            {
                if (s_usbDebuggingSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.UsbDebuggingEnabled, s_usbDebuggingSettingChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_usbDebuggingSettingChanged += value;
            }

            remove
            {
                s_usbDebuggingSettingChanged -= value;
                if (s_usbDebuggingSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.UsbDebuggingEnabled);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_data3GNetworkSettingChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool data3GEnabled = SystemSettings.Data3GNetworkEnabled;
            Data3GNetworkSettingChangedEventArgs eventArgs = new Data3GNetworkSettingChangedEventArgs(data3GEnabled);
            s_data3GNetworkSettingChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<Data3GNetworkSettingChangedEventArgs> s_data3GNetworkSettingChanged;
        /// <summary>
        /// Data3GNetworkSettingChanged event is triggered when the 3G data network status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A Data3GNetworkSettingChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<Data3GNetworkSettingChangedEventArgs> Data3GNetworkSettingChanged
        {
            add
            {
                if (s_data3GNetworkSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.Data3GNetworkEnabled, s_data3GNetworkSettingChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_data3GNetworkSettingChanged += value;
            }

            remove
            {
                s_data3GNetworkSettingChanged -= value;
                if (s_data3GNetworkSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.Data3GNetworkEnabled);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_lockscreenAppChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string lockScreenApp = SystemSettings.LockscreenApp;
            LockscreenAppChangedEventArgs eventArgs = new LockscreenAppChangedEventArgs(lockScreenApp);
            s_lockscreenAppChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LockscreenAppChangedEventArgs> s_lockscreenAppChanged;
        /// <summary>
        /// LockscreenAppChanged event is triggered when the lockscreen app pkg name is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LockscreenAppChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LockscreenAppChangedEventArgs> LockscreenAppChanged
        {
            add
            {
                if (s_lockscreenAppChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LockscreenApp, s_lockscreenAppChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_lockscreenAppChanged += value;
            }

            remove
            {
                s_lockscreenAppChanged -= value;
                if (s_lockscreenAppChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LockscreenApp);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_defaultFontTypeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string defaultFontType = SystemSettings.DefaultFontType;
            DefaultFontTypeChangedEventArgs eventArgs = new DefaultFontTypeChangedEventArgs(defaultFontType);
            s_defaultFontTypeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<DefaultFontTypeChangedEventArgs> s_defaultFontTypeChanged;
        /// <summary>
        /// DefaultFontTypeChanged event is triggered when the current system default font type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A DefaultFontTypeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<DefaultFontTypeChangedEventArgs> DefaultFontTypeChanged
        {
            add
            {
                if (s_defaultFontTypeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.DefaultFontType, s_defaultFontTypeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_defaultFontTypeChanged += value;
            }

            remove
            {
                s_defaultFontTypeChanged -= value;
                if (s_defaultFontTypeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DefaultFontType);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeCountryChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string localeCountry = SystemSettings.LocaleCountry;
            LocaleCountryChangedEventArgs eventArgs = new LocaleCountryChangedEventArgs(localeCountry);
            s_localeCountryChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleCountryChangedEventArgs> s_localeCountryChanged;
        /// <summary>
        /// LocaleCountryChanged event is triggered when the current country setting in the <LANGUAGE>_<REGION> syntax, is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LocaleCountryChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LocaleCountryChangedEventArgs> LocaleCountryChanged
        {
            add
            {
                if (s_localeCountryChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleCountry, s_localeCountryChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_localeCountryChanged += value;
            }

            remove
            {
                s_localeCountryChanged -= value;
                if (s_localeCountryChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleCountry);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeLanguageChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string localeLanguage = SystemSettings.LocaleLanguage;
            LocaleLanguageChangedEventArgs eventArgs = new LocaleLanguageChangedEventArgs(localeLanguage);
            s_localeLanguageChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleLanguageChangedEventArgs> s_localeLanguageChanged;
        /// <summary>
        /// LocaleLanguageChanged event is triggered when the current language setting in the <LANGUAGE>_<REGION> syntax, is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LocaleLanguageChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LocaleLanguageChangedEventArgs> LocaleLanguageChanged
        {
            add
            {
                if (s_localeLanguageChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleLanguage, s_localeLanguageChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_localeLanguageChanged += value;
            }

            remove
            {
                s_localeLanguageChanged -= value;
                if (s_localeLanguageChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleLanguage);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeTimeformat24HourChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool localeTimeFormat24Hour = SystemSettings.LocaleTimeformat24Hour;
            LocaleTimeformat24HourChangedEventArgs eventArgs = new LocaleTimeformat24HourChangedEventArgs(localeTimeFormat24Hour);
            s_localeTimeformat24HourChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleTimeformat24HourChangedEventArgs> s_localeTimeformat24HourChanged;
        /// <summary>
        /// LocaleTimeformat24HourChanged event is triggered when the time format is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LocaleTimeformat24HourChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LocaleTimeformat24HourChangedEventArgs> LocaleTimeformat24HourChanged
        {
            add
            {
                if (s_localeTimeformat24HourChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleTimeformat24Hour, s_localeTimeformat24HourChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_localeTimeformat24HourChanged += value;
            }

            remove
            {
                s_localeTimeformat24HourChanged -= value;
                if (s_localeTimeformat24HourChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleTimeformat24Hour);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeTimezoneChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string localeTimezone = SystemSettings.LocaleTimezone;
            LocaleTimezoneChangedEventArgs eventArgs = new LocaleTimezoneChangedEventArgs(localeTimezone);
            s_localeTimezoneChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleTimezoneChangedEventArgs> s_localeTimezoneChanged;
        /// <summary>
        /// LocaleTimezoneChanged event is triggered when the  current time zone is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LocaleTimezoneChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LocaleTimezoneChangedEventArgs> LocaleTimezoneChanged
        {
            add
            {
                if (s_localeTimezoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleTimezone, s_localeTimezoneChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_localeTimezoneChanged += value;
            }

            remove
            {
                s_localeTimezoneChanged -= value;
                if (s_localeTimezoneChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleTimezone);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_timeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            //bool motionActivation = SystemSettings.Time;
            TimeChangedEventArgs eventArgs = new TimeChangedEventArgs();
            s_timeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<TimeChangedEventArgs> s_timeChanged;
        /// <summary>
        /// TimeChanged event is triggered when the system time is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A TimeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<TimeChangedEventArgs> TimeChanged
        {
            add
            {
                if (s_timeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.Time, s_timeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_timeChanged += value;
            }

            remove
            {
                s_timeChanged -= value;
                if (s_timeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.Time);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundLockChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundLock = SystemSettings.SoundLock;
            SoundLockChangedEventArgs eventArgs = new SoundLockChangedEventArgs(soundLock);
            s_soundLockChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundLockChangedEventArgs> s_soundLockChanged;
        /// <summary>
        /// SoundLockChanged event is triggered when the screen lock sound enabled status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A SoundLockChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<SoundLockChangedEventArgs> SoundLockChanged
        {
            add
            {
                if (s_soundLockChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundLock, s_soundLockChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_soundLockChanged += value;
            }

            remove
            {
                s_soundLockChanged -= value;
                if (s_soundLockChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundLock);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundSilentModeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundSilentMode = SystemSettings.SoundSilentMode;
            SoundSilentModeChangedEventArgs eventArgs = new SoundSilentModeChangedEventArgs(soundSilentMode);
            s_soundSilentModeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundSilentModeChangedEventArgs> s_soundSilentModeChanged;
        /// <summary>
        /// SoundSilentModeChanged event is triggered when the silent mode status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A SoundSilentModeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<SoundSilentModeChangedEventArgs> SoundSilentModeChanged
        {
            add
            {
                if (s_soundSilentModeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundSilentMode, s_soundSilentModeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_soundSilentModeChanged += value;
            }

            remove
            {
                s_soundSilentModeChanged -= value;
                if (s_soundSilentModeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundSilentMode);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundTouchChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundTouch = SystemSettings.SoundTouch;
            SoundTouchChangedEventArgs eventArgs = new SoundTouchChangedEventArgs(soundTouch);
            s_soundTouchChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundTouchChangedEventArgs> s_soundTouchChanged;
        /// <summary>
        /// SoundTouchChanged event is triggered when the screen touch sound enabled status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A SoundTouchChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<SoundTouchChangedEventArgs> SoundTouchChanged
        {
            add
            {
                if (s_soundTouchChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundTouch, s_soundTouchChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_soundTouchChanged += value;
            }

            remove
            {
                s_soundTouchChanged -= value;
                if (s_soundTouchChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundTouch);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_displayScreenRotationAutoChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool displayScreenRotationAuto = SystemSettings.DisplayScreenRotationAuto;
            DisplayScreenRotationAutoChangedEventArgs eventArgs = new DisplayScreenRotationAutoChangedEventArgs(displayScreenRotationAuto);
            s_displayScreenRotationAutoChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<DisplayScreenRotationAutoChangedEventArgs> s_displayScreenRotationAutoChanged;
        /// <summary>
        /// DisplayScreenRotationAutoChanged event is triggered when the automatic rotation control status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A DisplayScreenRotationAutoChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<DisplayScreenRotationAutoChangedEventArgs> DisplayScreenRotationAutoChanged
        {
            add
            {
                if (s_displayScreenRotationAutoChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.DisplayScreenRotationAuto, s_displayScreenRotationAutoChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_displayScreenRotationAutoChanged += value;
            }

            remove
            {
                s_displayScreenRotationAutoChanged -= value;
                if (s_displayScreenRotationAutoChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DisplayScreenRotationAuto);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_deviceNameChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string deviceName = SystemSettings.DeviceName;
            DeviceNameChangedEventArgs eventArgs = new DeviceNameChangedEventArgs(deviceName);
            s_deviceNameChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<DeviceNameChangedEventArgs> s_deviceNameChanged;
        /// <summary>
        /// DeviceNameChanged event is triggered when the device name is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A DeviceNameChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<DeviceNameChangedEventArgs> DeviceNameChanged
        {
            add
            {
                if (s_deviceNameChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.DeviceName, s_deviceNameChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_deviceNameChanged += value;
            }

            remove
            {
                s_deviceNameChanged -= value;
                if (s_deviceNameChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DeviceName);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_motionSettingChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool motionEnabled = SystemSettings.MotionEnabled;
            MotionSettingChangedEventArgs eventArgs = new MotionSettingChangedEventArgs(motionEnabled);
            s_motionSettingChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<MotionSettingChangedEventArgs> s_motionSettingChanged;
        /// <summary>
        /// MotionSettingChanged event is triggered when the motion feature enabled status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A MotionSettingChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<MotionSettingChangedEventArgs> MotionSettingChanged
        {
            add
            {
                if (s_motionSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.MotionEnabled, s_motionSettingChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_motionSettingChanged += value;
            }

            remove
            {
                s_motionSettingChanged -= value;
                if (s_motionSettingChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.MotionEnabled);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_networkWifiNotificationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool networkWifiNotification = SystemSettings.NetworkWifiNotification;
            NetworkWifiNotificationChangedEventArgs eventArgs = new NetworkWifiNotificationChangedEventArgs(networkWifiNotification);
            s_networkWifiNotificationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<NetworkWifiNotificationChangedEventArgs> s_networkWifiNotificationChanged;
        /// <summary>
        /// NetworkWifiNotificationChanged event is triggered when the Wi-Fi-related notifications enabled status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A NetworkWifiNotificationChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<NetworkWifiNotificationChangedEventArgs> NetworkWifiNotificationChanged
        {
            add
            {
                if (s_networkWifiNotificationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.NetworkWifiNotification, s_networkWifiNotificationChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_networkWifiNotificationChanged += value;
            }

            remove
            {
                s_networkWifiNotificationChanged -= value;
                if (s_networkWifiNotificationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.NetworkWifiNotification);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_networkFlightModeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool networkFlightMode = SystemSettings.NetworkFlightMode;
            NetworkFlightModeChangedEventArgs eventArgs = new NetworkFlightModeChangedEventArgs(networkFlightMode);
            s_networkFlightModeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<NetworkFlightModeChangedEventArgs> s_networkFlightModeChanged;
        /// <summary>
        /// NetworkFlightModeChanged event is triggered when the flight mode status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A NetworkFlightModeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<NetworkFlightModeChangedEventArgs> NetworkFlightModeChanged
        {
            add
            {
                if (s_networkFlightModeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.NetworkFlightMode, s_networkFlightModeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_networkFlightModeChanged += value;
            }

            remove
            {
                s_networkFlightModeChanged -= value;
                if (s_networkFlightModeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.NetworkFlightMode);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_screenBacklightTimeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            int screenBacklightTime = SystemSettings.ScreenBacklightTime;
            ScreenBacklightTimeChangedEventArgs eventArgs = new ScreenBacklightTimeChangedEventArgs(screenBacklightTime);
            s_screenBacklightTimeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<ScreenBacklightTimeChangedEventArgs> s_screenBacklightTimeChanged;
        /// <summary>
        /// ScreenBacklightTimeChanged event is triggered when the backlight time is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A ScreenBacklightTimeChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<ScreenBacklightTimeChangedEventArgs> ScreenBacklightTimeChanged
        {
            add
            {
                if (s_screenBacklightTimeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.ScreenBacklightTime, s_screenBacklightTimeChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_screenBacklightTimeChanged += value;
            }

            remove
            {
                s_screenBacklightTimeChanged -= value;
                if (s_screenBacklightTimeChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.ScreenBacklightTime);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundNotificationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string soundNotification = SystemSettings.SoundNotification;
            SoundNotificationChangedEventArgs eventArgs = new SoundNotificationChangedEventArgs(soundNotification);
            s_soundNotificationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundNotificationChangedEventArgs> s_soundNotificationChanged;
        /// <summary>
        /// SoundNotificationChanged event is triggered when the file path of the current notification tone set by the user is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A SoundNotificationChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<SoundNotificationChangedEventArgs> SoundNotificationChanged
        {
            add
            {
                if (s_soundNotificationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundNotification, s_soundNotificationChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_soundNotificationChanged += value;
            }

            remove
            {
                s_soundNotificationChanged -= value;
                if (s_soundNotificationChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundNotification);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundNotificationRepetitionPeriodChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            int soundNotificationRepetitionPeriod = SystemSettings.SoundNotificationRepetitionPeriod;
            SoundNotificationRepetitionPeriodChangedEventArgs eventArgs = new SoundNotificationRepetitionPeriodChangedEventArgs(soundNotificationRepetitionPeriod);
            s_soundNotificationRepetitionPeriodChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundNotificationRepetitionPeriodChangedEventArgs> s_soundNotificationRepetitionPeriodChanged;
        /// <summary>
        /// SoundNotificationRepetitionPeriodChanged event is triggered when the time period for notification repetitions is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A SoundNotificationRepetitionPeriodChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<SoundNotificationRepetitionPeriodChangedEventArgs> SoundNotificationRepetitionPeriodChanged
        {
            add
            {
                if (s_soundNotificationRepetitionPeriodChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundNotificationRepetitionPeriod, s_soundNotificationRepetitionPeriodChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_soundNotificationRepetitionPeriodChanged += value;
            }

            remove
            {
                s_soundNotificationRepetitionPeriodChanged -= value;
                if (s_soundNotificationRepetitionPeriodChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundNotificationRepetitionPeriod);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_lockStateChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            SystemSettingsIdleLockState lockState = SystemSettings.LockState;
            LockStateChangedEventArgs eventArgs = new LockStateChangedEventArgs(lockState);
            s_lockStateChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LockStateChangedEventArgs> s_lockStateChanged;
        /// <summary>
        /// LockStateChanged event is triggered when the current lock state is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A LockStateChangedEventArgs object that contains the key & changed value</param>
        public static event EventHandler<LockStateChangedEventArgs> LockStateChanged
        {
            add
            {
                if (s_lockStateChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LockState, s_lockStateChangedCallback, IntPtr.Zero);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_lockStateChanged += value;
            }

            remove
            {
                s_lockStateChanged -= value;
                if (s_lockStateChanged == null)
                {
                    SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LockState);
                    if (ret != SystemSettingsError.None)
                    {
                        throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }
    }
}

