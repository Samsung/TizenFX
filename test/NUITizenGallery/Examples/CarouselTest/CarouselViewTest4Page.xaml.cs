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
    public partial class CarouselViewTest4Page : ContentPage
    {
        private readonly static int PageCount = 6;
        Button[] buttons = new Button[PageCount];
        public CarouselViewTest4Page()
        {
            InitializeComponent();

            buttons[0] = SetPage0Button;
            buttons[1] = SetPage1Button;
            buttons[2] = SetPage2Button;
            buttons[3] = SetPage3Button;
            buttons[4] = SetPage4Button;
            buttons[5] = SetPage5Button;

            for (int i = 0; i < PageCount; ++i)
            {
                buttons[i].Clicked += OnButtonClicked;
            }

            Scroller.ScrollAnimationEnded += OnScrollAnimationEnded;

            SetPageIndicator(0);
        }

        private void OnButtonClicked(object sender, ClickedEventArgs args)
        {
            Button btn = (Button) sender;
            Scroller.ScrollToIndex(Int32.Parse(btn.Text));
        }

        private void SetPageIndicator(int index)
        {
            for (int i = 0; i < PageCount; ++i)
            {
                buttons[i].TextColor = Color.White;
            }

            buttons[index].TextColor = Color.Red;
        }
        private void OnScrollAnimationEnded(object sender, ScrollEventArgs args)
        {
            SetPageIndicator(Scroller.CurrentPage);
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
