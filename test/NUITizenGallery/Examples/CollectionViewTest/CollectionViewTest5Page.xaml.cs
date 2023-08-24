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
    public partial class CollectionViewTest5Page : ContentPage
    {
        TestItem item10;
        ObservableCollection<TestItem> source;
        void OnSelect10Clicked(object sender, ClickedEventArgs e)
        {
            ColView.SelectedItem = item10;
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TestItem SelectedItem = null;
            string message;
            foreach(TestItem item in e.CurrentSelection)
            {
                Console.WriteLine("Selected Item {0}", item?.GetHashCode());
                SelectedItem = item;
            }

            if (source == null)
            {
                message = "Source is NULL";
            }
            else
            {
                int index = source.IndexOf(SelectedItem);
                message = index + " was Selected";
            }

            var btn = new Button() { Text = "Ok", };
            btn.Clicked += (object s, ClickedEventArgs args) =>
            {
                Navigator?.Pop();
            };

            Console.WriteLine(message);
            DialogPage.ShowAlertDialog("Selected", message, btn);
        }

        public CollectionViewTest5Page()
        {
            InitializeComponent();
            var MyModel = new TestSourceModel();
            item10 = MyModel.TestSource[10];

            ColView.ItemsSource = source = MyModel.TestSource;
            ColView.ItemTemplate = new DataTemplate(() =>
            {
                var item = new RecyclerViewItem()
                {
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    WidthSpecification = 200,
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
