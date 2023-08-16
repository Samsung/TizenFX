/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Provides data for the <see cref="MediaController.Mode360CapabilityUpdated"/> event.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class Mode360CapabilityUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mode360CapabilityUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="support">The mode360 capability.</param>
        /// <exception cref="ArgumentException"><paramref name="support"/> is not valid.</exception>
        /// <since_tizen> 11 </since_tizen>
        internal Mode360CapabilityUpdatedEventArgs(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Support = support;
        }

        /// <summary>
        /// Gets the value whether the mode360 is supported or not.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public MediaControlCapabilitySupport Support { get; }
    }
}