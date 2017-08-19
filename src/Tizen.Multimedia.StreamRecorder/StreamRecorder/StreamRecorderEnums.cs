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

namespace Tizen.Multimedia
{

    /// <summary>
    /// Specifies errors for <see cref="StreamRecorder"/>/
    /// </summary>
    public enum StreamRecorderError
    {
        /// <summary>
        /// Internal error.
        /// </summary>
        InternalError = StreamRecorderErrorCode.InvalidOperation,
        /// <summary>
        /// Out of storage.
        /// </summary>
        OutOfStorage = StreamRecorderErrorCode.OutOfStorage
    }

    /// <summary>
    /// Specifies the video source formats for <see cref="StreamRecorder"/>.
    /// </summary>
    public enum StreamRecorderVideoFormat
    {
        /// <summary>
        /// Nv12 format.
        /// </summary>
        Nv12,
        /// <summary>
        /// Nv21 format.
        /// </summary>
        Nv21,
        /// <summary>
        /// I420 format.
        /// </summary>
        I420
    }

    #region Internal enums

    /// <summary>
    /// Enumeration for Audio Codec.
    /// </summary>
    internal enum StreamRecorderAudioCodec
    {
        /// <summary>
        /// AMR codec.
        /// </summary>
        Amr = 0,
        /// <summary>
        /// AAC codec.
        /// </summary>
        Aac,
        /// <summary>
        /// PCM codec.
        /// </summary>
        Pcm
    }

    /// <summary>
    /// Enumeration for the file container format.
    /// </summary>
    internal enum StreamRecorderFileFormat
    {
        /// <summary>
        /// 3GP file format.
        /// </summary>
        ThreeGp,
        /// <summary>
        /// MP4 file format.
        /// </summary>
        Mp4,
        /// <summary>
        /// AMR file format.
        /// </summary>
        Amr,
        /// <summary>
        /// ADTS file format.
        /// </summary>
        Adts,
        /// <summary>
        /// WAV file format.
        /// </summary>
        Wav
    }

    /// <summary>
    /// Enumeration for the recorder notify type.
    /// </summary>
    internal enum StreamRecorderNotify
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// State changed.
        /// </summary>
        StateChanged
    }

    /// <summary>
    /// Enumeration for video codec.
    /// </summary>
    internal enum StreamRecorderVideoCodec
    {
        /// <summary>
        /// H263 codec.
        /// </summary>
        H263,
        /// <summary>
        /// MPEG4 codec.
        /// </summary>
        Mpeg4
    }

    /// <summary>
    /// Enumeration for source type.
    /// </summary>
    internal enum StreamRecorderSourceType
    {
        /// <summary>
        /// Video source
        /// </summary>
        Video,
        /// <summary>
        /// Audio source
        /// </summary>
        Audio,
        /// <summary>
        /// Audio/Video both
        /// </summary>
        VideoAudio
    }

    internal static class StreamRecorderEnumExtensions
    {
        internal static RecorderVideoCodec ToRecorderEnum(this StreamRecorderVideoCodec value)
        {
            switch (value)
            {
                case StreamRecorderVideoCodec.H263:
                    return RecorderVideoCodec.H263;

                case StreamRecorderVideoCodec.Mpeg4:
                    return RecorderVideoCodec.Mpeg4;
            }

            Debug.Fail("Unknown video codec value.");
            return 0;
        }

        internal static StreamRecorderVideoCodec ToStreamRecorderEnum(this RecorderVideoCodec value)
        {
            switch (value)
            {
                case RecorderVideoCodec.H263:
                    return StreamRecorderVideoCodec.H263;

                case RecorderVideoCodec.Mpeg4:
                    return StreamRecorderVideoCodec.Mpeg4;
            }

            throw new NotSupportedException($"{value.ToString()} is not supported.");
        }


        internal static RecorderAudioCodec ToRecorderEnum(this StreamRecorderAudioCodec value)
        {
            switch (value)
            {
                case StreamRecorderAudioCodec.Aac:
                    return RecorderAudioCodec.Aac;

                case StreamRecorderAudioCodec.Amr:
                    return RecorderAudioCodec.Amr;

                case StreamRecorderAudioCodec.Pcm:
                    return RecorderAudioCodec.Pcm;
            }

            Debug.Fail("Unknown audio codec value.");
            return 0;
        }


        internal static StreamRecorderAudioCodec ToStreamRecorderEnum(this RecorderAudioCodec value)
        {
            switch (value)
            {
                case RecorderAudioCodec.Aac:
                    return StreamRecorderAudioCodec.Aac;

                case RecorderAudioCodec.Amr:
                    return StreamRecorderAudioCodec.Amr;

                case RecorderAudioCodec.Pcm:
                    return StreamRecorderAudioCodec.Pcm;
            }

            throw new NotSupportedException($"{value.ToString()} is not supported.");
        }


        internal static RecorderFileFormat ToRecorderEnum(this StreamRecorderFileFormat value)
        {
            switch (value)
            {
                case StreamRecorderFileFormat.ThreeGp:
                    return RecorderFileFormat.ThreeGp;

                case StreamRecorderFileFormat.Mp4:
                    return RecorderFileFormat.Mp4;

                case StreamRecorderFileFormat.Amr:
                    return RecorderFileFormat.Amr;

                case StreamRecorderFileFormat.Adts:
                    return RecorderFileFormat.Adts;

                case StreamRecorderFileFormat.Wav:
                    return RecorderFileFormat.Wav;
            }

            Debug.Fail("Unknown file format value.");
            return 0;
        }


        internal static StreamRecorderFileFormat ToStreamRecorderEnum(this RecorderFileFormat value)
        {
            switch (value)
            {
                case RecorderFileFormat.ThreeGp:
                    return StreamRecorderFileFormat.ThreeGp;

                case RecorderFileFormat.Mp4:
                    return StreamRecorderFileFormat.Mp4;

                case RecorderFileFormat.Amr:
                    return StreamRecorderFileFormat.Amr;

                case RecorderFileFormat.Adts:
                    return StreamRecorderFileFormat.Adts;

                case RecorderFileFormat.Wav:
                    return StreamRecorderFileFormat.Wav;
            }

            throw new NotSupportedException($"{value.ToString()} is not supported.");
        }
    }
    #endregion
}
