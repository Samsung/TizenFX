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
    public partial class PerformanceTest3Page : ContentPage
    {
        private int TestItems = 200;

        public PerformanceTest3Page()
        {
            InitializeComponent();

            ScrollBegin.Clicked += OnScrollBeginClicked;
            ScrollMiddle.Clicked += OnScrollMiddleClicked;
            ScrollEnd.Clicked += OnScrollEndClicked;

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
