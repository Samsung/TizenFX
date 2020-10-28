
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace DisposeTest
{
    class Example : NUIApplication
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        protected override void OnCreate()
        {
            base.OnCreate();
            ImageDisposeTest();
            AddButtons();
            TimerDisposeTest();
            GcTest();
        }
        private ImageView image;
        private Timer timer;
        private bool flag;
        private Animation ani;
        private void ImageDisposeTest()
        {
            Layer layer = new Layer();
            layer.RaiseToTop();
            Window.Instance.AddLayer(layer);

            image = new ImageView();
            image.ResourceUrl = resourcePath + "/images/application-icon-0.png";
            image.Size2D = new Size2D(333, 333);
            image.ParentOrigin = ParentOrigin.Center;
            image.PivotPoint = PivotPoint.Center;
            image.PositionUsesPivotPoint = true;
            image.Position = new Position(0, 0, 0);
            layer.Add(image);

            timer = new Timer(1000);
            timer.Tick += Timer_Tick;
            timer.Start();

            ani = new Animation();
            ani.AnimateTo(image, "Scale", new Size(2.0f, 2.0f, 2.0f), 0, 3000);
            ani.AnimateTo(image, "Scale", new Size(1.0f, 1.0f, 1.0f), 3000, 6000);
            ani.Finished += Ani_Finished;
            ani.Play();
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            ////NUILog.Debug("scale animation finished! start again in Finshied callback!");
            ani.Play();
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            if (flag)
            {
                image.ResourceUrl = resourcePath + "/images/gallery-2.jpg";
                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.SVG));
                string url = $"{resourcePath}/images/gallery-2.jpg";
                //string url = $"{resourcePath}/3.svg";
                map.Add(ImageVisualProperty.URL, new PropertyValue(url));
                map.Add((int)Visual.Property.MixColor, new PropertyValue(new Color(0.7f, 0.0f, 0.0f, 1.0f)));
                //image.ImageMap = map;

                flag = false;
                ////NUILog.Debug("flag = false!");
            }
            else
            {
                image.ResourceUrl = resourcePath + "/images/test-image.png";
                flag = true;
                ////NUILog.Debug("flag = true!");
            }
            return true;
        }

        private Window window;
        private Layer layer;
        PushButton pushButton1, pushButton2;
        public void AddButtons()
        {
            //NUILog.Debug("Customized Application Initialize event handler");
            window = Window.Instance;
            window.BackgroundColor = Color.Magenta;
            window.TouchEvent += OnWindowTouched;
            window.WheelEvent += OnWindowWheelMoved;
            window.KeyEvent += OnWindowKeyPressed;
            //window.EventProcessingFinished += OnWindowEventProcessingFinished;

            layer = window.GetDefaultLayer();

            pushButton1 = new PushButton();
            pushButton1.ParentOrigin = ParentOrigin.BottomLeft;
            pushButton1.PivotPoint = PivotPoint.BottomLeft;
            pushButton1.PositionUsesPivotPoint = true;
            pushButton1.LabelText = "start animation";
            pushButton1.Position = new Vector3(0.0f, window.Size.Height * 0.1f, 0.0f);
            pushButton1.Clicked += OnPushButtonClicked1;
            window.Add(pushButton1);

            pushButton2 = new PushButton();
            pushButton2.ParentOrigin = ParentOrigin.BottomLeft;
            pushButton2.PivotPoint = PivotPoint.BottomLeft;
            pushButton2.PositionUsesPivotPoint = true;
            pushButton2.LabelText = "reload image with same URL";
            pushButton2.Position = new Vector3(0.0f, window.Size.Height * 0.2f, 0.0f);
            pushButton2.Clicked += OnPushButtonClicked2;
            window.Add(pushButton2);
        }

        public bool OnPushButtonClicked1(object sender, EventArgs e)
        {
            //NUILog.Debug("### push button 1 clicked!");
            return true;
        }

        public bool OnPushButtonClicked2(object sender, EventArgs e)
        {
            //NUILog.Debug("### push button 2 clicked!");
            return true;
        }

        public void OnWindowEventProcessingFinished(object sender, EventArgs e)
        {
            //NUILog.Debug("OnWindowEventProcessingFinished()!");
            if (e != null)
            {
                //NUILog.Debug("e != null !");
            }
        }

        public void OnWindowKeyPressed(object sender, Window.KeyEventArgs e)
        {
            //NUILog.Debug("OnWindowKeyEventOccured()!");
            //NUILog.Debug("keyPressedName=" + e.Key.KeyPressedName);
            //NUILog.Debug("state=" + e.Key.State);
        }

        public void OnWindowWheelMoved(object sender, Window.WheelEventArgs e)
        {
            //NUILog.Debug("OnWindowWheelEventOccured()!");
            //NUILog.Debug("direction=" + e.Wheel.Direction);
            //NUILog.Debug("type=" + e.Wheel.Type);
        }

        // Callback for window touched signal handling
        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            //NUILog.Debug("OnWindowTouched()! e.TouchData.GetState(0)=" + e.Touch.GetState(0));

            distest(null, null);
            //NUILog.Debug("### 3 timers are disposed!");
        }


        List<Timer> timerList;
        void TimerDisposeTest()
        {
            timerList = new List<Timer>();
            //NUILog.Debug("TimerDisposeTest()!");

            for (int i = 0; i < 3; i++)
            {
                Timer timer = new Timer(100);
                if (0 == i) timer.Tick += Timer_Tick0;
                if (1 == i) timer.Tick += Timer_Tick1;
                if (2 == i) timer.Tick += Timer_Tick2;
                timerList.Add(timer);
            }
            ////NUILog.Debug($"TimerDisposeTest() dp1 timerlist cnt={timerList.Count}");

            foreach (Timer timer in timerList)
            {
                timer.Start();
            }

            distest = new DisposeTest(Timer_Tick0);
        }

        private delegate bool DisposeTest(object source, Timer.TickEventArgs e);
        DisposeTest distest;

        private bool Timer_Tick0(object source, Timer.TickEventArgs e)
        {
            foreach (Timer timer in timerList)
            {
                timer?.Dispose();
            }
            timerList.Clear();
            ////NUILog.Debug("### Timer_Tick0=> 3 timers are disposed!");

            for (int i = 0; i < 100; i++)
            {
                Timer timer = new Timer(100);
                if (0 == i%3) timer.Tick += Timer_Tick0;
                if (1 == i%3) timer.Tick += Timer_Tick1;
                if (2 == i%3) timer.Tick += Timer_Tick2;
                timerList.Add(timer);
            }

            ////NUILog.Debug($"Timer_Tick0=> timerlist cnt={timerList.Count}");
            foreach (Timer timer in timerList)
            {
                timer.Start();
            }
            return true;
        }

        private bool Timer_Tick1(object source, Timer.TickEventArgs e)
        {
            foreach (Timer timer in timerList)
            {
                timer?.Dispose();
            }
            timerList.Clear();
            ////NUILog.Debug("### Timer_Tick1=> 3 timers are disposed!");

            for (int i = 0; i < 100; i++)
            {
                Timer timer = new Timer(100);
                if (0 == i % 3) timer.Tick += Timer_Tick0;
                if (1 == i % 3) timer.Tick += Timer_Tick1;
                if (2 == i % 3) timer.Tick += Timer_Tick2;
                timerList.Add(timer);
            }

            ////NUILog.Debug($"Timer_Tick1=> timerlist cnt={timerList.Count}");
            foreach (Timer timer in timerList)
            {
                timer.Start();
            }
            return true;
        }

        private bool Timer_Tick2(object source, Timer.TickEventArgs e)
        {
            foreach (Timer timer in timerList)
            {
                timer?.Dispose();
            }
            timerList.Clear();
            //NUILog.Debug("### Timer_Tick2=> 3 timers are disposed!");

            for (int i = 0; i < 100; i++)
            {
                Timer timer = new Timer(100);
                if (0 == i % 3) timer.Tick += Timer_Tick0;
                if (1 == i % 3) timer.Tick += Timer_Tick1;
                if (2 == i % 3) timer.Tick += Timer_Tick2;
                timerList.Add(timer);
            }

            //NUILog.Debug($"Timer_Tick2=> timerlist cnt={timerList.Count}");
            foreach (Timer timer in timerList)
            {
                timer.Start();
            }
            return true;
        }

        private Timer myTimer;
        private List<View> myViewList;
        private const int numberOfObjects = 999;
        private Random myRandom;

        void GcTest()
        {
            myViewList = new List<View>();
            myRandom = new Random();
            for (int i = 0; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            myTimer = new Timer(1000);

            myTimer.Tick += MyTimer_Tick;

            myTimer.Start();
        }

        private bool MyTimer_Tick(object source, System.EventArgs e)
        {
            //Remove current Scene,
            foreach (View v in myViewList)
            {
                Window.Instance.GetDefaultLayer().Remove(v);
            }

            myViewList.Clear();

            ////Add View

            GC.Collect();
            GC.WaitForPendingFinalizers();

            for (int i = 0; i < 50; i++)
            {
                TextLabel v = new TextLabel();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "label " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 50; i < 100; i++)
            {
                PushButton v = new PushButton();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.LabelText = "button " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 100; i < 150; i++)
            {
                ImageView v = new ImageView();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.ResourceUrl = resourcePath + "/images/gallery-3.jpg";

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 150; i < 200; i++)
            {
                //TextEditor v = new TextEditor();
                TextLabel v = new TextLabel("2");

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "editor" + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 200; i < 250; i++)
            {
                //TextField v = new TextField();
                TextLabel v = new TextLabel("1");

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "field " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 250; i < 300; i++)
            {
                CheckBoxButton v = new CheckBoxButton();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.LabelText = "check " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 300; i < 350; i++)
            {
                ScrollBar v = new ScrollBar();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 350; i < 400; i++)
            {
                Slider v = new Slider();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 400; i < 450; i++)
            {
                TableView v = new TableView(1, 1);

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 450; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            return true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            ////NUILog.Debug("Main() called!");

            Example example = new Example();
            example.Run(args);
        }
    }
}
