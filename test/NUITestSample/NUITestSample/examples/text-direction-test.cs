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
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace TextDirectionTest
{
    class Example : NUIApplication
    {
        TextLabel label1;
        TextLabel label2;

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
            window.BackgroundColor = Color.Cyan;

            label1 = new TextLabel()
            {
                Text = "Hello world",
                PixelSize = 32.0f,
                Size2D = new Size2D(500, 100),
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Green,
                HorizontalAlignment = HorizontalAlignment.End,
            };
            //if (label1.TextDirection == TextDirection.LeftToRight)
            //{
            //    label1.HorizontalAlignment = HorizontalAlignment.Begin;
            //}

            label2 = new TextLabel()
            {
                Text = "لوحة المفاتيح العربية",
                PixelSize = 32.0f,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
                Size2D = new Size2D(500, 100),
                Position2D = new Position2D(0, 200),
                BackgroundColor = Color.Green,
            };

            //Tizen.Log.Fatal("NUI", "Text label1 direction: " + label1.TextDirection);

            PushButton button = new PushButton()
            {
                LabelText = "Click",
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
                Position2D = new Position2D(0, 500),
                Focusable = true,
            };
            //Tizen.Log.Fatal("NUI", "Text label2 direction: " + label2.TextDirection);

            button.Clicked += (obj, arg) =>
            {
                Tizen.Log.Fatal("NUI", "Text label1 direction: " + label1.TextDirection);
                Tizen.Log.Fatal("NUI", "Text label2 direction: " + label2.TextDirection);
                return true;
            };

            window.Add(label1);
            window.Add(label2);
            window.Add(button);
            FocusManager.Instance.SetCurrentFocusView(button);
            //Tizen.Log.Fatal("NUI", "Text label1 direction: " + label1.TextDirection);
            //Tizen.Log.Fatal("NUI", "Text label2 direction: " + label2.TextDirection);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
