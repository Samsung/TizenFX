namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for audio device options.
    /// </summary>
    public enum AudioDeviceOptions
    {
        /// <summary>
        /// Mask for input devices
        /// </summary>
        Input = 0x0001,
        /// <summary>
        /// Mask for output devices
        /// </summary>
        Output = 0x0002,
        /// <summary>
        /// Mask for input/output devices (both directions are available)
        /// </summary>
        InputAndOutput = 0x0004,
        /// <summary>
        /// Mask for built-in devices
        /// </summary>
        Internal = 0x00010,
        /// <summary>
        /// Mask for external devices
        /// </summary>
        External = 0x0020,
        /// <summary>
        /// Mask for deactivated devices
        /// </summary>
        Deactivated = 0x1000,
        /// <summary>
        /// Mask for activated devices
        /// </summary>
        Activated = 0x2000,
        /// <summary>
        /// Mask for all devices
        /// </summary>
        All = 0xFFFF
    }

    /// <summary>
    /// Enumeration for audio device type.
    /// </summary>
    public enum AudioDeviceType
    {
        /// <summary>
        /// Built-in speaker
        /// </summary>
        BuiltinSpeaker,
        /// <summary>
        /// Built-in receiver
        /// </summary>
        BuiltinReceiver,
        /// <summary>
        /// Built-in mic
        /// </summary>
        BuiltinMic,
        /// <summary>
        /// Audio jack that can be connected to wired accessory such as headphones and headsets
        /// </summary>
        AudioJack,
        /// <summary>
        /// Bluetooth
        /// </summary>
        Bluetooth,
        /// <summary>
        /// HDMI
        /// </summary>
        Hdmi,
        /// <summary>
        /// Device for forwarding
        /// </summary>
        Forwarding,
        /// <summary>
        /// USB Audio
        /// </summary>
        UsbAudio
    }

    /// <summary>
    /// Enumeration for audio device direction.
    /// </summary>
    public enum AudioDeviceIoDirection
    {
        /// <summary>
        /// Input device
        /// </summary>
        Input,
        /// <summary>
        /// Output device
        /// </summary>
        Output,
        /// <summary>
        /// Input/output device (both directions are available)
        /// </summary>
        InputAndOutput
    }

    /// <summary>
    /// Enumeration for audio device state.
    /// </summary>
    public enum AudioDeviceState
    {
        /// <summary>
        /// Deactivated state
        /// </summary>
        Deactivated,
        /// <summary>
        /// Activated state
        /// </summary>
        Activated
    }

    /// <summary>
    /// Enumeration for changed property of audio device.
    /// </summary>
    public enum AudioDeviceProperty
    {
        /// <summary>
        /// State of the device was changed
        /// </summary>
        State,
        /// <summary>
        /// IO direction of the device was changed
        /// </summary>
        IoDirection
    }

    /// <summary>
    /// Enumeration for audio type.
    /// </summary>
    public enum AudioVolumeType
    {
        /// <summary>
        /// Audio type for system
        /// </summary>
        System,
        /// <summary>
        /// Audio type for notifications
        /// </summary>
        Notification,
        /// <summary>
        /// Audio type for alarm
        /// </summary>
        Alarm,
        /// <summary>
        /// Audio type for ringtones
        /// </summary>
        Ringtone,
        /// <summary>
        /// Audio type for media
        /// </summary>
        Media,
        Call,
        /// <summary>
        /// Audio type for voip
        /// </summary>
        Voip,
        /// <summary>
        /// Audio type for voice
        /// </summary>
        Voice
    }

    /// <summary>
    /// Enumeration for audio stream type.
    /// </summary>
    public enum AudioStreamType
    {
        /// <summary>
        /// Audio stream type for media
        /// </summary>
        Media,
        /// <summary>
        /// Audio stream type for system
        /// </summary>
        System,
        /// <summary>
        /// Audio stream type for alarm
        /// </summary>
        Alarm,
        /// <summary>
        /// Audio stream type for notification
        /// </summary>
        Notification,
        /// <summary>
        /// Audio stream type for emergency
        /// </summary>
        Emergency,
        /// <summary>
        /// Audio stream type for voice information
        /// </summary>
        VoiceInformation,
        /// <summary>
        /// Audio stream type for voice recognition
        /// </summary>
        VoiceRecognition,
        /// <summary>
        /// Audio stream type for ringtone for VoIP
        /// </summary>
        RingtoneVoip,
        /// <summary>
        /// Audio stream type for VoIP
        /// </summary>
        Voip,
        /// <summary>
        /// Audio stream type for media only for external devices
        /// </summary>
        MediaExternalOnly
    }

    /// <summary>
    /// Enumeration for change reason of audio stream focus state.
    /// </summary>
    public enum AudioStreamFocusChangedReason
    {
        /// <summary>
        /// Changed by the stream type for media
        /// </summary>
        Media,
        /// <summary>
        /// Changed by the stream type for system
        /// </summary>
        System,
        /// <summary>
        /// Changed by the stream type for alarm
        /// </summary>
        Alarm,
        /// <summary>
        /// Changed by the stream type for notification
        /// </summary>
        Notification,
        /// <summary>
        /// Changed by the stream type for emergency
        /// </summary>
        Emergency,
        /// <summary>
        /// Changed by the stream type for voice information
        /// </summary>
        VoiceInformation,
        /// <summary>
        /// Changed by the stream type for voice recognition
        /// </summary>
        VoiceRecognition,
        /// <summary>
        /// Changed by the stream type for ringtone
        /// </summary>
        RingtoneVoip,
        /// <summary>
        /// Changed by the stream type for VoIP
        /// </summary>
        Voip,
        /// <summary>
        /// Changed by the stream type for voice-call or video-call
        /// </summary>
        Call,
        /// <summary>
        /// Changed by the stream type for media only for external devices
        /// </summary>
        MediaExternalOnly
    }

    /// <summary>
    /// Enumeration for audio stream focus options.
    /// </summary>
    public enum AudioStreamFocusOptions
    {
        /// <summary>
        /// Mask for playback focus
        /// </summary>
        Playback = 0x0001,
        /// <summary>
        /// Mask for recording focus
        /// </summary>
        Recording = 0x0002
    }

    /// <summary>
    /// Enumeration for audio stream focus state.
    /// </summary>
    public enum AudioStreamFocusState
    {
        /// <summary>
        /// Focus state for release
        /// </summary>
        Released,
        /// <summary>
        ///Focus state for acquisition
        /// </summary>
        Acquired
    }
}