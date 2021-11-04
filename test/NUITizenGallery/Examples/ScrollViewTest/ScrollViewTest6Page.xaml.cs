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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ScrollViewTest6Page : ContentPage
    {

        void onValueChanged1(object sender, SliderValueChangedEventArgs e)
        {
            float v = slider1.CurrentValue;
            ScrollArea.SizeWidth = v;
            widthLbl.Text = "Width:" + v.ToString();
        }

        void onValueChanged2(object sender, SliderValueChangedEventArgs e)
        {
            float v = slider2.CurrentValue;
            ScrollArea.SizeHeight = v;
            heightLbl.Text = "Height:" + v.ToString();
        }

        void onBtn1Clicked(object sender, ClickedEventArgs e)
        {
            txtLbl3.Text += " More horizontal text.";
        }

        void onBtn2Clicked(object sender, ClickedEventArgs e)
        {
            TextLabel tl = new TextLabel()
            {
                Text = " Next line of text.",
                PointSize = 10,
                TextColor = Tizen.NUI.Color.Green
            };
            ScrollArea.Add(tl);
        }

        void onBtn3Clicked(object sender, ClickedEventArgs e)
        {
            int childrenCount = (int)ScrollArea.ChildCount - 1;
            View child = ScrollArea.GetChildAt((uint)childrenCount);
            if (child != null)
            {
                ScrollArea.Remove(child);
            }
        }

        void onBtn4Clicked(object sender, ClickedEventArgs e)
        {
            ScrollArea.ScrollTo(0, false);
        }

        void onBtn5Clicked(object sender, ClickedEventArgs e)
        {
            ScrollArea.ScrollTo(0, true);
        }

        void onBtn6Clicked(object sender, ClickedEventArgs e)
        {
            if (ScrollArea.ScrollingDirection == ScrollableBase.Direction.Vertical)
            {
                orientLbl.Text = "Orientation: Horizontal";
                ScrollArea.ScrollingDirection = ScrollableBase.Direction.Horizontal;
            }
            else
            {
                orientLbl.Text = "Orientation: Vertical";
                ScrollArea.ScrollingDirection = ScrollableBase.Direction.Vertical;
            }
        }

        public ScrollViewTest6Page()
        {
            InitializeComponent();
            slider1.ValueChanged += onValueChanged1;
            slider2.ValueChanged += onValueChanged2;
            btn1.Clicked += onBtn1Clicked;
            btn2.Clicked += onBtn2Clicked;
            btn3.Clicked += onBtn3Clicked;
            btn4.Clicked += onBtn4Clicked;
            btn5.Clicked += onBtn5Clicked;
            btn6.Clicked += onBtn6Clicked;
            ScrollArea.Scrolling += (o, e) =>
            {
                scrollLbl.Text = "ScrollX:" + ScrollArea.ScrollPosition.X.ToString() + ", ScrollY:" + ScrollArea.ScrollPosition.Y.ToString();
            };
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
