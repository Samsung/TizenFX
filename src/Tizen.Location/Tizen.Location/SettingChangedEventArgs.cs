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
    public class SettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for SettingChangedEventArgs class.
        /// </summary>
        /// <param name="method"> The positioing method used for Location information.</param>
        /// <param name="enable"> Status of the method.</param>
        public SettingChangedEventArgs(LocationType type, bool enable)
        {
            LocationType = type;
            IsEnabled = enable;
        }

        /// <summary>
        /// Gets the currently used location method.
        /// </summary>
        public LocationType LocationType { get; private set; }

        /// <summary>
        /// Method to get the setting value changed.
        /// </summary>
        public bool IsEnabled { get; private set; }
    }
}
