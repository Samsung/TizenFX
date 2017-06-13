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

namespace ImageViewTest
{
    class Example : NUIApplication
    {

        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";
        public static void Log(string str)
        {
            Tizen.Log.Debug("NUI", "[DALI C# SAMPLE] " + str);
        }

        private Animation _animation;
        private ImageView _imageView;
        private bool _isAniFinised = true;
        private Layer layer, _layer1, _layer2;
        private PushButton _pushButton1, _pushButton2;
        private Window window;

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
            Log("Customized Application Initialize event handler");
            window = Window.Instance;
            window.BackgroundColor = Color.Cyan;
            window.Touch += OnWindowTouched;
            window.WheelRoll += OnWindowWheelMoved;
            window.Key += OnWindowKeyPressed;
            //window.EventProcessingFinished += OnWindowEventProcessingFinished;

            layer = window.GetDefaultLayer();
            _layer1 = new Layer();
            _layer2 = new Layer();
            window.Add(_layer1);
            window.Add(_layer2);
            Log("_layer1.Behavior =" + _layer1.Behavior);
            if (_layer1.Behavior == Layer.LayerBehavior.LayerUI)
            {
                _layer1.Behavior = Layer.LayerBehavior.Layer2D;
                Log("again _layer1.Behavior =" + _layer1.Behavior);
            }
            // Add a ImageView to the window
            // PropertyMap map = new PropertyMap();
            // map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
            // map.Add(NpatchImageVisualProperty.URL, new PropertyValue(resources+"/images/00_popup_bg.9.png"));
            // map.Add(NpatchImageVisualProperty.Border, new PropertyValue(new Rectangle(100, 100, 100, 100)));
            _imageView = new ImageView();
            //_imageView.ImageMap = map;
            _imageView.ResourceUrl = resources+"/images/00_popup_bg.9.png";
            //_imageView.Border = new Rectangle(100, 100, 100, 100);
            _imageView.ParentOrigin = ParentOrigin.TopLeft;
            _imageView.PivotPoint = PivotPoint.TopLeft;
            _imageView.Position = new Position(5.0f, 5.0f, 0.0f);
            _imageView.PixelArea = new Vector4(0.0f, 0.0f, 0.5f, 0.5f);
            _imageView.Size = new Size(200.0f, 80.0f, 0.0f);
            //_imageView.SetResizePolicy(ResizePolicyType.USE_NATURAL_SIZE, DimensionType.ALL_DIMENSIONS);
            layer.Add(_imageView);

            _pushButton1 = new PushButton();
            _pushButton1.ParentOrigin = ParentOrigin.BottomLeft;
            _pushButton1.PivotPoint = PivotPoint.BottomLeft;
            _pushButton1.LabelText = "start animation";
            _pushButton1.Position = new Vector3(0.0f, window.Size.Height * 0.1f, 0.0f);
            _pushButton1.Clicked += OnPushButtonClicked1;
            _layer1.Add(_pushButton1);

            _pushButton2 = new PushButton();
            _pushButton2.ParentOrigin = ParentOrigin.BottomLeft;
            _pushButton2.PivotPoint = PivotPoint.BottomLeft;
            _pushButton2.LabelText = "reload image with same URL";
            _pushButton2.Position = new Vector3(0.0f, window.Size.Height * 0.2f, 0.0f);
            _pushButton2.Clicked += OnPushButtonClicked2;
            _layer2.Add(_pushButton2);

            ImageView syncImage = new ImageView();
            syncImage.ParentOrigin = ParentOrigin.CenterLeft;
            syncImage.PivotPoint = PivotPoint.CenterLeft;
            syncImage.PositionUsesAnchorPoint = true;
            syncImage.Size2D = new Size2D(150, 150);
            syncImage.ResourceUrl = resources+"/images/gallery-3.jpg";
            syncImage.SynchronosLoading = true;
            layer.Add(syncImage);

            PropertyMap _map = new PropertyMap();
            _map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
            _map.Add(NpatchImageVisualProperty.URL, new PropertyValue(resources+"/images/00_popup_bg.9.png"));
            _map.Add(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue(true));
            ImageView nPatchImage = new ImageView();
            nPatchImage.ParentOrigin = ParentOrigin.BottomLeft;
            nPatchImage.PivotPoint = PivotPoint.BottomLeft;
            nPatchImage.PositionUsesAnchorPoint = true;
            nPatchImage.Size = new Size(300.0f, 100.0f, 0.0f);
            nPatchImage.ImageMap = _map;
            layer.Add(nPatchImage);

            ImageView syncNineImage = new ImageView();
            syncNineImage.ParentOrigin = ParentOrigin.CenterLeft;
            syncNineImage.PivotPoint = PivotPoint.CenterLeft;
            syncNineImage.Position2D = new Position2D(0, 200);
            syncNineImage.PositionUsesAnchorPoint = true;
            syncNineImage.Size = new Size(150.0f, 150.0f, 0.0f);
            syncNineImage.ResourceUrl = resources+"/images/00_popup_bg.9.png";
            syncNineImage.SynchronosLoading = true;
            syncNineImage.Border = new Rectangle(0, 0, 0, 0);
            layer.Add(syncNineImage);
        }

        public bool OnPushButtonClicked2(object sender, EventArgs e)
        {
            if (_imageView)
            {
                Log("OnPushButtonClicked2()!");
                layer.Remove(_imageView);
                _imageView = new ImageView();
                _imageView.ResourceUrl = resources+"/images/gallery-3.jpg";
                _imageView.ParentOrigin = ParentOrigin.Center;
                _imageView.PivotPoint = PivotPoint.Center;
                _imageView.PixelArea = new Vector4(0.0f, 0.0f, 0.5f, 0.5f);
                //_imageView.SetResizePolicy(ResizePolicyType.USE_NATURAL_SIZE, DimensionType.ALL_DIMENSIONS);
                layer.Add(_imageView);
            }

            return true;
        }

        public bool OnPushButtonClicked1(object sender, EventArgs e)
        {
            if (_isAniFinised == true)
            {
                _isAniFinised = false;
                Log("OnPushButtonClicked1()!");

                // Create a new _animation
                if (_animation)
                {
                    //_animation.Stop(Tizen.NUI.Constants.Animation.EndAction.Stop);
                    _animation.Reset();
                }

                _animation = new Animation();
                _animation.AnimateTo(_imageView, "PixelArea", new Vector4(0.5f, 0.0f, 0.5f, 0.5f), 0, 1000);
                _animation.AnimateTo(_imageView, "PixelArea", new Vector4(0.5f, 0.5f, 0.5f, 0.5f), 1000, 2000);
                _animation.AnimateTo(_imageView, "PixelArea", new Vector4(0.0f, 0.0f, 1.0f, 1.0f), 2000, 3000);
                _animation.AnimateTo(_imageView, "PixelArea", new Vector4(0.5f, 0.5f, 0.5f, 0.5f), 3000, 4000);

                KeyFrames _keyFrames = new KeyFrames();
                _keyFrames.Add(0.0f, new Size(0.0f, 0.0f, 0.0f));
                _keyFrames.Add(0.3f, new Size(window.Size.Width * 0.7f, window.Size.Height * 0.7f, 0.0f));
                _keyFrames.Add(1.0f, new Size(window.Size));
                _animation.AnimateBetween(_imageView, "Size", _keyFrames, 4000, 6000, Animation.Interpolation.Linear);

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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Log("Main() called!");

            Example example = new Example();
            example.Run(args);
        }
    }
}
