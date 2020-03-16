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

namespace Tizen.BatteryMonitor
{
    /// <summary>
    /// Enumeration for battery consuming features.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ResourceType {
        /// <summary>
        /// Bluetooth Low Energy.
        /// </summary>
        Ble = 0,

        /// <summary>
        /// Wi-Fi.
        /// </summary>
        Wifi,

        /// <summary>
        /// CPU.
        /// </summary>
        Cpu,

        /// <summary>
        /// Display.
        /// </summary>
        Display,

        /// <summary>
        /// Network.
        /// </summary>
        DeviceNetwork,

        /// <summary>
        /// GPS.
        /// </summary>
        GpsSensor,

        /// <summary>
        /// Heart Rate Monitor.
        /// </summary>
        HrmSensor,

        /// <summary>
        /// Battery.
        /// </summary>
        Battery
    }

    /// <summary>
    /// Enumeration for feature data collection period.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum DurationType {

        /// <summary>
        /// Set the period from a day ago to now.
        /// </summary>
        Day = 0,

        /// <summary>
        /// Set the period from a week ago to now.
        /// </summary>
        Week
    }

}