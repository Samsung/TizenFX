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
using System.Collections.Generic;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides data for the <see cref="PersonRecognizer.Recognized"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API15.")]
    public class PersonRecognizedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRecognizedEventArgs"/> class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API15.")]
        public PersonRecognizedEventArgs(IEnumerable<PersonRecognitionInfo> recognitionInfo)
        {
            Recognitions = recognitionInfo;
        }

        /// <summary>
        /// Gets a set of information that correspond to the recognized persons.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API15.")]
        public IEnumerable<PersonRecognitionInfo> Recognitions { get; }
    }
}
