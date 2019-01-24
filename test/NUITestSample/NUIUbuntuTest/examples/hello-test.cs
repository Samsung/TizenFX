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
namespace HelloTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;
        private Window _window;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            // Connect the signal callback for window touched signal
            _window = Window.Instance;
            _window.TouchEvent += OnWindowTouched;

            // Add a _text label to the window
            _text = new TextLabel("Hello Mono World");
            _text.ParentOrigin = ParentOrigin.Center;
            _text.PivotPoint = PivotPoint.Center;
            _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.PointSize = 32.0f;

            _window.Add(_text);
        }

        // Callback for window touched signal handling
        private void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            // Only animate the _text label when touch down happens
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Hello mono world.");
            //Example example = new Example();
            //Example example = new Example("stylesheet");
            Example example = new Example();
            example.Run(args);
        }
    }
}
