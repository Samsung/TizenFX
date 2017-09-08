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
    /// Provides data for the <see cref="PersonAppearanceDetector.Detected"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PersonAppearanceDetectedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAppearanceDetectedEventArgs"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PersonAppearanceDetectedEventArgs(IEnumerable<Rectangle> appeared,
            IEnumerable<Rectangle> disappeared, IEnumerable<Rectangle> tracked)
        {
            AppearanceAreas = appeared;
            DisappearanceAreas = disappeared;
            TrackedAreas = tracked;
        }

        /// <summary>
        /// Gets a set of rectangular regions where appearances of the persons were detected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<Rectangle> AppearanceAreas { get; }

        /// <summary>
        /// Gets a set of rectangular regions where disappearances of the persons were detected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<Rectangle> DisappearanceAreas { get; }

        /// <summary>
        /// Gets a set of rectangular regions where persons were tracked.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<Rectangle> TrackedAreas { get; }
    }
}
