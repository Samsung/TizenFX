using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUISimpleCallee
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.TouchEvent += OnTouchEvent;
            Window.Instance.BackgroundColor = Color.Yellow;

            TextLabel text = new TextLabel("Callee");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Red;
            text.PointSize = 25.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);

            TransitionOptions = new TransitionOptions(GetDefaultWindow());
            TransitionOptions.EnableTransition = true;

            TransitionOptions.CallerScreenShown += TransitionOptions_CallerScreenShown;
            TransitionOptions.CallerScreenHidden += TransitionOptions_CallerScreenHidden;
        }

        private void TransitionOptions_CallerScreenShown(object sender, EventArgs e)
        {
            Tizen.Log.Error("MYLOG", "Shown");
        }

        private void TransitionOptions_CallerScreenHidden(object sender, EventArgs e)
        {
            Tizen.Log.Error("MYLOG", "Hidden");
        }

        private void OnTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                //Window.Instance.Hide();
                Exit();
            }
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
            var app = new Program();
            app.Run(args);
        }
    }
}
