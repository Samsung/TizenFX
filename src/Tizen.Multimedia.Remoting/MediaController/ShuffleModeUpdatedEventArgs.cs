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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.ShuffleModeUpdated"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ShuffleModeUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShuffleModeUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="enabled">A value indicating whether the shuffle mode is enabled.</param>
        /// <since_tizen> 4 </since_tizen>
        public ShuffleModeUpdatedEventArgs(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Gets a value indicating whether the shuffle mode is enabled.
        /// </summary>
        /// <value>true if the shuffle mode is enabled; otherwise, false.</value>
        /// <since_tizen> 4 </since_tizen>
        public bool Enabled { get; }
    }
}