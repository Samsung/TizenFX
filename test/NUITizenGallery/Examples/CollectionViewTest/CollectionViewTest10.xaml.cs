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
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class CollectionViewTest10 : ContentPage
    {
        int addCount = 0;
        public ObservableCollection<TestItem> source;
        void AddItemClicked(object sender, ClickedEventArgs e)
        {
            // Add item in the source
            source.Add(new TestItem(addCount, $"Test Item [{addCount}]", Color.Red));
            addCount++;
        }
        void RemoveItemClicked(object sender, ClickedEventArgs e)
        {
            // Removed selected item from the source
            if (ColView.SelectedItem != null)
                source.Remove((TestItem)ColView.SelectedItem);
        }
        void RemoveAllClicked(object sender, ClickedEventArgs e)
        {
            // Remove All items in the source
            source.Clear();
            Console.WriteLine("Source clear is Clicked");
        }

        public CollectionViewTest10()
        {
            InitializeComponent();

            // Empty Source
            source = new ObservableCollection<TestItem>();
            ColView.ItemsSource = source;
            ColView.ItemTemplate = new DataTemplate(() =>
            {
                var item = new DefaultLinearItem()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                };
                item.Label.SetBinding(TextLabel.TextProperty, "Name");

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
