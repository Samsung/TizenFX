using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class SeamlessAnimation : TransitionAnimation
    {
        private Size DEFAULT_POPUP_SIZE = new Size(470, 600);

        private Window window;

        private Position DefaultIconPos;
        private Position DefaultAddIconPos;
        private Position DefaultMainPos;
        private Position DefaultSubPos;
        private Position DefaultMainViewPos;

        private ImageView imgView = null;
        private Animation transitionAnimation = null;
        private bool isForward = false;


        private UICreator uiCreator;

        public SeamlessAnimation(int durationMilliSeconds) : base(durationMilliSeconds)
        {
        }

        protected void TestAnimation()
        {
            DestroyImagView();
            ResetAnimation();
//            ResetImageView(frame.Image);

            isForward = true;
            if (isForward == true)
            {
                StoreInitDate();

                transitionAnimation.AnimateTo(uiCreator.AnimationView, "Size", new Size(window.Size), 50, 600);
                transitionAnimation.AnimateTo(uiCreator.AnimationView, "Position", new Position(0, 0), 50, 600);
                transitionAnimation.AnimateTo(imgView, "Size", new Size(window.Size), 200, 600);

                transitionAnimation.AnimateTo(uiCreator.IconView, "Position", new Position(0, 150), 0, 300);
                transitionAnimation.AnimateTo(uiCreator.AddView, "Position", new Position(30, 180), 0, 300);

                transitionAnimation.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.3f, 1.3f, 1.0f), 0, 300);
                transitionAnimation.AnimateTo(uiCreator.AddView, "Scale", new Vector3(0.7f, 0.7f, 1.0f), 0, 300);

                uiCreator.MainView.Hide();
                uiCreator.MainProfileText.Hide();
                uiCreator.SubProfileText.Hide();
            }
            else
            {
                transitionAnimation.AnimateTo(uiCreator.AnimationView, "Size", DEFAULT_POPUP_SIZE, 50, 600);
                transitionAnimation.AnimateTo(uiCreator.AnimationView, "Position", DefaultMainViewPos, 50, 600);
                transitionAnimation.AnimateTo(imgView, "Size", DEFAULT_POPUP_SIZE, 200, 600);

                transitionAnimation.AnimateTo(uiCreator.IconView, "Position", DefaultIconPos, 400, 600);
                transitionAnimation.AnimateTo(uiCreator.AddView, "Position", DefaultAddIconPos, 400, 600);

                transitionAnimation.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), 400, 600);
                transitionAnimation.AnimateTo(uiCreator.IconView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), 400, 600);

            }

            transitionAnimation.Finished += Ani_Finished;
            transitionAnimation.Play();
            //StartAnimation();
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
            DestroyImagView();
            if (!isForward)
            {
                uiCreator.MainView.Show();
                uiCreator.MainProfileText.Show();
                uiCreator.SubProfileText.Show();
            }
            return false;
        }

        private void ResetAnimation()
        {
            if (transitionAnimation != null)
            {
                transitionAnimation.Reset();
                transitionAnimation.Clear();
                transitionAnimation.Dispose();
                transitionAnimation = null;
            }
            transitionAnimation = new Animation(600);
            transitionAnimation.DefaultAlphaFunction = GetSineInOut80();
        }

        private void DestroyImagView()
        {
            if(imgView != null)
            {
                imgView.LowerToBottom();
                imgView.Hide();
                imgView.Unparent();
                imgView.Dispose();
                imgView = null;
            }
        }

        private void ResetImageView(ImageView imgFrame)
        {
            imgView = imgFrame;
            imgView.ParentOrigin = ParentOrigin.TopCenter;
            imgView.PivotPoint = PivotPoint.TopCenter;
            imgView.PositionUsesPivotPoint = true;
            imgView.CornerRadius = 50.0f;

            uiCreator.AnimationView.Add(imgView);
            imgView.LowerToBottom();
        }

        private void StoreInitDate()
        {
            DefaultIconPos = uiCreator.IconView.Position;
            DefaultAddIconPos = uiCreator.AddView.Position;
            DefaultMainPos = uiCreator.MainProfileText.Position;
            DefaultSubPos = uiCreator.SubProfileText.Position;
            DefaultMainViewPos = uiCreator.MainView.Position;

            imgView.Size = DEFAULT_POPUP_SIZE;
            uiCreator.AnimationView.Size = DEFAULT_POPUP_SIZE;
        }

        internal AlphaFunction GetSineInOut80()
        {
            return new AlphaFunction(new Vector2(0.45f, 0.43f), new Vector2(0.41f, 1.0f));
        }
    }
}
