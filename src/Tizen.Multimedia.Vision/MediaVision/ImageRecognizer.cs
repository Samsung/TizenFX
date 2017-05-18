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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using InteropImage = Interop.MediaVision.Image;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to recognize images on image sources.
    /// </summary>
    public static class ImageRecognizer
    {
        /// <summary>
        /// Recognizes the given image objects on the source image.\n
        /// </summary>
        /// <param name="source">The source image on which image objects will be recognized.</param>
        /// <param name="imageObjects">The array of image objects which will be processed as targets of recognition.</param>
        /// <param name="config">The configuration of engine which will be used for recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.\n
        ///     - or -\n
        ///     <paramref name="imageObjects"/> is null.\n
        ///     - or -\n
        ///     <paramref name="imageObjects"/> contains null reference.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="imageObjects"/> has no elements.(The length is zero.)</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        public static async Task<IEnumerable<ImageRecognitionResult>> RecognizeAsync(
            MediaVisionSource source, ImageObject[] imageObjects)
        {
            return await RecognizeAsync(source, imageObjects, null);
        }

        /// <summary>
        /// Recognizes the given image objects on the source image.\n
        /// </summary>
        /// <param name="source">The source image on which image objects will be recognized.</param>
        /// <param name="imageObjects">The array of image objects which will be processed as targets of recognition.</param>
        /// <param name="config">The configuration used for recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.\n
        ///     - or -\n
        ///     <paramref name="imageObjects"/> is null.\n
        ///     - or -\n
        ///     <paramref name="imageObjects"/> contains null elements.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="imageObjects"/> has no elements.(The length is zero.)</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.\n
        ///     - or -\n
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        public static async Task<IEnumerable<ImageRecognitionResult>> RecognizeAsync(MediaVisionSource source,
            ImageObject[] imageObjects, ImageRecognitionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (imageObjects == null)
            {
                throw new ArgumentNullException(nameof(imageObjects));
            }
            if (imageObjects.Length == 0)
            {
                throw new ArgumentException("No image object to recognize.", nameof(imageObjects));
            }

            var tcs = new TaskCompletionSource<IEnumerable<ImageRecognitionResult>>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            using (var imageHandles = ObjectKeeper.Get(GetHandles(imageObjects)))
            {
                InteropImage.Recognize(source.Handle, imageHandles.Target, imageHandles.Target.Length,
                    EngineConfiguration.GetHandle(config), cb.Target).
                    Validate("Failed to perform image recognition.");

                return await tcs.Task;
            }
        }

        private static ImageRecognitionResult[] CreateResults(IntPtr[] locations, uint numOfObjects)
        {
            ImageRecognitionResult[] results = new ImageRecognitionResult[numOfObjects];

            for (int i = 0; i < numOfObjects; i++)
            {
                Quadrangle quadrangle = locations[i] != IntPtr.Zero ?
                    Marshal.PtrToStructure<global::Interop.MediaVision.Quadrangle>(locations[i]).ToApiStruct() : null;

                results[i] = new ImageRecognitionResult(locations[i] != IntPtr.Zero, quadrangle);
            }

            return results;
        }

        private static InteropImage.RecognizedCallback GetCallback(
            TaskCompletionSource<IEnumerable<ImageRecognitionResult>> tcs)
        {
            return (IntPtr source, IntPtr engineConfig, IntPtr imageObjectHandles,
                IntPtr[] locations, uint numOfObjects, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(CreateResults(locations, numOfObjects)))
                    {
                        Log.Info(MediaVisionLog.Tag, "Failed to set recognition result");
                    }
                }
                catch (Exception e)
                {
                    MultimediaLog.Error(MediaVisionLog.Tag, "Failed to handle recognition result", e);
                    tcs.TrySetException(e);
                }
            };
        }

        private static IntPtr[] GetHandles(ImageObject[] imageObjects)
        {
            IntPtr[] imageHandles = new IntPtr[imageObjects.Length];
            for (int i = 0; i < imageObjects.Length; i++)
            {
                if (imageObjects[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(imageObjects)}[{i}]");
                }

                imageHandles[i] = imageObjects[i].Handle;
            }

            return imageHandles;
        }
    }
}
