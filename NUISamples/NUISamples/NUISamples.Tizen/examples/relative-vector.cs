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
//using Tizen.Applications;

//------------------------------------------------------------------------------
// <manual-generated />
//
// This file can only run on Tizen target. You should compile it with DaliApplication.cs, and
// add tizen c# application related library as reference.
//------------------------------------------------------------------------------
namespace RelativeVectorTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private ImageView _imageView;
        private Window _window;
        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";

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
            _window = Window.Instance;
            _window.TouchEvent += OnWindowTouched;

            _imageView = new ImageView();
            _imageView.ResourceUrl = resources+"/images/gallery-3.jpg";
            _imageView.ParentOrigin = ParentOrigin.Center;
            _imageView.PivotPoint = PivotPoint.Center;
            _imageView.PixelArea = new RelativeVector4(0.0f, 0.0f, 0.0f, 0.0f);

            _window.Add(_imageView);
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
                 _animation.AnimateTo(_imageView, "PixelArea", new RelativeVector4(0.0f, 0.0f, 1.0f, 1.0f), 0, 1000);
                _animation.EndAction = Animation.EndActions.Discard;
                _animation.PlayRange = new RelativeVector2(0.2f, 0.8f);

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
            Example example = new Example("stylesheet", WindowMode.Transparent);
            example.Run(args);
        }
    }
}
