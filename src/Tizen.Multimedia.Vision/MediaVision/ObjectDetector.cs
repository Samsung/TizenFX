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
using System.Threading.Tasks;
using InteropInference = Interop.MediaVision.Inference;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect objects and get its locations on image source using inference engine.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ObjectDetector
    {
        /// <summary>
        /// Detects objects and gets its locations on the source image using inference engine set in <paramref name="config"/>.<br/>
        /// Each time when DetectAsync is called, a set of the detected objects at the media source are received asynchronously.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <feature>http://tizen.org/feature/vision.inference.image</feature>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <param name="config">The engine's configuration that will be used for detecting.</param>
        /// <returns>
        /// A task that represents the asynchronous detect operation.<br/>
        /// If there's no detected object, <see cref="ObjectDetectionResult.Number"/> will be 0 and other properties will be empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <seealso cref="InferenceModelConfiguration"/>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<ObjectDetectionResult> DetectAsync(MediaVisionSource source,
            InferenceModelConfiguration config)
        {
            // `vision.inference` feature is already checked, when config is created.
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceImage);

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var tcs = new TaskCompletionSource<ObjectDetectionResult>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                InteropInference.DetectObject(source.Handle, config.GetHandle(), cb.Target).
                    Validate("Failed to detect object.");

                return await tcs.Task;
            }
        }

        private static InteropInference.ObjectDetectedCallback GetCallback(TaskCompletionSource<ObjectDetectionResult> tcs)
        {
            return (IntPtr sourceHandle, int numberOfObjects, int[] indices, string[] names, float[] confidences,
                global::Interop.MediaVision.Rectangle[] locations, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(new ObjectDetectionResult(indices, names, confidences, locations,
                        numberOfObjects)))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set object detection result.");
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
