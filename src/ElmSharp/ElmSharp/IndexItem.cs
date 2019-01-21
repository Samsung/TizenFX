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

using System;
namespace ElmSharp
{
    /// <summary>
    /// The IndexItem is used to manage the index item.
    /// Inherits ItemObject.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class IndexItem : ItemObject
    {
        /// <summary>
        /// Creates and initializes a new instance of the IndexItem class.
        /// </summary>
        /// <param name="text">The text is set to the Text. It's the 'string' type.</param>
        /// <since_tizen> preview </since_tizen>
        public IndexItem(string text) : base(IntPtr.Zero)
        {
            Text = text;
        }

        /// <summary>
        /// Selected will be triggered when the index item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Selected;

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Text { get; private set; }

        /// <summary>
        /// Sets the selected state of an item.
        /// </summary>
        /// <param name="selected">The selected state.</param>
        /// <since_tizen> preview </since_tizen>
        public void Select(bool selected)
        {
            Interop.Elementary.elm_index_item_selected_set(Handle, selected);
        }
        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

    }
}
