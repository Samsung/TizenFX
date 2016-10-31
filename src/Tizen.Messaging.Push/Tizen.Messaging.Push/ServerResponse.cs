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

namespace Tizen.Messaging.Push
{
    /// <summary>
    /// The ServerResponse structure provides the result and the server response if any.
    /// </summary>
    public struct ServerResponse
    {
        /// <summary>
        /// Enumeration for the Result from the server.
        /// </summary>
        public enum Result
        {
            /// <summary>
            /// Successful.
            /// </summary>
            Success = 0,
            /// <summary>
            /// Time Out Occured.
            /// </summary>
            Timeout = 1,
            /// <summary>
            /// Server Error Occured.
            /// </summary>
            ServerError = 2,
            /// <summary>
            /// System Error Occured.
            /// </summary>
            SystemError = 3
        }

        /// <summary>
        /// Gives the Result of the opeartion.
        /// </summary>
        /// <value>
        /// It is the Result state of the operation performed.</value>
        public Result ServerResult
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the Message from the server.
        /// </summary>
        /// <value>
        /// It is the Message sent by the server.</value>
        public string ServerMessage
        {
            get;
            internal set;
        }
    }
}
