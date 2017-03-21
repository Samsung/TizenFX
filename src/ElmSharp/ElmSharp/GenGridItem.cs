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
    /// It inherits <see cref="GenItem"/>.
    /// A instance to the gengrid item added.
    /// It contains Update() method to update a gengrid item which is given.
    /// </summary>
    public class GenGridItem : GenItem
    {
        internal GenGridItem(object data, GenItemClass itemClass) : base(data, itemClass)
        {
        }

        /// <summary>
        /// Gets or sets whether a given gengrid item is selected.
        /// If one gengrid item is selected, any other previously selected items get unselected in favor of this new one.
        /// </summary>
        /// <remarks>
        /// If true, it is selected.
        /// If false, it is unselected.
        /// </remarks>
        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_gengrid_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_selected_set(Handle, value);
            }
        }

        /// <summary>
        /// Updates the content of a given gengrid item.
        /// This updates an item by calling all the genitem class functions again to get the content, text, and states.
        /// Use this when the original item data has changed and you want the changes to reflect.
        /// </summary>
        /// <remarks>
        /// <see cref="GenGrid.UpdateRealizedItems"/> to update the contents of all the realized items.
        /// </remarks>
        public override void Update()
        {
            Interop.Elementary.elm_gengrid_item_update(Handle);
        }
    }
}
