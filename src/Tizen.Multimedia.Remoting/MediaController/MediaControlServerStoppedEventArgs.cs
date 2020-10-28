/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Provides data for the <see cref="MediaControllerManager.ServerStopped"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaControlServerStoppedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlServerStoppedEventArgs"/> class.
        /// </summary>
        /// <param name="serverAppId">The application id of the server stopped.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serverAppId"/> is null.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlServerStoppedEventArgs(string serverAppId)
        {
            ServerAppId = serverAppId ?? throw new ArgumentNullException(nameof(serverAppId));
        }

        /// <summary>
        /// Gets the application id of the server.
        /// </summary>
        /// <value>A string represents the application id.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ServerAppId { get; }
    }
}