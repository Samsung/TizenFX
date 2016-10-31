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
    /// Enumeration for result of response
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Indicates result of response for success
        /// </summary>
        Ok = 0,
        /// <summary>
        /// Indicates result of response for some error
        /// </summary>
        Error,
        /// <summary>
        /// Indicates result of response for created resource
        /// </summary>
        Created,
        /// <summary>
        ///  Indicates result of response for deleted resource
        /// </summary>
        Deleted,
        /// <summary>
        ///  Indicates result of response for changed resource
        /// </summary>
        Changed,
        /// <summary>
        /// Indicates result of response for slow resource
        /// </summary>
        Slow,
        /// <summary>
        /// Indicates result of response for accessing unauthorized resource
        /// </summary>
        Forbidden
    }
}
