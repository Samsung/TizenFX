/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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
using InteropFLD = Interop.MediaVision.InferenceFacialLandmarkDetection;


namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the result of <see cref="InferenceFacialLandmarkDetector"/> operations.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceFacialLandmarkDetectorResult
    {
        internal InferenceFacialLandmarkDetectorResult(IntPtr handle)
        {
            InteropFLD.GetResultCount(handle, out ulong requestId, out uint count).
                Validate("Failed to get result count.");

            RequestId = requestId;
            var points = new List<Point>();

            for (uint i = 0 ; i < count ; i++)
            {
                InteropFLD.GetPoints(handle, i, out uint x, out uint y).Validate("Failed to get points.");
                points.Add(new Point((int)x, (int)y));
            }

            Points = points;
        }

        /// <summary>
        /// Gets the request ID which is matched with request ID of RequestInference() return value.<br/>
        /// It represents the order of request.
        /// </summary>
        /// <value>The request ID that indicates the order of request.</value>
        /// <since_tizen> 12 </since_tizen>
        public ulong RequestId { get; }

        /// <summary>
        /// Gets The coordinates of detected facial landmarks.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<Point> Points { get; }
    }
}
