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
    /// Represents a configuration of <see cref="ImageRecognizer"/>.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImageRecognitionConfiguration : EngineConfiguration
    {
        private const string KeySceneScaleFactor = "MV_IMAGE_RECOGNITION_SCENE_SCALE_FACTOR";
        private const string KeySceneMaxKeypoints = "MV_IMAGE_RECOGNITION_SCENE_MAX_KEYPOINTS_NUM";

        private const string KeyMinKeypointsMatch = "MV_IMAGE_RECOGNITION_MIN_MATCH_NUM";
        private const string KeyReqMatchPartKey = "MV_IMAGE_RECOGNITION_REQ_MATCH_PART";
        private const string KeyTolerantPartMatchingError = "MV_IMAGE_RECOGNITION_TOLERANT_MATCH_PART_ERR";

        /// <summary>
        /// A read-only field that represents the default value of <see cref="KeySceneScaleFactor"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultSceneScaleFactor = 1.2;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="SceneMaxKeyPoints"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DefaultSceneMaxKeypoints = 5000;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="MinKeyPointMatches"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DefaultMinKeyPointMatches = 30;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="RequiredMatchingPart"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultRequiredMatchPart = 0.05;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="TolerantPartMatchError"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultTolerantPartMatchError = 0.1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRecognitionConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public ImageRecognitionConfiguration() : base("image_recognition")
        {
        }

        /// <summary>
        /// Gets or sets the scene scale factor.
        /// </summary>
        /// <value>
        /// The value indicating the factor will be used for resizing of the scene including the images (objects) for recognition.
        /// The default is 1.2.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public double SceneScaleFactor
        {
            get
            {
                return GetDouble(KeySceneScaleFactor);
            }
            set
            {
                Set(KeySceneScaleFactor, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum key points that should be detected on the scene.
        /// The maximal number of key points can be selected on the scene including the images (objects) to calculate descriptors.
        /// </summary>
        /// <value>
        /// The maximal key points for image recognition.
        /// The default is 5000.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int SceneMaxKeyPoints
        {
            get
            {
                return GetInt(KeySceneMaxKeypoints);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(SceneMaxKeyPoints), value,
                        $"{nameof(SceneMaxKeyPoints)} can't be less than zero.");
                }
                Set(KeySceneMaxKeypoints, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of key points matches required for recognition.
        /// </summary>
        /// <value>
        /// The minimal number of key points should be matched between an image and a scene for image objects recognition.
        /// The default is 30.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int MinKeyPointMatches
        {
            get
            {
                return GetInt(KeyMinKeypointsMatch);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(MinKeyPointMatches), value,
                        $"{nameof(MinKeyPointMatches)} can't be less than zero.");
                }
                Set(KeyMinKeypointsMatch, value);
            }
        }

        /// <summary>
        /// Gets or sets the required matching part for the image recognition.
        /// To recognize occluded or hidden an image by other images, required relative part of the matches in respect to the total
        /// amount of matching keypoints required for image recognition. Too low value will result in unsustainable behavior,
        /// but the effect of object overlapping will be reduced.
        /// </summary>
        /// <value>
        /// The value indicating required relative part of the matches; can be from 0 to 1, inclusive.
        /// The default is 0.05.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.\n
        ///     -or-\n
        ///     <paramref name="value"/> is greater than one.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public double RequiredMatchingPart
        {
            get
            {
                return GetDouble(KeyReqMatchPartKey);
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Valid range is 0 to 1 inclusive,");
                }
                Set(KeyReqMatchPartKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the part matching error for the image recognition.\n
        /// Allowable error of matches number.
        /// </summary>
        /// <value>
        /// The value indicating allowable error of matches; can be from 0 to 1, inclusive.
        /// The default is 0.1.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.\n
        ///     -or-\n
        ///     <paramref name="value"/> is greater than one.
        /// </exception>
        /// <since_tizen> 3</since_tizen>
        public double TolerantPartMatchError
        {
            get
            {
                return GetDouble(KeyTolerantPartMatchingError);
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Valid range is 0 to 1 inclusive.");
                }

                Set(KeyTolerantPartMatchingError, value);
            }
        }
    }
}
