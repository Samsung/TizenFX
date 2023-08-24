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
    /// The HeartRateMonitorLEDGreenBatch changed event arguments class is used for storing the data returned by the HeartRateMonitorLEDGreenBatch sensor
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class HeartRateMonitorLEDGreenBatchDataUpdatedEventArgs : EventArgs
    {
        internal HeartRateMonitorLEDGreenBatchDataUpdatedEventArgs(IReadOnlyList<HeartRateMonitorLEDGreenBatchData> batchedDataList)
        {
            Data = batchedDataList;
        }
        /// <summary>
        /// Gets the series value of the HeartRateMonitorLEDGreenBatch.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> HeartRateMonitorLEDGreenBatchData. </value>
        public IReadOnlyList<HeartRateMonitorLEDGreenBatchData> Data { get; }
    }
}