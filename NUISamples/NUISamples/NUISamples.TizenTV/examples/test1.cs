// Copyright (c) 2017 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;


// 1) sibling order test
namespace Test1
{
    class Example : NUIApplication
    {
        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        Window _window;
        StyleManager _style;

        public void Initialize()
        {
            _window = Window.Instance;
            _window.BackgroundColor = Color.White;

            // 1) sibling order test
            SiblingTest();
            // 2) text visual test
            dali_VisualBase_Creation_test();

            // 3) visual creation test
            VisualTest2();

            _style = StyleManager.Get();
            //_style.StyleChanged += _style_StyleChanged;
            _style.StyleChanged += (obj, e) =>
            {
                Tizen.Log.Debug("NUI", "in stylechanged.. C#side..\n");
                //flag = true;
            };

            _style.ApplyTheme("/home/owner/apps_rw/NUISamples.TizenTV/res/json/date-picker-theme.json");
            Tizen.Log.Debug("NUI", "#### 1) first change!");


            AnimatePath_1();
        }

        private void _style_StyleChanged(object sender, StyleManager.StyleChangedEventArgs e)
        {
            Tizen.Log.Debug("NUI", "style changed event handler comes");
        }

        public void SiblingTest()
        {
            View _prev = null;
            Position2D _myPos = new Position2D(100, 100);
            List<View> list_view = new List<View>();
            TextLabel _txt = new TextLabel();

            for (int i = 0; i < 10; i++)
            {
                View _view0 = new PushButton();
                PushButton _view = _view0 as PushButton;

                _view.Name = "sibling" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.LabelText = "sibling" + i;
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);
                _view.Clicked += (sender, ee) =>
                {
                    View curr = sender as View;
                    Tizen.Log.Debug("NUI", "clicked curr view name=" + curr.Name + "  sibling=" + curr.SiblingOrder);
                    curr.RaiseToTop();
                    if (_prev)
                    {
                        _prev.LowerToBottom();
                        Tizen.Log.Debug("NUI", "raise on top is called!curr sibling=" + curr.SiblingOrder + " prev name=" + _prev.Name + " sibling=" + _prev.SiblingOrder);
                    }
                    _prev = curr;
                    _txt.Text = "on top: " + curr.Name + ", sibling order=" + curr.SiblingOrder;

                    _style.ApplyTheme("/home/owner/apps_rw/NUISamples.TizenTV/res/json/style-example-theme-one.json");
                    Tizen.Log.Debug("NUI", "#### 2) second change!");

                    return true;
                };
                list_view.Add(_view);
            }

            for (int i = 0; i < 10; i++)
            {
                _window.Add(list_view[i]);
                Tizen.Log.Debug("NUI", list_view[i].Name + "'s sibling order=" + list_view[i].SiblingOrder);
            }

            _txt.ParentOrigin = ParentOrigin.TopLeft;
            _txt.PivotPoint = PivotPoint.TopLeft;
            _txt.Text = "on top: sibling#, sibling order=?";
            _txt.Position2D = _myPos + new Position2D(-50, 200);
            _txt.TextColor = Color.Blue;
            _window.Add(_txt);

        }

        public class VisualTest : CustomView
        {
            private int TextVisualPropertyIndex = -1;
            private VisualBase _textVisual;
            private string _string;

