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
    public partial class EntryTest4Page : ContentPage
    {
        public EntryTest4Page()
        {
            InitializeComponent();

            string resourcesUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            string iconUrl = resourcesUrl + "images/clock_tabs_ic_stopwatch.png";

            TabButton firstTabButton = new TabButton()
            {
                Text = "FirstPage",
                IconURL = iconUrl,
            };

            TabButton secondTabButton = new TabButton()
            {
                Text = "SecondPage",
                IconURL = iconUrl,
            };

            View firstTabContent = CreateFirstContent();
            View secondTabContent = CreateSecondContent();

            tabView.AddTab(firstTabButton, firstTabContent);
            tabView.AddTab(secondTabButton, secondTabContent);
        }

        private View CreateFirstContent()
        {
            TextField textField = new TextField()
            {
                Text = "Text field"
            };

            TextLabel label = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = "Make an entry focused and then press HW backbutton or enterkey on a keyboard.",
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
                BackgroundColor = Color.Blue
            };

            View topView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Top
                },
            };

            topView.Add(textField);
            topView.Add(label);

            Button button = new Button()
            {
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Text = "Start",
                PointSize = 8,
            };

            View bottomView = new View()
            {
                SizeHeight = 150f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };

            bottomView.Add(button);

            View contentView = new View()
            {
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = new Color("#FF66FF"),
                Layout = new LinearLayout()
                {

                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Top,
                    CellPadding = new Size2D(10, 10)
                },
            };

            contentView.Add(topView);
            contentView.Add(bottomView);

            return contentView;
        }

        private View CreateSecondContent()
        {
            Button test1 = new Button
            {
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Text = "Second-1",
                Weight = 0.35f,
            };

            Button test2 = new Button
            {
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Text = "Second-2",
                Weight = 0.35f,
            };

            TextLabel label = new TextLabel
            {
                Text = "Can you see two buttons and this label?",
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
                Weight = 1.0f,
            };

            View bsView = new View()
            {
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    CellPadding = new Size2D(6, 6),
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.End
                },
            };

            bsView.Add(test1);
            bsView.Add(test2);
            bsView.Add(label);

            View contentView = new View()
            {
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Red,
            };

            contentView.Add(bsView);

            return contentView;
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
