/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen
{
    /// <summary>
    /// The Environment class provides the method to set environment variables through delegate.
    /// Delegate for System.Environment.SetEnvironmentVariable can't be created because it is overloaded, so
    /// Tizen.Environment.SetEnvironmentVariable wrapper is added.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Environment
    {
        /// <summary>
        /// Sets environment variable
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> 5.5 </since_tizen>
        public static void SetEnvironmentVariable(string variable, string value)
        {
            System.Environment.SetEnvironmentVariable(variable, value);
        }
    }
}
