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
    public partial class PerformanceTest3Page : View
    {
        private int TestItems = 200;
        private int ScrollTime = 5000;

        public PerformanceTest3Page()
        {
            InitializeComponent();

            //Application Linear Layout
            LinearLayout layout = new LinearLayout();
            layout.LinearOrientation = LinearLayout.Orientation.Vertical;
            layout.LinearAlignment = LinearLayout.Alignment.Center;
            layout.Padding = new Extents(5, 5, 5, 5);
            layout.CellPadding = new Size2D(5, 5);
            this.Layout = layout;

            LinearLayout hLayout = new LinearLayout();
            hLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            hLayout.LinearAlignment = LinearLayout.Alignment.Center;
            hLayout.Padding = new Extents(5, 5, 5, 5);
            hLayout.CellPadding = new Size2D(5, 5);
            ButtonBox.Layout = hLayout;


            ScrollBegin.Clicked += OnScrollBeginClicked;
            ScrollMiddle.Clicked += OnScrollMiddleClicked;
            ScrollEnd.Clicked += OnScrollEndClicked;

            //Create List for Labels
            LabelsListView = new ScrollableBase();
            LabelsListView.BackgroundColor = Color.White;
            LabelsListView.Size2D = new Size2D(700, 1200);

            //Set linead layout for scrollable widget
            LinearLayout scrollLayout = new LinearLayout();
            scrollLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            scrollLayout.LinearAlignment = LinearLayout.Alignment.Center;
            scrollLayout.CellPadding = new Size2D(5, 5);
            LabelsListView.Layout = scrollLayout;
            LabelsListView.ScrollDuration = ScrollTime;
            this.Add(LabelsListView);

            var items = new ListItemTitleView[TestItems];
            for (int i = 0; i < TestItems; i++) {
                items[i] = new ListItemTitleView("item: " + i.ToString());
                LabelsListView.Add(items[i]);
            }
        }

        private void OnScrollBeginClicked(object sender, ClickedEventArgs args)
        {
            LabelsListView.ScrollToIndex(0);
        }

        private void OnScrollEndClicked(object sender, ClickedEventArgs args)
        {
            LabelsListView.ScrollToIndex(199);
        }

        private void OnScrollMiddleClicked(object sender, ClickedEventArgs args)
        {
            LabelsListView.ScrollToIndex(100);
        }
    }
}
