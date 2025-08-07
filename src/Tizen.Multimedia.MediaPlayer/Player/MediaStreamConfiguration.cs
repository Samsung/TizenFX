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
using System.Diagnostics;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides a means to configure properties and handle events for <see cref="MediaStreamSource"/>.
    /// </summary>
    /// <seealso cref="MediaStreamSource"/>
    /// <since_tizen> 3 </since_tizen>
    public class MediaStreamConfiguration
    {
        private const ulong DefaultBufferMaxSize = 200000;
        private const uint DefaultBufferMinThreshold = 0;

        private readonly MediaStreamSource _owner;
        private readonly StreamType _streamType;

        private ulong _bufferMaxSize = DefaultBufferMaxSize;
        private uint _threshold = DefaultBufferMinThreshold;

        internal MediaStreamConfiguration(MediaStreamSource owner, StreamType streamType)
        {
            _owner = owner;
            _streamType = streamType;
        }

        /// <summary>
        /// Occurs when the buffer underruns or overflows.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <seealso cref="BufferMaxSize"/>
        /// <seealso cref="BufferMinThreshold"/>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MediaStreamBufferStatusChangedEventArgs> BufferStatusChanged;

        /// <summary>
        /// Occurs when the seeking is requested.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MediaStreamSeekingOccurredEventArgs> SeekingOccurred;

        /// <summary>
        /// Gets or sets the maximum size of the buffer for media stream.
        /// </summary>
        /// <value>The maximum size of the buffer in bytes. The default is 200000.</value>
        /// <remarks>If the buffer level overflows the maximum size, <see cref="BufferStatusChanged"/> will be raised with <see cref="MediaStreamBufferStatus.Overflow"/>.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaStreamSource"/> is not assigned to a player.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is zero.</exception>
        /// <seealso cref="BufferStatusChanged"/>
        /// <since_tizen> 3 </since_tizen>
        public ulong BufferMaxSize
        {
            get
            {
                return _bufferMaxSize;
            }
            set
            {
                if (_owner.Player == null)
                {
                    throw new InvalidOperationException("The source is not assigned to a player yet.");
                }

                Debug.Assert(_owner.Player.IsDisposed == false);

                if (value == 0UL)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "the buffer max size can't be zero.");
                }

                NativePlayer.SetMediaStreamBufferMaxSize(_owner.Player.Handle, _streamType, value).
                    ThrowIfFailed(_owner.Player, "Failed to set the buffer max size");

                _bufferMaxSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum threshold of the media stream buffer.
        /// </summary>
        /// <value>The minimum threshold of the buffer in percentage. The default is zero.</value>
        /// <remarks>If the buffer level drops below the threshold value, <see cref="BufferStatusChanged"/> will be raised with <see cref="MediaStreamBufferStatus.Underrun"/>.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaStreamSource"/> is not assigned to a player.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is greater than 100.</exception>
        /// <seealso cref="BufferStatusChanged"/>
        /// <since_tizen> 3 </since_tizen>
        public uint BufferMinThreshold
        {
            get
            {
                return _threshold;
            }
            set
            {
                if (_owner.Player == null)
                {
                    throw new InvalidOperationException("The source is not assigned to a player yet.");
                }

                Debug.Assert(_owner.Player.IsDisposed == false);

                if (100 < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"The threshold can't be greater than 100, but got { value }.");
                }

                NativePlayer.SetMediaStreamBufferMinThreshold(_owner.Player.Handle, _streamType, value).
                    ThrowIfFailed(_owner.Player, "Failed to set the buffer minimum threshold");

                _threshold = value;
            }
        }

        internal void OnPlayerSet(Player player)
        {
            if (_streamType == StreamType.Audio)
            {
                player.MediaStreamAudioSeekingOccurred += MediaStreamSeekingOccurred;
                player.MediaStreamAudioBufferStatusChanged += MediaStreamBufferStatusChanged;
            }
            else
            {
                player.MediaStreamVideoSeekingOccurred += MediaStreamSeekingOccurred;
                player.MediaStreamVideoBufferStatusChanged += MediaStreamBufferStatusChanged;
            }

            NativePlayer.SetMediaStreamBufferMaxSize(player.Handle, _streamType, _bufferMaxSize).
                ThrowIfFailed(player, "Failed to initialize the media stream configuration");

            NativePlayer.SetMediaStreamBufferMinThreshold(player.Handle, _streamType, _threshold).
                ThrowIfFailed(player, "Failed to initialize the media stream configuration");
        }

        internal void OnPlayerUnset(Player player)
        {
            if (_streamType == StreamType.Audio)
            {
                player.MediaStreamAudioSeekingOccurred -= MediaStreamSeekingOccurred;
                player.MediaStreamAudioBufferStatusChanged -= MediaStreamBufferStatusChanged;
            }
            else
            {
                player.MediaStreamVideoSeekingOccurred -= MediaStreamSeekingOccurred;
                player.MediaStreamVideoBufferStatusChanged -= MediaStreamBufferStatusChanged;
            }
        }

        private void MediaStreamBufferStatusChanged(object sender, MediaStreamBufferStatusChangedEventArgs e)
        {
            BufferStatusChanged?.Invoke(this, e);
        }

        private void MediaStreamSeekingOccurred(object sender, MediaStreamSeekingOccurredEventArgs e)
        {
            SeekingOccurred?.Invoke(this, e);
        }
    }
}
