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

using System;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a result of RecognizeAsync operations of <see cref="ImageRecognizer"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API15.")]
    public class ImageRecognitionResult
    {

        internal ImageRecognitionResult(bool success, Quadrangle region)
        {
            Success = success;
            Region = region;
        }

        /// <summary>
        /// The region of recognized image object on the source image.
        /// </summary>
        /// <value>The region of recognized image object if successful, otherwise null.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API15.")]
        public Quadrangle Region { get; }

        /// <summary>
        /// Gets the value indicating the recognition is successful.
        /// </summary>
        /// <since_tizen> 4</since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API15.")]
        public bool Success { get; }
    }
}
