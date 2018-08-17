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
using Tizen.Applications;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaControlServer.CustomCommandReceived"/> event.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class CustomCommandReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCommandReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="clientAppId">The client application id.</param>
        /// <param name="requestId">The request id of the media controller client.</param>
        /// <param name="command">The playback custom command.</param>
        /// <param name="bundleHandle">The extra data.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="clientAppId"/> or <paramref name="requestId"/> or <paramref name="command"/> is null.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public CustomCommandReceivedEventArgs(string clientAppId, string requestId, string command, SafeBundleHandle bundleHandle)
        {
            ClientAppId = clientAppId ?? throw new ArgumentNullException(nameof(clientAppId));
            RequestID = requestId ?? throw new ArgumentNullException(nameof(requestId));
            Command = command ?? throw new ArgumentNullException(nameof(command));

            if (bundleHandle != null)
            {
                Bundle = new Bundle(bundleHandle);
            }
        }

        /// <summary>
        /// Gets the application id of the client that sent command.
        /// </summary>
        /// <value>The client application id.</value>
        /// <since_tizen> 5 </since_tizen>
        public string ClientAppId { get; }

        /// <summary>
        /// Gets the reqeust id
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string RequestID { get; }

        /// <summary>
        /// Gets the custom command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Command { get; }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Bundle Bundle { get; }
    }
}