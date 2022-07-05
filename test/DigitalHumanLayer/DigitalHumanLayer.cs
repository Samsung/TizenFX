using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace DigitalHumanLayer
{
    class Program : NUIApplication
    {
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";
        private static string[] runtimeArgs = { "org.tizen.example.DigitalHumanLayer", "--enable-dali-window", "--enable-spatial-navigation" };

        //Define WebView Variable as Member Variable
        WebView webView;

        //Control Position Animation for WebView
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

            //Set Window Notification Type
            Window.Instance.Type = WindowType.Notification;

            //Make Window Notification Level Top
            Window.Instance.SetNotificationLevel(NotificationLevel.Top);

            //Create NUI WebView
            webView = new WebView(runtimeArgs)
            {
                Size = new Size(500, 500),
                Position = new Position(750, 300),
                UserAgent = USER_AGENT,
                Focusable = true,
                VideoHoleEnabled = true,
            };

            webView.LoadUrl("https://www.youtube.com");

            //Initialize Move Animation for WebView
            moveAnimation = new Animation(600);
            alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);
            moveAnimation.DefaultAlphaFunction = alphaFunction;

            moveTopButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(210, 220),
                Text = "Move Bottom"
            };
            moveTopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                //Move Position 750, 0 (Pivot is LeftTop of WebView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(webView, "PositionX", 750);
                moveAnimation.AnimateTo(webView, "PositionY", 0);
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
                //Move Position 750, 600 (Pivot is LeftTop of WebView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(webView, "PositionX", 750);
                moveAnimation.AnimateTo(webView, "PositionY", 600);
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
                //Move Position 300, 300 (Pivot is LeftTop of WebView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(webView, "PositionX", 300);
                moveAnimation.AnimateTo(webView, "PositionY", 300);
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
                //Move Position 750, 300 (Pivot is LeftTop of WebView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(webView, "PositionX", 750);
                moveAnimation.AnimateTo(webView, "PositionY", 300);
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
                //Move Position 1400, 300 (Pivot is LeftTop of WebView)
                ResetMoveAnimation();
                moveAnimation.AnimateTo(webView, "PositionX", 1400);
                moveAnimation.AnimateTo(webView, "PositionY", 300);
                moveAnimation.Play();
            };

            //Add WebView and NUI Buttons to Main Window
            Window.Instance.GetDefaultLayer().Add(moveTopButton);
            Window.Instance.GetDefaultLayer().Add(moveBottomButton);
            Window.Instance.GetDefaultLayer().Add(moveLeftButton);
            Window.Instance.GetDefaultLayer().Add(moveCenterButton);
            Window.Instance.GetDefaultLayer().Add(moveRightButton);
            Window.Instance.GetDefaultLayer().Add(webView);
        }

        void Destory()
        {
            //Remove WebView and NUI Buttons from Main Window
            Window.Instance.GetDefaultLayer().Remove(moveTopButton);
            Window.Instance.GetDefaultLayer().Remove(moveBottomButton);
            Window.Instance.GetDefaultLayer().Remove(moveLeftButton);
            Window.Instance.GetDefaultLayer().Remove(moveCenterButton);
            Window.Instance.GetDefaultLayer().Remove(moveRightButton);
            Window.Instance.GetDefaultLayer().Remove(webView);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
