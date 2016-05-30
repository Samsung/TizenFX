using System;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The RecorderAttribute class contains various properties of Media recorder.
    /// </summary>
	public class RecorderAttribute
	{
		private IntPtr _handle;

		internal RecorderAttribute(IntPtr handle)
		{
			_handle = handle;
		}

        /// <summary>
        /// The maximum size of a recording file in KB(KiloBytes). If 0 means
        /// unlimited recording size.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the recording data is discarded
        /// and not written in the recording file.
        /// The recorder state must be in 'Ready' or 'Created' state.
        /// </remarks>
		///
        public int SizeLimit
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetSizeLimit (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get sizelimit, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetSizeLimit (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set sizelimit, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set sizelimit");
				}
            }
        }

        /// <summary>
        /// The time limit of a recording file in Seconds. If 0 means unlimited recording
        /// time.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the recording data is discarded
        /// and not written in the recording file.
        /// The recorder state must be in 'Ready' or 'Created' state.
        /// </remarks>
        public int TimeLimit
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetTimeLimit (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get timelimit, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetTimeLimit (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set timelimit, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set timelimit");
				}
            }
        }

        /// <summary>
        /// The sampling rate of an audio stream in hertz.
        /// </summary>
        public int AudioSampleRate
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetAudioSampleRate (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get audio samplerate, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetAudioSampleRate (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set audio samplerate, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set audio samplerate");
				}
            }
        }

        /// <summary>
        /// The bitrate of an audio encoder in bits per second.
        /// </summary>
        public int AudioBitRate
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetAudioEncoderBitrate (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get audio bitrate, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetAudioEncoderBitrate (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set audio bitrate, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set audio bitrate");
				}
            }
        }

        /// <summary>
        /// The bitrate of an video encoder in bits per second.
        /// </summary>
        public int VideoBitRate
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetVideoEncoderBitrate (_handle, out val);
				if ((RecorderError)ret != RecorderError.None) 
				{
					Log.Error (RecorderLog.Tag, "Failed to get video bitrate, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetVideoEncoderBitrate (_handle, value);
				if ((RecorderError)ret != RecorderError.None) 
				{
					Log.Error (RecorderLog.Tag, "Failed to set video bitrate, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set video bitrate");
				}
            }
        }

        /// <summary>
        /// The mute state of a recorder.
        /// </summary>
        public bool Mute
        {
            get
            {
				bool val;

				val = Interop.RecorderAttribute.GetMute (_handle);
				int ret = ErrorFacts.GetLastResult ();
				if ((RecorderError)ret != RecorderError.None) 
				{
					Log.Error (RecorderLog.Tag, "Failed to get the mute state of recorder, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetMute (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set mute, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set mute");
				}
            }
        }

        /// <summary>
        /// The video recording motion rate
        /// </summary>
        /// <remarks>
        /// The attribute is valid only in a video recorder.
        /// If the rate is in range of 0-1, video is recorded in a slow motion mode.
        /// If the rate is bigger than 1, video is recorded in a fast motion mode.
        /// </remarks>
        public double MotionRate
        {
            get
            {
				double val = 0.0;

				int ret = Interop.RecorderAttribute.GetMotionRate (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get video motionrate, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetMotionRate (_handle, (double)value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set video motionrate, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set video motionrate");
				}
            }
        }

        /// <summary>
        /// The number of audio channel.
        /// </summary>
        /// <remarks>
        /// The attribute is applied only in Created state.
        /// For mono recording, set channel to 1.
        /// For stereo recording, set channel to 2.
        /// </remarks>
        public int AudioChannel
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetAudioChannel (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get audio channel, " + (RecorderError)ret);
				}
				return val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetAudioChannel (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set audio channel, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set audio channel");
				}
            }
        }

        /// <summary>
        /// The audio device for recording.
        /// </summary>
        public RecorderAudioDevice AudioDevice
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetAudioDevice (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get audio device, " + (RecorderError)ret);
				}
				return (RecorderAudioDevice)val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetAudioDevice (_handle, (int)value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set audio device, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set audio device");
				}
            }
        }

        /// <summary>
        /// The orientation in a video metadata tag.
        /// </summary>
        public RecorderOrientation OrientationTag
        {
            get
            {
				int val = 0;

				int ret = Interop.RecorderAttribute.GetOrientationTag (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get recorder orientation, " + (RecorderError)ret);
				}
				return (RecorderOrientation)val;
            }
            set
            {
				int ret = Interop.RecorderAttribute.SetOrientationTag (_handle, (int)value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set recorder orientation, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set audio orientation");
				}
            }
        }
	}
}

