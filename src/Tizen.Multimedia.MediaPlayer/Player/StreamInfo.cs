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
                    return Marshal.PtrToStringAnsi(audioPtr);
                }
                else
                {
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

        private void GetAudioProperties(out int sampleRate, out int channels, out int bitRate)
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetAudioStreamInfo(Player.Handle, out sampleRate,
                out channels, out bitRate).
                ThrowIfFailed(Player, "Failed to get audio stream info");
        }

        /// <summary>
        /// Gets the sample rate of the audio.
        /// </summary>
        /// <returns>The audio sample rate of the stream, in Hertz.</returns>
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
        /// <since_tizen>4</since_tizen>
        public int GetAudioSampleRate()
        {
            GetAudioProperties(out var sampleRate, out _, out _);

            return sampleRate;
        }

        /// <summary>
        /// Gets the channels of the audio.
        /// </summary>
        /// <returns>The number of channels of the stream.</returns>
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
        /// <since_tizen>4</since_tizen>
        public int GetAudioChannels()
        {
            GetAudioProperties(out _, out var channels, out _);

            return channels;
        }

        /// <summary>
        /// Gets the bit rate of the audio.
        /// </summary>
        /// <returns>The bit rate of the stream, in Hertz.</returns>
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
        /// <since_tizen>4</since_tizen>
        public int GetAudioBitRate()
        {
            GetAudioProperties(out _, out _, out var bitRate);

            return bitRate;
        }

        private void GetVideoProperties(out int fps, out int bitRate)
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.GetVideoStreamInfo(Player.Handle, out fps, out bitRate).
                ThrowIfFailed(Player, "Failed to get the video stream info");
        }

        /// <summary>
        /// Gets the fps of the video.
        /// </summary>
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
        /// <since_tizen>4</since_tizen>
        public int GetVideoFps()
        {
            GetVideoProperties(out var fps, out _);

            return fps;
        }

        /// <summary>
        /// Gets the bit rate of the video.
        /// </summary>
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
        /// <since_tizen>4</since_tizen>
        public int GetVideoBitRate()
        {
            GetVideoProperties(out _, out var bitRate);

            return bitRate;
        }

        /// <summary>
        /// Gets the size of the video.
        /// </summary>
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
        /// <since_tizen>4</since_tizen>
        public Size GetVideoSize()
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

            ValidationUtil.ValidateEnum(typeof(StreamMetadataKey), key);

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
