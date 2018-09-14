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

using Tizen.Applications;
using System;
using NativeClient = Interop.MediaControllerClient;
using NativeServer = Interop.MediaControllerServer;
using NativeClientHandle = Interop.MediaControllerClientHandle;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to send command to media control client.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Event
    {
        private string _requestId;

        internal NativeClientHandle _clientHandle;

        /// <summary>
        /// The client id.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected string _clientId;

        /// <summary>
        /// The server id.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected string _serverId;

        /// <summary>
        /// Initializes a <see cref="Event"/> base class.
        /// </summary>
        protected Event() { }

        internal abstract string Request(IntPtr serverHandle);

        internal void Response(IntPtr handle, int result, Bundle bundle)
        {
            if (bundle != null)
            {
                NativeClient.SendCustomEventReplyBundle(_clientHandle, _serverId, _requestId, result, bundle.SafeBundleHandle)
                    .ThrowIfError("Failed to response event.");
            }
            else
            {
                NativeClient.SendCustomEventReply(_clientHandle, _serverId, _requestId, result, IntPtr.Zero)
                    .ThrowIfError("Failed to repose event.");
            }
        }

        /// <summary>
        /// Sets the information that needed to request event.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        internal void SetRequestInformation(string clientId)
        {
            _clientId = clientId;
        }

        /// <summary>
        /// Sets the information that needed to response event.
        /// </summary>
        /// <param name="clientrHandle">The client handle.</param>
        /// <param name="requestId">The request Id for each command.</param>
        internal void SetResponseInformation(NativeClientHandle clientrHandle, string requestId)
        {
            _clientHandle = clientrHandle;
            _requestId = requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send custom event.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public sealed class CustomEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEvent"/> class.
        /// </summary>
        /// <param name="customEvent">A predefined custom event.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomEvent(string customEvent)
        {
            Event = customEvent ?? throw new ArgumentNullException("Custom event is not set.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEvent"/> class.
        /// </summary>
        /// <param name="customEvent">A predefined custom event.</param>
        /// <param name="bundle">The extra data for custom event.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomEvent(string customEvent, Bundle bundle)
            : this(customEvent)
        {
            Bundle = bundle;
        }

        ///<summary>
        /// Gets the custom event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Event { get; }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Bundle Bundle { get; }

        internal override string Request(IntPtr serverHandle)
        {
            string requestId = null;

            if (Bundle != null)
            {
                NativeServer.SendCustomEventBundle(serverHandle, _clientId, Event,  Bundle.SafeBundleHandle, out requestId)
                    .ThrowIfError("Failed to send costom event.");
            }
            else
            {
                NativeServer.SendCustomEvent(serverHandle, _clientId, Event, IntPtr.Zero, out requestId)
                    .ThrowIfError("Failed to send costom event.");
            }

            return requestId;
        }
    }
}