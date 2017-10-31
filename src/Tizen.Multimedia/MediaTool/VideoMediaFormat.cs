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
    /// Represents a video media format. This class cannot be inherited.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class VideoMediaFormat : MediaFormat
    {
        private const int DefaultFrameRate = 0;
        private const int DefaultBitRate = 0;

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type, width, and height.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/> or <paramref name="height"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height)
            : this(mimeType, width, height, DefaultFrameRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type and size.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The size of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">The width or the height of <paramref name="size"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size)
            : this(mimeType, size, DefaultFrameRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, and frame rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="width"/>, <paramref name="height"/>, or <paramref name="frameRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height, int frameRate)
            : this(mimeType, width, height, frameRate, DefaultBitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, and frame rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The video size of the format.</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size,
            int frameRate)
            : this(mimeType, size, frameRate, DefaultBitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, frame rate, and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="width"/>, <paramref name="height"/>, <paramref name="frameRate"/>, or <paramref name="bitRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate, int bitRate)
            : this(mimeType, new Size(width, height), frameRate, bitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// size, frame rate, and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The size of the format.</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="bitRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size,
            int frameRate, int bitRate)
            : base(MediaFormatType.Video)
        {
            if (!Enum.IsDefined(typeof(MediaFormatVideoMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            if (size.Width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Width, "Size.Width value can't be less than zero.");
            }
            if (size.Height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Height, "Size.Height value can't be less than zero.");
            }
            if (frameRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frameRate), frameRate, "Frame rate can't be less than zero.");
            }
            if (bitRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bitRate), bitRate, "Bit rate value can't be less than zero.");
            }

            MimeType = mimeType;
            Size = size;
            FrameRate = frameRate;
            BitRate = bitRate;
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaForma class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal VideoMediaFormat(IntPtr handle)
            : base(MediaFormatType.Video)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int width = 0;
            int height = 0;
            int bitRate = 0;
            int frameRate = 0;
            MediaFormatVideoMimeType mimeType;
            GetInfo(handle, out width, out height, out bitRate, out mimeType);

            GetFrameRate(handle, out frameRate);

            MimeType = mimeType;
            Size = new Size(width, height);
            FrameRate = frameRate;
            BitRate = bitRate;
        }

        /// <summary>
        /// Retrieves video properties of the media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        /// <param name="width">An out parameter for the width.</param>
        /// <param name="height">An out parameter for the height.</param>
        /// <param name="bitRate">An out parameter for the bit rate.</param>
        /// <param name="mimeType">An out parameter for the mime type.</param>
        private static void GetInfo(IntPtr handle, out int width, out int height, out int bitRate,
            out MediaFormatVideoMimeType mimeType)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int mimeTypeValue = 0;
            int maxBps = 0;

            int ret = Interop.MediaFormat.GetVideoInfo(handle,
                out mimeTypeValue, out width, out height, out bitRate, out maxBps);

            MultimediaDebug.AssertNoError(ret);

            mimeType = (MediaFormatVideoMimeType)mimeTypeValue;

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatVideoMimeType), mimeType),
                "Invalid video mime type!");
        }

        /// <summary>
        /// Retrieves frame rate from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        /// <param name="frameRate">An out parameter for the frame rate.</param>
        private static void GetFrameRate(IntPtr handle, out int frameRate)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Interop.MediaFormat.GetVideoFrameRate(handle, out frameRate);

            MultimediaDebug.AssertNoError(ret);
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Video);

            int ret = Interop.MediaFormat.SetVideoMimeType(handle, (int)MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoWidth(handle, Size.Width);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoHeight(handle, Size.Height);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoAverageBps(handle, BitRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoFrameRate(handle, FrameRate);
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatVideoMimeType MimeType { get; }

        /// <summary>
        /// Gets the size of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size Size { get; }

        /// <summary>
        /// Gets the frame rate value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int FrameRate { get; }

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BitRate { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
            => $@"MimeType={ MimeType.ToString() }, Size=({ Size.ToString() }), FrameRate=
                { FrameRate.ToString() }, BitRate={ BitRate.ToString() }";

        /// <summary>
        /// Compares an object to an instance of <see cref="VideoMediaFormat"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the formats are equal; otherwise, false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as VideoMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType && Size == rhs.Size &&
                FrameRate == rhs.FrameRate && BitRate == rhs.BitRate;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="VideoMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="VideoMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
            => new { MimeType, Size, FrameRate, BitRate }.GetHashCode();
    }
}
