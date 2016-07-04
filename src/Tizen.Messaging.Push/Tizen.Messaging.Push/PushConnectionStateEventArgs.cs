/// This File contains the Api's related to the PushConnectionStateEventArgs class
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
    /// An extended EventArgs class which contains the State Information.
    /// </summary>
    public class PushConnectionStateEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for the different states.
        /// </summary>
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
        /// <value>
        /// It is the current state.</value>
        public PushState State
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives information about the error if set.
        /// </summary>
        /// <value>
        /// It is the string which contains the error string if set.</value>
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
