/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;

namespace ElmSharp
{
    /// <summary>
    /// It inherits <see cref="ItemObject"/>.
    /// An instance to the list item is added.
    /// It contains the Text, LeftIcon, and RightIcon properties to show the list item which is given.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ListItem : ItemObject
    {
        internal ListItem(string text, EvasObject leftIcon, EvasObject rightIcon, EvasObject parent) : base(IntPtr.Zero, parent)
        {
            Text = text;
            LeftIcon = leftIcon;
            RightIcon = rightIcon;
        }

        /// <summary>
        /// Gets the text for the list item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the left icon for the list item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasObject LeftIcon { get; internal set; }

        /// <summary>
        /// Gets the right icon for the list item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasObject RightIcon { get; internal set; }
    }
}