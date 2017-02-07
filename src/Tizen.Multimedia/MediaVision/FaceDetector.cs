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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents the interface for media vision face detection.
    /// </summary>
    public static class FaceDetector
    {
        /// <summary>
        /// Performs face detection on the source for the engine_conf.\n
        /// Use this function to launch face detection algorithm configured by @a config configuration.
        /// Each time when DetectAsync is called, a set of the detected faces at the media source are received asynchronously.
        /// </summary>
        /// <param name="source">The source of the media where faces will be detected</param>
        /// <param name="config">The configuration of engine will be used for detecting. If NULL, then default settings will be used.</param>
        /// <returns>Returns the FaceDetectionResult asynchronously</returns>
        /// <code>
        ///
        /// </code>
        public static async Task<FaceDetectionResult> DetectAsync(MediaVisionSource source, FaceEngineConfiguration config = null)
        {
            if (source == null)
            {
                throw new ArgumentException("Invalid source");
            }

            TaskCompletionSource<FaceDetectionResult> tcsResult = new TaskCompletionSource<FaceDetectionResult>();
            // Define native callback
            Interop.MediaVision.Face.MvFaceDetectedCallback faceDetectedCb = (IntPtr sourceHandle, IntPtr engineCfgHandle, IntPtr facesLocations, int numberOfFaces, IntPtr userData) =>
            {
                try
                {
                    Log.Info(MediaVisionLog.Tag, String.Format("Faces detected, count : {0}", numberOfFaces));
                    List<Rectangle> locations = new List<Rectangle>();
                    if (numberOfFaces > 0)
                    {
                        // Prepare list of locations
                        for (int i = 0; i < numberOfFaces; i++)
                        {
                            Interop.MediaVision.Rectangle location = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(facesLocations, typeof(Interop.MediaVision.Rectangle));
                            Rectangle rect = new Rectangle(new Point(location.x, location.y),
                                new Size(location.width, location.height));
                            Log.Info(MediaVisionLog.Tag, String.Format("Face {0} detected at : ({1}, {2})", i + 1, rect.Point.X, rect.Point.Y));
                            locations.Add(rect);
                            facesLocations = IntPtr.Add(facesLocations, sizeof(int) * 4);
                        }
                    }

                    FaceDetectionResult result = new FaceDetectionResult()
                    {
                        Locations = locations
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

            int ret = Interop.MediaVision.Face.Detect(source._sourceHandle, (config != null) ? config._engineHandle : IntPtr.Zero, faceDetectedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform face detection.");
            return await tcsResult.Task;
        }
    }
}
