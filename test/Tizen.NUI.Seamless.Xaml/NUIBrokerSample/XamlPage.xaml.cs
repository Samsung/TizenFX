using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    public partial class XamlPage : View
    {
        private const int TOUCH_AREA = 5;
        private const string TARGET_APPLICATION = "org.tizen.example.NUIMusicPlayer";
        private const string EMART_APPLICATION = "org.tizen.example.ScrollingTransition";

        private NUIApplication application;
        private Animation startAni;

        private Position downPosition = new Position(0, 0);
        private Position movePosition = new Position(0, 0);
        public XamlPage(NUIApplication application)
        {
            this.application = application;
            InitializeComponent();
        }

        private bool OnViewTouchEvent2(object source, TouchEventArgs e)
        {
            PointStateType type = e.Touch.GetState(0);
            Vector2 vector = e.Touch.GetScreenPosition(0);
            switch (type)
            {
                case PointStateType.Down:
                    downPosition = movePosition = new Position(vector);
                    PlayScaleDownAnimation(mainView);
                    PlayScaleDownAnimation(source as View);
                    break;
                case PointStateType.Motion:
                    var currentPosition = new Position(vector);
                    MoveMainScreen(new Position(mainViewModel.MainPosition) + (currentPosition - movePosition));
                    movePosition = currentPosition;
                    break;
                case PointStateType.Up:
                    if (isTouchArea(AbsPosition(new Position(vector) - downPosition)))
                    {
                        LaunchApplication(TARGET_APPLICATION);
                    }

                    PlayScaleUpAnimation(mainView);
                    PlayScaleUpAnimation(source as View);
                    break;
            }
            return false;
        }

        private void LaunchApplication(string opr)
        {
            AppControl appControl = new AppControl();
            appControl.ApplicationId = opr;
            application.SendLaunchRequest(appControl);
        }

        private Position AbsPosition(Position2D position)
        {
            return new Position(Math.Abs(position.X), Math.Abs(position.Y));
        }

        private bool isTouchArea(Position2D position)
        {
            return (position.X < TOUCH_AREA && position.Y < TOUCH_AREA);
        }

        private void MoveMainScreen(Position position)
        {
            mainViewModel.MainPosition = position;
        }

        private void PlayScaleDownAnimation(View view)
        {
            //ClearAnimation();
            Animation startAni = new Animation(150);
            startAni.AnimateTo(view, "Scale", new Vector3(0.9f, 0.9f, 1.0f));
            startAni.Play();
        }

        private void PlayScaleUpAnimation(View view)
        {
            //ClearAnimation();
            Animation startAni = new Animation(150);
            startAni.AnimateTo(view, "Scale", new Vector3(1.0f, 1.0f, 1.0f));
            startAni.Play();
        }

        private void ClearAnimation()
        {
            if (startAni != null)
            {
                startAni.Stop();
                startAni.Clear();
                startAni.Dispose();
                startAni = null;
            }
        }

    }
}
