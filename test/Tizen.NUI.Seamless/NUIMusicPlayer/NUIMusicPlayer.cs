using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIMusicPlayer
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
            uiCreator = new UICreator();
            uiCreator.CreateUI(); 
            
            TransitionOptions = new TransitionOptions(GetDefaultWindow());
            TransitionOptions.EnableTransition = true;

        }

        protected void OnResumed()
        {
            base.OnResume();
            uiCreator.ShowObjects();
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                uiCreator.HideObjects();
                //Window.Instance.SetIconified(true);
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
