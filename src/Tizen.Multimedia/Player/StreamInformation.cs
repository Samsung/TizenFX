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
				if (Interop.PlayerInterop.GetCodecInfo (_playerHandle, out audioCodec, out videoCodec) != 0) {
					//throw Exception
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
				if (Interop.PlayerInterop.GetDuration (_playerHandle, out duration) != 0) {
					//throw Exception
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
				if( Interop.PlayerInterop.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate) != 0) {
					//throw Exception;
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
				if( Interop.PlayerInterop.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate) != 0) {
					//throw Exception;
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
				if( Interop.PlayerInterop.GetAudioStreamInfo(_playerHandle, out sampleRate, out channels, out bitRate) != 0) {
					//throw Exception;
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
				if (Interop.PlayerInterop.GetCodecInfo (_playerHandle, out audioCodec, out videoCodec) != 0) {
					//throw Exception
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
				if (Interop.PlayerInterop.GetVideoStreamInfo (_playerHandle, out fps, out bitRate) != 0) {
					//throw Exception;
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
				if (Interop.PlayerInterop.GetVideoStreamInfo (_playerHandle, out fps, out bitRate) != 0) {
					//throw Exception;
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
				if (Interop.PlayerInterop.GetVideoSize (_playerHandle, out width, out height) != 0) {
					//throw Exception;
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
				if (Interop.PlayerInterop.GetVideoSize (_playerHandle, out width, out height) != 0) {
					//throw Exception;
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
			
		internal IntPtr _playerHandle;

        internal byte[] _albumArt;
        internal PlayerContentInfo _contentInfo;
    }
}