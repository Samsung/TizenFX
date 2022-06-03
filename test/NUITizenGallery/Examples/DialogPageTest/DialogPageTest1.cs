using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class DialogContentPage1 : ContentPage
    {
        public DialogContentPage1(Window window)
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            AppBar = new AppBar()
            {
                Title = "Dialog Sample",
            };

            var button = new Button()
            {
                Text = "Click to show Dialog",
                WidthSpecification = 400,
                HeightSpecification = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            var positiveButton = new Button()
            {
                Text = "Yes",
            };
            positiveButton.Clicked += (object sender, ClickedEventArgs e) => { window.GetDefaultNavigator().Pop(); };

            var negativeButton = new Button()
            {
                Text = "No",
            };
            negativeButton.Clicked += (object sender, ClickedEventArgs e) => { window.GetDefaultNavigator().Pop(); };

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                DialogPage.ShowAlertDialog("Title", "Message", positiveButton, negativeButton);
            };

            Content = button;
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
        }
    }

    class DialogPageTest1 : IExample
    {
        private Window window;

        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new DialogContentPage1(window));
        }

        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
