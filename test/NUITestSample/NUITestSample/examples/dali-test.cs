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
using Tizen.NUI.BaseComponents;
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
        //private const string _resPath = "/home/owner/apps_rw/NUISamples.TizenTV/res";
        private const string _resPath = "./res";  //for ubuntu

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

            VisibilityChangeTest();

            ResourceReadyTest();

            ViewFocusTest();

            WindowDevelPropertyTest();

            Animatable handle = new Animatable();
            int myPropertyIndex = handle.RegisterProperty("myProperty", new PropertyValue(10.0f), PropertyAccessMode.ReadWrite);
            float myProperty = 0.0f;
            handle.GetProperty(myPropertyIndex).Get(out myProperty);
            Tizen.Log.Debug("NUI",  "myProperty value: " + myProperty );

            int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new PropertyValue(new Size(5.0f, 5.0f, 0.0f)), PropertyAccessMode.ReadWrite);
            Size2D myProperty2 = new Size2D(0, 0);
            handle.GetProperty(myPropertyIndex2).Get(myProperty2);
            Tizen.Log.Debug("NUI",  "myProperty2 value: " + myProperty2.Width + ", " + myProperty2.Height );

            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.Name = "MyView";
            //view.MixColor = new Color(1.0f, 0.0f, 1.0f, 0.8f);
            Tizen.Log.Debug("NUI", "View size: " + view.Size2D.Width + ", " + view.Size2D.Height);
            Tizen.Log.Debug("NUI", "View name: " + view.Name);

            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            Size windowSize = new Size(window.Size.Width, window.Size.Height, 0.0f);
            Tizen.Log.Debug("NUI", "Window size: " + windowSize.Width + ", " + windowSize.Height);
            window.Add(view);

            TextLabel text = new TextLabel("Hello Mono World");
            text.ParentOrigin = ParentOrigin.Center;
            text.PivotPoint = PivotPoint.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            window.Add(text);

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

            Window.Instance.Add(leftView);
            Window.Instance.Add(rightView);
            Window.Instance.Add(upView);
            Window.Instance.Add(downView);

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

            Window.Instance.Add(view);

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

            Window.Instance.Remove(leftView);
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
            View view = new View();
            View differentView = new View();
            View viewSame = view;
            View nullView = null;

            // test the true operator
            if ( view )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (view) : test passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (view): test failed ");
            }

            View parent = view.Parent;

            if ( parent )
            {
                Tizen.Log.Debug("NUI", "Handle with Empty body  :failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "Valid with Empty body  :passed ");
            }

            view.Add( differentView );

            // here we test two different C# objects, which on the native side have the same body/ ref-object
            if ( view == differentView.Parent )
            {
                Tizen.Log.Debug("NUI", "view == differentView.GetParent() :passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "view == differentView.GetParent() :failed ");
            }

            if ( differentView == differentView.Parent )
            {
                Tizen.Log.Debug("NUI", "differentView == differentView.GetParent() :failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "differentView == differentView.GetParent() :passed ");
            }

            if ( nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (nullView) : test failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator true (nullView): test passed ");
            }

            // ! operator
            if ( !view )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(view) : test failed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(view): test passed ");
            }

            if ( !nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(nullView) : test passed ");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator !(nullView): test failed ");
            }

            // Note: operator false only used inside & operator
            // test equality operator ==
            if ( view == viewSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator  (view == viewSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator  (view == viewSame) : test failed");
            }

            if ( view == differentView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view == differentView) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view == differentView) : test passed");
            }

            if ( view == nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view == nullView) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view == nullView) : test passed");
            }

            if ( nullView == nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView == nullView) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView == nullView) : test failed");
            }

            // test || operator
            if ( view || viewSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view || viewSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view || viewSame) : test failed");
            }

            if ( view || nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view || nullView) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view || nullView) : test failed");
            }

            if ( nullView || nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView || nullView) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView || nullView) : test passed");
            }

            // test && operator
            if ( view && viewSame )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view && viewSame) : test passed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view && viewSame) : test failed");
            }

            if ( view && nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view && nullView) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (view && nullView) : test passed");
            }

            if ( nullView && nullView )
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView && nullView) : test failed");
            }
            else
            {
                Tizen.Log.Debug("NUI", "BaseHandle Operator (nullView && nullView) : test passed");
            }
        }


        private TextLabel label;
        public void VisibilityChangeTest()
        {
            label = new TextLabel();
            label.Text = "Visibility";
            label.TextColor = Color.Red;
            label.PointSize = 30.0f;
            label.ParentOrigin = ParentOrigin.TopLeft;
            label.PivotPoint = PivotPoint.TopLeft;
            label.Position = new Position(0.0f, 50.0f, 0.0f);
            Window.Instance.Add(label);
            label.VisibilityChanged += (sender, e) =>
            {
                if (e.Visibility)
                    Tizen.Log.Debug("NUI", "VisibilityChanged, label show.");
                else
                    Tizen.Log.Debug("NUI", "VisibilityChanged, label hide.");
            };

            PushButton button = new PushButton();
            button.LabelText = "Change Visibility";
            button.ParentOrigin = ParentOrigin.TopLeft;
            button.PivotPoint = PivotPoint.TopLeft;
            Window.Instance.Add(button);
            button.Clicked += (sender, e) =>
            {
                if (label.Visible)
                {
                    label.Hide();
                }
                else
                {
                    label.Show();
                }

                return true;
            };
        }

        public void ResourceReadyTest()
        {
            ImageView image = new ImageView();
            image.ResourceUrl = _resPath + "/images/dog-anim.gif";
            image.Size2D = new Size2D(150, 150);
            image.ParentOrigin = ParentOrigin.TopLeft;
            image.PivotPoint = PivotPoint.TopLeft;
            image.Position = new Position(0.0f, 150.0f, 0.0f);
            image.ResourceReady += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "Resource is ready!");
            };
            Window.Instance.Add(image);
        }

        public void ViewFocusTest()
        {
            View view1 = new View();
            view1.BackgroundColor = Color.Red;
            view1.Size2D = new Size2D(80, 50);
            view1.ParentOrigin = ParentOrigin.CenterLeft;
            view1.PivotPoint = PivotPoint.CenterLeft;
            view1.Position = new Position(10.0f, 50.0f, 0.0f);
            view1.Focusable = true;
            View view2 = new View();
            view2.BackgroundColor = Color.Cyan;
            view2.Size2D = new Size2D(80, 50);
            view2.ParentOrigin = ParentOrigin.CenterLeft;
            view2.PivotPoint = PivotPoint.CenterLeft;
            view2.Position = new Position(100.0f, 50.0f, 0.0f);
            view2.Focusable = true;
            view1.RightFocusableView = view2;
            view2.LeftFocusableView = view1;
            Window.Instance.Add(view1);
            Window.Instance.Add(view2);
            FocusManager.Instance.SetCurrentFocusView(view1);

            PushButton button = new PushButton();
            button.LabelText = "Focus Back";
            button.Size2D = new Size2D(150, 50);
            button.ParentOrigin = ParentOrigin.CenterLeft;
            button.PivotPoint = PivotPoint.CenterLeft;
            button.Position = new Position(190.0f, 50.0f, 0.0f);

            button.Focusable = true;
            view2.RightFocusableView = button;
 
            button.Pressed += (obj, e) =>
            {
                FocusManager.Instance.MoveFocusBackward();
                return true;
            };
            Window.Instance.Add(button);
        }

        public void WindowDevelPropertyTest()
        {
            Window window = Window.Instance;
            uint count = window.GetSupportedAuxiliaryHintCount();
            if (count > 0)
            {
                window.BackgroundColor = Color.Blue;
            }
            uint id = window.AddAuxiliaryHint("wm.policy.win.effect.disable", "1");
            window.RemoveAuxiliaryHint(id);
            window.RemoveAuxiliaryHint(2);

            id = window.AddAuxiliaryHint("wm.policy.win.effect.disable", "1");
            window.SetAuxiliaryHintValue(id, "0");
            string value = window.GetAuxiliaryHintValue(id);
            if(value.Length > 0)
            {
                window.BackgroundColor = Color.Red;
            }

            window.SetInputRegion(new Rectangle(0, 0, 0, 0));
            WindowType type = window.Type;
            Tizen.Log.Debug("NUI", "window type is "+type);
            window.Type = WindowType.Notification;

            NotificationLevel level = window.GetNotificationLevel();
            window.SetNotificationLevel(NotificationLevel.High);
            level = window.GetNotificationLevel();
            Tizen.Log.Debug("NUI", "window notification level is " + level);

            window.SetOpaqueState(true);
            Tizen.Log.Debug("NUI", "window is opaque? " + window.IsOpaqueState());

            window.SetScreenOffMode(ScreenOffMode.Never);
            ScreenOffMode screenMode = window.GetScreenOffMode();
            Tizen.Log.Debug("NUI", "window screen mode is " + screenMode);

            bool ret = window.SetBrightness(50);
            int brightness = window.GetBrightness();
            Tizen.Log.Debug("NUI", "window brightness is " + brightness, ", return "+ret);
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
            background.Find(ColorVisualProperty.MixColor, "mixColor")?.Get(backgroundColor);
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
          Window.Instance.Add(container);
          Tizen.Log.Debug("NUI", "winow layer count is "+Window.Instance.LayerCount);
          Tizen.Log.Debug("NUI", "winow default layer child at 0 is "+Window.Instance.GetDefaultLayer().GetChildAt(0));
          // Test downcast for native control
          TextLabel myLabel = new TextLabel();
          myLabel.Name = "MyLabelName";
          myLabel.Text = "MyText";

          Tizen.Log.Debug("NUI", "myLabel.Name = " + myLabel.Name + ", Text = " + myLabel.Text);

          container.Add(myLabel);

          View myLabelView  = container.FindChildByName("MyLabelName");
          if(myLabelView)
          {
            TextLabel newLabel = myLabelView as TextLabel;
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

          View myViewView  = container.FindChildByName("MyViewName");
          if(myViewView)
          {
            MyView newView = myViewView as MyView;
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

          View myButtonView  = container.FindChildByName("MyButtonName");
          if(myButtonView)
          {
            MyButton newButton = myButtonView as MyButton;
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

          View spinView  = container.FindChildByName("SpinName");
          if(spinView)
          {
            Spin newSpin = spinView as Spin;
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

          View mySpinView  = container.FindChildByName("MySpinName");
          if(mySpinView)
          {
            MySpin newSpin = mySpinView as MySpin;
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

            for (uint i = 0; i < parent.ChildCount; i++)
            {
                View childView = parent.GetChildAt(i);
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
            PushButton view = parentView.GetChildAt(0) as PushButton;
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
