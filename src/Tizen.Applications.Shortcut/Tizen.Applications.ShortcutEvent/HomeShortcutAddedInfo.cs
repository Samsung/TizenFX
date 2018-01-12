/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Tizen.Applications.Shortcut
{
    /// <summary>
    /// A class that contains the shortcut information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class HomeShortcutAddedInfo : ShortcutAddedInfo
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string AppId { get; internal set; }

        /// <summary>
        /// Gets the specific information for creating a new shortcut.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Uri { get; internal set; }
    }
}