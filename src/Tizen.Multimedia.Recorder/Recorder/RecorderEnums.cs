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
    /// Specifies audio codecs for <see cref="Recorder"/>.
    /// </summary>
    /// <seealso cref="Recorder.GetSupportedAudioCodecs"/>
    public enum RecorderAudioCodec
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        None = -1,
        /// <summary>
        /// AMR codec.
        /// </summary>
        Amr,
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
    /// Specifies audio capture devices for <see cref="Recorder"/>.
    /// </summary>
    public enum RecorderAudioDevice
    {
        /// <summary>
        /// Capture audio from the Mic device.
        /// </summary>
        Mic,
        /// <summary>
        /// Capture audio from the modem.
        /// </summary>
        Modem
    }

    /// <summary>
    /// Specifies container formats for <see cref="Recorder"/>.
    /// </summary>
    /// <seealso cref="Recorder.GetSupportedFileFormats"/>
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
    /// Specifies recorder policies.
    /// </summary>
    /// <seealso cref="Recorder.StateChanged"/>
    /// <seealso cref="Recorder.Interrupting"/>
    /// <seealso cref="Recorder.Interrupted"/>
    public enum RecorderPolicy
    {
        /// <summary>
        /// Security policy.
        /// </summary>
        Security = 4,
        /// <summary>
        /// Resource conflict policy.
        /// </summary>
        ResourceConflict
    }

    /// <summary>
    /// Specifies types of the recording limit for <see cref="Recorder"/>.
    /// </summary>
    /// <seealso cref="Recorder.SizeLimit"/>
    /// <seealso cref="Recorder.TimeLimit"/>
    /// <seealso cref="Recorder.RecordingLimitReached"/>
    public enum RecordingLimitType
    {
        /// <summary>
        /// Time limit in seconds of the recording file
        /// </summary>
        Time,
        /// <summary>
        /// Size limit in KB(KiloBytes) of the recording file.
        /// </summary>
        Size,
        /// <summary>
        /// No free space in the storage.
        /// </summary>
        Space
    }

    /// <summary>
    /// Specifies states for <see cref="Recorder"/>.
    /// </summary>
    public enum RecorderState
    {
        /// <summary>
        /// Recorder is created, but not prepared.
        /// </summary>
        Idle = 1,
        /// <summary>
        /// Recorder is ready to record. In case of a video recorder,
        /// preview display will be shown.
        /// </summary>
        Ready,
        /// <summary>
        /// Recorder is recording the media.
        /// </summary>
        Recording,
        /// <summary>
        /// Recorder is paused while recording the media.
        /// </summary>
        Paused
    }

    /// <summary>
    /// Specifies video codecs for <see cref="VideoRecorder"/>.
    /// </summary>
    /// <seealso cref="VideoRecorder.GetSupportedVideoCodecs"/>
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
    /// Specifies errors for <see cref="Recorder"/>.
    /// </summary>
    /// <seealso cref="Recorder.ErrorOccurred"/>
    public enum RecorderError
    {
        /// <summary>
        /// ESD situation.
        /// </summary>
        Esd = RecorderErrorCode.Esd,

        /// <summary>
        /// Device Error.
        /// </summary>
        DeviceError = RecorderErrorCode.DeviceError,

        /// <summary>
        /// Internal error.
        /// </summary>
        InternalError = RecorderErrorCode.InvalidOperation,

        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = RecorderErrorCode.OutOfMemory,

        /// <summary>
        /// Out of storage or the storage has been removed while recording.
        /// </summary>
        OutOfStorage = RecorderErrorCode.OutOfStorage
    }

    /// <summary>
    /// Specifies recorder types for <see cref="Recorder.DeviceStateChanged"/>.
    /// </summary>
    public enum RecorderType
    {
        /// <summary>
        /// Audio recorder.
        /// </summary>
        Audio,

        /// <summary>
        /// Video recorder.
        /// </summary>
        Video
    }

    /// <summary>
    /// Specifies recorder device states for <see cref="Recorder.DeviceStateChanged"/>.
    /// </summary>
    public enum RecorderDeviceState
    {
        /// <summary>
        /// No recording in progress.
        /// </summary>
        Idle,

        /// <summary>
        /// Recording in progress.
        /// </summary>
        Recording,

        /// <summary>
        /// All recordings are paused.
        /// </summary>
        Paused
    }
}