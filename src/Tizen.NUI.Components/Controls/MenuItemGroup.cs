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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// MenuItemGroup class is used to group together a set of MenuItems.
    /// It enables a user to select exclusively single MenuItem of a group.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MenuItemGroup : SelectGroup
    {
        /// <summary>
        /// Constructs MenuItemGroup
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MenuItemGroup() : base()
        {
            EnableMultiSelection = false;
        }

        /// <summary>
        /// Adds a menu item to the end of MenuItemGroup.
        /// </summary>
        /// <param name="menuItem">A menu item to be added to the group.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument menuItem is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem), "menuItem should not be null.");
            }

            base.AddSelection(menuItem);
        }

        /// <summary>
        /// Removes a menu item from MenuItemGroup.
        /// </summary>
        /// <param name="menuItem">A menu item to be removed from the group.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument menuItem is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem), "menuItem should not be null.");
            }

            base.RemoveSelection(menuItem);
        }
    }
}
