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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for Audio Codec.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderAudioCodec
    {
        /// <summary>
        /// Disable Audio track.
        /// </summary>
        Disable = -1,
        /// <summary>
        /// AMR codec.
        /// </summary>
        Amr = 0,
        /// <summary>
        /// AAC codec.
        /// </summary>
        Aac,
        /// <summary>
        /// Vorbis codec.
        /// </summary>
        Vorbis,
        /// <summary>
        /// PCM codec.
        /// </summary>
        Pcm,
        /// <summary>
        /// The mp3 codec.
        /// </summary>
        Mp3
    }

    /// <summary>
    /// Enumeration for Audio capture devices.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderAudioDevice
    {
        /// <summary>
        /// Capture audio from Mic device.
        /// </summary>
        Mic,
        /// <summary>
        /// Capture audio from modem.
        /// </summary>
        Modem
    }

    /// <summary>
    /// Enumeration for the file container format.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderFileFormat
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
        Wav,
        /// <summary>
        /// OGG file format.
        /// </summary>
        Ogg,
        /// <summary>
        /// M2TS file format.
        /// </summary>
        M2ts
    }

    /// <summary>
    /// Enumeration for the recorder policy.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderPolicy
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Security policy.
        /// </summary>
        Security = 4,
        /// <summary>
        /// Resource conflict policy.
        /// </summary>
        ResourceConflict = 5
    }

    /// <summary>
    /// Enumeration for the recording limit.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecordingLimitType
    {
        /// <summary>
        /// Time limit in seconds of recording file
        /// </summary>
        Time,
        /// <summary>
        /// Size limit in KB(KiloBytes) of recording file.
        /// </summary>
        Size,
        /// <summary>
        /// No free space in storage.
        /// </summary>
        Space
    }

    /// <summary>
    /// Enumeration for recorder states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderState
    {
        /// <summary>
        /// Recorder is not created.
        /// </summary>
        None,
        /// <summary>
        /// Recorder is created, but not prepared.
        /// </summary>
        Created,
        /// <summary>
        /// Recorder is ready to record. In case of video recorder,
        /// preview display will be shown.
        /// </summary>
        Ready,
        /// <summary>
        /// Recorder is recording media.
        /// </summary>
        Recording,
        /// <summary>
        /// Recorder is paused while recording media.
        /// </summary>
        Paused
    }

    /// <summary>
    /// Enumeration for video codec.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderVideoCodec
    {
        /// <summary>
        /// H263 codec.
        /// </summary>
        H263,
        /// <summary>
        /// H264 codec.
        /// </summary>
        H264,
        /// <summary>
        /// MPEG4 codec.
        /// </summary>
        Mpeg4,
        /// <summary>
        /// Theora codec.
        /// </summary>
        Theora
    }

    /// <summary>
    /// Enumeration for recorder failure error.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RecorderErrorCode
    {
        /// <summary>
        /// Device Error.
        /// </summary>
        DeviceError = RecorderError.DeviceError,
        /// <summary>
        /// Internal error.
        /// </summary>
        InvalidOperation = RecorderError.InvalidOperation,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = RecorderError.OutOfMemory
    }
}