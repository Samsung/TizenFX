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
    /// TabView is a class which contains a TabBar and TabContent and
    /// selects a view from the TabContent according to the selected TabButton in the TabBar.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabView : Control
    {
        private TabBar tabBar = null;

        private TabContent content = null;

        /// <summary>
        /// Creates a new instance of TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabView()
        {
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            InitTabBar();
            InitContent();
        }

        private void InitTabBar()
        {
            if (tabBar != null)
            {
                return;
            }

            tabBar = new TabBar();
            tabBar.TabButtonSelected += tabButtonSelectedHandler;

            Add(tabBar);
        }

        private void InitContent()
        {
            if (content != null)
            {
                return;
            }

            content = new TabContent();
            content.WidthSpecification = LayoutParamPolicies.MatchParent;
            content.HeightSpecification = LayoutParamPolicies.MatchParent;

            Add(content);
        }

        private void tabButtonSelectedHandler(object sender, TabButtonSelectedEventArgs args)
        {
            if ((content != null) && (content.ViewCount > args.Index))
            {
                content.Select(args.Index);
            }
        }

        /// <summary>
        /// Gets TabBar of TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabBar TabBar
        {
            get
            {
                return tabBar;
            }
        }

        /// <summary>
        /// Gets TabContent of TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabContent Content
        {
            get
            {
                return content;
            }
        }

        /// <summary>
        /// Adds a tab with tab button and content view.
        /// </summary>
        /// <param name="tabButton">A tab button to be added.</param>
        /// <param name="view">A content view to be added.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddTab(TabButton tabButton, View view)
        {
            if (TabBar != null)
            {
                TabBar.AddTabButton(tabButton);
            }

            if (Content != null)
            {
                Content.AddView(view);
            }
        }

        /// <summary>
        /// Removes a tab at the specified index of TabView.
        /// </summary>
        /// <param name="index">The index of TabView where a tab will be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of tabs.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveTab(int index)
        {
            var tabButton = TabBar.GetTabButton(index);
            if (tabButton != null)
            {
                TabBar.RemoveTabButton(tabButton);
            }

            var view = Content.GetView(index);
            if (view != null)
            {
                Content.RemoveView(view);
            }
        }

        /// <summary>
        /// Dispose TabView and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (tabBar != null)
                {
                    tabBar.TabButtonSelected -= tabButtonSelectedHandler;
                    Utility.Dispose(tabBar);
                }

                if (content != null)
                {
                    Utility.Dispose(content);
                }
            }

            base.Dispose(type);
        }
    }
}
