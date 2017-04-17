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
using Tizen.NUI.Constants;

namespace VisaulAnimationExample
{
    class Example : NUIApplication
    {
        private VisualView _contentView;
        private TextLabel _title;
        private PushButton _shadowButton;
        private bool _active = false;
        private const string _resPath = "/home/owner/apps_rw/NUISamples.TizenTV/res";

        private Animation _animation;
        private bool _transitionInProgress = false;
        private int cnt1, cnt2;

        private SVGVisual svgVisual;
        private AnimatedImageVisual gifVisual;

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
            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;

            TableView titleLayout = new TableView(2, 1);
            titleLayout.Name = ("TitleLayout");
            titleLayout.AnchorPoint = AnchorPoint.TopLeft;
            titleLayout.Position2D = new Position2D(10, 10);
            titleLayout.Size2D = new Size2D((int)(stage.Size.Width * 0.9f), (int)(stage.Size.Height * 0.9f));
            titleLayout.SetCellPadding(new Size2D(10, 10));
            titleLayout.BackgroundColor = Color.Cyan;
            stage.GetDefaultLayer().Add(titleLayout);

            _title = new TextLabel("Visual Transition / SVG / AGIF Example");
            _title.Name = ("Title");
            _title.SetStyleName("Title");
            _title.WidthResizePolicy = ResizePolicyType.FillToParent;
            _title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            _title.HorizontalAlignment = HorizontalAlignment.HorizontalAlignCenter;
            titleLayout.AddChild(_title, new TableView.CellPosition(0, 0));
            titleLayout.SetFitHeight(0);

            TableView contentLayout = new TableView(3, 2);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.AnchorPoint = AnchorPoint.TopLeft;
            contentLayout.SetCellPadding(new Size2D(10, 10));
            contentLayout.BackgroundColor = Color.Magenta;
            titleLayout.AddChild(contentLayout, new TableView.CellPosition(1, 0));

            //////////////////////////////////////////////////////////////////////
            // Create a conttent view
            _contentView = new VisualView();
            _contentView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //_contentView.Size2D = new Size2D(250, 250);
            _contentView.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            ImageVisual _icon = new ImageVisual();
            _icon.URL = _resPath + "/images/application-icon-0.png";
            _icon.DepthIndex = 1;
            _icon.Size = new Size2D(50, 50);
            _icon.SizePolicy = new Vector2(1, 1);
            _icon.Position = new Position2D(5, 5);
            _icon.PositionPolicy = new Vector2(1, 1);
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            _icon.MixColor = new Color(0, 1, 0, 0.5f);
            _icon.Opacity = 0.5f;
            _contentView.AddVisual("icon_visual1", _icon);

            contentLayout.AddChild(_contentView, new TableView.CellPosition(0, 0));

            _shadowButton = new PushButton();
            _shadowButton.LabelText = "Toggle Transition";
            _shadowButton.Name = ("ToggleTransition");
            _shadowButton.ParentOrigin = ParentOrigin.Center;
            _shadowButton.AnchorPoint = AnchorPoint.Center;
            _shadowButton.Clicked += (obj, ev) =>
            {
                _active = !_active;
                StartTransition(_active);
                return true;
            };
            _shadowButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            _shadowButton.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.AddChild(_shadowButton, new TableView.CellPosition(0, 1));

            //////////////////////////////////////////////////////////////////////
            // make NPatch visual test
            NPatchVisual npatch1 = new NPatchVisual();
            npatch1.URL = _resPath + "/images/gallery-2.jpg";
            npatch1.Size = new Size2D(400, 400);
            npatch1.SizePolicy = new Vector2(1, 1);
            npatch1.Position = new Position2D(400, 0);
            npatch1.PositionPolicy = new Vector2(1, 1);
            npatch1.Origin = Visual.AlignType.TopBegin;
            npatch1.AnchorPoint = Visual.AlignType.TopBegin;
            npatch1.Border = new Rectangle(100, 100, 100, 100);
            npatch1.DepthIndex = 2;
            npatch1.MixColor = new Color(1, 0, 0, 1);
            npatch1.Opacity = 0.5f;
            _contentView.AddVisual("npatchImageVisual1", npatch1);


