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

namespace VisaulAnimationExample
{
    class Example2 : NUIApplication
    {
        private VisualView _contentView1;
        private VisualView _contentView2;
        private VisualView _contentView3;
        private TextLabel _title;
        private PushButton _shadowButton1;
        private PushButton _shadowButton2;
        private PushButton _shadowButton3;
        private bool _active1 = false;
        private bool _active2 = false;
        private bool _active3 = false;
        private const string _resPath = "/home/owner/apps_rw/NUISamples.TizenTV/res";

        private Animation _animation;
        private bool _transitionInProgress = false;

        public Example2() : base()
        {
        }

        public Example2(string stylesheet) : base(stylesheet)
        {
        }

        public Example2(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableView titleLayout = new TableView(2, 1);
            titleLayout.Name = ("TitleLayout");
            titleLayout.PivotPoint = PivotPoint.TopLeft;
            titleLayout.Position2D = new Position2D(10, 10);
            titleLayout.Size2D = new Size2D((int)(window.Size.Width * 0.9f), (int)(window.Size.Height * 0.9f));
            titleLayout.SetCellPadding(new Size2D(10, 10));
            titleLayout.BackgroundColor = Color.Cyan;
            window.Add(titleLayout);

            _title = new TextLabel("Visual Transition Example");
            _title.Name = ("Title");
            _title.SetStyleName("Title");
            _title.WidthResizePolicy = ResizePolicyType.FillToParent;
            _title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            _title.HorizontalAlignment = HorizontalAlignment.Center;
            titleLayout.AddChild(_title, new TableView.CellPosition(0, 0));
            titleLayout.SetFitHeight(0);

            TableView contentLayout = new TableView(3, 2);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.PivotPoint = PivotPoint.TopLeft;
            contentLayout.SetCellPadding(new Size2D(10, 10));
            contentLayout.BackgroundColor = Color.Magenta;
            titleLayout.AddChild(contentLayout, new TableView.CellPosition(1, 0));

            //////////////////////////////////////////////////////////////////////
            // make visual position animation
            _contentView1 = new VisualView();
            _contentView1.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView1.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //_contentView.Size2D = new Size2D(250, 250);
            _contentView1.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            ImageVisual _icon = new ImageVisual();
            _icon.URL = _resPath + "/images/application-icon-0.png";
            _icon.DepthIndex = 1;
            _icon.Size = new Size2D(50, 50);
            _icon.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon.Position = new Position2D(5, 5);
            _icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            _icon.MixColor = new Color(0, 1, 0, 0.5f);
            _icon.Opacity = 0.5f;
            _contentView1.AddVisual("icon_visual1", _icon);

            contentLayout.AddChild(_contentView1, new TableView.CellPosition(0, 0));

            _shadowButton1 = new PushButton();
            _shadowButton1.LabelText = "Toggle Transition Position";
            _shadowButton1.Name = ("ToggleTransition");
            _shadowButton1.ParentOrigin = ParentOrigin.Center;
            _shadowButton1.PivotPoint = PivotPoint.Center;
            _shadowButton1.Clicked += (obj, ev) =>
            {
                _active1 = !_active1;
                StartTransition(_contentView1, _icon, "Position", _active1);
                return true;
            };
            _shadowButton1.WidthResizePolicy = ResizePolicyType.FillToParent;
            _shadowButton1.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.AddChild(_shadowButton1, new TableView.CellPosition(0, 1));

            //////////////////////////////////////////////////////////////////////
            // make visual opacity animation
            _contentView2 = new VisualView();
            _contentView2.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView2.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //_contentView.Size2D = new Size2D(250, 250);
            _contentView2.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            ImageVisual _icon2 = new ImageVisual();
            _icon2.URL = _resPath + "/images/application-icon-0.png";
            _icon2.DepthIndex = 1;
            _icon2.Size = new Size2D(50, 50);
            _icon2.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon2.Position = new Position2D(5, 5);
            _icon2.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon2.Origin = Visual.AlignType.TopBegin;
            _icon2.AnchorPoint = Visual.AlignType.TopBegin;
            _icon2.MixColor = new Color(0, 1, 0, 0.5f);
            _icon2.Opacity = 0.5f;
            _contentView2.AddVisual("icon_visual2", _icon2);

            contentLayout.AddChild(_contentView2, new TableView.CellPosition(1, 0));

            _shadowButton2 = new PushButton();
            _shadowButton2.LabelText = "Toggle Transition Opacity";
            _shadowButton2.Name = ("ToggleTransition");
            _shadowButton2.ParentOrigin = ParentOrigin.Center;
            _shadowButton2.PivotPoint = PivotPoint.Center;
            _shadowButton2.Clicked += (obj, ev) =>
            {
                _active2 = !_active2;
                StartTransition(_contentView2, _icon2, "Opacity", _active2);
                return true;
            };
            _shadowButton2.WidthResizePolicy = ResizePolicyType.FillToParent;
            _shadowButton2.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.AddChild(_shadowButton2, new TableView.CellPosition(1, 1));

            //////////////////////////////////////////////////////////////////////
            // make AnimatedImage visual test
            _contentView3 = new VisualView();
            _contentView3.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView3.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //_contentView.Size2D = new Size2D(250, 250);
            _contentView3.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            ImageVisual _icon3 = new ImageVisual();
            _icon3.URL = _resPath + "/images/application-icon-0.png";
            _icon3.DepthIndex = 1;
            _icon3.Size = new Size2D(50, 50);
            _icon3.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon3.Position = new Position2D(5, 5);
            _icon3.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon3.Origin = Visual.AlignType.TopBegin;
            _icon3.AnchorPoint = Visual.AlignType.TopBegin;
            _icon3.MixColor = new Color(0, 1, 0, 0.5f);
            _icon3.Opacity = 0.5f;
            _contentView3.AddVisual("icon_visual3", _icon3);

            contentLayout.AddChild(_contentView3, new TableView.CellPosition(2, 0));

            _shadowButton3 = new PushButton();
            _shadowButton3.LabelText = "Toggle Transition MixColor";
            _shadowButton3.Name = ("ToggleTransition");
            _shadowButton3.ParentOrigin = ParentOrigin.Center;
            _shadowButton3.PivotPoint = PivotPoint.Center;
            _shadowButton3.Clicked += (obj, ev) =>
            {
                _active3 = !_active3;
                StartTransition(_contentView3, _icon3, "MixColor", _active3);
                return true;
            };
            _shadowButton3.WidthResizePolicy = ResizePolicyType.FillToParent;
            _shadowButton3.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.AddChild(_shadowButton3, new TableView.CellPosition(2, 1));
        }

