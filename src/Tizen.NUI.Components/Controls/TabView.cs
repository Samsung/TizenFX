/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabView is a class which contains a TabBar and TabContent.
    /// TabView adds TabButtons and Views to TabBar and TabContent in TabView by <see cref="TabView.AddTab"/>.
    /// TabView removes TabButtons and Views from TabBar and TabContent in TabView by <see cref="TabView.RemoveTab"/>.
    /// TabView selects a view from the TabContent according to the selected TabButton in the TabBar.
    ///
    /// <example>
    /// <code>
    /// var tabView = new TabView()
    /// {
    ///     WidthSpecification = LayoutParamPolicies.MatchParent,
    ///     HeightSpecification = LayoutParamPolicies.MatchParent,
    /// };
    ///
    /// var tabButton = new TabButton()
    /// {
    ///     Text = "Tab#1"
    /// };
    ///
    /// var content = new View()
    /// {
    ///     BackgroundColor = Color.Red,
    ///     WidthSpecification = LayoutParamPolicies.MatchParent,
    ///     HeightSpecification = LayoutParamPolicies.MatchParent,
    /// };
    ///
    /// tabView.AddTab(tabButton, content);
    ///
    /// var tabButton2 = new TabButton()
    /// {
    ///     Text = "Tab#2"
    /// };
    ///
    /// var content2 = new View()
    /// {
    ///     BackgroundColor = Color.Green,
    ///     WidthSpecification = LayoutParamPolicies.MatchParent,
    ///     HeightSpecification = LayoutParamPolicies.MatchParent,
    /// };
    ///
    /// tabView.AddTab(tabButton2, content2);
    ///
    /// var tabButton3 = new TabButton()
    /// {
    ///     Text = "Tab#3"
    /// };
    ///
    /// var content3 = new View()
    /// {
    ///     BackgroundColor = Color.Blue,
    ///     WidthSpecification = LayoutParamPolicies.MatchParent,
    ///     HeightSpecification = LayoutParamPolicies.MatchParent,
    /// };
    ///
    /// tabView.AddTab(tabButton3, content3);
    /// </code>
    /// </example>
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TabView : Control
    {
        private TabBar tabBar = null;

        private TabContent content = null;

        private void Initialize()
        {
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            InitTabBar();
            InitContent();

            // To show TabBar's shadow TabBar is raised above Content.
            TabBar.RaiseAbove(Content);
        }

        /// <summary>
        /// Creates a new instance of TabView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabView()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TabView.
        /// </summary>
        /// <param name="style">Creates TabView by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabView(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a TabView with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created TabView.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabView(ControlStyle style) : base(style)
        {
            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            AccessibilityRole = Role.PageTabList;
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
                content.SelectContentView(args.Index);
            }
        }

        /// <summary>
        /// Gets TabBar of TabView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabBar TabBar
        {
            get
            {
                return tabBar;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            protected set
            {
                if (tabBar != null)
                {
                    tabBar.TabButtonSelected -= tabButtonSelectedHandler;
                    Utility.Dispose(tabBar);
                }

                tabBar = value;
                Add(tabBar);
            }
        }

        /// <summary>
        /// Gets TabContent of TabView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabContent Content
        {
            get
            {
                return content;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            protected set
            {
                if (content != null)
                {
                    Utility.Dispose(content);
                }

                content = value;
                Add(content);
            }
        }

        /// <summary>
        /// Adds a tab with tab button and content view.
        /// </summary>
        /// <param name="tabButton">A tab button to be added.</param>
        /// <param name="view">A content view to be added.</param>
        /// <since_tizen> 9 </since_tizen>
        public void AddTab(TabButton tabButton, View view)
        {
            if (TabBar != null)
            {
                TabBar.AddTabButton(tabButton);
            }

            if (Content != null)
            {
                Content.AddContentView(view);
            }
        }

        /// <summary>
        /// Removes a tab at the specified index of TabView.
        /// The indices of tabs(tab buttons and views) in TabView are basically the order of adding to TabView by <see cref="TabView.AddTab"/>.
        /// So the index of a tab(tab button and view) in TabView can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of a tab(tab button and view) in TabView where the tab will be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of tabs.</exception>
        /// <since_tizen> 9 </since_tizen>
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
                Content.RemoveContentView(view);
            }
        }

        /// <summary>
        /// Adds a tab from the given TabItem.
        /// TabItem contains Title and IconURL of a new TabButton in TabBar and Content of a new View in TabContent.
        /// <param name="tabItem">The tab item which contains Title and IconURL of a new TabButton in TabBar and Content of a new View in TabContent.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The tabButton is added to TabBar and disposed when TabBar is disposed.")]
        public virtual void Add(TabItem tabItem)
        {
            if (tabItem == null) return;

            var hasTitle = (String.IsNullOrEmpty(tabItem.Title) == false);
            var hasIconUrl = (String.IsNullOrEmpty(tabItem.IconUrl) == false);

            // Adds a new TabButton and Content View only if TabItem has TabButton properties and Content View.
            if ((hasTitle || hasIconUrl) && (tabItem.Content != null))
            {
                var tabButton = new TabButton(tabItem.TabButtonStyle);

                if (hasTitle)
                {
                    tabButton.Text = tabItem.Title;
                }

                if (hasIconUrl)
                {
                    tabButton.IconURL = tabItem.IconUrl;
                }

                TabBar.AddTabButton(tabButton);

                Content.AddContentView(tabItem.Content);
            }
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
