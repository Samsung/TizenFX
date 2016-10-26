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

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents result of face tracking operation.
    /// </summary>
    public class FaceTrackingResult
    {
        internal FaceTrackingResult()
        {
        }

        /// <summary>
        /// Gets the quadrangle-shaped location which determines new position of the tracked face on the source.
        /// </summary>
        public Quadrangle Location { get; internal set; }

        /// <summary>
        /// The confidence of the tracking_model that new location of the face was determined correctly
        /// (value from 0.0 to 1.0). If no location was determined during last track iteration, then value is 0.0
        /// </summary>
        public double Confidence { get; internal set; }
    }
}
