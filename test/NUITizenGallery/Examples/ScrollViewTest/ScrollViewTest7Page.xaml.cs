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
    public partial class ScrollViewTest7Page : ContentPage
    {
        public ScrollViewTest7Page()
        {
            InitializeComponent();

            for (int i = 0; i <= 60; ++i)
            {
                var t = new TextLabel
                {
                    Text = String.Format("I am label #{0}", i),
                    Size2D = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, 70),
                };
                Scroller.Add(t);
            }

            btn.Clicked += (o, e) =>
            {
                Random rand = new Random();
                float scroll = (float)rand.NextDouble() * 1280;
                Scroller.ScrollTo(scroll, true);
            };

            Scroller.Scrolling += (o, e) =>
            {
                scrollInfo.Text = "scroll X:+" + Scroller.ScrollPosition.X.ToString() + ", Y:" + Scroller.ScrollPosition.Y.ToString();
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
