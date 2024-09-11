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
    using System;

    /// <summary>
    /// Enumeration for the sizes of the shortcut widget.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
    public enum ShortcutWidgetSize
    {
        /// <summary>
        /// Type mask for the normal mode widget, don't use this value for a specific size.
        /// </summary>
        WidgetDefault = 0x10000000,

        /// <summary>
        /// 1by1
        /// </summary>
        Widget1by1 = 0x10010000,

        /// <summary>
        /// 2by1
        /// </summary>
        Widget2by1 = 0x10020000,

        /// <summary>
        /// 2by2
        /// </summary>
        Widget2by2 = 0x10040000,

        /// <summary>
        /// 4by1
        /// </summary>
        Widget4by1 = 0x10080000,

        /// <summary>
        /// 4by2
        /// </summary>
        Widget4by2 = 0x10100000,

        /// <summary>
        /// 4by3
        /// </summary>
        Widget4by3 = 0x10200000,

        /// <summary>
        /// 4by4
        /// </summary>
        Widget4by4 = 0x10400000,

        /// <summary>
        /// 4by5
        /// </summary>
        Widget4by5 = 0x11000000,

        /// <summary>
        /// 4by6
        /// </summary>
        Widget4by6 = 0x12000000,

        /// <summary>
        /// Type mask for the easy mode widget, don't use this value for a specific size.
        /// </summary>
        EasyDefault = 0x30000000,

        /// <summary>
        /// Easy mode 1by1.
        /// </summary>
        Easy1by1 = 0x30010000,

        /// <summary>
        /// Easy mode 3by2.
        /// </summary>
        Easy3by1 = 0x30020000,

        /// <summary>
        /// Easy mode 3by3.
        /// </summary>
        Easy3by3 = 0x30040000,
    }

    /// <summary>
    /// Enumeration for the shortcut types.
    /// </summary>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
    internal enum ShortcutType
    {
        /// <summary>
        /// Launch the application itself.
        /// </summary>
        LaunchByApp = 0x00000000,

        /// <summary>
        /// Launch the application with the given data (URI).
        /// </summary>
        LaunchByUri = 0x00000001,
    }
}