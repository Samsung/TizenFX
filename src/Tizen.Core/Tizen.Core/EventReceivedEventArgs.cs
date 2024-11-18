/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Core
{
    /// <summary>
    /// Represents the arguments passed to the event handler when the event data is received.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class EventReceivedEventArgs : System.EventArgs
    {
        internal EventReceivedEventArgs(EventObject eventObject)
        {
            if (eventObject == null)
            {
                throw new ArgumentNullException(nameof(eventObject));
            }

            Id = eventObject.Id;
            Data = eventObject.Data;
        }

        /// <summary>
        /// Gets the ID of the received object.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the Data of the received object.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public object Data { get; private set; }
    }
}
