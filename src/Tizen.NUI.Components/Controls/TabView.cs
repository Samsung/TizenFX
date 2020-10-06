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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabView is a class which contains a TabBar and TabContent and
    /// selects a View from the TabContent according to the selected TabButton in the TabBar.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabView : Control
    {
        /// <summary>
        /// Creates a new instance of TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabView()
        {
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
        }

        private TabBar tabBar;

        /// <summary>
        /// Set/get a TabBar object to/from a TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabBar TabBar
        {
            set
            {
                if (tabBar != null)
                {
                    this.Remove(tabBar);
                    tabBar.TabSelected -= tabSelectedCallback;
                    tabBar = null;
                }

                if (value != null)
                {
                    tabBar = value;
                    this.Add(value);

                    if (content)
                    {
                        tabBar.TabSelected += tabSelectedCallback;
                    }
                }
            }
            get
            {
                return tabBar;
            }
        }

        private TabContent content;

        /// <summary>
        /// Set/get a TabContent object to/from a TabView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabContent Content
        {
            set
            {
                if (content != null)
                {
                    this.Remove(content);
                    content = null;
                }

                if (value != null)
                {
                    content = value;
                    this.Add(value);
                    value.WidthSpecification = LayoutParamPolicies.MatchParent;
                    value.HeightSpecification = LayoutParamPolicies.MatchParent;

                    if (tabBar)
                    {
                        tabBar.TabSelected += tabSelectedCallback;
                    }
                }
            }
            get
            {
                return content;
            }
        }
        private void tabSelectedCallback(object sender, TabSelectedEventArgs args)
        {
            content.Select(args.Index);
        }
    }
}