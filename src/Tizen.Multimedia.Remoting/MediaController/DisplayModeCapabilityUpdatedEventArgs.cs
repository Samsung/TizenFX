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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.DisplayModeCapabilityUpdated"/> event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class DisplayModeCapabilityUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayModeCapabilityUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="mode">The supported list of display mode capabilities.</param>
        /// <since_tizen> 6 </since_tizen>
        internal DisplayModeCapabilityUpdatedEventArgs(IList<MediaControlDisplayMode> mode)
        {
            DisplayMode = new ReadOnlyCollection<MediaControlDisplayMode>(mode);
        }

        /// <summary>
        /// Gets the supported list of display mode capabilities.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ReadOnlyCollection<MediaControlDisplayMode> DisplayMode { get; }
    }
}