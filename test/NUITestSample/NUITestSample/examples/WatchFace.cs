using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace WatchSample
{
    class Program : NUIWatchApplication
    {
        private TextLabel text;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        protected override void OnTimeTick(TimeTickEventArgs e)
        {
            base.OnTimeTick(e);
            text.Text = "Hello NUI Watch \n" + e.WatchTime.Hour + ":" + e.WatchTime.Minute + ":" + e.WatchTime.Second + ":" + e.WatchTime.Millisecond;
            Tizen.Log.Error("NUI", "TimeTick " + e.WatchTime.TimeZone + "(" + e.WatchTime.DaylightSavingTimeStatus + ") | " + e.WatchTime.Year + "/" + e.WatchTime.Month + "/" + e.WatchTime.Day + "(" + e.WatchTime.DayOfWeek + ")  " + e.WatchTime.Hour + "(" + e.WatchTime.Hour24 + "):" + e.WatchTime.Minute + ":" + e.WatchTime.Second + ":" + e.WatchTime.Millisecond + "\n");
        }

        protected override void OnAmbientTick(AmbientTickEventArgs e)
        {
            base.OnAmbientTick(e);
            Tizen.Log.Error("NUI", "AmbientTick " + e.WatchTime.TimeZone + "(" + e.WatchTime.DaylightSavingTimeStatus + ") | " + e.WatchTime.Year + "/" + e.WatchTime.Month + "/" + e.WatchTime.Day + "(" + e.WatchTime.DayOfWeek + ")  " + e.WatchTime.Hour + "(" + e.WatchTime.Hour24 + "):" + e.WatchTime.Minute + ":" + e.WatchTime.Second + ":" + e.WatchTime.Millisecond + "\n");
        }

        protected override void OnAmbientChanged(AmbientChangedEventArgs e)
        {
            base.OnAmbientChanged(e);
            Tizen.Log.Error("NUI", "AmbientChanged " + e.Changed + "\n");
        }

        void Initialize()
        {
            Window window = this.Window;
            window.KeyEvent += OnKeyEvent;

            text = new TextLabel("Hello Tizen NUI World");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.White;
            text.PointSize = 10.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            text.MultiLine = true;
            window.GetDefaultLayer().Add(text);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void _Main(string[] args)
        {
            Tizen.Log.Error("NUI", "App Start....\n");
            var app = new Program();
            app.Run(args);
        }
    }
}
