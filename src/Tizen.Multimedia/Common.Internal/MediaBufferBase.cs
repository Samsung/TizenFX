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
    internal abstract class MediaBufferBase : IMediaBuffer
    {
        private readonly IntPtr _dataHandle;

        public int Length { get; }

        internal MediaBufferBase(IntPtr dataHandle, int size, bool isReadOnly)
        {
            Debug.Assert(dataHandle != IntPtr.Zero, "dataHandle is null!");
            Debug.Assert(size >= 0, "size must not be negative!");

            _dataHandle = dataHandle;
            Length = size;
            IsReadOnly = false;
        }

        internal MediaBufferBase(IntPtr dataHandle, int size) :
            this(dataHandle, size, false)
        {
        }

        internal IntPtr DataHandle => _dataHandle;

        public bool IsReadOnly { get; }

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
                throw new ArgumentOutOfRangeException($"{nameof(offset)}, {nameof(length)}",
                    "offset + length can't be greater than length of the buffer.");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length,
                    $"Length can't be less than zero.");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset,
                    $"Offset can't be less than zero.");
            }
        }

        public byte this[int index]
        {
            get
            {
                ThrowIfBufferIsNotReadable();

                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index,
                        $"Valid index range is [0, { nameof(Length) }).");
                }

                return Marshal.ReadByte(DataHandle, index);
            }
            set
            {
                ThrowIfBufferIsNotWritable();

                Marshal.WriteByte(DataHandle, index, value);
            }
        }

        private void ThrowIfBufferIsNotReadable()
        {
            ValidateBufferReadable();
        }

        private void ThrowIfBufferIsNotWritable()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The buffer is read-only.");
            }

            ValidateBufferWritable();
        }

        internal abstract void ValidateBufferReadable();

        internal abstract void ValidateBufferWritable();

        public void CopyFrom(byte[] source, int startIndex, int length, int offset)
        {
            ThrowIfBufferIsNotReadable();

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex,
                    "startIndex can't be less than zero.");
            }
            if (startIndex + length > source.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)}, {nameof(length)}",
                    "startIndex + length can't be greater than source.Length.");
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
            ThrowIfBufferIsNotWritable();

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex,
                    "startIndex can't be less than zero.");
            }
            if (startIndex + length > dest.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)}, {nameof(length)}",
                    "startIndex + length can't be greater than source.Length.");
            }

            ValidateRange(offset, length);

            Marshal.Copy(IntPtr.Add(_dataHandle, offset), dest, startIndex, length);
        }

        public void CopyTo(byte[] dest, int startIndex, int length)
        {
            CopyTo(dest, startIndex, length, 0);
        }
    }
}
