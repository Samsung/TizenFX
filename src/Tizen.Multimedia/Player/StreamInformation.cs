/// Audio Stream Information
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;


namespace Tizen.Multimedia
{
    /// <summary>
    /// Stream information
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for fetching
    /// metadata of a media stream.
    /// </remarks>
    public class StreamInformation
    {

        /// <summary>
        /// Get album art.
        /// </summary>
        /// <value> byte[] </value>
        public byte[] AlbumArt 
        {
            get 
            {
                return _albumArt;
            }
        }

        /// <summary>
        /// Get AudioCodec.
        /// </summary>
        /// <value> AudioCodec string </value>
        public string AudioCodec 
        {
            get
            {
				string audioCodec, videoCodec;
				int ret = Interop.Player.GetCodecInfo(_playerHandle, out audioCodec, out videoCodec);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get codec info" + (PlayerError)ret);
				}
				return audioCodec;
            }
        }

        /// <summary>
        /// Get Duration.
        /// </summary>
        /// <value> duration in milliseconds </value>
        public int Duration 
        {
            get
            {
				int duration;
				int ret = Interop.Player.GetDuration(_playerHandle, out duration);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get duration info" + (PlayerError)ret);
				}
                return duration;
            }
        }

        /// <summary>
        /// Get Sample rate.
        /// </summary>
        /// <value> The audio sample rate [Hz]  </value>
        public int AudioSampleRate 
        {
            get
            {
				int sampleRate, channels, bitRate;
				int ret = Interop.Player.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get audio stream info" + (PlayerError)ret);
				}
				return sampleRate;
            }
        }

        /// <summary>
        /// Channels
        /// </summary>
        /// <value>  The audio channels </value>
        public int AudioChannels 
        {
            get
            {
				int sampleRate, channels, bitRate;
				int ret = Interop.Player.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get audio channels info" + (PlayerError)ret);
				}
				return channels;
            }
        }

        /// <summary>
        /// Audio bit rate.
        /// </summary>
        /// <value> bit rate [Hz] </value>
        public int AudioBitRate
        {
            get
            {
				int sampleRate, channels, bitRate;
				int ret = Interop.Player.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get audio bitrate info" + (PlayerError)ret);
				}
				return bitRate;
            }
        }


        /// <summary>
        /// VideoCodec
        /// </summary>
        /// <value> video codec string </value>
        public string VideoCodec
        {
            get
            {
				string audioCodec, videoCodec;
				int ret = Interop.Player.GetCodecInfo(_playerHandle, out audioCodec, out videoCodec);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get video codec info" + (PlayerError)ret);
				}
				return videoCodec;
            }
        }

        /// <summary>
        /// FPS
        /// </summary>
        /// <value> int Frames per second</value>
        public int VideoFps
        {
            get
            {
				int fps, bitRate;
				int ret = Interop.Player.GetVideoStreamInfo(_playerHandle, out fps, out bitRate);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get video fps info" + (PlayerError)ret);
				}
				return fps;
            }
        }

        /// <summary>
        /// Video bit rate.
        /// </summary>
        /// <value> bit rate [Hz] </value>
        public int VideoBitRate
        {
            get
            {
				int fps, bitRate;
				int ret = Interop.Player.GetVideoStreamInfo(_playerHandle, out fps, out bitRate);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get video bitrate info" + (PlayerError)ret);
				}
				return bitRate;
            }
        }

        /// <summary>
        /// Get Video Height.
        /// </summary>
        /// <value> video height </value>
        public int VideoHeight
        {
            get
            {
				int height, width;
				int ret = Interop.Player.GetVideoSize(_playerHandle, out width, out height);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get video height" + (PlayerError)ret);
				}
				return height;
            }
        }

        /// <summary>
        /// Get Video Width.
        /// </summary>
        /// <value> video width </value>
        public int VideoWidth
        {
            get
            {
				int height, width;
				int ret = Interop.Player.GetVideoSize(_playerHandle, out width, out height);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get video width" + (PlayerError)ret);
				}
				return width;
            }
        }

        /// <summary>
        /// Get Player content info.
        /// </summary>
        /// <value> metadata </value>
        public PlayerContentInfo ContentInfo
        {
            get
            {
                return _contentInfo;
            }
        }

		internal StreamInformation()
		{
		}

		internal IntPtr _playerHandle;

        internal byte[] _albumArt;
        internal PlayerContentInfo _contentInfo;
    }
}