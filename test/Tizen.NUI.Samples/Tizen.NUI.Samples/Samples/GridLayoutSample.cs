/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Samples
{
    class GridExample : IExample
    {
        private Window currentWindow;
        private static int MAX_ITEM_COUNT = 31;
        private int layoutOption = 3;

        private View layoutView;
        private TextLabel label;
        private View bottomView;
        private View bottomView_2;

        public void Activate()
        {
            Initialize();
        }

        public void Initialize()
        {
            currentWindow = NUIApplication.GetDefaultWindow();
            currentWindow.BackgroundColor = Color.White;

            InitializeDefaultUI();
            InitializeLayoutUI();
        }

        public void InitializeLayoutUI()
        {
            for (int i = 0; i < MAX_ITEM_COUNT; i++)
            {
                View child = new View()
                {
                    Size = new Size(100, 100),
                    BackgroundColor = i % 2 == 0 ? Color.Magenta : Color.Cyan,
                };

                TextLabel text = new TextLabel("" + (i + 1))
                {
                    PointSize = 14,
                    Size = new Size(50, 50),
                };

                child.Add(text);
                layoutView.Add(child);
            }

        }

        public void InitializeDefaultUI()
        {
            label = new TextLabel()
            {
                Text = "Layout Sample",
                PointSize = 20,
            };
            currentWindow.Add(label);

            layoutView = new View()
            {
                Size2D = new Size2D(480, 600),
                Position2D = new Position2D(0, 30),
                BackgroundColor = Color.Black,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Vertical,
                    Columns = 5,
                },

            };
            currentWindow.Add(layoutView);

            View bottomView = new View()
            {
                Size = new Size(480, 100),
                Position2D = new Position2D(0, 600),
                BackgroundColor = Color.Black,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Center,
                }

            };
            currentWindow.Add(bottomView);

            Button btn_1 = new Button()
            {
                Text = "Grid_V",
                Size = new Size(100, 50),
                Margin = 10,
            };
            Button btn_2 = new Button()
            {
                Text = "Grid_H",
                Size = new Size(100, 50),
                Margin = 10,
            };
            btn_1.Clicked += Btn1_Clicked;
            btn_2.Clicked += Btn2_Clicked;

            bottomView.Add(btn_1);
            bottomView.Add(btn_2);

            bottomView_2 = new View()
            {
                Size = new Size(480, 100),
                Position2D = new Position2D(0, 700),
                BackgroundColor = Color.Black,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Center,
                }
            };
            currentWindow.Add(bottomView_2);

            Button btn_5 = new Button()
            {
                Text = "++",
                Size = new Size(50, 50),
                Margin = 10,
            };
            Button btn_6 = new Button()
            {
                Text = "--",
                Size = new Size(50, 50),
                Margin = 10,
            };
            btn_5.Clicked += Btn5_Clicked;
            btn_6.Clicked += Btn6_Clicked;

            bottomView_2.Add(btn_5);
            bottomView_2.Add(btn_6);
        }

        private void Btn1_Clicked(object sender, ClickedEventArgs e)
        {
            GridLayout layout = new GridLayout();
            layout.Columns = 5;
            layout.GridOrientation = GridLayout.Orientation.Vertical;
            layoutView.Layout = layout;
            layoutOption = 1;
            layout.LayoutWithTransition = true;
        }

        private void Btn2_Clicked(object sender, ClickedEventArgs e)
        {
            GridLayout layout = new GridLayout();
            layout.LayoutWithTransition = true;
            layout.Rows = 5;
            layout.GridOrientation = GridLayout.Orientation.Horizontal;
            layoutView.Layout = layout;

            layoutOption = 2;
        }

        private void Btn5_Clicked(object sender, ClickedEventArgs e)
        {
            ObjectProcess(true);
        }

        private void Btn6_Clicked(object sender, ClickedEventArgs e)
        {
            ObjectProcess(false);
        }

        public void ObjectProcess(bool opt)
        {
            int nValue = opt ? 1 : -1;
            switch (layoutOption)
            {
                case 1:
                    (layoutView.Layout as GridLayout).Columns += nValue;
                    break;
                case 2:
                    (layoutView.Layout as GridLayout).Rows += nValue;
                    break;
            }
        }

        public void Deactivate()
        {
            label.Unparent();
            layoutView.Unparent();
            bottomView.Unparent();
            bottomView_2.Unparent();

            label.Dispose();
            layoutView.Dispose();
            bottomView.Dispose();
            bottomView_2.Dispose();

            label = null;
            layoutView = null;
            bottomView = null;
            bottomView_2 = null;
        }
    }
}
