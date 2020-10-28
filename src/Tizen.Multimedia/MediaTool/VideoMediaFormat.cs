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
        private const int DefaultMaxBps = 0;

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
            : this(mimeType, width, height, frameRate, bitRate, DefaultMaxBps)
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
            : this (mimeType, size, frameRate, bitRate, DefaultMaxBps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, frame rate, bit rate and max bps.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <param name="maxBps">The max bps of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="width"/>, <paramref name="height"/>, <br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/>, or <paramref name="bitRate"/>, or <paramref name="maxBps"/> is less than zero.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate, int bitRate, int maxBps)
            : this(mimeType, new Size(width, height), frameRate, bitRate, maxBps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// size, frame rate, bit rate and max bps.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The size of the format.</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <param name="maxBps">The max bps of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid (i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="bitRate"/> is less than zero.
        ///     -or-<br/>
        ///     <paramref name="maxBps"/> is less than zero.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size, int frameRate, int bitRate, int maxBps)
            : base(MediaFormatType.Video)
        {
            ValidationUtil.ValidateEnum(typeof(MediaFormatVideoMimeType), mimeType, nameof(mimeType));

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
            if (maxBps < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxBps), maxBps, "Max bps value can't be less than zero.");
            }

            MimeType = mimeType;
            Size = size;
            FrameRate = frameRate;
            BitRate = bitRate;
            MaxBps = maxBps;
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaForma class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal VideoMediaFormat(IntPtr handle)
            : base(MediaFormatType.Video)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Interop.MediaFormat.GetVideoInfo(handle,
                out var mimeType, out var width, out var height, out var bitRate, out var maxBps);

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatVideoMimeType), mimeType),
                "Invalid video mime type!");

            ret = Interop.MediaFormat.GetVideoFrameRate(handle, out var frameRate);

            MultimediaDebug.AssertNoError(ret);

            MimeType = mimeType;
            Size = new Size(width, height);
            FrameRate = frameRate;
            BitRate = bitRate;
            MaxBps = maxBps;
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Video);

            int ret = Interop.MediaFormat.SetVideoMimeType(handle, MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoWidth(handle, Size.Width);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoHeight(handle, Size.Height);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoAverageBps(handle, BitRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoFrameRate(handle, FrameRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoMaxBps(handle, MaxBps);
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
        /// Gets the max bps value of the current format.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int MaxBps { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
            => $@"MimeType={ MimeType.ToString() }, Size=({ Size.ToString() }), FrameRate=
                { FrameRate.ToString() }, BitRate={ BitRate.ToString() }, MaxBps = { MaxBps.ToString() }";

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
                FrameRate == rhs.FrameRate && BitRate == rhs.BitRate && MaxBps == rhs.MaxBps;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="VideoMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="VideoMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
            => new { MimeType, Size, FrameRate, BitRate, MaxBps }.GetHashCode();
    }
}
