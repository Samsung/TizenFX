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
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a media source using memory.
    /// </summary>
    /// <remarks>
    /// The buffer has to be filled with appropriate data which means it must be well-formatted.
    /// If you provide invalid data, you won't receive an error until <see cref="Player.Start"/> is called.
    /// </remarks>
    /// <seealso cref="Player.SetSource(MediaSource)"/>
    /// <since_tizen> 3 </since_tizen>
    public sealed class MediaBufferSource : MediaSource
    {
        private byte[] _buffer;

        /// <summary>
        /// Initializes a new instance of the MediaBufferSource class with the specified buffer length.
        /// </summary>
        /// <param name="length">The value indicating the size of the buffer.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length"/> is zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="length"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaBufferSource(int length)
        {
            if (length <= 0)
            {
                Log.Error(PlayerLog.Tag, "invalid length : " + length);
                throw new ArgumentOutOfRangeException(nameof(length), length,
                    "length can't be equal to or less than zero.");
            }
            _buffer = new byte[length];
        }

        /// <summary>
        /// Initializes a new instance of the MediaBufferSource class with the specified buffer.
        /// </summary>
        /// <param name="buffer">The source array to be copied into the buffer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaBufferSource(byte[] buffer) : this(buffer, buffer == null ? 0 : buffer.Length)
        {
        }

        //TODO remove default parameter.
        /// <summary>
        /// Initializes a new instance of the MediaBufferSource class with buffer, length, and optional offset.
        /// with the specified length and the specified offset.
        /// </summary>
        /// <param name="buffer">The source array to be copied into the buffer.</param>
        /// <param name="length">The value indicating the number of bytes to copy from the buffer.</param>
        /// <param name="offset">The value indicating the offset in the buffer of the first byte to copy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="offset"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="length"/> is equal to or less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="offset"/>+<paramref name="length"/> is greater than buffer.Length.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public MediaBufferSource(byte[] buffer, int length, int offset = 0)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset, "offset can't be less than zero.");
            }
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "length can't be equal to or less than zero.");
            }
            if (length + offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"length + offset can't be greater than the length of the { nameof(buffer) }.");
            }

            _buffer = new byte[length];

            Array.Copy(buffer, offset, _buffer, 0, length);
        }

        private MediaBufferSource()
        {
        }

        /// <summary>
        /// Creates a MediaBufferSource that wraps a byte array.
        /// </summary>
        /// <param name="buffer">The array to be wrapped.</param>
        /// <returns>A MediaBufferSource wrapping the byte array.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static MediaBufferSource Wrap(byte[] buffer)
        {
            if (buffer == null)
            {
                Log.Error(PlayerLog.Tag, "invalid buffer");
                throw new ArgumentNullException(nameof(buffer));
            }

            MediaBufferSource source = new MediaBufferSource();
            source._buffer = buffer;
            return source;
        }

        /// <summary>
        /// Gets the byte array of this buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Buffer => _buffer;

        internal override void OnAttached(Player player)
        {
            NativePlayer.SetMemoryBuffer(player.Handle, _buffer, _buffer.Length).
                ThrowIfFailed(player, "Failed to set the memory buffer");
        }
    }
}