        private void StartTransition(VisualView view, VisualMap target, string property, bool activate)
        {
            if (_animation)
            {
                _animation.Stop();
                _animation.Finished += OnTransitionFinished;
            }

            if (activate)
            {
                if (property == "Position")
                {
                    _animation = view.AnimateVisual(target, property, new Position2D(20, 20), 0, 1000, AlphaFunction.BuiltinFunctions.Linear, new Position2D(40, 40));
                }
                else if (property == "Opacity")
                {
                    _animation = view.AnimateVisual(target, property, 0.0f, 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
                }
                else if (property == "MixColor")
                {
                    _animation = view.AnimateVisual(target, property, Color.Green, 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
                }
            }
            else
            {
                if (property == "Position")
                {
                    _animation = view.AnimateVisual(target, property, new Position2D(5, 5), 0, 1000);
                }
                else if (property == "Opacity")
                {
                    _animation = view.AnimateVisual(target, property, 1.0f, 0, 1000);
                }
                else if (property == "MixColor")
                {
                    _animation = view.AnimateVisual(target, property, Color.Red, 0, 1000);
                }
            }

            if (_animation)
            {
                _animation.Finished += OnTransitionFinished;
                _transitionInProgress = true;
                _animation.Play();
            }
        }
        private void OnTransitionFinished(object sender, EventArgs e)
        {
            _transitionInProgress = false;
            if (_animation)
            {
                _animation.Finished += OnTransitionFinished;
                _animation.Reset();
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }


    }
}
