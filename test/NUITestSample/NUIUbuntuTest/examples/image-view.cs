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
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace ImageViewTest
{
    class Example : NUIApplication
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Animation _animation;
        private ImageView _imageView;
        private bool _isAniFinised = true;
        private Layer layer, _layer1, _layer2;
        private PushButton _pushButton1, _pushButton2;
        private Window window;
        private bool urlNullTest = false;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            ImageUrlTest();
        }

        private ImageView image;
        private Timer timer;
        private bool flag;
        private void ImageUrlTest()
        {
            image = new ImageView();
            image.ResourceUrl = resourcePath + "/images/application-icon-0.png";
            image.Size2D = new Size2D(333, 333);
            image.ParentOrigin = ParentOrigin.Center;
            image.PivotPoint = PivotPoint.Center;
            image.PositionUsesPivotPoint = true;
            Window.Instance.Add(image);

            timer = new Timer(1000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            if (flag)
            {
                image.ResourceUrl = resourcePath + "/images/application-icon-0.png";
                flag = false;
                //////NUILog.Debug("flag = false!");
            }
            else
            {
                if (urlNullTest)
                {
                    image.ResourceUrl = "";
                }
                else
                {
                    image.ResourceUrl = resourcePath + "/images/image-1.jpg";
                }
                flag = true;
                ////NUILog.Debug("flag = true!");
            }
            return true;
        }

        public void Initialize()
        {
            //////NUILog.Debug("Customized Application Initialize event handler");
            window = Window.Instance;
            window.BackgroundColor = Color.Cyan;
            window.TouchEvent += OnWindowTouched;
            window.WheelEvent += OnWindowWheelMoved;
            window.KeyEvent += OnWindowKeyPressed;
            //window.EventProcessingFinished += OnWindowEventProcessingFinished;

            layer = window.GetDefaultLayer();
            _layer1 = new Layer();
            _layer2 = new Layer();
            window.AddLayer(_layer1);
            window.AddLayer(_layer2);
            //////NUILog.Debug("_layer1.Behavior =" + _layer1.Behavior);
            if (_layer1.Behavior == Layer.LayerBehavior.LayerUI)
            {
                _layer1.Behavior = Layer.LayerBehavior.Layer2D;
                ////NUILog.Debug("again _layer1.Behavior =" + _layer1.Behavior);
            }
            // Add a ImageView to the window
            // PropertyMap map = new PropertyMap();
            // map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
            // map.Add(NpatchImageVisualProperty.URL, new PropertyValue(resourcePath+"/images/00_popup_bg.9.png"));
            // map.Add(NpatchImageVisualProperty.Border, new PropertyValue(new Rectangle(100, 100, 100, 100)));
            _imageView = new ImageView();
            //_imageView.ImageMap = map;
            _imageView.ResourceUrl = resourcePath + "/images/gallery-0.jpg";
            //_imageView.Border = new Rectangle(100, 100, 100, 100);
            _imageView.ParentOrigin = ParentOrigin.TopLeft;
            _imageView.PivotPoint = PivotPoint.TopLeft;
            _imageView.Position = new Position(5.0f, 5.0f, 0.0f);
            _imageView.PixelArea = new Vector4(0.0f, 0.0f, 0.5f, 0.5f);
            _imageView.Size2D = new Size2D(200, 80);
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
            syncImage.PositionUsesPivotPoint = true;
            syncImage.Size2D = new Size2D(150, 150);
            syncImage.ResourceUrl = resourcePath + "/images/gallery-3.jpg";
            syncImage.SynchronosLoading = true;
            layer.Add(syncImage);

            PropertyMap _map = new PropertyMap();
            _map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
            _map.Add(NpatchImageVisualProperty.URL, new PropertyValue(resourcePath + "/images/gallery-4.jpg"));
            _map.Add(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue(true));
            ImageView nPatchImage = new ImageView();
            nPatchImage.ParentOrigin = ParentOrigin.BottomLeft;
            nPatchImage.PivotPoint = PivotPoint.BottomLeft;
            nPatchImage.PositionUsesPivotPoint = true;
            nPatchImage.Size2D = new Size2D(300, 100);
            nPatchImage.ImageMap = _map;
            layer.Add(nPatchImage);

            ImageView syncNineImage = new ImageView();
            syncNineImage.ParentOrigin = ParentOrigin.CenterLeft;
            syncNineImage.PivotPoint = PivotPoint.CenterLeft;
            syncNineImage.Position2D = new Position2D(0, 200);
            syncNineImage.PositionUsesPivotPoint = true;
            syncNineImage.Size2D = new Size2D(150, 150);
            syncNineImage.ResourceUrl = resourcePath + "/images/gallery-5.jpg";
            syncNineImage.SynchronosLoading = true;
            syncNineImage.Border = new Rectangle(0, 0, 0, 0);
            layer.Add(syncNineImage);
        }

        public bool OnPushButtonClicked2(object sender, EventArgs e)
        {
            if (_imageView)
            {
                //////NUILog.Debug("OnPushButtonClicked2()!");
                layer.Remove(_imageView);
                _imageView = new ImageView();
                _imageView.ResourceUrl = resourcePath + "/images/gallery-3.jpg";
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
                ////NUILog.Debug("OnPushButtonClicked1()!");

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
            ////NUILog.Debug("AnimationFinished()!");
        }

        // Callback for second _animation finished signal handling
        public void AnimationFinished2(object sender, EventArgs e)
        {
            ////NUILog.Debug("AnimationFinished2()!");
            if (_animation)
            {
                ////NUILog.Debug("Duration= " + _animation.Duration);
                ////NUILog.Debug("EndAction= " + _animation.EndAction);
                _isAniFinised = true;
            }
        }

        public void OnWindowEventProcessingFinished(object sender, EventArgs e)
        {
            ////NUILog.Debug("OnWindowEventProcessingFinished()!");
            if (e != null)
            {
                //////NUILog.Debug("e != null !");
            }
        }

        public void OnWindowKeyPressed(object sender, Window.KeyEventArgs e)
        {
            ////NUILog.Debug("OnWindowKeyEventOccured()!");
            ////NUILog.Debug("keyPressedName=" + e.Key.KeyPressedName);
            ////NUILog.Debug("state=" + e.Key.State);
        }

        public void OnWindowWheelMoved(object sender, Window.WheelEventArgs e)
        {
            ////NUILog.Debug("OnWindowWheelEventOccured()!");
            ////NUILog.Debug("direction=" + e.Wheel.Direction);
            ////NUILog.Debug("type=" + e.Wheel.Type);
        }

        // Callback for window touched signal handling
        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            ////NUILog.Debug("OnWindowTouched()! e.TouchData.GetState(0)=" + e.Touch.GetState(0));
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            ////NUILog.Debug("Main() called!");

            Example example = new Example();
            example.Run(args);
        }
    }
}
