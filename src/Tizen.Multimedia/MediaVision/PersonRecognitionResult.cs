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
    /// This class represents result of person recognition event trigger.
    /// </summary>
    public class PersonRecognitionResult
    {
        internal PersonRecognitionResult()
        {
        }

        /// <summary>
        /// Gets a rectangular locations where person face was recognized.
        /// </summary>
        public Rectangle Location { get; internal set; }

        /// <summary>
        /// Gets a label that correspond to the recognized person.
        /// </summary>
        public int Label { get; internal set; }

        /// <summary>
        /// Gets a confidence value that correspond to the recognized person.
        /// </summary>
        public double Confidence { get; internal set; }
    }
}
