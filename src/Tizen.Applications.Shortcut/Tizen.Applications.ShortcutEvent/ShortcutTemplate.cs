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
    /// A class that contains the preset list of the shortcut template from the installed package.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ShortcutTemplate
    {
        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string AppId { get; internal set; }

        /// <summary>
        /// Gets the name of the created shortcut icon.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ShortcutName { get; internal set; }

        /// <summary>
        /// Gets the absolute path of an icon file for this shortcut.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string IconPath { get; internal set; }

        /// <summary>
        /// Gets the user data. A property of the shortcut element in the manifest file.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ExtraKey { get; internal set; }

        /// <summary>
        /// Gets the user data. A property of the shortcut element in the manifest file.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ExtraData { get; internal set; }
    }
}