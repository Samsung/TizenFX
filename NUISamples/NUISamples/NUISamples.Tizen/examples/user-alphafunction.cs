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

namespace UserAlphaFunctionTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;
        private View _view1, _view2, _view3;
        private UserAlphaFunctionDelegate _user_alpha_func;
        private int myCount;

        public static void Log(string str)
        {
            Tizen.Log.Debug("NUI", "[DALI C# SAMPLE] " + str);
        }

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

        // Declare user alpha function delegate
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate float UserAlphaFunctionDelegate(float progress);

        public void Initialize()
        {
            Log("Initialize() is called!");
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.TouchEvent += OnWindowTouched;
            window.TouchEvent += OnWindowTouched2;
            //window.EventProcessingFinished += OnEventProcessingFinished;
            window.WheelEvent += OnWindowWheelEvent;

            // Add a _text label to the window
            _text = new TextLabel("Hello Mono World");
            _text.ParentOrigin = ParentOrigin.BottomCenter;
            _text.PivotPoint = PivotPoint.BottomCenter;
            _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.PointSize = 32.0f;
            window.Add(_text);

            _view1 = new View();
            _view1.Size2D = new Size2D(200, 200);
            _view1.BackgroundColor = Color.Green;
            _view1.ParentOrigin = ParentOrigin.Center;
            _view1.PivotPoint = PivotPoint.Center;
            _view1.WidthResizePolicy = ResizePolicyType.Fixed;
            _view1.HeightResizePolicy = ResizePolicyType.Fixed;
            _view1.AddedToWindow += OnWindow;
            window.Add(_view1);

            _view2 = new View();
            _view2.BackgroundColor = Color.Red;
            _view2.Size2D = new Size2D(50, 50);
            _view2.ParentOrigin = ParentOrigin.TopLeft;
            _view2.PivotPoint = PivotPoint.TopLeft;
            _view2.WidthResizePolicy = ResizePolicyType.Fixed;
            _view2.HeightResizePolicy = ResizePolicyType.Fixed;
            _view1.Add(_view2);

            _view3 = new View();
            _view3.BackgroundColor = Color.Blue;
            _view3.Size2D = new Size2D(50, 50);
            _view3.ParentOrigin = ParentOrigin.TopLeft;
            _view3.PivotPoint = PivotPoint.TopLeft;
            _view3.WidthResizePolicy = ResizePolicyType.Fixed;
            _view3.HeightResizePolicy = ResizePolicyType.Fixed;
            _view1.Add(_view3);

            _user_alpha_func = new UserAlphaFunctionDelegate(body);

            MyAnimating();
        }

        // User defines alpha function as custom alpha function
        // Important Notification : when this custom alpha-function is implemented,
        // the other function call nor other data excess is prevented.
        // this method must be implemented to calculate the values of input and output purely.
        // unless, this will cause application crash.
        float body(float progress)
        {
            if (progress > 0.2f && progress < 0.7f)
            {
                return progress + 0.8f;
            }
            return progress;
        }

        // Callback for _animation finished signal handling
        public void AnimationFinished(object sender, EventArgs e)
        {
            Log("AnimationFinished() is called!");
            myCount = 0;
        }

        public void MyAnimating()
        {
            // Create a new _animation
            if (_animation)
            {
                _animation.Clear();
                _animation.Reset();
            }

            _animation = new Animation(10000); // 10000 milli-second of duration
            _animation.AnimateTo(_view2, "Position", new Vector3(150.0f, 150.0f, 0.0f), 5000, 10000, new AlphaFunction(_user_alpha_func));
            // Connect the signal callback for animaiton finished signal
            _animation.Finished += AnimationFinished;
            _animation.EndAction = Animation.EndActions.Discard;
            // Play the _animation
            _animation.Play();
        }

        // Callback for window touched signal handling
        public void OnWindowTouched(object source, Window.TouchEventArgs e)
        {
            // Only animate the _text label when touch down happens
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Log("OnWindowTouched() is called! PointStateType.DOWN came!");
                myCount++;
                if (myCount > 1)
                {
                    _animation.Stop();
                    Log("_animation.Stop() is called!");
                }
            }
        }

        // Callback for window touched signal handling
        public void OnWindowTouched2(object source, Window.TouchEventArgs e)
        {
            Log("OnWindowTouched2() is called!state=" + e.Touch.GetState(0));
        }

        public void OnEventProcessingFinished(object source)
        {
            Log("OnEventProcessingFinished() is called!");
        }

        public void OnWindowWheelEvent(object source, Window.WheelEventArgs e)
        {
            Log("OnWindowWheelEvent() is called!");
            //Log("OnWindowWheelEvent() is called!direction="+ e.WheelEvent.direction + " timeStamp=" + e.WheelEvent.timeStamp );
        }


        public void OnWindow(object source, EventArgs e)
        {
            Log("OnWindow() is called!");
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Log("Main() is called!");

            Example example = new Example();
            example.Run(args);

            Log("After MainLoop()");
        }
    }
}

