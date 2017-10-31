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

namespace Tizen.Common
{
    /// <summary>
    /// The DotnetUtil class provides the .NET API version.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class DotnetUtil
    {
        /// <summary>
        /// Gets the version of Tizen .NET API.
        /// </summary>
        /// <returns>The Tizen .NET API version</returns>
        /// <since_tizen> 4 </since_tizen>
        public static int TizenAPIVersion
        {
            get
            {
                int version = 0;
                DotnetUtilError ret = (DotnetUtilError)Interop.DotnetUtil.GetVconfInt("db/dotnet/tizen_api_version", out version);
                if (ret != DotnetUtilError.None)
                {
                    Log.Warn(DotnetUtilErrorFactory.LogTag, "unable to get Tizen .NET API version.");
                }
                return version;
            }
        }
    }
}
