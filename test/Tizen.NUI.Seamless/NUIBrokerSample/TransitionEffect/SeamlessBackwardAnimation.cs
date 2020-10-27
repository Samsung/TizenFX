using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class SeamlessBackwardAnimation : TransitionAnimation
    {
        private Size DEFAULT_POPUP_SIZE = new Size(470, 600);

        private Window window;

        private Position DefaultIconPos;
        private Position DefaultAddIconPos;
        private Position DefaultMainPos;
        private Position DefaultSubPos;
        private Position DefaultMainViewPos;
        
        private int durationMilliSeconds;
        private UICreator uiCreator;

        public SeamlessBackwardAnimation(UICreator uiCreator, int durationMilliSeconds) : base(durationMilliSeconds)
        {
            this.durationMilliSeconds = durationMilliSeconds;
            window = Window.Instance;
            this.uiCreator = uiCreator;

            int propertyCount = 4;
            Properties = new string[propertyCount];
            DestValue = new string[propertyCount];
            StartTime = new int[propertyCount];
            EndTime = new int[propertyCount];
            for (int i = 0; i < propertyCount; i++)
            {
                StartTime[i] = 200;
                EndTime[i] = durationMilliSeconds;
            }

            DefaultAlphaFunction = GetSineInOut80();

        }
        private void SetupAnimationData()
        {
            Properties[0] = "SizeWidth";
            DestValue[0] = DEFAULT_POPUP_SIZE.Width.ToString();

            Properties[1] = "SizeHeight";
            DestValue[1] = DEFAULT_POPUP_SIZE.Height.ToString();

            Properties[2] = "PositionX";
            DestValue[2] = DefaultMainViewPos.X.ToString();

            Properties[3] = "PositionY";
            DestValue[3] = DefaultMainViewPos.Y.ToString();

        }

        public void InitAnimation()
        {
            Animation ani = new Animation(durationMilliSeconds);
            ani.DefaultAlphaFunction = GetSineInOut80();

            StoreInitDate();
            SetupAnimationData();

            this.AnimateTo(uiCreator.AnimationView, "Size", DEFAULT_POPUP_SIZE, 50, 600);
            this.AnimateTo(uiCreator.AnimationView, "Position", DefaultMainViewPos, 50, 600);
            //this.AnimateTo(imgView, "Size", DEFAULT_POPUP_SIZE, 200, 600);

            this.AnimateTo(uiCreator.IconView, "Position", DefaultIconPos, 400, 600);
            this.AnimateTo(uiCreator.AddView, "Position", DefaultAddIconPos, 400, 600);

            this.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), 400, 600);
            this.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), 400, 600);

            ani.Finished += Ani_Finished;
            ani.Play();
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            //FinishAnimation();
            Timer timer = new Timer(30);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            uiCreator.MainView.Show();
            uiCreator.MainProfileText.Show();
            uiCreator.SubProfileText.Show();
            return false;
        }

        private void StoreInitDate()
        {
            DefaultIconPos = uiCreator.IconView.Position;
            DefaultAddIconPos = uiCreator.AddView.Position;
            DefaultMainPos = uiCreator.MainProfileText.Position;
            DefaultSubPos = uiCreator.SubProfileText.Position;
            DefaultMainViewPos = uiCreator.MainView.Position;

            uiCreator.AnimationView.Size = DEFAULT_POPUP_SIZE;
        }

        internal AlphaFunction GetSineInOut80()
        {
            return new AlphaFunction(new Vector2(0.45f, 0.43f), new Vector2(0.41f, 1.0f));
        }

        
        public override Position GetDefaultPosition()
        {
            return DefaultMainViewPos;
        }

        public override Size GetDefaultSize()
        {
            return new Size(0, 0);
        }

        public override Position GetDefaultParentOrigin()
        {
            return ParentOrigin.TopCenter;
        }

        public override Position GetDefaultPivotPoint()
        {
            return PivotPoint.TopCenter;
        }

    }
}
