using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for player state
    /// </summary>
    public enum PlayerState
    {
        /// <summary>
        /// Player is not created 
        /// </summary>
        None,

        /// <summary>
        /// Player is created, but not prepared 
        /// </summary>
        Idle,

        /// <summary>
        /// Player is ready to play media 
        /// </summary>
        Ready,

        /// <summary>
        /// Player is playing media 
        /// </summary>
        Playing,

        /// <summary>
        /// Player is paused while playing media 
        /// </summary>
        Paused,
    }

    /// <summary>
    /// Enumeration for player display type
    /// </summary>
    public enum DisplayType
    {
        /// <summary>
        /// Overlay surface display  
        /// </summary>
        Overlay,

        /// <summary>
        ///  Evas image object surface display 
        /// </summary>
        Evas,

        /// <summary>
        /// This disposes off buffers  
        /// </summary>
        None,
    }


    /// <summary>
    /// Enumeration for player audio latency mode
    /// </summary>
    public enum AudioLatencyMode
    {
        /// <summary>
        /// Low audio latency mode   
        /// </summary>
        Low,

        /// <summary>
        ///  Middle audio latency mode 
        /// </summary>
        Mid,

        /// <summary>
        /// High audio latency mode   
        /// </summary>
        High,
    }


    /// <summary>
    /// Enumeration for player display rotation
    /// </summary>
    public enum DisplayRotation
    {
        /// <summary>
        /// Display is not rotated  
        /// </summary>
        RotationNone,

        /// <summary>
        ///  Display is rotated 90 degrees 
        /// </summary>
        Rotation90,

        /// <summary>
        /// Display is rotated 180 degrees  
        /// </summary>
        Rotation180,

        /// <summary>
        /// Display is rotated 270 degrees  
        /// </summary>
        Rotation270
    }


    /// <summary>
    /// Enumeration for player display mode
    /// </summary>
    public enum DisplayMode
    {
        /// <summary>
        /// Letter box 
        /// </summary>
        LetterBox,

        /// <summary>
        ///  Origin size
        /// </summary>
        OriginalSize,

        /// <summary>
        /// Full-screen 
        /// </summary>
        FullScreen,

        /// <summary>
        /// Cropped full-screen 
        /// </summary>
        CroppedFull,

        /// <summary>
        /// Origin size (if surface size is larger than video size(width/height)) or 
        /// Letter box (if video size(width/height) is larger than surface size) 
        /// </summary>
        OriginalOrFull,

        /// <summary>
        /// Dst ROI mode  
        /// </summary>
        DstRoi
    }


    /// <summary>
    /// Enumeration for player stream type
    /// </summary>
    public enum StreamType
    {
        /// <summary>
        /// Container type 
        /// </summary>
        Default,

        /// <summary>
        ///  Audio element stream type 
        /// </summary>
        Audio,

        /// <summary>
        /// Video element stream type  
        /// </summary>
        Video,

        /// <summary>
        /// Text type  
        /// </summary>
        Text
    }



    /// <summary>
    /// Enumeration for Progressive download message
    /// </summary>
    public enum ProgressiveDownloadMessage
    {
        /// <summary>
        /// Progressive download is started 
        /// </summary>
        Started,

        /// <summary>
        ///  Progressive download is completed 
        /// </summary>
        Completed,
    }

    /// <summary>
    /// Streaming buffer status
    /// </summary>
    public enum StreamingBufferStatus
    {
        /// <summary>
        /// Underrun
        /// </summary>
        Underrun,

        /// <summary>
        ///  Completed 
        /// </summary>
        Overflow,
    }

    /// <summary>
    /// Enumeration for sound type
    /// </summary>
    public enum SoundType
    {
        /// <summary>
        /// Sound type for system 
        /// </summary>
        System,

        /// <summary>
        ///  Sound type for notifications 
        /// </summary>
        Notification,

        /// <summary>
        /// Sound type for alarm 
        /// </summary>
        Alarm,

        /// <summary>
        /// Sound type for ringtones 
        /// </summary>
        Ringtone,

        /// <summary>
        ///  Sound type for media 
        /// </summary>
        Media,

        /// <summary>
        /// Sound type for call 
        /// </summary>
        Call,

        /// <summary>
        /// Sound type for voip
        /// </summary>
        Voip,

        /// <summary>
        ///  Sound type for voice 
        /// </summary>
        Voice
    }

    /// <summary>
    /// Enumeration for source type
    /// </summary>
    public enum PlayerSourceType
    {
        /// <summary>
        /// Uri source 
        /// </summary>
        Uri,

        /// <summary>
        /// memory buffer source 
        /// </summary>
        Memory,

        /// <summary>
        /// stream source 
        /// </summary>
        Stream,
    }

}
