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
    /// The HoverselItem is the item of Hoversel.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class HoverselItem : ItemObject
    {
        internal HoverselItem(EvasObject parent) : base(parent, IntPtr.Zero)
        {
        }

        /// <summary>
        /// The HoverselItem's label.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Label { get; internal set; }

        /// <summary>
        /// ItemSelected will be triggered when the HoverselItem is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ItemSelected;

        internal void SendItemSelected()
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
