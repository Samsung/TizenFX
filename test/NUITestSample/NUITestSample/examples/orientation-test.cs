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

namespace OrientationTest
{
    class Example : NUIApplication
    {
        private const string resources = "/home/owner/apps_rw/NUISamples/res";

        private ImageView _imageView;
        private PushButton _pushButton1, _pushButton2;
        private Window window;

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
            window = Window.Instance;
            window.BackgroundColor = Color.White;

            _imageView = new ImageView()
            {
                ResourceUrl = resources + "/images/gallery-0.jpg",
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center, //CenterLeft/TopLeft/BottomLeft(left)
                Size2D = new Size2D(400, 300),
            };
            window.Add(_imageView);

            _pushButton1 = new PushButton()
            {
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                LabelText = "left rotate",
                Focusable = true,
                Position = new Vector3(window.Size.Width * 0.1f, window.Size.Height * 0.1f, 0.0f),
            };
            _pushButton1.Clicked += OnPushButtonClicked1;
            window.Add(_pushButton1);

            _pushButton2 = new PushButton()
            {
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                LabelText = "right rotate",
                Focusable = true,
                Position = new Vector3(window.Size.Width * 0.2f, window.Size.Height * 0.1f, 0.0f),
            };
            _pushButton2.Clicked += OnPushButtonClicked2;
            window.Add(_pushButton2);

            FocusManager.Instance.SetCurrentFocusView(_pushButton1);
            _pushButton1.RightFocusableView = _pushButton2;
            _pushButton2.LeftFocusableView = _pushButton1;
        }

        public bool OnPushButtonClicked2(object sender, EventArgs e)
        {
            _imageView.Orientation = new Rotation(new Radian(new Degree(360.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            return true;
        }

        public bool OnPushButtonClicked1(object sender, EventArgs e)
        {
            _imageView.Orientation = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            return true;
        }
    }
}
