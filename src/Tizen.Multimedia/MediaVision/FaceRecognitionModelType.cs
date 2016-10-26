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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for face recognition model learning attribute of the engine configuration.
    /// </summary>
    public enum FaceRecognitionModelType
    {
        /// <summary>
        /// Unknown method
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Eigenfaces
        /// </summary>
        EigenFaces,
        /// <summary>
        /// Fisherfaces
        /// </summary>
        FisherFaces,
        /// <summary>
        /// Local Binary Patterns Histograms (LBPH) - This is the default type
        /// </summary>
        LBPH
    }
}
