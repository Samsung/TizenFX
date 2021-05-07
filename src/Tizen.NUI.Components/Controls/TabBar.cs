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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButtonSelectedEventArgs is a class to record tab button selected event
    /// arguments which will be sent to a user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabButtonSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of TabButtonSelectedEventArgs.
        /// The indices of tab buttons in TabBar are basically the order of adding to TabBar by <see cref="TabView.AddTab"/>.
        /// So a tab button's index in TabBar can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of the selected tab button in TabBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButtonSelectedEventArgs(int index)
        {
            Index = index;
        }

        /// <summary>
        /// The index of the selected tab button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index { get; }
    }

    /// <summary>
    /// TabBar is a class which contains a set of TabButtons and has one of them selected.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TabBar : Control
    {
        private IList<TabButton> tabButtons;

        private TabButtonGroup tabButtonGroup;

        /// <summary>
        /// Creates a new instance of TabBar.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabBar()
        {
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal };

            WidthSpecification = LayoutParamPolicies.MatchParent;

            tabButtons = new List<TabButton>();
            tabButtonGroup = new TabButtonGroup();
            SelectedIndex = -1;
        }

        /// <summary>
        /// An event for the tab button selected signal which can be used to
        /// subscribe or unsubscribe the event handler provided by a user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TabButtonSelectedEventArgs> TabButtonSelected;

        /// <summary>
        /// The index of the selected tab button.
        /// The indices of tab buttons in TabBar are basically the order of adding to TabBar by <see cref="TabView.AddTab"/>.
        /// So a tab button's index in TabBar can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the count of tab buttons.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int TabButtonCount => tabButtons.Count;

        /// <summary>
        /// Adds a tab button to TabBar.
        /// </summary>
        /// <param name="tabButton">A tab button to be added to TabBar.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument tabButton is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void AddTabButton(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton), "tabButton should not be null.");
            }

            tabButtons.Add(tabButton);
            Add(tabButton);
            tabButtonGroup.Add(tabButton);

            tabButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                int index = tabButtons.IndexOf(tabButton);

                if (SelectedIndex == index)
                {
                    return;
                }

                SelectedIndex = index;

                if (TabButtonSelected != null)
                {
                    TabButtonSelectedEventArgs args = new TabButtonSelectedEventArgs(SelectedIndex);
                    TabButtonSelected(this, args);
                }
            };

            if (SelectedIndex == -1)
            {
                tabButton.IsSelected = true;
                SelectedIndex = 0;

                if (TabButtonSelected != null)
                {
                    TabButtonSelectedEventArgs args = new TabButtonSelectedEventArgs(SelectedIndex);
                    TabButtonSelected(this, args);
                }
            }

            //TODO: To support non-unified tab button size.
            CalculateUnifiedTabButtonSize();
        }

        /// <summary>
        /// Removes a tab button from TabBar.
        /// </summary>
        /// <param name="tabButton">A tab button to be removed from TabBar.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument tabButton is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument tabButton does not exist in TabBar.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void RemoveTabButton(TabButton tabButton)
        {
            if (tabButton == null)
            {
                throw new ArgumentNullException(nameof(tabButton), "tabButton should not be null.");
            }

            if (tabButtons.Contains(tabButton) == false)
            {
                throw new ArgumentException("tabButton does not exist in TabBar.", nameof(tabButton));
            }

            int index = tabButtons.IndexOf(tabButton);
            TabButton selectedTabButton = tabButtons[SelectedIndex];

            tabButtons.Remove(tabButton);
            Remove(tabButton);
            tabButtonGroup.Remove(tabButton);

            if ((index < SelectedIndex) || (tabButtons.Count == SelectedIndex))
            {
                SelectedIndex -= 1;

                if (TabButtonSelected != null)
                {
                    TabButtonSelectedEventArgs args = new TabButtonSelectedEventArgs(SelectedIndex);
                    TabButtonSelected(this, args);
                }
            }

            if ((SelectedIndex != -1) && (selectedTabButton != tabButtons[SelectedIndex]))
            {
                tabButtons[SelectedIndex].IsSelected = true;
            }

            //TODO: To support non-unified tab button size.
            CalculateUnifiedTabButtonSize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            //TODO: To support non-unified tab button size.
            CalculateUnifiedTabButtonSize();
        }

        private void CalculateUnifiedTabButtonSize()
        {
            if (tabButtons.Count <= 0)
            {
                return;
            }

            var tabButtonWidth = Size.Width / tabButtons.Count;

            foreach (TabButton tabButton in tabButtons)
            {
                if (tabButton.Size.Width != tabButtonWidth)
                {
                    tabButton.Size = new Size(tabButtonWidth, tabButton.Size.Height);
                }
            }
        }

        /// <summary>
        /// Gets the tab button at the specified index of TabBar.
        /// The indices of tab buttons in TabBar are basically the order of adding to TabBar by <see cref="TabView.AddTab"/>.
        /// So a tab button's index in TabBar can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of tab button in TabBar where the specified tab button exists.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of tab buttons.</exception>
        /// <since_tizen> 9 </since_tizen>
        public TabButton GetTabButton(int index)
        {
            if ((index < 0) || (index >= tabButtons.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should not be greater than or equal to 0, and less than the number of tab buttons.");
            }

            return tabButtons[index];
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (tabButtons != null)
                {
                    foreach (TabButton tabButton in tabButtons)
                    {
                        Utility.Dispose(tabButton);
                    }

                    tabButtons = null;
                }

                tabButtonGroup = null;
            }

            base.Dispose(type);
        }
    }
}
