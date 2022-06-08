using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class MenuSample : IExample
    {
        private static readonly int itemCount = 20;
        private MenuItem[] menuItems = new MenuItem[itemCount];

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

            for (int i = 0; i < itemCount; i++)
            {
                menuItems[i] = new MenuItem() { Text = "Menu" + (i + 1) };
                menuItems[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    var menuItem = sender as MenuItem;
                    global::System.Console.WriteLine($"{menuItem.Text}'s IsSelected is changed to {args.IsSelected}.");
                };
            }

            moreButton.Clicked += (object sender, ClickedEventArgs args) =>
            {
                var menu = new Menu()
                {
                    Anchor = moreButton,
                    HorizontalPositionToAnchor = Menu.RelativePosition.Center,
                    VerticalPositionToAnchor = Menu.RelativePosition.End,
                    Items = menuItems,
                };
                menu.Post();
            };
        }

        public void Deactivate()
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (menuItems[i] != null)
                {
                    menuItems[i].Dispose();
                    menuItems[i] = null;
                }
            }

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
