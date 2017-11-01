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
    /// A class that contains information about the widget.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WidgetShortcutInfo : ShortcutInfo
    {
        /// <summary>
        /// Gets or sets the Widget ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string WidgetId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the size of widget.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ShortcutWidgetSize WidgetSize { get; set; }

        /// <summary>
        /// Gets or sets the Update period in seconds.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public double Period { get; set; }
    }
}