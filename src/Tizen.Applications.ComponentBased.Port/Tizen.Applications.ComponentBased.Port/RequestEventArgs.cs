/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// Arguments for the event raised when the request is received.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class RequestEventArgs : EventArgs
    {
        internal RequestEventArgs(string sender, object request, bool isReplyRequested)
        {
            Sender = sender;
            Request = request;
            IsReplyRequested = isReplyRequested;
            Reply = null;
        }

        /// <summary>
        /// The name of the sender port
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Sender
        {
            get;
            internal set;
        }

        /// <summary>
        /// The received serialized data.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public object Request
        {
            get;
            internal set;
        }

        /// <summary>
        /// The flag indicating whether the reply is requested or not.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsReplyRequested
        {
            get;
            internal set;
        }

        /// <summary>
        /// The serialized reply data.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public object Reply
        {
            get;
            set;
        }
    }
}
