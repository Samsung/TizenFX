/// This File contains the Api's related to the PushMessageEventArgs class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


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
        /// Gives the request ID of the notification.
        /// </summary>
        /// <value>
        /// It is a string value representing the request ID of the Notification.</value>
        public string RequestID
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
            RequestID = "";
        }
    }
}
