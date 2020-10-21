using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class Program : NUIApplication
    {
        private UICreator uiCreator;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f);

            uiCreator = new UICreator(this);
            uiCreator.CreateUI();

            TransitionOptions = new TransitionOptions(GetDefaultWindow());
            TransitionOptions.EnableTransition = true;
            TransitionOptions.ForwardAnimation = new SlideIn(1300);
            TransitionOptions.BackwardAnimation = new SlideOut(1300);

            //(launchBroker as SeamlessAnimator)?.SetUICreator(uiCreator);
        }


        protected override void OnPause()
        {
            base.OnPause();
        }


        public static string GetResourcePath()
        {
            return Tizen.Applications.Application.Current.DirectoryInfo.Resource;
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
            new Program().Run(args);
        }
    }
}
