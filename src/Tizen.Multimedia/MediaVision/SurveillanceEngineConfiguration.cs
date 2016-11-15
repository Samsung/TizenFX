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
    /// This class represents concrete EngineConfig for creation of video surveillance systems.
    /// </summary>
    public class SurveillanceEngineConfiguration : EngineConfiguration
    {
        private const string _faceRecognitionModelFilePathKey = "MV_SURVEILLANCE_FACE_RECOGNITION_MODEL_FILE_PATH";
        private const string _movementDetectionThresholdKey = "MV_SURVEILLANCE_MOVEMENT_DETECTION_THRESHOLD";
        private const string _skipFramesCountKey = "MV_SURVEILLANCE_SKIP_FRAMES_COUNT";
        private string _faceRecognitionModelFilePathValue;
        private int _movementDetectionThresholdValue = 10;
        private int _skipFramesCountValue = 0;

        /// <summary>
        /// The default constructor of SurveillanceEngineConfiguration class
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public SurveillanceEngineConfiguration()
            : base()
        {
            FaceRecognitionModelFilePath = _faceRecognitionModelFilePathValue;
            MovementDetectionThreshold = _movementDetectionThresholdValue;
            SkipFramesCount = _skipFramesCountValue;
        }

        /// <summary>
        /// Sets and gets face recognition model file path.\n
        /// This value HAS TO BE set in engine configuration before subscribing on PersonRecognized event trigger.
        /// </summary>
        public string FaceRecognitionModelFilePath
        {
            get
            {
                return _faceRecognitionModelFilePathValue;
            }

            set
            {
                Add<string>(_faceRecognitionModelFilePathKey, value);
                _faceRecognitionModelFilePathValue = value;
            }
        }

        /// <summary>
        /// Sets and gets movement detection threshold.\n
        /// This value might be set in engine configuration before subscription on MovementDetected event trigger to specify sensitivity of the movement
        /// detector. This value has to be integer in 0..255 range where 255 means that no movements will be detected, and 0 means that all frame changes
        /// will be interpreted as movements. Default value is 10.
        /// </summary>
        public int MovementDetectionThreshold
        {
            get
            {
                return _movementDetectionThresholdValue;
            }

            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Invalid value");
                }

                Add<int>(_movementDetectionThresholdKey, value);
                _movementDetectionThresholdValue = value;
            }
        }

        /// <summary>
        /// Sets and gets how many frames will be skipped during push source.\n
        /// This integer value might be set in engine configuration to specify number of PushSource() function calls will be ignored by subscription
        /// of the event trigger. Default value is 0. It means that no frames will be skipped and all mv_surveillance_push_source() function calls will
        /// be processed.
        /// </summary>
        public int SkipFramesCount
        {
            get
            {
                return _skipFramesCountValue;
            }

            set
            {
                Add<int>(_skipFramesCountKey, value);
                _skipFramesCountValue = value;
            }
        }
    }
}
