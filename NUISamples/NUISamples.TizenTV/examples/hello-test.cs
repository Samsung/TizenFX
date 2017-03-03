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

namespace HelloTestExample
{
    class Example : NUIApplication
    {
        private void LOG(string _str)
        {
            Tizen.Log.Debug("NUI", _str);
            //Console.WriteLine("[NUI]" + _str);
        }

        private Animation _animation;
        private TextLabel _text;
        private Stage _stage;

        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, Application.WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        private void Initialize()
        {
            LOG("Customized Application Initialize event handler");
            _stage = Stage.Instance;
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
                LOG("Duration= " + _animation.Duration);
                LOG("EndAction= " + _animation.EndAction);
            }

            LOG("[4]_text PositionX =" + _text.PositionX + "  SizeHeight=" + _text.SizeHeight);
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

                LOG("[1]_text PositionX =" + _text.PositionX + "  SizeHeight=" + _text.SizeHeight);

                _animation.AnimateTo(_text, "PositionX", _text.PositionX + 200.0f);
                _animation.AnimateTo(_text, "SizeHeight", _text.SizeHeight + 200.0f);

                LOG("[2]_text PositionX =" + _text.PositionX + "  SizeHeight=" + _text.SizeHeight);

                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), Vector3.XAxis), 0, 500);
                _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), Vector3.XAxis), 500, 1000);

                //_animation.AnimateBy(_text, "ScaleX", 3.0f, 1000, 1500);
                //_animation.AnimateBy(_text, "ScaleY", 4.0f, 1250, 2000);
                _animation.EndAction = Animation.EndActions.Discard;

                // Connect the signal callback for animaiton finished signal
                _animation.Finished += AnimationFinished;

                
                // Play the _animation
                _animation.Play();

                LOG("[3]_text PositionX =" + _text.PositionX + "  SizeHeight=" + _text.SizeHeight);

            }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
