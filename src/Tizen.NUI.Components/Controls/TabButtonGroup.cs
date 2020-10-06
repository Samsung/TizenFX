/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
        /// Add a TabButton to the end of TabButtonGroup.
        /// </summary>
        /// <param name="tab">The TabButton object to add to the group</param>
        /// <exception cref="ArgumentNullException">tab is null</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(TabButton tab)
        {
            if (null == tab) throw new ArgumentNullException(nameof(tab));
            base.AddSelection(tab);
        }

        /// <summary>
        /// Remove a TabButton from TabButtonGroup.
        /// </summary>
        /// <param name="tab">The TabButton object to remove from the group</param>
        /// <exception cref="ArgumentNullException">tab is null</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(TabButton tab)
        {
            if (null == tab) throw new ArgumentNullException(nameof(tab));
            base.RemoveSelection(tab);
        }

        /// <summary>
        /// Set the state of the rest of TabButtons in TabButtonGroup as normal
        /// when a selection is made by a user.
        /// </summary>
        /// <param name="selection">The handler of the SelectButton selected by a user</param>
        /// <exception cref="ArgumentNullException">selection is null</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void SelectionHandler(SelectButton selection)
        {
            TabButton selectedTab = selection as TabButton;

            if (selectedTab == null) throw new ArgumentNullException(nameof(selection));

            if (!ItemGroup.Contains(selectedTab))
            {
                throw new ArgumentException("This TabButtonGroup doesn't contain ", nameof(selection));
            }

            foreach (TabButton tabButton in ItemGroup)
            {
                if (tabButton != null && tabButton != selectedTab && selectedTab.IsEnabled == true)
                {
                    tabButton.IsSelected = false;
                    tabButton.setTabButtonState(ControlState.Normal);
                }
            }
        }
    }
}