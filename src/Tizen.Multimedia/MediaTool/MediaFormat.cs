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

    /// <summary>
    /// Represents a container media format. This class cannot be inherited.
    /// </summary>
    public sealed class ContainerMediaFormat : MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the ContainerMediaFormat class.
        /// </summary>
        /// <param name="mimeType">The mime type of the container format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
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
        public MediaFormatContainerMimeType MimeType
        {
            get;
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Container);

            int ret = Interop.MediaFormat.SetContainerMimeType(handle, (int)MimeType);

            MultimediaDebug.AssertNoError(ret);
        }

        public override string ToString()
        {
            return $"MimeType={ MimeType.ToString() }";
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as ContainerMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType;
        }

        public override int GetHashCode()
        {
            return (int)MimeType;
        }
    }

    /// <summary>
    /// Represents a video media format. This class cannot be inherited.
    /// </summary>
    public sealed class VideoMediaFormat : MediaFormat
    {
        private const int DefaultFrameRate = 0;
        private const int DefaultBitRate = 0;

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type, width and height.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, or height is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height)
            : this(mimeType, width, height, DefaultFrameRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type, width and height.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The size of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, or height is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size)
            : this(mimeType, size, DefaultFrameRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height and frame rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, height or frameRate is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate)
            : this(mimeType, width, height, frameRate, DefaultBitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height and frame rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The video size of the format.</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, height or frameRate is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, Size size,
            int frameRate)
            : this(mimeType, size, frameRate, DefaultBitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, frame rate and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, height, frameRate or bitRate is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate, int bitRate)
            : this(mimeType, new Size(width, height), frameRate, bitRate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type,
        /// width, height, frame rate and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="size">The size of the format.</param>
        /// <param name="frameRate">The frame rate of the format.</param>
        /// <param name="bitRate">The bit rate of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">width, height, frameRate or bitRate is less than zero.</exception>
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
        /// Retrieves video properties of media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that properties are retrieved from.</param>
        /// <param name="width">An out parameter for width.</param>
        /// <param name="height">An out parameter for height.</param>
        /// <param name="bitRate">An out parameter for bit rate.</param>
        /// <param name="mimeType">An out parameter for mime type.</param>
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
        /// <param name="handle">A native handle that properties are retrieved from.</param>
        /// <param name="frameRate">An out parameter for frame rate.</param>
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
        public MediaFormatVideoMimeType MimeType { get; }

        /// <summary>
        /// Gets the size of the current format.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Gets the frame rate value of the current format.
        /// </summary>
        public int FrameRate { get; }

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        public int BitRate { get; }

        public override string ToString()
        {
            return $@"MimeType={ MimeType.ToString() }, Size=({ Size.ToString() }), FrameRate=
                { FrameRate.ToString() }, BitRate={ BitRate.ToString() }";
        }

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

        public override int GetHashCode()
        {
            return new { MimeType, Size, FrameRate, BitRate }.GetHashCode();
        }
    }

    /// <summary>
    /// Represents an audio media format. This class cannot be inherited.
    /// </summary>
    public sealed class AudioMediaFormat : MediaFormat
    {

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        ///     channel, sample rate, bit and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <exception cref="ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///                     channel, sampleRate, bit or bitRate is less than zero.</exception>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate)
        : this(mimeType, channel, sampleRate, bit, bitRate, MediaFormatAacType.None)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        ///     channel, sample rate, bit, bit rate and aac type.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <param name="aacType">The AAC bitstream format(ADIF or ADTS).</param>
        /// <exception cref="ArgumentException">
        ///     mimeType or aacType is invalid(i.e. undefined value).
        ///     <para>- or -</para>
        ///     aacType is not <see cref="MediaFormatAacType.None"/>, but mimeType is one of aac types.
        ///     </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///                     channel, sampleRate, bit or bitRate is less than zero.</exception>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate, MediaFormatAacType aacType)
            : base(MediaFormatType.Audio)
        {
            if (!Enum.IsDefined(typeof(MediaFormatAudioMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            if (channel < 0)
            {
                throw new ArgumentOutOfRangeException("Channel value can't be negative.");
            }
            if (sampleRate < 0)
            {
                throw new ArgumentOutOfRangeException("Sample rate value can't be negative.");
            }
            if (bit < 0)
            {
                throw new ArgumentOutOfRangeException("Bit value can't be negative.");
            }
            if (bitRate < 0)
            {
                throw new ArgumentOutOfRangeException("Bit rate value can't be negative.");
            }
            if (!Enum.IsDefined(typeof(MediaFormatAacType), aacType))
            {
                throw new ArgumentException($"Invalid aac type value : { (int)aacType }");
            }
            if (!IsAacSupportedMimeType(mimeType) && aacType != MediaFormatAacType.None)
            {
                throw new ArgumentException("Aac is supported only with aac mime types.");
            }

            MimeType = mimeType;
            Channel = channel;
            SampleRate = sampleRate;
            Bit = bit;
            BitRate = bitRate;
            AacType = aacType;
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal AudioMediaFormat(IntPtr handle)
            : base(MediaFormatType.Audio)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            MediaFormatAudioMimeType mimeType;
            int channel = 0;
            int sampleRate = 0;
            int bit = 0;
            int bitRate = 0;
            MediaFormatAacType aacType;
            GetInfo(handle, out mimeType, out channel, out sampleRate, out bit, out bitRate);

            if (IsAacSupportedMimeType(mimeType))
            {
                GetAacType(handle, out aacType);
            }
            else
            {
                aacType = MediaFormatAacType.None;
            }

            MimeType = mimeType;
            Channel = channel;
            SampleRate = sampleRate;
            Bit = bit;
            BitRate = bitRate;
            AacType = aacType;
        }

        /// <summary>
        /// Returns an indication whether a specified mime type is a aac type.
        /// </summary>
        /// <param name="mimeType">A mime type.</param>
        private static bool IsAacSupportedMimeType(MediaFormatAudioMimeType mimeType)
        {
            return mimeType == MediaFormatAudioMimeType.AacLC ||
                mimeType == MediaFormatAudioMimeType.AacHE ||
                mimeType == MediaFormatAudioMimeType.AacHEPS;
        }

        /// <summary>
        /// Retrieves audio properties of media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that properties are retrieved from.</param>
        /// <param name="mimeType">An out parameter for mime type.</param>
        /// <param name="channel">An out parameter for channel.</param>
        /// <param name="sampleRate">An out parameter for sample rate.</param>
        /// <param name="bit">An out parameter for bit.</param>
        /// <param name="bitRate">An out parameter for bit rate.</param>
        private static void GetInfo(IntPtr handle, out MediaFormatAudioMimeType mimeType,
            out int channel, out int sampleRate, out int bit, out int bitRate)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int mimeTypeValue = 0;

            int ret = Interop.MediaFormat.GetAudioInfo(handle,
                out mimeTypeValue, out channel, out sampleRate, out bit, out bitRate);

            mimeType = (MediaFormatAudioMimeType)mimeTypeValue;

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAudioMimeType), mimeType),
                "Invalid audio mime type!");
        }

        /// <summary>
        /// Retrieves aac type value from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that properties are retrieved from.</param>
        /// <param name="aacType">An out parameter for aac type.</param>
        private static void GetAacType(IntPtr handle, out MediaFormatAacType aacType)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int aacTypeValue = 0;

            int ret = Interop.MediaFormat.GetAudioAacType(handle, out aacTypeValue);

            MultimediaDebug.AssertNoError(ret);

            aacType = (MediaFormatAacType)aacTypeValue;

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAacType), aacType), "Invalid aac type!");
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Audio);

            int ret = Interop.MediaFormat.SetAudioMimeType(handle, (int)MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioChannel(handle, Channel);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioSampleRate(handle, SampleRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioBit(handle, Bit);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAverageBps(handle, BitRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAacType(handle, (int)AacType);
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        public MediaFormatAudioMimeType MimeType { get; }

        /// <summary>
        /// Gets the channel value of the current format.
        /// </summary>
        public int Channel { get; }

        /// <summary>
        /// Gets the sample rate value of the current format.
        /// </summary>
        public int SampleRate { get; }

        /// <summary>
        /// Gets the bit value of the current format.
        /// </summary>
        public int Bit { get; }

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        public int BitRate { get; }

        /// <summary>
        /// Gets the aac type of the current format.
        /// </summary>
        public MediaFormatAacType AacType { get; }

        public override string ToString()
        {
            return $@"MimeTyp={ MimeType.ToString() }, Channel={ Channel.ToString() }, SampleRate=
                { SampleRate }, Bit={ Bit.ToString() }, BitRate={ BitRate.ToString() }, AacType={ AacType.ToString() }";
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as AudioMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType && Channel == rhs.Channel && SampleRate == rhs.SampleRate &&
                Bit == rhs.Bit && BitRate == rhs.BitRate;
        }

        public override int GetHashCode()
        {
            return new { MimeType, Channel, SampleRate, Bit, BitRate }.GetHashCode();
        }
    }

    /// <summary>
    /// Represents a text media format. This class cannot be inherited.
    /// </summary>
    public sealed class TextMediaFormat : MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the TextMediaFormat class with the specified mime type
        ///     and text type.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="textType">The text type of the format.</param>
        /// <exception cref="ArgumentException">
        ///                     mimeType or textType is invalid(i.e. undefined value).</exception>
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
        /// Retrieves text properties of media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that properties are retrieved from.</param>
        /// <param name="mimeType">An out parameter for mime type.</param>
        /// <param name="textType">An out parameter for text type.</param>
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
        public MediaFormatTextMimeType MimeType { get; }

        /// <summary>
        /// Gets the text type of the current format.
        /// </summary>
        public MediaFormatTextType TextType { get; }

        public override string ToString()
        {
            return $"MimeType={ MimeType.ToString() }, TextType={ TextType.ToString() }";
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as TextMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType && TextType == rhs.TextType;
        }

        public override int GetHashCode()
        {
            return new { MimeType, TextType }.GetHashCode();
        }
    }
}
