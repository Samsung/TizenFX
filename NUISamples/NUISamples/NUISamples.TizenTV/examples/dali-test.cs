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
using Tizen.NUI.UIComponents;
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
            DowncastTest();

            NavigationPropertiesTests();

            OperatorTests();

            CustomViewPropertyTest();

            Handle handle = new Handle();
            int myPropertyIndex = handle.RegisterProperty("myProperty", new PropertyValue(10.0f), PropertyAccessMode.ReadWrite);
            float myProperty = 0.0f;
            handle.GetProperty(myPropertyIndex).Get(ref myProperty);
            Tizen.Log.Debug("NUI",  "myProperty value: " + myProperty );

            int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new PropertyValue(new Size(5.0f, 5.0f, 0.0f)), PropertyAccessMode.ReadWrite);
            Size myProperty2 = new Size(0.0f, 0.0f, 0.0f);
            handle.GetProperty(myPropertyIndex2).Get(myProperty2);
            Tizen.Log.Debug("NUI",  "myProperty2 value: " + myProperty2.Width + ", " + myProperty2.Height );

            Actor actor = new Actor();
            actor.Size = new Size(200.0f, 200.0f, 0.0f);
            actor.Name = "MyActor";
            //actor.MixColor = new Color(1.0f, 0.0f, 1.0f, 0.8f);
            Tizen.Log.Debug("NUI", "Actor size: " + actor.Size.Width + ", " + actor.Size.Height);
            Tizen.Log.Debug("NUI", "Actor name: " + actor.Name);

            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;
            Size stageSize = new Size(stage.Size.Width, stage.Size.Height, 0.0f);
            Tizen.Log.Debug("NUI", "Stage size: " + stageSize.Width + ", " + stageSize.Height);
            stage.GetDefaultLayer().Add(actor);

            TextLabel text = new TextLabel("Hello Mono World");
            text.ParentOrigin = ParentOrigin.Center;
            text.AnchorPoint = AnchorPoint.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            stage.GetDefaultLayer().Add(text);

            Tizen.Log.Debug("NUI",  "Text label text:  " + text.Text );

            Tizen.Log.Debug("NUI",  "Text label point size:  " + text.PointSize );
            text.PointSize = 32.0f;
            Tizen.Log.Debug("NUI",  "Text label new point size:  " + text.PointSize );

            RectanglePaddingClassTest();

            Tizen.Log.Debug("NUI",  " *************************" );
            Size Size = new Size(100, 50, 0);
            Tizen.Log.Debug("NUI",  "    Created " + Size );
            Tizen.Log.Debug("NUI",  "    Size x =  " + Size.Width + ", y = " + Size.Height );
            Size += new Size(20, 20, 0);
            Tizen.Log.Debug("NUI",  "    Size x =  " + Size.Width + ", y = " + Size.Height );
            Size.Width += 10;
            Size.Height += 10;
            Tizen.Log.Debug("NUI",  "    Size width =  " + Size.Width + ", height = " + Size.Height );

            Tizen.Log.Debug("NUI",  " *************************" );
            Position Position = new Position(20, 100, 50);
            Tizen.Log.Debug("NUI",  "    Created " + Position );
            Tizen.Log.Debug("NUI",  "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position += new Position(20, 20, 20);
            Tizen.Log.Debug("NUI",  "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position.X += 10;
            Position.Y += 10;
            Position.Z += 10;
            Tizen.Log.Debug("NUI",  "    Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z );

            Tizen.Log.Debug("NUI",  " *************************" );
            Color color = new Color(20, 100, 50, 200);
            Tizen.Log.Debug("NUI",  "    Created " + color );
            Tizen.Log.Debug("NUI",  "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color += new Color(20, 20, 20, 20);
            Tizen.Log.Debug("NUI",  "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color.R += 10;
            color.G += 10;
            color.B += 10;
            color.A += 10;
            Tizen.Log.Debug("NUI",  "    Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A );

            ViewDownCastTest();
        }

        public void RectanglePaddingClassTest()
        {
            using (Rectangle r1 = new Rectangle(2, 5, 20, 30))
            {
                Tizen.Log.Debug("NUI",  "    Created " + r1 );
                Tizen.Log.Debug("NUI",  "    IsEmpty() =  " + r1.IsEmpty() );
                Tizen.Log.Debug("NUI",  "    Left =  " + r1.Left() );
                Tizen.Log.Debug("NUI",  "    Right =  " + r1.Right() );
                Tizen.Log.Debug("NUI",  "    Top  = " + r1.Top() );
                Tizen.Log.Debug("NUI",  "    Bottom  = " + r1.Bottom() );
                Tizen.Log.Debug("NUI",  "    Area  = " + r1.Area() );
            }

            Tizen.Log.Debug("NUI",  " *************************" );

            using (Rectangle r2 = new Rectangle(2, 5, 20, 30))
            {
                Tizen.Log.Debug("NUI",  "    Created " + r2 );
                r2.Set(1,1,40,40);
                Tizen.Log.Debug("NUI",  "    IsEmpty() =  " + r2.IsEmpty() );
                Tizen.Log.Debug("NUI",  "    Left =  " + r2.Left() );
                Tizen.Log.Debug("NUI",  "    Right =  " + r2.Right() );
                Tizen.Log.Debug("NUI",  "    Top  = " + r2.Top() );
                Tizen.Log.Debug("NUI",  "    Bottom  = " + r2.Bottom() );
                Tizen.Log.Debug("NUI",  "    Area  = " + r2.Area() );
            }

            Tizen.Log.Debug("NUI",  " *************************" );

            Rectangle r3 = new Rectangle(10, 10, 20, 20);
            Rectangle r4 = new Rectangle(10, 10, 20, 20);

            if (r3 == r4)
            {
                Tizen.Log.Debug("NUI", "r3 == r4");
            }
            else
            {
                Tizen.Log.Debug("NUI", "r3 != r4");
            }

            r4 = new Rectangle(12, 10, 20, 20);

            if (r3 == r4)
            {
                Tizen.Log.Debug("NUI", "r3 == r4");
            }
            else
            {
                Tizen.Log.Debug("NUI", "r3 != r4");
            }

            PaddingType p1 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);
            PaddingType p2 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);

            if (p1 == p2)
            {
                Tizen.Log.Debug("NUI", "p1 == p2");
            }
            else
            {
                Tizen.Log.Debug("NUI", "p1 != p2");
            }

            p2 = new PaddingType(12.0f, 10.7f, 20.2f, 20.0f);

            if (p1 == p2)
            {
                Tizen.Log.Debug("NUI", "p1 == p2");
            }
            else
            {
                Tizen.Log.Debug("NUI", "p1 != p2");
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
                Tizen.Log.Debug("NUI", "Passed: LeftFocusedView = " + tmpView.Name);
            }
            else
            {
                Tizen.Log.Debug("NUI", "Failed: LeftFocusedView = " + tmpView.Name);
            }

            view.RightFocusableView = rightView;
            tmpView = view.RightFocusableView;
            if (string.Compare(tmpView.Name, "rightView") == 0)
            {
                Tizen.Log.Debug("NUI", "Passed: RightFocusedView = " + tmpView.Name);
            }
            else
            {
                Tizen.Log.Debug("NUI", "Failed: RightFocusedView = " + tmpView.Name);
            }

            Stage.Instance.GetDefaultLayer().Add(view);

            view.UpFocusableView = upView;
            tmpView = view.UpFocusableView;
            if (string.Compare(tmpView.Name, "upView") == 0)
            {
                Tizen.Log.Debug("NUI", "Passed: UpFocusedView = " + tmpView.Name);
            }
            else
            {
                Tizen.Log.Debug("NUI", "Failed: UpFocusedView = " + tmpView.Name);
            }

            view.DownFocusableView = downView;
            tmpView = view.DownFocusableView;
            if (string.Compare(tmpView.Name, "downView") == 0)
            {
                Tizen.Log.Debug("NUI", "Passed: DownFocusedView = " + tmpView.Name);
            }
            else
            {
                Tizen.Log.Debug("NUI", "Failed: DownFocusedView = " + tmpView.Name);
            }

            Stage.Instance.GetDefaultLayer().Remove(leftView);
            tmpView = view.LeftFocusableView;
            if (!tmpView)
            {
                Tizen.Log.Debug("NUI", "Passed: NULL LeftFocusedView");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Failed: LeftFocusedView = " + tmpView.Name);
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
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (actor) : test passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (actor): test failed ");
            }

            Actor parent = actor.Parent;

            if ( parent )
            {
                Tizen.Log.Debug("NUI", "Handle with Empty body  :failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Valid with Empty body  :passed ");
            }

            actor.Add( differentActor );

            // here we test two different C# objects, which on the native side have the same body/ ref-object
            if ( actor == differentActor.Parent )
            {
                Tizen.Log.Debug("NUI", "actor == differentActor.GetParent() :passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "actor == differentActor.GetParent() :failed ");
            }

            if ( differentActor == differentActor.Parent )
            {
                Tizen.Log.Debug("NUI", "differentActor == differentActor.GetParent() :failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "differentActor == differentActor.GetParent() :passed ");
            }

            if ( nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (nullActor) : test failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (nullActor): test passed ");
            }

            // ! operator
            if ( !actor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(actor) : test failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(actor): test passed ");
            }

            if ( !nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(nullActor) : test passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(nullActor): test failed ");
            }

            // Note: operator false only used inside & operator
            // test equality operator ==
            if ( actor == actorSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator  (actor == actorSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator  (actor == actorSame) : test failed");
            }

            if ( actor == differentActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor == differentActor) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor == differentActor) : test passed");
            }

            if ( actor == nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor == nullActor) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor == nullActor) : test passed");
            }

            if ( nullActor == nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor == nullActor) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor == nullActor) : test failed");
            }

            // test || operator
            if ( actor || actorSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor || actorSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor || actorSame) : test failed");
            }

            if ( actor || nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor || nullActor) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor || nullActor) : test failed");
            }

            if ( nullActor || nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor || nullActor) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor || nullActor) : test passed");
            }

            // test && operator
            if ( actor && actorSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor && actorSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor && actorSame) : test failed");
            }

            if ( actor && nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor && nullActor) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (actor && nullActor) : test passed");
            }

            if ( nullActor && nullActor )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor && nullActor) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullActor && nullActor) : test passed");
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
                Tizen.Log.Debug("NUI", "Custom View Background property : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Custom View Background property : test failed");
            }

            // BackgroundColor property
            spin.BackgroundColor = Color.Yellow;
            if(spin.BackgroundColor == Color.Yellow)
            {
                Tizen.Log.Debug("NUI", "Custom View BackgroundColor property : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Custom View BackgroundColor property : test failed");
            }

            // BackgroundImage property
            spin.BackgroundImage = "background-image.jpg";
            if(spin.BackgroundImage == "background-image.jpg")
            {
                Tizen.Log.Debug("NUI", "Custom View BackgroundImage property : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Custom View BackgroundImage property : test failed");
            }

            // StyleName property
            spin.StyleName = "MyCustomStyle";
            if(spin.StyleName == "MyCustomStyle")
            {
                Tizen.Log.Debug("NUI", "Custom View StyleName property : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Custom View StyleName property : test failed");
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

          Tizen.Log.Debug("NUI", "myLabel.Name = " + myLabel.Name + ", Text = " + myLabel.Text);

          container.Add(myLabel);

          Actor myLabelActor  = container.FindChildByName("MyLabelName");
          if(myLabelActor)
          {
            TextLabel newLabel = View.DownCast<TextLabel>(myLabelActor);
            if(newLabel)
            {
              Tizen.Log.Debug("NUI", "Downcast to TextLabel successful: newLabel Name = " + newLabel.Name + ", Text = " + newLabel.Text);
            }
            else
            {
              Tizen.Log.Debug("NUI", "Downcast to TextLabel failed!");
            }
          }

          // Test downcast for class directly inherited from View
          MyView myView = new MyView();
          myView.Name = "MyViewName";
          myView.MyOwnName = "MyOwnViewName";
          myView._myCurrentValue = 5;

          Tizen.Log.Debug("NUI", "myView.Name = " + myView.Name + ", MyOwnName = " + myView.MyOwnName + ", myCurrentValue = " + myView._myCurrentValue);

          container.Add(myView);

          Actor myViewActor  = container.FindChildByName("MyViewName");
          if(myViewActor)
          {
            MyView newView = View.DownCast<MyView>(myViewActor);
            if(newView)
            {
              Tizen.Log.Debug("NUI", "Downcast to MyView successful: newView Name = " + newView.Name + ", MyOwnName = " + newView.MyOwnName + ", myCurrentValue = " + newView._myCurrentValue);
            }
            else
            {
              Tizen.Log.Debug("NUI", "Downcast to MyView failed!");
            }
          }

          // Test downcast for class directly inherited from native control
          MyButton myButton = new MyButton();
          myButton.Name = "MyButtonName";
          myButton.MyOwnName = "MyOwnViewName";
          myButton.LabelText = "MyLabelText";
          myButton._myCurrentValue = 5;

          Tizen.Log.Debug("NUI", "myButton.Name = " + myButton.Name + ", MyOwnName = " + myButton.MyOwnName + ", LabelText = " + myButton.LabelText + ", myCurrentValue = " + myButton._myCurrentValue);

          container.Add(myButton);

          Actor myButtonActor  = container.FindChildByName("MyButtonName");
          if(myButtonActor)
          {
            MyButton newButton = View.DownCast<MyButton>(myButtonActor);
            if(newButton)
            {
              Tizen.Log.Debug("NUI", "Downcast to MyButton successful: newButton Name = " + newButton.Name + ", MyOwnName = " + newButton.MyOwnName + ", LabelText = " + myButton.LabelText + ", myCurrentValue = " + newButton._myCurrentValue);
            }
            else
            {
              Tizen.Log.Debug("NUI", "Downcast to MyButton failed!");
            }
          }

          // Test downcast for a CustomView
          Spin spin = new Spin();
          spin.Name = "SpinName";
          spin.MaxValue = 8888;

          Tizen.Log.Debug("NUI", "spin.Name = " + spin.Name + ", MaxValue = " + spin.MaxValue);

          container.Add(spin);

          Actor spinActor  = container.FindChildByName("SpinName");
          if(spinActor)
          {
            Spin newSpin = View.DownCast<Spin>(spinActor);
            if(newSpin)
            {
              Tizen.Log.Debug("NUI", "Downcast to Spin successful: newSpin Name = " + newSpin.Name + ", MaxValue = " + newSpin.MaxValue);
            }
            else
            {
              Tizen.Log.Debug("NUI", "Downcast to Spin failed!");
            }
          }

          // Test downcast for class inherited from a CustomView
          MySpin mySpin = new MySpin();
          mySpin.Name = "MySpinName";
          mySpin.MyOwnName = "MyOwnSpinName";
          mySpin.MaxValue = 8888;
          mySpin._myCurrentValue = 5;

          Tizen.Log.Debug("NUI", "mySpin.Name = " + mySpin.Name + ", MyOwnName = " + mySpin.MyOwnName + ", MaxValue = " + mySpin.MaxValue + ", currentValue = " + mySpin._myCurrentValue);

          container.Add(mySpin);

          Actor mySpinActor  = container.FindChildByName("MySpinName");
          if(mySpinActor)
          {
            MySpin newSpin = View.DownCast<MySpin>(mySpinActor);
            if(newSpin)
            {
              Tizen.Log.Debug("NUI", "Downcast to MySpin successful: newSpin Name = " + newSpin.Name + ", MyOwnName = " + newSpin.MyOwnName + ", MaxValue = " + newSpin.MaxValue + ", currentValue = " + newSpin._myCurrentValue);
            }
            else
            {
              Tizen.Log.Debug("NUI", "Downcast to MySpin failed!");
            }
          }
        }



        public void DowncastTest()
        {
            //Create a View as a child of parent View, get it use parent.GetChildAt(i), then DownCast to View handle, but call BackgroundColor property will crash.
            View parent = new View();
            View[] childs = new View[5];

            for (int i = 0; i < 5; i++)
            {
                childs[i] = new View();
                childs[i].Name = "child_view_" + i;
                childs[i].BackgroundColor = Color.Red;
                parent.Add(childs[i]);
            }

            for (uint i = 0; i < parent.GetChildCount(); i++)
            {
                Actor child = parent.GetChildAt(i);
                View childView = View.DownCast<View>(child);
                if (childView)
                {
                    Tizen.Log.Debug("NUI", "Type[" + childView.GetTypeName() + "] BGColor[" + childView.BackgroundColor.R + "]" + " Name[" + childView.Name + "]");
                }
            }

            PushButton button = new PushButton();
            button.LabelText = "ButtonTest!";
            button.BackgroundColor = Color.White;
            View parentView = new View();
            parentView.Add(button);
            PushButton view = PushButton.DownCast(parentView.GetChildAt(0));
            if (view)
            {
                Tizen.Log.Debug("NUI", "NUI view GetTypeName= " + view.GetTypeName());
                Tizen.Log.Debug("NUI", "NUI view LabelText= " + view.LabelText);
                Tizen.Log.Debug("NUI", "NUI view color= " +  view.BackgroundColor.R);
            }
        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Hello Mono World");

            Example example = new Example();
            example.Run(args);
        }
    }
}
