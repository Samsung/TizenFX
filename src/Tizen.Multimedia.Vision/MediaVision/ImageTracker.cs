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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using InteropImage = Interop.MediaVision.Image;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to track images on image sources.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class ImageTracker
    {
        /// <summary>
        /// Tracks the given image tracking model on the current frame.
        /// </summary>
        /// <param name="source">The current image of sequence where the image tracking model will be tracked.</param>
        /// <param name="trackingModel">The image tracking model which processed as target of tracking.</param>
        /// <returns>A task that represents the asynchronous tracking operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="trackingModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="trackingModel"/> has already been disposed of.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="trackingModel"/> has no target.</exception>
        /// <seealso cref="ImageTrackingModel.SetTarget(ImageObject)"/>
        /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<Quadrangle> TrackAsync(MediaVisionSource source,
            ImageTrackingModel trackingModel)
        {
            return await TrackAsync(source, trackingModel, null);
        }

        /// <summary>
        /// Tracks the given image tracking model on the current frame and <see cref="ImageTrackingConfiguration"/>.
        /// </summary>
        /// <param name="source">The current image of sequence where the image tracking model will be tracked.</param>
        /// <param name="trackingModel">The image tracking model which processed as target of tracking.</param>
        /// <param name="config">The configuration used for tracking. This value can be null.</param>
        /// <returns>A task that represents the asynchronous tracking operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="trackingModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="trackingModel"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="trackingModel"/> has no target.</exception>
        /// <seealso cref="ImageTrackingModel.SetTarget(ImageObject)"/>
        /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<Quadrangle> TrackAsync(MediaVisionSource source,
            ImageTrackingModel trackingModel, ImageTrackingConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (trackingModel == null)
            {
                throw new ArgumentNullException(nameof(trackingModel));
            }

            TaskCompletionSource<Quadrangle> tcs = new TaskCompletionSource<Quadrangle>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                InteropImage.Track(source.Handle, trackingModel.Handle, EngineConfiguration.GetHandle(config),
                    cb.Target).Validate("Failed to perform image tracking.");

                return await tcs.Task;
            }
        }

        private static InteropImage.TrackedCallback GetCallback(TaskCompletionSource<Quadrangle> tcs)
        {
            return (IntPtr sourceHandle, IntPtr imageTrackingModelHandle, IntPtr engineCfgHandle, IntPtr locationPtr, IntPtr _) =>
            {
                try
                {
                    Quadrangle region = null;
                    if (locationPtr != IntPtr.Zero)
                    {
                        region = Marshal.PtrToStructure<global::Interop.MediaVision.Quadrangle>(locationPtr).ToApiStruct();
                    }

                    Log.Info(MediaVisionLog.Tag, $"Image tracked, region : {region}");

                    if (!tcs.TrySetResult(region))
                    {
                        Log.Info(MediaVisionLog.Tag, "Failed to set track result");
                    }
                }
                catch (Exception e)
                {
                    MultimediaLog.Error(MediaVisionLog.Tag, "Failed to handle track result", e);
                    tcs.TrySetException(e);
                }
            };

        }
    }
}
