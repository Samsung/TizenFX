using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIBrokerSample
{
    public class Program : NUIApplication
    {
        private Window window;
        private View animationView;
        private ObjectAnimationManager objectAnimationManager;

        protected override void OnCreate()
        {
            base.OnCreate();
            window = GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;

            var xamlPage = CreateXamlPage();
            animationView = xamlPage.AnimationView;
            window.Add(xamlPage);

            EnableAppTransition(true);

            //Animating by default transition
            //EnableAppTransition(false);

            objectAnimationManager = new ObjectAnimationManager(xamlPage);
        }

        private XamlPage CreateXamlPage()
        {
            var page = new XamlPage(this);
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.TopLeft;
            page.PivotPoint = PivotPoint.TopLeft;
            page.BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f);
            page.Size = new Size(window.WindowSize.Width, window.WindowSize.Height, 0);

            return page;
        }

        private void EnableAppTransition(bool isCustomAnimation = true)
        {
            TransitionOptions = new TransitionOptions(window);
            TransitionOptions.AnimatedTarget = animationView;
            TransitionOptions.EnableTransition = true;

            if (isCustomAnimation)
            {
                //Set Custom Animation
                TransitionOptions.ForwardAnimation = new SeamlessForward(400);
                TransitionOptions.BackwardAnimation = new SeamlessBackward(400);
                TransitionOptions.AnimationInitialized += TransitionOptions_AnimationInitialized;
            }
            else
            {
                //Set Default Animation
                TransitionOptions.ForwardAnimation = new SlideIn(600);
                TransitionOptions.BackwardAnimation = new SlideOut(600);
            }

        }

        private void TransitionOptions_AnimationInitialized(bool direction)
        {
            objectAnimationManager.StartIconAnimationByDirection(direction);
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
