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
using System.Runtime.InteropServices;
using Dali;

namespace MyCSharpExample
{
    class MyView : View
    {
        private string _myOwnName;
        public int _myCurrentValue;

        public MyView()
        {
            _myCurrentValue = 0;
        }

        public string MyOwnName
        {
            get
            {
                return _myOwnName;
            }
            set
            {
                _myOwnName = value;
            }
        }
    }

    class MyButton : PushButton
    {
        private string _myOwnName;
        public int _myCurrentValue;

        public MyButton()
        {
            _myCurrentValue = 0;
        }

        public string MyOwnName
        {
            get
            {
                return _myOwnName;
            }
            set
            {
                _myOwnName = value;
            }
        }
    }

    class MySpin : Spin
    {
        private string _myOwnName;
        public int _myCurrentValue;

        public MySpin()
        {
            _myCurrentValue = 0;
        }

        public string MyOwnName
        {
            get
            {
                return _myOwnName;
            }
            set
            {
                _myOwnName = value;
            }
        }
    }

    class Example
    {
        private Dali.Application _application;

        public Example(Dali.Application application)
        {
            _application = application;
            Console.WriteLine("1) InitSignal connection count = " + _application.InitSignal().GetConnectionCount());

            _application.Initialized += Initialize;
            Console.WriteLine("2) InitSignal connection count = " + _application.InitSignal().GetConnectionCount());
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {

            //1)
            NavigationPropertiesTests();

            //2)
            OperatorTests();

            //3)
            CustomViewPropertyTest();

            //4)
            ActorHandleTest();

            //5)
            RectanglePaddingClassTest();

            //6)
            SizePositionTest();

            //7)
            ViewDownCastTest();

        }


        public void NavigationPropertiesTests()
        {
            Console.WriteLine("");
            Console.WriteLine("### [1] NavigationPropertiesTests START");

            View view = new View();
            View leftView, rightView, upView, downView, tmpView;

            leftView = new View();
            leftView.Name = "leftView";
            rightView = new View();
            rightView.Name = "rightView";
            upView = new View();
            upView.Name = "upView";
            downView = new View();
            downView.Name = "downView";

            Stage.Instance.Add(leftView);
            Stage.Instance.Add(rightView);
            Stage.Instance.Add(upView);
            Stage.Instance.Add(downView);

            view.LeftFocusableView = leftView;
            tmpView = view.LeftFocusableView;
            if (string.Compare(tmpView.Name, "leftView") == 0)
            {
                Console.WriteLine("Passed: LeftFocusedView = " + tmpView.Name);
            }
            else
            {
                Console.WriteLine("Failed: LeftFocusedView = " + tmpView.Name);
            }

            view.RightFocusableView = rightView;
            tmpView = view.RightFocusableView;
            if (string.Compare(tmpView.Name, "rightView") == 0)
            {
                Console.WriteLine("Passed: RightFocusedView = " + tmpView.Name);
            }
            else
            {
                Console.WriteLine("Failed: RightFocusedView = " + tmpView.Name);
            }

            Stage.Instance.Add(view);

            view.UpFocusableView = upView;
            tmpView = view.UpFocusableView;
            if (string.Compare(tmpView.Name, "upView") == 0)
            {
                Console.WriteLine("Passed: UpFocusedView = " + tmpView.Name);
            }
            else
            {
                Console.WriteLine("Failed: UpFocusedView = " + tmpView.Name);
            }

            view.DownFocusableView = downView;
            tmpView = view.DownFocusableView;
            if (string.Compare(tmpView.Name, "downView") == 0)
            {
                Console.WriteLine("Passed: DownFocusedView = " + tmpView.Name);
            }
            else
            {
                Console.WriteLine("Failed: DownFocusedView = " + tmpView.Name);
            }

            Stage.Instance.Remove(leftView);
            tmpView = view.LeftFocusableView;
            if (!tmpView)
            {
                Console.WriteLine("Passed: NULL LeftFocusedView");
            }
            else
            {
                Console.WriteLine("Failed: LeftFocusedView = " + tmpView.Name);
            }

            Console.WriteLine("### [1] NavigationPropertiesTests END");
        }

        public void OperatorTests()
        {
            Console.WriteLine("");
            Console.WriteLine("### [2] OperatorTests START");
            Actor actor = new Actor();
            Actor differentActor = new Actor();
            Actor actorSame = actor;
            Actor nullActor = null;

            // test the true operator
            if (actor)
            {
                Console.WriteLine("BaseHandle Operator true (actor) : test passed ");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator true (actor): test failed ");
            }

            Actor parent = actor.GetParent();

            if (parent)
            {
                Console.WriteLine("Handle with Empty body  :failed ");
            }
            else
            {
                Console.WriteLine("Valid with Empty body  :passed ");
            }

            actor.Add(differentActor);

            // here we test two different C# objects, which on the native side have the same body/ ref-object
            if (actor == differentActor.GetParent())
            {
                Console.WriteLine("actor == differentActor.GetParent() :passed ");
            }
            else
            {
                Console.WriteLine("actor == differentActor.GetParent() :failed ");
            }

            if (differentActor == differentActor.GetParent())
            {
                Console.WriteLine("differentActor == differentActor.GetParent() :failed ");
            }
            else
            {
                Console.WriteLine("differentActor == differentActor.GetParent() :passed ");
            }

            if (nullActor)
            {
                Console.WriteLine("BaseHandle Operator true (nullActor) : test failed ");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator true (nullActor): test passed ");
            }

            // ! operator
            if (!actor)
            {
                Console.WriteLine("BaseHandle Operator !(actor) : test failed ");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator !(actor): test passed ");
            }

            if (!nullActor)
            {
                Console.WriteLine("BaseHandle Operator !(nullActor) : test passed ");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator !(nullActor): test failed ");
            }

            // Note: operator false only used inside & operator
            // test equality operator ==
            if (actor == actorSame)
            {
                Console.WriteLine("BaseHandle Operator  (actor == actorSame) : test passed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator  (actor == actorSame) : test failed");
            }

            if (actor == differentActor)
            {
                Console.WriteLine("BaseHandle Operator (actor == differentActor) : test failed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor == differentActor) : test passed");
            }

            if (actor == nullActor)
            {
                Console.WriteLine("BaseHandle Operator (actor == nullActor) : test failed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor == nullActor) : test passed");
            }

            if (nullActor == nullActor)
            {
                Console.WriteLine("BaseHandle Operator (nullActor == nullActor) : test passed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (nullActor == nullActor) : test failed");
            }

            // test || operator
            if (actor || actorSame)
            {
                Console.WriteLine("BaseHandle Operator (actor || actorSame) : test passed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor || actorSame) : test failed");
            }

            if (actor || nullActor)
            {
                Console.WriteLine("BaseHandle Operator (actor || nullActor) : test passed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor || nullActor) : test failed");
            }

            if (nullActor || nullActor)
            {
                Console.WriteLine("BaseHandle Operator (nullActor || nullActor) : test failed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (nullActor || nullActor) : test passed");
            }

            // test && operator
            if (actor && actorSame)
            {
                Console.WriteLine("BaseHandle Operator (actor && actorSame) : test passed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor && actorSame) : test failed");
            }

            if (actor && nullActor)
            {
                Console.WriteLine("BaseHandle Operator (actor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (actor && nullActor) : test passed");
            }

            if (nullActor && nullActor)
            {
                Console.WriteLine("BaseHandle Operator (nullActor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine("BaseHandle Operator (nullActor && nullActor) : test passed");
            }

            Console.WriteLine("### [2] OperatorTests END");

        }

        public void CustomViewPropertyTest()
        {
            Console.WriteLine("");
            Console.WriteLine("### [3] CustomViewPropertyTest START");

            // Create a Spin control
            Spin spin = new Spin();

            // Background property
            Property.Map background = new Property.Map();
            background.Add(Dali.Constants.Visual.Property.Type, new Property.Value((int)Dali.Constants.Visual.Type.Color))
                      .Add(Dali.Constants.ColorVisualProperty.MixColor, new Property.Value(Color.Red));
            spin.Background = background;

            background = spin.Background;
            Color backgroundColor = new Color();
            background.Find(Dali.Constants.ColorVisualProperty.MixColor).Get(backgroundColor);

            if (backgroundColor == Color.Red)
            {
                Console.WriteLine("Custom View Background property : test passed");
            }
            else
            {
                Console.WriteLine("Custom View Background property : test failed");
            }

            // BackgroundColor property
            spin.BackgroundColor = Color.Yellow;

            if (spin.BackgroundColor.EqualTo(Color.Yellow))
            {
                Console.WriteLine("Custom View BackgroundColor property : test passed");
            }
            else
            {
                Console.WriteLine("Custom View BackgroundColor property : test failed");
            }

            // BackgroundImage property
            spin.BackgroundImage = "background-image.jpg";
            if (spin.BackgroundImage == "background-image.jpg")
            {
                Console.WriteLine("Custom View BackgroundImage property : test passed");
            }
            else
            {
                Console.WriteLine("Custom View BackgroundImage property : test failed");
            }

            // StyleName property
            spin.StyleName = "MyCustomStyle";
            if (spin.StyleName == "MyCustomStyle")
            {
                Console.WriteLine("Custom View StyleName property : test passed");
            }
            else
            {
                Console.WriteLine("Custom View StyleName property : test failed");
            }

            Console.WriteLine("### [3] CustomViewPropertyTest END");
        }



        public void ActorHandleTest()
        {
            Console.WriteLine("");
            Console.WriteLine("### [4] ActorHandleTest START");

            Handle handle = new Handle();
            int myPropertyIndex = handle.RegisterProperty("myProperty", new Property.Value(10.0f), Property.AccessMode.READ_WRITE);
            float myProperty = 0.0f;
            handle.GetProperty(myPropertyIndex).Get(ref myProperty);
            Console.WriteLine("myProperty value: " + myProperty);

            int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new Property.Value(new Size(5.0f, 5.0f, 5.0f)), Property.AccessMode.READ_WRITE);
            Size myProperty2 = new Size(0.0f, 0.0f, 0.0f);
            handle.GetProperty(myPropertyIndex2).Get(myProperty2);
            Console.WriteLine("myProperty2 value: " + myProperty2.Width + ", " + myProperty2.Height);

            Actor actor = new Actor();
            actor.Size = new Position(200.0f, 200.0f, 0.0f);
            actor.Name = "MyActor";
            Console.WriteLine("Actor id: {0}", actor.GetId());
            Console.WriteLine("Actor size: " + actor.Size.X + ", " + actor.Size.Y);
            Console.WriteLine("Actor name: " + actor.Name);

            Stage stage = Stage.GetCurrent();
            stage.BackgroundColor = Color.White;
            Size2D stageSize = stage.Size;
            Console.WriteLine("Stage size: " + stageSize.Width + ", " + stageSize.Height);
            stage.Add(actor);

            TextLabel text = new TextLabel("Hello World");
            text.ParentOrigin = NDalic.ParentOriginCenter;
            text.AnchorPoint = NDalic.AnchorPointCenter;
            text.HorizontalAlignment = "CENTER";
            stage.Add(text);

            Console.WriteLine("Text label text:  " + text.Text);

            Console.WriteLine("Text label point size:  " + text.PointSize);
            text.PointSize = 32.0f;
            Console.WriteLine("Text label new point size:  " + text.PointSize);

            Console.WriteLine("### [4] ActorHandleTest END");

        }



        public void RectanglePaddingClassTest()
        {
            Console.WriteLine("");
            Console.WriteLine("### [5] RectanglePaddingClassTest START");

            using (Rectangle r1 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine("    Created " + r1);
                Console.WriteLine("    IsEmpty() =  " + r1.IsEmpty());
                Console.WriteLine("    Left =  " + r1.Left());
                Console.WriteLine("    Right =  " + r1.Right());
                Console.WriteLine("    Top  = " + r1.Top());
                Console.WriteLine("    Bottom  = " + r1.Bottom());
                Console.WriteLine("    Area  = " + r1.Area());
            }

            Console.WriteLine(" *************************");

            using (Rectangle r2 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine("    Created " + r2);
                r2.Set(1, 1, 40, 40);
                Console.WriteLine("    IsEmpty() =  " + r2.IsEmpty());
                Console.WriteLine("    Left =  " + r2.Left());
                Console.WriteLine("    Right =  " + r2.Right());
                Console.WriteLine("    Top  = " + r2.Top());
                Console.WriteLine("    Bottom  = " + r2.Bottom());
                Console.WriteLine("    Area  = " + r2.Area());
            }

            Console.WriteLine(" *************************");

            Rectangle r3 = new Rectangle(10, 10, 20, 20);
            Rectangle r4 = new Rectangle(10, 10, 20, 20);

            if (r3 == r4)
            {
                Console.WriteLine("r3 == r4");
            }
            else
            {
                Console.WriteLine("r3 != r4");
            }

            r4 = new Rectangle(12, 10, 20, 20);

            if (r3 == r4)
            {
                Console.WriteLine("r3 == r4");
            }
            else
            {
                Console.WriteLine("r3 != r4");
            }

            PaddingType p1 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);
            PaddingType p2 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);

