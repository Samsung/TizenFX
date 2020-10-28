/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.DisplayRotationUpdated"/> event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class DisplayRotationUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayRotationUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="rotation">A value indicating the updated display rotation.</param>
        /// <since_tizen> 6 </since_tizen>
        internal DisplayRotationUpdatedEventArgs(Rotation rotation)
        {
            Rotation = rotation;
        }

        /// <summary>
        /// Gets the updated display rotation.
        /// </summary>
        /// <value>The <see cref="Rotation"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public Rotation Rotation { get; }
    }
}