/// This File contains the Api's related to the ServerResponse class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


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
