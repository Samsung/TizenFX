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
    /// A class for getting information of the Shortcut.
    /// </summary>
    public class ShortcutDeletedInfo
    {
        /// <summary>
        /// Gets the name of package.
        /// </summary>
        public string AppId { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets the name of the created shortcut icon.
        /// </summary>
        public string ShortcutName { get; internal set; } = string.Empty;
    }
}