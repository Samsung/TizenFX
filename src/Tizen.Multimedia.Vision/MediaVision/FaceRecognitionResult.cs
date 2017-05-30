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
    /// Represents result of <see cref="FaceRecognizer"/> operations.
    /// </summary>
    public class FaceRecognitionResult
    {
        internal FaceRecognitionResult(bool recognized, double confidence, int label, Rectangle? area)
        {
            Success = recognized;
            Label = label;
            Area = area;
            Confidence = confidence;
        }

        /// <summary>
        /// Gets the value indicating the recognition is successful.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Gets the label of the recognized face.
        /// </summary>
        public int Label { get; }

        /// <summary>
        /// Gets the location of the recognized face.
        /// </summary>
        public Rectangle? Area { get; }

        /// <summary>
        /// The confidence of the recognition model that face has been recognized correctly (value from 0.0 to 1.0).
        /// No faces were recognized if confidence was 0.0. When model has been learned on large amount of examples,
        /// threshold for this value can be high (0.85-0.95). If model was learned for small amount of examples,
        /// then threshold can be reduced (0.5-0.85).
        /// </summary>
        public double Confidence { get; }
    }
}
