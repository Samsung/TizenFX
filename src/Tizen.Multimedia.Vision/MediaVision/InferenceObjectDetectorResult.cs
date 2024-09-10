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
using InteropOD = Interop.MediaVision.InferenceObjectDetection;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the result of <see cref="InferenceObjectDetector"/> operations.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceObjectDetectorResult
    {
        internal InferenceObjectDetectorResult(IntPtr handle)
        {
            InteropOD.GetResultCount(handle, out ulong requestOrder, out uint count).
                Validate("Failed to get result count.");

            RequestOrder = requestOrder;
            var boundBoxes = new List<Rectangle>();

            for (uint i = 0 ; i < count ; i++)
            {
                InteropOD.GetBoundBox(handle, i, out int left, out int top, out int right, out int bottom).
                    Validate("Failed to get bound box.");
                boundBoxes.Add(new Rectangle(left, top, right - left, bottom - top));
            }

            BoundBox = boundBoxes;
        }

        /// <summary>
        /// Gets the requested order.
        /// </summary>
        /// <value>The requested order.</value>
        /// <since_tizen> 12 </since_tizen>
        public ulong RequestOrder { get; }

        /// <summary>
        /// Gets the boundBox of the detected object.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<Rectangle> BoundBox { get; }
    }
}
