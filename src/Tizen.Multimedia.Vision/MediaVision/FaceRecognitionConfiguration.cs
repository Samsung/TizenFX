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
    /// Represents a configuration of <see cref="FaceRecognizer"/> instances.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <since_tizen> 4 </since_tizen>
    public class FaceRecognitionConfiguration : EngineConfiguration
    {
        private const string KeyModelType = "MV_FACE_RECOGNITION_MODEL_TYPE";

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRecognitionConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FaceRecognitionConfiguration() : base("face_recognition")
        {
        }

        /// <summary>
        /// Gets or sets the method used for face recognition model learning.
        /// Default value is <see cref="FaceRecognitionModelType.Lbph"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FaceRecognitionModelType ModelType
        {
            get
            {
                return (FaceRecognitionModelType)GetInt(KeyModelType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(FaceRecognitionModelType), value);
                Set(KeyModelType, (int)value);
            }
        }

    }
}
