using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class NavigatorSample : IExample
    {
        private Navigator navigator;
        private ContentPage firstPage, secondPage;
        private Button firstButton, secondButton;

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

            firstPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    AutoNavigationContent = false,
                    Title = "FirstPage",
                },
                Content = firstButton,
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
