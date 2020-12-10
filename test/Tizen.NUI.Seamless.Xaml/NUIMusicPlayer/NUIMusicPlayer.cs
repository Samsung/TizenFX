using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIMusicPlayer
{
    public class Program : NUIApplication
    {
        private Window window;
        private XamlPage page;
        protected override void OnCreate()
        {
            base.OnCreate();
            window = GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;

            page = new XamlPage();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.TopLeft;
            page.PivotPoint = PivotPoint.TopLeft;
            page.BackgroundColor = Color.Black;
            page.Size = window.WindowSize;
            window.Add(page);

            TransitionOptions = new TransitionOptions(window);
            TransitionOptions.EnableTransition = true;
            TransitionOptions.CallerScreenHidden += TransitionOptions_CallerScreenHidden;
            TransitionOptions.CallerScreenShown += TransitionOptions_CallerScreenShown;
        }

        private void TransitionOptions_CallerScreenShown(object sender, EventArgs e)
        {
            page.ShowInitObject();
        }

        private void TransitionOptions_CallerScreenHidden(object sender, EventArgs e)
        {
            page.HideInitObject();
        }

        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            window.Activate();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                window.Lower();
                //window.Hide();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
