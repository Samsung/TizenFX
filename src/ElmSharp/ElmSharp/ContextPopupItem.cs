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
    /// An instance to the ContextPopup item is added.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ContextPopupItem : ItemObject
    {
        internal ContextPopupItem(string text, EvasObject icon) : base(IntPtr.Zero)
        {
            Text = text;
            Icon = icon;
        }

        internal ContextPopupItem(EvasObject parent, string text, EvasObject icon) : base(parent, IntPtr.Zero)
        {
            Text = text;
            Icon = icon;
        }

        /// <summary>
        /// Gets the Text property of the given ContextPopupItem.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the Icon (type is <see cref="EvasObject"/>) property of the given ContextPopupItem.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasObject Icon { get; internal set; }

        /// <summary>
        /// Selected will be triggered when the ContextPopupItem is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Selected;

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
