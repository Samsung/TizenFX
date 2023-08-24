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
        Button inButton, outButton, thinkingButton, okButton, listenButton;

        //Control Position Animation for RiveAnimationView
        Animation moveAnimation;
        AlphaFunction alphaFunction;
        Button topButton, bottomButton, leftButton, centerButton, rightButton;
        Button leftTopButton, rightTopButton, leftBottomButton, rightBottomButton;

        //In and Out Animation Timer
        Animation showAnimation;
        Animation inAnimation;
        Animation outAnimation;
        Animation resetEyeAnimation;
        Animation resetOkAnimation;
        Animation resetThinkingAnimation;
        Animation resetListenAnimation;

        void resetEyeFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("reset", -1.0f);
        }

        void resetOkFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("thinking", -1.0f);
            rav.SetAnimationElapsedTime("listen", -1.0f);
        }

        void resetThinkingFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("ok", -1.0f);
            rav.SetAnimationElapsedTime("listen", -1.0f);
        }

        void resetListenFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("ok", -1.0f);
            rav.SetAnimationElapsedTime("thinking", -1.0f);
        }

        void moveAnimationFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("reset", 0.0f);
            rav.SetAnimationElapsedTime("eye 360", -1.0f);

            if (resetEyeAnimation)
            {
                resetEyeAnimation.Stop();
            }
            else
            {
                resetEyeAnimation = new Animation(100);
                resetEyeAnimation.Finished += resetEyeFinished;
            }
            resetEyeAnimation.Play();
        }

        void showAnimationFinished(object sender, EventArgs e)
        {
            if (inAnimation)
            {
                inAnimation.Stop();
            }
            rav.SetAnimationElapsedTime("reset", -1.0f);
            rav.SetAnimationElapsedTime("eye 360", -1.0f);
            rav.SetAnimationElapsedTime("out", 0.0f);

            rav.SetAnimationElapsedTime("thinking", 0.0f);
            rav.SetAnimationElapsedTime("listen", 0.0f);
            rav.SetAnimationElapsedTime("ok", 0.0f);
            rav.EnableAnimation("thinking", false);
            rav.EnableAnimation("listen", false);
            rav.EnableAnimation("ok", false);

            rav.EnableAnimation("out", false);
            rav.EnableAnimation("in", true);

            inAnimation.Play();
        }

        void inAnimationFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("reset", -1.0f);
            rav.SetAnimationElapsedTime("eye 360", -1.0f);
            rav.SetAnimationElapsedTime("out", -1.0f);
            rav.EnableAnimation("in", false);
            rav.EnableAnimation("idle", true);
        }

        void outAnimationFinished(object sender, EventArgs e)
        {
            rav.SetAnimationElapsedTime("reset", 0.0f);
            rav.SetAnimationElapsedTime("eye 360", -1.0f);
            rav.SetAnimationElapsedTime("out", -1.0f);
            rav.EnableAnimation("out", false);
            rav.EnableAnimation("idle", false);
            rav.Stop();
        }
        void InitializeTimer()
        {
            showAnimation = new Animation(100);
            showAnimation.Finished += showAnimationFinished;
            inAnimation = new Animation(1100);
            inAnimation.Finished += inAnimationFinished;
            outAnimation = new Animation(900);
            outAnimation.Finished += outAnimationFinished;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            InitializeTimer();
            Initialize();
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
            Destory();
        }
        
        private double CalculateEyeAngle(Vector2 targetPos)
        {
            double ravCenterX = rav.PositionX + (rav.Size.Width / 2);
            double ravCenterY = rav.PositionY + (rav.Size.Height / 2);

            double angle = Math.Atan2(targetPos.Y - ravCenterY, targetPos.X - ravCenterX) * (180.0f / Math.PI);
            angle += 180.0f;
            if (angle < 0.0f)
            {
                angle = 360.0f + angle;
            }

            double angleToTime = angle / 180.0f;
            return angleToTime;
        }

        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Motion)
            {
                //Calibrate Cursor Posiiton to Animation Time
                Vector2 pos = e.Touch.GetScreenPosition(0);
                double angleToTime = CalculateEyeAngle(pos);

                //Control eye 360 animation using cursor position
                rav.SetAnimationElapsedTime("reset", -1.0f);
                rav.SetAnimationElapsedTime("eye 360", (float)angleToTime);
            }
        }

        void ResetMoveAnimation()
        {
            //Reset previous moving animation
            if (moveAnimation)
            {
                moveAnimation.Stop();
                moveAnimation.Dispose();
            }

            moveAnimation = new Animation(800);
            var c1 = new Vector2(0.5f, 0.0f);
            var c2 = new Vector2(0.5f, 1.0f);

            alphaFunction = new AlphaFunction(c1, c2);
            moveAnimation.DefaultAlphaFunction = alphaFunction;
            moveAnimation.Finished += moveAnimationFinished;
        }

        void ApplyMoveAnimation(int X, int Y)
        {
            ResetMoveAnimation();
            Vector2 pos = new Vector2(X, Y);
            double angleToTime = CalculateEyeAngle(pos);
            rav.SetAnimationElapsedTime("reset", -1.0f);
            rav.SetAnimationElapsedTime("eye 360", (float)angleToTime);

            moveAnimation.AnimateTo(rav, "PositionX", pos.X);
            moveAnimation.AnimateTo(rav, "PositionY", pos.Y);
            moveAnimation.Play();
        }

        void Initialize()
        {
            Window.Instance.WindowSize = new Size(1920, 1080);

            //Make Window Transparency
            Window.Instance.BackgroundColor = Color.Transparent;
            Window.Instance.SetTransparency(true);

            //Ignore Key Events for Receiving remote controller event
            Window.Instance.SetAcceptFocus(false);

            //Set Window Notification Type
            Window.Instance.Type = WindowType.Notification;

            //Make Window Notification Level Top
            Window.Instance.SetNotificationLevel(NotificationLevel.Top);

            Window.Instance.TouchEvent += OnTouchEvent;

            //Create RiveAnimation
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "mini_a.riv")
            {
                Size = new Size(250, 250),
                Position = new Position( 750, 300)
            };

            //Enable In Animation
            rav.EnableAnimation("in", true);

            //Play RiveAnimation 
            rav.Play();
            inAnimation.Play();

            inButton = new Button()
            {
                Size = new Size(120, 100),
                Position = new Position(10, 10),
                Text = "in"
            };
            inButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (showAnimation)
                {
                    showAnimation.Stop();
                }
                rav.Play();
                showAnimation.Play();
            };

            outButton = new Button()
            {
                Size = new Size(120, 100),
                Position = new Position(140, 10),
                Text = "out"
            };
            outButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (outAnimation)
                {
                    outAnimation.Stop();
                }
                rav.EnableAnimation("in", false);
                rav.EnableAnimation("out", true);
                outAnimation.Play();
            };

            okButton = new Button()
            {
                Size = new Size(120, 100),
                Position = new Position(10, 120),
                Text = "ok"
            };
            okButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetAnimationElapsedTime("reset", -1.0f);
                rav.SetAnimationElapsedTime("eye 360", -1.0f);
                //Enable ok animation only
                rav.SetAnimationElapsedTime("thinking", 0.0f);
                rav.SetAnimationElapsedTime("listen", 0.0f);

                if (resetOkAnimation)
                {
                    resetOkAnimation.Stop();
                }
                else
                {
                    resetOkAnimation = new Animation(100);
                    resetOkAnimation.Finished += resetOkFinished;
                }
                resetOkAnimation.Play();

                rav.EnableAnimation("thinking", false);
                rav.EnableAnimation("listen", false);
                rav.EnableAnimation("ok", true);
            };

            listenButton = new Button()
            {
                Size = new Size(120, 100),
                Position = new Position(140, 120),
                Text = "listen"
            };
            listenButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetAnimationElapsedTime("reset", -1.0f);
                rav.SetAnimationElapsedTime("eye 360", -1.0f);
                //Enable listen animation only
                rav.SetAnimationElapsedTime("ok", 0.0f);
                rav.SetAnimationElapsedTime("thinking", 0.0f);

                if (resetListenAnimation)
                {
                    resetListenAnimation.Stop();
                }
                else
                {
                    resetListenAnimation = new Animation(100);
                    resetListenAnimation.Finished += resetListenFinished;
                }
                resetListenAnimation.Play();

                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("thinking", false);
                rav.EnableAnimation("listen", true);
            };

            thinkingButton = new Button()
            {
                Size = new Size(120, 100),
                Position = new Position(270, 120),
                Text = "thinking"
            };
            thinkingButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetAnimationElapsedTime("reset", -1.0f);
                rav.SetAnimationElapsedTime("eye 360", -1.0f);
                //Enable ok animation only
                rav.SetAnimationElapsedTime("ok", 0.0f);
                rav.SetAnimationElapsedTime("listen", 0.0f);

                if (resetThinkingAnimation)
                {
                    resetThinkingAnimation.Stop();
                }
                else
                {
                    resetThinkingAnimation = new Animation(100);
                    resetThinkingAnimation.Finished += resetThinkingFinished;
                }
                resetThinkingAnimation.Play();

                rav.EnableAnimation("ok", false);
                rav.EnableAnimation("listen", false);
                rav.EnableAnimation("thinking", true);
            };

            topButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(180, 250),
                Text = "Move Top"
            };
            topButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(750, 0);
            };

            bottomButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(180, 470),
                Text = "Move Bottom"
            };
            bottomButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(750, 600);
            };

            leftButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(10, 360),
                Text = "Move Left"
            };
            leftButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(300, 300);
            };

            centerButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(180, 360),
                Text = "Move Center"
            };
            centerButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(750, 300);
            };

            rightButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(350, 360),
                Text = "Move Right"
            };
            rightButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(1400, 300);
            };

            leftTopButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(10, 250),
                Text = "Left Top"
            };
            leftTopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(300, 0);
            };

            rightTopButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(350, 250),
                Text = "Move Right"
            };
            rightTopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(1400, 0);
            };

            leftBottomButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(10, 470),
                Text = "Move Right"
            };
            leftBottomButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(300, 750);
            };

            rightBottomButton = new Button()
            {
                Size = new Size(160, 100),
                Position = new Position(350, 470),
                Text = "Move Right"
            };
            rightBottomButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                ApplyMoveAnimation(1400, 750);
            };

            //Add RiveAnimationView and NUI Buttons to Main Window
            Window.Instance.GetDefaultLayer().Add(rav);
            Window.Instance.GetDefaultLayer().Add(inButton);
            Window.Instance.GetDefaultLayer().Add(outButton);
            Window.Instance.GetDefaultLayer().Add(thinkingButton);
            Window.Instance.GetDefaultLayer().Add(listenButton);
            Window.Instance.GetDefaultLayer().Add(okButton);
            Window.Instance.GetDefaultLayer().Add(topButton);
            Window.Instance.GetDefaultLayer().Add(bottomButton);
            Window.Instance.GetDefaultLayer().Add(leftButton);
            Window.Instance.GetDefaultLayer().Add(centerButton);
            Window.Instance.GetDefaultLayer().Add(rightButton);
            Window.Instance.GetDefaultLayer().Add(leftTopButton);
            Window.Instance.GetDefaultLayer().Add(rightTopButton);
            Window.Instance.GetDefaultLayer().Add(leftBottomButton);
            Window.Instance.GetDefaultLayer().Add(rightBottomButton);
        }

        void Destory()
        {
            //Remove RiveAnimationView and NUI Buttons from Main Window
            Window.Instance.GetDefaultLayer().Remove(rav);
            Window.Instance.GetDefaultLayer().Remove(inButton);
            Window.Instance.GetDefaultLayer().Remove(outButton);
            Window.Instance.GetDefaultLayer().Remove(thinkingButton);
            Window.Instance.GetDefaultLayer().Remove(listenButton);
            Window.Instance.GetDefaultLayer().Remove(okButton);
            Window.Instance.GetDefaultLayer().Remove(topButton);
            Window.Instance.GetDefaultLayer().Remove(bottomButton);
            Window.Instance.GetDefaultLayer().Remove(leftButton);
            Window.Instance.GetDefaultLayer().Remove(centerButton);
            Window.Instance.GetDefaultLayer().Remove(rightButton);
            Window.Instance.GetDefaultLayer().Remove(leftTopButton);
            Window.Instance.GetDefaultLayer().Remove(rightTopButton);
            Window.Instance.GetDefaultLayer().Remove(leftBottomButton);
            Window.Instance.GetDefaultLayer().Remove(rightBottomButton);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
