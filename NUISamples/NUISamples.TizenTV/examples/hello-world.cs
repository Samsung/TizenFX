/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;

namespace HelloWorldExample
{
    class Example
    {
        private void LOG(string msg)
        {
            Tizen.Log.Debug("NUI", msg);
            //Console.WriteLine("[NUI] " + msg);
        }

        private Application _application;
        private Animation _animation;
        private TextLabel _text;
        private Stage _stage;

        public Example(Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            LOG("Customized Application Initialize event handler");
            _stage = Stage.Instance;
            _stage.BackgroundColor = Color.Green;
            _stage.Touch += OnStageTouched;

            // Add a _text label to the stage
            _text = new TextLabel("Hello NUI World");
            _text.ParentOrigin = ParentOrigin.Center;
            _text.AnchorPoint = AnchorPoint.Center;
            _text.HorizontalAlignment = "CENTER";
            _text.PointSize = 32.0f;
            _text.TextColor = Color.Magenta;
            _stage.GetDefaultLayer().Add(_text);
        }

        // Callback for _animation finished signal handling
        public void AnimationFinished(object sender, EventArgs e)
        {
            LOG("AnimationFinished()!");
            if (_animation)
            {
                Console.WriteLine("Duration= " + _animation.Duration);
                Console.WriteLine("EndAction= " + _animation.EndAction);
            }
        }

        // Callback for stage touched signal handling
        public void OnStageTouched(object sender, Stage.TouchEventArgs e)
        {
            // Only animate the _text label when touch down happens
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                LOG("Customized Stage Touch event handler");
                // Create a new _animation
                if (_animation)
                {
                    //_animation.Stop(Dali.Constants.Animation.EndAction.Stop);
                    _animation.Reset();
                }

                _animation = new Animation
                {
                    Duration = 2000
                };

                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), Vector3.XAxis), 0, 500);
                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), Vector3.XAxis), 500, 1000);

                _animation.AnimateBy(_text, "ScaleX", 3.0f, 1000, 1500);
                _animation.AnimateBy(_text, "ScaleY", 4.0f, 1250, 2000);
                _animation.EndAction = Animation.EndActions.Discard;

                // Connect the signal callback for animaiton finished signal
                _animation.Finished += AnimationFinished;

                // Play the _animation
                _animation.Play();

            }
        }

        public void MainLoop()
        {
            _application.MainLoop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example(Application.NewApplication());
            example.MainLoop();
        }
    }
}
