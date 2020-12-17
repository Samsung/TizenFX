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

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for application component type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ApplicationComponentType
    {
        /// <summary>
        /// Component type is ui application.
        /// </summary>
        UIApplication = 0,

        /// <summary>
        /// Component type is service application.
        /// </summary>
        ServiceApplication,

        /// <summary>
        /// Component type is widget application.
        /// </summary>
        WidgetApplication,

        /// <summary>
        /// Component type is watch application.
        /// </summary>
        WatchApplication,

        /// <summary>
        /// Component type is component-based application.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        ComponentBasedApplication,
    }
}
