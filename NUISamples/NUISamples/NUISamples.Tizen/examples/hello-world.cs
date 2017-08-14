/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;
        private int cnt;
        private View _view;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        TextLabel pixelLabel;
        TextLabel pointLabel;
        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.TouchEvent += OnWindowTouched;
            window.KeyEvent += OnWindowKeyEvent;
            window.Resized += (obj, e) =>
            {
                NUILog.Debug("Height: " + e.WindowSize.Height);
                NUILog.Debug("Width: " + e.WindowSize.Width);
            };

            pixelLabel = new TextLabel("Test Pixel Size 32.0f");
            pixelLabel.Position2D = new Position2D(10, 10);
            pixelLabel.PixelSize = 32.0f;
            window.Add(pixelLabel);

            pointLabel = new TextLabel("Test Point Size 32.0f");
            pointLabel.Position2D = new Position2D(10, 100);
            pointLabel.PointSize = 32.0f;
            window.Add(pointLabel);

            TextLabel ellipsis = new TextLabel("Ellipsis of TextLabel is enabled.");
            ellipsis.Size2D = new Size2D(100, 100);
            ellipsis.Position2D = new Position2D(10, 250);
            ellipsis.PointSize = 20.0f;
            ellipsis.Ellipsis = true;
            window.Add(ellipsis);

            TextLabel autoScrollStopMode = new TextLabel("AutoScrollStopMode is finish-loop.");
            autoScrollStopMode.Size2D = new Size2D(400, 100);
            autoScrollStopMode.Position2D = new Position2D(10, 400);
            autoScrollStopMode.PointSize = 15.0f;
            autoScrollStopMode.AutoScrollStopMode = AutoScrollStopMode.FinishLoop;
            autoScrollStopMode.AutoScrollLoopDelay = 10.0f;
            autoScrollStopMode.EnableAutoScroll = true;
            window.Add(autoScrollStopMode);

            _text = new TextLabel("Hello NUI World");
            _text.Position2D = new Position2D(10, 500);
            _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.PointSize = 20.0f;
            _text.TextColor = Color.Magenta;
            window.Add(_text);

            _view = new View();
            _view.Size2D = new Size2D(100, 100);
            _view.SizeWidth = 50;
            NUILog.Debug("[1]_view SizeWidth=" + _view.SizeWidth);

            _animation = new Animation
            {
                Duration = 2000
            };
            _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            _animation.AnimateTo(_text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            _animation.AnimateBy(_text, "ScaleX", 3, 1000, 1500);
            _animation.AnimateBy(_text, "ScaleY", 4.0f, 1500, 2000);
            _animation.EndAction = Animation.EndActions.Discard;
            _animation.Finished += AnimationFinished;

            _view.SizeWidth = 50;
            NUILog.Debug("[2]_view SizeWidth=" + _view.SizeWidth);

            TextLabelLineWrapModeTest();
        }

        public void AnimationFinished(object sender, EventArgs e)
        {
            NUILog.Debug("AnimationFinished()! cnt=" + (cnt));
            if (_animation)
            {
                NUILog.Debug("Duration= " + _animation.Duration + "EndAction= " + _animation.EndAction);
            }
            _view.SizeWidth = 50;
            NUILog.Debug("[3]_view SizeWidth=" + _view.SizeWidth);
        }

        int win_test;
        public void OnWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            NUILog.Debug("e.Key.KeyPressedName=" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    if (_animation)
                    {
                        _animation.Finished += AnimationFinished;
                        cnt++;
                        NUILog.Debug("AnimationFinished added!");
                    }
                    pointLabel.TextColorAnimatable = Color.Blue;
                    pixelLabel.TextColorAnimatable = Color.Blue;

                    NUILog.Debug($"LineWrapMode 1st={ myTextLabel?.LineWrapMode} 2nd={ myTextLabel2?.LineWrapMode}");
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (_animation)
                    {
                        _animation.Finished -= AnimationFinished;
                        cnt--;
                        NUILog.Debug("AnimationFinished removed!");
                    }
                    pointLabel.TextColorAnimatable = Color.Red;
                    pixelLabel.TextColorAnimatable = Color.Red;

                    Window.Instance.SetClass($"Window.SetClass() Test #{win_test++}", "");
                    NUILog.Debug($"Check with enlightenment_info -topwins ! Window.SetClass() Test #{win_test}");
                }
                else if (e.Key.KeyPressedName == "Return")
                {
                    _animation.Play();
                    NUILog.Debug("_animation play here!");
                }
            }
        }

        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                _animation.Play();
            }
        }

        private TextLabel myTextLabel;
        private TextLabel myTextLabel2;
        private TextEditor myTextEditor;
        private TextEditor myTextEditor2;
        public void TextLabelLineWrapModeTest()
        {
            NUILog.Debug("WrapModeTest START!");
            myTextLabel = new TextLabel();
            myTextLabel.Position2D = new Position2D(10, 600);
            myTextLabel.Size2D = new Size2D(400, 90);
            myTextLabel.BackgroundColor = Color.Blue;
            myTextLabel.PointSize = 20;
            myTextLabel.TextColor = Color.White;
            myTextLabel.MultiLine = true;
            myTextLabel.LineWrapMode = LineWrapMode.Character;
            myTextLabel.Text = $"[TextLabel LineWrapMode.Character] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextLabel);

            myTextLabel2 = new TextLabel();
            myTextLabel2.Position2D = new Position2D(450, 600);
            myTextLabel2.Size2D = new Size2D(400, 90);
            myTextLabel2.BackgroundColor = Color.Blue;
            myTextLabel2.PointSize = 20;
            myTextLabel2.TextColor = Color.White;
            myTextLabel2.MultiLine = true;
            myTextLabel2.LineWrapMode = LineWrapMode.Word;
            myTextLabel2.Text = $"[TextLabel LineWrapMode.Word] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextLabel2);

            NUILog.Debug($"TextLabel LineWrapMode 1st={ myTextLabel?.LineWrapMode} 2nd={ myTextLabel2?.LineWrapMode}");

            myTextEditor = new TextEditor();
            myTextEditor.Position2D = new Position2D(10, 700);
            myTextEditor.Size2D = new Size2D(400, 90);
            myTextEditor.BackgroundColor = Color.Red;
            myTextEditor.PointSize = 20;
            myTextEditor.TextColor = Color.White;
            //myTextEditor.MultiLine = true;
            myTextEditor.LineWrapMode = LineWrapMode.Character;
            myTextEditor.Text = $"[TextEditor LineWrapMode.Character] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextEditor);

            myTextEditor2 = new TextEditor();
            myTextEditor2.Position2D = new Position2D(450, 700);
            myTextEditor2.Size2D = new Size2D(400, 90);
            myTextEditor2.BackgroundColor = Color.Red;
            myTextEditor2.PointSize = 20;
            myTextEditor2.TextColor = Color.White;
            //myTextEditor2.MultiLine = true;
            myTextEditor2.LineWrapMode = LineWrapMode.Word;
            myTextEditor2.Text = $"[TextEditor LineWrapMode.Word] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextEditor2);

            NUILog.Debug($"TextEditor LineWrapMode 1st={ myTextEditor?.LineWrapMode} 2nd={ myTextEditor2?.LineWrapMode}");
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
