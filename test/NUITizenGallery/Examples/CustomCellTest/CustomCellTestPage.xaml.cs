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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class CustomCellTestPage : View
    {
        private readonly int ScrollTime = 500;
        private readonly int TestItems = 20;
        public CustomCellTestPage()
        {
            InitializeComponent();

            //Application Linear Layout
            LinearLayout layout = new LinearLayout();
            layout.LinearOrientation = LinearLayout.Orientation.Vertical;
            layout.LinearAlignment = LinearLayout.Alignment.Center;
            layout.Padding = new Extents(5, 5, 5, 5);
            layout.CellPadding = new Size2D(5, 5);
            this.Layout = layout;

            ListView.BackgroundColor = Color.White;
            ListView.Size2D = new Size2D(720, 1280);

            //Set linear layout for scrollable widget
            LinearLayout scrollLayout = new LinearLayout();
            scrollLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            scrollLayout.LinearAlignment = LinearLayout.Alignment.Center;
            scrollLayout.CellPadding = new Size2D(5, 5);
            ListView.Layout = scrollLayout;
            ListView.ScrollDuration = ScrollTime;
            this.Add(ListView);

            var items = new CustomCellListItem[TestItems];
            for (int i = 0; i < TestItems; i++) {
                items[i] = new CustomCellListItem("item: " + i.ToString());
                ListView.Add(items[i]);
            }
        }

        private void OnScrollBeginClicked(object sender, ClickedEventArgs args)
        {
            ListView.ScrollToIndex(0);
        }

        private void OnScrollEndClicked(object sender, ClickedEventArgs args)
        {
            ListView.ScrollToIndex(199);
        }

        private void OnScrollMiddleClicked(object sender, ClickedEventArgs args)
        {
            ListView.ScrollToIndex(100);
        }
    }
}
