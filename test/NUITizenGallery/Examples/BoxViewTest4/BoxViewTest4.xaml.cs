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
    public partial class BoxViewTest4 : View
    {
        public BoxViewTest4()
        {
            InitializeComponent();
            Subscribe();
            box.Scale = new Vector3(2, 2, 1);
            box.Orientation = new Rotation(new Radian(new Degree(50)), new Vector3(0f, 0f, 1f));
            label.Text = "Scale : " + box.Scale.X;
        }

        private void Subscribe()
        {
            button1.Clicked += OnButton1Clicked;
            button2.Clicked += OnButton2Clicked;
        }

        private void Unsubscribe()
        {
            button1.Clicked -= OnButton1Clicked;
            button2.Clicked -= OnButton2Clicked;
        }

        private void OnButton1Clicked(object sender, ClickedEventArgs e)
        {
            box.Scale += new Vector3(1, 1, 0);
            label.Text = "Scale : " + box.Scale.X;
        }

        private void OnButton2Clicked(object sender, ClickedEventArgs e)
        {
            box.Scale -= new Vector3(1, 1, 0);
            label.Text = "Scale : " + box.Scale.X;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Unsubscribe();
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
