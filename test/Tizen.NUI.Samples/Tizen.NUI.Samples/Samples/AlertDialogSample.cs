using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class AlertDialogSample : IExample
    {
        private int oldPageCount = 0;

        public void Activate()
        {
            var window = NUIApplication.GetDefaultWindow();

            oldPageCount = window.GetDefaultNavigator().PageCount;

            var button = new Button()
            {
                Text = "Click to show AlertDialog",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
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

            var page = new ContentPage()
            {
                Content = button,
            };
            window.GetDefaultNavigator().Push(page);
        }

        public void Deactivate()
        {
            var window = NUIApplication.GetDefaultWindow();
            var newPageCount = window.GetDefaultNavigator().PageCount;

            for (int i = 0; i < (newPageCount - oldPageCount); i++)
            {
                window.GetDefaultNavigator().Pop();
            }
        }
    }
}
