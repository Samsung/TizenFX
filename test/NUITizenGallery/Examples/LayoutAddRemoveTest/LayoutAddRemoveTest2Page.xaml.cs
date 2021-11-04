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
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class LayoutAddRemoveTest2Page : ContentPage
    {
        float red = 1f;
        public LayoutAddRemoveTest2Page()
        {
            InitializeComponent();
            addButton.Clicked += OnAddButtonClicked;
            addTaskButton.Clicked += OnAddTaskButtonClicked;
            removeButton.Clicked += OnRemoveButtonClicked;
        }

        private void OnAddButtonClicked(object sender, ClickedEventArgs e)
        {
            linear.Add(new View
            {
                WidthSpecification = 240,
                HeightSpecification = 240,
                BackgroundColor = new Color(red / 255f, 50f / 255f, 50 / 255f, 255f),
            });

            red = red > 255f ? 1f : red + 50f;
        }

        private void OnAddTaskButtonClicked(object sender, ClickedEventArgs e)
        {
            SynchronizationContext.Current.Post(AddButton, null);
        }

        private void OnRemoveButtonClicked(object sender, ClickedEventArgs e)
        {
            if (linear.ChildCount > 0)
            {
                linear.Remove(linear.Children[0]);
            }
        }

        private void AddButton(object state)
        {
            linear.Add(new Button()
            {
                Text = "Add",
                HeightSpecification = LayoutParamPolicies.MatchParent,
            });
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
                addTaskButton.Clicked -= OnAddTaskButtonClicked;
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
