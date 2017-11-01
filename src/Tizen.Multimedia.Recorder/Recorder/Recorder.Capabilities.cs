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
using System.Linq;
using Native = Interop.Recorder;
using NativeHandle = Interop.RecorderHandle;

namespace Tizen.Multimedia
{
    internal class Capabilities
    {
        public IEnumerable<RecorderFileFormat> SupportedFileFormats { get; }
        public IEnumerable<RecorderAudioCodec> SupportedAudioCodecs { get; }
        public IEnumerable<RecorderVideoCodec> SupportedVideoCodecs { get; }

        private RecorderErrorCode GetAudioEncoders(NativeHandle handle, List<RecorderAudioCodec> result) =>
            Native.GetAudioEncoders(handle, (codec, _) => { result.Add(codec); return true; });

        private RecorderErrorCode GetFileFormats(NativeHandle handle, List<RecorderFileFormat> result) =>
            Native.GetFileFormats(handle, (format, _) => { result.Add(format); return true; });

        private RecorderErrorCode GetVideoEncoders(NativeHandle handle, List<RecorderVideoCodec> result) =>
            Native.GetVideoEncoders(handle, (codec, _) => { result.Add(codec); return true; });

        private static IEnumerable<T> Load<T>(NativeHandle handle, Func<NativeHandle, List<T>, RecorderErrorCode> loadFunc)
        {
            var result = new List<T>();

            var ret = loadFunc(handle, result);

            if (ret == RecorderErrorCode.NotSupported)
            {
                return null;
            }

            ret.ThrowIfError("Failed to load the capabilities");

            return result.AsReadOnly();
        }

        internal Capabilities(NativeHandle handle)
        {
            SupportedVideoCodecs = Load<RecorderVideoCodec>(handle, GetVideoEncoders);

            SupportedAudioCodecs = Load<RecorderAudioCodec>(handle, GetAudioEncoders);
            SupportedFileFormats = Load<RecorderFileFormat>(handle, GetFileFormats);
        }
    }

    /// <since_tizen> 3 </since_tizen>
    public partial class Recorder
    {
        internal static Lazy<Capabilities> Capabilities { get; } = new Lazy<Capabilities>(LoadCapabilities);

        private static Capabilities LoadCapabilities()
        {
            var ret = Native.Create(out var handle);

            if (ret == RecorderErrorCode.NotSupported)
            {
                throw new NotSupportedException("Audio recording is not supported.");
            }

            ret.ThrowIfError("Failed to load the capabilities");

            using (handle)
            {
                return new Capabilities(handle);
            }
        }

        /// <summary>
        /// Gets the file formats that the current device supports.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<RecorderFileFormat> GetSupportedFileFormats() => Capabilities.Value.SupportedFileFormats;

        /// <summary>
        /// Gets the audio encoders that the current device supports.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<RecorderAudioCodec> GetSupportedAudioCodecs() => Capabilities.Value.SupportedAudioCodecs;

        internal static void ValidateFileFormat(RecorderFileFormat format)
        {
            if (GetSupportedFileFormats().Contains(format) == false)
            {
                throw new NotSupportedException($"{format.ToString()} is not supported.");
            }
        }

        internal static void ValidateAudioCodec(RecorderAudioCodec codec)
        {
            if (GetSupportedAudioCodecs().Contains(codec) == false)
            {
                throw new NotSupportedException($"{codec.ToString()} is not supported.");
            }
        }
    }
}