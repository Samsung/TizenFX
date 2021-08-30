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
    public partial class CollectionViewTest7Page : ContentPage
    {
        void OnScrolling(object sender, ScrollEventArgs e)
        {
            ObservableCollection<TestItem> source = ColView.ItemsSource as ObservableCollection<TestItem>;
            if (source == null) return;
            //Reached Bound of Scroll
            if (e.ScrollPosition.Y == (ColView.ContentContainer.SizeHeight - ColView.SizeHeight))
            {
                int count = source.Count;
                var Rand = new Random();
                for (int i = count; i < count + 20; i++)
                {
                    source.Add(new TestItem(i,
                                            "Test Item",
                                            new Color(((float)(Rand.Next(255))/255),
                                                      ((float)(Rand.Next(255))/255),
                                                      ((float)(Rand.Next(255))/255), 1)));
                }
            }
        }

        public CollectionViewTest7Page()
        {
            InitializeComponent();
            BindingContext = new TestSourceModel(40);

            ColView.ItemTemplate = new DataTemplate(() =>
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
            // Currently ScrollableBase only support Scrolling and ScrollOutOfBound event.
            ColView.Scrolling += OnScrolling;
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
