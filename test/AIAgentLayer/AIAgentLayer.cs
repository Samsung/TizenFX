using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;

namespace AIAgentLayer
{
    class Program : NUIApplication
    {
        //Define RiveAnimation Variable as Member Variable
        Tizen.NUI.Extension.RiveAnimationView rav;

        //Control RiveAnimationState Buttons
        Button idleButton, okButton, listenButton;

        //Control Position Animation for RiveAnimationView
        Animation moveAnimation;
        AlphaFunction alphaFunction;
        Button moveTopButton, moveBottomButton, moveLeftButton, moveCenterButton, moveRightButton;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
            Destory();
        }

        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                //Reset to 0.0f Timeline
                rav.SetAnimationElapsedTime("ok", 0.0f);
                rav.SetAnimationElapsedTime("listen", 0.0f);
                //Disable ok and listen animations
                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("listen", false);
            }
            else if (e.Touch.GetState(0) == PointStateType.Motion)
            {
                //Disable ok and listen eplapsed time control
                rav.SetAnimationElapsedTime("ok", -1.0f);
                rav.SetAnimationElapsedTime("listen", -1.0f);

                //Calibrate Cursor Posiiton to Animation Time
                Vector2 pos = e.Touch.GetScreenPosition(0);
                double ravCenterX = rav.PositionX + (rav.Size.Width / 2);
                double ravCenterY = rav.PositionY + (rav.Size.Height / 2);

                double angle = Math.Atan2(pos.Y - ravCenterY, pos.X - ravCenterX) * (180.0f / Math.PI);
                angle += 180;
                angle -= 90;
                if (angle < 0)
                {
                    angle = 360.0f + angle;
                }

                double angleToTime = angle / 180.0f;

                //Control eye360 animation using cursor position
                rav.SetAnimationElapsedTime("eye360", (float)angleToTime);
            }
            else if (e.Touch.GetState(0) == PointStateType.Up)
            {
                //Disable eye360 eplapsed time control
                rav.SetAnimationElapsedTime("eye360", -1.0f);
                //Disable eye360 animation
                rav.EnableAnimation("eye360", false);
            }
        }

        void ResetMoveAnimation()
        {
            //Reset previous moving animation
            if (moveAnimation)
            {
                moveAnimation.Stop();
                moveAnimation.Dispose();

                moveAnimation = new Animation(600);
                alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine);
                moveAnimation.DefaultAlphaFunction = alphaFunction;
            }
        }

        void Initialize()
        {
            Window.Instance.WindowSize = new Size(1920, 1080);

            //Make Window Transparency
            Window.Instance.BackgroundColor = Color.Transparent;
            Window.Instance.SetTransparency(true);

            //Ignore Key Events for Receiving remote controller event
            Window.Instance.SetAcceptFocus(false);

            //Make Window Notification Level Top
            Window.Instance.SetNotificationLevel(NotificationLevel.Top);

            Window.Instance.TouchEvent += OnTouchEvent;

            //Create RiveAnimation
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "mini_a.riv")
            {
                Size = new Size(500, 500),
                Position = new Position( 750, 300)
            };

            //Enable RiveAnimation State
            rav.EnableAnimation("idle", true);

            //Play RiveAnimation
            rav.Play();

            //Initialize Move Animation for RiveAnimationView
            moveAnimation = new Animation(600);
            alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine);
            moveAnimation.DefaultAlphaFunction = alphaFunction;

            idleButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 100),
                Text = "idle"
            };
            idleButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Reset ok, listen and eye360 animations
                rav.SetAnimationElapsedTime("ok", 0.0f);
                rav.SetAnimationElapsedTime("listen", 0.0f);
                rav.SetAnimationElapsedTime("eye360", 0.0f);
                //Enable idle animation only
                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("listen", false);
                rav.EnableAnimation("eye360", false);
                rav.EnableAnimation("idle", true);
            };

            listenButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(210, 100),
                Text = "listen"
            };
            listenButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Reset ok and eye360 animations
                rav.SetAnimationElapsedTime("ok", 0.0f);
                rav.SetAnimationElapsedTime("eye360", 0.0f);
                //Enable listen animation only
                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("eye360", false);
                rav.EnableAnimation("listen", true);
            };

            okButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(420, 100),
                Text = "ok"
            };
            okButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Reset listen and eye360 animations
                rav.SetAnimationElapsedTime("listen", 0.0f);
                rav.SetAnimationElapsedTime("eye360", 0.0f);
                //Enable ok animation only
                rav.EnableAnimation("listen", false);
                rav.EnableAnimation("eye360", false);
                rav.EnableAnimation("ok", true);
            };

            moveTopButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(210, 220),
                Text = "Move Top"
            };
            moveTopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 750, 0 (Pivot is LeftTop of RiveAnimationView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(rav, "PositionX", 750);
                moveAnimation.AnimateTo(rav, "PositionY", 0);
                moveAnimation.Play();
            };

            moveBottomButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(210, 440),
                Text = "Move Bottom"
            };
            moveBottomButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 750, 600 (Pivot is LeftTop of RiveAnimationView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(rav, "PositionX", 750);
                moveAnimation.AnimateTo(rav, "PositionY", 600);
                moveAnimation.Play();
            };

            moveLeftButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 330),
                Text = "Move Left"
            };
            moveLeftButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 300, 300 (Pivot is LeftTop of RiveAnimationView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(rav, "PositionX", 300);
                moveAnimation.AnimateTo(rav, "PositionY", 300);
                moveAnimation.Play();
            };

            moveCenterButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(210, 330),
                Text = "Move Center"
            };
            moveCenterButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 750, 300 (Pivot is LeftTop of RiveAnimationView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(rav, "PositionX", 750);
                moveAnimation.AnimateTo(rav, "PositionY", 300);
                moveAnimation.Play();
            };

            moveRightButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(420, 330),
                Text = "Move Right"
            };
            moveRightButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 1400, 300 (Pivot is LeftTop of RiveAnimationView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(rav, "PositionX", 1400);
                moveAnimation.AnimateTo(rav, "PositionY", 300);
                moveAnimation.Play();
            };

            //Add RiveAnimationView and NUI Buttons to Main Window
            Window.Instance.GetDefaultLayer().Add(rav);
            Window.Instance.GetDefaultLayer().Add(idleButton);
            Window.Instance.GetDefaultLayer().Add(listenButton);
            Window.Instance.GetDefaultLayer().Add(okButton);
            Window.Instance.GetDefaultLayer().Add(moveTopButton);
            Window.Instance.GetDefaultLayer().Add(moveBottomButton);
            Window.Instance.GetDefaultLayer().Add(moveLeftButton);
            Window.Instance.GetDefaultLayer().Add(moveCenterButton);
            Window.Instance.GetDefaultLayer().Add(moveRightButton);
        }

        void Destory()
        {
            //Remove RiveAnimationView and NUI Buttons from Main Window
            Window.Instance.GetDefaultLayer().Remove(rav);
            Window.Instance.GetDefaultLayer().Remove(idleButton);
            Window.Instance.GetDefaultLayer().Remove(listenButton);
            Window.Instance.GetDefaultLayer().Remove(okButton);
            Window.Instance.GetDefaultLayer().Remove(moveTopButton);
            Window.Instance.GetDefaultLayer().Remove(moveBottomButton);
            Window.Instance.GetDefaultLayer().Remove(moveLeftButton);
            Window.Instance.GetDefaultLayer().Remove(moveCenterButton);
            Window.Instance.GetDefaultLayer().Remove(moveRightButton);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
