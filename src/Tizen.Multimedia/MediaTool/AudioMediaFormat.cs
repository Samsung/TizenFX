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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;
using Tizen.Internals.Errors;
using Native = Tizen.Multimedia.Interop.MediaFormat;

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
            : this(mimeType, channel, sampleRate, bit, bitRate, aacType, 0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        /// channel, sample rate, bit, bit rate, bit depth, and audio channel map.
        /// </summary>
        /// <remarks>
        /// If <paramref name="audioChannelMap"/> contains <see cref="MediaFormatAudioChannelPosition.None"/>,
        /// <paramref name="channel"/> should be set greater than 0.<br/>
        /// If <paramref name="audioChannelMap"/> contains <see cref="MediaFormatAudioChannelPosition.Mono"/>,
        /// <paramref name="channel"/> should be set 1.<br/>
        /// User can not set <see cref="MediaFormatAudioChannelPosition.None"/> with another channel positions.<br/>
        /// User can not set <see cref="MediaFormatAudioChannelPosition.Mono"/> with another channel positions.<br/>
        /// If same channel position is added in <paramref name="audioChannelMap"/> more than once, the duplicaiton will be removed.
        /// </remarks>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <param name="bitDepth">The bit depth value of the PCM audio format.</param>
        /// <param name="audioChannelMap">The loudspeaker position in PCM audio format.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mimeType"/> is invalid (i.e. undefined value).<br/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="audioChannelMap"/> is invalid or mismatched with <paramref name="channel"/> like the following:<br/>
        ///     <paramref name="audioChannelMap"/> is not matched correctly with <paramref name="channel"/>.
        ///     -or-<br/>
        ///     <paramref name="audioChannelMap"/> is set to <see cref="MediaFormatAudioChannelPosition.Invaild"/>.
        ///     -or-<br/>
        ///     <see cref="MediaFormatAudioChannelPosition.Mono"/> or <see cref="MediaFormatAudioChannelPosition.None"/> is set with another channel position.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="channel"/>, <paramref name="sampleRate"/>, <paramref name="bit"/>, or <paramref name="bitRate"/>,
        ///     <paramref name="bitDepth"/> is less than zero.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate, int bitDepth, IList<MediaFormatAudioChannelPosition> audioChannelMap)
            : this(mimeType, channel, sampleRate, bit, bitRate, MediaFormatAacType.None, bitDepth, audioChannelMap)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AudioMediaFormat class with the specified mime type,
        /// channel, sample rate, bit, bit rate, bit depth, and audio channel map.
        /// </summary>
        /// <remarks>
        /// If <paramref name="audioChannelMap"/> contains <see cref="MediaFormatAudioChannelPosition.None"/>,
        /// <paramref name="channel"/> should be set greater than 0.<br/>
        /// If <paramref name="audioChannelMap"/> contains <see cref="MediaFormatAudioChannelPosition.Mono"/>,
        /// <paramref name="channel"/> should be set 1.<br/>
        /// User can not set <see cref="MediaFormatAudioChannelPosition.None"/> with another channel positions.<br/>
        /// User can not set <see cref="MediaFormatAudioChannelPosition.Mono"/> with another channel positions.<br/>
        /// If same channel position is added in <paramref name="audioChannelMap"/> more than twice, its duplicaiton will be removed.
        /// </remarks>
        /// <param name="mimeType">The mime type of the format.</param>
        /// <param name="channel">The channel value of the format.</param>
        /// <param name="sampleRate">The sample rate value of the format.</param>
        /// <param name="bit">The bit value of the format.</param>
        /// <param name="bitRate">The bit rate value of the format.</param>
        /// <param name="aacType">The AAC bitstream format(ADIF or ADTS).</param>
        /// <param name="bitDepth">The bit depth value of the PCM audio format.</param>
        /// <param name="audioChannelMap">The loudspeaker position in PCM audio format.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mimeType"/> or <paramref name="aacType"/> is invalid (i.e. undefined value).<br/>
        ///     -or-<br/>
        ///     <paramref name="aacType"/> is not <see cref="MediaFormatAacType.None"/>, but <paramref name="mimeType"/> is one of the AAC types.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="audioChannelMap"/> is invalid or mismatched with <paramref name="channel"/> like the following:<br/>
        ///     <paramref name="audioChannelMap"/> is not matched correctly with <paramref name="channel"/>.
        ///     -or-<br/>
        ///     <paramref name="audioChannelMap"/> is set to <see cref="MediaFormatAudioChannelPosition.Invaild"/>.
        ///     -or-<br/>
        ///     <see cref="MediaFormatAudioChannelPosition.Mono"/> or <see cref="MediaFormatAudioChannelPosition.None"/> is set with another channel position.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="channel"/>, <paramref name="sampleRate"/>, <paramref name="bit"/>, or <paramref name="bitRate"/>,
        ///     <paramref name="bitDepth"/> is less than zero.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public AudioMediaFormat(MediaFormatAudioMimeType mimeType,
            int channel, int sampleRate, int bit, int bitRate, MediaFormatAacType aacType, int bitDepth, IList<MediaFormatAudioChannelPosition> audioChannelMap)
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
            if (bitDepth < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bitDepth), bitDepth,
                    "Bit depth value can't be negative.");
            }

            ValidationUtil.ValidateEnum(typeof(MediaFormatAacType), aacType, nameof(aacType));

            if (!IsAacSupportedMimeType(mimeType) && aacType != MediaFormatAacType.None)
            {
                throw new ArgumentException("Aac is supported only with aac mime types.");
            }

            MimeType = mimeType;
            AacType = aacType;
            Channel = channel;
            SampleRate = sampleRate;
            Bit = bit;
            BitRate = bitRate;
            BitDepth = bitDepth;

            if (audioChannelMap != null)
            {
                audioChannelMap = audioChannelMap.Distinct().OrderBy(p => p).ToList();

                ValidateAudioChannelMap(audioChannelMap);

                AudioChannelMap = new ReadOnlyCollection<MediaFormatAudioChannelPosition>(audioChannelMap);
            }
        }

        private void ValidateAudioChannelMap(IList<MediaFormatAudioChannelPosition> audioChannelMap)
        {
            if (audioChannelMap.Contains(MediaFormatAudioChannelPosition.Invaild))
            {
                throw new ArgumentException("Invalid channel position.", nameof(audioChannelMap));
            }

            if ((audioChannelMap.Contains(MediaFormatAudioChannelPosition.Mono) && audioChannelMap.Count > 1) ||
                (audioChannelMap.Contains(MediaFormatAudioChannelPosition.None) && audioChannelMap.Count > 1))
            {
                throw new ArgumentException($"Mono and None can not be set with another channel position.",
                    nameof(audioChannelMap));
            }

            if (audioChannelMap.Contains(MediaFormatAudioChannelPosition.None))
            {
                if (Channel <= 0)
                {
                    throw new ArgumentException($"Channel should be greater than 0 in {MediaFormatAudioChannelPosition.None}.",
                        nameof(audioChannelMap));
                }
            }
            else
            {
                if (audioChannelMap.Count != Channel)
                {
                    throw new ArgumentException("Channel should be the same with number of audioChannelMap.",
                        nameof(audioChannelMap));
                }
            }
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
            AudioChannelMap = Channel == 0 ? null : GetAudioChannelMap(handle);
        }

        private static ReadOnlyCollection<MediaFormatAudioChannelPosition> GetAudioChannelMap(IntPtr handle)
        {
            var ret = Native.GetAudioChannelMask(handle, out ulong mask);
            MultimediaDebug.AssertNoError(ret);

            var positions = new MediaFormatAudioChannelPosition[Enum.GetNames(typeof(MediaFormatAudioChannelPosition)).Length];

            ret = Native.GetChannelPositionFromMask(handle, mask, ref positions);
            MultimediaDebug.AssertNoError(ret);

            return positions == null ? null :
                new ReadOnlyCollection<MediaFormatAudioChannelPosition>(positions.Distinct().OrderBy(p => p).ToList());
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

            int ret = Native.GetAudioInfo(handle,
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

            int ret = Native.GetAudioAacType(handle, out var aacType);

            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(Enum.IsDefined(typeof(MediaFormatAacType), aacType), "Invalid aac type!");

            return aacType;
        }

        internal override void AsNativeHandle(IntPtr handle)
        {
            Debug.Assert(Type == MediaFormatType.Audio);

            int ret = Native.SetAudioMimeType(handle, MimeType);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.SetAudioChannel(handle, Channel);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.SetAudioSampleRate(handle, SampleRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.SetAudioBit(handle, Bit);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.SetAudioAverageBps(handle, BitRate);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.SetAudioAacType(handle, AacType);
            MultimediaDebug.AssertNoError(ret);

            if (AudioChannelMap != null)
            {
                ret = Native.SetAudioChannelMask(handle, GetAudioChannelMask(handle, AudioChannelMap));
                MultimediaDebug.AssertNoError(ret);
            }
        }

        private static ulong GetAudioChannelMask(IntPtr handle, IList<MediaFormatAudioChannelPosition> audioChannelMap)
        {
            int ret = Native.GetMaskFromChannelPosition(handle, audioChannelMap.ToArray(),
                out ulong mask);
            MultimediaDebug.AssertNoError(ret);

            return mask;
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
        /// Gets or sets the list of channel position value of PCM audio format.
        /// </summary>
        /// <remarks>
        /// The channel mask specifies the mapping of channels to speakers.
        /// default value is 0.
        /// </remarks>
        /// <seealso cref="Channel"/>
        /// <seealso cref="MediaFormatAudioChannelPosition"/>
        /// <since_tizen> 6 </since_tizen>
        public ReadOnlyCollection<MediaFormatAudioChannelPosition> AudioChannelMap { get; }

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
        /// Gets the bit depth value of the current format.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int BitDepth { get; }

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
        {
            var toString = $@"MimeType={ MimeType.ToString() }, Channel={ Channel.ToString() }, SampleRate={ SampleRate },
                Bit={ Bit.ToString() }, BitRate={ BitRate.ToString() }, BitDepth={ BitDepth.ToString() }, AacType={ AacType.ToString()}";

            if (AudioChannelMap != null)
            {
                toString += ", AudioChannelMap=" + $"{string.Join(",", AudioChannelMap)}";
            }

            return toString;
        }

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

            var mapCompare = true;
            // We don't care the case of both properties are null.
            if (AudioChannelMap != null && rhs.AudioChannelMap != null)
            {
                for (int i = 0; i < AudioChannelMap.Count; i++)
                {
                    mapCompare = AudioChannelMap[i].Equals(rhs.AudioChannelMap[i]);
                }
            }
            else if ((AudioChannelMap == null && rhs.AudioChannelMap != null) ||
                (AudioChannelMap != null && rhs.AudioChannelMap == null))
            {
                mapCompare = false;
            }

            return MimeType == rhs.MimeType && Channel == rhs.Channel && SampleRate == rhs.SampleRate &&
                Bit == rhs.Bit && BitRate == rhs.BitRate && BitDepth == rhs.BitDepth && AacType == rhs.AacType && mapCompare;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="AudioMediaFormat"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="AudioMediaFormat"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
            => new { MimeType, Channel, SampleRate, Bit, BitRate, BitDepth, AacType, AudioChannelMap }.GetHashCode();
    }
}
