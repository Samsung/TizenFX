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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the result of face tracking operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FaceTrackingResult
    {
        internal FaceTrackingResult(bool success, double confidence, Quadrangle region)
        {
            Success = success;
            Confidence = confidence;
            Region = region;
        }

        /// <summary>
        /// Gets the value indicating the tracking is successful.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public bool Success { get; }

        /// <summary>
        /// Gets the region which determines the new position of the tracked face on the source.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Quadrangle Region { get; }

        /// <summary>
        /// The confidence of the tracking model that a new location of the face was determined correctly
        /// (value from 0.0 to 1.0). If no location was determined during the last track iteration, then the value is 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Confidence { get; }
    }
}
