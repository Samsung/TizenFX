/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using InteropInference = Interop.MediaVision.Inference;
using Unmanaged = Interop.MediaVision;

namespace Tizen.Multimedia.Vision
{

    /// <summary>
    /// Represents a Landmark in pose detection.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public struct Landmark
    {
        /// <summary>
        /// Represents a location in the 2D space.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Point Location
        {
            get;
            set;
        }
        /// <summary>
        /// Confidence score of point.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float Score
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Provides the ability to detect Pose landmarks on image source using inference engine.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public static class PoseLandmarkDetector
    {
        /// <summary>
        /// Detects Pose landmarks on the source image using inference engine set in <paramref name="config"/>.<br/>
        /// </summary>
        /// <remarks>
        /// To set region-of-interest area in source image, please set <see cref="InferenceModelConfiguration.Roi"/>.
        /// If not set, full image area will be used to detect Pose landmark.
        /// </remarks>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <feature>http://tizen.org/feature/vision.inference.face</feature>
        /// <param name="source">The source of the media where poses will be detected.</param>
        /// <param name="config">The engine's configuration that will be used for detecting.</param>
        /// <returns>
        /// A task that represents the asynchronous detect operation.<br/>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <seealso cref="InferenceModelConfiguration"/>
        /// <since_tizen> 9 </since_tizen>
        public static async Task<Landmark[,]> DetectAsync(MediaVisionSource source,
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
            var tcs = new TaskCompletionSource<Landmark[,]>();
            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                IntPtr roiUnmanaged = IntPtr.Zero;
                try
                {
                    if (config.Roi.HasValue)
                    {
                        var roi = config.Roi.Value.ToMarshalable();

                        roiUnmanaged = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Unmanaged.Rectangle)));
                        Marshal.WriteIntPtr(roiUnmanaged, IntPtr.Zero);
                        Marshal.StructureToPtr(roi, roiUnmanaged, false);
                    }
                    InteropInference.DetectPoseLandmark(source.Handle, config.GetHandle(), roiUnmanaged, cb.Target).
                        Validate("Failed to detect Pose landmark.");
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
        private static InteropInference.PoseLandmarkDetectedCallback GetCallback(TaskCompletionSource<Landmark[,]> tcs)
        {
            return (IntPtr sourceHandle, IntPtr poses, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(GetResults(poses)))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set Pose landmark detection result.");
                    }
                }
                catch (Exception e)
                {
                    tcs.TrySetException(e);
                }
            };
        }
        private static Landmark[,] GetResults(IntPtr poses)
        {
            int numOfPoses, numOfLandMarks;
            float score;
            InteropInference.GetPoseNum(poses, out numOfPoses).Validate("Failed to get number of pose");
            InteropInference.GetLandmarkNum(poses, out numOfLandMarks).Validate("Failed to get number of landmark");
            Unmanaged.Point location = new Unmanaged.Point();
            Landmark[,] results = new Landmark[numOfPoses, numOfLandMarks];
            for (int np = 0; np < numOfPoses; np++)
            {
                for (int nl = 0; nl < numOfLandMarks; nl++)
                {
                    InteropInference.GetLandmark(poses, np, nl, out location, out score).Validate("Failed to GetLandmark");
                    results[np, nl].Score = score;
                    results[np, nl].Location = location.ToApiStruct();
                }
            }
            return results;
        }
    }
}
