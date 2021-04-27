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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButtonGroup class is used to group together a set of TabButton controls.
    /// It enables a user to select exclusively single TabButton of a group.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabButtonGroup : SelectGroup
    {
        /// <summary>
        /// Constructs TabButtonGroup
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButtonGroup() : base()
        {
            EnableMultiSelection = false;
        }

        /// <summary>
        /// Adds a tab button to the end of TabButtonGroup.
        /// </summary>
        /// <param name="tabButton">A tab button to be added to the group.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument tabButton is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton), "tabButton should not be null.");
            }

            base.AddSelection(tabButton);
        }

        /// <summary>
        /// Removes a tab button from TabButtonGroup.
        /// </summary>
        /// <param name="tabButton">A tab button to be removed from the group.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument tabButton is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton), "tabButton should not be null.");
            }

            base.RemoveSelection(tabButton);
        }
    }
}
