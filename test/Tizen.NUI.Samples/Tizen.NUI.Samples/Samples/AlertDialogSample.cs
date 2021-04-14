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

            oldPageCount = window.GetDefaultNavigator().NavigationPages.Count;

            var button = new Button()
            {
                Text = "Click to show AlertDialog",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                Navigator.ShowAlertDialog("Title", "Message",
                    "Yes", (object sender2, ClickedEventArgs e2) => { window.GetDefaultNavigator().Pop(); },
                    "No", (object sender2, ClickedEventArgs e2) => { window.GetDefaultNavigator().Pop(); });
            };

            var dialogPage = new ContentPage()
            {
                Content = button,
            };
            window.GetDefaultNavigator().Push(dialogPage);
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
