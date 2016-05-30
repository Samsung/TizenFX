using System;
using System.Collections.Generic;


namespace Tizen.Multimedia
{
    /// <summary>
    /// The RecorderCapability class provides methods to retrieve the recorder
    /// capabilities such as supported file formats, audio and video encoders.
    /// </summary>
    public class RecorderCapability
    {
		private IntPtr _handle;

		private  List<RecorderFileFormat> _formats;
		private  List<RecorderAudioCodec> _audioCodec;
		private  List<RecorderVideoCodec> _videoCodec;
		private  List<VideoResolution> _resolutions;

		internal RecorderCapability(IntPtr handle)
		{
			_handle = handle;
			_formats = new List<RecorderFileFormat>();
			_audioCodec = new List<RecorderAudioCodec>();
			_videoCodec = new List<RecorderVideoCodec> ();
			_resolutions = new List<VideoResolution> ();

		}

        /// <summary>
        /// Retrieves all the file formats supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported file
        /// formats by recorder.
        /// </returns>
		public IEnumerable<RecorderFileFormat> FileFormats
        {
			get
			{
				if (_formats.Count == 0)
				{
					Interop.RecorderCapablity.FileFormatCallback callback = (RecorderFileFormat format, IntPtr userData) =>
					{
						_formats.Add (format);
						return true;
					};
					int ret = Interop.RecorderCapablity.FileFormats (_handle, callback, IntPtr.Zero);
					if (ret != (int)RecorderError.None)
					{
						RecorderErrorFactory.ThrowException (ret, "Failed to get the supported fileformats");
					}
				}
				return _formats;
			}
        }

        /// <summary>
        /// Retrieves all the audio encoders supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported audio encoders
        /// by recorder.
        /// </returns>
		public IEnumerable<RecorderAudioCodec> AudioEncodings
        {
			get
			{
				if (_audioCodec.Count == 0)
				{
					Interop.RecorderCapablity.AudioEncoderCallback callback = (RecorderAudioCodec codec, IntPtr userData) =>
					{
						_audioCodec.Add(codec);
                        return true;
					};
					int ret = Interop.RecorderCapablity.AudioEncoders (_handle, callback, IntPtr.Zero);
					if (ret != (int)RecorderError.None)
					{
						RecorderErrorFactory.ThrowException (ret, "Failed to get the supported audio encoders");
					}
				}
				return _audioCodec;
			}
        }

		/// <summary>
		/// Retrieves all the video encoders supported by the recorder.
		/// </summary>
		/// <returns>
		/// It returns a list containing all the supported video encoders
		/// by recorder.
		/// </returns>
		public IEnumerable<RecorderVideoCodec> VideoEncodings
		{
			get
			{
				if (_videoCodec.Count == 0)
				{
					Interop.RecorderCapablity.VideoEncoderCallback callback = (RecorderVideoCodec codec, IntPtr userData) =>
					{
						_videoCodec.Add(codec);
						return true;
					};
					int ret = Interop.RecorderCapablity.VideoEncoders (_handle, callback, IntPtr.Zero);
					if (ret != (int)RecorderError.None)
					{
						RecorderErrorFactory.ThrowException (ret, "Failed to get the supported video encoders");
					}
				}
				return _videoCodec;
			}
		}

        /// <summary>
        /// Retrieves all the video resolutions supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns videoresolution list containing the width and height of
        /// different resolutions supported by recorder.
        /// </returns>
        public IEnumerable<VideoResolution> VideoResolutions
        {
			get
			{
				if (_resolutions.Count == 0)
				{
					Interop.RecorderCapablity.VideoResolutionCallback callback = (int width, int height, IntPtr userData) =>
					{
						VideoResolution temp = null;
						temp.Width = width;
						temp.Height = height;
						_resolutions.Add(temp);
                        return true;
					};
					int ret = Interop.RecorderCapablity.VideoResolution (_handle, callback, IntPtr.Zero);
					if (ret != (int)RecorderError.None)
					{
						RecorderErrorFactory.ThrowException (ret, "Failed to get the supported video resolutions");
					}
				}
				return _resolutions;
			}
        }
    }
}
