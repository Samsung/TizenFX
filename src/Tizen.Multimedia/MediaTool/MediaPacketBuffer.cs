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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a buffer for a <see cref="MediaPacket"/>.
    /// </summary>
    public class MediaPacketBuffer
    {
        private readonly MediaPacket _packet;
        private readonly IntPtr _dataHandle;

        internal MediaPacketBuffer(MediaPacket packet, IntPtr dataHandle, int size)
        {
            Debug.Assert(packet != null, "Packet is null!");
            Debug.Assert(!packet.IsDisposed, "Packet is already disposed!");
            Debug.Assert(dataHandle != IntPtr.Zero, "dataHandle is null!");
            Debug.Assert(size >= 0, "size must not be negative!");

            _packet = packet;
            _dataHandle = dataHandle;
            _length = size;
        }

        /// <summary>
        /// Gets or sets a value at the specified index.
        /// </summary>
        /// <param name="index">The index of the value to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than zero.\n
        ///     -or-\n
        ///     index is equal to or greater than <see cref="Length"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The MediaPacket that owns the current buffer is being used by another module.</exception>
        public byte this[int index]
        {
            get
            {
                _packet.EnsureReadableState();

                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException($"Valid index range is [0, { nameof(Length) }).");
                }

                return Marshal.ReadByte(_dataHandle, index);
            }
            set
            {
                _packet.EnsureWritableState();

                Marshal.WriteByte(_dataHandle, index, value);
            }
        }

        /// <summary>
        /// Validates the range
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     offset + length is greater than <see cref="Length"/>.\n
        ///     -or-\n
        ///     offset or length is less than zero.
        /// </exception>
        private void ValidateRange(int offset, int length)
        {
            if (offset + length > _length)
            {
                throw new ArgumentOutOfRangeException("offset + length can't be greater than length of the buffer.");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException($"Length can't be less than zero : { length }.");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException($"Offset can't be less than zero : { offset }.");
            }
        }

        /// <summary>
        /// Copies data from a byte array to the buffer.
        /// </summary>
        /// <param name="source">The array to copy from.</param>
        /// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
        /// <param name="length">The number of array elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex, offset or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer already has been disposed of.</exception>
        public void CopyFrom(byte[] source, int startIndex, int length, int offset = 0)
        {
            _packet.EnsureReadableState();

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex can't be less than zero.");
            }
            if (startIndex + length > source.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex + length can't be greater than source.Length.");
            }

            ValidateRange(offset, length);

            Marshal.Copy(source, startIndex, IntPtr.Add(_dataHandle, offset), length);
        }

        /// <summary>
        /// Copies data from the buffer to a byte array.
        /// </summary>
        /// <param name="dest">The array to copy to.</param>
        /// <param name="startIndex">The zero-based index in the dest array where copying should start.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex, offset or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The MediaPacket that owns the current buffer is being used by another module.</exception>
        public void CopyTo(byte[] dest, int startIndex, int length, int offset = 0)
        {
            _packet.EnsureWritableState();

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Start index can't be less than zero.");
            }
            if (startIndex + length > dest.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex + length can't be greater than dest.Length.");
            }

            ValidateRange(offset, length);

            Marshal.Copy(IntPtr.Add(_dataHandle, offset), dest, startIndex, length);
        }

        private readonly int _length;

        /// <summary>
        /// Gets the size of the buffer, in bytes.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer already has been disposed of.</exception>
        public int Length
        {
            get
            {
                _packet.EnsureReadableState();

                return _length;
            }
        }
    }
}
