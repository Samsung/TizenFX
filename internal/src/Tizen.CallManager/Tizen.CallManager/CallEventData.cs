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

namespace Tizen.CallManager
{
    /// <summary>
    /// A class which contains information about call event data.
    /// </summary>
    public class CallEventData
    {
        internal uint EventId;
        internal MultiSimSlot Slot;
        internal CallEndCause Cause;
        internal CallData Incoming;
        internal CallData Active;
        internal CallData Held;
        internal CallEventData()
        {
        }

        /// <summary>
        /// Get the Call id of the number for which Call event has occurred.
        /// </summary>
        public uint Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// Get the Sim slot type.
        /// </summary>
        public MultiSimSlot SimSlot
        {
            get
            {
                return Slot;
            }
        }

        /// <summary>
        /// Get call end cause type.
        /// </summary>
        public CallEndCause EndCause
        {
            get
            {
                return Cause;
            }
        }

        /// <summary>
        /// Get incoming call data.
        /// </summary>
        public CallData IncomingData
        {
            get
            {
                return Incoming;
            }
        }

        /// <summary>
        /// Get active call data.
        /// </summary>
        public CallData ActiveData
        {
            get
            {
                return Active;
            }
        }

        /// <summary>
        /// Get the call data for held call.
        /// </summary>
        public CallData HeldData
        {
            get
            {
                return Held;
            }
        }
    }
}
