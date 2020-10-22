using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class SeamlessForwardAnimation : TransitionAnimation
    {
        private Size DEFAULT_POPUP_SIZE = new Size(470, 600);

        private Window window;

        private Position DefaultIconPos;
        private Position DefaultAddIconPos;
        private Position DefaultMainViewPos;

        private int durationMilliSeconds;
        private UICreator uiCreator;

        public SeamlessForwardAnimation(UICreator uiCreator, int durationMilliSeconds) : base(durationMilliSeconds)
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

            Properties[0] = "SizeWidth";
            DestValue[0] = Window.Instance.WindowSize.Width.ToString();

            Properties[1] = "SizeHeight";
            DestValue[1] = Window.Instance.WindowSize.Height.ToString();

            Properties[2] = "PositionX";
            DestValue[2] = "0";

            Properties[3] = "PositionY";
            DestValue[3] = "0";

            DefaultAlphaFunction = GetSineInOut80();

        }

        public void InitAnimation()
        {
            Animation ani = new Animation(durationMilliSeconds);
            ani.DefaultAlphaFunction = GetSineInOut80();

            StoreInitDate();
            uiCreator.MainView.Hide();
            //ani.AnimateTo(uiCreator.AnimationView, "Size", new Size(window.Size), 50, 600);
            ani.AnimateTo(uiCreator.AnimationView, "Position", new Position(0, 0), 50, 600);

            ani.AnimateTo(uiCreator.IconView, "Position", new Position(0, 150), 0, 300);
            ani.AnimateTo(uiCreator.AddView, "Position", new Position(30, 180), 0, 300);

            ani.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.3f, 1.3f, 1.0f), 0, 300);
            ani.AnimateTo(uiCreator.AddView, "Scale", new Vector3(0.7f, 0.7f, 1.0f), 0, 300);
            
            ani.Finished += Ani_Finished;
            ani.Play();
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            uiCreator.AnimationView.Position = DefaultMainViewPos;
            uiCreator.IconView.Position = DefaultIconPos;
            uiCreator.IconView.Scale = new Vector3(1.0f, 1.0f, 1.0f);
            uiCreator.AddView.Position = DefaultAddIconPos;
            uiCreator.AddView.Scale = new Vector3(1.0f, 1.0f, 1.0f);
            uiCreator.AnimationView.Size = new Size(470, 600);
            uiCreator.MainView.Show();
        }

        private void StoreInitDate()
        {
            DefaultIconPos = new Position(-160, 80); //uiCreator.IconView.Position;
            DefaultAddIconPos = new Position(160, 80); //uiCreator.AddView.Position;

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
