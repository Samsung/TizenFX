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
using System.Runtime.InteropServices;
using InteropIC = Interop.MediaVision.InferenceImageClassification;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the result of <see cref="InferenceImageClassifier"/> operations.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceImageClassifierResult
    {
        internal InferenceImageClassifierResult(IntPtr handle)
        {
            InteropIC.GetResultCount(handle, out ulong requestId, out uint count).
                Validate("Failed to get result count.");

            RequestId = requestId;
            var labels = new List<string>();

            for (uint i = 0 ; i < count ; i++)
            {
                InteropIC.GetLabels(handle, i, out IntPtr label).Validate("Failed to get labels.");
                labels.Add(Marshal.PtrToStringAnsi(label));
            }

            Labels = labels;
        }

        /// <summary>
        /// Gets the request ID which is matched with request ID of RequestInference() return value.<br/>
        /// It represents the order of request.
        /// </summary>
        /// <value>The request ID that indicates the order of request.</value>
        /// <since_tizen> 12 </since_tizen>
        public ulong RequestId { get; }

        /// <summary>
        /// Gets the labels of the classified image.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public IEnumerable<string> Labels { get; }
    }
}
