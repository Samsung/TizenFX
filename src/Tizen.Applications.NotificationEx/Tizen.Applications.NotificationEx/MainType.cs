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

namespace Tizen.Applications.NotificationEx
{
    /// <summary>
    /// Enumeration for main type.    
    /// </summary>
    /// <remarks>
    /// Developers can designate AbstractItem's main item using the SetMainType method.
    /// </remarks>
    /// <since_tizen> 7 </since_tizen>
    public enum MainType
    {
        /// <summary>
        /// The main title of the notification item.
        /// </summary>
        Title = 1,
        /// <summary>
        /// The main contents of the notification item.
        /// </summary>
        Contents = 2,
        /// <summary>
        /// The main icon of the notification item.
        /// </summary>
        Icon = 3,
        /// <summary>
        /// The main button of the notification item.
        /// </summary>
        Button = 4
    }
}
