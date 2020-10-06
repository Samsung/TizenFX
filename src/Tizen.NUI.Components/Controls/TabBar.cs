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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabSelectedEventArgs is a class to record tab selected event arguments
    /// which will be sent to a user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Create a new instance of TabSelectedEventArgs
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabSelectedEventArgs(int index)
        {
            Index = index;
        }

        /// <summary>
        /// The selected tab's index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index { get; }
    }

    /// <summary>
    /// TabBar is a class which contains a set of TabButtons
    /// and has one of them selected.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabBar : Control
    {
        /// <summary>
        /// The list which contains the TabButtons in the TabBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IList<TabButton> tabList;

        /// <summary>
        /// The index of the selected TabButton.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int selectedIndex { get; set; }

        private TabButtonGroup tabButtonGroup;

        /// <summary>
        /// An event for the tab selected signal which can be used to
        /// subscribe or unsubscribe the event handler provided by a user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TabSelectedEventArgs> TabSelected;

        /// <summary>
        /// Creates a new instance of TabBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabBar()
        {
            Layout = new GridLayout() { GridOrientation = GridLayout.Orientation.Vertical };
            WidthSpecification = LayoutParamPolicies.MatchParent;

            tabList = new List<TabButton>();
            tabButtonGroup = new TabButtonGroup();
            selectedIndex = -1;
        }

        /// <summary>
        /// Add a TabButton to the TabBar.
        /// </summary>
        /// <param name="tabButton">A TabButton to add</param>
        /// <exception cref="ArgumentNullException">tabButton is null</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddTab(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton));
            }

            tabList.Add(tabButton);
            Add(tabButton);
            tabButtonGroup.Add(tabButton);

            tabButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                int index = tabList.IndexOf(tabButton);

                if (selectedIndex == index)
                {
                    return;
                }

                selectedIndex = index;

                if (TabSelected != null)
                {
                    TabSelectedEventArgs args = new TabSelectedEventArgs(selectedIndex);
                    TabSelected(this, args);
                }
            };

            if (selectedIndex == -1)
            {
                tabButton.IsSelected = true;
                tabButton.setTabButtonState(ControlState.Pressed);
                selectedIndex = 0;

                if (TabSelected != null)
                {
                    TabSelectedEventArgs args = new TabSelectedEventArgs(selectedIndex);
                    TabSelected(this, args);
                }
            }
        }

        /// <summary>
        /// Remove a TabButton from the TabBar.
        /// </summary>
        /// <param name="tabButton">A TabButton to remove</param>
        /// <exception cref="ArgumentNullException">tabButton is null</exception>
        /// <exception cref="ArgumentException">tabButton is not in the TabBar</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveTab(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton));
            }
            if (!tabList.Contains(tabButton))
            {
                throw new ArgumentException("This TabBar doesn't contain ", nameof(tabButton));
            }

            int index = tabList.IndexOf(tabButton);
            TabButton selectedTabButton = tabList[selectedIndex];

            tabList.Remove(tabButton);
            Remove(tabButton);
            tabButtonGroup.Remove(tabButton);

            if (index < selectedIndex || tabList.Count == selectedIndex)
            {
                selectedIndex -= 1;

                if (TabSelected != null)
                {
                    TabSelectedEventArgs args = new TabSelectedEventArgs(selectedIndex);
                    TabSelected(this, args);
                }
            }

            if (selectedIndex != -1 && selectedTabButton != tabList[selectedIndex])
            {
                tabList[selectedIndex].IsSelected = true;
                tabList[selectedIndex].setTabButtonState(ControlState.Pressed);
            }
        }
    }
}