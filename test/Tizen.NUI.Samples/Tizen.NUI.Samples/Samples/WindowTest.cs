
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class WindowTest : IExample
    {
        string tag = "NUITEST";
        Window mainWin;
        int screenWidth;
        int screenHeight;

        int addingInput;
        Timer tm;
        bool manualRotation;
        int rotationCount;

        private const string KEY_NUM_1 = "1";
        private const string KEY_NUM_2 = "2";
        private const string KEY_NUM_3 = "3";
        private const string KEY_NUM_4 = "4";
        private const string KEY_NUM_5 = "5";
        private const string KEY_NUM_6 = "6";
        private const string KEY_NUM_7 = "7";
        private const string KEY_NUM_8 = "8";
        private const string KEY_NUM_9 = "9";
        private const string KEY_NUM_0 = "0";


        void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.KeyEvent += OnKeyEvent;
            mainWin.TouchEvent += WinTouchEvent;
            mainWin.BackgroundColor = Color.Cyan;

            Information.TryGetValue<int>("http://tizen.org/feature/screen.width", out screenWidth);
            Information.TryGetValue<int>("http://tizen.org/feature/screen.height", out screenHeight);
            log.Fatal(tag, $"Initialize= screenWidth {screenWidth}, screenHeight {screenHeight} ");
            Rectangle inputRegion = new Rectangle(0,0,screenWidth,screenHeight/2);
            mainWin.IncludeInputRegion(inputRegion);

            addingInput = 0;

            TextLabel text = new TextLabel("NUI Window Test");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            mainWin.Add(text);

            List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();

            list.Add(Window.WindowOrientation.Landscape);
            list.Add(Window.WindowOrientation.LandscapeInverse);
            list.Add(Window.WindowOrientation.NoOrientationPreference);
            list.Add(Window.WindowOrientation.Portrait);
            list.Add(Window.WindowOrientation.PortraitInverse);

            mainWin.SetAvailableOrientations(list);

            Animation animation = new Animation(2000);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            animation.Looping = true;
            animation.Play();

            manualRotation = false;
            rotationCount = 0;

            tm = new Timer(100);
            tm.Tick += Tm_Tick;
            tm.Start();
        }

        private bool Tm_Tick(object source, Timer.TickEventArgs e)
        {
            bool rotating = mainWin.IsWindowRotating();
            log.Fatal(tag, $"window is Rotating: {rotating}");
            if(rotating && manualRotation)
            {
                rotationCount++;
                if(rotationCount > 100)
                {
                  log.Fatal(tag, $"call SendRotationCompletedAcknowledgement");
                  mainWin.SendRotationCompletedAcknowledgement();
                  rotationCount = 0;
                }
            }
            return true;
        }

        private void WinTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Vector2 touchpoint = e.Touch.GetScreenPosition(0);
                log.Fatal(tag, $"WinTouchEvent={touchpoint.X}, {touchpoint.Y}");
                int xPosition = 0;
                if(addingInput == 0)
                {
                    if(touchpoint.Y > (screenHeight/2 - 50))
                    {
                        int yPostion = screenHeight/2 + 1;
                        int height = screenHeight/2;
                        log.Fatal(tag, $"WinTouchEvent= Include {xPosition},{yPostion} {screenWidth}x{height} ");
                        mainWin.IncludeInputRegion(new Rectangle(xPosition,yPostion,screenWidth,height));
                        addingInput = 1;
                    }
                }
                else
                {
                    if(touchpoint.Y > (screenHeight - 50))
                    {
                        int yPostion = screenHeight/2 + 1;
                        int height = screenHeight/2;
                        log.Fatal(tag, $"WinTouchEvent= Exclude {xPosition},{yPostion} {screenWidth}x{height} ");
                        mainWin.ExcludeInputRegion(new Rectangle(xPosition, yPostion, screenWidth, height));
                        addingInput = 0;
                    }
                }
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Fatal(tag, $"key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case "XF86Back":
                    case "Escape":
                        //Exit();
                        break;

                    case KEY_NUM_1:
                        log.Fatal(tag, $"pressed Key Num 1!");
                        break;

                    case KEY_NUM_2:
                        mainWin.Maximize(true);
                        break;

                    case KEY_NUM_3:
                        if(mainWin.IsMaximized())
                        {
                            mainWin.Maximize(false);
                        }
                        break;
                    case KEY_NUM_4:
                        mainWin.SetMaximumSize(new Size2D(700, 700));
                        break;
                    case KEY_NUM_5:
                        mainWin.SetMimimumSize(new Size2D(100, 100));
                        break;
                    case KEY_NUM_6:
                        if(manualRotation == false)
                        {
                            manualRotation = true;
                            log.Fatal(tag, $"Enable manual rotation");
                        }
                        else
                        {
                            manualRotation = false;
                            log.Fatal(tag, $"Disable manual rotation");
                        }
                        mainWin.SetNeedsRotationCompletedAcknowledgement(manualRotation);
                        break;
                    case KEY_NUM_7:
                        mainWin.SetMimimumSize(new Size2D(100, 100));
                        break;
                    case KEY_NUM_8:
                        if(mainWin.GetFullScreen() == false)
                        {
                            mainWin.SetFullScreen(true);
                        }
                        else
                        {
                            mainWin.SetFullScreen(false);
                        }
                        break;

                    default:
                        log.Fatal(tag, $"no test!");
                        break;
                }
            }
        }

        public void Activate() { Initialize(); }
        public void Deactivate() { }
    }
}
