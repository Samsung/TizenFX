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
    public partial class ScrollViewTest1Page : ContentPage
    {
        public ScrollViewTest1Page()
        {
            InitializeComponent();

            for (int i = 0; i <= 60; ++i)
            {
                var t = new TextLabel
                {
                    Text = String.Format("I am label #{0}", i),
                    Size2D = new Size2D(720, 70)
                };
                Scroller.Add(t);
            }

            btn.Clicked += (o, e) =>
            {
                Scroller.ScrollTo(500, true);
            };
        }
    }
}

