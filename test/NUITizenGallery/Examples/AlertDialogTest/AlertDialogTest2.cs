﻿using System.Collections.Generic;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class AlertDialogContentPage2 : ContentPage
    {
        private Window window;

        public AlertDialogContentPage2(Window win)
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            AppBar = new AppBar()
            {
                Title = "Alert dialog page Sample",
            };

            window = win;

            var button = new Button()
            {
                Text = "Click to show Dialog",
                WidthSpecification = 400,
                HeightSpecification = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            Content = button;

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                var dialog = new AlertDialog()
                {
                    WidthSpecification = 300,
                    HeightSpecification = 300,
                };

                var title = new TextLabel()
                {
                    Size = new Size(180, 120),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                dialog.TitleContent = title;
                dialog.Title = "Title";

                var content = new TextLabel()
                {
                    Size = new Size(180, 180),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                dialog.Content = content;
                dialog.Message = "Message";

                var exitButton = new Button()
                {
                    Text = "Exit",
                    WidthSpecification = 100,
                    HeightSpecification = 60,
                };
                dialog.Actions = new List<View>() { exitButton };

                exitButton.Clicked += (object s1, ClickedEventArgs e1) =>
                {
                    window.GetDefaultNavigator().Pop();
                };

                var dialogContent = new ContentPage()
                {
                    Content = dialog,
                    BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                };

                window.GetDefaultNavigator().Push(dialogContent);
            };
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Deactivate();
            }

            base.Dispose(type);
        }

        private void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
        }
    }


    class AlertDialogTest2 : IExample
    {
        private Window window;

        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new AlertDialogContentPage2(window));
        }

        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