            //////////////////////////////////////////////////////////////////////
            // make SVG visual test
            VisualView VisualView1 = new VisualView();
            VisualView1.WidthResizePolicy = ResizePolicyType.FillToParent;
            VisualView1.HeightResizePolicy = ResizePolicyType.FillToParent;
            VisualView1.BackgroundColor = Color.Black;
            contentLayout.AddChild(VisualView1, new TableView.CellPosition(1, 0));

            svgVisual = new SVGVisual();
            svgVisual.URL = _resPath + "/images/Kid1.svg";
            svgVisual.Size = new Size2D(300, 300);
            svgVisual.SizePolicy = new Vector2(1, 1);
            svgVisual.Position = new Position2D(0, 0);
            svgVisual.PositionPolicy = new Vector2(1, 1);
            svgVisual.Origin = Visual.AlignType.TopBegin;
            svgVisual.AnchorPoint = Visual.AlignType.TopBegin;
            VisualView1.AddVisual("svg_visual1", svgVisual);

            PushButton svgButton = new PushButton();
            svgButton.LabelText = "SVG Visual Test";
            svgButton.Name = ("svg_visual_test");
            svgButton.AnchorPoint = AnchorPoint.Center;
            svgButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            svgButton.HeightResizePolicy = ResizePolicyType.FillToParent;
            svgButton.Clicked += (obj, ev) =>
            {
                cnt1++;
                if (cnt1 % 2 == 0)
                {
                    svgVisual.URL = _resPath + "/images/World.svg";
                }
                else
                {
                    svgVisual.URL = _resPath + "/images/Mail.svg";
                }
                Tizen.Log.Debug("NUI", "svg button clicked!");
                return true;
            };
            contentLayout.AddChild(svgButton, new TableView.CellPosition(1, 1));

            //////////////////////////////////////////////////////////////////////
            // make AnimatedImage visual test
            VisualView VisualView2 = new VisualView();
            VisualView2.WidthResizePolicy = ResizePolicyType.FillToParent;
            VisualView2.HeightResizePolicy = ResizePolicyType.FillToParent;
            VisualView2.BackgroundColor = Color.Blue;
            contentLayout.AddChild(VisualView2, new TableView.CellPosition(2, 0));

            gifVisual = new AnimatedImageVisual();
            gifVisual.URL = _resPath + "/images/dog-anim.gif";
            gifVisual.Size = new Size2D(200, 200);
            gifVisual.SizePolicy = new Vector2(1, 1);
            gifVisual.Position = new Position2D(0, 0);
            gifVisual.PositionPolicy = new Vector2(1, 1);
            gifVisual.Origin = Visual.AlignType.TopBegin;
            gifVisual.AnchorPoint = Visual.AlignType.TopBegin;
            VisualView2.AddVisual("gif_visual", gifVisual);

            PushButton gifButton = new PushButton();
            gifButton.LabelText = "AnimatedImage Visual Test";
            gifButton.Name = ("gif_visual_test");
            gifButton.AnchorPoint = AnchorPoint.Center;
            gifButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            gifButton.HeightResizePolicy = ResizePolicyType.FillToParent;
            gifButton.Clicked += (obj, ev) =>
            {
                Tizen.Log.Debug("NUI", "gif button clicked!");
                cnt2++;
                if (cnt2 % 2 == 0)
                {
                    gifVisual.URL = _resPath + "/images/dali-logo-anim.gif";
                }
                else
                {
                    gifVisual.URL = _resPath + "/images/echo.gif";
                }
                return true;
            };
            contentLayout.AddChild(gifButton, new TableView.CellPosition(2, 1));


        }

        private void StartTransition(bool activate)
        {
            if (_animation)
            {
                _animation.Stop();
                _animation.Finished += OnTransitionFinished;
            }

            if (activate)
            {
                AnimatorVisual grow = new AnimatorVisual();
                grow.AlphaFunction = "LINEAR";
                grow.StartTime = 0;
                grow.EndTime = 1000;
                grow.Target = "icon_visual1";
                grow.PropertyIndex = "Size";
                grow.DestinationValue = new Size2D(200, 200);
                _animation = _contentView.AnimateVisual(grow);
            }
            else
            {
                AnimatorVisual shrink = new AnimatorVisual();
                shrink.AlphaFunction = "LINEAR";
                shrink.StartTime = 0;
                shrink.EndTime = 1000;
                shrink.Target = "icon_visual1";
                shrink.PropertyIndex = "Size";
                shrink.DestinationValue = new Size2D(50, 50);
                _animation = _contentView.AnimateVisual(shrink);
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
