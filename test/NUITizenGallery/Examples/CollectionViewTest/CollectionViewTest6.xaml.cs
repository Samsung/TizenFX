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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class CollectionViewTest6 : ContentPage
    {
        DataTemplate LinearTemplate = new DataTemplate(() =>
        {
            var item = new RecyclerViewItem()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
            };
            item.SetBinding(View.BackgroundColorProperty, "BgColor");
            var label = new TextLabel()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            label.PixelSize = 30;
            label.SetBinding(TextLabel.TextProperty, "Index");
            item.Add(label);

            return item;
        });
        DataTemplate GridTemplate = new DataTemplate(() =>
        {
            var item = new RecyclerViewItem()
            {
                WidthSpecification = (NUIApplication.GetDefaultWindow().WindowSize.Width / 2),
                HeightSpecification = 100,
            };
            item.SetBinding(View.BackgroundColorProperty, "BgColor");
            var label = new TextLabel()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            label.PixelSize = 30;
            label.SetBinding(TextLabel.TextProperty, "Index");
            item.Add(label);

            return item;
        });

        ObservableCollection<TestItem> source;
        bool headerClicked;
        int clickedCount;
        bool footerClicked;
        bool layouterClicked;
        bool srcClicked;

        void HeaderBtnClicked(object sender, ClickedEventArgs e)
        {
            headerClicked = !headerClicked;
            if (headerClicked)
            {
                var item = new RecyclerViewItem()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = 100,
                    BackgroundColor = Color.Grey,
                };
                var label = new TextLabel()
                {
                    PixelSize = 20,
                    Text = clickedCount.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Position.PivotPointCenterLeft,
                };
                item.Add(label);
                clickedCount++;

                ColView.Header = item;
            }
            else
            {
                ColView.Header = null;
            }
        }
        void FooterBtnClicked(object sender, ClickedEventArgs e)
        {
            footerClicked = !footerClicked;
            if (footerClicked)
            {
                var item = new RecyclerViewItem()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = 100,
                    BackgroundColor = Color.White,
                };
                var label = new TextLabel()
                {
                    PixelSize = 20,
                    Text = clickedCount.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Position.PivotPointCenterLeft,
                };
                item.Add(label);
                clickedCount++;

                ColView.Footer = item;
            }
            else
            {
                ColView.Footer = null;
            }
        }

        void LayouterBtnClicked(object sender, ClickedEventArgs e)
        {
            layouterClicked = !layouterClicked;
            if (layouterClicked)
            {
                ColView.ItemTemplate = GridTemplate;
                ColView.ItemsLayouter = new GridLayouter();
            }
            else
            {
                ColView.ItemTemplate = LinearTemplate;
                ColView.ItemsLayouter = new LinearLayouter();
            }
        }

        void SrcBtnClicked(object sender, ClickedEventArgs e)
        {
            srcClicked = !srcClicked;
            if (srcClicked)
            {
               ColView.ItemsSource = null;
            }
            else
            {
               ColView.ItemsSource = source;
            }
        }


        public CollectionViewTest6()
        {
            InitializeComponent();

            var MyModel = new TestSourceModel(20);
            ColView.ItemsSource = source = MyModel.TestSource;
            ColView.ItemTemplate = LinearTemplate;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }

                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }
}
