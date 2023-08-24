/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.Collections.ObjectModel;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to get the result of face detection using <see cref="InferenceModelConfiguration"/> and
    /// <see cref="FaceDetector.DetectAsync(MediaVisionSource, InferenceModelConfiguration)"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class FaceDetectionResult
    {
        internal FaceDetectionResult(float confidence, global::Interop.MediaVision.Rectangle location)
        {
            Confidence = confidence;
            Location = location.ToApiStruct();
        }

        /// <summary>
        /// Gets the confidence of detected face.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float Confidence { get; }

        /// <summary>
        /// Gets the location of detected face.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Rectangle Location { get; }
    }
}
