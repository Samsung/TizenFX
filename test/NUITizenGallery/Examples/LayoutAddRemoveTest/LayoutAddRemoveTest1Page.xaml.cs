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
    public partial class LayoutAddRemoveTest1Page : ContentPage
    {
        private float red = 0f;
        public LayoutAddRemoveTest1Page()
        {
            InitializeComponent();
            addButton.Clicked += OnAddButtonClicked;
            removeButton.Clicked += OnRemoveButtonClicked;
        }

        private void OnAddButtonClicked(object sender, ClickedEventArgs e)
        {
            linear.Add(new View
            {
                BackgroundColor = new Color(red, 1f, 1f, 1f),
                HeightSpecification = 200,
                WidthSpecification = LayoutParamPolicies.MatchParent
            });

            red += 0.3f;

            if (red > 1.0f)
            {
                red = 0f;
            }
        }

        private void OnRemoveButtonClicked(object sender, ClickedEventArgs e)
        {
            if (linear.ChildCount > 0)
            {
                linear.Remove(linear.Children[0]);
            }
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                addButton.Clicked -= OnAddButtonClicked;
                removeButton.Clicked -= OnRemoveButtonClicked;
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
