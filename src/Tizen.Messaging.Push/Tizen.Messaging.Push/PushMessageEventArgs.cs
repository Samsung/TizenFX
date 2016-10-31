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
    /// An extended EventArgs class which contains the message received.
    /// </summary>
    public class PushMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gives the Application Data recieved. </summary>
        /// <value>
        /// It is the string which stores the application data.</value>
        public string AppData
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the Message Received Field.
        /// </summary>
        /// <value>
        /// It is the string which stores the message field.</value>
        public string Message
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the time at which the Notification was received.
        /// </summary>
        /// <value>
        /// It is the DateTime field representing the time at which the Notification was received.</value>
        public DateTime ReceivedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the Sender of the notification.
        /// </summary>
        /// <value>
        /// It is a string value representing the Sender of the Notification.</value>
        public string Sender
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the session ID of the notification.
        /// </summary>
        /// <value>
        /// It is a string value representing the session ID of the Notification.</value>
        public string SessionInfo
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the request Id of the notification.
        /// </summary>
        /// <value>
        /// It is a string value representing the request Id of the Notification.</value>
        public string RequestId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the value in the type field of the notification.
        /// </summary>
        /// <value>
        /// It is an integer value representing the type field of the notification.</value>
        public int Type
        {
            get;
            internal set;
        }

        internal PushMessageEventArgs()
        {
            // Giving Default Values
            AppData = "";
            Message = "";
            ReceivedAt = new DateTime();
            Sender = "";
            SessionInfo= "";
            RequestId = "";
        }
    }
}
