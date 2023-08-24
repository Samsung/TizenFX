using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class TabViewSample : IExample
    {
        private Window window;
        private Navigator navigator;
        private ContentPage contentPage;
        private TabView tabView;
        private TabButton tabButton, tabButton2, tabButton3;
        private View content, content2, content3;
        private Button addBtn, removeBtn;
        private int tabCount;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            navigator = window.GetDefaultNavigator();

            contentPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "TabView Sample",
                    AutoNavigationContent = false,
                },
            };

            tabView = new TabView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            tabCount = 0;

            tabButton = new TabButton()
            {
                Text = "Tab#1"
            };
            tabButton.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"1st TabButton's IsSelected is changed to {args.IsSelected}.");
            };

            content = new TextLabel()
            {
                Text = "Content#1",
                BackgroundColor = Color.Red,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            tabView.AddTab(tabButton, content);
            tabCount++;

            tabButton2 = new TabButton()
            {
                Text = "Tab#2"
            };
            tabButton2.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"2nd TabButton's IsSelected is changed to {args.IsSelected}.");
            };

            content2 = new TextLabel()
            {
                Text = "Content#2",
                BackgroundColor = Color.Green,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            tabView.AddTab(tabButton2, content2);
            tabCount++;

            tabButton3 = new TabButton()
            {
                Text = "Tab#3"
            };
            tabButton3.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"3rd TabButton's IsSelected is changed to {args.IsSelected}.");
            };

            content3 = new TextLabel()
            {
                Text = "Content#3",
                BackgroundColor = Color.Blue,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            tabView.AddTab(tabButton3, content3);
            tabCount++;

            contentPage.Content = tabView;

            navigator.Push(contentPage);

            addBtn = new Button()
            {
                Text = "+Tab",
                Size = new Size(100, 72),
                Position = new Position(80, 290)
            };

            addBtn.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount < 4)
                {
                    tabCount++;

                    var newTabButton = new TabButton()
                    {
                        Text = "Tab#" + tabCount.ToString()
                    };

                    int curCount = tabCount;
                    newTabButton.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                    {
                        global::System.Console.WriteLine($"{curCount}th TabButton's IsSelected is changed to {args.IsSelected}.");
                    };

                    var newContent = new TextLabel()
                    {
                        Text = "Content#" + tabCount.ToString(),
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                        HeightSpecification = LayoutParamPolicies.MatchParent,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    switch (tabCount)
                    {
                        case 1:
                            newContent.BackgroundColor = Color.Red;
                            break;
                        case 2:
                            newContent.BackgroundColor = Color.Green;
                            break;
                        default:
                            newContent.BackgroundColor = Color.Blue;
                            break;
                    }

                    tabView.AddTab(newTabButton, newContent);
                }
            };

            window.Add(addBtn);

            removeBtn = new Button()
            {
                Text = "-Tab",
                Size = new Size(100, 72),
                Position = new Position(180, 290),
            };

            removeBtn.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount > 0)
                {
                    tabCount--;
                    tabView.RemoveTab(tabCount);
                }
            };

            window.Add(removeBtn);
        }

        public void Deactivate()
        {

            if (contentPage != null)
            {
                navigator?.Remove(contentPage);
                contentPage.Dispose();
                contentPage = null;
                tabView = null;
            }

            if (addBtn != null)
            {
                window?.Remove(addBtn);
                addBtn.Dispose();
                addBtn = null;
            }

            if (removeBtn != null)
            {
                window?.Remove(removeBtn);
                removeBtn.Dispose();
                removeBtn = null;
            }

            navigator = null;
            window = null;
        }
    }
}
