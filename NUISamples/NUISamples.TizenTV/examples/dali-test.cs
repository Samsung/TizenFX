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
using Tizen.NUI;
using Tizen.NUI.Constants;

namespace DaliTest
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

    class Example : NUIApplication
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallbackDelegate(IntPtr appPtr); // void, void delgate

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

        public void Initialize()
        {
            NavigationPropertiesTests();

            OperatorTests();

            CustomViewPropertyTest();

            Handle handle = new Handle();
            int myPropertyIndex = handle.RegisterProperty("myProperty", new PropertyValue(10.0f), PropertyAccessMode.ReadWrite);
            float myProperty = 0.0f;
            handle.GetProperty(myPropertyIndex).Get(ref myProperty);
            Console.WriteLine( "myProperty value: " + myProperty );

            int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new PropertyValue(new Size(5.0f, 5.0f, 0.0f)), PropertyAccessMode.ReadWrite);
            Size myProperty2 = new Size(0.0f, 0.0f, 0.0f);
            handle.GetProperty(myPropertyIndex2).Get(myProperty2);
            Console.WriteLine( "myProperty2 value: " + myProperty2.Width + ", " + myProperty2.Height );

            Actor actor = new Actor();
            actor.Size = new Size(200.0f, 200.0f, 0.0f);
            actor.Name = "MyActor";
            actor.MixColor = new Color(1.0f, 0.0f, 1.0f, 0.8f);
            Console.WriteLine("Actor size: " + actor.Size.Width + ", " + actor.Size.Height);
            Console.WriteLine("Actor name: " + actor.Name);

            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;
            Size stageSize = new Size(stage.Size.Width, stage.Size.Height, 0.0f);
            Console.WriteLine("Stage size: " + stageSize.Width + ", " + stageSize.Height);
            stage.GetDefaultLayer().Add(actor);

            TextLabel text = new TextLabel("Hello Mono World");
            text.ParentOrigin = ParentOrigin.Center;
            text.AnchorPoint = AnchorPoint.Center;
            text.HorizontalAlignment = "CENTER";
            stage.GetDefaultLayer().Add(text);

            Console.WriteLine( "Text label text:  " + text.Text );

            Console.WriteLine( "Text label point size:  " + text.PointSize );
            text.PointSize = 32.0f;
            Console.WriteLine( "Text label new point size:  " + text.PointSize );

            RectanglePaddingClassTest();

            Console.WriteLine( " *************************" );
            Size Size = new Size(100, 50, 0);
            Console.WriteLine( "    Created " + Size );
            Console.WriteLine( "    Size x =  " + Size.Width + ", y = " + Size.Height );
            Size += new Size(20, 20, 0);
            Console.WriteLine( "    Size x =  " + Size.Width + ", y = " + Size.Height );
            Size.Width += 10;
            Size.Height += 10;
            Console.WriteLine( "    Size width =  " + Size.Width + ", height = " + Size.Height );

            Console.WriteLine( " *************************" );
            Position Position = new Position(20, 100, 50);
            Console.WriteLine( "    Created " + Position );
            Console.WriteLine( "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position += new Position(20, 20, 20);
            Console.WriteLine( "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position.X += 10;
            Position.Y += 10;
            Position.Z += 10;
            Console.WriteLine( "    Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z );

            Console.WriteLine( " *************************" );
            Color color = new Color(20, 100, 50, 200);
            Console.WriteLine( "    Created " + color );
            Console.WriteLine( "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color += new Color(20, 20, 20, 20);
            Console.WriteLine( "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color.R += 10;
            color.G += 10;
            color.B += 10;
            color.A += 10;
            Console.WriteLine( "    Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A );

            ViewDownCastTest();
        }

        public void RectanglePaddingClassTest()
        {
            using (Rectangle r1 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine( "    Created " + r1 );
                Console.WriteLine( "    IsEmpty() =  " + r1.IsEmpty() );
                Console.WriteLine( "    Left =  " + r1.Left() );
                Console.WriteLine( "    Right =  " + r1.Right() );
                Console.WriteLine( "    Top  = " + r1.Top() );
                Console.WriteLine( "    Bottom  = " + r1.Bottom() );
                Console.WriteLine( "    Area  = " + r1.Area() );
            }

            Console.WriteLine( " *************************" );

            using (Rectangle r2 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine( "    Created " + r2 );
                r2.Set(1,1,40,40);
                Console.WriteLine( "    IsEmpty() =  " + r2.IsEmpty() );
                Console.WriteLine( "    Left =  " + r2.Left() );
                Console.WriteLine( "    Right =  " + r2.Right() );
                Console.WriteLine( "    Top  = " + r2.Top() );
                Console.WriteLine( "    Bottom  = " + r2.Bottom() );
                Console.WriteLine( "    Area  = " + r2.Area() );
            }

            Console.WriteLine( " *************************" );

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
        }

        public void NavigationPropertiesTests()
        {
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

            Stage.Instance.GetDefaultLayer().Add(leftView);
            Stage.Instance.GetDefaultLayer().Add(rightView);
            Stage.Instance.GetDefaultLayer().Add(upView);
            Stage.Instance.GetDefaultLayer().Add(downView);

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

            Stage.Instance.GetDefaultLayer().Add(view);

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

            Stage.Instance.GetDefaultLayer().Remove(leftView);
            tmpView = view.LeftFocusableView;
            if (!tmpView)
            {
                Console.WriteLine("Passed: NULL LeftFocusedView");
            }
            else
            {
                Console.WriteLine("Failed: LeftFocusedView = " + tmpView.Name);
            }
        }

        public void OperatorTests()
        {
            Actor actor = new Actor();
            Actor differentActor = new Actor();
            Actor actorSame = actor;
            Actor nullActor = null;

            // test the true operator
            if ( actor )
            {
                Console.WriteLine ("BaseHandle Operator true (actor) : test passed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator true (actor): test failed ");
            }

            Actor parent = actor.Parent;

            if ( parent )
            {
                Console.WriteLine ("Handle with Empty body  :failed ");
            }
            else
            {
                Console.WriteLine ("Valid with Empty body  :passed ");
            }

            actor.Add( differentActor );

            // here we test two different C# objects, which on the native side have the same body/ ref-object
            if ( actor == differentActor.Parent )
            {
                Console.WriteLine ("actor == differentActor.GetParent() :passed ");
            }
            else
            {
                Console.WriteLine ("actor == differentActor.GetParent() :failed ");
            }

            if ( differentActor == differentActor.Parent )
            {
                Console.WriteLine ("differentActor == differentActor.GetParent() :failed ");
            }
            else
            {
                Console.WriteLine ("differentActor == differentActor.GetParent() :passed ");
            }

            if ( nullActor )
            {
                Console.WriteLine ("BaseHandle Operator true (nullActor) : test failed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator true (nullActor): test passed ");
            }

            // ! operator
            if ( !actor )
            {
                Console.WriteLine ("BaseHandle Operator !(actor) : test failed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator !(actor): test passed ");
            }

            if ( !nullActor )
            {
                Console.WriteLine ("BaseHandle Operator !(nullActor) : test passed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator !(nullActor): test failed ");
            }

            // Note: operator false only used inside & operator
            // test equality operator ==
            if ( actor == actorSame )
            {
                Console.WriteLine ("BaseHandle Operator  (actor == actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator  (actor == actorSame) : test failed");
            }

            if ( actor == differentActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor == differentActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor == differentActor) : test passed");
            }

            if ( actor == nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor == nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor == nullActor) : test passed");
            }

            if ( nullActor == nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor == nullActor) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor == nullActor) : test failed");
            }

            // test || operator
            if ( actor || actorSame )
            {
                Console.WriteLine ("BaseHandle Operator (actor || actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor || actorSame) : test failed");
            }

            if ( actor || nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor || nullActor) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor || nullActor) : test failed");
            }

            if ( nullActor || nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor || nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor || nullActor) : test passed");
            }

            // test && operator
            if ( actor && actorSame )
            {
                Console.WriteLine ("BaseHandle Operator (actor && actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor && actorSame) : test failed");
            }

            if ( actor && nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor && nullActor) : test passed");
            }

            if ( nullActor && nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor && nullActor) : test passed");
            }
        }

        public void CustomViewPropertyTest()
        {
            // Create a Spin control
            Spin spin = new Spin();

            // Background property
            PropertyMap background = new PropertyMap();
            background.Add( Visual.Property.Type, new PropertyValue((int)Visual.Type.Color) )
                      .Add( ColorVisualProperty.MixColor, new PropertyValue(Color.Red) );
            spin.Background = background;

            background = spin.Background;
            Color backgroundColor = new Color();
            background.Find(ColorVisualProperty.MixColor).Get(backgroundColor);
            if( backgroundColor == Color.Red )
            {
                Console.WriteLine ("Custom View Background property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View Background property : test failed");
            }

            // BackgroundColor property
            spin.BackgroundColor = Color.Yellow;
            if(spin.BackgroundColor == Color.Yellow)
            {
                Console.WriteLine ("Custom View BackgroundColor property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View BackgroundColor property : test failed");
            }

            // BackgroundImage property
            spin.BackgroundImage = "background-image.jpg";
            if(spin.BackgroundImage == "background-image.jpg")
            {
                Console.WriteLine ("Custom View BackgroundImage property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View BackgroundImage property : test failed");
            }

            // StyleName property
            spin.StyleName = "MyCustomStyle";
            if(spin.StyleName == "MyCustomStyle")
            {
                Console.WriteLine ("Custom View StyleName property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View StyleName property : test failed");
            }
        }

        public void ViewDownCastTest()
        {
          View container = new View();
          container.Position = new Position(-800.0f, -800.0f, 0.0f);
          Stage.Instance.GetDefaultLayer().Add(container);

          // Test downcast for native control
          TextLabel myLabel = new TextLabel();
          myLabel.Name = "MyLabelName";
          myLabel.Text = "MyText";

          Console.WriteLine("myLabel.Name = " + myLabel.Name + ", Text = " + myLabel.Text);

          container.Add(myLabel);

          Actor myLabelActor  = container.FindChildByName("MyLabelName");
          if(myLabelActor)
          {
            TextLabel newLabel = View.DownCast<TextLabel>(myLabelActor);
            if(newLabel)
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

          Actor myViewActor  = container.FindChildByName("MyViewName");
          if(myViewActor)
          {
            MyView newView = View.DownCast<MyView>(myViewActor);
            if(newView)
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

          Actor myButtonActor  = container.FindChildByName("MyButtonName");
          if(myButtonActor)
          {
            MyButton newButton = View.DownCast<MyButton>(myButtonActor);
            if(newButton)
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

          Actor spinActor  = container.FindChildByName("SpinName");
          if(spinActor)
          {
            Spin newSpin = View.DownCast<Spin>(spinActor);
            if(newSpin)
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

          Actor mySpinActor  = container.FindChildByName("MySpinName");
          if(mySpinActor)
          {
            MySpin newSpin = View.DownCast<MySpin>(mySpinActor);
            if(newSpin)
            {
              Console.WriteLine("Downcast to MySpin successful: newSpin Name = " + newSpin.Name + ", MyOwnName = " + newSpin.MyOwnName + ", MaxValue = " + newSpin.MaxValue + ", currentValue = " + newSpin._myCurrentValue);
            }
            else
            {
              Console.WriteLine("Downcast to MySpin failed!");
            }
          }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Console.WriteLine ("Hello Mono World");

            Example example = new Example();
            example.Run(args);
        }
    }
}
