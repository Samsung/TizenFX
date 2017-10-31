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
    /// Represents a container media format. This class cannot be inherited.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class ContainerMediaFormat : MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the ContainerMediaFormat class.
        /// </summary>
        /// <param name="mimeType">The mime type of the container format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <since_tizen> 3 </since_tizen>
        public ContainerMediaFormat(MediaFormatContainerMimeType mimeType)
            : base(MediaFormatType.Container)
        {
            if (!Enum.IsDefined(typeof(MediaFormatContainerMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            MimeType = mimeType;
        }

        /// <summary>
        /// Initializes a new instance of the ContainerMediaFormat class from a native handle.
        /// </summary>
        /// <param name="handle">A native media format handle.</param>
        internal ContainerMediaFormat(IntPtr handle)
            : base(MediaFormatType.Container)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int mimeType = 0;

            int ret = Interop.MediaFormat.GetContainerMimeType(handle, out mimeType);

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatContainerMimeType), mimeType),
                "Invalid container mime type!");

            MimeType = (MediaFormatContainerMimeType)mimeType;
        }

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatContainerMimeType MimeType { get; }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Container);

            int ret = Interop.MediaFormat.SetContainerMimeType(handle, (int)MimeType);

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString() => $"MimeType={ MimeType.ToString() }";

        /// <summary>
        /// Compares an object to an instance of <see cref="ContainerMediaFormat"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the formats are equal; otherwise, false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as ContainerMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="ContainerMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="ContainerMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
            => (int)MimeType;
    }
}
