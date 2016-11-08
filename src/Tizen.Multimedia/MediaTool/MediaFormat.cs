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
            _type = type;
        }

        private readonly MediaFormatType _type;

        /// <summary>
        /// Gets the type of the current format.
        /// </summary>
        public MediaFormatType Type
        {
            get
            {
                return _type;
            }
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
                MediaToolDebug.AssertNoError(ret);

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

            MediaToolDebug.AssertNoError(ret);

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
        protected abstract void AsNativeHandle(IntPtr handle);
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
        /// <exception cref="System.ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        public ContainerMediaFormat(MediaFormatContainerMimeType mimeType)
            : base(MediaFormatType.Container)
        {
            if (!Enum.IsDefined(typeof(MediaFormatContainerMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            _mimeType = mimeType;
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

            MediaToolDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatContainerMimeType), mimeType),
                "Invalid container mime type!");

            _mimeType = (MediaFormatContainerMimeType)mimeType;
        }

        private readonly MediaFormatContainerMimeType _mimeType;

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        public MediaFormatContainerMimeType MimeType
        {
            get
            {
                return _mimeType;
            }
        }

        protected override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Container);

            int ret = Interop.MediaFormat.SetContainerMimeType(handle, (int)_mimeType);

            MediaToolDebug.AssertNoError(ret);
        }

        public override string ToString()
        {
            return $"[{ nameof(ContainerMediaFormat) }] MimeType : { _mimeType }";
        }

    }

    /// <summary>
    /// Represents a video media format. This class cannot be inherited.
    /// </summary>
    public sealed class VideoMediaFormat : MediaFormat
    {
        private const int DEFAULT_FRAME_RATE = 0;
        private const int DEFAULT_BIT_RATE = 0;


        /// <summary>
        /// Initializes a new instance of the VideoMediaFormat class with the specified mime type, width and height.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="width">The width value of the format.</param>
        /// <param name="height">The height value of the format</param>
        /// <exception cref="System.ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">width, or height is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height)
            : this(mimeType, width, height, DEFAULT_FRAME_RATE)
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
        /// <exception cref="System.ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">width, height or frameRate is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate)
            : this(mimeType, width, height, frameRate, DEFAULT_BIT_RATE)
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
        /// <exception cref="System.ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">width, height, frameRate or bitRate is less than zero.</exception>
        public VideoMediaFormat(MediaFormatVideoMimeType mimeType, int width, int height,
            int frameRate, int bitRate)
            : base(MediaFormatType.Video)
        {
            if (!Enum.IsDefined(typeof(MediaFormatVideoMimeType), mimeType))
            {
                throw new ArgumentException($"Invalid mime type value : { (int)mimeType }");
            }
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("Width value can't be less than zero.");
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("Height value can't be less than zero.");
            }
            if (frameRate < 0)
            {
                throw new ArgumentOutOfRangeException("Frame rate can't be less than zero.");
            }
            if (bitRate < 0)
            {
                throw new ArgumentOutOfRangeException("Bit rate value can't be less than zero.");
            }

            _mimeType = mimeType;
            _width = width;
            _height = height;
            _frameRate = frameRate;
            _bitRate = bitRate;
        }

        /// <summary>
        /// Initializes a new instance of the VideoMediaForma class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal VideoMediaFormat(IntPtr handle)
            : base(MediaFormatType.Video)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            GetInfo(handle, out _width, out _height, out _bitRate, out _mimeType);

            GetFrameRate(handle, out _frameRate);
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

            MediaToolDebug.AssertNoError(ret);

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

            MediaToolDebug.AssertNoError(ret);
        }

        protected override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Video);

            int ret = Interop.MediaFormat.SetVideoMimeType(handle, (int)_mimeType);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoWidth(handle, _width);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoHeight(handle, _height);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoAverageBps(handle, _bitRate);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetVideoFrameRate(handle, _frameRate);
            MediaToolDebug.AssertNoError(ret);
        }

        private readonly MediaFormatVideoMimeType _mimeType;

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        public MediaFormatVideoMimeType MimeType
        {
            get
            {
                return _mimeType;
            }
        }

        private readonly int _width;

        /// <summary>
        /// Gets the width value of the current format.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        private readonly int _height;

        /// <summary>
        /// Gets the width value of the current format.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        private readonly int _frameRate;

        /// <summary>
        /// Gets the frame rate value of the current format.
        /// </summary>
        public int FrameRate
        {
            get
            {
                return _frameRate;
            }
        }

        private readonly int _bitRate;

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        public int BitRate
        {
            get
            {
                return _bitRate;
            }
        }

        public override string ToString()
        {
            return $"[{ nameof(VideoMediaFormat) }] MimeType : { _mimeType }, Width : { _width }, "
                +  $"Height : { _height }, FrameRate : { _frameRate }, BitRate : { _bitRate }";
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
        /// <exception cref="System.ArgumentException">mimeType is invalid(i.e. undefined value).</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
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
        /// <exception cref="System.ArgumentException">
        ///     mimeType or aacType is invalid(i.e. undefined value).
        ///     <para>- or -</para>
        ///     aacType is not <see cref="MediaFormatAacType.None"/>, but mimeType is one of aac types.
        ///     </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
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

            _mimeType = mimeType;
            _channel = channel;
            _sampleRate = sampleRate;
            _bit = bit;
            _bitRate = bitRate;
            _aacType = aacType;
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal AudioMediaFormat(IntPtr handle)
            : base(MediaFormatType.Audio)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            GetInfo(handle, out _mimeType, out _channel, out _sampleRate, out _bit, out _bitRate);

            if (IsAacSupportedMimeType(_mimeType))
            {
                GetAacType(handle, out _aacType);
            }
            else
            {
                _aacType = MediaFormatAacType.None;
            }

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

            MediaToolDebug.AssertNoError(ret);

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

            MediaToolDebug.AssertNoError(ret);

            aacType = (MediaFormatAacType)aacTypeValue;

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAacType), aacType), "Invalid aac type!");
        }

        protected override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Audio);

            int ret = Interop.MediaFormat.SetAudioMimeType(handle, (int)_mimeType);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioChannel(handle, _channel);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioSampleRate(handle, _sampleRate);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioBit(handle, _bit);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAverageBps(handle, _bitRate);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAacType(handle, (int)_aacType);
            MediaToolDebug.AssertNoError(ret);
        }

        private readonly MediaFormatAudioMimeType _mimeType;

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        public MediaFormatAudioMimeType MimeType
        {
            get
            {
                return _mimeType;
            }
        }

        private readonly int _channel;

        /// <summary>
        /// Gets the channel value of the current format.
        /// </summary>
        public int Channel
        {
            get
            {
                return _channel;
            }
        }

        private readonly int _sampleRate;

        /// <summary>
        /// Gets the sample rate value of the current format.
        /// </summary>
        public int SampleRate
        {
            get
            {
                return _sampleRate;
            }
        }

        private readonly int _bit;

        /// <summary>
        /// Gets the bit value of the current format.
        /// </summary>
        public int Bit
        {
            get
            {
                return _bit;
            }
        }

        private readonly int _bitRate;

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        public int BitRate
        {
            get
            {
                return _bitRate;
            }
        }

        private readonly MediaFormatAacType _aacType;

        /// <summary>
        /// Gets the aac type of the current format.
        /// </summary>
        public MediaFormatAacType AacType
        {
            get
            {
                return _aacType;
            }
        }

        public override string ToString()
        {
            return $"[{ nameof(AudioMediaFormat) }] MimeType : { _mimeType }, Channel : { _channel }, "
                + $"SampleRate : { _sampleRate }, Bit : { _bit }, BitRate : { _bitRate }, AacType : { _aacType }";
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
        /// <exception cref="System.ArgumentException">
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
            _mimeType = mimeType;
            _textType = textType;
        }

        /// <summary>
        /// Initializes a new instance of the TextMediaFormat class from a native handle.
        /// </summary>
        /// <param name="handle">A native handle.</param>
        internal TextMediaFormat(IntPtr handle)
            : base(MediaFormatType.Text)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            GetInfo(handle, out _mimeType, out _textType);
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

            MediaToolDebug.AssertNoError(ret);

            mimeType = (MediaFormatTextMimeType)mimeTypeValue;
            textType = (MediaFormatTextType)textTypeValue;

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatTextMimeType), mimeType),
                "Invalid text mime type!");
            Debug.Assert(Enum.IsDefined(typeof(MediaFormatTextType), textType),
                "Invalid text type!");
        }

        protected override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Text);

            int ret = Interop.MediaFormat.SetTextMimeType(handle, (int)_mimeType);
            MediaToolDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetTextType(handle, (int)_textType);
            MediaToolDebug.AssertNoError(ret);
        }

        private readonly MediaFormatTextMimeType _mimeType;

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        public MediaFormatTextMimeType MimeType
        {
            get
            {
                return _mimeType;
            }
        }

        private readonly MediaFormatTextType _textType;

        /// <summary>
        /// Gets the text type of the current format.
        /// </summary>
        public MediaFormatTextType TextType
        {
            get
            {
                return _textType;
            }
        }

        public override string ToString()
        {
            return $"[{ nameof(TextMediaFormat) }] MimeType : { _mimeType }, TextType : { _textType }";
        }
    }
}
