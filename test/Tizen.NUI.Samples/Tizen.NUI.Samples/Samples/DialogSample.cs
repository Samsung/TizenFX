﻿using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class DialogSample : IExample
    {
        private int oldPageCount = 0;

        public void Activate()
        {
            var window = NUIApplication.GetDefaultWindow();

            oldPageCount = window.GetDefaultNavigator().NavigationPages.Count;

            var button = new Button()
            {
                Text = "Click to show Dialog",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                var textLabel = new TextLabel("Message")
                {
                    BackgroundColor = Color.White,
                    Size = new Size(180, 180),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Navigator.ShowDialog(textLabel);
            };

            window.GetDefaultNavigator().Push(new Page(button));
        }

        public void Deactivate()
        {
            var window = NUIApplication.GetDefaultWindow();
            var newPageCount = window.GetDefaultNavigator().NavigationPages.Count;

            for (int i = 0; i < (newPageCount - oldPageCount); i++)
            {
                window.GetDefaultNavigator().Pop();
            }
        }
    }
}
