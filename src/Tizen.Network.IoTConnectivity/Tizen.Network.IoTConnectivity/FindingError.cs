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


namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Enumeration for resource found errors.
    /// </summary>
    internal enum FindingError
    {
        /// <summary>
        /// I/O error.
        /// </summary>
        Io = 1,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// No data available.
        /// </summary>
        NoData,
        /// <summary>
        /// Time out.
        /// </summary>
        TimeOut,
        /// <summary>
        /// IoTivity errors.
        /// </summary>
        Iotivity,
        /// <summary>
        /// Representation errors.
        /// </summary>
        Representation,
        /// <summary>
        /// Invalid type.
        /// </summary>
        InvalidType,
        /// <summary>
        /// Already.
        /// </summary>
        Already,
        /// <summary>
        /// System errors.
        /// </summary>
        System
    }
}
