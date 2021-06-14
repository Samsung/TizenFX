/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
 *
 */
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The event arguments that hold data for the event <see cref="ThemeManager.ThemeChanged"/>.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ThemeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ThemeChangedEventArgs(string themeId, string platformThemeId, bool isPlatformThemeChanged)
        {
            ThemeId = themeId;
            PlatformThemeId = platformThemeId;
            IsPlatformThemeChanged = isPlatformThemeChanged;
        }

        /// <summary>
        /// The new theme's Id.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ThemeId { get; }

        /// <summary>
        /// The platform theme's Id.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlatformThemeId { get; }

        /// <summary>
        /// Whether this event is trigger by platform theme change.
        /// </summary>
        /// <seealso cref="NUIApplication.ThemeOptions.PlatformThemeEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsPlatformThemeChanged { get; }
    }
}
