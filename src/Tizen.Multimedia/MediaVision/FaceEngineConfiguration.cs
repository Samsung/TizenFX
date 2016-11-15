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
    /// This class represents concrete EngineConfig for Face detection and recognition
    /// </summary>
    public class FaceEngineConfiguration : EngineConfiguration
    {
        // List of predefined keys
        private const string _faceDetectionModelFilePathKey = "MV_FACE_DETECTION_MODEL_FILE_PATH";
        private const string _faceRecognitionModelTypeKey = "MV_FACE_RECOGNITION_MODEL_TYPE";
        private const string _faceDetectionRoiXKey = "MV_FACE_DETECTION_ROI_X";
        private const string _faceDetectionRoiYKey = "MV_FACE_DETECTION_ROI_Y";
        private const string _faceDetectionRoiWidthKey = "MV_FACE_DETECTION_ROI_WIDTH";
        private const string _faceDetectionRoiHeightKey = "MV_FACE_DETECTION_ROI_HEIGHT";
        private const string _faceDetectionMinWidthKey = "MV_FACE_DETECTION_MIN_SIZE_WIDTH";
        private const string _faceDetectionMinHeightKey = "MV_FACE_DETECTION_MIN_SIZE_HEIGHT";
        // Values are cached below to prevent interop calls for get operation
        private string _faceDetectionModelFilePathValue;
        private FaceRecognitionModelType _faceRecognitionModelTypeValue = FaceRecognitionModelType.LBPH;
        private int _faceDetectionRoiXValue = -1;
        private int _faceDetectionRoiYValue = -1;
        private int _faceDetectionRoiWidthValue = -1;
        private int _faceDetectionRoiHeightValue = -1;
        private int _faceDetectionMinWidthValue = -1;
        private int _faceDetectionMinHeightValue = -1;

        /// <summary>
        /// The default constructor of FaceEngineConfig class
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public FaceEngineConfiguration()
            : base()
        {
            ModelFilePath = _faceDetectionModelFilePathValue;
            ModelType = _faceRecognitionModelTypeValue; ;
            MinimumHeight = _faceDetectionMinHeightValue;
            MinimumWidth = _faceDetectionMinWidthValue;
            RoiHeight = _faceDetectionRoiHeightValue;
            RoiWidth = _faceDetectionRoiWidthValue;
            RoiX = _faceDetectionRoiXValue;
            RoiY = _faceDetectionRoiYValue;
        }

        /// <summary>
        /// Sets and gets face detection haarcascade xml file attribute of the engine configuration.
        /// </summary>
        public string ModelFilePath
        {
            get
            {
                return _faceDetectionModelFilePathValue;
            }

            set
            {
                Add<string>(_faceDetectionModelFilePathKey, value);
                _faceDetectionModelFilePathValue = value;
            }
        }

        /// <summary>
        /// Sets and gets the method used for face recognition model learning attribute of the engine configuration.
        /// </summary>
        public FaceRecognitionModelType ModelType
        {
            get
            {
                return _faceRecognitionModelTypeValue;
            }

            set
            {
                if (value == FaceRecognitionModelType.Unknown)
                {
                    throw new ArgumentException("ModelType value is invalid");
                }

                Add<int>(_faceRecognitionModelTypeKey, (int)value);
                _faceRecognitionModelTypeValue = value;
            }
        }

        /// <summary>
        /// Sets and gets minimum height of face which will be detected as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (all detected faces will be applied) can be changed to specify the minimum face height.
        /// </remarks>
        public int MinimumHeight
        {
            get
            {
                return _faceDetectionMinHeightValue;
            }

            set
            {
                Add<int>(_faceDetectionMinHeightKey, value);
                _faceDetectionMinHeightValue = value;
            }
        }

        /// <summary>
        /// Sets and gets minimum width of face which will be detected as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (all detected faces will be applied) can be changed to specify the minimum face width.
        /// </remarks>
        public int MinimumWidth
        {
            get
            {
                return _faceDetectionMinWidthValue;
            }

            set
            {
                Add<int>(_faceDetectionMinWidthKey, value);
                _faceDetectionMinWidthValue = value;
            }
        }

        /// <summary>
        /// Sets and gets height of face detection roi as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (the roi will be a full image) can be changed to specify the roi for face detection.
        /// </remarks>
        public int RoiHeight
        {
            get
            {
                return _faceDetectionRoiHeightValue;
            }

            set
            {
                Add<int>(_faceDetectionRoiHeightKey, value);
                _faceDetectionRoiHeightValue = value;
            }
        }

        /// <summary>
        /// Sets and gets width of face detection roi as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (the roi will be a full image) can be changed to specify the roi for face detection
        /// </remarks>
        public int RoiWidth
        {
            get
            {
                return _faceDetectionRoiWidthValue;
            }

            set
            {
                Add<int>(_faceDetectionRoiWidthKey, value);
                _faceDetectionRoiWidthValue = value;
            }
        }

        /// <summary>
        /// Sets and gets X coordinate of face detection roi as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (the roi will be a full image) can be changed to specify the roi for face detection
        /// </remarks>
        public int RoiX
        {
            get
            {
                return _faceDetectionRoiXValue;
            }

            set
            {
                Add<int>(_faceDetectionRoiXKey, value);
                _faceDetectionRoiXValue = value;
            }
        }

        /// <summary>
        /// Sets and gets Y coordinate of face detection roi as attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// Default value is -1 (the roi will be a full image) can be changed to specify the roi for face detection
        /// </remarks>
        public int RoiY
        {
            get
            {
                return _faceDetectionRoiYValue;
            }

            set
            {
                Add<int>(_faceDetectionRoiYKey, value);
                _faceDetectionRoiYValue = value;
            }
        }
    }
}
