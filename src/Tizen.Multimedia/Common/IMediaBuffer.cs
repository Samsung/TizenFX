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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides functionality to read and write the media buffer.
    /// </summary>
    public interface IMediaBuffer
    {
        /// <summary>
        /// Gets or sets a value at the specified index.
        /// </summary>
        /// <param name="index">The index of the value to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is less than zero.\n
        ///     -or-\n
        ///     <paramref name="index"/> is equal to or greater than <see cref="Length"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available, i.e. not writable state.</exception>
        byte this[int index]
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the size of the buffer, in bytes.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the value indicating whether the <see cref="IMediaBuffer"/> is read-only.
        /// </summary>
        /// <value> true if the <see cref="IMediaBuffer"/> is read-only; otherwise, false.</value>
        bool IsReadOnly { get; }

        /// <summary>
        /// Copies data from a byte array to the buffer.
        /// </summary>
        /// <param name="dest">The array to copy to.</param>
        /// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
        /// <param name="length">The number of array elements to copy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dest"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer has already been disposed of.</exception>
        void CopyTo(byte[] dest, int startIndex, int length);

        /// <summary>
        /// Copies data from a byte array to the buffer.
        /// </summary>
        /// <param name="dest">The array to copy to.</param>
        /// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
        /// <param name="length">The number of array elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dest"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/>, <paramref name="length"/>,
        ///     or <paramref name="offset"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer has already been disposed of.</exception>
        void CopyTo(byte[] dest, int startIndex, int length, int offset);

        /// <summary>
        /// Copies data from the buffer to a byte array.
        /// </summary>
        /// <param name="source">The array to copy from.</param>
        /// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>
        void CopyFrom(byte[] source, int startIndex, int length);

        /// <summary>
        /// Copies data from the buffer to a byte array.
        /// </summary>
        /// <param name="source">The array to copy from.</param>
        /// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <param name="offset">The zero-based index in the buffer where copying should start.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/>, <paramref name="length"/>,
        ///     or <paramref name="offset"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The object that owns the current buffer has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The buffer is not available. i.e. not writable state.</exception>
        void CopyFrom(byte[] source, int startIndex, int length, int offset);
    }
}
