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
//using Tizen.Applications;

//------------------------------------------------------------------------------
// <manual-generated />
//
// This file can only run on Tizen target. You should compile it with DaliApplication.cs, and
// add tizen c# application related library as reference.
//------------------------------------------------------------------------------
namespace PositionUsesPivotPointTest
{
    class Example : NUIApplication
    {
        private TextLabel _text1;
        private TextLabel _text2;
        private Window _window;

        public Example():base()
        {
        }

        public Example(string stylesheet):base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode):base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            // Connect the signal callback for window touched signal
            _window = Window.Instance;
            _text1 = new TextLabel("PositionUsesPivotPoint");
            _text1.ParentOrigin = ParentOrigin.Center;
            _text1.PivotPoint = PivotPoint.Center;
            _text1.Position = new Position(0, 0, 0);
            _text1.PositionUsesPivotPoint = true;
            _text1.HorizontalAlignment = HorizontalAlignment.Center;
            _text1.Size2D = new Size2D(200, 100);
            _text1.PointSize = 10.0f;
            _text1.BackgroundColor = Color.Blue;
            _window.Add(_text1);

            _text2 = new TextLabel("PositionNotUsesPivotPoint");
            _text2.ParentOrigin = ParentOrigin.Center;
            _text2.PivotPoint = PivotPoint.Center;
            _text2.Position = new Position(0, 0, 0);
            _text2.PositionUsesPivotPoint = false;
            _text2.HorizontalAlignment = HorizontalAlignment.Center;
            _text2.Size2D = new Size2D(200, 100);
            _text2.PointSize = 10.0f;
            _text2.BackgroundColor = Color.Red;
            _window.Add(_text2);
        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Hello mono world.");
            Example example = new Example("stylesheet", WindowMode.Transparent);
            example.Run(args);
        }
    }
}
