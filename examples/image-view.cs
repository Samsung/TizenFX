/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Dali.Constants;

namespace ImageViewExample
{

    class Example
    {
        public static void Log(string str)
        {
            Console.WriteLine("[DALI C# SAMPLE] " + str);
        }

        private Dali.Application _application;
        private Animation _animation;
        private ImageView _imageView;
        private bool _isAniFinised = true;
        private Layer layer, _layer1, _layer2;
        private PushButton _pushButton1, _pushButton2;
        private Window window;

        public Example(Dali.Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            Log("Customized Application Initialize event handler");
            window = Window.Instance;
            window.BackgroundColor = Color.Cyan;
            window.Touch += OnWindowTouched;
            window.Wheel += OnWindowWheelMoved;
            window.Key += OnWindowKeyPressed;
            //window.EventProcessingFinished += OnWindowEventProcessingFinished;

            layer = window.GetDefaultLayer();
            _layer1 = new Layer();
            _layer2 = new Layer();
            window.Add(_layer1);
            window.Add(_layer2);
            Log("_layer1.Behavior =" + _layer1.Behavior);
            if (_layer1.Behavior == Layer.LayerBehavior.LAYER_UI)
            {
                _layer1.Behavior = Layer.LayerBehavior.LAYER_2D;
                Log("again _layer1.Behavior =" + _layer1.Behavior);
            }
            // Add a ImageView to the window
            _imageView = new ImageView();
            _imageView.ResourceUrl = "./images/gallery-3.jpg";
            _imageView.ParentOrigin = ParentOrigin.Center;
            _imageView.AnchorPoint = AnchorPoint.Center;
            _imageView.PixelArea = new Vector4(0.0f, 0.0f, 0.5f, 0.5f);
            //_imageView.SetResizePolicy(ResizePolicyType.USE_NATURAL_SIZE, DimensionType.ALL_DIMENSIONS);
            layer.Add(_imageView);

            _pushButton1 = new PushButton();
            _pushButton1.ParentOrigin = ParentOrigin.BottomLeft;
            _pushButton1.AnchorPoint = AnchorPoint.BottomLeft;
            _pushButton1.LabelText = "start animation";
            _pushButton1.Position = new Vector3(0.0f, window.Size.Height * 0.1f, 0.0f);
            _pushButton1.Clicked += OnPushButtonClicked1;
            _layer1.Add(_pushButton1);

            _pushButton2 = new PushButton();
            _pushButton2.ParentOrigin = ParentOrigin.BottomLeft;
            _pushButton2.AnchorPoint = AnchorPoint.BottomLeft;
            _pushButton2.LabelText = "reload image with same URL";
            _pushButton2.Position = new Vector3(0.0f, window.Size.Height * 0.2f, 0.0f);
            _pushButton2.Clicked += OnPushButtonClicked2;
            _layer2.Add(_pushButton2);

        }

        public bool OnPushButtonClicked2(object sender, Button.ClickedEventArgs e)
        {
            if (_imageView)
            {
                Log("OnPushButtonClicked2()!");
                layer.Remove(_imageView);
                _imageView = new ImageView();
                _imageView.ResourceUrl = "./images/gallery-3.jpg";
                _imageView.ParentOrigin = ParentOrigin.Center;
                _imageView.AnchorPoint = AnchorPoint.Center;
                _imageView.PixelArea = new Vector4(0.0f, 0.0f, 0.5f, 0.5f);
                //_imageView.SetResizePolicy(ResizePolicyType.USE_NATURAL_SIZE, DimensionType.ALL_DIMENSIONS);
                layer.Add(_imageView);
            }

            return true;
        }


        public bool OnPushButtonClicked1(object sender, Button.ClickedEventArgs e)
        {
            if (_isAniFinised == true)
            {
                _isAniFinised = false;
                Log("OnPushButtonClicked1()!");

                // Create a new _animation
                if (_animation)
                {
                    //_animation.Stop(Dali.Constants.Animation.EndAction.Stop);
                    _animation.Reset();
                }

                _animation = new Animation();
                _animation.StartTime = 0;
                _animation.EndTime = 1000;
                _animation.TargetProperty = "PixelArea";
                _animation.Destination = new Vector4(0.5f, 0.0f, 0.5f, 0.5f);
                _animation.AnimateTo(_imageView);

                _animation.StartTime = 1000;
                _animation.EndTime = 2000;
                _animation.TargetProperty = "PixelArea";
                _animation.Destination = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
                _animation.AnimateTo(_imageView);

                _animation.StartTime = 2000;
                _animation.EndTime = 3000;
                _animation.TargetProperty = "PixelArea";
                _animation.Destination = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
                _animation.AnimateTo(_imageView);

                _animation.StartTime = 3000;
                _animation.EndTime = 4000;
                _animation.TargetProperty = "PixelArea";
                _animation.Destination = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
                _animation.AnimateTo(_imageView);

                _animation.StartTime = 4000;
                _animation.EndTime = 6000;
                _animation.TargetProperty = "Size";
                KeyFrames _keyFrames = new KeyFrames();
                _keyFrames.Add(0.0f, new Size(0.0f, 0.0f, 0.0f));
                _keyFrames.Add(0.3f, new Size((window.Size * 0.7f)));
                _keyFrames.Add(1.0f, new Size(window.Size));
                _animation.AnimateBetween(_imageView, _keyFrames, Animation.Interpolation.Linear);

                _animation.EndAction = Animation.EndActions.Discard;

                // Connect the signal callback for animaiton finished signal
                _animation.Finished += AnimationFinished;
                _animation.Finished += AnimationFinished2;

                // Play the _animation
                _animation.Play();
            }

            return true;
        }

        // Callback for _animation finished signal handling
        public void AnimationFinished(object sender, EventArgs e)
        {
            Log("AnimationFinished()!");
        }

        // Callback for second _animation finished signal handling
        public void AnimationFinished2(object sender, EventArgs e)
        {
            Log("AnimationFinished2()!");
            if (_animation)
            {
                Log("Duration= " + _animation.Duration);
                Log("EndAction= " + _animation.EndAction);
                _isAniFinised = true;
            }
        }

        public void OnWindowEventProcessingFinished(object sender, EventArgs e)
        {
            Log("OnWindowEventProcessingFinished()!");
            if (e != null)
            {
                Log("e != null !");
            }
        }

        public void OnWindowKeyPressed(object sender, Window.KeyEventArgs e)
        {
            Log("OnWindowKeyEventOccured()!");
            Log("keyPressedName=" + e.Key.KeyPressedName);
            Log("state=" + e.Key.State);
        }

        public void OnWindowWheelMoved(object sender, Window.WheelEventArgs e)
        {
            Log("OnWindowWheelEventOccured()!");
            Log("direction=" + e.Wheel.Direction);
            Log("type=" + e.Wheel.Type);
        }

        // Callback for window touched signal handling
        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            Log("OnWindowTouched()! e.TouchData.GetState(0)=" + e.Touch.GetState(0));
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
            Log("Main() called!");

            Example example = new Example(Application.NewApplication());
            example.MainLoop();
        }
    }
}

