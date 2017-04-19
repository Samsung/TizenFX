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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for all available system settings
    /// </summary>
    public enum SystemSettingsKeys : int
    {
        /// <summary>
        /// (string) The file path of the current ringtone
        /// </summary>
        IncomingCallRingtone = 0,
        /// <summary>
        /// (string) The file path of the current home screen wallpaper
        /// </summary>
        WallpaperHomeScreen,
        /// <summary>
        /// (string) The file path of the current lock screen wallpaper
        /// </summary>
        WallpaperLockScreen,
        /// <summary>
        /// (int) The current system font size
        /// </summary>
        FontSize,
        /// <summary>
        /// (string) The current system font type
        /// </summary>
        FontType,
        /// <summary>
        /// (bool) Indicates whether the motion service is activated
        /// </summary>
        MotionActivationEnabled,
        /// <summary>
        /// (string) The file path of the current email alert ringtone
        /// </summary>
        EmailAlertRingtone,
        /// <summary>
        /// (bool) Indicates whether the USB debugging is enabled
        /// </summary>
        UsbDebuggingEnabled,
        /// <summary>
        /// (bool) Indicates whether the 3G data network is enabled
        /// </summary>
        Data3GNetworkEnabled,
        /// <summary>
        /// (string) Indicates lockscreen app pkg name
        /// </summary>
        LockscreenApp = Data3GNetworkEnabled + 2,
        /// <summary>
        /// (string) The current system default font type (only support Get)
        /// </summary>
        DefaultFontType,
        /// <summary>
        /// (string) Indicates the current country setting in the \<LANGUAGE\>_\<REGION\> syntax.
        /// The country setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format
        /// </summary>
        LocaleCountry,
        /// <summary>
        /// (string) Indicates the current language setting in the \<LANGUAGE\>_\<REGION\> syntax.
        /// The language setting is in the ISO 639-2 format
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        LocaleLanguage,
        /// <summary>
        /// (bool) Indicates whether the 24-hour clock is used.
        /// If the value is false, the 12-hour clock is used.
        /// </summary>
        LocaleTimeFormat24HourEnabled,
        /// <summary>
        /// (string) Indicates the current time zone. Eg. Pacific/Tahiti
        /// </summary>
        LocaleTimeZone,
        /// <summary>
        /// (int) Once System changes time, this event occurs to notify time change.
        /// </summary>
        Time,
        /// <summary>
        /// GET (bool) Indicates whether the screen lock sound is enabled on the device. ex) LCD on/off sound
        /// </summary>
        SoundLockEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the device is in the silent mode.
        /// </summary>
        SoundSilentModeEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        SoundTouchEnabled,
        /// <summary>
        /// GET (bool) Indicates whether rotation control is automatic.
        /// </summary>
        DisplayScreenRotationAutoEnabled,
        /// <summary>
        /// GET (string) Indicates device name.
        /// </summary>
        DeviceName,
        /// <summary>
        /// GET (bool) Indicates whether the device user has enabled motion feature.
        /// </summary>
        MotionEnabled,
        /// <summary>
        /// GET (bool) Indicates whether Wi-Fi-related notifications are enabled on the device.
        /// </summary>
        NetworkWifiNotificationEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the device is in the flight mode.
        /// </summary>
        NetworkFlightModeEnabled,
        /// <summary>
        /// (int) Indicates the backlight time (in seconds). The following values can be used: 15, 30, 60, 120, 300, and 600.
        /// </summary>
        ScreenBacklightTime,
        /// <summary>
        /// (string) Indicates the file path of the current notification tone set by the user.
        /// </summary>
        SoundNotification,
        /// <summary>
        /// (int) Indicates the time period for notification repetitions.
        /// </summary>
        SoundNotificationRepetitionPeriod,
        /// <summary>
        /// (int) Indicates the current lock state
        /// </summary>
        LockState,
        /// <summary>
        /// (string)  Indicates Ads ID for each device
        /// </summary>
        AdsId,
        /// <summary>
        /// (int) Indicates Ultra Data Save status, one of #system_settings_uds_state_e values
        /// </summary>
        UltraDataSave,
        /// <summary>
        /// (string) Indicates Ultra Data Save Package List (Since 4.0), the list is a string containing whitelisted package names separated with semicolons (;)
        /// </summary>
        UltraDataSavePackageList
    }
    /// <summary>
    /// Enumeration for Idle Lock State.
    /// </summary>
    public enum SystemSettingsIdleLockState
    {
        /// <summary>
        /// Device is unlocked
        /// </summary>
        Unlock = 0,
        /// <summary>
        /// Device is locked
        /// </summary>
        Lock,
        /// <summary>
        /// Device is being locked
        /// </summary>
        LaunchingLock
    }
    /// <summary>
    /// Enumeration for font size.
    /// </summary>
    public enum SystemSettingsFontSize
    {
        /// <summary>
        /// A small size
        /// </summary>
        Small = 0,
        /// <summary>
        /// A normal size
        /// </summary>
        Normal,
        /// <summary>
        /// A large size
        /// </summary>
        Large,
        /// <summary>
        /// A huge size
        /// </summary>
        Huge,
        /// <summary>
        /// A giant size
        /// </summary>
        Giant
    }
    /// <summary>
    /// Enumeration for ultra data save
    /// </summary>
    public enum SystemSettingsUdsState
    {
        /// <summary>
        /// UDS Off
        /// </summary>
        UdsOff = 0,
        /// <summary>
        /// UDS On
        /// </summary>
        UdsOn,
        /// <summary>
        /// UDS On and the app is whitelisted
        /// </summary>
        UdsOnWhitelisted,
    }
}
