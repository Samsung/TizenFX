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
    /// Provides data for the <see cref="MediaControllerManager.ServerStarted"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaControlServerStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlServerStartedEventArgs"/> class.
        /// </summary>
        /// <param name="mediaController">A <see cref="MediaController"/> of the server.</param>
        /// <exception cref="ArgumentNullException"><paramref name="mediaController"/> is null.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlServerStartedEventArgs(MediaController mediaController)
        {
            Controller = mediaController ?? throw new ArgumentNullException(nameof(mediaController));
        }

        /// <summary>
        /// Gets the controller of the server added.
        /// </summary>
        /// <value>A <see cref="MediaController"/>.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaController Controller { get; }
    }
}