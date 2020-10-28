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
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.ShuffleModeCapabilityUpdated"/> event.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class ShuffleModeCapabilityUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShuffleModeCapabilityUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="support">The shuffle mode capabilities.</param>
        /// <exception cref="ArgumentException"><paramref name="support"/> is not vaild.</exception>
        /// <since_tizen> 5 </since_tizen>
        public ShuffleModeCapabilityUpdatedEventArgs(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Support = support;
        }

        /// <summary>
        /// Gets the value whether the shuffle mode is supported or not.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport Support { get; }
    }
}