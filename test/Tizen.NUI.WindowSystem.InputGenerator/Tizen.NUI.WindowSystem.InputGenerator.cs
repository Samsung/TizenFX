/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.WindowSystem;
using System.Collections.Generic;

namespace Tizen.NUI.WindowSystem
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
            Log.Debug("GeneratorSample", "Initialize() started");

            Window win = Window.Instance;
            Log.Debug("GeneratorSample", "Window.Instance obtained");

            try
            {
                Log.Debug("GeneratorSample", "Creating TizenCoreWlDisplay...");
                display = new TizenCoreWlDisplay();
                Log.Debug("GeneratorSample", "TizenCoreWlDisplay created");

                Log.Debug("GeneratorSample", "Connecting TizenCoreWlDisplay...");
                display.Connect();
                Log.Debug("GeneratorSample", "TizenCoreWlDisplay connected");

                Log.Debug("GeneratorSample", "Creating InputGenerator with DeviceType.All...");
                inputGen = new InputGenerator(display, InputGenerator.DeviceType.All, null);
                Log.Debug("GeneratorSample", "InputGenerator created");
            }
            catch (Exception e)
            {
                Log.Error("GeneratorSample", $"Failed to initialize TizenCoreWl/InputGenerator: {e.GetType().Name}: {e.Message}");
                Log.Error("GeneratorSample", $"StackTrace: {e.StackTrace}");
            }

            win.WindowSize = new Size2D(500, 500);
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.White;

            View windowView = new View();
            windowView.Size2D = new Size2D(500, 500);
            windowView.BackgroundColor = Color.White;
            windowView.TouchEvent += OnTouchEvent;
            win.Add(windowView);

            centerLabel = new TextLabel("InputGenerator Sample, Click to generate Return Key.");
            centerLabel.HorizontalAlignment = HorizontalAlignment.Center;
            centerLabel.VerticalAlignment = VerticalAlignment.Center;
            centerLabel.TextColor = Color.Black;
            centerLabel.PointSize = 12.0f;
            centerLabel.HeightResizePolicy = ResizePolicyType.FillToParent;
            centerLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            windowView.Add(centerLabel);

            repeatCounter = 0;
            Log.Debug("GeneratorSample", "Initialize() completed");
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
            {
                repeatCounter++;
                centerLabel.Text = "Return Key Pressed, counter: " + repeatCounter.ToString();
            }
        }

        private bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                inputGen.GenerateKey("Return", true);
                inputGen.GenerateKey("Return", false);

                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private TizenCoreWlDisplay display;
        private InputGenerator inputGen;
        private TextLabel centerLabel;
        int repeatCounter = 0;
    }
}
