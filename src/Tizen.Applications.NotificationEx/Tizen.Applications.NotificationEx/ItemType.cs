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
    /// Enumeration for item type.    
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum ItemType
    {
        /// <summary>
        /// A Text notification item type.
        /// </summary>
        Text = 1,

        /// <summary>
        /// A Image notification item type.
        /// </summary>
        Image = 2,

        /// <summary>
        /// A Button notification item type.
        /// </summary>
        Button = 4,

        /// <summary>
        /// A ChatMessage notification item type.
        /// </summary>
        ChatMessage = 5,

        /// <summary>
        /// A CheckBox notification item type.
        /// </summary>
        CheckBox = 6,

        /// <summary>
        /// A InputSelector notification item type.
        /// </summary>
        InputSelector = 8,

        /// <summary>
        /// A Group notification item type.
        /// </summary>
        Group = 9,

        /// <summary>
        /// A Entry notification item type.
        /// </summary>
        Entry = 10,

        /// <summary>
        /// A Progress notification item type.
        /// </summary>
        Progress = 11,

        /// <summary>
        /// A Time notification item type.
        /// </summary>
        Time = 12,

        /// <summary>
        /// A Custom notification item type.
        /// </summary>
        Custom = 100
    }
}
