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
        ///     <paramref name="mimeType"/> or <paramref name="aacType"/> is invalid (i.e. undefined value).\n
        ///     -or-\n
        ///     <paramref name="aacType"/> is not <see cref="MediaFormatAacType.None"/>, but <paramref name="mimeType"/> is one of the AAC types.
        ///     </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="channel"/>, <paramref name="sampleRate"/>, <paramref name="bit"/>, or <paramref name="bitRate"/> is less than zero.
        /// </exception>
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

            int mimeTypeValue = 0;

            int ret = Interop.MediaFormat.GetAudioInfo(handle,
                out mimeTypeValue, out channel, out sampleRate, out bit, out bitRate);

            mimeType = (MediaFormatAudioMimeType)mimeTypeValue;

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAudioMimeType), mimeType),
                "Invalid audio mime type!");
        }

        /// <summary>
        /// Retrieves the AAC type value from a native handle.
        /// </summary>
        /// <param name="handle">A native handle that the properties are retrieved from.</param>
        /// <param name="aacType">An out parameter for tha AAC type.</param>
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
        /// Gets the AAC type of the current format.
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
}
