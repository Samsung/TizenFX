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

using System.Collections.Generic;

namespace Tizen.Multimedia
{
    public class ImageRecognitionResult
    {
        /// <summary>
        /// This class represents result of image recognition operation.
        /// </summary>
        internal ImageRecognitionResult()
        {
        }

        /// <summary>
        /// The locations of image objects on the source image.
        /// </summary>
        public List<Quadrangle> Locations { get; internal set; }
    }
}
