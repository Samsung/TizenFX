
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class SubWindowTest : IExample
    {
        string tag = "NUITEST";
        Window mainWin;
        Window subWin1;
        Window subWin2;
        Timer tm;
        void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.KeyEvent += OnKeyEvent;
            mainWin.BackgroundColor = Color.Cyan;
            mainWin.WindowSize = new Size2D(500, 500);

            TextLabel text = new TextLabel("Hello Tizen NUI World");
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

            log.Fatal(tag, "animation play!");
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

                    case "1":
                        TestCase1();
                        break;

                    case "2":
                        TestCase2();
                        break;

                    case "3":
                        TestCase3();
                        break;

                    case "4":
                        TestCase4();
                        break;

                    case "5":
                        TestCase5();
                        break;

                    default:
                        log.Fatal(tag, $"no test!");
                        break;
                }
            }
        }

        //TDD
        void TestCase1()
        {
            log.Fatal(tag, "test 1 : 1) make sub window-1 2) add some dummy object");

            subWin1 = new Window("subwin1", new Rectangle(500, 500, 300, 300), false);
            subWin1.BackgroundColor = Color.Blue;
            View dummy = new View()
            {
                Size = new Size(100, 100),
                Position = new Position(50, 50),
                BackgroundColor = Color.Yellow,
            };
            subWin1.Add(dummy);
            subWin1.KeyEvent += SubWin1_KeyEvent;
        }
        void TestCase2()
        {
            log.Fatal(tag, "test 2 : 1) do dispose of sub window-1 created in #1");
            subWin1?.Dispose();
        }
        void TestCase3()
        {
            log.Fatal(tag, $"test 3 : 1) create sub window2 which doesn't have any setting 2) dispose it after 3 second delay");
            subWin2 = null;
            subWin2 = new Window();
            tm = new Timer(3000);
            tm.Tick += Tm_Tick;
            tm.Start();
        }
        void TestCase4()
        {
            log.Fatal(tag, $"test 4 : 1) create sub window2 which has some setting 2) dispose it after 3 second delay");
            subWin2 = null;
            subWin2 = new Window("subWin2", new Rectangle(100, 100, 100, 100), false);
            subWin2.BackgroundColor = Color.Red;
            tm = new Timer(3000);
            tm.Tick += Tm_Tick;
            tm.Start();
        }
        void TestCase5()
        {
            log.Fatal(tag, $"test 5 : 1) create sub window2 which has some setting 2) add some dummy object 3) dispose it after 3 second delay");
            subWin2 = null;
            subWin2 = new Window("subWin2", new Rectangle(500, 500, 300, 300), false);
            subWin2.BackgroundColor = Color.Red;
            View v1 = new View()
            {
                Size = new Size(50, 50),
                Position = new Position(50, 50),
                BackgroundColor = Color.Yellow,
            };
            subWin2.Add(v1);

            tm = new Timer(3000);
            tm.Tick += Tm_Tick;
            tm.Start();
        }

        private bool Tm_Tick(object source, Timer.TickEventArgs e)
        {
            log.Fatal(tag, $"after 3000ms, subwin2 dispose!");
            subWin2?.Dispose();
            return false;
        }

        private void SubWin1_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Fatal(tag, $"subWin1 key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case "XF86Back":
                    case "Escape":
                        //Exit();
                        break;
                    case "1":
                        mainWin.Raise();
                        break;
                    default:
                        log.Fatal(tag, $"default!");
                        break;
                }
            }
        }


        public void Activate() { Initialize(); }
        public void Deactivate() { }
    }
}
