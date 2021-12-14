
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class BorderWindowTest : NUIApplication
    {
        public BorderWindowTest(Size2D winSize, Position2D winPos, bool border) : base("", WindowMode.Transparent, winSize, winPos, border)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window win = GetDefaultWindow();
            win.KeyEvent += OnKeyEvent;

            ContentPage page = new ContentPage()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Cyan,
            };

            page.AppBar = new AppBar()
            {
                Title = "     this is AppBar",
                WidthSpecification = 495,
                HeightSpecification = 100,
                BackgroundColor = Color.Yellow,
            };

            page.Content = new View()
            {
                BackgroundColor = Color.Blue,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var content1 = new View()
            {
                BackgroundColor = Color.Magenta,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            page.Content.Add(content1);

            var content2 = new View()
            {
                BackgroundColor = Color.Green,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            page.Content.Add(content2);

            win.GetDefaultLayer().Add(page);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }
    }
}
