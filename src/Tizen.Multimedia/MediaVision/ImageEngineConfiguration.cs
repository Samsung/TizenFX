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

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents concrete EngineConfig for image recognition and tracking
    /// </summary>
    public class ImageEngineConfiguration : EngineConfiguration
    {
        // List of predefined keys
        private const string _imageRecognitionObjectScaleFactorKey = "MV_IMAGE_RECOGNITION_OBJECT_SCALE_FACTOR";
        private const string _imageRecognitionObjectMaxKeypointsKey = "MV_IMAGE_RECOGNITION_OBJECT_MAX_KEYPOINTS_NUM";
        private const string _imageRecognitionSceneScaleFactorKey = "MV_IMAGE_RECOGNITION_SCENE_SCALE_FACTOR";
        private const string _imageRecognitionSceneMaxKeypointsKey = "MV_IMAGE_RECOGNITION_SCENE_MAX_KEYPOINTS_NUM";
        private const string _imageRecognitionMinKeypointsMatchKey = "MV_IMAGE_RECOGNITION_MIN_MATCH_NUM";
        private const string _imageRecognitionReqMatchPartKey = "MV_IMAGE_RECOGNITION_REQ_MATCH_PART";
        private const string _imageRecognitionTolerantPartMatchingErrorKey = "MV_IMAGE_RECOGNITION_TOLERANT_MATCH_PART_ERR";
        private const string _imageTrackingHistoryAmountKey = "MV_IMAGE_TRACKING_HISTORY_AMOUNT";
        private const string _imageTrackingExpectedOffsetKey = "MV_IMAGE_TRACKING_EXPECTED_OFFSET";
        private const string _imageTrackingUseStabilizationKey = "MV_IMAGE_TRACKING_USE_STABLIZATION";
        private const string _imageTrackingStabilizationTolerantShiftKey = "MV_IMAGE_TRACKING_STABLIZATION_TOLERANT_SHIFT";
        private const string _imageTrackingStabilizationSpeedKey = "MV_IMAGE_TRACKING_STABLIZATION_SPEED";
        private const string _imageTrackingStabilizationAccelarationKey = "MV_IMAGE_TRACKING_STABLIZATION_ACCELERATION";

        // Values are cached below to prevent interop calls for get operation
        private double _imageRecognitionObjectScaleFactorValue = 1.2;
        private int _imageRecognitionObjectMaxKeypointsValue = 1000;
        private double _imageRecognitionSceneScaleFactorValue = 1.2;
        private int _imageRecognitionSceneMaxKeypointsValue = 5000;
        private int _imageRecognitionMinKeypointsMatchValue = 30;
        private double _imageRecognitionReqMatchPartValue = 0.05;
        private double _imageRecognitionTolerantPartMatchingErrorValue = 0.1;
        private int _imageTrackingHistoryAmountValue = 3;
        private double _imageTrackingExpectedOffsetValue = 0;
        private bool _imageTrackingUseStabilizationValue = true;
        private double _imageTrackingStabilizationTolerantShiftValue;
        private double _imageTrackingStabilizationSpeedValue = 0.3;
        private double _imageTrackingStabilizationAccelarationValue = 0.1;

        /// <summary>
        /// The default constructor of ImageEngineConfiguration class
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public ImageEngineConfiguration()
            : base()
        {
        }

        /// <summary>
        /// Sets and gets the image to be recognized scale factor attribute of the engine configuration.\n
        /// The value of the factor will be used for resizing of the images (objects) for recognition.
        /// Scale factor is the double value and the defalut is 1.2
        /// </summary>
        public double ObjectScaleFactor
        {
            get
            {
                return _imageRecognitionObjectScaleFactorValue;
            }

            set
            {
                Add<double>(_imageRecognitionObjectScaleFactorKey, value);
                _imageRecognitionObjectScaleFactorValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the maximum keypoints should be detected on the image attribute of the engine configuration.\n
        /// The maximal number of keypoints can be selected on the image object to calculate descriptors.
        /// This keypoints will be used for image (object) recognition and has to be specified as integer number and the defalut is 1000.
        /// </summary>
        public int ObjectMaxKeyPoints
        {
            get
            {
                return _imageRecognitionObjectMaxKeypointsValue;
            }

            set
            {
                Add<int>(_imageRecognitionObjectMaxKeypointsKey, (int)value);
                _imageRecognitionObjectMaxKeypointsValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the scene scale factor attribute of the engine configuration.\n
        /// The value of the factor will be used for resizing of the scene including the images (objects) for recognition.
        /// Scale factor is the double value and the defalut is 1.2
        /// </summary>
        public double SceneScaleFactor
        {
            get
            {
                return _imageRecognitionSceneScaleFactorValue;
            }

            set
            {
                Add<double>(_imageRecognitionSceneScaleFactorKey, value);
                _imageRecognitionSceneScaleFactorValue = value;
            }
        }

        /// <summary>
        /// Sets and gets set the maximum keypoints should be detected on the scene attribute of the engine configuration.\n
        /// The maximal number of keypoints can be selected on the scene including the images (objects) to calculate descriptors.
        /// This keypoints will be used for image recognition and has to be specified as unsigned integer and the defalut is 5000.
        /// </summary>
        public int SceneMaxKeyPoints
        {
            get
            {
                return _imageRecognitionSceneMaxKeypointsValue;
            }

            set
            {
                Add<int>(_imageRecognitionSceneMaxKeypointsKey, value);
                _imageRecognitionSceneMaxKeypointsValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the minimum number of keypoints matches required for recognition attribute of the engine configuration.\n
        /// The minimal number of keypoints should be matched between an image and a scene.
        /// It will be taken into account for image objects recognition. Value is unsigned integer and the defalut is 30.
        /// </summary>
        public int MinKeyPointsMatches
        {
            get
            {
                return _imageRecognitionMinKeypointsMatchValue;
            }

            set
            {
                Add<int>(_imageRecognitionMinKeypointsMatchKey, value);
                _imageRecognitionMinKeypointsMatchValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the required matching part for the image recognition attribute of the engine configuration.\n
        /// To recognize occluded or hidden an image by other images, required relative part of the matches in respect to the total
        /// amount of matching keypoints required for image recognition. Too low value will result in unsustainable behavior,
        /// but effect of object overlapping will be reduced. Value can be from 0 to 1 and the defalut is 0.05.
        /// </summary>
        public double RequiredMatchingPart
        {
            get
            {
                return _imageRecognitionReqMatchPartValue;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid value");
                }

                Add<double>(_imageRecognitionReqMatchPartKey, value);
                _imageRecognitionReqMatchPartValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the part matching error for the image recognition attribute of the engine configuration.\n
        /// Allowable error of matches number. Value can be from 0 to 1 and the defalut is 0.1
        /// </summary>
        public double TolerantPartMatchingError
        {
            get
            {
                return _imageRecognitionTolerantPartMatchingErrorValue;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid value");
                }

                Add<double>(_imageRecognitionTolerantPartMatchingErrorKey, value);
                _imageRecognitionTolerantPartMatchingErrorValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the number of recognition results in the tracking history attribute of the engine configuration.\n
        /// Number of previous recognition results, which will influence the stabilization. Value is unsigned integer and the defalut is 3.
        /// </summary>
        public int TrackingHistoryAmount
        {
            get
            {
                return _imageTrackingHistoryAmountValue;
            }

            set
            {
                Add<int>(_imageTrackingHistoryAmountKey, value);
                _imageTrackingHistoryAmountValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the expected tracking offset attribute of the engine configuration.\n
        /// Relative offset value, for which the object offset is expected (relative to the object size in the current frame).
        /// Value is a double and the defalut is 0.
        /// </summary>
        public double ExpectedTrackingOffset
        {
            get
            {
                return _imageTrackingExpectedOffsetValue;
            }

            set
            {
                Add<double>(_imageTrackingExpectedOffsetKey, value);
                _imageTrackingExpectedOffsetValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the acceleration of the tracking stabilization attribute of the engine configuration.\n
        /// Acceleration will be used for image stabilization (relative to the distance from current location to stabilized location).
        /// Value is double from 0 to 1 and the defalut is 0.1.
        /// </summary>
        public double TrackingStabilizationAccelaration
        {
            get
            {
                return _imageTrackingStabilizationAccelarationValue;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid value");
                }

                Add<double>(_imageTrackingStabilizationAccelarationKey, value);
                _imageTrackingStabilizationAccelarationValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the speed of the tracking stabilization attribute of the engine configuration.\n
        /// Start speed will be used for image stabilization. Value is a double and the defalut is 0.3.
        /// </summary>
        public double TrackingStabilizationSpeed
        {
            get
            {
                return _imageTrackingStabilizationSpeedValue;
            }

            set
            {
                Add<double>(_imageTrackingStabilizationSpeedKey, value);
                _imageTrackingStabilizationSpeedValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the relative tolerant shift for the tracking stabilization attribute of the engine configuration.\n
        /// It is component of tolerant shift which will be ignored by stabilization process.
        /// </summary>
        public double TrackingStabilizationTolerantShift
        {
            get
            {
                return _imageTrackingStabilizationTolerantShiftValue;
            }

            set
            {
                Add<double>(_imageTrackingStabilizationTolerantShiftKey, value);
                _imageTrackingStabilizationTolerantShiftValue = value;
            }
        }

        /// <summary>
        /// Enables/disables the contour stabilization during tracking process. Default value is true.
        /// </summary>
        public bool UseTrackingStabilization
        {
            get
            {
                return _imageTrackingUseStabilizationValue;
            }

            set
            {
                Add<bool>(_imageTrackingUseStabilizationKey, value);
                _imageTrackingUseStabilizationValue = value;
            }
        }
    }
}
