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
    /// An extended EventArgs class which contains the changed location information.
    /// </summary>
    public class LocationChangedEventArgs : EventArgs
    {

        /// <summary>
        /// Class Constructor for LocationUpdatedEventArgs class.
        /// </summary>
        /// <param name="locationUpdate"> Object of Location class.</param>
        public LocationChangedEventArgs(Location updatatedLocation)
        {
            Location = updatatedLocation;
        }

        /// <summary>
        /// Get the Location Update information.
        /// </summary>
        public Location Location { get; private set; }
    }
}
