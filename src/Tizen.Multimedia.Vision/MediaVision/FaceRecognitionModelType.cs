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
    /// Specifies the face recognition model learning algorithms.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API15.")]
    public enum FaceRecognitionModelType
    {
        /// <summary>
        /// Eigenfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        EigenFaces = 1,

        /// <summary>
        /// Fisherfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FisherFaces,

        /// <summary>
        /// Local Binary Patterns Histograms (LBPH); The default type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Lbph
    }
}
