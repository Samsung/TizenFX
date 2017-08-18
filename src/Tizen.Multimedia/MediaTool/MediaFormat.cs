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
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    /// <summary>
    /// MediaFormat is a base class for media formats.
    /// </summary>
    public abstract class MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the ContainerMediaFormat class with a type.
        /// </summary>
        /// <param name="type">A type for the format.</param>
        internal MediaFormat(MediaFormatType type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets the type of the current format.
        /// </summary>
        public MediaFormatType Type
        {
            get;
        }

        /// <summary>
        /// Creates a media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        /// <returns>An object of one of subclasses of <see cref="MediaFormat"/>.</returns>
        internal static MediaFormat FromHandle(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentException("The handle value is invalid.");
            }

            int type = 0;
            int ret = Interop.MediaFormat.GetType(handle, out type);

            if (ret != (int)ErrorCode.InvalidOperation)
            {
                MultimediaDebug.AssertNoError(ret);

                switch ((MediaFormatType)type)
                {
                    case MediaFormatType.Container:
                        return new ContainerMediaFormat(handle);

                    case MediaFormatType.Video:
                        return new VideoMediaFormat(handle);

                    case MediaFormatType.Audio:
                        return new AudioMediaFormat(handle);

                    case MediaFormatType.Text:
                        return new TextMediaFormat(handle);
                }
            }

            throw new ArgumentException("looks like handle is corrupted.");
        }

        /// <summary>
        /// Create a native media format from this object.
        /// </summary>
        /// <returns>A converted native handle.</returns>
        /// <remarks>The returned handle must be destroyed using <see cref="Interop.MediaFormat.Unref(IntPtr)"/>.</remarks>
        internal IntPtr AsNativeHandle()
        {
            IntPtr handle;
            int ret = Interop.MediaFormat.Create(out handle);

            MultimediaDebug.AssertNoError(ret);

            AsNativeHandle(handle);

            return handle;
        }

        internal static void ReleaseNativeHandle(IntPtr handle)
        {
            Interop.MediaFormat.Unref(handle);
        }

        /// <summary>
        /// Fill out properties of a native media format with the current media format object.
        /// </summary>
        /// <param name="handle">A native handle to be written.</param>
        internal abstract void AsNativeHandle(IntPtr handle);
    }
}