            public VisualTest() : base(typeof(VisualTest).Name, CustomViewBehaviour.RequiresKeyboardNavigationSupport)
            {
            }
            public string TextVisual
            {
                get
                {
                    return _string;
                }
                set
                {
                    _string = value;

                    TextVisualPropertyIndex = RegisterProperty("textvisualtest", new PropertyValue("textvisualtest"), PropertyAccessMode.ReadWrite);

                    PropertyMap textVisual = new PropertyMap();
                    textVisual.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text))
                        .Add(TextVisualProperty.Text, new PropertyValue(_string))
                        .Add(TextVisualProperty.TextColor, new PropertyValue(Color.Blue))
                        .Add(TextVisualProperty.PointSize, new PropertyValue(10))
                        .Add(TextVisualProperty.HorizontalAlignment, new PropertyValue("CENTER"))
                        .Add(TextVisualProperty.VerticalAlignment, new PropertyValue("CENTER"));
                    _textVisual = VisualFactory.Instance.CreateVisual(textVisual);
                    RegisterVisual(TextVisualPropertyIndex, _textVisual);
                    _textVisual.DepthIndex = TextVisualPropertyIndex;
                }
            }
        }

        //when use belowing testcase, Time is out and this case is BLOCK
        public void dali_VisualBase_Creation_test()
        {
            try
            {
                Tizen.Log.Debug("NUI", "##### start! ######");

                VisualTest _visualTest = new VisualTest();
                _visualTest.TextVisual = "Hello NUI Text Visual!";
                _visualTest.ParentOrigin = ParentOrigin.TopLeft;
                _visualTest.PivotPoint = PivotPoint.TopLeft;
                _visualTest.Size2D = new Size2D(600, 200);
                _visualTest.Position2D = new Position2D(50, 400);
                _visualTest.BackgroundColor = Color.Yellow;
                _window.Add(_visualTest);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("NUI", "##### Caught Exception" + e.ToString());
                throw new System.InvalidOperationException("visual test error!!!");
            }
        }

        public void VisualTest2()
        {
            try
            {
                Tizen.Log.Debug("NUI", "##### VisualTest2() start! ######");

                VisualFactory visualfactory = VisualFactory.Instance;
                PropertyMap textMap1 = new PropertyMap();
                textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                textMap1.Insert(TextVisualProperty.Text, new PropertyValue("Hello"));
                textMap1.Insert(TextVisualProperty.PointSize, new PropertyValue(10.0f));

                PropertyMap textMap2 = new PropertyMap();
                VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
                textVisual1.Creation = textMap2;
            }
            catch (Exception e)
            {
                Tizen.Log.Error("NUI", "Caught Exception" + e.ToString());
                throw new System.InvalidOperationException("visual test2 error!!!");
                //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                //Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        //[Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimatePath_1()
        {
            Tizen.Log.Debug("NUI", "#### 1) animate path test !");
            /* TEST CODE */
            View view = new View();
            view.ParentOrigin = ParentOrigin.TopLeft;
            view.PivotPoint = PivotPoint.TopLeft;
            view.MinimumSize = new Size2D(100, 100);
            view.BackgroundColor = Color.Red;
            _window.Add(view);

            Position position0 = new Position(200.0f, 200.0f, 0.0f);
            Position position1 = new Position(300.0f, 300.0f, 0.0f);
            Position position2 = new Position(400.0f, 400.0f, 0.0f);

            Path path = new Path();
            path.AddPoint(position0);
            path.AddPoint(position1);
            path.AddPoint(position2);
            //Control points for first segment
            path.AddControlPoint(new Vector3(39.0f, 90.0f, 0.0f));
            path.AddControlPoint(new Vector3(56.0f, 119.0f, 0.0f));
            //Control points for second segment
            path.AddControlPoint(new Vector3(78.0f, 120.0f, 0.0f));
            path.AddControlPoint(new Vector3(93.0f, 104.0f, 0.0f));

            Animation animation = new Animation();
            animation.AnimatePath(view, path, Vector3.XAxis, 0, 5000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            Vector3 position = new Vector3();
            Vector3 tangent = new Vector3();

            path.Sample(0.0f, position, tangent);
            Rotation rotation = new Rotation(new Radian(new Degree(0.0f)), tangent);
            Tizen.Log.Debug("NUI", "################  progress = 0! ");
            Tizen.Log.Debug("NUI", "position=(" + position.X + "," + position.Y + "," + position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.Position.X + "," + view.Position.Y + "," + view.Position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.PositionX + "," + view.PositionY + "," + view.PositionZ + ")");
            Tizen.Log.Debug("NUI", "view cur position=(" + view.CurrentPosition.X + "," + view.CurrentPosition.Y + "," + view.CurrentPosition.Z + ")");
            Tizen.Log.Debug("NUI", "tangent=(" + tangent.X + "," + tangent.Y + "," + tangent.Z + ")");
            Tizen.Log.Debug("NUI", "angle between=" + Rotation.AngleBetween(view.Orientation, rotation) + "  view orientation length=" + view.Orientation.Length() + "  rotation length=" + rotation.Length());
            //Assert.AreEqual(position.X, view.PositionX, "The actor's PositionX of is not correct");
            //Assert.AreEqual(position.Y, actor.PositionY, "The actor's PositionY of is not correct");
            //Assert.AreEqual(position.Z, actor.PositionZ, "The actor's PositionZ of is not correct");
            //Assert.IsTrue(rotation.Equals(actor.Orientation));
            //await Task.Delay(250);
            path.Sample(0.25f, position, tangent);
            rotation = new Rotation(new Radian(new Degree(0.0f)), tangent);
            Tizen.Log.Debug("NUI", "################  progress = 0.25! ");
            Tizen.Log.Debug("NUI", "position=(" + position.X + "," + position.Y + "," + position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.Position.X + "," + view.Position.Y + "," + view.Position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.PositionX + "," + view.PositionY + "," + view.PositionZ + ")");
            Tizen.Log.Debug("NUI", "view cur position=(" + view.CurrentPosition.X + "," + view.CurrentPosition.Y + "," + view.CurrentPosition.Z + ")");
            Tizen.Log.Debug("NUI", "tangent=(" + tangent.X + "," + tangent.Y + "," + tangent.Z + ")");
            Tizen.Log.Debug("NUI", "angle between=" + Rotation.AngleBetween(view.Orientation, rotation) + "  view orientation length=" + view.Orientation.Length() + "  rotation length=" + rotation.Length());
            //Assert.AreEqual(position.X, actor.PositionX, "The PositionX of actor is not correct");
            //Assert.AreEqual(position.Y, actor.PositionY, "The PositionY of actor is not correct");
            //Assert.AreEqual(position.Z, actor.PositionZ, "The PositionZ of actor is not correct");
            //Assert.IsTrue(rotation.Equals(actor.Orientation));
            //await Task.Delay(500);
            path.Sample(0.75f, position, tangent);
            rotation = new Rotation(new Radian(new Degree(0.0f)), tangent);
            Tizen.Log.Debug("NUI", "################  progress = 0.75! ");
            Tizen.Log.Debug("NUI", "position=(" + position.X + "," + position.Y + "," + position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.Position.X + "," + view.Position.Y + "," + view.Position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.PositionX + "," + view.PositionY + "," + view.PositionZ + ")");
            Tizen.Log.Debug("NUI", "view cur position=(" + view.CurrentPosition.X + "," + view.CurrentPosition.Y + "," + view.CurrentPosition.Z + ")");
            Tizen.Log.Debug("NUI", "tangent=(" + tangent.X + "," + tangent.Y + "," + tangent.Z + ")");
            Tizen.Log.Debug("NUI", "angle between=" + Rotation.AngleBetween(view.Orientation, rotation) + "  view orientation length=" + view.Orientation.Length() + "  rotation length=" + rotation.Length());
            //Assert.AreEqual(position.X, actor.PositionX, "The PositionX of actor is not correct here");
            //Assert.AreEqual(position.Y, actor.PositionY, "The PositionY of actor is not correct here");
            //Assert.AreEqual(position.Z, actor.PositionZ, "The PositionZ of actor is not correct here");
            //Assert.IsTrue(rotation.Equals(actor.Orientation));

            path.Sample(1.0f, position, tangent);
            rotation = new Rotation(new Radian(new Degree(0.0f)), tangent);
            Tizen.Log.Debug("NUI", "################  progress = 1.0! ");
            Tizen.Log.Debug("NUI", "position=(" + position.X + "," + position.Y + "," + position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.Position.X + "," + view.Position.Y + "," + view.Position.Z + ")");
            Tizen.Log.Debug("NUI", "view position=(" + view.PositionX + "," + view.PositionY + "," + view.PositionZ + ")");
            Tizen.Log.Debug("NUI", "view cur position=(" + view.CurrentPosition.X + "," + view.CurrentPosition.Y + "," + view.CurrentPosition.Z + ")");
            Tizen.Log.Debug("NUI", "tangent=(" + tangent.X + "," + tangent.Y + "," + tangent.Z + ")");
            Tizen.Log.Debug("NUI", "angle between=" + Rotation.AngleBetween(view.Orientation, rotation) + "  view orientation length=" + view.Orientation.Length() + "  rotation length=" + rotation.Length());


            Tizen.Log.Debug("NUI", "#### 2) animate path test end!");
        }




        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
