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
    /// Represents a configuration of fill operations of <see cref="ImageObject"/> instances.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImageFillConfiguration : EngineConfiguration
    {
        private const string KeyScaleFactor = "MV_IMAGE_RECOGNITION_OBJECT_SCALE_FACTOR";
        private const string KeyMaxKeypoints = "MV_IMAGE_RECOGNITION_OBJECT_MAX_KEYPOINTS_NUM";

        /// <summary>
        /// A read-only field that represents the default value of <see cref="ObjectScaleFactor"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultScaleFactor = 1.2;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="ObjectMaxKeyPoints"/>.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public static readonly int DefaultMaxKeypoints = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFillConfiguration"/> class.
        /// </summary>
        /// <exception cref="System.NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public ImageFillConfiguration() : base("image_recognition")
        {
        }

        /// <summary>
        /// Gets or sets the scale factor the image to be recognized.\n
        /// The value of the factor will be used for resizing of the images (objects) for recognition.
        /// The default value is 1.2.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageFillConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public double ObjectScaleFactor
        {
            get
            {
                return GetDouble(KeyScaleFactor);
            }
            set
            {
                Set(KeyScaleFactor, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum key points should be detected on the image.\n
        /// The maximal number of key points can be selected on the image object to calculate descriptors.
        /// This key points will be used for image (object) recognition and has to be specified as integer number.
        /// The default value is 1000.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageFillConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int ObjectMaxKeyPoints
        {
            get
            {
                return GetInt(KeyMaxKeypoints);
            }
            set
            {
                Set(KeyMaxKeypoints, value);
            }
        }
    }
}
