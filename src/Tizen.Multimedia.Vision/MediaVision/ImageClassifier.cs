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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using InteropInference = Interop.MediaVision.Inference;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to classify image objects on image source using inference engine.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ImageClassifier
    {
        /// <summary>
        /// Classifies image objects on the source image using inference engine set in <paramref name="config"/>.<br/>
        /// Each time when DetectAsync is called, a set of the detected faces at the media source are received asynchronously.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <feature>http://tizen.org/feature/vision.inference.image</feature>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <param name="config">The engine's configuration that will be used for classifying.</param>
        /// <returns>
        /// A task that represents the asynchronous classify operation.<br/>
        /// If there's no classified image object, empty collection will be returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <seealso cref="InferenceModelConfiguration"/>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<IEnumerable<ImageClassificationResult>> ClassifyAsync(MediaVisionSource source,
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

            var tcs = new TaskCompletionSource<IEnumerable<ImageClassificationResult>>();

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

                    InteropInference.ClassifyImage(source.Handle, config.GetHandle(), roiUnmanaged, cb.Target).
                        Validate("Failed to classify image.");
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

        private static InteropInference.ImageClassifedCallback GetCallback(TaskCompletionSource<IEnumerable<ImageClassificationResult>> tcs)
        {
            return (IntPtr sourceHandle, int numberOfClasses, int[] indices, string[] names, float[] confidences, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(GetResults(numberOfClasses, indices, names, confidences)))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set image classification result.");
                    }
                }
                catch (Exception e)
                {
                    tcs.TrySetException(e);
                }
            };
        }

        private static IEnumerable<ImageClassificationResult> GetResults(int number, int[] indices,
            string[] names, float[] confidences)
        {
            if (number == 0)
            {
                return Enumerable.Empty<ImageClassificationResult>();
            }

            var results = new List<ImageClassificationResult>();

            for (int i = 0; i < number; i++)
            {
                results.Add(new ImageClassificationResult(indices[i], names[i], confidences[i]));
            }

            return results;
        }
    }
}
