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
    public partial class TabViewTestPage : ContentPage
    {
        private int tabCount = 0;

        public TabViewTestPage()
        {
            InitializeComponent();

            tabView.AddTab(CreateTabButton(), CreateView());
            tabCount++;

            tabView.AddTab(CreateTabButton(), CreateView());
            tabCount++;
        }

        private TabButton CreateTabButton()
        {
            return new TabButton() { Text = "Tab" + (tabCount + 1), };
        }

        private View CreateView()
        {
            Color backgroundColor;
            Color buttonBackgroundColor;

            if ((tabCount + 1) % 4 == 0)
            {
                backgroundColor = Color.DarkGreen;
                buttonBackgroundColor = Color.Green;
            }
            else if ((tabCount + 1) % 4 == 1)
            {
                backgroundColor = Color.DarkRed;
                buttonBackgroundColor = Color.Red;
            }
            else if ((tabCount + 1) % 4 == 2)
            {
                backgroundColor = Color.DarkBlue;
                buttonBackgroundColor = Color.Blue;
            }
            else
            {
                backgroundColor = Color.SaddleBrown;
                buttonBackgroundColor = Color.Orange;
            }

            var container = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(0, 20),
                },
                BackgroundColor = backgroundColor,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var buttonAddTab = new Button()
            {
                Text = "Add Tab",
                BackgroundColor = buttonBackgroundColor,
            };
            buttonAddTab.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount < 4)
                {
                    tabView.AddTab(CreateTabButton(), CreateView());
                    tabCount++;
                }
            };
            container.Add(buttonAddTab);

            var buttonRemoveTab = new Button()
            {
                Text = "Remove Tab",
                BackgroundColor = buttonBackgroundColor,
            };
            buttonRemoveTab.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount > 1)
                {
                    tabView.RemoveTab(tabCount - 1);
                    tabCount--;
                }
            };
            container.Add(buttonRemoveTab);

            return container;
        }
    }
}
