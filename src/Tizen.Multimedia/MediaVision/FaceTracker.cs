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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class contains the Media Vision face tracking API which performs tracking
    /// on <see cref="MediaVisionSource"/> for <see cref="FaceTrackingModel"/>
    /// </summary>
    public static class FaceTracker
    {
        /// <summary>
        /// Performs face tracking on the @a source for the @a trackingModel.\n
        /// Use this function to launch face tracking algorithm configured by @a config configuration using
        /// @a trackingModel tracking model. Each time when this function is called, new location determined for the tracked face
        /// and model confidence that location is determined correctly are returned.
        /// </summary>
        /// <param name="source">The source of the media to recognize face for</param>
        /// <param name="trackingModel">The model will be used for tracking</param>
        /// <param name="doLearn">The model learning flag. If it is set true then model will try to learn (if it supports learning feature), otherwise model will be not learned during the invoking tracking iteration. Learning process improves tracking correctness, but can decrease tracking performance</param>
        /// <param name="config">The configuration of engine will be used for tracking. If NULL, the default configuration will be used.</param>
        /// <returns>Returns the FaceTrackingResult with new location and confidence asynchronously</returns>
        /// <code>
        /// 
        /// </code>
        public static async Task<FaceTrackingResult> TrackAsync(MediaVisionSource source, FaceTrackingModel trackingModel, bool doLearn, FaceEngineConfiguration config = null)
        {
            if (source == null || trackingModel == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            TaskCompletionSource<FaceTrackingResult> tcsResult = new TaskCompletionSource<FaceTrackingResult>();

            // Define native callback
            Interop.MediaVision.Face.MvFaceTrackedCallback faceTrackedCb = (IntPtr sourceHandle, IntPtr trackingModelHandle, IntPtr engineCfgHandle, IntPtr locationPtr, double confidence, IntPtr userData) =>
            {
                try
                {
                    Quadrangle faceLocation = null;
                    if (locationPtr != IntPtr.Zero)
                    {
                        Interop.MediaVision.Quadrangle location = (Interop.MediaVision.Quadrangle)Marshal.PtrToStructure(locationPtr, typeof(Interop.MediaVision.Quadrangle));
                        faceLocation = new Quadrangle()
                        {
                            Points = new Point[4]
                            {
                            new Point(location.x1, location.y1),
                            new Point(location.x2, location.y2),
                            new Point(location.x3, location.y3),
                            new Point(location.x4, location.y4)
                            }
                        };

                        Log.Info(MediaVisionLog.Tag, String.Format("Tracked location : {0}, confidence : {1}", faceLocation.ToString(), confidence));
                    }

                    FaceTrackingResult result = new FaceTrackingResult()
                    {
                        Location = faceLocation,
                        Confidence = confidence
                    };

                    if (!tcsResult.TrySetResult(result))
                    {
                        Log.Info(MediaVisionLog.Tag, "Failed to set result");
                        tcsResult.TrySetException(new InvalidOperationException("Failed to set result"));
                    }
                }
                catch (Exception ex)
                {
                    Log.Info(MediaVisionLog.Tag, "exception :" + ex.ToString());
                    tcsResult.TrySetException(ex);
                }
            };

            int ret = Interop.MediaVision.Face.Track(source._sourceHandle, trackingModel._trackingModelHandle, (config != null) ? config._engineHandle : IntPtr.Zero, faceTrackedCb, doLearn, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform face tracking.");

            return await tcsResult.Task;
        }
    }
}
