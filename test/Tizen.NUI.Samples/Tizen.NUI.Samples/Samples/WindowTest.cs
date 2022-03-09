
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.System;
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

        private const string KEY_NUM_1 = "1";
        private const string KEY_NUM_2 = "2";
        private const string KEY_NUM_3 = "3";
        private const string KEY_NUM_4 = "4";
        private const string KEY_NUM_5 = "5";

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

            Animation animation = new Animation(2000);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            animation.Looping = true;
            animation.Play();
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
