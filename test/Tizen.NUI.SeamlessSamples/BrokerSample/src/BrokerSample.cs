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

namespace BrokerSample
{
    class Program : NUIApplication
    {
        private Window window;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            ApplicationTransitionManager.Instance.ApplicationFrameType = FrameType.FrameBroker;
            window = GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;

            CreateUI();
        }

        private void CreateUI()
        {
            var layoutView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal
                },
            };

            int type = 0;
            Color[] colors = { Color.Red, Color.Blue, Color.Cyan, Color.Yellow };
            foreach (var color in colors)
            {
                var button = new BrokerView()
                {
                    Name = "" + type,
                    BackgroundColor = color,
                    Margin = new Extents(30, 30, 30, 30),
                };
                type++;
                layoutView.Add(button);
            }
            GetDefaultWindow().Add(layoutView);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down
                && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
