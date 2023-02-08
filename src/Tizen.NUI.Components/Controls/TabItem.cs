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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabView provides Add(TabItem tabItem) to add a tab from the given TabItem.
    /// TabItem contains Title and IconUrl of a new TabButton in TabView's TabBar and Content of a new View in TabView's TabContent.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabItem
    {
        /// <summary>
        /// Creates a new instance of TabItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabItem()
        {
        }

        /// <summary>
        /// TabButton style applied to a new TabButton when TabView adds TabItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButtonStyle TabButtonStyle { get; set; }

        /// <summary>
        /// Title of TabItem.
        /// Title is set to the Text of a new TabButton in TabView's TabBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title { get; set; }

        /// <summary>
        /// IconUrl of TabItem.
        /// IconUrl is set to the IconUrl of a new TabButton in TabView's TabBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IconUrl { get; set; }

        /// <summary>
        /// Content of TabItem.
        /// Content is added to TabView's TabContent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content { get; set; }
    }
}
