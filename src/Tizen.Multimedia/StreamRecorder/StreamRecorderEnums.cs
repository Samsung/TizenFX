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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for Audio Codec.
    /// </summary>
    public enum StreamRecorderAudioCodec
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
    public enum StreamRecorderFileFormat
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
    public enum StreamRecorderNotify
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// State changed noti.
        /// </summary>
        StateChanged
    }

    /// <summary>
    /// Enumeration for the recording limit type.
    /// </summary>
    public enum StreamRecordingLimitType
    {
        /// <summary>
        /// Time limit in seconds of recording file
        /// </summary>
        Time,
        /// <summary>
        /// Size limit in KB(KiloBytes) of recording file.
        /// </summary>
        Size
    }

    /// <summary>
    /// Enumeration for stream recorder states.
    /// </summary>
    public enum StreamRecorderState
    {
        /// <summary>
        /// Stream recorder is not created.
        /// </summary>
        None,
        /// <summary>
        /// Stream recorder is created, but not prepared.
        /// </summary>
        Created,
        /// <summary>
        /// Stream recorder is ready to record.
        /// </summary>
        Prepared,
        /// <summary>
        /// Stream recorder is recording pushed packet.
        /// </summary>
        Recording,
        /// <summary>
        /// Stream recorder is paused.
        /// </summary>
        Paused
    }

    /// <summary>
    /// Enumeration for video codec.
    /// </summary>
    public enum StreamRecorderVideoCodec
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
    public enum StreamRecorderSourceType
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

    /// <summary>
    /// Enumeration for video source format.
    /// </summary>
    public enum StreamRecorderVideoSourceFormat
    {
        /// <summary>
        /// Nv12 Video source format
        /// </summary>
        Nv12,
        /// <summary>
        /// Nv21 video source format
        /// </summary>
        Nv21,
        /// <summary>
        /// I420 video source format
        /// </summary>
        I420
    }

    /// <summary>
    /// Enumeration for stream recorder failure error.
    /// </summary>
    public enum StreamRecorderErrorCode
    {
        /// <summary>
        /// Sucessful.
        /// </summary>
        None = StreamRecorderError.None,
        /// <summary>
        /// Internal error.
        /// </summary>
        InvalidParameter = StreamRecorderError.InvalidParameter,
        /// <summary>
        /// Internal error.
        /// </summary>
        InvalidOperation = StreamRecorderError.InvalidOperation,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = StreamRecorderError.OutOfMemory
    }
}
