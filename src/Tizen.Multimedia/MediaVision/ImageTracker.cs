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
    /// This class contains the Media Vision image tracking API which performs tracking
    /// on <see cref="MediaVisionSource"/> for <see cref="ImageTrackingModel"/>
    /// </summary>
    public static class ImageTracker
    {
        /// <summary>
        /// Tracks the given image tracking model on the current frame asynchronously.
        /// </summary>
        /// <param name="source">The current image of sequence where image tracking model will be tracked</param>
        /// <param name="trackingModel">The image tracking model which processed as target of tracking</param>
        /// <param name="config">The configuration of engine which will be used for tracking. If NULL, then default settings will be used.</param>
        /// <returns>Returns the image object location asynchronously</returns>
        /// <code>
        /// 
        /// </code>
        public static async Task<Quadrangle> TrackAsync(MediaVisionSource source, ImageTrackingModel trackingModel, ImageEngineConfiguration config = null)
        {
            if (source == null || trackingModel == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            TaskCompletionSource<Quadrangle> tcsResult = new TaskCompletionSource<Quadrangle>();

            // Define native callback
            Interop.MediaVision.Image.MvImageTrackedCallback imageTrackedCb = (IntPtr sourceHandle, IntPtr imageTrackingModelHandle, IntPtr engineCfgHandle, IntPtr locationPtr, IntPtr userData) =>
            {
                try
                {
                    Quadrangle imageLocation = null;
                    if (locationPtr != IntPtr.Zero)
                    {
                        Interop.MediaVision.Quadrangle location = (Interop.MediaVision.Quadrangle)Marshal.PtrToStructure(locationPtr, typeof(Interop.MediaVision.Quadrangle));
                        imageLocation = new Quadrangle()
                        {
                            Points = new Point[4]
                            {
                            new Point(location.x1, location.y1),
                            new Point(location.x2, location.y2),
                            new Point(location.x3, location.y3),
                            new Point(location.x4, location.y4)
                            }
                        };

                        Log.Info(MediaVisionLog.Tag, String.Format("Image tracked, location : {0}", imageLocation.ToString()));
                    }

                    if (!tcsResult.TrySetResult(imageLocation))
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

            int ret = Interop.MediaVision.Image.Track(source._sourceHandle, trackingModel._trackingModelHandle, (config != null) ? config._engineHandle : IntPtr.Zero, imageTrackedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform image tracking.");

            return await tcsResult.Task;
        }
    }
}
