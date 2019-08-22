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
    /// Provides the ability to classify image objects on image source using inference engine.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ImageClassifier
    {
        /// <summary>
        /// Classifies image objects on the source image using inference engine which set by <paramref name="config"/>.<br/>
        /// Each time when DetectAsync is called, a set of the detected faces at the media source are received asynchronously.
        /// </summary>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <param name="config">The configuration of engine will be used for detecting.</param>
        /// <returns>
        /// A task that represents the asynchronous classify operation.<br/>
        /// If there's no classified image object, <see cref="FaceDetectionResult.Number"/> will be 0 and, other properties will be null.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <seealso cref="InferenceModelConfiguration"/>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<ImageClassificationResult> ClassifyAsync(MediaVisionSource source,
            InferenceModelConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var tcs = new TaskCompletionSource<ImageClassificationResult>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                InteropInference.ClassifyImage(source.Handle, config.GetHandle(), cb.Target).
                    Validate("Failed to detect face.");

                return await tcs.Task;
            }
        }

        private static InteropInference.ImageClassifedCallback GetCallback(TaskCompletionSource<ImageClassificationResult> tcs)
        {
            return (IntPtr sourceHandle, int numberOfClasses, int[] indices, string[] names, float[] confidences, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(new ImageClassificationResult(indices, names, confidences, numberOfClasses)))
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
    }
}
