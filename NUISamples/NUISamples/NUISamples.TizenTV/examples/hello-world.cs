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
using Tizen.NUI.Extension.Test;

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;
        private int cnt;
        private View _view;

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
            InternalSetting.DefaultParentOriginAsTopLeft = false;
            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;
            stage.Touch += OnStageTouched;
            stage.Key += OnStageKeyEvent;

            _text = new TextLabel("Hello NUI World");
            _text.ParentOrigin = ParentOrigin.Center;
            _text.AnchorPoint = AnchorPoint.Center;
            _text.HorizontalAlignment = "CENTER";
            _text.PointSize = 32.0f;
            _text.TextColor = Color.Magenta;
            stage.GetDefaultLayer().Add(_text);

            _view = new View();
            _view.Size = new Size(100, 100, 100);
            _view.SizeWidth = 50;
            Tizen.Log.Debug("NUI", "[1]_view SizeWidth=" + _view.SizeWidth);

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

            _view.SizeWidth = 50;
            Tizen.Log.Debug("NUI", "[2]_view SizeWidth=" + _view.SizeWidth);

            ActorTest _actorExt = new ActorTest();
            Actor _actor1 = _actorExt.CreateActor();
            if(_actor1) Tizen.Log.Debug("NUI", "FriendAssembly Test _actor1 name = " + _actor1.Name);
            else Tizen.Log.Debug("NUI", "FriendAssembly Test _actor1 is NULL!");

        }

        public void AnimationFinished(object sender, EventArgs e)
        {
            Tizen.Log.Debug("NUI", "AnimationFinished()! cnt=" + (cnt));
            if (_animation)
            {
                Tizen.Log.Debug("NUI", "Duration= " + _animation.Duration + "EndAction= " + _animation.EndAction);
            }
            _view.SizeWidth = 50;
            Tizen.Log.Debug("NUI", "[3]_view SizeWidth=" + _view.SizeWidth);
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
                        cnt++;
                        Tizen.Log.Debug("NUI", "AnimationFinished added!");
                    }
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (_animation)
                    {
                        _animation.Finished -= AnimationFinished;
                        cnt--;
                        Tizen.Log.Debug("NUI", "AnimationFinished removed!");
                    }
                }
            }
        }

        public void OnStageTouched(object sender, Stage.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                if (_animation)
                {
                    //_animation.Stop(Dali.Constants.Animation.EndAction.Stop);
                    //_animation.Reset();
                }
                _animation.Play();
            }
        }

        [STAThread]
        static void _Main(string[] args)
        {
            //Tizen.Log.Debug("NUI", "Main() called!");
            Example example = new Example();
            example.Run(args);
        }
    }
}
