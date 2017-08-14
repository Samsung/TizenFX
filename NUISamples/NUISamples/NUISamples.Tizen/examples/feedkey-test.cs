/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace FeedKeyTest
{
    class Example : NUIApplication
    {
        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view1 = new View()
            {
                Position2D = new Position2D(10, 10),
                BackgroundColor = Color.Magenta,
                Size2D = new Size2D(200, 200),
                Focusable = true
            };

            View view2 = new View()
            {
                Position2D = new Position2D(10, 240),
                BackgroundColor = Color.Red,
                Size2D = new Size2D(200, 200),
                Focusable = true
            };

            window.Add(view1);
            window.Add(view2);

            FocusManager.Instance.SetCurrentFocusView(view1);
            view2.UpFocusableView = view1;
            view1.DownFocusableView = view2;

            view1.KeyEvent += (obj, e) =>
            {
                if (e.Key.State != Key.StateType.Down)
                {
                    return false;
                }
                Tizen.Log.Debug("NUI", "View1 KeyPressedName: " + e.Key.KeyPressedName);
                Window.FeedKeyEvent(e.Key);
                return false;
            };

            view2.KeyEvent += (obj, e) =>
            {
                if (e.Key.State != Key.StateType.Down)
                {
                    // Tizen.Log.Debug("NUI", "View2 key state != Down");
                    return false;
                }

                // Tizen.Log.Debug("NUI", "View2 KeyPressedName: " + e.Key.KeyPressedName);
                View v = obj as View;
                if(v == view1)
                {
                    Tizen.Log.Debug("NUI", "View2 received view1 feed event: " + e.Key.KeyPressedName);
                }
                if (v == view2)
                {
                    Tizen.Log.Debug("NUI", "View2 received event: " + e.Key.KeyPressedName);
                }
                return false;
            };
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
