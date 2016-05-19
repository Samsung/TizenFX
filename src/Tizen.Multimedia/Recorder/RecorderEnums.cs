using System;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Enumeration for Audio Codec.
	/// </summary>
	public enum RecorderAudioCodec
	{
		/// <summary>
		/// Disable Audio track.
		/// </summary>
		Disable = -1,
		/// <summary>
		/// AMR codec.
		/// </summary>
		Amr = 0,
		/// <summary>
		/// AAC codec.
		/// </summary>
		Aac,
		/// <summary>
		/// Vorbis codec.
		/// </summary>
		Vorbis,
		/// <summary>
		/// PCM codec.
		/// </summary>
		Pcm,
		/// <summary>
		/// The mp3 codec.
		/// </summary>
		Mp3
	}

	/// <summary>
	/// Enumeration for Audio capture devices.
	/// </summary>
	public enum RecorderAudioDevice
	{
		/// <summary>
		/// Capture audio from Mic device.
		/// </summary>
		Mic,
		/// <summary>
		/// Capture audio from modem.
		/// </summary>
		Modem
	}

	/// <summary>
	/// Enumeration for the file container format.
	/// </summary>
	public enum RecorderFileFormat
	{
		/// <summary>
		/// 3GP file format.
		/// </summary>
		ThreeGp,
		/// <summary>
		/// MP4 file format.
		/// </summary>
		Mp4,
		/// <summary>
		/// AMR file format.
		/// </summary>
		Amr,
		/// <summary>
		/// ADTS file format.
		/// </summary>
		Adts,
		/// <summary>
		/// WAV file format.
		/// </summary>
		Wav,
		/// <summary>
		/// OGG file format.
		/// </summary>
		Ogg,
		/// <summary>
		/// M2TS file format.
		/// </summary>
		M2TS
	}

	/// <summary>
	/// Enumeration for the recorder policy.
	/// </summary>
	public enum  RecorderPolicy
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,
		/// <summary>
		/// Security policy.
		/// </summary>
		Security = 4,
		/// <summary>
		/// Sound policy.
		/// </summary>
		Resourceconflict = 5
	}

	/// <summary>
	/// Enumeration for the recording limit.
	/// </summary>
	public enum RecordingLimitType
	{
		/// <summary>
		/// Time limit in seconds of recording file
		/// </summary>
		Time,
		/// <summary>
		/// Size limit in KB(KiloBytes) of recording file.
		/// </summary>
		Size,
		/// <summary>
		/// No free space in storage.
		/// </summary>
		Space
	}

	/// <summary>
	/// Enumeration for the recorder rotation type.
	/// </summary>
	public enum  RecorderRotation
	{
		/// <summary>
		/// No rotation.
		/// </summary>
		RotationNone,
		/// <summary>
		/// 90 Degree rotation.
		/// </summary>
		Rotation90,
		/// <summary>
		/// 180 Degree rotation.
		/// </summary>
		Rotation180,
		/// <summary>
		/// 270 Degree rotation.
		/// </summary>
		Rotation270
	}

	/// <summary>
	/// Enumeration for recorder states.
	/// </summary>
	public enum RecorderState
	{
		/// <summary>
		/// Recorder is not created.
		/// </summary>
		None,
		/// <summary>
		/// Recorder is created, but not prepared.
		/// </summary>
		Created,
		/// <summary>
		/// Recorder is ready to record. In case of video recorder,
		/// preview display will be shown
		/// </summary>
		Ready,
		/// <summary>
		/// Recorder is recording media.
		/// </summary>
		Recording,
		/// <summary>
		/// Recorder is paused while recording media.
		/// </summary>
		Paused
	}

	/// <summary>
	/// Enumeration for video codec.
	/// </summary>
	public enum RecorderVideoCodec
	{
		/// <summary>
		/// H263 codec.
		/// </summary>
		H263,
		/// <summary>
		/// H264 codec.
		/// </summary>
		H264,
		/// <summary>
		/// MPEG4 codec.
		/// </summary>
		Mpeg4,
		/// <summary>
		/// Theora codec.
		/// </summary>
		Theora
	}

    /// <summary>
    /// Enumeration for audio sample type.
    /// </summary>
    public enum AudioSampleType {
        /// <summary>
        /// Unsigned 8-bit audio samples.
        /// </summary>
        U8 = 0x70,
        /// <summary>
        /// Signed 16-bit audio samples.
        /// </summary>
        S16Le
    }

    /// <summary>
    /// Enumeration for recorder failure error.
    /// </summary>
    public enum RecorderErrorCode {
        /// <summary>
        /// Device Error.
        /// </summary>
		ErrorDevice = RecorderError.ErrorDevice,
        /// <summary>
        /// Internal error.
        /// </summary>
		InvalidOperation = RecorderError.InvalidOperation,
        /// <summary>
        /// Out of memory.
        /// </summary>
		OutOfMemory = RecorderError.OutOfMemory
    }
}

