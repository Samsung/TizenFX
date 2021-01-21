﻿using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class AppBarSample : IExample
    {
        private Page firstPage, secondPage;
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
                Text = "2",
                Size = new Size(72.0f, 72.0f)
            };
            firstActionButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                CreateSecondPage();
            };

            firstAppBar = new AppBar("First Page", firstActionButton)
            {
                AutoNavigationContent = false
            };

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

            firstPage = new Page(firstAppBar, firstButton);

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(firstPage);
        }

        private void CreateSecondPage()
        {
            secondActionButton = new Button()
            {
                Text = "1",
                Size = new Size(72.0f, 72.0f)
            };
            secondActionButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            };

            secondAppBar = new AppBar("Second Page", secondActionButton);

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

            secondPage = new Page(secondAppBar, secondButton);

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
