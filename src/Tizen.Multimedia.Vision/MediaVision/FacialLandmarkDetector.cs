/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using InteropInference = Interop.MediaVision.Inference;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect facial landmarks on image source using inference engine.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class FacialLandmarkDetector
    {
        /// <summary>
        /// Detects facial landmarks on the source image using inference engine set in <paramref name="config"/>.<br/>
        /// </summary>
        /// <remarks>
        /// To set region-of-interest area in source image, please set <see cref="InferenceModelConfiguration.Roi"/>.
        /// If not set, full image area will be used to detect facial landmark.
        /// </remarks>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <feature>http://tizen.org/feature/vision.inference.face</feature>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <param name="config">The engine's configuration that will be used for detecting.</param>
        /// <returns>
        /// A task that represents the asynchronous detect operation.<br/>
        /// If there's no detected facial landmark, the return value will be empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <seealso cref="InferenceModelConfiguration"/>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<IEnumerable<Point>> DetectAsync(MediaVisionSource source,
            InferenceModelConfiguration config)
        {
            // `vision.inference` feature is already checked, when config is created.
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceFace);

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var tcs = new TaskCompletionSource<Point[]>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                IntPtr roiUnmanaged = IntPtr.Zero;

                try
                {
                    if (config.Roi.HasValue)
                    {
                        var roi = config.Roi.Value.ToMarshalable();

                        roiUnmanaged = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(global::Interop.MediaVision.Rectangle)));
                        Marshal.WriteIntPtr(roiUnmanaged, IntPtr.Zero);
                        Marshal.StructureToPtr(roi, roiUnmanaged, false);
                    }

                    InteropInference.DetectFacialLandmark(source.Handle, config.GetHandle(), roiUnmanaged, cb.Target).
                        Validate("Failed to detect facial landmark.");
                }
                finally
                {
                    if (roiUnmanaged != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(roiUnmanaged);
                    }
                }

                return await tcs.Task;
            }
        }

        private static InteropInference.FacialLandmarkDetectedCallback GetCallback(TaskCompletionSource<Point[]> tcs)
        {
            return (IntPtr sourceHandle, int numberOfLandmarks, global::Interop.MediaVision.Point[] locations, IntPtr _) =>
            {
                try
                {
                    if (numberOfLandmarks == 0)
                    {
                        tcs.TrySetResult(null);
                    }
                    else
                    {
                        var locationResult = new Point[numberOfLandmarks];

                        for (int i = 0; i < numberOfLandmarks; i++)
                        {
                            locationResult[i] = locations[i].ToApiStruct();
                        }

                        if (!tcs.TrySetResult(locationResult))
                        {
                            Log.Error(MediaVisionLog.Tag, "Failed to set facial landmark detection result.");
                        }
                    }
                }
                catch (Exception e)
                {
                    tcs.TrySetException(e);
                }
            };
        }
    }
}
