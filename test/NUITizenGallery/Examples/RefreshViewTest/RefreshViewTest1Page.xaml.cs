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
    public partial class RefreshViewTest1Page : ContentPage
    {
        Random rand;
        bool clicked = false;
        TextLabel lbl1;

        public RefreshViewTest1Page()
        {
            InitializeComponent();

            lbl1 = new TextLabel
            {
                Text = "It is Empty!"
            };
            Scroller.Add(lbl1);

            btn1.Clicked += (s, e) =>
            {
                if (!clicked)
                {
                    rand = new Random();
                    int i = 0;
                    Scroller.Remove(lbl1);
                    for (i = 1; i <= 50; i++)
                    {
                        var label = new TextLabel(DateTime.UtcNow.AddMinutes(i).ToString("F"));
                        var r = new decimal(rand.NextDouble());
                        var g = new decimal(rand.NextDouble());
                        var b = new decimal(rand.NextDouble());
                        var boxview = new View
                        {
                            Size2D = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, 100),
                            BackgroundColor = new Tizen.NUI.Color((float)r, (float)g, (float)b, 1.0f)
                        };
                        Scroller.Add(label);
                        Scroller.Add(boxview);
                    }
                }
                else
                {
                    View[] a = Scroller.Children.ToArray();
                    int i = 0;
                    for (i = 0; i < a.Length; i++)
                    {
                        Scroller.Remove(a[i]);
                    }
                    lbl1 = new TextLabel
                    {
                        Text = "It is Empty!"
                    };
                    Scroller.Add(lbl1);
                }
                clicked = !clicked;
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

