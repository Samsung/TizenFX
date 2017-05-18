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
using InteropFace = Interop.MediaVision.Face;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to track faces on image sources.
    /// </summary>
    public static class FaceTracker
    {

        /// <summary>
        /// Performs face tracking on the source with the trackingModel.
        /// </summary>
        /// <param name="source">The source of the media to recognize face for.</param>
        /// <param name="trackingModel">The model will be used for tracking.</param>
        /// <param name="doLearn">The value indicating whether model learning while tracking. If it is true then model will try to learn
        /// (if it supports learning feature), otherwise model will be not learned during the invoking tracking iteration.
        /// Learning process improves tracking correctness, but can decrease tracking performance</param>
        /// <returns>A task that represents the asynchronous tracking operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.\n
        ///     - or -\n
        ///     <paramref name="trackingModel"/> is null.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.\n
        ///     - or -\n
        ///     <paramref name="trackingModel"/> has already been disposed of.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="trackingModel"/> is not prepared.</exception>
        public static async Task<FaceTrackingResult> TrackAsync(MediaVisionSource source,
            FaceTrackingModel trackingModel, bool doLearn)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (trackingModel == null)
            {
                throw new ArgumentNullException(nameof(trackingModel));
            }

            TaskCompletionSource<FaceTrackingResult> tcs = new TaskCompletionSource<FaceTrackingResult>();

            using (var cb = ObjectKeeper.Get(GetTrackCallback(tcs)))
            {
                InteropFace.Track(source.Handle, trackingModel.Handle, IntPtr.Zero,
                    cb.Target, doLearn).Validate("Failed to perform face tracking.");

                return await tcs.Task;
            }
        }

        private static InteropFace.TrackedCallback GetTrackCallback(TaskCompletionSource<FaceTrackingResult> tcs)
        {
            return (IntPtr sourceHandle, IntPtr trackingModelHandle, IntPtr engineCfgHandle,
                IntPtr locationPtr, double confidence, IntPtr _) =>
            {
                try
                {
                    Quadrangle area = null;
                    if (locationPtr != IntPtr.Zero)
                    {
                        area = Marshal.PtrToStructure<global::Interop.MediaVision.Quadrangle>(locationPtr).ToApiStruct();
                    }

                    Log.Info(MediaVisionLog.Tag, $"Tracked area : {area}, confidence : {confidence}");

                    if (!tcs.TrySetResult(new FaceTrackingResult(locationPtr != IntPtr.Zero, confidence, area)))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set tracking result");
                    }
                }
                catch (Exception e)
                {
                    MultimediaLog.Error(MediaVisionLog.Tag, "Setting tracking result failed.", e);
                    tcs.TrySetException(e);
                }
            };
        }
    }
}
