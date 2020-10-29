using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class Program : NUIApplication
    {
        private UICreator uiCreator;
        private SeamlessForwardAnimation fAnimation;
        private SeamlessBackwardAnimation bAnimation;

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

            fAnimation = new SeamlessForwardAnimation(uiCreator, 600);
            bAnimation = new SeamlessBackwardAnimation(uiCreator, 600);
            TransitionOptions.ForwardAnimation = fAnimation;
            //TransitionOptions.BackwardAnimation = bAnimation;

            TransitionOptions.AnimationInitialized += TransitionOptions_AnimationInitialized;
            //(launchBroker as SeamlessAnimator)?.SetUICreator(uiCreator);
        }

        private void TransitionOptions_AnimationInitialized(object sender, EventArgs e)
        {
            fAnimation.InitAnimation();
            //bAnimation.InitAnimation();
        }

        protected override void OnResume()
        {
            base.OnResume();
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
