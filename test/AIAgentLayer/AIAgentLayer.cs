using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;

namespace AIAgentLayer
{
    class Program : NUIApplication
    {
        //Define RiveAnimation Variable as Member Variable
        Tizen.NUI.Extension.RiveAnimationView rav;
        Button idle, ok;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.WindowSize = new Size(900, 1080); 

            //Make Window Transparency
            Window.Instance.BackgroundColor = Color.Transparent;
            Window.SetTransparency(true);

            //Make Window Notification Level Top
            Window.SetNotificationLevel(NotificationLevel.Top);

            //Create RiveAnimation
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "mini_a.riv")
            {
                Size = new Size(500, 500),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            //Enable RiveAnimation State
            rav.EnableAnimation("idle", true);
            rav.SetAnimationElapsedTime("eye360", 0.7f);
            //Play RiveAnimation
            rav.Play();

            idle = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 100),
                Text = "listen"
            };
            idle.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetAnimationElapsedTime("ok", 0);
                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("listen", true);
            };

            ok = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 200),
                Text = "ok"
            };
            ok.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetAnimationElapsedTime("listen", 0);
                rav.EnableAnimation("listen", false);
                rav.EnableAnimation("ok", true);
            };

            //Add RiveAnimation to Main Window
            Window.Instance.GetDefaultLayer().Add(rav);
            Window.Instance.GetDefaultLayer().Add(ok);
            Window.Instance.GetDefaultLayer().Add(idle);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
