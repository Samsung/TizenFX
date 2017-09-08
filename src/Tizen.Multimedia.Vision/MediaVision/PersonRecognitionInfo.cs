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
    /// Represents a result of <see cref="PersonRecognizer"/> instances.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PersonRecognitionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRecognitionInfo"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PersonRecognitionInfo(Rectangle area, int label, double confidence)
        {
            Area = area;
            Label = label;
            Confidence = confidence;
        }

        /// <summary>
        /// Gets the rectangular location where person face was recognized.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public Rectangle Area { get; }

        /// <summary>
        /// Gets the label that correspond to the recognized person.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Label { get; }

        /// <summary>
        /// Gets the confidence value that correspond to the recognized person.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Confidence { get; }
    }
}
