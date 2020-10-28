using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace VisaulAnimationExample
{
    class Example : NUIApplication
    {
        public Example() : base("", WindowMode.Opaque)
        {
        }
        protected override void OnCreate()
        {
            base.OnCreate();
            CreateLayout();
            ScreenPositionTest();
        }

        const string TAG = "NUI";

        #region screen position test
        Timer timer;
        void ScreenPositionTest()
        {
            timer = new Timer(1000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            Tizen.Log.Fatal(TAG, $"button1 position=({button1?.Position2D.X},{button1?.Position2D.Y}), screen position=({button1?.ScreenPosition.X},{button1?.ScreenPosition.Y})");
            Tizen.Log.Fatal(TAG, $"button2 position=({button2?.Position2D.X},{button2?.Position2D.Y}), screen position=({button2?.ScreenPosition.X},{button2?.ScreenPosition.Y})");
            Tizen.Log.Fatal(TAG, $"contentView position=({contentView?.Position2D.X},{contentView?.Position2D.Y}), screen position=({contentView?.ScreenPosition.X},{contentView?.ScreenPosition.Y})");
            return true;
        }
        #endregion

        #region visual view animation test
        VisualView contentView;
        TextLabel title;
        PushButton button1, button2, button3;
        bool active = false;
        static readonly string _resPath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        Animation animation1;
        bool transitionInProgress = false;
        int cnt1, cnt2;

        SVGVisual svgVisual;
        AnimatedImageVisual gifVisual;
        ImageVisual icon;

        Window window;
        TableView titleLayout, contentLayout;
        VisualView visualView1, visualView2;
        void CreateLayout()
        {
            window = Window.Instance;
            window.SetTransparency(true);
            window.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);

            titleLayout = new TableView(2, 1);
            titleLayout.Name = ("TitleLayout");
            titleLayout.PositionUsesPivotPoint = true;
            titleLayout.ParentOrigin = ParentOrigin.Center;
            titleLayout.PivotPoint = PivotPoint.Center;
            var layoutSizeWidth = window.Size.Width * 0.7f;
            var layoutSizeHeight = window.Size.Height * 0.7f;
            titleLayout.Size2D = new Size2D((int)(layoutSizeWidth), (int)(layoutSizeHeight));
            titleLayout.SetCellPadding(new Size2D(10, 10));
            titleLayout.BackgroundColor = Color.Cyan;
            window.Add(titleLayout);

            title = new TextLabel("Visual Transition / SVG / AGIF Example");
            title.Name = ("Title");
            title.SetStyleName("Title");
            title.WidthResizePolicy = ResizePolicyType.FillToParent;
            title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            titleLayout.AddChild(title, new TableView.CellPosition(0, 0));
            titleLayout.SetFitHeight(0);

            contentLayout = new TableView(3, 2);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.PivotPoint = PivotPoint.TopLeft;
            contentLayout.SetCellPadding(new Size2D(10, 10));
            contentLayout.BackgroundColor = Color.Magenta;
            titleLayout.AddChild(contentLayout, new TableView.CellPosition(1, 0));

            //////////////////////////////////////////////////////////////////////
            // Create a content view
            contentView = new VisualView();
            contentView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            contentView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //contentView.Size2D = new Size2D(250, 250);
            contentView.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            icon = new ImageVisual();
            icon.URL = _resPath + "/images/application-icon-0.png";
            icon.DepthIndex = 1;
            icon.Size = new Size2D(50, 50);
            icon.SizePolicy = VisualTransformPolicyType.Absolute;
            icon.Position = new Position2D(5, 5);
            icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            icon.Origin = Visual.AlignType.TopBegin;
            icon.AnchorPoint = Visual.AlignType.TopBegin;
            icon.MixColor = new Color(0, 1, 0, 0.5f);
            icon.Opacity = 0.5f;
            contentView.AddVisual("icon_visual1", icon);

            contentLayout.AddChild(contentView, new TableView.CellPosition(0, 0));

            button1 = new PushButton();
            button1.LabelText = "Toggle Transition";
            button1.Name = ("ToggleTransition");
            button1.ParentOrigin = ParentOrigin.Center;
            button1.PivotPoint = PivotPoint.Center;
            button1.Clicked += (obj, ev) =>
            {
                active = !active;
                StartTransition(active);
                return true;
            };
            button1.WidthResizePolicy = ResizePolicyType.FillToParent;
            button1.HeightResizePolicy = ResizePolicyType.FillToParent;
            button1.Focusable = true;
            button1.UpFocusableView = button3;
            button1.DownFocusableView = button2;
            contentLayout.AddChild(button1, new TableView.CellPosition(0, 1));

            //////////////////////////////////////////////////////////////////////
            // make NPatch visual test
            NPatchVisual npatch1 = new NPatchVisual();
            npatch1.URL = _resPath + "/images/gallery-2.jpg";
            npatch1.Size = new Size2D(400, 400);
            npatch1.SizePolicy = VisualTransformPolicyType.Absolute;
            npatch1.Position = new Position2D(400, 0);
            npatch1.PositionPolicy = VisualTransformPolicyType.Absolute;
            npatch1.Origin = Visual.AlignType.TopBegin;
            npatch1.AnchorPoint = Visual.AlignType.TopBegin;
            npatch1.Border = new Rectangle(100, 100, 100, 100);
            npatch1.DepthIndex = 2;
            npatch1.MixColor = new Color(1, 0, 0, 1);
            npatch1.Opacity = 0.5f;
            contentView.AddVisual("npatchImageVisual1", npatch1);

            //////////////////////////////////////////////////////////////////////
            // make SVG visual test
            visualView1 = new VisualView();
            visualView1.WidthResizePolicy = ResizePolicyType.FillToParent;
            visualView1.HeightResizePolicy = ResizePolicyType.FillToParent;
            visualView1.BackgroundColor = Color.Black;
            contentLayout.AddChild(visualView1, new TableView.CellPosition(1, 0));

            svgVisual = new SVGVisual();
            svgVisual.URL = _resPath + "/images/Kid1.svg";
            svgVisual.Size = new Size2D(300, 300);
            svgVisual.SizePolicy = VisualTransformPolicyType.Absolute;
            svgVisual.Position = new Position2D(0, 0);
            svgVisual.PositionPolicy = VisualTransformPolicyType.Absolute;
            svgVisual.Origin = Visual.AlignType.TopBegin;
            svgVisual.AnchorPoint = Visual.AlignType.TopBegin;
            visualView1.AddVisual("svg_visual1", svgVisual);

            button2 = new PushButton();
            button2.LabelText = "SVG Visual Test";
            button2.Name = ("svg_visual_test");
            button2.PivotPoint = PivotPoint.Center;
            button2.WidthResizePolicy = ResizePolicyType.FillToParent;
            button2.HeightResizePolicy = ResizePolicyType.FillToParent;
            button2.Clicked += (obj, ev) =>
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
                Tizen.Log.Fatal(TAG, "svg button clicked!");
                return true;
            };
            button2.Focusable = true;
            button2.UpFocusableView = button1;
            button2.DownFocusableView = button2;
            contentLayout.AddChild(button2, new TableView.CellPosition(1, 1));

            //////////////////////////////////////////////////////////////////////
            // make AnimatedImage visual test
            visualView2 = new VisualView();
            visualView2.WidthResizePolicy = ResizePolicyType.FillToParent;
            visualView2.HeightResizePolicy = ResizePolicyType.FillToParent;
            visualView2.BackgroundColor = Color.Blue;
            contentLayout.AddChild(visualView2, new TableView.CellPosition(2, 0));

            gifVisual = new AnimatedImageVisual();
            gifVisual.URL = _resPath + "/images/dog-anim.gif";
            gifVisual.Size = new Size2D(200, 200);
            gifVisual.SizePolicy = VisualTransformPolicyType.Absolute;
            gifVisual.Position = new Position2D(0, 0);
            gifVisual.PositionPolicy = VisualTransformPolicyType.Absolute;
            gifVisual.Origin = Visual.AlignType.TopBegin;
            gifVisual.AnchorPoint = Visual.AlignType.TopBegin;
            visualView2.AddVisual("gif_visual", gifVisual);

            button3 = new PushButton();
            button3.LabelText = "AnimatedImage Visual Test";
            button3.Name = ("gif_visual_test");
            button3.PivotPoint = PivotPoint.Center;
            button3.WidthResizePolicy = ResizePolicyType.FillToParent;
            button3.HeightResizePolicy = ResizePolicyType.FillToParent;
            button3.Clicked += (obj, ev) =>
            {
                Tizen.Log.Fatal(TAG, "gif button clicked!");
                cnt2++;
                int gifNum = cnt2 % 15;
                gifVisual.URL = _resPath + "/images/anim-gif/" + gifNum + ".gif";
                button3.LabelText = "file:" + gifNum + ".gif";
                return true;
            };
            button3.Focusable = true;
            button3.DownFocusableView = button1;
            button3.UpFocusableView = button2;
            contentLayout.AddChild(button3, new TableView.CellPosition(2, 1));

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        private void StartTransition(bool activate)
        {
            if (animation1)
            {
                animation1.Stop();
                animation1.Finished += OnTransitionFinished1;
            }

            if (activate)
            {
                contentView.AnimateVisualAdd(icon, "Size", new Size2D(150, 150), 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
                contentView.AnimateVisualAdd(icon, "Position", new Position2D(40, 40), 0, 1000);
                animation1 = contentView.AnimateVisualAddFinish();
            }
            else
            {
                contentView.AnimateVisualAdd(icon, "Size", new Position2D(50, 50), 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
                contentView.AnimateVisualAdd(icon, "Position", new Position2D(5, 5), 0, 1000);
                animation1 = contentView.AnimateVisualAddFinish();
            }

            if (animation1)
            {
                animation1.Finished += OnTransitionFinished1;
                transitionInProgress = true;
                animation1.Play();
            }
        }
        private void OnTransitionFinished1(object sender, EventArgs e)
        {
            transitionInProgress = false;
            if (animation1)
            {
                animation1.Finished += OnTransitionFinished1;
                animation1.Reset();
            }
        }
        #endregion

    }
}
