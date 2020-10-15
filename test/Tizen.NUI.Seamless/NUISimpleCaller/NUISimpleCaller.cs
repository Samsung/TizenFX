using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;

namespace NUISimpleCaller
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

            TextLabel text = new TextLabel("NUI Simple Caller Sample");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);


            TransitionOptions = new TransitionOptions(GetDefaultWindow());
            TransitionOptions.EnableTransition = true;
            TransitionOptions.ForwardAnimation = new SlideIn(300);
            TransitionOptions.BackwardAnimation = new SlideOut(300);

            ////TransitionOptions.AnimationStart += TransitionOptions_AnimationStart;
            ////TransitionOptions.AnimationFinished += TransitionOptions_AnimationFinished;
        }

        private void TransitionOptions_AnimationFinished()
        {
            Tizen.Log.Error("MYLOG", "Finish Animation");
        }

        private void TransitionOptions_AnimationStart()
        {
            Tizen.Log.Error("MYLOG", "Start Animation");
        }

        private void OnTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                AppControl appControl = new AppControl();
                appControl.ApplicationId = "org.tizen.example.NUISimpleCallee";
                SendLaunchRequest(appControl);
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
