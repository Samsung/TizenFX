
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace UIThreadApp
{
    public class AppCoreTask : CoreTask
    {
        public override void OnCreate()
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnCreate");
        }

        public override void OnTerminate()
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnTerminate");
        }

        public override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnAppControlReceived " + e.ReceivedAppControl.ApplicationId);
        }

        public override void OnLowMemory(LowMemoryEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnLowMemory " + e.LowMemoryStatus);
        }

        public override void OnLowBattery(LowBatteryEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnCreate " + e.LowBatteryStatus);
        }

        public override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnLocaleChanged " + e.Locale);
        }

        public override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnRegionFormatChanged " + e.Region);
        }

        public override void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "CoreTask OnDeviceOrientationChanged " + e.DeviceOrientation);
        }
    }

    class Program : NUIApplication
    {
        private View root;
        private Control control;

        public Program(string styleSheet, WindowMode windowMode, CoreTask task) : base(styleSheet, windowMode, task)
        {
        }

        protected override void OnCreate()
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnCreate");
            base.OnCreate();
            Initialize();
        }

        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnLocaleChanged " + e.Locale);
        }

        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnLowBattery " + e.LowBatteryStatus);
        }

        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnLowMemory " + e.LowMemoryStatus);
        }

        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnRegionFormatChanged " + e.Region);
        }

        protected override void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnDeviceOrientationChanged " + e.DeviceOrientation);
        }

        protected override void OnTerminate()
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnTerminate");
        }

        protected override void OnPause()
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnPause");
        }

        protected override void OnResume()
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnResume");
        }

        protected override void OnPreCreate()
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnPreCreate");
        }

        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Tizen.Log.Info("UIThreadApp", "NUIApplication OnAppControlReceived " + e.ReceivedAppControl.ApplicationId);
        }

        void Initialize()
        {

            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = window.Size,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 0.6f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            control = new Control()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BoxShadow = new Shadow(0, new Color(0.2f, 0.2f, 0.2f, 0.3f), new Vector2(5, 5)),
                CornerRadius = 0.5f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
            };

            root.Add(control);

            var animation = new Animation(2000);
            animation.AnimateTo(control, "SizeWidth", 200, 0, 1000);
            animation.AnimateTo(control, "SizeWidth", 100, 1000, 2000);
            animation.Looping = true;
            animation.Play();

            NUIApplication.GetDefaultWindow().KeyEvent += OnKeyEvent;
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program("", NUIApplication.WindowMode.Opaque, new AppCoreTask());
            app.Run(args);
        }
    }
}
