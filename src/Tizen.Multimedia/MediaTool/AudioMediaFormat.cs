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
    /// Represents an audio media format. This class cannot be inherited.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class AudioMediaFormat : MediaFormat
    {
        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        /// channel, sample rate, bit, and bit rate.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <exception cref="ArgumentException"><paramref name="mimeType"/> is invalid(i.e. undefined value).</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="channel"/>, <paramref name="sampleRate"/>, <paramref name="bit"/>, or <paramref name="bitRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate)
            : this(mimeType, channel, sampleRate, bit, bitRate, MediaFormatAacType.None)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        ///     channel, sample rate, bit, bit rate, and AAC type.
        /// </summary>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <param name="aacType">The AAC bitstream format(ADIF or ADTS).</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mimeType"/> or <paramref name="aacType"/> is invalid (i.e. undefined value).<br/>
        ///     -or-<br/>
        ///     <paramref name="aacType"/> is not <see cref="MediaFormatAacType.None"/>, but <paramref name="mimeType"/> is one of the AAC types.
        ///     </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="channel"/>, <paramref name="sampleRate"/>, <paramref name="bit"/>, or <paramref name="bitRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate, MediaFormatAacType aacType)
            : base(MediaFormatType.Audio)
        {
            ValidationUtil.ValidateEnum(typeof(MediaFormatAudioMimeType), mimeType, nameof(mimeType));

            if (channel < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(channel), channel,
                    "Channel value can't be negative.");
            }
            if (sampleRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleRate), sampleRate,
                    "Sample rate value can't be negative.");
            }
            if (bit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bit), bit,
                    "Bit value can't be negative.");
            }
            if (bitRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bitRate), bitRate,
                    "Bit rate value can't be negative.");
            }

            ValidationUtil.ValidateEnum(typeof(MediaFormatAacType), aacType, nameof(aacType));

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

            GetInfo(handle, out var mimeType, out var channel, out var sampleRate, out var bit, out var bitRate);

            MimeType = mimeType;
            Channel = channel;
            SampleRate = sampleRate;
            Bit = bit;
            BitRate = bitRate;
            AacType = IsAacSupportedMimeType(mimeType) ? GetAacType(handle) : MediaFormatAacType.None;
        }

        /// <summary>
        /// Returns an indication whether a specified mime type is an AAC type.
        /// </summary>
        /// <param name="mimeType">A mime type.</param>
        private static bool IsAacSupportedMimeType(MediaFormatAudioMimeType mimeType)
        {
            return mimeType == MediaFormatAudioMimeType.AacLC ||
                mimeType == MediaFormatAudioMimeType.AacHE ||
                mimeType == MediaFormatAudioMimeType.AacHEPS;
        }

        /// <summary>
        /// Retrieves audio properties of the media format from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        /// <param name="mimeType">An out parameter for the mime type.</param>
        /// <param name="channel">An out parameter for the channel.</param>
        /// <param name="sampleRate">An out parameter for the sample rate.</param>
        /// <param name="bit">An out parameter for the bit.</param>
        /// <param name="bitRate">An out parameter for the bit rate.</param>
        private static void GetInfo(IntPtr handle, out MediaFormatAudioMimeType mimeType,
            out int channel, out int sampleRate, out int bit, out int bitRate)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Interop.MediaFormat.GetAudioInfo(handle,
                out mimeType, out channel, out sampleRate, out bit, out bitRate);

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAudioMimeType), mimeType),
                "Invalid audio mime type!");
        }

        /// <summary>
        /// Retrieves the AAC type value from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        private static MediaFormatAacType GetAacType(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero, "The handle is invalid!");

            int ret = Interop.MediaFormat.GetAudioAacType(handle, out var aacType);

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAacType), aacType), "Invalid aac type!");

            return aacType;
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Audio);

            int ret = Interop.MediaFormat.SetAudioMimeType(handle, MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioChannel(handle, Channel);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioSampleRate(handle, SampleRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioBit(handle, Bit);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAverageBps(handle, BitRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.MediaFormat.SetAudioAacType(handle, AacType);
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Gets the mime type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatAudioMimeType MimeType { get; }

        /// <summary>
        /// Gets the channel value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Channel { get; }

        /// <summary>
        /// Gets the sample rate value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int SampleRate { get; }

        /// <summary>
        /// Gets the bit value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Bit { get; }

        /// <summary>
        /// Gets the bit rate value of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BitRate { get; }

        /// <summary>
        /// Gets the AAC type of the current format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaFormatAacType AacType { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
            => $@"MimeType={ MimeType.ToString() }, Channel={ Channel.ToString() }, SampleRate=
                { SampleRate }, Bit={ Bit.ToString() }, BitRate={ BitRate.ToString() }, AacType={ AacType.ToString() }";

        /// <summary>
        /// Compares an object to an instance of <see cref="AudioMediaFormat"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the formats are equal; otherwise, false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as AudioMediaFormat;
            if (rhs == null)
            {
                return false;
            }

            return MimeType == rhs.MimeType && Channel == rhs.Channel && SampleRate == rhs.SampleRate &&
                Bit == rhs.Bit && BitRate == rhs.BitRate && AacType == rhs.AacType;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="AudioMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="AudioMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
            => new { MimeType, Channel, SampleRate, Bit, BitRate, AacType }.GetHashCode();
    }
}
