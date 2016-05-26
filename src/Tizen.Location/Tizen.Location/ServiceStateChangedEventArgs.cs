// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;


namespace Tizen.Location
{
    /// <summary>
    /// An extended EventArgs class which contains the changed location service state.
    /// </summary>
    public class ServiceStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for ServiceStateChangedEventArgs class.
        /// </summary>
        /// <param name="state"> An enumeration of type LocationServiceState.</param>
        public ServiceStateChangedEventArgs(ServiceState state)
        {

            ServiceState = state;
        }

        /// <summary>
        /// Get the Service state.
        /// </summary>
        public ServiceState ServiceState { get; private set; }
    }
}
