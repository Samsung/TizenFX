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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest2Page : ContentPage
    {
        private readonly string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        private readonly Color[] button1Colors = {
            Color.Black,
            Color.Red,
            Color.Green,
            Color.Blue,
            new Color(global::System.Drawing.Color.FromName("Pink")),
            new Color(global::System.Drawing.Color.FromName("Olive")),
            new Color(global::System.Drawing.Color.FromName("Lime")),
            new Color(global::System.Drawing.Color.FromName("Aqua")),
            new Color(global::System.Drawing.Color.FromName("Navy")),
            Color.White,
        };

        uint button1ColorIndex = 0;

        public ButtonTest2Page()
        {
            InitializeComponent();
            imageview1.ResourceUrl = ImageURL + "NUITizenGallery.png";
            coloredButton.Clicked += OnColoredButtonClicked;
            button3.Clicked += OnButton3Clicked;
        }

        private void OnColoredButtonClicked(object sender, ClickedEventArgs e) =>
            coloredButton.TextColor = button1Colors[++button1ColorIndex % button1Colors.Length];

        private void OnButton3Clicked(object sender, ClickedEventArgs e) =>
            button2.IsEnabled = !button2.IsEnabled;

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                coloredButton.Clicked -= OnColoredButtonClicked;
                button3.Clicked -= OnButton3Clicked;
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
