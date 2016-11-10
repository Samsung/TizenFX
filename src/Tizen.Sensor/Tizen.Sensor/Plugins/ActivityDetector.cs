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

namespace Tizen.Sensor
{
    public abstract class ActivityDetector : Sensor
    {
        protected const int ActivityAttribute = (((int)SensorType.InVehicleActivityDetector << 8) | 0x80 | 0x1);

        protected enum ActivityType
        {
            Unknown = 1,
            Stationary = 2,
            Walking = 4,
            Running = 8,
            InVehicle = 16,
            OnBicycle = 32,
        };

        /// <summary>
        /// Gets the activity accuracy of activity detector
        /// </summary>
        public SensorDataAccuracy ActivityAccuracy { get; protected set; }

        internal abstract void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data);

        internal ActivityDetector(uint index) : base(index)
        {
        }

        internal override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for activity detector");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for activity detector");
            }
        }
    }
}
