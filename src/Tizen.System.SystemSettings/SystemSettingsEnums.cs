
namespace Tizen.System.SystemSettings
{
    /// <summary>
    /// Enumeration for all available system settings
    /// </summary>
    public enum SystemSettingsKeys
    {
        /// <summary>
        /// (string) The file path of the current ringtone
        /// </summary>
        IncomingCallRingtone,
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
        MotionActivation,
        /// <summary>
        /// (string) The file path of the current email alert ringtone
        /// </summary>
        EmailAlertRingtone,
        /// <summary>
        /// (bool) Indicates whether the USB debugging is enabled (Since 2.4)
        /// </summary>
        UsbDebuggingEnabled,
        /// <summary>
        /// (bool) Indicates whether the 3G data network is enabled (Since 2.4)
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
        /// (string) Indicates the current country setting in the <LANGUAGE>_<REGION> syntax.
        /// The country setting is in the ISO 639-2 format,
        /// and the region setting is in the ISO 3166-1 alpha-2 format
        /// </summary>
        LocaleCountry,
        /// <summary>
        /// (string) Indicates the current language setting in the <LANGUAGE>_<REGION> syntax.
        /// The language setting is in the ISO 639-2 format
        /// and the region setting is in the ISO 3166-1 alpha-2 format.
        /// </summary>
        LocaleLanguage,
        /// <summary>
        /// (bool) Indicates whether the 24-hour clock is used.
        /// If the value is false, the 12-hour clock is used.
        /// </summary>
        LocaleTimeformat24Hour,
        /// <summary>
        /// (string) Indicates the current time zone.
        /// </summary>
        LocaleTimezone,
        /// <summary>
        /// (int) Once System changes time, this event occurs to notify time change.
        /// </summary>
        Time,
        /// <summary>
        /// GET (bool) Indicates whether the screen lock sound is enabled on the device. ex) LCD on/off sound
        /// </summary>
        SoundLock,
        /// <summary>
        /// GET (bool) Indicates whether the device is in the silent mode.
        /// </summary>
        SoundSilentMode,
        /// <summary>
        /// GET (bool) Indicates whether the screen touch sound is enabled on the device.
        /// </summary>
        SoundTouch,
        /// <summary>
        /// GET (bool) Indicates whether rotation control is automatic.
        /// </summary>
        DisplayScreenRotationAuto,
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
        NetworkWifiNotification,
        /// <summary>
        /// GET (bool) Indicates whether the device is in the flight mode.
        /// </summary>
        NetworkFlightMode,
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
        LockState
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
}
