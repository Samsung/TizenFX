// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Sensor
{
    /// <summary>
    /// Sensor accuracy changed event arguments Class. Contains the parameters to be returned through accuracy callback
    /// </summary>
    public class SensorAccuracyChangedEventArgs : EventArgs
    {
        internal SensorAccuracyChangedEventArgs(TimeSpan timespan, SensorDataAccuracy accuracy)
        {
            TimeSpan = timespan;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Gets the time stamp.
        /// </summary>
        public TimeSpan TimeSpan { get; private set; }

        /// <summary>
        /// Gets the accuracy.
        /// </summary>
        public SensorDataAccuracy Accuracy { get; private set; }
    }
}