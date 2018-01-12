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
    /// A class to get the information of the shortcut.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ShortcutInfo
    {
        /// <summary>
        /// Gets or sets the name of the created shortcut icon.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ShortcutName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the absolute path of an icon file for this shortcut.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string IconPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether to allow or not allow duplication.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool IsAllowDuplicate { get; set; }
    }
}