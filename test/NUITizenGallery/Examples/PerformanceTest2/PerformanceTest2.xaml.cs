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
    public partial class PerformanceTest2Page : View
    {
        private int TestItems = 50;
        private int ScrollTime = 5000;

        public PerformanceTest2Page()
        {
            InitializeComponent();

            //Application Linear Layout
            LinearLayout layout = new LinearLayout();
            layout.LinearOrientation = LinearLayout.Orientation.Vertical;
            layout.LinearAlignment = LinearLayout.Alignment.Center;
            layout.Padding = new Extents(5, 5, 5, 5);
            layout.CellPadding = new Size2D(5, 5);

            this.Layout = layout;
            StartButton.Clicked += OnButtonScrollClicked;

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

            var items = new ListItemTitleSwitch[TestItems];
            for (int i = 0; i < TestItems; i++) {
                items[i] = new ListItemTitleSwitch("item: " + i.ToString());
                LabelsListView.Add(items[i]);
            }
        }

        private void OnButtonScrollClicked(object sender, ClickedEventArgs args)
        {
            LabelsListView.ScrollToIndex(49);
        }
    }
}
