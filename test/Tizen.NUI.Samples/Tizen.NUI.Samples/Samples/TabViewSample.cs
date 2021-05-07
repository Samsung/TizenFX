using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class TabViewSample : IExample
    {
        private TabView tabView;
        private TabButton tabButton, tabButton2, tabButton3;
        private View content, content2, content3;
        private Button addBtn, removeBtn;
        private int tabCount;

        public void Activate()
        {
            var window = NUIApplication.GetDefaultWindow();

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

            window.Add(tabView);

            addBtn = new Button()
            {
                Text = "+Tab",
                Size = new Size(100, 72),
                Position = new Position(80, 290)
            };

            addBtn.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount < 3)
                {
                    tabCount++;

                    var newTabButton = new TabButton()
                    {
                        Text = "Tab#" + tabCount.ToString()
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
            var window = NUIApplication.GetDefaultWindow();

            if (tabView != null)
            {
                window.Remove(tabView);
                tabView.Dispose();
                tabView = null;
            }

            if (addBtn != null)
            {
                window.Remove(addBtn);
                addBtn.Dispose();
                addBtn = null;
            }

            if (removeBtn != null)
            {
                window.Remove(removeBtn);
                removeBtn.Dispose();
                removeBtn = null;
            }
        }
    }
}
