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
using System;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for audio stream.
    /// </summary>
    public struct AudioStreamProperties
    {
        /// <summary>
        /// Initialize a new instance of the AudioStreamProperties struct with the specified sample rate, channels and bit rate.
        /// </summary>
        public AudioStreamProperties(int sampleRate, int channels, int bitRate)
        {
            SampleRate = sampleRate;
            Channels = channels;
            BitRate = bitRate;
            Log.Debug(PlayerLog.Tag, "sampleRate : " + sampleRate + ", channels : " + channels + ", bitRate : " + bitRate);
        }

        /// <summary>
        /// Gets or sets the sample rate.
        /// </summary>
        /// <value>The audio sample rate(Hz).</value>
        public int SampleRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        public int Channels
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bit rate.
        /// </summary>
        /// <value>The audio bit rate(Hz).</value>
        public int BitRate
        {
            get;
            set;
        }

        public override string ToString() =>
            $"SampleRate={ SampleRate.ToString() }, Channels={ Channels.ToString() }, BitRate={ BitRate.ToString() }";
    }

    /// <summary>
    /// Represents properties for video stream.
    /// </summary>
    public struct VideoStreamProperties
    {
        /// <summary>
        /// Initialize a new instance of the VideoStreamProperties struct with the specified fps, bit rate and size.
        /// </summary>
        public VideoStreamProperties(int fps, int bitRate, Size size)
        {
            Fps = fps;
            BitRate = bitRate;
            Size = size;
            Log.Debug(PlayerLog.Tag, "fps : " + fps + ", bitrate : " + bitRate +
                ", width : " + size.Width + ", height : " + size.Height);
        }
        /// <summary>
        /// Initialize a new instance of the VideoStreamProperties struct with the specified fps, bit rate, width and height.
        /// </summary>
        public VideoStreamProperties(int fps, int bitRate, int width, int height)
        {
            Fps = fps;
            BitRate = bitRate;
            Size = new Size(width, height);
            Log.Debug(PlayerLog.Tag, "fps : " + fps + ", bitrate : " + bitRate +
                ", width : " + width + ", height : " + height);
        }

        /// <summary>
        /// Gets or sets the fps.
        /// </summary>
        public int Fps
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bit rate.
        /// </summary>
        public int BitRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public Size Size
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Fps={ Fps.ToString() }, BitRate={ BitRate.ToString() }, Size=[{ Size.ToString() }]";
        }
    }

    /// <summary>
    /// Provides a means to retrieve stream information.
    /// </summary>
    public class StreamInfo
    {
        internal StreamInfo(Player owner)
        {
            Player = owner;
        }

        /// <summary>
        /// Retrieves the album art of the stream or null if there is no album art data.
        /// </summary>
        /// <remarks>The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.</exception>
        public byte[] GetAlbumArt()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetAlbumArt(Player.Handle, out var art, out var size).
                ThrowIfFailed("Failed to get the album art");

            if (art == IntPtr.Zero || size == 0)
            {
                Log.Error(PlayerLog.Tag, "art is null or size is 0 : " + size);
                return null;
            }

            byte[] albumArt = new byte[size];
            Marshal.Copy(art, albumArt, 0, size);
            return albumArt;
        }

        private string GetCodecInfo(bool audioInfo)
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            IntPtr audioPtr = IntPtr.Zero;
            IntPtr videoPtr = IntPtr.Zero;
            try
            {
                NativePlayer.GetCodecInfo(Player.Handle, out audioPtr, out videoPtr).
                    ThrowIfFailed("Failed to get codec info");

                if (audioInfo)
                {
                    Log.Debug(PlayerLog.Tag, "it is audio case");
                    return Marshal.PtrToStringAnsi(audioPtr);
                }
                else
                {
                    Log.Debug(PlayerLog.Tag, "it is video case");
                    return Marshal.PtrToStringAnsi(videoPtr);
                }
            }
            finally
            {
                LibcSupport.Free(audioPtr);
                LibcSupport.Free(videoPtr);
            }
        }

        /// <summary>
        /// Retrieves the codec name of audio or null if there is no audio.
        /// </summary>
        public string GetAudioCodec()
        {
            return GetCodecInfo(true);
        }

        /// <summary>
        /// Retrieves the codec name of video or null if there is no video.
        /// </summary>
        public string GetVideoCodec()
        {
            return GetCodecInfo(false);
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <remarks>The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.</exception>
        public int GetDuration()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            int duration = 0;
            NativePlayer.GetDuration(Player.Handle, out duration).
                ThrowIfFailed("Failed to get the duration");

            Log.Info(PlayerLog.Tag, "get duration : " + duration);
            return duration;
        }

        /// <summary>
        /// Gets the properties of audio.
        /// </summary>
        /// <remarks>The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.</exception>
        public AudioStreamProperties GetAudioProperties()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            int sampleRate = 0;
            int channels = 0;
            int bitRate = 0;

            NativePlayer.GetAudioStreamInfo(Player.Handle, out sampleRate, out channels, out bitRate).
                ThrowIfFailed("Failed to get audio stream info");

            // TODO should we check value is zero and return null?

            return new AudioStreamProperties(sampleRate, channels, bitRate);
        }

        /// <summary>
        /// Gets the properties of video.
        /// </summary>
        /// <remarks>The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.</exception>
        public VideoStreamProperties GetVideoProperties()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            int fps = 0;
            int bitRate = 0;

            NativePlayer.GetVideoStreamInfo(Player.Handle, out fps, out bitRate).
                ThrowIfFailed("Failed to get the video stream info");

            // TODO should we check value is zero and return null?

            return new VideoStreamProperties(fps, bitRate, GetVideoSize());
        }

        private Size GetVideoSize()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            int height = 0;
            int width = 0;

            NativePlayer.GetVideoSize(Player.Handle, out width, out height).
                ThrowIfFailed("Failed to get the video size");

            return new Size(width, height);
        }

        /// <summary>
        /// Gets the metadata with the specified key.
        /// </summary>
        /// <param name="key">The key to query.</param>
        /// <remarks>The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.</exception>
        public string GetMetadata(StreamMetadataKey key)
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            ValidationUtil.ValidateEnum(typeof(StreamMetadataKey), key);

            IntPtr ptr = IntPtr.Zero;

            try
            {
                NativePlayer.GetContentInfo(Player.Handle, key, out ptr).
                    ThrowIfFailed($"Failed to get the meta data with the key '{ key }'");

                return Marshal.PtrToStringAnsi(ptr);
            }
            finally
            {
                LibcSupport.Free(ptr);
            }
        }

        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        public Player Player { get; }
    }
}
