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
using System.Threading.Tasks;
using InteropFace = Interop.MediaVision.Face;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to detect faces on image sources.
    /// </summary>
    public static class FaceDetector
    {

        /// <summary>
        /// Detects faces on the source.\n
        /// Each time when DetectAsync is called, a set of the detected faces at the media source are received asynchronously.
        /// </summary>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <returns>A task that represents the asynchronous detect operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.\n
        ///     - or -\n
        ///     The format of <paramref name="source"/> is not supported.
        /// </exception>
        public static async Task<Rectangle[]> DetectAsync(MediaVisionSource source)
        {
            return await DetectAsync(source, null);
        }

        /// <summary>
        /// Detects faces on the source.\n
        /// Each time when DetectAsync is called, a set of the detected faces at the media source are received asynchronously.
        /// </summary>
        /// <param name="source">The source of the media where faces will be detected.</param>
        /// <param name="config">The configuration of engine will be used for detecting. This value can be null.</param>
        /// <returns>A task that represents the asynchronous detect operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        public static async Task<Rectangle[]> DetectAsync(MediaVisionSource source,
            FaceDetectionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            TaskCompletionSource<Rectangle[]> tcs = new TaskCompletionSource<Rectangle[]>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                InteropFace.Detect(source.Handle, EngineConfiguration.GetHandle(config), cb.Target).
                    Validate("Failed to perform face detection");

                return await tcs.Task;
            }
        }

        private static InteropFace.DetectedCallback GetCallback(TaskCompletionSource<Rectangle[]> tcs)
        {
            return (IntPtr sourceHandle, IntPtr engineConfig, global::Interop.MediaVision.Rectangle[] facesLocations,
                int numberOfFaces, IntPtr _) =>
            {
                try
                {
                    Log.Info(MediaVisionLog.Tag, $"Faces detected, count : {numberOfFaces}.");
                    Rectangle[] locations = new Rectangle[numberOfFaces];
                    for (int i = 0; i < numberOfFaces; i++)
                    {
                        locations[i] = facesLocations[i].ToApiStruct();
                        Log.Info(MediaVisionLog.Tag, $"Face {0} detected : {locations}.");
                    }

                    if (!tcs.TrySetResult(locations))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set face detection result.");
                    }
                }
                catch (Exception e)
                {
                    MultimediaLog.Info(MediaVisionLog.Tag, "Failed to handle face detection.", e);
                    tcs.TrySetException(e);
                }
            };
        }
    }
}
