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
    /// The System Settings API provides APIs for sharing the configuration over a system.
    /// </summary>
    /// <remarks>
    /// The System Settings API provides functions for getting the system configuration related to user preferences.
    /// The main features of the System Settings API include accessing system-wide configurations, such as ringtones, wallpapers, and so on.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public static class SystemSettings
    {
        /// <summary>
        /// Lock for EventHandlers.
        /// </summary>
        private static readonly object LockObj = new object();

        /// <summary>
        /// The file path of the current ringtone.
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
        public static string IncomingCallRingtone
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.IncomingCallRingtone, out filePath);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get IncomingCallRingtone system setting.");
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
        /// The file path of the current home-screen wallpaper.
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
        public static string WallpaperHomeScreen
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.WallpaperHomeScreen, out filePath);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get WallpaperHomeScreen system setting.");
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
        /// The file path of the current lock-screen wallpaper.
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
        public static string WallpaperLockScreen
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.WallpaperLockScreen, out filePath);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get WallpaperLockScreen system setting.");
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
        /// The current system font size.
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
        public static SystemSettingsFontSize FontSize
        {
            get
            {
                int fontSize;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.FontSize, out fontSize);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get FontSize system setting.");
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
        /// The current system font type.
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
        public static string FontType
        {
            get
            {
                string fontType;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.FontType, out fontType);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get FontType system setting.");
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
        /// Indicates whether the motion service is activated.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool MotionActivationEnabled
        {
            get
            {
                bool isMotionServiceActivated;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.MotionActivationEnabled, out isMotionServiceActivated);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get MotionActivation system setting.");
                }
                return isMotionServiceActivated;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.MotionActivationEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set MotionActivation system setting.");
                }
            }
        }

        /// <summary>
        /// The file path of the current email alert ringtone.
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
        public static string EmailAlertRingtone
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.EmailAlertRingtone, out filePath);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get EmailAlertRingtone system setting.");
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
        /// Indicates whether the USB debugging is enabled.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool UsbDebuggingEnabled
        {
            get
            {
                bool isusbDebuggingEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.UsbDebuggingEnabled, out isusbDebuggingEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get UsbDebuggingEnabled system setting.");
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
        /// Indicates whether the 3G data network is enabled.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool Data3GNetworkEnabled
        {
            get
            {
                bool is3GDataEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.Data3GNetworkEnabled, out is3GDataEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get Data3GNetworkEnabled system setting.");
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
        /// Indicates the lock-screen application package name.
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
        public static string LockScreenApp
        {
            get
            {
                string pkgName;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LockScreenApp, out pkgName);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LockScreenApp system setting.");
                }
                return pkgName;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LockScreenApp, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LockScreenApp system setting.");
                }
            }
        }

        /// <summary>
        /// The current system default font type (only supports Get).
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
        public static string DefaultFontType
        {
            get
            {
                string defaultFontType;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.DefaultFontType, out defaultFontType);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get DefaultFontType system setting value.");
                }
                return defaultFontType;
            }
        }

        /// <summary>
        /// Indicates the current country setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The country setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string LocaleCountry
        {
            get
            {
                string countrySetting;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleCountry, out countrySetting);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LocaleCountry system setting.");
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
        /// Indicates the current language setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The language setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string LocaleLanguage
        {
            get
            {
                string languageSetting;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleLanguage, out languageSetting);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LocaleLanguage system setting.");
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
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool LocaleTimeFormat24HourEnabled
        {
            get
            {
                bool is24HrFormat;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.LocaleTimeFormat24HourEnabled, out is24HrFormat);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LocaleTimeFormat24Hour system setting.");
                }
                return is24HrFormat;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.LocaleTimeFormat24HourEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleTimeFormat24Hour system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates the current time zone, for example, Pacific/Tahiti.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string LocaleTimeZone
        {
            get
            {
                string timeZone;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.LocaleTimeZone, out timeZone);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LocaleTimeZone system setting.");
                }
                return timeZone;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.LocaleTimeZone, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set LocaleTimeZone system setting.");
                }
            }
        }

        /// <summary>
        /// Once the system changes time, this event occurs to notify the time change.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static int Time
        {
            get
            {
                int time;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.Time, out time);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get Time system setting.");
                }
                return time;
            }
        }
        /// <summary>
        /// Indicates whether the screen lock sound is enabled on the device, for example, the LCD on or off sound.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool SoundLockEnabled
        {
            get
            {
                bool isSoundLockEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundLockEnabled, out isSoundLockEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get SoundLock system setting.");
                }
                return isSoundLockEnabled;
            }
        }

        /// <summary>
        /// Indicates whether the device is in the silent mode.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool SoundSilentModeEnabled
        {
            get
            {
                bool isSilent;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundSilentModeEnabled, out isSilent);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get SoundSilentMode system setting.");
                }
                return isSilent;
            }
        }

        /// <summary>
        /// Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool SoundTouchEnabled
        {
            get
            {
                bool isTouchSoundEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.SoundTouchEnabled, out isTouchSoundEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get SoundTouch system setting value.");
                }
                return isTouchSoundEnabled;
            }
        }

        /// <summary>
        /// Indicates whether the rotation control is automatic.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool DisplayScreenRotationAutoEnabled
        {
            get
            {
                bool isRotationAutomatic;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.DisplayScreenRotationAutoEnabled, out isRotationAutomatic);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get DisplayScreenRotationAuto system setting.");
                }
                return isRotationAutomatic;
            }
        }

        /// <summary>
        /// Indicates the device name.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string DeviceName
        {
            get
            {
                string deviceName;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.DeviceName, out deviceName);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get DeviceName system setting value.");
                }
                return deviceName;
            }
        }
        /// <summary>
        /// Indicates whether the device user has enabled the motion feature.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool MotionEnabled
        {
            get
            {
                bool isMotionEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.MotionEnabled, out isMotionEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get MotionEnabled system setting value.");
                }
                return isMotionEnabled;
            }
        }

        /// <summary>
        /// Indicates whether Wi-Fi related notifications are enabled on the device.
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
        public static bool NetworkWifiNotificationEnabled
        {
            get
            {
                bool isWifiNotificationEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.NetworkWifiNotificationEnabled, out isWifiNotificationEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get NetworkWifiNotification system setting.");
                }
                return isWifiNotificationEnabled;
            }
        }

        /// <summary>
        /// Indicates whether the device is in the flight mode.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool NetworkFlightModeEnabled
        {
            get
            {
                bool isFlightModeEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.NetworkFlightModeEnabled, out isFlightModeEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get NetworkFlightMode system setting.");
                }
                return isFlightModeEnabled;
            }
        }

        /// <summary>
        /// Indicates the backlight time (in seconds). The following values can be used: 15, 30, 60, 120, 300, and 600.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static int ScreenBacklightTime
        {
            get
            {
                int backlightTime;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.ScreenBacklightTime, out backlightTime);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get ScreenBacklightTime system setting.");
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
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <feature>http://tizen.org/feature/systemsetting.incoming_call</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string SoundNotification
        {
            get
            {
                string filePath;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.SoundNotification, out filePath);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get SoundNotification system setting.");
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
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static int SoundNotificationRepetitionPeriod
        {
            get
            {
                int notificationRepetitionPeriod;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.SoundNotificationRepetitionPeriod, out notificationRepetitionPeriod);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get SoundNotificationRepetitionPeriod system setting.");
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
        /// Indicates the current lock state.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static SystemSettingsIdleLockState LockState
        {
            get
            {
                int LockState;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.LockState, out LockState);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get LockState system setting.");
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

        /// <summary>
        /// The current system ADS ID.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string AdsId
        {
            get
            {
                string adsId;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueString(SystemSettingsKeys.AdsId, out adsId);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get AdsId system setting.");
                }
                return adsId;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueString(SystemSettingsKeys.AdsId, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set AdsId system setting.");
                }
            }
        }


        /// <summary>
        /// Indicates the time period for notification repetitions.
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
        public static SystemSettingsUdsState UltraDataSave
        {
            get
            {
                int UltraDataSave;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueInt(SystemSettingsKeys.UltraDataSave, out UltraDataSave);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get UltraDataSave system setting.");
                }
                return (SystemSettingsUdsState)UltraDataSave;
            }
        }

        /// <summary>
        /// Indicates whether the accessibility TTS is enabled on the device.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static bool AccessibilityTtsEnabled
        {
            get
            {
                bool isAccessibilityTTSEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.AccessibilityTtsEnabled, out isAccessibilityTTSEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get AccessibilityTTS system setting value.");
                }
                return isAccessibilityTTSEnabled;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.AccessibilityTtsEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set AccessibilityTTS system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the vibration is enabled on the device or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static bool Vibration
        {
            get
            {
                bool isVibration;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.Vibration, out isVibration);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isVibration system setting.");
                }
                return isVibration;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.Vibration, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isVibration system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the automatic time update is enabled on the device or not.
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
        public static bool AutomaticTimeUpdate
        {
            get
            {
                bool isAutomaticTimeUpdate;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.AutomaticTimeUpdate, out isAutomaticTimeUpdate);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isAutomaticTimeUpdate system setting.");
                }
                return isAutomaticTimeUpdate;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.AutomaticTimeUpdate, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isAutomaticTimeUpdate system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether the developer option state is enabled on the device or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static bool DeveloperOptionState
        {
            get
            {
                bool isDeveloperOptionState;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.DeveloperOptionState, out isDeveloperOptionState);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isDeveloperOptionState system setting.");
                }
                return isDeveloperOptionState;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.DeveloperOptionState, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isDeveloperOptionState system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether accessibility grayscale is enabled on the device or not.
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
        public static bool AccessibilityGrayscale
        {
            get
            {
                bool isAccessibilityGrayscale;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.AccessibilityGrayscale, out isAccessibilityGrayscale);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isAccessibilityGrayscale system setting.");
                }
                return isAccessibilityGrayscale;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.AccessibilityGrayscale, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isAccessibilityGrayscale system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether accessibility negative color is enabled on the device or not.
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
        public static bool AccessibilityNegativeColor
        {
            get
            {
                bool isAccessibilityNegativeColor;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.AccessibilityNegativeColor, out isAccessibilityNegativeColor);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isAccessibilityNegativeColor system setting.");
                }
                return isAccessibilityNegativeColor;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.AccessibilityNegativeColor, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isAccessibilityNegativeColor system setting.");
                }
            }
        }

        /// <summary>
        /// Indicates whether rotary event is enabled on the device.
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
        public static bool RotaryEventEnabled
        {
            get
            {
                bool isRotaryEventEnabled;
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsGetValueBool(SystemSettingsKeys.RotaryEventEnabled, out isRotaryEventEnabled);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to get isRotaryEventEnabled system setting.");
                }
                return isRotaryEventEnabled;
            }
            set
            {
                SystemSettingsError res = (SystemSettingsError)Interop.Settings.SystemSettingsSetValueBool(SystemSettingsKeys.RotaryEventEnabled, value);
                if (res != SystemSettingsError.None)
                {
                    throw SystemSettingsExceptionFactory.CreateException(res, "unable to set isRotaryEventEnabled system setting.");
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
        /// The IncomingCallRingtoneChanged event is triggered when the file path of the incoming ringtone is changed.
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
        public static event EventHandler<IncomingCallRingtoneChangedEventArgs> IncomingCallRingtoneChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_incomingCallRingtoneChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_incomingCallRingtoneChanged -= value;
                    if (s_incomingCallRingtoneChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.IncomingCallRingtone, s_incomingCallRingtoneChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// THe WallpaperHomeScreenChanged event is triggered when the file path of the current home screen wallpaper is changed.
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
        public static event EventHandler<WallpaperHomeScreenChangedEventArgs> WallpaperHomeScreenChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_wallpaperHomeScreenChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_wallpaperHomeScreenChanged -= value;
                    if (s_wallpaperHomeScreenChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.WallpaperHomeScreen, s_wallpaperHomeScreenChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The WallpaperLockScreenChanged event is triggered when the file path of the current lock screen wallpaper is changed.
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
        public static event EventHandler<WallpaperLockScreenChangedEventArgs> WallpaperLockScreenChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_wallpaperLockScreenChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_wallpaperLockScreenChanged -= value;
                    if (s_wallpaperLockScreenChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.WallpaperLockScreen, s_wallpaperLockScreenChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The FontSizeChanged event is triggered when the current system font size is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<FontSizeChangedEventArgs> FontSizeChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_fontSizeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_fontSizeChanged -= value;
                    if (s_fontSizeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.FontSize, s_fontSizeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The FontTypeChanged event is triggered when the current system font type is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<FontTypeChangedEventArgs> FontTypeChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_fontTypeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_fontTypeChanged -= value;
                    if (s_fontTypeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.FontType, s_fontTypeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_motionActivationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool motionActivation = SystemSettings.MotionActivationEnabled;
            MotionActivationSettingChangedEventArgs eventArgs = new MotionActivationSettingChangedEventArgs(motionActivation);
            s_motionActivationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<MotionActivationSettingChangedEventArgs> s_motionActivationChanged;
        /// <summary>
        /// The MotionActivationChanged event is triggered when the motion service status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<MotionActivationSettingChangedEventArgs> MotionActivationSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_motionActivationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.MotionActivationEnabled, s_motionActivationChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_motionActivationChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_motionActivationChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_motionActivationChanged -= value;
                    if (s_motionActivationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.MotionActivationEnabled, s_motionActivationChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The EmailAlertRingtoneChanged event is triggered when the file path of the current email alert ringtone is changed.
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
        public static event EventHandler<EmailAlertRingtoneChangedEventArgs> EmailAlertRingtoneChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_emailAlertRingtoneChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_emailAlertRingtoneChanged -= value;
                    if (s_emailAlertRingtoneChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.EmailAlertRingtone, s_emailAlertRingtoneChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The UsbDebuggingSettingChangedEventArgs event is triggered when the USB debugging status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<UsbDebuggingSettingChangedEventArgs> UsbDebuggingSettingChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_usbDebuggingSettingChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_usbDebuggingSettingChanged -= value;
                    if (s_usbDebuggingSettingChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.UsbDebuggingEnabled, s_usbDebuggingSettingChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The Data3GNetworkSettingChanged event is triggered when the 3G data network status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<Data3GNetworkSettingChangedEventArgs> Data3GNetworkSettingChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_data3GNetworkSettingChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_data3GNetworkSettingChanged -= value;
                    if (s_data3GNetworkSettingChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.Data3GNetworkEnabled, s_data3GNetworkSettingChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_lockscreenAppChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string lockScreenApp = SystemSettings.LockScreenApp;
            LockScreenAppChangedEventArgs eventArgs = new LockScreenAppChangedEventArgs(lockScreenApp);
            s_lockscreenAppChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LockScreenAppChangedEventArgs> s_lockscreenAppChanged;
        /// <summary>
        /// The LockScreenAppChanged event is triggered when the lockscreen application package name is changed.
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
        public static event EventHandler<LockScreenAppChangedEventArgs> LockScreenAppChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_lockscreenAppChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LockScreenApp, s_lockscreenAppChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_lockscreenAppChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_lockscreenAppChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }

                    s_lockscreenAppChanged -= value;
                    if (s_lockscreenAppChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LockScreenApp, s_lockscreenAppChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The LocaleCountryChanged event is triggered when the current country setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax, is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<LocaleCountryChangedEventArgs> LocaleCountryChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_localeCountryChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_localeCountryChanged -= value;
                    if (s_localeCountryChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleCountry, s_localeCountryChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The LocaleLanguageChanged event is triggered when the current language setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax, is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<LocaleLanguageChangedEventArgs> LocaleLanguageChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (null == value)
                        throw SystemSettingsExceptionFactory.CreateException(SystemSettingsError.InvalidParameter, "Error invalid callback");

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
            }

            remove
            {
                lock (LockObj)
                {
                    if (null == value)
                        throw SystemSettingsExceptionFactory.CreateException(SystemSettingsError.InvalidParameter, "Error invalid callback");

                    if (s_localeLanguageChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_localeLanguageChanged -= value;
                    if (s_localeLanguageChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleLanguage, s_localeLanguageChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeTimeFormat24HourChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool localeTimeFormat24Hour = SystemSettings.LocaleTimeFormat24HourEnabled;
            LocaleTimeFormat24HourSettingChangedEventArgs eventArgs = new LocaleTimeFormat24HourSettingChangedEventArgs(localeTimeFormat24Hour);
            s_localeTimeFormat24HourChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleTimeFormat24HourSettingChangedEventArgs> s_localeTimeFormat24HourChanged;
        /// <summary>
        /// The LocaleTimeFormat24HourChanged event is triggered when the time format is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<LocaleTimeFormat24HourSettingChangedEventArgs> LocaleTimeFormat24HourSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_localeTimeFormat24HourChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleTimeFormat24HourEnabled, s_localeTimeFormat24HourChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_localeTimeFormat24HourChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_localeTimeFormat24HourChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_localeTimeFormat24HourChanged -= value;
                    if (s_localeTimeFormat24HourChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleTimeFormat24HourEnabled, s_localeTimeFormat24HourChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_localeTimeZoneChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string localeTimeZone = SystemSettings.LocaleTimeZone;
            LocaleTimeZoneChangedEventArgs eventArgs = new LocaleTimeZoneChangedEventArgs(localeTimeZone);
            s_localeTimeZoneChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<LocaleTimeZoneChangedEventArgs> s_localeTimeZoneChanged;
        /// <summary>
        /// The LocaleTimeZoneChanged event is triggered when the current time zone is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<LocaleTimeZoneChangedEventArgs> LocaleTimeZoneChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_localeTimeZoneChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.LocaleTimeZone, s_localeTimeZoneChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_localeTimeZoneChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_localeTimeZoneChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_localeTimeZoneChanged -= value;
                    if (s_localeTimeZoneChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LocaleTimeZone, s_localeTimeZoneChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_timeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {

            int time = SystemSettings.Time;
            TimeChangedEventArgs eventArgs = new TimeChangedEventArgs(time);
            s_timeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<TimeChangedEventArgs> s_timeChanged;
        /// <summary>
        /// The TimeChanged event is triggered when the system time is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<TimeChangedEventArgs> TimeChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_timeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_timeChanged -= value;
                    if (s_timeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.Time, s_timeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundLockChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundLock = SystemSettings.SoundLockEnabled;
            SoundLockSettingChangedEventArgs eventArgs = new SoundLockSettingChangedEventArgs(soundLock);
            s_soundLockChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundLockSettingChangedEventArgs> s_soundLockChanged;
        /// <summary>
        /// The SoundLockChanged event is triggered when the screen lock sound enabled status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<SoundLockSettingChangedEventArgs> SoundLockSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_soundLockChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundLockEnabled, s_soundLockChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_soundLockChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_soundLockChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_soundLockChanged -= value;
                    if (s_soundLockChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundLockEnabled, s_soundLockChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundSilentModeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundSilentMode = SystemSettings.SoundSilentModeEnabled;
            SoundSilentModeSettingChangedEventArgs eventArgs = new SoundSilentModeSettingChangedEventArgs(soundSilentMode);
            s_soundSilentModeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundSilentModeSettingChangedEventArgs> s_soundSilentModeChanged;
        /// <summary>
        /// The SoundSilentModeChanged event is triggered when the silent mode status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<SoundSilentModeSettingChangedEventArgs> SoundSilentModeSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_soundSilentModeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundSilentModeEnabled, s_soundSilentModeChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_soundSilentModeChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_soundSilentModeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_soundSilentModeChanged -= value;
                    if (s_soundSilentModeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundSilentModeEnabled, s_soundSilentModeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_soundTouchChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool soundTouch = SystemSettings.SoundTouchEnabled;
            SoundTouchSettingChangedEventArgs eventArgs = new SoundTouchSettingChangedEventArgs(soundTouch);
            s_soundTouchChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<SoundTouchSettingChangedEventArgs> s_soundTouchChanged;
        /// <summary>
        /// THe SoundTouchChanged event is triggered when the screen touch sound enabled status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<SoundTouchSettingChangedEventArgs> SoundTouchSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_soundTouchChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.SoundTouchEnabled, s_soundTouchChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_soundTouchChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_soundTouchChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_soundTouchChanged -= value;
                    if (s_soundTouchChanged == null)

                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundTouchEnabled, s_soundTouchChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_displayScreenRotationAutoChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool displayScreenRotationAuto = SystemSettings.DisplayScreenRotationAutoEnabled;
            DisplayScreenRotationAutoSettingChangedEventArgs eventArgs = new DisplayScreenRotationAutoSettingChangedEventArgs(displayScreenRotationAuto);
            s_displayScreenRotationAutoChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<DisplayScreenRotationAutoSettingChangedEventArgs> s_displayScreenRotationAutoChanged;
        /// <summary>
        /// The DisplayScreenRotationAutoChanged event is triggered when the automatic rotation control status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<DisplayScreenRotationAutoSettingChangedEventArgs> DisplayScreenRotationAutoSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_displayScreenRotationAutoChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.DisplayScreenRotationAutoEnabled, s_displayScreenRotationAutoChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_displayScreenRotationAutoChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_displayScreenRotationAutoChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_displayScreenRotationAutoChanged -= value;
                    if (s_displayScreenRotationAutoChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DisplayScreenRotationAutoEnabled, s_displayScreenRotationAutoChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The DeviceNameChanged event is triggered when the device name is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<DeviceNameChangedEventArgs> DeviceNameChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_deviceNameChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_deviceNameChanged -= value;
                    if (s_deviceNameChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DeviceName, s_deviceNameChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The MotionSettingChanged event is triggered when the motion feature enabled status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<MotionSettingChangedEventArgs> MotionSettingChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_motionSettingChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_motionSettingChanged -= value;
                    if (s_motionSettingChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.MotionEnabled, s_motionSettingChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_networkWifiNotificationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool networkWifiNotification = SystemSettings.NetworkWifiNotificationEnabled;
            NetworkWifiNotificationSettingChangedEventArgs eventArgs = new NetworkWifiNotificationSettingChangedEventArgs(networkWifiNotification);
            s_networkWifiNotificationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<NetworkWifiNotificationSettingChangedEventArgs> s_networkWifiNotificationChanged;
        /// <summary>
        /// The NetworkWifiNotificationChanged event is triggered when the WiFi-related notifications enabled status is changed.
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
        public static event EventHandler<NetworkWifiNotificationSettingChangedEventArgs> NetworkWifiNotificationSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_networkWifiNotificationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.NetworkWifiNotificationEnabled, s_networkWifiNotificationChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_networkWifiNotificationChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_networkWifiNotificationChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_networkWifiNotificationChanged -= value;
                    if (s_networkWifiNotificationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.NetworkWifiNotificationEnabled, s_networkWifiNotificationChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_networkFlightModeChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool networkFlightMode = SystemSettings.NetworkFlightModeEnabled;
            NetworkFlightModeSettingChangedEventArgs eventArgs = new NetworkFlightModeSettingChangedEventArgs(networkFlightMode);
            s_networkFlightModeChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<NetworkFlightModeSettingChangedEventArgs> s_networkFlightModeChanged;
        /// <summary>
        /// The NetworkFlightModeChanged event is triggered when the flight mode status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<NetworkFlightModeSettingChangedEventArgs> NetworkFlightModeSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_networkFlightModeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.NetworkFlightModeEnabled, s_networkFlightModeChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_networkFlightModeChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_networkFlightModeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_networkFlightModeChanged -= value;
                    if (s_networkFlightModeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.NetworkFlightModeEnabled, s_networkFlightModeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// THe ScreenBacklightTimeChanged event is triggered when the backlight time is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<ScreenBacklightTimeChangedEventArgs> ScreenBacklightTimeChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_screenBacklightTimeChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_screenBacklightTimeChanged -= value;
                    if (s_screenBacklightTimeChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.ScreenBacklightTime, s_screenBacklightTimeChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The SoundNotificationChanged event is triggered when the file path of the current notification tone set by the user is changed.
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
        public static event EventHandler<SoundNotificationChangedEventArgs> SoundNotificationChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_soundNotificationChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_soundNotificationChanged -= value;
                    if (s_soundNotificationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundNotification, s_soundNotificationChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The SoundNotificationRepetitionPeriodChanged event is triggered when the time period for notification repetitions is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<SoundNotificationRepetitionPeriodChangedEventArgs> SoundNotificationRepetitionPeriodChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_soundNotificationRepetitionPeriodChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_soundNotificationRepetitionPeriodChanged -= value;
                    if (s_soundNotificationRepetitionPeriodChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.SoundNotificationRepetitionPeriod, s_soundNotificationRepetitionPeriodChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
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
        /// The LockStateChanged event is triggered when the current lock state is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<LockStateChangedEventArgs> LockStateChanged
        {
            add
            {
                lock (LockObj)
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
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_lockStateChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_lockStateChanged -= value;
                    if (s_lockStateChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.LockState, s_lockStateChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_adsIdChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string adsId = SystemSettings.AdsId;
            AdsIdChangedEventArgs eventArgs = new AdsIdChangedEventArgs(adsId);
            s_adsIdChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<AdsIdChangedEventArgs> s_adsIdChanged;
        /// <summary>
        /// The AdsIdChanged event is triggered when the current ADS ID state is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<AdsIdChangedEventArgs> AdsIdChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_adsIdChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.AdsId, s_adsIdChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_adsIdChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_adsIdChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_adsIdChanged -= value;
                    if (s_adsIdChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.AdsId, s_adsIdChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_ultraDataSaveChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            SystemSettingsUdsState ultraDataSave = SystemSettings.UltraDataSave;
            UltraDataSaveChangedEventArgs eventArgs = new UltraDataSaveChangedEventArgs(ultraDataSave);
            s_ultraDataSaveChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<UltraDataSaveChangedEventArgs> s_ultraDataSaveChanged;
        /// <summary>
        /// The UltraDataSaveChanged event is triggered when the current Ultra Data Save state is changed.
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
        public static event EventHandler<UltraDataSaveChangedEventArgs> UltraDataSaveChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_ultraDataSaveChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.UltraDataSave, s_ultraDataSaveChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_ultraDataSaveChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_ultraDataSaveChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_ultraDataSaveChanged -= value;
                    if (s_ultraDataSaveChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.UltraDataSave, s_ultraDataSaveChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_ultraDataSavePackageListChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            string ultraDataSavePackageList = "None";
            UltraDataSavePackageListChangedEventArgs eventArgs = new UltraDataSavePackageListChangedEventArgs(ultraDataSavePackageList);
            s_ultraDataSavePackageListChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<UltraDataSavePackageListChangedEventArgs> s_ultraDataSavePackageListChanged;
        /// <summary>
        /// The UltraDataSavePackageListChanged event is triggered when the current ADS ID state is changed.
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
        public static event EventHandler<UltraDataSavePackageListChangedEventArgs> UltraDataSavePackageListChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_ultraDataSavePackageListChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.UltraDataSavePackageList, s_ultraDataSavePackageListChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_ultraDataSavePackageListChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_ultraDataSavePackageListChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_ultraDataSavePackageListChanged -= value;
                    if (s_ultraDataSavePackageListChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.UltraDataSavePackageList, s_ultraDataSavePackageListChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_accessibilityTtsChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool accessibilityTts = SystemSettings.AccessibilityTtsEnabled;
            AccessibilityTtsSettingChangedEventArgs eventArgs = new AccessibilityTtsSettingChangedEventArgs(accessibilityTts);
            s_accessibilityTtsChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<AccessibilityTtsSettingChangedEventArgs> s_accessibilityTtsChanged;
        /// <summary>
        /// THe AccessibilityTtsChanged event is triggered when the screen touch sound enabled status is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<AccessibilityTtsSettingChangedEventArgs> AccessibilityTtsSettingChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_accessibilityTtsChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.AccessibilityTtsEnabled, s_accessibilityTtsChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_accessibilityTtsChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    if (s_accessibilityTtsChanged == null) {
                        Tizen.Log.Info("Tizen.System.SystemSettings","There is no event handler");
                        return;
                    }
                    s_accessibilityTtsChanged -= value;
                    if (s_accessibilityTtsChanged == null)

                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.AccessibilityTtsEnabled, s_accessibilityTtsChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_vibrationChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool vibration = SystemSettings.Vibration;
            VibrationChangedEventArgs eventArgs = new VibrationChangedEventArgs(vibration);
            s_vibrationChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<VibrationChangedEventArgs> s_vibrationChanged;
        /// <summary>
        /// The VibrationChanged event is triggered when the vibration value is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<VibrationChangedEventArgs> VibrationChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_vibrationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.Vibration, s_vibrationChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_vibrationChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_vibrationChanged -= value;
                    if (s_vibrationChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.Vibration, s_vibrationChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_automaticTimeUpdateChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool automaticTimeUpdate = SystemSettings.AutomaticTimeUpdate;
            AutomaticTimeUpdateChangedEventArgs eventArgs = new AutomaticTimeUpdateChangedEventArgs(automaticTimeUpdate);
            s_automaticTimeUpdateChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<AutomaticTimeUpdateChangedEventArgs> s_automaticTimeUpdateChanged;
        /// <summary>
        /// The AutomaticTimeUpdateChanged event is triggered when the AutomaticTimeUpdate value is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<AutomaticTimeUpdateChangedEventArgs> AutomaticTimeUpdateChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_automaticTimeUpdateChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.AutomaticTimeUpdate, s_automaticTimeUpdateChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_automaticTimeUpdateChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_automaticTimeUpdateChanged -= value;
                    if (s_automaticTimeUpdateChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.AutomaticTimeUpdate, s_automaticTimeUpdateChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_developerOptionStateChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool developerOptionState = SystemSettings.DeveloperOptionState;
            DeveloperOptionStateChangedEventArgs eventArgs = new DeveloperOptionStateChangedEventArgs(developerOptionState);
            s_developerOptionStateChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<DeveloperOptionStateChangedEventArgs> s_developerOptionStateChanged;
        /// <summary>
        /// The DeveloperOptionStateChanged event is triggered when the DeveloperOptionState value is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/systemsettings.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/systemsetting</feature>
        /// <exception cref="ArgumentException">Invalid Argument</exception>
        /// <exception cref="NotSupportedException">Not Supported feature</exception>
        /// <exception cref="InvalidOperationException">Invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<DeveloperOptionStateChangedEventArgs> DeveloperOptionStateChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_developerOptionStateChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.DeveloperOptionState, s_developerOptionStateChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_developerOptionStateChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_developerOptionStateChanged -= value;
                    if (s_developerOptionStateChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.DeveloperOptionState, s_developerOptionStateChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_accessibilityGrayscaleChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool accessibilityGrayscale = SystemSettings.AccessibilityGrayscale;
            AccessibilityGrayscaleChangedEventArgs eventArgs = new AccessibilityGrayscaleChangedEventArgs(accessibilityGrayscale);
            s_accessibilityGrayscaleChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<AccessibilityGrayscaleChangedEventArgs> s_accessibilityGrayscaleChanged;
        /// <summary>
        /// The AccessibilityGrayscaleChanged event is triggered when the AccessibilityGrayscale value is changed.
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
        public static event EventHandler<AccessibilityGrayscaleChangedEventArgs> AccessibilityGrayscaleChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_accessibilityGrayscaleChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.AccessibilityGrayscale, s_accessibilityGrayscaleChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_accessibilityGrayscaleChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_accessibilityGrayscaleChanged -= value;
                    if (s_accessibilityGrayscaleChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.AccessibilityGrayscale, s_accessibilityGrayscaleChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_accessibilityNegativeColorChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool accessibilityNegativeColor = SystemSettings.AccessibilityNegativeColor;
            AccessibilityNegativeColorChangedEventArgs eventArgs = new AccessibilityNegativeColorChangedEventArgs(accessibilityNegativeColor);
            s_accessibilityNegativeColorChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<AccessibilityNegativeColorChangedEventArgs> s_accessibilityNegativeColorChanged;
        /// <summary>
        /// The AccessibilityNegativeColorChanged event is triggered when the AccessibilityNegativeColor value is changed.
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
        public static event EventHandler<AccessibilityNegativeColorChangedEventArgs> AccessibilityNegativeColorChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_accessibilityNegativeColorChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.AccessibilityNegativeColor, s_accessibilityNegativeColorChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_accessibilityNegativeColorChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_accessibilityNegativeColorChanged -= value;
                    if (s_accessibilityNegativeColorChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.AccessibilityNegativeColor, s_accessibilityNegativeColorChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }

        private static readonly Interop.Settings.SystemSettingsChangedCallback s_rotaryEventEnabledChangedCallback = (SystemSettingsKeys key, IntPtr userData) =>
        {
            bool rotaryEventEnabled = SystemSettings.RotaryEventEnabled;
            RotaryEventEnabledChangedEventArgs eventArgs = new RotaryEventEnabledChangedEventArgs(rotaryEventEnabled);
            s_rotaryEventEnabledChanged?.Invoke(null, eventArgs);
        };
        private static event EventHandler<RotaryEventEnabledChangedEventArgs> s_rotaryEventEnabledChanged;
        /// <summary>
        /// The RotaryEventEnabledChanged event is triggered when the RotaryEventEnabled value is changed.
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
        public static event EventHandler<RotaryEventEnabledChangedEventArgs> RotaryEventEnabledChanged
        {
            add
            {
                lock (LockObj)
                {
                    if (s_rotaryEventEnabledChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsSetCallback(SystemSettingsKeys.RotaryEventEnabled, s_rotaryEventEnabledChangedCallback, IntPtr.Zero);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                    s_rotaryEventEnabledChanged += value;
                }
            }

            remove
            {
                lock (LockObj)
                {
                    s_rotaryEventEnabledChanged -= value;
                    if (s_rotaryEventEnabledChanged == null)
                    {
                        SystemSettingsError ret = (SystemSettingsError)Interop.Settings.SystemSettingsRemoveCallback(SystemSettingsKeys.RotaryEventEnabled, s_rotaryEventEnabledChangedCallback);
                        if (ret != SystemSettingsError.None)
                        {
                            throw SystemSettingsExceptionFactory.CreateException(ret, "Error in callback handling");
                        }
                    }
                }
            }
        }
    }
}

