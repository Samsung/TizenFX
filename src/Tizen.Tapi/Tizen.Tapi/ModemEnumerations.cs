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

namespace Tizen.Tapi
{
    /// <summary>
    /// Enumeration for the phone power status values.
    /// </summary>
    public enum PhonePowerStatus
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Power on.
        /// </summary>
        On,
        /// <summary>
        /// Power off.
        /// </summary>
        Off,
        /// <summary>
        /// Power reset.
        /// </summary>
        Reset,
        /// <summary>
        /// Power low.
        /// </summary>
        Low,
        /// <summary>
        /// Error.
        /// </summary>
        Error
    }

    /// <summary>
    /// Enumeration for the phone power reset commands.
    /// </summary>
    public enum PhonePowerCommand
    {
        /// <summary>
        /// On.
        /// </summary>
        On = 0,
        /// <summary>
        /// Off.
        /// </summary>
        Off,
        /// <summary>
        /// Reset.
        /// </summary>
        Reset,
        /// <summary>
        /// Low value.
        /// </summary>
        Low,
        /// <summary>
        /// Max value.
        /// </summary>
        Max = Low
    }

    /// <summary>
    /// Enumeration for flight mode request type.
    /// </summary>
    public enum PowerFlightModeRequest
    {
        /// <summary>
        /// Off.
        /// </summary>
        Enter = 0x01,
        /// <summary>
        /// On.
        /// </summary>
        Leave,
        /// <summary>
        /// Max value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for flight mode request type.
    /// </summary>
    public enum PowerFlightModeResponse
    {
        /// <summary>
        /// Flight mode on success.
        /// </summary>
        On = 0x01,
        /// <summary>
        /// Flight mode off success.
        /// </summary>
        Off,
        /// <summary>
        /// Flight mode request fail.
        /// </summary>
        Fail,
        /// <summary>
        /// Max value.
        /// </summary>
        Max
    }
}
