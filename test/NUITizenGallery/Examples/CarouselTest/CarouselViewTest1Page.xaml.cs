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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class CarouselViewTest1Page : ContentPage
    {
        private bool DefaultScrollbarState;
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        public CarouselViewTest1Page()
        {
            InitializeComponent();
            DefaultScrollbarState = Scroller.HideScrollbar;

            Never.Clicked += OnNeverButtonClicked;
            Always.Clicked += OnAlwaysButtonClicked;
            Default.Clicked += OnDefaultButtonClicked;

            Scroller.ScrollAnimationEnded += OnScrollAnimationEnded;
            Scroller.ScrollDragStarted += OnScrollDragStarted;

            PaginationStyle paginationStyle = new PaginationStyle()
            {
                IndicatorSize = new Size(26, 26),
                IndicatorSpacing = 8,
                IndicatorImageUrl = new Selector<string>
                {
                    Normal = ResourcePath + "pagination_ic_nor.png",
                    Selected = ResourcePath + "pagination_ic_sel.png"
                }
            };

            Index.ApplyStyle(paginationStyle);
            Index.BackgroundColor = Color.Gray;
            Index.IndicatorCount = 3;
            Index.SelectedIndex = 0;
        }

        private void OnNeverButtonClicked(object sender, ClickedEventArgs args)
        {
            Scroller.HideScrollbar = true;
        }

        private void OnAlwaysButtonClicked(object sender, ClickedEventArgs args)
        {
            Scroller.HideScrollbar = false;
        }

        private void OnDefaultButtonClicked(object sender, ClickedEventArgs args)
        {
            Scroller.HideScrollbar = DefaultScrollbarState;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs args)
        {
            Index.SelectedIndex = Scroller.CurrentPage;
            ScrollStatus.Text = "";
        }

        private void OnScrollDragStarted(object sender, ScrollEventArgs args)
        {
            ScrollStatus.Text = "Dragging";
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
