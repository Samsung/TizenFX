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
    /// Represents a configuration of <see cref="FaceDetector"/> instances.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FaceDetectionConfiguration : EngineConfiguration
    {
        private const string KeyModelFilePath = "MV_FACE_DETECTION_MODEL_FILE_PATH";
        private const string KeyRoiX = "MV_FACE_DETECTION_ROI_X";
        private const string KeyRoiY = "MV_FACE_DETECTION_ROI_Y";
        private const string KeyRoiWidth = "MV_FACE_DETECTION_ROI_WIDTH";
        private const string KeyRoiHeight = "MV_FACE_DETECTION_ROI_HEIGHT";
        private const string KeyMinWidth = "MV_FACE_DETECTION_MIN_SIZE_WIDTH";
        private const string KeyMinHeight = "MV_FACE_DETECTION_MIN_SIZE_HEIGHT";

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceDetectionConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3</since_tizen>
        public FaceDetectionConfiguration() : base("face_recognition")
        {
        }

        /// <summary>
        /// Gets or sets the face detection haarcascade xml file for face detection.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string ModelFilePath
        {
            get
            {
                return GetString(KeyModelFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(ModelFilePath), "ModeFilePath can't be null.");
                }
                Set(KeyModelFilePath, value);
            }
        }


        /// <summary>
        /// Gets or sets the minimum height of a face which will be detected.
        /// </summary>
        /// <remarks>
        /// Default value is null (all detected faces will be applied), which can be changed to specify the minimum face height.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int? MinHeight
        {
            get
            {
                int value = GetInt(KeyMinHeight);
                if (value == -1) return null;
                return value;
            }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(MinHeight), value,
                        $"{nameof(MinHeight)} can't be less than zero.");
                }

                Set(KeyMinHeight, value ?? -1);
            }
        }

        /// <summary>
        /// Gets or sets the minimum width of a face which will be detected.
        /// </summary>
        /// <remarks>
        /// Default value is null (all detected faces will be applied), which can be changed to specify the minimum face width.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int? MinWidth
        {
            get
            {
                int value = GetInt(KeyMinWidth);
                if (value == -1) return null;
                return value;
            }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(MinWidth), value,
                        $"{nameof(MinWidth)} can't be less than zero.");
                }

                Set(KeyMinWidth, value ?? -1);
            }
        }

        private static readonly Rectangle DefaultRoi = new Rectangle(-1, -1, -1, -1);

        private Rectangle? _roi;

        /// <summary>
        /// Gets or sets the roi of the face detection.
        /// </summary>
        /// <remarks>
        /// Default value is null (the roi will be a full image), which can be changed to specify the roi for face detection.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The x position of <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The y position of <paramref name="value"/> is less than zero.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle? Roi
        {
            get
            {
                return _roi;
            }
            set
            {
                if (value != null)
                {
                    ValidateRoi(value.Value);
                }

                SetRoi(value ?? DefaultRoi);

                _roi = value;
            }
        }

        private static void ValidateRoi(Rectangle roi)
        {
            if (roi.Width <= 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Width", roi.Width,
                    "The width of roi can't be less than or equal to zero.");
            }

            if (roi.Height <= 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Height", roi.Height,
                    "The height of roi can't be less than or equal to zero.");
            }

            if (roi.X < 0)
            {
                throw new ArgumentOutOfRangeException("Roi.X", roi.X,
                    "The x position of roi can't be less than zero.");
            }

            if (roi.Y < 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Y", roi.Y,
                    "The y position of roi can't be less than zero.");
            }
        }

        private void SetRoi(Rectangle roi)
        {
            Set(KeyRoiX, roi.X);
            Set(KeyRoiY, roi.Y);
            Set(KeyRoiWidth, roi.Width);
            Set(KeyRoiHeight, roi.Height);
        }
    }
}
