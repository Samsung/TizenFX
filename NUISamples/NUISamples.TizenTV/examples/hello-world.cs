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
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace MyCSharpExample
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;

        public Example() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Console.WriteLine("Customized Application Initialize event handler");
            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;
            stage.Touch += OnStageTouched;
            stage.Key += OnStageKeyEvent;

            // Add a _text label to the stage
            _text = new TextLabel("Hello NUI World");
            _text.ParentOrigin = ParentOrigin.Center;
            _text.AnchorPoint = AnchorPoint.Center;
            _text.HorizontalAlignment = "CENTER";
            _text.PointSize = 32.0f;
            _text.TextColor = Color.Magenta;
            stage.GetDefaultLayer().Add(_text);
        }

        // Callback for _animation finished signal handling
        public void AnimationFinished(object sender, EventArgs e)
        {
            Console.WriteLine("AnimationFinished()!");
            if (_animation)
            {
                Console.WriteLine("Duration= " + _animation.Duration);
                Console.WriteLine("EndAction= " + _animation.EndAction);
            }
        }

        public void OnStageKeyEvent(object sender, Stage.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    if (_animation)
                    {
                        _animation.Finished += AnimationFinished;
                        Console.WriteLine("AnimationFinished added!");
                    }
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (_animation)
                    {
                        _animation.Finished -= AnimationFinished;
                        Console.WriteLine("AnimationFinished removed!");
                    }
                }
            }
        }

        public void OnStageTouched(object sender, Stage.TouchEventArgs e)
        {
            // Only animate the _text label when touch down happens
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Console.WriteLine("Customized Stage Touch event handler");
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
                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);

                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);

                _animation.AnimateBy(_text, "ScaleX", 3.0f, 1000, 1500);

                _animation.AnimateBy(_text, "ScaleY", 4.0f, 1500, 2000);

                _animation.EndAction = Animation.EndActions.Discard;

                _animation.Finished += AnimationFinished;

                _animation.Play();
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Main() called!");
            Example example = new Example();
            example.Run(args);
        }
    }
}
