using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class MenuSample : IExample
    {
        public void Activate()
        {
            var window = NUIApplication.GetDefaultWindow();
            var navigator = window.GetDefaultNavigator();

            var pageContent = new Button()
            {
                Text = "Page Content",
                CornerRadius = 0,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var moreButton = new Button()
            {
                Text = "More",
            };

            var appBar = new AppBar()
            {
                AutoNavigationContent = false,
                Title = "Title",
                Actions = new View[] { moreButton, },
            };

            var page = new ContentPage()
            {
                AppBar = appBar,
                Content = pageContent,
            };
            navigator.Push(page);

            var menuItem = new MenuItem() { Text = "Menu" };
            menuItem.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"1st MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem2 = new MenuItem() { Text = "Menu2" };
            menuItem2.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"2nd MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem3 = new MenuItem() { Text = "Menu3" };
            menuItem3.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"3rd MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem4 = new MenuItem() { Text = "Menu4" };
            menuItem4.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"4th MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            moreButton.Clicked += (object sender, ClickedEventArgs args) =>
            {
                var menu = new Menu()
                {
                    Anchor = moreButton,
                    HorizontalPositionToAnchor = Menu.RelativePosition.Center,
                    VerticalPositionToAnchor = Menu.RelativePosition.End,
                    Items = new MenuItem[] { menuItem, menuItem2, menuItem3, menuItem4 },
                };
                menu.Post();
            };
        }

        public void Deactivate()
        {
            var window = NUIApplication.GetDefaultWindow();
            var navigator = window.GetDefaultNavigator();
            var newPageCount = window.GetDefaultNavigator().PageCount;

            for (int i = 0; i < newPageCount; i++)
            {
                navigator.Pop();
            }
        }
    }
}
