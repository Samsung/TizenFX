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

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// An extended EventArgs class, which contains remote message port information and message.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Contains AppId, port name, and trusted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RemoteValues Remote { get; internal set; }

        /// <summary>
        /// The message passed from the remote application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Bundle Message { get; internal set; }
    }
}
