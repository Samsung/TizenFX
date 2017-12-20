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

namespace ResizePolicyTest
{
    class Example : NUIApplication
    {
        View parent;
        View child;

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

            parent = new View()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Green,
                Size2D = new Size2D(100, 100),
            };

            child = new View()
            {
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Blue,
            };
            parent.Add(child);

            Tizen.Log.Fatal("NUI", "After view create! ");
            Tizen.Log.Fatal("NUI", "parent size width: " + parent.SizeWidth);
            Tizen.Log.Fatal("NUI", "child  size width: " + child.SizeWidth);

            PushButton button = new PushButton()
            {
                LabelText = "ChangeSize",
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                Focusable = true,
            };

            button.Clicked += (obj, arg) =>
            {
                Tizen.Log.Fatal("NUI", "Before view size change! ");
                Tizen.Log.Fatal("NUI", "parent size width: " + parent.SizeWidth);
                Tizen.Log.Fatal("NUI", "child  size width: " + child.SizeWidth);

                parent.Size2D = new Size2D(200, 200);
                Tizen.Log.Fatal("NUI", "After view size change! ");
                Tizen.Log.Fatal("NUI", "parent size width: " + parent.SizeWidth);
                Tizen.Log.Fatal("NUI", "child  size width: " + child.SizeWidth);
                return true;
            };

            window.Add(parent);
            window.Add(button);
            FocusManager.Instance.SetCurrentFocusView(button);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
