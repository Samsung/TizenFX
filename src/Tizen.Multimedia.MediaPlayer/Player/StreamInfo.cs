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
    /// Represents properties for the audio stream.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct AudioStreamProperties
    {
        /// <summary>
        /// Initializes a new instance of the AudioStreamProperties struct with the specified sample rate, channels, and bit rate.
        /// </summary>
        /// <param name="sampleRate">The sample rate of the stream.</param>
        /// <param name="channels">The number of channels of the stream.</param>
        /// <param name="bitRate">The bit rate of the stream.</param>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamProperties(int sampleRate, int channels, int bitRate)
        {
            SampleRate = sampleRate;
            Channels = channels;
            BitRate = bitRate;

            Log.Debug(PlayerLog.Tag, $"sampleRate={sampleRate}, channels={channels}, bitRate={bitRate}");
        }

        /// <summary>
        /// Gets or sets the sample rate.
        /// </summary>
        /// <value>The audio sample rate(Hz).</value>
        /// <since_tizen> 3 </since_tizen>
        public int SampleRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Channels
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bit rate.
        /// </summary>
        /// <value>The audio bit rate(Hz).</value>
        /// <since_tizen> 3 </since_tizen>
        public int BitRate
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString() =>
            $"SampleRate={ SampleRate.ToString() }, Channels={ Channels.ToString() }, BitRate={ BitRate.ToString() }";
    }

    /// <summary>
    /// Represents properties for the video stream.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct VideoStreamProperties
    {
        /// <summary>
        /// Initializes a new instance of the VideoStreamProperties struct with the specified fps, bit rate, and size.
        /// </summary>
        /// <param name="fps">The fps of the stream.</param>
        /// <param name="bitRate">The bit rate of the stream.</param>
        /// <param name="size">The size of the stream.</param>
        /// <since_tizen> 3 </since_tizen>
        public VideoStreamProperties(int fps, int bitRate, Size size)
        {
            Fps = fps;
            BitRate = bitRate;
            Size = size;
            Log.Debug(PlayerLog.Tag, $"fps={fps}, bitrate={bitRate}, size=({size})");
        }
        /// <summary>
        /// Initializes a new instance of the VideoStreamProperties struct with the specified fps, bit rate, width, and height.
        /// </summary>
        /// <param name="fps">The fps of the stream.</param>
        /// <param name="bitRate">The bit rate of the stream.</param>
        /// <param name="width">The width of the stream.</param>
        /// <param name="height">The height of the stream.</param>
        /// <since_tizen> 3 </since_tizen>
        public VideoStreamProperties(int fps, int bitRate, int width, int height)
            : this(fps, bitRate, new Size(width, height))
        {
        }

        /// <summary>
        /// Gets or sets the fps.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Fps
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bit rate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BitRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size Size
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
        {
            return $"Fps={ Fps.ToString() }, BitRate={ BitRate.ToString() }, Size=[{ Size.ToString() }]";
        }
    }

    /// <summary>
    /// Provides a means to retrieve stream information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class StreamInfo
    {
        internal StreamInfo(Player owner)
        {
            Player = owner;
        }

        /// <summary>
        /// Retrieves the album art of the stream, or null if there is no album art data.
        /// </summary>
        /// <returns>Raw byte array if album art exists; otherwise null.</returns>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public byte[] GetAlbumArt()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetAlbumArt(Player.Handle, out var art, out var size).
                ThrowIfFailed(Player, "Failed to get the album art");

            if (art == IntPtr.Zero || size == 0)
            {
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
                    ThrowIfFailed(Player, "Failed to get codec info");

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
        /// Retrieves the codec name of the audio or null if there is no audio.
        /// </summary>
        /// <returns>A string that represents the codec name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetAudioCodec()
        {
            return GetCodecInfo(true);
        }

        /// <summary>
        /// Retrieves the codec name of the video or null if there is no video.
        /// </summary>
        /// <returns>A string that represents the codec name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetVideoCodec()
        {
            return GetCodecInfo(false);
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <returns>The duration of the stream.</returns>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public int GetDuration()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetDuration(Player.Handle, out var duration).
                ThrowIfFailed(Player, "Failed to get the duration");

            Log.Info(PlayerLog.Tag, "get duration : " + duration);
            return duration;
        }

        /// <summary>
        /// Gets the duration in nanoseconds.
        /// </summary>
        /// <returns>The duration of the stream.</returns>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public long GetDurationNanos()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetDurationNanos(Player.Handle, out var duration).
                ThrowIfFailed(Player, "Failed to get the duration in nanoseconds");

            Log.Info(PlayerLog.Tag, "get duration(nsec) : " + duration);
            return duration;
        }

        /// <summary>
        /// Gets the properties of the audio.
        /// </summary>
        /// <returns>A <see cref="AudioStreamProperties"/> that contains the audio stream information.</returns>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamProperties GetAudioProperties()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetAudioStreamInfo(Player.Handle, out var sampleRate,
                out var channels, out var bitRate).
                ThrowIfFailed(Player, "Failed to get audio stream info");

            return new AudioStreamProperties(sampleRate, channels, bitRate);
        }

        /// <summary>
        /// Gets the properties of the video.
        /// </summary>
        /// <returns>A <see cref="VideoStreamProperties"/> that contains the video stream information.</returns>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoStreamProperties GetVideoProperties()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetVideoStreamInfo(Player.Handle, out var fps, out var bitRate).
                ThrowIfFailed(Player, "Failed to get the video stream info");

            return new VideoStreamProperties(fps, bitRate, GetVideoSize());
        }

        private Size GetVideoSize()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetVideoSize(Player.Handle, out var width, out var height).
                ThrowIfFailed(Player, "Failed to get the video size");

            return new Size(width, height);
        }

        /// <summary>
        /// Gets the metadata with the specified key.
        /// </summary>
        /// <returns>A string that represents the value of the specified key.</returns>
        /// <param name="key">The key to query.</param>
        /// <remarks>
        /// The <see cref="Multimedia.Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public string GetMetadata(StreamMetadataKey key)
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            ValidationUtil.ValidateEnum(typeof(StreamMetadataKey), key, nameof(key));

            IntPtr ptr = IntPtr.Zero;

            try
            {
                NativePlayer.GetContentInfo(Player.Handle, key, out ptr).
                    ThrowIfFailed(Player, $"Failed to get the meta data with the key '{ key }'");

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
        /// <since_tizen> 3 </since_tizen>
        public Player Player { get; }
    }
}
