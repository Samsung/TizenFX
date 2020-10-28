/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;

namespace Tizen.Sensor
{
    /// <summary>
    /// Abstract sensor for series of sensor data
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public abstract class BatchSensor<TData> : Sensor where TData : Tizen.Sensor.BatchData
    {
        /// <summary>
        /// Create BatchSensor
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public BatchSensor(uint index = 0) : base(index) {
            UpdateBatchData((IntPtr)null, 0);
        }

        /// <summary>
        /// Get general batch data
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public IReadOnlyList<TData> Data { get; protected set; }

        /// <summary>
        /// Convert general batch data to specific batch data
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <returns> List of converted specific batch data </returns>
        protected abstract IReadOnlyList<TData> ConvertBatchData();

        /// <summary>
        /// Update the internal batch data using the latest events
        /// </summary>
        /// <param name="eventsPtr">
        /// General batch data's raw pointer
        /// </param>
        /// <param name="eventsCount">
        /// Number of general batch events
        /// </param>
        protected void UpdateBatchData(IntPtr eventsPtr, uint eventsCount)
        {
            updateBatchEvents(eventsPtr, eventsCount);
            Data = ConvertBatchData();
        }
    }
}
