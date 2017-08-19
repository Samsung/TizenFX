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
    internal enum MediaBufferAccessMode
    {
        Read,
        Write
    }

    internal interface IBufferOwner
    {
        bool IsBufferAccessible(object buffer, MediaBufferAccessMode accessMode);

        bool IsDisposed { get; }
    }


    internal static class BufferOwnerExtensions
    {
        internal static void ValidateBufferReadable(this IBufferOwner bufferOwner, IMediaBuffer buffer)
        {
            if (bufferOwner.IsDisposed)
            {
                throw new ObjectDisposedException(bufferOwner.GetType().Name);
            }

            if (!bufferOwner.IsBufferAccessible(buffer, MediaBufferAccessMode.Read))
            {
                throw new InvalidOperationException("The buffer is not in the readable state.");
            }
        }

        internal static void ValidateBufferWritable(this IBufferOwner bufferOwner, IMediaBuffer buffer)
        {
            if (bufferOwner.IsDisposed)
            {
                throw new ObjectDisposedException(bufferOwner.GetType().Name);
            }

            if (!bufferOwner.IsBufferAccessible(buffer, MediaBufferAccessMode.Write))
            {
                throw new InvalidOperationException("The buffer is not in writable state.");
            }
        }
    }

}
