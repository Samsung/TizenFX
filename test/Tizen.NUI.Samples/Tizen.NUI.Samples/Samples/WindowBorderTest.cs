using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using static Tizen.NUI.Window;

namespace Tizen.NUI.Samples
{
    public class WindowBorderSample : IExample
    {
        private View parent1;
        private Navigator navigator;
        private ContentPage firstPage, secondPage;
        private Button firstButton, secondButton;
        private Button textButton;
        private Button textButton1;
        private void Popped(object sender, PoppedEventArgs args)
        {
            global::System.Console.WriteLine("Page is popped!");
            args.Page.Dispose();

            if (args.Page == firstPage)
            {
                firstPage = null;
            }
            else
            {
                secondPage = null;
            }

            navigator.Popped -= Popped;
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            navigator = new Navigator()
           {
               WidthResizePolicy = ResizePolicyType.FillToParent,
               HeightResizePolicy = ResizePolicyType.FillToParent
           };

            window.Add(navigator);

            CreateFirstPage();

            textButton = new Button();
            textButton.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton.Size = new Size(100, 80);
            textButton.TextLabel.Text = "Left";

            textButton.PositionUsesPivotPoint = true;
            textButton.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
            textButton.PivotPoint = Tizen.NUI.ParentOrigin.BottomLeft;
            window.Add(textButton);

            textButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                Window.Instance.RequestResizeToServer(ResizeDirection.BottomLeft);
            };

            textButton1 = new Button();
            textButton1.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton1.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton1.Size = new Size(100, 80);
            textButton1.TextLabel.Text = "Right";

            textButton1.PositionUsesPivotPoint = true;
            textButton1.ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight;
            textButton1.PivotPoint = Tizen.NUI.ParentOrigin.BottomRight;
            window.Add(textButton1);

            textButton1.Clicked += (object sender, ClickedEventArgs e) =>
            {
                Window.Instance.RequestResizeToServer(ResizeDirection.BottomRight);
            };
        }

        private void CreateFirstPage()
        {
            firstButton = new Button()
            {
                Text = "First Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            firstButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                CreateSecondPage();
            };

            parent1 = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size(50, 50),
                }
            };

            parent1.Add(firstButton);
            firstPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    AutoNavigationContent = false,
                    Title = "FirstPage",
                },
                Content = parent1,
            };
            firstPage.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("First Page is appearing!");
            };
            firstPage.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("First Page is disappearing!");
            };

            navigator.Push(firstPage);
        }

        private void CreateSecondPage()
        {
            secondButton = new Button()
            {
                Text = "Second Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            secondButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                navigator.Pop();
            };

            secondPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "SecondPage",
                },
                Content = secondButton,
            };
            secondPage.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Second Page is appearing!");
            };
            secondPage.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Second Page is disappearing!");
            };

            navigator.Push(secondPage);
        }

        public void Deactivate()
        {
            if (navigator != null)
            {
                NUIApplication.GetDefaultWindow().Remove(navigator);

                navigator.Dispose();
                navigator = null;
                firstButton = null;
                firstPage = null;
                secondButton = null;
                secondPage = null;
            }
        }
    }
}
