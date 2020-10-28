using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Constants;

namespace TimerTest
{
    // An example of Visual View control.
    class Example : NUIApplication
    {
        private static int i = 0;

        public Example() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextLabel label = new TextLabel()
            {
                Text = "Steps: 0",
                Size2D = new Size2D(460, 80),
                Position2D = new Position2D(10, 10)
            };

            RadioButton radio1 = new RadioButton()
            {
                LabelText = "Set interval 500",
                Size2D = new Size2D(300, 50),
                Position2D = new Position2D(10, 100),
            };
            RadioButton radio2 = new RadioButton()
            {
                LabelText = "Set interval 1000",
                Size2D = new Size2D(300, 50),
                Position2D = new Position2D(10, 160),
                Selected = true
            };
            RadioButton radio3 = new RadioButton()
            {
                LabelText = "Set interval 3000",
                Size2D = new Size2D(300, 50),
                Position2D = new Position2D(10, 220),
            };

            PushButton button1 = new PushButton()
            {
                LabelText = "Start",
                Size2D = new Size2D(100, 50),
                Position2D = new Position2D(10, 300),
                Focusable = true
            };

            PushButton button2 = new PushButton()
            {
                LabelText = "Stop",
                Size2D = new Size2D(100, 50),
                Position2D = new Position2D(140, 300),
                Focusable = true
            };

            window.Add(label);
            window.Add(radio1);
            window.Add(radio2);
            window.Add(radio3);
            window.Add(button1);
            window.Add(button2);

            FocusManager.Instance.SetCurrentFocusView(button1);
            button1.LeftFocusableView = button1.RightFocusableView = button2;
            button2.RightFocusableView = button2.LeftFocusableView = button1;
            button1.UpFocusableView = button2.UpFocusableView = radio3;
            radio3.UpFocusableView = radio2;
            radio2.UpFocusableView = radio1;
            radio1.DownFocusableView = radio2;
            radio2.DownFocusableView = radio3;
            radio3.DownFocusableView = button1;

            Timer timer = new Timer(1000);
            timer.Tick += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "NUI Timer tick called!");
                label.Text = "Steps: " + (i++);
                return true;
            };

            button1.Clicked += (obj, e) =>
            {
                if (radio1.Selected == true) timer.Interval = 500;
                if (radio2.Selected == true) timer.Interval = 1000;
                if (radio3.Selected == true) timer.Interval = 3000;
                timer.Start();
                return true;
            };
            button2.Clicked += (obj, e) =>
            {
                timer.Stop();
                return true;
            };
        }
    }
}
