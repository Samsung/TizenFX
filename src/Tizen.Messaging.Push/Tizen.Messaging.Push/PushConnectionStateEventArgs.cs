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

namespace Tizen.Messaging.Push
{
    /// <summary>
    /// An extended EventArgs class, which contains the State Information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PushConnectionStateEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for the different states.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum PushState
        {
            /// <summary>
            /// Registered with the Server.
            /// </summary>
            Registered = 0,
            /// <summary>
            /// Unregistered.
            /// </summary>
            Unregistered = 1,
            /// <summary>
            /// To change the provisioning server IP.
            /// </summary>
            ProvisioningIPChanged = 2,
            /// <summary>
            /// Ping interval is changing.
            /// </summary>
            PingChanged = 3,
            /// <summary>
            /// Error Occured in Changing State.
            /// </summary>
            StateError = 4
        }

        /// <summary>
        /// Gives the current state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// It is the current state.
        /// </value>
        public PushState State
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives information about the error if set.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// It is the string, which contains the error string if set.
        /// </value>
        public string Error
        {
            get;
            internal set;
        }

        internal PushConnectionStateEventArgs(PushState state, string error)
        {
            State = state;
            Error = error;
        }
    }
}
