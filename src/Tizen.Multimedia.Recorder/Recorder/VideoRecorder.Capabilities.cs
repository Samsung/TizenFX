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
using System.Diagnostics;
using System.Linq;
using Native = Interop.Recorder;
using NativeHandle = Interop.RecorderHandle;

namespace Tizen.Multimedia
{
    public partial class VideoRecorder
    {
        private static IEnumerable<Size> _frontResolutions;
        private static IEnumerable<Size> _rearResolutions;

        private static IEnumerable<Size> GetVideoResolutions(NativeHandle handle)
        {
            var result = new List<Size>();

            var ret = Native.GetVideoResolutions(handle, (w, h, _) => { result.Add(new Size(w, h)); return true; });

            if (ret == RecorderErrorCode.NotSupported)
            {
                throw new NotSupportedException("Video recording is not supported.");
            }

            ret.ThrowIfError("Failed to load the resolutions");

            return result.AsReadOnly();
        }

        private static IEnumerable<Size> LoadVideoResolutions(CameraDevice device)
        {
            using (var camera = new Camera(device))
            {
                Native.CreateVideo(camera.Handle, out var handle).ThrowIfError("Failed to get the resolutions");

                using (handle)
                {
                    return GetVideoResolutions(handle);
                }
            }
        }

        /// <summary>
        /// Gets the video resolutions that the current device supports.
        /// </summary>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <param name="device">The camera device to retrieve the supported resolutions</param>
        /// <exception cref="NotSupportedException">A required feature is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="device"/> is invalid.</exception>
        public static IEnumerable<Size> GetSupportedVideoResolutions(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            if (device == CameraDevice.Front)
            {
                return _frontResolutions ?? (_frontResolutions = LoadVideoResolutions(CameraDevice.Front));
            }

            if (device == CameraDevice.Front)
            {
                return _rearResolutions ?? (_rearResolutions = LoadVideoResolutions(CameraDevice.Rear));
            }

            Debug.Fail($"No cache for {device}.");

            return LoadVideoResolutions(device);
        }

        /// <summary>
        /// Gets the video encoders that the current device supports.
        /// </summary>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <exception cref="NotSupportedException">A required feature is not supported.</exception>
        public static IEnumerable<RecorderVideoCodec> GetSupportedVideoCodecs()
            => Capabilities.Value.SupportedVideoCodecs ?? throw new NotSupportedException("Video recording is not supported.");

        internal static void ValidateVideoCodec(RecorderVideoCodec codec)
        {
            if (GetSupportedVideoCodecs().Contains(codec) == false)
            {
                throw new NotSupportedException($"{codec.ToString()} is not supported.");
            }
        }
    }
}