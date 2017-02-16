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
using Dali;
using Tizen.Applications;

//------------------------------------------------------------------------------
// <manual-generated />
//
// This file can only run on Tizen target. You should compile it with DaliApplication.cs, and
// add tizen c# application related library as reference.
//------------------------------------------------------------------------------
namespace MyCSharpExample
{
    class Example : DaliApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallbackDelegate(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void TouchCallbackDelegate(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void AnimationCallbackDelegate(IntPtr data);

        private Animation _animation;
        private TextLabel _text;

        public Example():base()
        {
        }

        public Example(string stylesheet):base(stylesheet)
        {
        }

        public Example(string stylesheet, Dali.Application.WINDOW_MODE windowMode):base(stylesheet, windowMode)
        {
        }

        private void Initialize()
        {
            // Connect the signal callback for stage touched signal
            TouchCallbackDelegate stageTouchedCallback = new TouchCallbackDelegate(OnStageTouched);
            stage.TouchSignal().Connect(stageTouchedCallback);

            // Add a _text label to the stage
            _text = new TextLabel("Hello Mono World");
            _text.ParentOrigin = NDalic.ParentOriginCenter;
            _text.AnchorPoint = NDalic.AnchorPointCenter;
            _text.HorizontalAlignment = "CENTER";
            _text.PointSize = 32.0f;

            stage.Add(_text);
        }

        // Callback for _animation finished signal handling
        private void AnimationFinished(IntPtr data)
        {
            Animation _animation = Animation.GetAnimationFromPtr( data );
            Console.WriteLine("Animation finished: duration = " + _animation.GetDuration());
        }

        // Callback for stage touched signal handling
        private void OnStageTouched(IntPtr data)
        {
            TouchData touchData = TouchData.GetTouchDataFromPtr( data );

            // Only animate the _text label when touch down happens
            if (touchData.GetState(0) == PointStateType.DOWN)
            {
                // Create a new _animation
                if (_animation)
                {
                    _animation.Reset();
                }

                _animation = new Animation(1.0f); // 1 second of duration

                _animation.AnimateTo(new Property(_text, Actor.Property.ORIENTATION), new Property.Value(new Quaternion(new Radian(new Degree(180.0f)), Vector3.XAXIS)), new AlphaFunction(AlphaFunction.BuiltinFunction.LINEAR), new TimePeriod(0.0f, 0.5f));
                _animation.AnimateTo(new Property(_text, Actor.Property.ORIENTATION), new Property.Value(new Quaternion(new Radian(new Degree(0.0f)), Vector3.XAXIS)), new AlphaFunction(AlphaFunction.BuiltinFunction.LINEAR), new TimePeriod(0.5f, 0.5f));

                // Connect the signal callback for animaiton finished signal
                AnimationCallbackDelegate animFinishedDelegate = new AnimationCallbackDelegate(AnimationFinished);
                _animation.FinishedSignal().Connect(animFinishedDelegate);

                // Play the _animation
                _animation.Play();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello mono world.");
            //Example example = new Example();
            //Example example = new Example("stylesheet");
            Example example = new Example("stylesheet", Dali.Application.WINDOW_MODE.TRANSPARENT);
            example.Run(args);
        }
    }
}
