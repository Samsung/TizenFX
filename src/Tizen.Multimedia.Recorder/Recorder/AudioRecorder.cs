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
using Native = Interop.Recorder;
using NativeHandle = Interop.RecorderHandle;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control audio recording.
    /// </summary>
    public class AudioRecorder : Recorder
    {
        private static NativeHandle CreateHandle()
        {
            Native.Create(out var handle).ThrowIfError("Failed to create Audio recorder");

            return handle;
        }

        private static void ThrowIfCodecAndFormatNotValid(RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat)
        {
            if (audioCodec == RecorderAudioCodec.None)
            {
                throw new ArgumentOutOfRangeException(nameof(audioCodec),
                    "RecorderAudioCodec.None is only available with VideoRecorder.");
            }

            audioCodec.ThrowIfFormatNotSupported(fileFormat);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecorder"/> class with the specified audio codec and file format.
        /// </summary>
        /// <param name="audioCodec">The codec for audio encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <exception cref="InvalidOperationException">An internal error occurred.</exception>
        /// <exception cref="NotSupportedException">
        ///     A required feature is not supported.\n
        ///     -or-\n
        ///     <paramref name="audioCodec"/> is not supported.\n
        ///     -or-\n
        ///     <paramref name="fileFormat"/> is not supported with the specified audio codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="audioCodec"/> is not valid.\n
        ///     -or-\n
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="audioCodec"/> is <see cref="RecorderAudioCodec.None"/>
        /// </exception>
        /// <seealso cref="Recorder.GetSupportedAudioCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderAudioCodec)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderAudioCodec, RecorderFileFormat)"/>
        public AudioRecorder(RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat) : base(CreateHandle())
        {
            SetFormatAndCodec(audioCodec, fileFormat);
        }

        /// <summary>
        /// Sets the audio codec and the file format for recording.
        /// </summary>
        /// <param name="audioCodec">The codec for audio encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="audioCodec"/> is not supported.\n
        ///     -or-\n
        ///     <paramref name="fileFormat"/> is not supported with the specified audio codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="audioCodec"/> is not valid.\n
        ///     -or-\n
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="audioCodec"/> is <see cref="RecorderAudioCodec.None"/>
        /// </exception>
        /// <seealso cref="Recorder.GetSupportedAudioCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderAudioCodec)"/>
        /// <seealso cref="Recorder.Start(string)"/>
        public void SetFormatAndCodec(RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat)
        {
            ThrowIfCodecAndFormatNotValid(audioCodec, fileFormat);

            AudioCodec = audioCodec;
            FileFormat = fileFormat;
        }
    }
}