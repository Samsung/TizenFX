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
    public interface IReadOnlyBuffer
    {
        /// <summary>
        /// Gets or sets a value at the specified index.
        /// </summary>
        /// <param name="index">The index of the value to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than zero.
        ///     <para>-or-</para>
        ///     index is equal to or greater than <see cref="Length"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>
        byte this[int index]
        {
            get;
        }
        /// <summary>
        /// Gets the size of the buffer, in bytes.
        /// </summary>
        int Length
        {
            get;
        }

        /// <summary>
        /// Copies data from a byte array to the buffer.
        /// </summary>
        /// <param name="source">The array to copy from.</param>
        /// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
        /// <param name="length">The number of array elements to copy.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        void CopyTo(byte[] dest, int startIndex, int length);

        /// <summary>
        /// Copies data from a byte array to the buffer.
        /// </summary>
        /// <param name="source">The array to copy from.</param>
        /// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
        /// <param name="length">The number of array elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex, offset or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        void CopyTo(byte[] dest, int startIndex, int length, int offset);
    }

    public interface IMediaBuffer : IReadOnlyBuffer
    {
        /// <summary>
        /// Gets or sets a value at the specified index.
        /// </summary>
        /// <param name="index">The index of the value to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than zero.
        ///     <para>-or-</para>
        ///     index is equal to or greater than <see cref="Length"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>
        byte this[int index]
        {
            get;
            set;
        }
        /// <summary>
        /// Copies data from the buffer to a byte array.
        /// </summary>
        /// <param name="dest">The array to copy to.</param>
        /// <param name="startIndex">The zero-based index in the dest array where copying should start.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>

        void CopyFrom(byte[] source, int startIndex, int length);

        /// <summary>
        /// Copies data from the buffer to a byte array.
        /// </summary>
        /// <param name="dest">The array to copy to.</param>
        /// <param name="startIndex">The zero-based index in the dest array where copying should start.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentOutOfRangeException">startIndex, offset or length is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer already has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>
        void CopyFrom(byte[] source, int startIndex, int length, int offset);

    }

    /// <summary>
    /// Represents a buffer for a <see cref="MediaPacket"/>.
    /// </summary>
    internal class DependentMediaBuffer : IMediaBuffer
    {
        private readonly IBufferOwner _owner;
        private readonly IntPtr _dataHandle;

        internal DependentMediaBuffer(IBufferOwner owner, IntPtr dataHandle, int size)
        {
            Debug.Assert(owner != null, "Owner is null!");
            Debug.Assert(!owner.IsDisposed, "Owner has been already disposed!");
            Debug.Assert(dataHandle != IntPtr.Zero, "dataHandle is null!");
            Debug.Assert(size >= 0, "size must not be negative!");

            _owner = owner;
            _dataHandle = dataHandle;
            Length = size;
        }

        public byte this[int index]
        {
            get
            {
                _owner.ValidateBufferReadable(this);

                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException($"Valid index range is [0, { nameof(Length) }).");
                }

                return Marshal.ReadByte(_dataHandle, index);
            }
            set
            {
                _owner.ValidateBufferWritable(this);

                Marshal.WriteByte(_dataHandle, index, value);
            }
        }

        /// <summary>
        /// Validates the range
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     offset + length is greater than <see cref="Length"/>.
        ///     <para>-or-</para>
        ///     offset or length is less than zero.
        /// </exception>
        private void ValidateRange(int offset, int length)
        {
            if (offset + length > Length)
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

        public void CopyFrom(byte[] source, int startIndex, int length, int offset)
        {
            _owner.ValidateBufferReadable(this);

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

        public void CopyFrom(byte[] source, int startIndex, int length)
        {
            CopyFrom(source, startIndex, length, 0);
        }

         public void CopyTo(byte[] dest, int startIndex, int length, int offset)
        {
            _owner.ValidateBufferWritable(this);

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

        public void CopyTo(byte[] dest, int startIndex, int length)
        {
            CopyTo(dest, startIndex, length, 0);
        }

        public int Length { get; }
    }
}
