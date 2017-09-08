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
    /// Represents a configuration of <see cref="PersonRecognizer"/> instances.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PersonRecognitionConfiguration : SurveillanceEngineConfiguration
    {
        private const string KeyFaceRecognitionModelFilePath = "MV_SURVEILLANCE_FACE_RECOGNITION_MODEL_FILE_PATH";

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRecognitionConfiguration"/> class.
        /// </summary>
        /// <param name="modelPath">Path to the face recognition model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelPath"/> is null.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public PersonRecognitionConfiguration(string modelPath)
        {
            FaceRecognitionModelPath = modelPath;
        }

        /// <summary>
        /// Gets or sets face recognition model file path.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="PersonRecognitionConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string FaceRecognitionModelPath
        {
            get
            {
                return GetString(KeyFaceRecognitionModelFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(FaceRecognitionModelPath));
                }
                Set(KeyFaceRecognitionModelFilePath, value);
            }
        }
    }
}
