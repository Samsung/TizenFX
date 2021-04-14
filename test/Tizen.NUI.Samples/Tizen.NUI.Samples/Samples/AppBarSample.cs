using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class AppBarSample : IExample
    {
        private ContentPage firstPage, secondPage;
        private AppBar firstAppBar, secondAppBar;
        private Button firstActionButton, secondActionButton;
        private Button firstButton, secondButton;

        public void Activate()
        {
            CreateFirstPage();
        }

        private void CreateFirstPage()
        {
            firstActionButton = new Button()
            {
                Text = "Page 2",
            };
            firstActionButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                CreateSecondPage();
            };

            firstAppBar = new AppBar()
            {
                AutoNavigationContent = false
            };
            firstAppBar.SetTitle("First Page");
            firstAppBar.AddActions(firstActionButton);

            firstButton = new Button()
            {
                Text = "Click to next",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            firstButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                CreateSecondPage();
            };

            firstPage = new ContentPage()
            {
                AppBar = firstAppBar,
                Content = firstButton,
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(firstPage);
        }

        private void CreateSecondPage()
        {
            secondActionButton = new Button()
            {
                Text = "Page 1",
            };
            secondActionButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            };

            secondAppBar = new AppBar();
            secondAppBar.SetTitle("Second Page");
            secondAppBar.AddActions(secondActionButton);

            secondButton = new Button()
            {
                Text = "Click to prev",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            secondButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            };

            secondPage = new ContentPage()
            {
                AppBar = secondAppBar,
                Content = secondButton,
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(secondPage);
        }

        public void Deactivate()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Remove(secondPage);

            secondPage = null;
            secondAppBar = null;
            secondActionButton = null;
            secondButton = null;

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Remove(firstPage);

            firstPage = null;
            firstAppBar = null;
            firstActionButton = null;
            firstButton = null;
        }
    }
}
