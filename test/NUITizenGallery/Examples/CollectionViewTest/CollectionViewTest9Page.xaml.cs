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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class CollectionViewTest9Page : ContentPage
    {
        void OnCheckClicked(object sender, ClickedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (check == null) return;
            if (check.BindingContext == null) return;
            var item = check.BindingContext;
            if (item is TestItem tItem)
            {
                tItem.IsSelected = check.IsSelected;
                Console.WriteLine($"On Clicked {tItem.Index} : {tItem.IsSelected}");
            }

        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<object> cur = new List<object>(e.CurrentSelection);

            foreach(TestItem item in e.PreviousSelection)
            {
                if (cur.Contains(item)) continue;
                item.IsSelected = false;
                Console.WriteLine($"On Selection {item.Index} : {item.IsSelected}");
            }
            foreach(TestItem item in cur)
            {
                item.IsSelected = true;
                Console.WriteLine($"On Selection {item.Index} : {item.IsSelected}");
            }
        }

        public CollectionViewTest9Page()
        {
            InitializeComponent();
            BindingContext = new GroupTestSourceModel(5, 5);

            ColView.ItemTemplate = new DataTemplate(() =>
            {
                var item = new DefaultLinearItem()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                };
                item.Label.SetBinding(TextLabel.TextProperty, "Name");

                var icon = new View()
                {
                    WidthSpecification = 60,
                    HeightSpecification = 60
                };
                icon.SetBinding(BackgroundColorProperty, "BgColor");
                item.Icon = icon;

                var check = new CheckBox()
                {
                    WidthSpecification = 60,
                    HeightSpecification = 60,
                };
                check.SetBinding(Button.IsSelectedProperty, "IsSelected");
                check.Clicked += OnCheckClicked;
                item.Extra = check;

                return item;
            });
            ColView.GroupHeaderTemplate = new DataTemplate(() =>
            {
                var header = new DefaultTitleItem()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                };
                header.Label.SetBinding(TextLabel.TextProperty, "GroupName");

                return header;
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
