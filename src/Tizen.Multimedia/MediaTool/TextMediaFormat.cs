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
    /// Represents a text media format. This class cannot be inherited.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class TextMediaFormat : MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the TextMediaFormat class with the specified mime type
        ///     and text type.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="textType">The text type of the format.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mimeType"/> or <paramref name="textType"/> is invalid (i.e. undefined value).
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public TextMediaFormat(MediaFormatTextMimeType mimeType, MediaFormatTextType textType)
            : base(MediaFormatType.Text)
        {
            if (!Enum.IsDefined(typeof(MediaFormatTextMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            if (!Enum.IsDefined(typeof(MediaFormatTextType), textType))
            {
                throw new ArgumentException($"Invalid text type value : { (int)textType }");
            }
            MimeType = mimeType;
            TextType = textType;
        }

        /// <summary>
        /// Initializes a new instance of the TextMediaFormat class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal TextMediaFormat(IntPtr handle)
            : base(MediaFormatType.Text)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            MediaFormatTextMimeType mimeType;
            MediaFormatTextType textType;

            GetInfo(handle, out mimeType, out textType);

            MimeType = mimeType;
            TextType = textType;
        }

        /// <summary>
        /// Retrieves text properties of the media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        /// <param name="mimeType">An out parameter for the mime type.</param>
        /// <param name="textType">An out parameter for the text type.</param>
        private static void GetInfo(IntPtr handle, out MediaFormatTextMimeType mimeType,
            out MediaFormatTextType textType)
        {
            int mimeTypeValue = 0;
            int textTypeValue = 0;

            int ret = Interop.MediaFormat.GetTextInfo(handle, out mimeTypeValue, out textTypeValue);

            MultimediaDebug.AssertNoError(ret);

            mimeType = (MediaFormatTextMimeType)mimeTypeValue;
            textType = (MediaFormatTextType)textTypeValue;

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatTextMimeType), mimeType),
                "Invalid text mime type!");
            Debug.Assert(Enum.IsDefined(typeof(MediaFormatTextType), textType),
                "Invalid text type!");
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Text);

            int ret = Interop.MediaFormat.SetTextMimeType(handle, (int)MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetTextType(handle, (int)TextType);
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatTextMimeType MimeType { get; }

        /// <summary>
        /// Gets the text type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatTextType TextType { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
            => $"MimeType={ MimeType.ToString() }, TextType={ TextType.ToString() }";

        /// <summary>
        /// Compares an object to an instance of <see cref="TextMediaFormat"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the formats are equal; otherwise, false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as TextMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType && TextType == rhs.TextType;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="TextMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="TextMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode() => new { MimeType, TextType }.GetHashCode();
    }
}
