/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.WindowSystem;

namespace Tizen.WindowSystem.InputGeneratorTest
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window win = Window.Default;
            inputGen = new InputGenerator();

            win.WindowSize = new Size2D(500, 500);
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.White;

            // Root layout
            View rootView = new View();
            rootView.Size2D = new Size2D(500, 500);
            rootView.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };
            win.Add(rootView);

            // Upper area: touch to generate SendKey
            View touchView = new View();
            touchView.SizeWidth = 500;
            touchView.Weight = 1.0f;
            touchView.SizeHeight = 400;
            touchView.BackgroundColor = Color.White;
            touchView.TouchEvent += OnTouchView;
            rootView.Add(touchView);

            centerLabel = new TextLabel("Touch upper area: SendKey test\nTouch counter: 0 / Key counter: 0");
            centerLabel.HorizontalAlignment = HorizontalAlignment.Center;
            centerLabel.VerticalAlignment = VerticalAlignment.Center;
            centerLabel.TextColor = Color.Black;
            centerLabel.PointSize = 12.0f;
            centerLabel.MultiLine = true;
            centerLabel.HeightResizePolicy = ResizePolicyType.FillToParent;
            centerLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            touchView.Add(centerLabel);

            // Lower area: button to generate SendPointer
            var sendPointerBtn = new Tizen.NUI.Components.Button()
            {
                Text = "SendPointer (generate touch at upper area)",
                SizeWidth = 500,
                SizeHeight = 80,
                PointSize = 10.0f,
                PositionY = 300f
            };
            sendPointerBtn.Clicked += OnSendPointerClicked;
            rootView.Add(sendPointerBtn);
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
            {
                keyCounter++;
                UpdateLabel();
            }
        }

        /// <summary>
        /// Touch on upper area → SendKey("Return") test
        /// </summary>
        private bool OnTouchView(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                touchCounter++;
                UpdateLabel();

                inputGen.SendKey("Return", true);
                inputGen.SendKey("Return", false);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Button click → SendPointer() generates a touch at (250, 150) which lands on the upper touchView.
        /// This triggers OnTouchView, proving SendPointer works.
        /// </summary>
        private void OnSendPointerClicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            inputGen.SendPointer(0, PointerAction.Down, 250, 150, InputGeneratorDevices.Touchscreen);
            inputGen.SendPointer(0, PointerAction.Up, 250, 150, InputGeneratorDevices.Touchscreen);
        }

        private void UpdateLabel()
        {
            centerLabel.Text = $"Touch counter: {touchCounter} / Key counter: {keyCounter}";
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private InputGenerator inputGen;
        private TextLabel centerLabel;
        int touchCounter = 0;
        int keyCounter = 0;
    }
}