            if (p1 == p2)
            {
                Console.WriteLine("p1 == p2");
            }
            else
            {
                Console.WriteLine("p1 != p2");
            }

            p2 = new PaddingType(12.0f, 10.7f, 20.2f, 20.0f);

            if (p1 == p2)
            {
                Console.WriteLine("p1 == p2");
            }
            else
            {
                Console.WriteLine("p1 != p2");
            }
            Console.WriteLine("### [5] RectanglePaddingClassTest END");

        }


        public void SizePositionTest()
        {
            Console.WriteLine("");
            Console.WriteLine("### [6] SizePositionTest START");

            Size Size = new Size(100, 50, 25);
            Console.WriteLine("    Created " + Size);
            Console.WriteLine("    Size w =  " + Size.Width + ", h = " + Size.Height + ", d = " + Size.Depth);
            Size += new Size(20, 20, 20);
            Console.WriteLine("    Size w =  " + Size.Width + ", h = " + Size.Height + ", d = " + Size.Depth);
            Size.Width += 10;
            Size.Height += 10;
            Size.Depth += 10;
            Console.WriteLine("    Size width =  " + Size.Width+ ", height = " + Size.Height + ", depth = " + Size.Depth);

            Console.WriteLine(" *************************");
            Position Position = new Position(20, 100, 50);
            Console.WriteLine("    Created " + Position);
            Console.WriteLine("    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z);
            Position += new Position(20, 20, 20);
            Console.WriteLine("    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z);
            Position.X += 10;
            Position.Y += 10;
            Position.Z += 10;
            Console.WriteLine("    Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z);
            Position parentOrigin = ParentOrigin.BottomRight;
            Console.WriteLine("    parentOrigin x =  " + parentOrigin.X + ", y = " + parentOrigin.Y + ", z = " + parentOrigin.Z);

            Console.WriteLine(" *************************");
            Color color = new Color(20, 100, 50, 200);
            Console.WriteLine("    Created " + color);
            Console.WriteLine("    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A);
            color += new Color(20, 20, 20, 20);
            Console.WriteLine("    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A);
            color.R += 10;
            color.G += 10;
            color.B += 10;
            color.A += 10;
            Console.WriteLine("    Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A);

            Console.WriteLine("### [6] SizePositionTest END");
        }


        public void ViewDownCastTest()
        {
            Console.WriteLine("");
            Console.WriteLine("### [7] ViewDownCastTest START");

            View container = new View();
            container.Position = new Position(-800.0f, -800.0f, 0.0f);
            Stage.GetCurrent().Add(container);

            // Test downcast for native control
            TextLabel myLabel = new TextLabel();
            myLabel.Name = "MyLabelName";
            myLabel.Text = "MyText";

            Console.WriteLine("myLabel.Name = " + myLabel.Name + ", Text = " + myLabel.Text);

            container.Add(myLabel);

            Actor myLabelActor = container.FindChildByName("MyLabelName");
            if (myLabelActor)
            {
                TextLabel newLabel = View.DownCast<TextLabel>(myLabelActor);
                if (newLabel)
                {
                    Console.WriteLine("Downcast to TextLabel successful: newLabel Name = " + newLabel.Name + ", Text = " + newLabel.Text);
                }
                else
                {
                    Console.WriteLine("Downcast to TextLabel failed!");
                }
            }

            // Test downcast for class directly inherited from View
            MyView myView = new MyView();
            myView.Name = "MyViewName";
            myView.MyOwnName = "MyOwnViewName";
            myView._myCurrentValue = 5;

            Console.WriteLine("myView.Name = " + myView.Name + ", MyOwnName = " + myView.MyOwnName + ", myCurrentValue = " + myView._myCurrentValue);

            container.Add(myView);

            Actor myViewActor = container.FindChildByName("MyViewName");
            if (myViewActor)
            {
                MyView newView = View.DownCast<MyView>(myViewActor);
                if (newView)
                {
                    Console.WriteLine("Downcast to MyView successful: newView Name = " + newView.Name + ", MyOwnName = " + newView.MyOwnName + ", myCurrentValue = " + newView._myCurrentValue);
                }
                else
                {
                    Console.WriteLine("Downcast to MyView failed!");
                }
            }

            // Test downcast for class directly inherited from native control
            MyButton myButton = new MyButton();
            myButton.Name = "MyButtonName";
            myButton.MyOwnName = "MyOwnViewName";
            myButton.LabelText = "MyLabelText";
            myButton._myCurrentValue = 5;

            Console.WriteLine("myButton.Name = " + myButton.Name + ", MyOwnName = " + myButton.MyOwnName + ", LabelText = " + myButton.LabelText + ", myCurrentValue = " + myButton._myCurrentValue);

            container.Add(myButton);

            Actor myButtonActor = container.FindChildByName("MyButtonName");
            if (myButtonActor)
            {
                MyButton newButton = View.DownCast<MyButton>(myButtonActor);
                if (newButton)
                {
                    Console.WriteLine("Downcast to MyButton successful: newButton Name = " + newButton.Name + ", MyOwnName = " + newButton.MyOwnName + ", LabelText = " + myButton.LabelText + ", myCurrentValue = " + newButton._myCurrentValue);
                }
                else
                {
                    Console.WriteLine("Downcast to MyButton failed!");
                }
            }

            // Test downcast for a CustomView
            Spin spin = new Spin();
            spin.Name = "SpinName";
            spin.MaxValue = 8888;

            Console.WriteLine("spin.Name = " + spin.Name + ", MaxValue = " + spin.MaxValue);

            container.Add(spin);

            Actor spinActor = container.FindChildByName("SpinName");
            if (spinActor)
            {
                Spin newSpin = View.DownCast<Spin>(spinActor);
                if (newSpin)
                {
                    Console.WriteLine("Downcast to Spin successful: newSpin Name = " + newSpin.Name + ", MaxValue = " + newSpin.MaxValue);
                }
                else
                {
                    Console.WriteLine("Downcast to Spin failed!");
                }
            }

            // Test downcast for class inherited from a CustomView
            MySpin mySpin = new MySpin();
            mySpin.Name = "MySpinName";
            mySpin.MyOwnName = "MyOwnSpinName";
            mySpin.MaxValue = 8888;
            mySpin._myCurrentValue = 5;

            Console.WriteLine("mySpin.Name = " + mySpin.Name + ", MyOwnName = " + mySpin.MyOwnName + ", MaxValue = " + mySpin.MaxValue + ", currentValue = " + mySpin._myCurrentValue);

            container.Add(mySpin);

            Actor mySpinActor = container.FindChildByName("MySpinName");
            if (mySpinActor)
            {
                MySpin newSpin = View.DownCast<MySpin>(mySpinActor);
                if (newSpin)
                {
                    Console.WriteLine("Downcast to MySpin successful: newSpin Name = " + newSpin.Name + ", MyOwnName = " + newSpin.MyOwnName + ", MaxValue = " + newSpin.MaxValue + ", currentValue = " + newSpin._myCurrentValue);
                }
                else
                {
                    Console.WriteLine("Downcast to MySpin failed!");
                }
            }

            Console.WriteLine("### [7] ViewDownCastTest END");
        }

        public void MainLoop()
        {
            _application.MainLoop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Example example = new Example(Application.NewApplication());
            example.MainLoop();
        }

      private void LOG(string str, int result = -1)
      {
        if (result == 1) Console.WriteLine(str + " : test passed!");
        else if (result == 0) Console.WriteLine(str + " : test failed! TEST FAILED! test failed! TEST FAILED!");
        else Console.WriteLine(str);
      }

      private void CustomPropertyHighLevelClassTest()
      {
        LOG("=================================");
        LOG(" high level class test");
        LOG("=================================");

        Handle handle = new Handle();
        int myPropertyIndex1 = handle.RegisterProperty("myProperty1", new Property.Value(new Size(10, 20, 30)), Property.AccessMode.READ_WRITE);
        Size myProperty1 = Dali.Size.Zero;
        handle.GetProperty(myPropertyIndex1).Get(myProperty1);
        if (myProperty1.EqualTo(new Size(10, 20, 30))) LOG( "myProperty1 must be Size(10, 20, 30) get=" + myProperty1, 1);
        else LOG( "myProperty1 must be Size(10, 20, 30) get=" + myProperty1, 0);

        int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new Property.Value(new Position(40, 50, 60)), Property.AccessMode.READ_WRITE);
        Position myProperty2 = Dali.Position.Zero;
        handle.GetProperty(myPropertyIndex2).Get(myProperty2);
        if (myProperty2.EqualTo(new Position(40, 50, 60))) LOG( "myProperty2 must be Position(40, 50, 60) get=" + myProperty2, 1);
        else LOG( "myProperty2 must be Position(40, 50, 60) get=" + myProperty2, 0);

        int myPropertyIndex3 = handle.RegisterProperty("myProperty3", new Property.Value(Color.Cyan), Property.AccessMode.READ_WRITE);
        Color myProperty3 = Color.Transparent;
        handle.GetProperty(myPropertyIndex3).Get(myProperty3);
        if (myProperty3.EqualTo(Color.Cyan)) LOG( "myProperty3 must be Color.Cyan get=" + myProperty3, 1);
        else LOG( "myProperty3 must be Color.Cyan get=" + myProperty3, 0);

        int myPropertyIndex4 = handle.RegisterProperty("myProperty4", new Property.Value(new Size2D(100, 200)), Property.AccessMode.READ_WRITE);
        Size2D myProperty4 = new Size2D(0, 0);
        handle.GetProperty(myPropertyIndex4).Get(myProperty4);
        if (myProperty4.EqualTo(new Size2D(100, 200))) LOG( "myProperty4 must be new Size2D(100, 200) get=" + myProperty4, 1);
        else LOG( "myProperty4 must be new Size2D(100, 200) get=" + myProperty4, 0);

        int myPropertyIndex5 = handle.RegisterProperty("myProperty5", new Property.Value(new Position2D(200, 300)), Property.AccessMode.READ_WRITE);
        Position2D myProperty5 = new Position2D(0, 0);
        handle.GetProperty(myPropertyIndex5).Get(myProperty5);
        if (myProperty5.EqualTo(new Position2D(200, 300))) LOG( "myProperty5 must be new Position2D(200, 300) get=" + myProperty5, 1);
        else LOG( "myProperty5 must be new Position2D(200, 300) get=" + myProperty5, 0);

        View view = new View();
        view.Size2D = new Size2D(new Size(200.0f, 200.0f, 0.0f));
        view.Name = "MyView1";
        view.BackgroundColor = new Color(1.0f, 0.0f, 1.0f, 0.8f);
        LOG("view id: " + view.GetId());
        LOG("view size: " + view.Size.Width + ", " + view.Size.Height + "," + view.Size.Depth);
        LOG("view size2d: " + view.Size2D.Width + ", " + view.Size2D.Height);
        LOG("view name: " + view.Name);

        Stage stage = Stage.GetCurrent();
        Size2D stageSize = stage.Size;
        LOG("Stage size2d: " + stageSize.Width + ", " + stageSize.Height);
        stage.Add(view);

        Size Size = new Size(100, 50, 25);
        LOG( Size +  "Created. this should be (100, 50, 25)!");
        LOG( "Size width= " + Size.Width + ", height=" + Size.Height + ",depth=" + Size.Depth );
        Size += new Size(20, 20, 20);
        if(Size.EqualTo(new Size(120, 70, 45))){ LOG( "plus Size(20,20,20) should be +20 for each! x =  " + Size.Width + ", y = " + Size.Height + ", z = " + Size.Depth, 1);}
        else { LOG( "plus Size(20,20,20) should be +20 for each! x =  " + Size.Width + ", y = " + Size.Height + ", z = " + Size.Depth, 0);}

        Size.Width += 10;
        Size.Height += 10;
        Size.Depth += 10;
        if(Size.EqualTo(new Size(130, 80, 55))){ LOG( "plus 10 for each! width =  " + Size.Width + ", height = " + Size.Height + ", depth = " + Size.Depth, 1); }
        else { LOG( "plus 10 for each! width =  " + Size.Width + ", height = " + Size.Height + ", depth = " + Size.Depth, 0); }

        Position Position = new Position(20, 100, 50);
        LOG(Position + "Created ");
        LOG( "Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
        Position += new Position(20, 20, 20);
        if(Position.EqualTo(new Position(40, 120, 70))) LOG( "plus Position(20, 20, 20)! Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z, 1);
        else LOG( "plus Position(20, 20, 20)! Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z, 0);

        Position.X += 10;
        Position.Y += 10;
        Position.Z += 10;
        if(Position.EqualTo(new Position(50, 130, 80))) LOG( "plus +10 for each! Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z, 1 );
        else  LOG( "plus +10 for each! Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z, 0 );

        Position2D _position2d = new Position2D(new Position(600.0f, 700.0f, 800.0f));
        LOG(_position2d + "Created ");
        LOG( "_postion2d x =  " + _position2d.X + ", y = " + _position2d.Y);
        _position2d += new Position2D(20, 20);
        if(_position2d.EqualTo(new Position2D(620, 720))) LOG( "plus Position2D(20, 20)! Position x =  " + _position2d.X + ", y = " + _position2d.Y, 1);
        else LOG( "plus Position2D(20, 20)! Position x =  " + _position2d.X + ", y = " + _position2d.Y, 0);

        Position parentOrigin = ParentOrigin.BottomRight;
        LOG( "parentOrigin.BottomRight x=" + parentOrigin.X + ", y=" + parentOrigin.Y + ", z=" + parentOrigin.Z );

        Color color = new Color(20, 100, 50, 200);
        LOG( color +  "    Created ");
        LOG( "Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
        color += new Color(20, 20, 20, 20);
        if(color.EqualTo(new Color(40, 120, 70, 220))) LOG( "plus Color(20, 20, 20, 20)! Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A, 1 );
        else LOG( "plus Color(20, 20, 20, 20)! Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A, 0 );
        color.R += 10;
        color.G += 10;
        color.B += 10;
        color.A += 10;
        if(color.EqualTo(new Color(50, 130, 80, 230))) LOG( "plus +10 for each! Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A, 1 );
        else LOG( "plus +10 for each! Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A, 0 );

        LOG("=================================");
      }

    }
}

