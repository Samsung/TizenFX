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
    /// Provides data for the <see cref="MediaControlServer.PlaybackCommandReceived"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Please do not use! This will be deprecated. Please use PlaybackActionCommandReceived instead.")]
    public class PlaybackCommandReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommandReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="clientAppId">The client application id.</param>
        /// <param name="command">The playback command.</param>
        /// <exception cref="ArgumentNullException"><paramref name="clientAppId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="command"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PlaybackCommandReceivedEventArgs(string clientAppId, MediaControlPlaybackCommand command)
        {
            if (clientAppId == null)
            {
                throw new ArgumentNullException(nameof(clientAppId));
            }

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), command, nameof(command));

            ClientAppId = clientAppId;
            Command = command;
        }

        /// <summary>
        /// Gets the application id of the client that sent command.
        /// </summary>
        /// <value>The client application id.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ClientAppId { get; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The <see cref="MediaControlPlaybackCommand"/>.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlPlaybackCommand Command { get; }
    }
}