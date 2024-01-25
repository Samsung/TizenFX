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
using System.Linq;

namespace NUITizenGallery
{
    public partial class BackgroundColorTest5Page : ContentPage
    {
        private int setColorCount = 1;
        public BackgroundColorTest5Page()
        {
            InitializeComponent();
            var resources_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            loading.ImageArray = Enumerable.Range(0, 12).Select(x => $"{resources_path}images/progress_{x}.png").ToArray();
            loading.Stop();
            button1.Clicked += OnButton1Clicked;
        }

        private void SetColor(Color color)
        {
            button1.BackgroundColor = color;
            label.BackgroundColor = color;
            textField.BackgroundColor = color;
            progress.BufferColor = color;
            slider.BgTrackColor = color;
            loadingView.BackgroundColor = color;
        }

        private void OnButton1Clicked(object sender, ClickedEventArgs e)
        {
            if (setColorCount % 2 == 0)
            {
                SetColor(Color.Yellow);
            }
            else
            {
                SetColor(Color.Red);
            }
            loading.Play();
            setColorCount++;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                button1.Clicked -= OnButton1Clicked;
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
