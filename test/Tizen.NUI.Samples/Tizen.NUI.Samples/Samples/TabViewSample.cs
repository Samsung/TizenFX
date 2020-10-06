using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class TabViewSampole : IExample
    {
        private TabView tabView;
        private TabBar tabBar;
        private TabButton[] tabButton;
        private TabContent tabContent;
        private View[] content;
        private Button addBtn, removeBtn;
        private int count;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            tabView = new TabView();
            window.Add(tabView);

            tabBar = new TabBar();
            tabButton = new TabButton[3];
            tabBar.AddTab(tabButton[0] = new TabButton() { Text = "Tab#1" });
            tabBar.AddTab(tabButton[1] = new TabButton() { Text = "Tab#2" });
            tabBar.AddTab(tabButton[2] = new TabButton() { Text = "Tab#3" });
            tabView.TabBar = tabBar;
            count = 3;

            tabContent = new TabContent();
            content = new View[3];
            content[0] = new View();
            content[0].BackgroundColor = Color.Red;
            content[0].Add(new TextLabel() {
                Text = "Content#1",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
            tabContent.AddView(content[0]);

            content[1] = new View();
            content[1].BackgroundColor = Color.Green;
            content[1].Add(new TextLabel() {
                Text = "Content#2",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
            tabContent.AddView(content[1]);

            content[2] = new View();
            content[2].BackgroundColor = Color.Yellow;
            content[2].Add(new TextLabel() {
                Text = "Content#3",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
            tabContent.AddView(content[2]);

            tabView.Content = tabContent;

            addBtn = new Button()
            {
                Text = "Add Tab",
                Position2D = new Position2D(50, 700)
            };
            addBtn.Clicked += (object sender, ClickedEventArgs args) => {
                if (count < 3)
                {
                    tabButton[count] = new TabButton() { Text = "Tab#" + (count + 1) };
                    tabBar.AddTab(tabButton[count]);
                    count++;
                }
                else{
                    Console.WriteLine("Already have 3 tabs");
                }

            };
            window.Add(addBtn);

            removeBtn = new Button()
            {
                Text = "Remove Tab",
                Position2D = new Position2D(330, 700)
            };
            removeBtn.Clicked += (object sender, ClickedEventArgs args) => {
                if (count > 0)
                {
                    Console.WriteLine("Remove Tab#" + count);
                    tabBar.RemoveTab(tabButton[--count]);
                }
                else{
                    Console.WriteLine("No tab to remove");
                }
            };
            window.Add(removeBtn);
        }

        public void Deactivate()
        {
            if (tabView != null)
            {
                NUIApplication.GetDefaultWindow().Remove(tabView);
                tabView.Dispose();
            }
        }
    }
}
