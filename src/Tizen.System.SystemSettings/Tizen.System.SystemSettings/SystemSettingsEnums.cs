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
    /// Enumeration for all the available system settings.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SystemSettingsKeys : int
    {
        /// <summary>
        /// GET (string) The file path of the current ringtone.
        /// </summary>
        IncomingCallRingtone = 0,
        /// <summary>
        /// GET (string) The file path of the current home-screen wallpaper.
        /// </summary>
        WallpaperHomeScreen,
        /// <summary>
        /// GET (string) The file path of the current lock-screen wallpaper.
        /// </summary>
        WallpaperLockScreen,
        /// <summary>
        /// GET (int) The current system font size.
        /// </summary>
        FontSize,
        /// <summary>
        /// GET (string) The current system font type.
        /// </summary>
        FontType,
        /// <summary>
        /// GET (bool) Indicates whether the motion service is activated.
        /// </summary>
        MotionActivationEnabled,
        /// <summary>
        /// GET (string) The file path of the current email alert ringtone.
        /// </summary>
        EmailAlertRingtone,
        /// <summary>
        /// GET (bool) Indicates whether the USB debugging is enabled.
        /// </summary>
        UsbDebuggingEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the 3G-data network is enabled.
        /// </summary>
        Data3GNetworkEnabled,
        /// <summary>
        /// GET (string) Indicates the lock-screen application package name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        LockScreenApp = Data3GNetworkEnabled + 2,
        /// <summary>
        /// GET (string) The current system default font type (only supports Get).
        /// </summary>
        DefaultFontType,
        /// <summary>
        /// GET (string) Indicates the current country setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The country setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        LocaleCountry,
        /// <summary>
        /// GET (string) Indicates the current language setting in the &lt;LANGUAGE&gt;_&lt;REGION&gt; syntax.
        /// The language setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        LocaleLanguage,
        /// <summary>
        /// GET (bool) Indicates whether the 24-hour clock is used.
        /// If the value is false, the 12-hour clock is used.
        /// </summary>
        LocaleTimeFormat24HourEnabled,
        /// <summary>
        /// GET (string) Indicates the current time zone, for example, Pacific/Tahiti.
        /// </summary>
        LocaleTimeZone,
        /// <summary>
        /// GET (int) Once system changes the time, this event occurs to notify the time change.
        /// </summary>
        Time,
        /// <summary>
        /// GET (bool) Indicates whether the screen lock sound is enabled on the device, for example, the LCD on or off sound.
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
        /// GET (bool) Indicates whether the rotation control is automatic.
        /// </summary>
        DisplayScreenRotationAutoEnabled,
        /// <summary>
        /// GET (string) Indicates the device name.
        /// </summary>
        DeviceName,
        /// <summary>
        /// GET (bool) Indicates whether the device user has the enabled motion feature.
        /// </summary>
        MotionEnabled,
        /// <summary>
        /// GET (bool) Indicates whether WiFi-related notifications are enabled on the device.
        /// </summary>
        NetworkWifiNotificationEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the device is in the flight mode.
        /// </summary>
        NetworkFlightModeEnabled,
        /// <summary>
        /// GET (int) Indicates the backlight time (in seconds). The following values can be used: 15, 30, 60, 120, 300, and 600.
        /// </summary>
        ScreenBacklightTime,
        /// <summary>
        /// GET (string) Indicates the file path of the current notification tone set by the user.
        /// </summary>
        SoundNotification,
        /// <summary>
        /// GET (int) Indicates the time period for notification repetitions.
        /// </summary>
        SoundNotificationRepetitionPeriod,
        /// <summary>
        /// GET (int) Indicates the current lock state.
        /// </summary>
        LockState,
        /// <summary>
        /// GET (string) Indicates the ADS ID for each device.
        /// </summary>
        AdsId,
        /// <summary>
        /// GET (int) Indicates the Ultra Data Save status, one of the #SystemSettingsUdsState values.
        /// </summary>
        UltraDataSave,
        /// <summary>
        /// GET (string) Indicates the Ultra Data Save Package List. Since 4.0, the list is a string containing whitelisted package names separated with semicolons (;).
        /// </summary>
        UltraDataSavePackageList,
        /// <summary>
        /// GET (bool) Indicates whether the accessibility TTS is enabled on the device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        AccessibilityTtsEnabled,
        /// <summary>
        /// GET (bool) Indicates whether the Vibration is enabled on the device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Vibration,
        /// <summary>
        /// GET (bool) Indicates whether the AutomaticTimeUpdate is enabled on the device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        AutomaticTimeUpdate,
        /// <summary>
        /// GET (bool) Indicates whether the Developer Option State is enabled on the device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DeveloperOptionState,
        /// <summary>
        /// GET (bool) Indicates whether accessibility grayscale  is enabled on the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        AccessibilityGrayscale,
        /// <summary>
        /// GET (bool) Indicates whether accessibility negative color is enabled on the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        AccessibilityNegativeColor
    }
    /// <summary>
    /// Enumeration for the Idle Lock State.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SystemSettingsIdleLockState : int
    {
        /// <summary>
        /// The device is unlocked.
        /// </summary>
        Unlock = 0,
        /// <summary>
        /// The device is locked.
        /// </summary>
        Lock,
        /// <summary>
        /// The device is being locked.
        /// </summary>
        LaunchingLock
    }
    /// <summary>
    /// Enumeration for the font size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SystemSettingsFontSize : int
    {
        /// <summary>
        /// A small size.
        /// </summary>
        Small = 0,
        /// <summary>
        /// A normal size.
        /// </summary>
        Normal,
        /// <summary>
        /// A large size.
        /// </summary>
        Large,
        /// <summary>
        /// A huge size.
        /// </summary>
        Huge,
        /// <summary>
        /// A giant size.
        /// </summary>
        Giant
    }
    /// <summary>
    /// Enumeration for the ultra data save.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SystemSettingsUdsState : int
    {
        /// <summary>
        /// UDS Off.
        /// </summary>
        UdsOff = 0,
        /// <summary>
        /// UDS On.
        /// </summary>
        UdsOn,
        /// <summary>
        /// UDS On and the application is whitelisted.
        /// </summary>
        UdsOnWhitelisted,
    }
}
