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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Interop;

namespace Tizen.Multimedia
{

    /// <summary>
    /// Provides the ability to push packets as the source of <see cref="Player"/>.
    /// </summary>
    /// <remarks>The source must be set as a source to a player before pushing.</remarks>
    /// <seealso cref="Player.SetSource(MediaSource)"/>
    /// <since_tizen> 3 </since_tizen>
    public sealed class MediaStreamSource : MediaSource
    {
        private readonly MediaFormat _audioMediaFormat;
        private readonly MediaFormat _videoMediaFormat;
        private static PlayerHandle _playerHandle;
        private static IntPtr _handle;

        /// <summary>
        /// Gets all supported audio types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<MediaFormatAudioMimeType> SupportedAudioTypes
        {
            get
            {
                NativePlayer.Create(out _playerHandle).ThrowIfFailed(null, "Failed to create player");
                _handle = _playerHandle.DangerousGetHandle();
                Debug.Assert(_handle != IntPtr.Zero);

                try
                {
                    List<MediaFormatAudioMimeType> audioFormats = new List<MediaFormatAudioMimeType>();

                    NativePlayer.SupportedMediaFormatCallback callback = (int format, IntPtr userData) =>
                    {
                        if (!Enum.IsDefined(typeof(MediaFormatAudioMimeType), format))
                        {
                            Log.Debug(PlayerLog.Tag, "skipped : " + format.ToString());
                        }
                        else
                        {
                            Log.Debug(PlayerLog.Tag, "supported audio : " + ((MediaFormatAudioMimeType)format).ToString());
                            audioFormats.Add((MediaFormatAudioMimeType)format);
                        }

                        return true;
                    };

                    NativePlayer.SupportedMediaStreamFormat(_handle, callback, IntPtr.Zero).
                        ThrowIfFailed(null, "Failed to get the list");

                    return audioFormats.AsReadOnly();
                }
                finally
                {
                    _playerHandle.Dispose();
                    _handle = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Gets all supported video types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<MediaFormatVideoMimeType> SupportedVideoTypes
        {
            get
            {
                NativePlayer.Create(out _playerHandle).ThrowIfFailed(null, "Failed to create player");
                _handle = _playerHandle.DangerousGetHandle();
                Debug.Assert(_handle != IntPtr.Zero);

                try
                {
                    List<MediaFormatVideoMimeType> videoFormats = new List<MediaFormatVideoMimeType>();

                    NativePlayer.SupportedMediaFormatCallback callback = (int format, IntPtr userData) =>
                    {
                        if (!Enum.IsDefined(typeof(MediaFormatVideoMimeType), format))
                        {
                            Log.Debug(PlayerLog.Tag, "skipped : " + format.ToString());
                        }
                        else
                        {
                            Log.Debug(PlayerLog.Tag, "supported video : " + ((MediaFormatVideoMimeType)format).ToString());
                            videoFormats.Add((MediaFormatVideoMimeType)format);
                        }

                        return true;
                    };

                    NativePlayer.SupportedMediaStreamFormat(_handle, callback, IntPtr.Zero).
                        ThrowIfFailed(null, "Failed to get the list"); ;

                    return videoFormats.AsReadOnly();
                }
                finally
                {
                    _playerHandle.Dispose();
                    _handle = IntPtr.Zero;
                }
            }
        }

        private Player _player;

        private MediaStreamConfiguration CreateAudioConfiguration(AudioMediaFormat format)
        {
            if (format == null)
            {
                return null;
            }

            if (!SupportedAudioTypes.Contains(format.MimeType))
            {
                Log.Error(PlayerLog.Tag, "The audio format is not supported : " + format.MimeType);
                throw new ArgumentException($"The audio format is not supported, Type : {format.MimeType}.");
            }

            return new MediaStreamConfiguration(this, StreamType.Audio);
        }

        private MediaStreamConfiguration CreateVideoConfiguration(VideoMediaFormat format)
        {
            if (format == null)
            {
                return null;
            }

            if (!SupportedVideoTypes.Contains(format.MimeType))
            {
                Log.Error(PlayerLog.Tag, "The video format is not supported : " + format.MimeType);
                throw new ArgumentException($"The video format is not supported, Type : {format.MimeType}.");
            }

            return new MediaStreamConfiguration(this, StreamType.Video);
        }

        /// <summary>
        /// Initializes a new instance of the MediaStreamSource class
        /// with the specified <see cref="AudioMediaFormat"/> and <see cref="VideoMediaFormat"/>.
        /// </summary>
        /// <param name="audioMediaFormat">The <see cref="AudioMediaFormat"/> for this source.</param>
        /// <param name="videoMediaFormat">The <see cref="VideoMediaFormat"/> for this source.</param>
        /// <remarks>AAC and H.264 are supported.</remarks>
        /// <exception cref="ArgumentNullException">Both <paramref name="audioMediaFormat"/> and <paramref name="videoMediaFormat"/> are null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="audioMediaFormat"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="videoMediaFormat"/> is not supported.
        /// </exception>
        /// <seealso cref="SupportedAudioTypes"/>
        /// <seealso cref="SupportedVideoTypes"/>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamSource(AudioMediaFormat audioMediaFormat, VideoMediaFormat videoMediaFormat)
        {
            if (audioMediaFormat == null && videoMediaFormat == null)
            {
                throw new ArgumentNullException(string.Concat(nameof(_audioMediaFormat), " and ", nameof(_videoMediaFormat)));
            }

            _audioMediaFormat = audioMediaFormat;
            _videoMediaFormat = videoMediaFormat;

            AudioConfiguration = CreateAudioConfiguration(audioMediaFormat);
            VideoConfiguration = CreateVideoConfiguration(videoMediaFormat);
        }

        /// <summary>
        /// Initializes a new instance of the MediaStreamSource class with the specified <see cref="AudioMediaFormat"/>.
        /// </summary>
        /// <param name="audioMediaFormat">The <see cref="AudioMediaFormat"/> for this source.</param>
        /// <remarks>AAC is supported.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="audioMediaFormat"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="audioMediaFormat"/> is not supported.</exception>
        /// <seealso cref="SupportedAudioTypes"/>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamSource(AudioMediaFormat audioMediaFormat)
        {
            _audioMediaFormat = audioMediaFormat ?? throw new ArgumentNullException(nameof(audioMediaFormat));
            AudioConfiguration = CreateAudioConfiguration(audioMediaFormat);
        }
        /// <summary>
        /// Initializes a new instance of the MediaStreamSource class with the specified <see cref="VideoMediaFormat"/>.
        /// </summary>
        /// <remarks>H.264 is supported.</remarks>
        /// <param name="videoMediaFormat">The <see cref="VideoMediaFormat"/> for this source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="videoMediaFormat"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="videoMediaFormat"/> is not supported.</exception>
        /// <seealso cref="SupportedVideoTypes"/>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamSource(VideoMediaFormat videoMediaFormat)
        {
            _videoMediaFormat = videoMediaFormat ?? throw new ArgumentNullException(nameof(videoMediaFormat));
            VideoConfiguration = CreateVideoConfiguration(videoMediaFormat);
        }

        /// <summary>
        /// Gets the audio configuration, or null if no AudioMediaFormat is specified in the constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamConfiguration AudioConfiguration { get; }

        /// <summary>
        /// Gets the video configuration, or null if no VideoMediaFormat is specified in the constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaStreamConfiguration VideoConfiguration { get; }

        /// <summary>
        /// Pushes elementary stream to decode audio or video.
        /// </summary>
        /// <remarks>This source must be set as a source to a player and the player must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <param name="packet">The <see cref="MediaPacket"/> to decode.</param>
        /// <exception cref="InvalidOperationException">
        ///     This source is not set as a source to a player.<br/>
        ///     -or-<br/>
        ///     The player is not in the valid state.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="packet"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="packet"/> has been disposed of.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="packet"/> is neither video nor audio type.<br/>
        ///     -or-<br/>
        ///     The format of packet is not matched with the specified format in the constructor.
        /// </exception>
        /// <exception cref="NoBufferSpaceException">The internal buffer has reached its limits.</exception>
        /// <seealso cref="Player.SetSource(MediaSource)"/>
        /// <seealso cref="MediaStreamConfiguration.BufferMaxSize"/>
        /// <seealso cref="MediaPacket"/>
        /// <since_tizen> 3 </since_tizen>
        public void Push(MediaPacket packet)
        {
            if (_player == null)
            {
                Log.Error(PlayerLog.Tag, "The source is not set as a source to a player yet.");
                throw new InvalidOperationException("The source is not set as a source to a player yet.");
            }
            if (_audioMediaFormat == null && _videoMediaFormat == null)
            {
                throw new ArgumentNullException(string.Concat(nameof(_audioMediaFormat), " and ", nameof(_videoMediaFormat)));
            }
            if (packet == null)
            {
                Log.Error(PlayerLog.Tag, "packet is null");
                throw new ArgumentNullException(nameof(packet));
            }
            if (packet.IsDisposed)
            {
                Log.Error(PlayerLog.Tag, "packet is disposed");
                throw new ObjectDisposedException(nameof(packet));
            }

            if (packet.Format.Type == MediaFormatType.Text || packet.Format.Type == MediaFormatType.Container)
            {
                Log.Error(PlayerLog.Tag, "The format of the packet is invalid : " + packet.Format.Type);
                throw new ArgumentException($"The format of the packet is invalid : { packet.Format.Type }.");
            }

            if (!packet.Format.Equals(_audioMediaFormat) && !packet.Format.Equals(_videoMediaFormat))
            {
                Log.Error(PlayerLog.Tag, "The format of the packet is invalid : Unmatched format.");
                throw new ArgumentException($"The format of the packet is invalid : Unmatched format.");
            }

            if (packet.Format.Type == MediaFormatType.Video && _videoMediaFormat == null)
            {
                Log.Error(PlayerLog.Tag, "Video is not configured with the current source.");
                throw new ArgumentException("Video is not configured with the current source.");
            }
            if (packet.Format.Type == MediaFormatType.Audio && _audioMediaFormat == null)
            {
                Log.Error(PlayerLog.Tag, "Audio is not configured with the current source.");
                throw new ArgumentException("Audio is not configured with the current source.");
            }

            _player.ValidatePlayerState(PlayerState.Paused, PlayerState.Playing, PlayerState.Ready);

            NativePlayer.PushMediaStream(_player.Handle, packet.GetHandle()).
                ThrowIfFailed(_player, "Failed to push the packet to the player");
        }

        private void SetMediaStreamInfo(StreamType streamType, MediaFormat mediaFormat)
        {
            if (mediaFormat == null)
            {
                Log.Error(PlayerLog.Tag, "invalid media format");
                return;
            }

            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = mediaFormat.AsNativeHandle();

                NativePlayer.SetMediaStreamInfo(_player.Handle, streamType, ptr).
                    ThrowIfFailed(_player, "Failed to set the media stream info");
            }
            finally
            {
                MediaFormat.ReleaseNativeHandle(ptr);
            }
        }

        internal override void OnAttached(Player player)
        {
            Debug.Assert(player != null);

            if (_player != null)
            {
                Log.Error(PlayerLog.Tag, "The source is has already been assigned to another player.");
                throw new InvalidOperationException("The source is has already been assigned to another player.");
            }

            AudioConfiguration?.OnPlayerSet(player);
            VideoConfiguration?.OnPlayerSet(player);

            _player = player;

            SetMediaStreamInfo(StreamType.Audio, _audioMediaFormat);
            SetMediaStreamInfo(StreamType.Video, _videoMediaFormat);
        }

        internal override void OnDetached(Player player)
        {
            base.OnDetached(player);

            AudioConfiguration?.OnPlayerUnset(player);
            VideoConfiguration?.OnPlayerUnset(player);

            _player = null;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> that this source is assigned to as a source, or null if this source is not assigned.
        /// </summary>
        /// <seealso cref="Player.SetSource(MediaSource)"/>
        /// <since_tizen> 3 </since_tizen>
        public Player Player => _player;

    }
}
