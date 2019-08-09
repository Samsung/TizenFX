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
    /// The item class of FlipSelector.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FlipSelectorItem : ItemObject
    {
        /// <summary>
        /// Sets or gets the text of the FlipSelectorItem.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Text { get; private set; }

        /// <summary>
        /// Selected will be triggered when selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Selected;

        /// <summary>
        /// Creates and initializes a new instance of the FlipSelectorItem.
        /// </summary>
        /// <param name="text">FlipSelectorItem's text</param>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem(string text) : base(IntPtr.Zero)
        {
            Text = text;
        }

        /// <summary>
        /// Creates and initializes a new instance of the FlipSelectorItem.
        /// </summary>
        /// <param name="text">FlipSelectorItem's text</param>
        /// <param name="parent">Parent EvasObject</param>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem(string text, EvasObject parent) : base(IntPtr.Zero, parent)
        {
            Text = text;
        }

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
