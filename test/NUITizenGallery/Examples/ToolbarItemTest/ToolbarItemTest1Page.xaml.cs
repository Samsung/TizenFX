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
using System.Text.RegularExpressions;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ToolbarItemTest1Page : ContentPage
    {
        public ToolbarItemTest1Page()
        {
            InitializeComponent();
            addPage1Button.Clicked += OnButtonClicked;
            addPage2Button.Clicked += OnButtonClicked;
            addPage3Button.Clicked += OnButtonClicked;
            addPage4Button.Clicked += OnButtonClicked;
        }

        private void OnButtonClicked(object sender, ClickedEventArgs e)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            int pageNumber = int.Parse(Regex.Match((sender as Button).Text, @"\d+").Value);
            Navigator.Push(CreatePage(pageNumber));
        }

        private Page CreatePage(int pageNumber)
        {
            var page = new ContentPage();
            page.AppBar = new AppBar
            {
                Title = $"Page {pageNumber}"
            };

            page.Content = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White
            };

            return page;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                addPage1Button.Clicked -= OnButtonClicked;
                addPage2Button.Clicked -= OnButtonClicked;
                addPage3Button.Clicked -= OnButtonClicked;
                addPage4Button.Clicked -= OnButtonClicked;
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
