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
            _window.TouchEvent += OnWindowTouched;

            // Add a _text label to the window
            _text = new TextLabel("Hello Mono World");
            _text.ParentOrigin = ParentOrigin.Center;
            _text.PivotPoint = PivotPoint.Center;
            _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.PointSize = 32.0f;

            _window.Add(_text);
        }

        // Callback for _animation finished signal handling
        private void AnimationFinished(object sender, EventArgs e)
        {
            if (_animation)
            {
                Tizen.Log.Debug("NUI", "Duration= " + _animation.Duration);
                Tizen.Log.Debug("NUI", "EndAction= " + _animation.EndAction);
            }
        }

        // Callback for window touched signal handling
        private void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            // Only animate the _text label when touch down happens
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                // Create a new _animation
                if (_animation)
                {
                    _animation.Reset();
                }

                _animation = new Animation(1000); // 1 second of duration

                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), Vector3.XAxis), 0, 500);
                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), Vector3.XAxis), 500, 1000);
                _animation.EndAction = Animation.EndActions.Discard;

                // Connect the signal callback for animaiton finished signal
                _animation.Finished += AnimationFinished;

                // Play the _animation
                _animation.Play();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void _Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Hello mono world.");
            //Example example = new Example();
            //Example example = new Example("stylesheet");
            Example example = new Example("stylesheet", WindowMode.Transparent);
            example.Run(args);
        }
    }
}
