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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to get the result of object detection using <see cref="InferenceModelConfiguration"/> and
    /// <see cref="ObjectDetector"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ObjectDetectionResult
    {
        internal ObjectDetectionResult(int[] indices, string[] names, float[] confidences,
            global::Interop.MediaVision.Rectangle[] locations, int size)
        {
            if (size > 0)
            {
                Number = size;
                Indices = new int[size];
                Names = new string[size];
                Confidences = new float[size];

                indices.CopyTo(Indices, 0);
                names.CopyTo(Names, 0);
                confidences.CopyTo(Confidences, 0);

                var location = new Rectangle[size];
                for (int i = 0; i < size; i++)
                {
                    Locations[i] = locations[i].ToApiStruct();
                }
            }
        }

        /// <summary>
        /// Gets the number of detected objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Number { get; }

        /// <summary>
        /// Gets the indices of detected objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int[] Indices { get; }

        /// <summary>
        /// Gets the names of detected objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string[] Names { get; }

        /// <summary>
        /// Gets the confidences of detected objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float[] Confidences { get; }

        /// <summary>
        /// Gets the locations of detected objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Rectangle[] Locations { get; }
    }
}
