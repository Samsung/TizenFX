/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class SubWindowTest : IExample
    {
        private const string tag = "NUITEST";
        private const string KEY_BACK = "XF86Back";
        private const string KEY_ESCAPE = "Escape";
        private const string KEY_NUM_1 = "1";
        private const string KEY_NUM_2 = "2";
        private const string KEY_NUM_3 = "3";
        private const string KEY_NUM_4 = "4";
        private const string KEY_NUM_5 = "5";
        private const string KEY_PARENT_ABOVE = "6";
        private const string KEY_PARENT_BELOW = "7";
        private Window mainWin;
        private Window subWinFirst;
        private Window subWinSecond;
        private Window subWinThird;
        private Timer disposeTimer;
        private bool belowParent;
        private const int oneSecond = 1000;
        private const int testSize = 100;
        private const int testPosition = 100;
        private const float testPointSize = 12.0f;

        public void Activate()
        {
            Initialize();
        }

        public void Deactivate()
        {
        }

        private void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.KeyEvent += OnKeyEvent;
            mainWin.BackgroundColor = Color.Cyan;
            mainWin.WindowSize = new Size2D(5 * testSize, 5 * testSize);
            mainWin.TouchEvent += WinTouchEvent;
            belowParent = false;

            TextLabel testText = new TextLabel("Hello Tizen NUI World")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = Color.Blue,
                PointSize = testPointSize,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent
            };
            mainWin.Add(testText);

            Animation testRotationAnim = new Animation(2 * oneSecond);
            testRotationAnim.AnimateTo(testText, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, oneSecond);
            testRotationAnim.AnimateTo(testText, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), oneSecond, 2 * oneSecond);
            testRotationAnim.Looping = true;
            testRotationAnim.Play();

            log.Debug(tag, "animation play!");
        }

        private void CreateSubWinThird()
        {
            if (subWinThird)
            {
                log.Debug(tag, $"subWinThird is already created");
                return;
            }
            subWinThird = new Window("subWinThird", new Rectangle(0, 0, 3 * testSize, 3 * testSize), false)
            {
                BackgroundColor = Color.Blue
            };
            View childDummyView = new View()
            {
                Size = new Size(testSize, testSize),
                Position = new Position(testPosition, testPosition),
                BackgroundColor = Color.Yellow,
            };
            subWinThird.Add(childDummyView);
            subWinThird.KeyEvent += SubWinThirdKeyEvent;
        }

        private void SetParentAbove()
        {
            CreateSubWinThird();
            subWinThird.SetParent(mainWin, false);
        }

        private void SetParentBelow()
        {
            CreateSubWinThird();
            subWinThird.SetParent(mainWin, true);
        }

        private void SubWinThirdKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Debug(tag, $"key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case KEY_PARENT_ABOVE:
                        SetParentAbove();
                        break;
                    case KEY_PARENT_BELOW:
                        SetParentBelow();
                        break;
                }
            }
        }

        private void WinTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                if (belowParent == false)
                {
                    SetParentBelow();
                    belowParent = true;
                }
                else
                {
                    SetParentAbove();
                    belowParent = false;
                }
            }
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Debug(tag, $"key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case KEY_BACK:
                    case KEY_ESCAPE:
                        break;

                    case KEY_NUM_1:
                        TestMakeSubWindowAndAddSomeDummyObject();
                        break;

                    case KEY_NUM_2:
                        TestDisposeSubWindowFirstWhichWasCreatedInPrivousTestCase();
                        break;

                    case KEY_NUM_3:
                        TestCreateSubWindowSecondWhichDoesNotHaveAnySettingAndDisposeItAfterThreeSecondsDelay();
                        break;

                    case KEY_NUM_4:
                        TestCreateSubWindowSecondWhichHasSomeSettingAndDisposeItAfterThreeSecondsDelay();
                        break;

                    case KEY_NUM_5:
                        TestCreateSubWindowSecondWhichHasSomeSettingAndAddSomeDummyObjectAndDisposeItAfterThreeSecondsDelay();
                        break;

                    case KEY_PARENT_ABOVE:
                        SetParentAbove();
                        break;

                    case KEY_PARENT_BELOW:
                        SetParentBelow();
                        break;

                    default:
                        log.Debug(tag, $"no test!");
                        break;
                }
            }
        }

        //TDD
        private void TestMakeSubWindowAndAddSomeDummyObject()
        {
            subWinFirst = new Window("subWinFirst", new Rectangle(5 * testPosition, 5 * testPosition, 3 * testSize, 3 * testSize), false)
            {
                BackgroundColor = Color.Blue
            };
            View childView = new View()
            {
                Size = new Size(testSize, testSize),
                Position = new Position(testPosition, testPosition),
                BackgroundColor = Color.Yellow,
            };
            subWinFirst.Add(childView);
            subWinFirst.KeyEvent += SubWinFirstKeyEvent;
        }

        private void TestDisposeSubWindowFirstWhichWasCreatedInPrivousTestCase()
        {
            subWinFirst?.Dispose();
        }

        private void TestCreateSubWindowSecondWhichDoesNotHaveAnySettingAndDisposeItAfterThreeSecondsDelay()
        {
            subWinSecond = null;
            subWinSecond = new Window();
            disposeTimer = new Timer(3 * oneSecond);
            disposeTimer.Tick += OnDisposeTimerTick;
            disposeTimer.Start();
        }

        private void TestCreateSubWindowSecondWhichHasSomeSettingAndDisposeItAfterThreeSecondsDelay()
        {
            subWinSecond = null;
            subWinSecond = new Window("subWinSecond", new Rectangle(testPosition, testPosition, testSize, testSize), false)
            {
                BackgroundColor = Color.Red
            };
            disposeTimer = new Timer(3 * oneSecond);
            disposeTimer.Tick += OnDisposeTimerTick;
            disposeTimer.Start();
        }

        private void TestCreateSubWindowSecondWhichHasSomeSettingAndAddSomeDummyObjectAndDisposeItAfterThreeSecondsDelay()
        {
            subWinSecond = null;
            subWinSecond = new Window("subWinSecond", new Rectangle(5 * testPosition, 5 * testPosition, 3 * testSize, 3 * testSize), false)
            {
                BackgroundColor = Color.Red
            };
            View testView = new View()
            {
                Size = new Size(testSize, testSize),
                Position = new Position(testPosition, testPosition),
                BackgroundColor = Color.Yellow,
            };
            subWinSecond.Add(testView);

            disposeTimer = new Timer(3 * oneSecond);
            disposeTimer.Tick += OnDisposeTimerTick;
            disposeTimer.Start();
        }

        private bool OnDisposeTimerTick(object source, Timer.TickEventArgs e)
        {
            log.Debug(tag, $"after 3000ms, subWinSecond dispose!");
            subWinSecond?.Dispose();
            return false;
        }

        private void SubWinFirstKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Debug(tag, $"subWinFirst key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case KEY_BACK:
                    case KEY_ESCAPE:
                        break;
                    case KEY_NUM_1:
                        mainWin.Raise();
                        break;
                    default:
                        log.Debug(tag, $"default!");
                        break;
                }
            }
        }
    }
}
