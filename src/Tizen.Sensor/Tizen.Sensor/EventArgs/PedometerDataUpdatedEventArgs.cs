// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// Pedometer changed event arguments. Class for storing the data returned by pedometer
    /// </summary>
    public class PedometerDataUpdatedEventArgs : EventArgs
    {
        internal PedometerDataUpdatedEventArgs(float[] values)
        {
            StepCount = (uint) values[0];
            WalkStepCount = (uint) values[1];
            RunStepCount = (uint) values[2];
            MovingDistance = values[3];
            CalorieBurned = values[4];
            LastSpeed = values[5];
            LastSteppingFrequency = values[6];
            LastStepStatus = (PedometerState) values[7];
        }

        /// <summary>
        /// Gets the step count
        /// </summary>
        public uint StepCount { get; private set; }

        /// <summary>
        /// Gets the walking step count
        /// </summary>
        public uint WalkStepCount { get; private set; }

        /// <summary>
        /// Gets the running step count
        /// </summary>
        public uint RunStepCount { get; private set; }

        /// <summary>
        /// Gets the moving distance
        /// </summary>
        public float MovingDistance { get; private set; }

        /// <summary>
        /// Gets the calorie burned
        /// </summary>
        public float CalorieBurned { get; private set; }

        /// <summary>
        /// Gets the last speed
        /// </summary>
        public float LastSpeed { get; private set; }

        /// <summary>
        /// Gets the last stepping frequency
        /// </summary>
        public float LastSteppingFrequency { get; private set; }

        /// <summary>
        /// Gets the last step status
        /// </summary>
        public PedometerState LastStepStatus { get; private set; }
    }
}
