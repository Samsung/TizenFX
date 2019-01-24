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
using System.Threading.Tasks;
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
        TextField textFieldPlaceholderTest;
        TextLabel keySubclassTest;

        protected override void OnCreate()
        {
            Tizen.Log.Error("MYLOG", "OnCreate\n");
            base.OnCreate();
            Initialize();
        }

        TextLabel pixelLabel;
        TextLabel pointLabel;
        public void Initialize()
        {
            Tizen.Log.Error("MYLOG", "Init\n");

            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.TouchEvent += OnWindowTouched;
            window.KeyEvent += OnWindowKeyEvent;
            window.Resized += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "Height: " + e.WindowSize.Height);
                Tizen.Log.Fatal("NUI", "Width: " + e.WindowSize.Width);
            };

            pixelLabel = new TextLabel("NUI Ubuntu Test! Click with mouse!");
            pixelLabel.Position2D = new Position2D(10, 10);
            pixelLabel.BackgroundColor = Color.Yellow;
            pixelLabel.PointSize = 20;
            pixelLabel.TextColor = Color.Blue;
            window.Add(pixelLabel);

            pointLabel = new TextLabel("Test Point Size 32.0f");
            pointLabel.Position2D = new Position2D(10, 70);
            pointLabel.PointSize = 32.0f;
            window.Add(pointLabel);

            Timer timer = new Timer(1000);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    Timer timer_in_another_thread = new Timer(1000);

                    TextLabel ellipsis = new TextLabel("Ellipsis of TextLabel is enabled.");
                    ellipsis.Size2D = new Size2D(100, 100);
                    ellipsis.Position2D = new Position2D(10, 250);
                    ellipsis.PointSize = 20.0f;
                    ellipsis.Ellipsis = true;
                    window.Add(ellipsis);
                }
                catch (Exception e)
                {
                    Tizen.Log.Fatal("NUI", $"exception caught! e={e}");
                }
            }).Wait();

            TextField textFieldEllipsisTest = new TextField();
            textFieldEllipsisTest.Text = "TextField Ellipsis Test, ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            textFieldEllipsisTest.Size2D = new Size2D(200, 100);
            textFieldEllipsisTest.Position2D = new Position2D(10, 150);
            textFieldEllipsisTest.PointSize = 30.0f;
            textFieldEllipsisTest.Ellipsis = false;
            window.Add(textFieldEllipsisTest);

            TextField textFieldEllipsisTest2 = new TextField();
            textFieldEllipsisTest2.Text = "TextField Ellipsis Test, ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            textFieldEllipsisTest2.Size2D = new Size2D(200, 100);
            textFieldEllipsisTest2.Position2D = new Position2D(300, 150);
            textFieldEllipsisTest2.PointSize = 30.0f;
            textFieldEllipsisTest2.Ellipsis = true;
            window.Add(textFieldEllipsisTest2);


            textFieldPlaceholderTest = new TextField();

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("placeholderText", new PropertyValue("TextField Placeholder Test"));
            propertyMap.Add("placeholderTextFocused", new PropertyValue("Placeholder Text Focused"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Blue));
            propertyMap.Add("placeholderPointSize", new PropertyValue(20.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));

            textFieldPlaceholderTest.Size2D = new Size2D(300, 50);
            textFieldPlaceholderTest.Position2D = new Position2D(10, 230);
            textFieldPlaceholderTest.BackgroundColor = Color.Magenta;
            textFieldPlaceholderTest.Placeholder = propertyMap;
            textFieldPlaceholderTest.Focusable = true;
            window.Add(textFieldPlaceholderTest);

            keySubclassTest = new TextLabel();
            keySubclassTest.Text = "Key Subclass Test!";
            keySubclassTest.Size2D = new Size2D(900, 50);
            keySubclassTest.Position2D = new Position2D(10, 300);
            keySubclassTest.BackgroundColor = Color.Cyan;
            keySubclassTest.PointSize = 20;
            keySubclassTest.Focusable = true;
            window.Add(keySubclassTest);


            TextLabel autoScrollStopMode = new TextLabel("AutoScrollStopMode is finish-loop. PointSize=30");
            autoScrollStopMode.Size2D = new Size2D(400, 100);
            autoScrollStopMode.Position2D = new Position2D(10, 400);
            autoScrollStopMode.PointSize = 30.0f;
            autoScrollStopMode.AutoScrollStopMode = AutoScrollStopMode.Immediate;
            autoScrollStopMode.AutoScrollLoopDelay = 3.0f;
            autoScrollStopMode.EnableAutoScroll = true;
            autoScrollStopMode.AutoScrollLoopCount = 0;
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
            Tizen.Log.Fatal("NUI", "[1]_view SizeWidth=" + _view.SizeWidth);

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
            Tizen.Log.Fatal("NUI", "[2]_view SizeWidth=" + _view.SizeWidth);

            TextLabelLineWrapModeTest();
            ViewLayoutDirectionTest();

            textFieldPlaceholderTest.DownFocusableView = keySubclassTest;
            keySubclassTest.UpFocusableView = textFieldPlaceholderTest;
            FocusManager.Instance.SetCurrentFocusView(keySubclassTest);
            Tizen.Log.Error("MYLOG", "Init 2\n");

        }


        private View view1, view11, view12, view111, view121;
        public void ViewLayoutDirectionTest()
        {
            view1 = new View();
            view1.Name = "view 1";
            view1.LayoutDirection = ViewLayoutDirectionType.RTL;
            Window.Instance.GetDefaultLayer().Add(view1);
            view1.LayoutDirectionChanged += View1_LayoutDirectionChanged;

            view11 = new View();
            view11.Name = "view 11";
            view11.InheritLayoutDirection = true;
            view1.Add(view11);

            view12 = new View();
            view12.Name = "view 12";
            view12.LayoutDirection = ViewLayoutDirectionType.LTR;
            view1.Add(view12);

            view111 = new View();
            view111.Name = "view 111";
            view111.InheritLayoutDirection = true;
            view11.Add(view111);

            view121 = new View();
            view121.Name = "view 121";
            view121.InheritLayoutDirection = true;
            view12.Add(view121);
        }

        private void View1_LayoutDirectionChanged(object sender, View.LayoutDirectionChangedEventArgs e)
        {
            Tizen.Log.Error("NUI", "View1_LayoutDirectionChanged()! e.Type=" + e.Type);
        }

        public void AnimationFinished(object sender, EventArgs e)
        {
            Tizen.Log.Fatal("NUI", "AnimationFinished()! cnt=" + (cnt));
            if (_animation)
            {
                Tizen.Log.Fatal("NUI", "Duration= " + _animation.Duration + "EndAction= " + _animation.EndAction);
            }
            _view.SizeWidth = 50;
            Tizen.Log.Fatal("NUI", "[3]_view SizeWidth=" + _view.SizeWidth);
        }

        int win_test;
        public void OnWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "e.Key.KeyPressedName=" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                keySubclassTest.Text = $"DeviceSubClass={e.Key.DeviceSubClass}, DeviceClass={e.Key.DeviceClass}, DeviceName={e.Key.DeviceName}, KeyCode={e.Key.KeyCode}";

                if (e.Key.KeyPressedName == "Up")
                {
                    if (_animation)
                    {
                        _animation.Finished += AnimationFinished;
                        cnt++;
                        Tizen.Log.Fatal("NUI", "AnimationFinished added!");
                    }
                    //pointLabel.TextColorAnimatable = Color.Blue;
                    //pixelLabel.TextColorAnimatable = Color.Blue;

                    Tizen.Log.Fatal("NUI", $"LineWrapMode 1st={ myTextLabel?.LineWrapMode} 2nd={ myTextLabel2?.LineWrapMode}");
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (_animation)
                    {
                        _animation.Finished -= AnimationFinished;
                        cnt--;
                        Tizen.Log.Fatal("NUI", "AnimationFinished removed!");
                    }
                    //pointLabel.TextColorAnimatable = Color.Red;
                    //pixelLabel.TextColorAnimatable = Color.Red;

                    Window.Instance.SetClass($"Window.SetClass() Test #{win_test++}", "");
                    Tizen.Log.Fatal("NUI", $"Check with enlightenment_info -topwins ! Window.SetClass() Test #{win_test}");
                }
                else if (e.Key.KeyPressedName == "Return")
                {
                    _animation.Play();
                    Tizen.Log.Fatal("NUI", "_animation play here!");
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
            Tizen.Log.Fatal("NUI", "WrapModeTest START!");
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

            Tizen.Log.Fatal("NUI", $"TextLabel LineWrapMode 1st={ myTextLabel?.LineWrapMode} 2nd={ myTextLabel2?.LineWrapMode}");

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

            Tizen.Log.Fatal("NUI", $"TextEditor LineWrapMode 1st={ myTextEditor?.LineWrapMode} 2nd={ myTextEditor2?.LineWrapMode}");
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
