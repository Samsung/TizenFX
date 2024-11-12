using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class GeometryTouchEvent : IExample
    {
        class LogOutput : ScrollableBase
        {
            public LogOutput() : base()
            {
                SizeWidth = 500;
                BackgroundColor = Color.AntiqueWhite;
                // WidthSpecification = LayoutParamPolicies.MatchParent;
                HeightSpecification = LayoutParamPolicies.MatchParent;
                // HideScrollbar = false;
                ScrollingDirection = ScrollableBase.Direction.Vertical;

                ContentContainer.Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                };
            }

            public void AddLog(string log)
            {
                Console.WriteLine($"{log}\n");
                var txt = new TextLabel
                {
                    Text = log
                };

                ContentContainer.Add(txt);
                if (ContentContainer.Children.Count > 30)
                {
                    var remove = ContentContainer.Children.GetRange(0, 10);
                    foreach (var child in remove)
                    {
                        ContentContainer.Remove(child);
                    }
                }
                ElmSharp.EcoreMainloop.Post(() =>
                {
                    ScrollTo((ContentContainer.Children.Count) * (txt.NaturalSize.Height), true);
                });
            }
            public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
            {
                return null;
            }
        }


        private TapGestureDetector[] tapGestureDetector = new TapGestureDetector[4];
        private PanGestureDetector[] panGestureDetector = new PanGestureDetector[4];
        private LongPressGestureDetector[] longPressGestureDetector = new LongPressGestureDetector[4];
        private List<GestureDetector>[] gestureDetector = new List<GestureDetector>[4];
        private Color backgroundColor = Color.White;


        private PanGestureDetector tempPanGestureDetector;

        private Window window;
        private View blueView;
        private View yellowView;
        private View redView;
        private View orangeView;
        private LogOutput log;
        private View root;

        public void Activate()
        {
            Tizen.Log.Error("NUI", $"NUIApplication.SetGeometryTouchGesture(true);!!!!!!!!!!!!!!!\n");
            NUIApplication.SetGeometryHittestEnabled(true);
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.Grey;

            // var tempWindow = new Window("subwin1", null, new Rectangle(20, 20, 800, 800), false);

            root = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,

            };
            root.Name = "root";

            // default hittest, do not parent-child
            blueView = new View
            {
                Name = "blueView",
                Size2D = new Size2D(700, 500),
                Position2D = new Position2D(500, 10),
                BackgroundColor = Color.Blue,
            };
            var blueTxt = new TextLabel
            {
                Text = "Blue",
            };
            blueView.Add(blueTxt);

            yellowView = new View
            {
                Name = "yellowView",
                Size2D = new Size2D(600, 350),
                Position2D = new Position2D(550, 60),
                BackgroundColor = Color.Yellow,
            };
            var yellowTxt = new TextLabel
            {
                Text = "Yellow",
            };
            yellowView.Add(yellowTxt);


            redView = new View
            {
                Name = "redView",
                Size2D = new Size2D(300, 150),
                Position2D = new Position2D(590, 120),
                BackgroundColor = Color.Red,
                // ClippingMode = ClippingModeType.ClipChildren,
            };
            var redTxt = new TextLabel
            {
                Text = "Red",
            };
            redView.Add(redTxt);


            orangeView = new View
            {
                Name = "orangeView",
                Size2D = new Size2D(700, 100),
                Position2D = new Position2D(50, 30),
                BackgroundColor = Color.Orange,
            };
            var orangeTxt = new TextLabel
            {
                Text = "Orange",
            };
            orangeView.Add(orangeTxt);

            var tempView = new View
            {
                 Name = "orangeView",
                Size2D = new Size2D(700, 100),
                Position2D = new Position2D(50, 30),
                BackgroundColor = Color.AntiqueWhite,
            };
            var tempTxt = new TextLabel
            {
                Text = "Temp",
            };
            tempView.HoverEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"TempView Hover {e.Hover.GetState(0)}\n");
                log.AddLog($" ->Temp Hover {e.Hover.GetState(0)}\n");
                return false;
            };
            tempView.Add(tempTxt);
            orangeView.Add(tempView);


            log = new LogOutput();

            redView.Add(orangeView);
            root.Add(blueView);
            root.Add(yellowView);
            root.Add(redView);
            window.Add(root);
            window.Add(log);

            //test code
            // for(int i = 0; i<2000; i++)
            // {
            //     var testView = new View()
            //     {
            //         Size2D = new Size2D (500, 500),
            //         Position2D = new Position2D(595, 125),
            //         BackgroundColor = new Vector4(0.5f, 1.0f, 0.5f, 0.5f),
            //     };
            //     window.Add(testView);
            // }

            for(int i =0; i<4; i++)
            {
                string name = GetName(i);
                tapGestureDetector[i] = new TapGestureDetector();
                tapGestureDetector[i].Detected += (s, e) =>
                {
                    Tizen.Log.Error("NUI", $"{name} tapGestureDetectorn");
                    log.AddLog($" ->{name} OnTap {e.TapGesture.State}\n");
                };
                panGestureDetector[i] = new PanGestureDetector();
                panGestureDetector[i].Detected += (s, e) =>
                {
                    Tizen.Log.Error("NUI", $"{name} panGestureDetector");
                    log.AddLog($" ->{name} OnPan {e.PanGesture.State}\n");
                };
                longPressGestureDetector[i] = new LongPressGestureDetector();
                longPressGestureDetector[i].Detected += (s, e) =>
                {
                    Tizen.Log.Error("NUI", $"{name} longPressGestureDetector");
                    log.AddLog($" ->{name} OnLong {e.LongPressGesture.State} {s}\n");

                    var senderView = e.View;
                    if(e.LongPressGesture.State == Gesture.StateType.Started)
                    {
                        backgroundColor = new Color(senderView.BackgroundColor);
                        senderView.BackgroundColor = senderView.BackgroundColor * 0.7f;
                    }

                    if(e.LongPressGesture.State == Gesture.StateType.Finished || e.LongPressGesture.State == Gesture.StateType.Cancelled)
                     {
                        senderView.BackgroundColor = backgroundColor;
                     }
                };
                gestureDetector[i] = new List<GestureDetector>();
            }

            // MakeInterceptTouchList();
            // MakeTouchList();
            // MakeGestureList();
            // MakeHoverList();

            LongPanGestureTest();
        }

        public void LongPanGestureTest()
        {

            orangeView.TouchEvent += (s, e) =>
            {
                log.AddLog($" ->orangeView touch11 {e.Touch.GetState(0)}\n");
                longPressGestureDetector[3].HandleEvent(s as View, e.Touch);
                return false;
            };


            tempPanGestureDetector = new PanGestureDetector();
            Color tempColor = yellowView.BackgroundColor * 0.7f;;
            tempPanGestureDetector.Detected += (s, e) =>
            {
                if(e.View == orangeView)
                {
                    log.AddLog($" -> tempPanGestureDetector orangeView OnPan {e.PanGesture.State}\n");
                }
                else if (e.View == yellowView)
                {
                    log.AddLog($" -> tempPanGestureDetector yellowView OnPan {e.PanGesture.State}\n");
                }
                if(e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
                {
                    yellowView.BackgroundColor = Color.Yellow;
                }
                else
                {
                    yellowView.BackgroundColor = tempColor;
                }
            };

            yellowView.InterceptTouchEvent += (s, e) =>
            {
                return tempPanGestureDetector.HandleEvent(s as View, e.Touch);
            };

            yellowView.TouchEvent += (s, e) =>
            {
                return tempPanGestureDetector.HandleEvent(s as View, e.Touch);
            };
        }

        private bool blueInterceptConsumed = false;
        private bool yellowInterceptConsumed = false;
        private bool redInterceptConsumed = false;
        private bool orangeInterceptConsumed = false;
        public void MakeInterceptTouchEvent(View list, View targetView, string name, Tizen.NUI.EventHandlerWithReturnType<object, Tizen.NUI.BaseComponents.View.TouchEventArgs, bool> interceptEvent)
        {
            var interceptButtonList = new View()
            {
                Size2D = new Size2D(300, 70),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            var checkBox = new CheckBox
            {
                Text = name
            };
            checkBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected == true)
                {
                    targetView.InterceptTouchEvent += interceptEvent;
                }
                else
                {
                    targetView.InterceptTouchEvent -= interceptEvent;
                }
            };
            var consumedCheck = new CheckBox
            {
                Text = "Consumed"
            };
            if(name == "Blue")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    blueInterceptConsumed = args.IsSelected;
                };
            }
            else if(name == "Yellow")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    yellowInterceptConsumed = args.IsSelected;
                };
            }
            else if(name == "Red")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    redInterceptConsumed = args.IsSelected;
                };
            }
            else if(name == "Orange")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    orangeInterceptConsumed = args.IsSelected;
                };
            }
            interceptButtonList.Add(checkBox);
            interceptButtonList.Add(consumedCheck);
            list.Add(interceptButtonList);
        }

        public void MakeInterceptTouchList()
        {
            var buttonLayer = new View()
            {
                Size2D = new Size2D(700, 400),
                Position2D = new Position2D(500, 560),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            };

            var interceptText = new TextLabel()
            {
                Text = "InterceptTouch"
            };
            buttonLayer.Add(interceptText);

            MakeInterceptTouchEvent(buttonLayer, blueView, "Blue", BlueInterceptTouched);
            MakeInterceptTouchEvent(buttonLayer, yellowView, "Yellow", YellowInterceptTouched);
            MakeInterceptTouchEvent(buttonLayer, redView, "Red", RedInterceptTouched);
            MakeInterceptTouchEvent(buttonLayer, orangeView, "Orange", OrangeInterceptTouched);
            window.Add(buttonLayer);
        }

        private bool blueConsumed = false;
        private bool yellowConsumed = false;
        private bool redConsumed = false;
        private bool orangeConsumed = false;
        public void MakeTouchEvent(View list, View targetView, string name, Tizen.NUI.EventHandlerWithReturnType<object, Tizen.NUI.BaseComponents.View.TouchEventArgs, bool> touchEvent)
        {
            var buttonList = new View()
            {
                Size2D = new Size2D(300, 70),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            var checkBox = new CheckBox
            {
                Text = name
            };
            checkBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected == true)
                {
                    targetView.TouchEvent += touchEvent;
                }
                else
                {
                    targetView.TouchEvent -= touchEvent;
                }
            };
            var consumedCheck = new CheckBox
            {
                Text = "Consumed"
            };
            if(name == "Blue")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    blueConsumed = args.IsSelected;
                };
            }
            else if(name == "Yellow")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    yellowConsumed = args.IsSelected;
                };
            }
            else if(name == "Red")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    redConsumed = args.IsSelected;
                };
            }
            else if(name == "Orange")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    orangeConsumed = args.IsSelected;
                };
            }
            buttonList.Add(checkBox);
            buttonList.Add(consumedCheck);
            list.Add(buttonList);
        }
        public void MakeTouchList()
        {
            var buttonLayer = new View()
            {
                Size2D = new Size2D(700, 400),
                Position2D = new Position2D(850, 560),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            };

            var title = new TextLabel()
            {
                Text = "Touch"
            };
            buttonLayer.Add(title);

            MakeTouchEvent(buttonLayer, blueView, "Blue", BlueTouched);
            MakeTouchEvent(buttonLayer, yellowView, "Yellow", YellowTouched);
            MakeTouchEvent(buttonLayer, redView, "Red", RedTouched);
            MakeTouchEvent(buttonLayer, orangeView, "Orange", OrangeTouched);
            window.Add(buttonLayer);
        }

        private bool blueHoverConsumed = false;
        private bool yellowHoverConsumed = false;
        private bool redHoverConsumed = false;
        private bool orangeHoverConsumed = false;
        public void MakeHoverEvent(View list, View targetView, string name, Tizen.NUI.EventHandlerWithReturnType<object, Tizen.NUI.BaseComponents.View.HoverEventArgs, bool> hoverEvent)
        {
            var buttonList = new View()
            {
                Size2D = new Size2D(300, 70),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            var checkBox = new CheckBox
            {
                Text = name
            };
            checkBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected == true)
                {
                    targetView.HoverEvent += hoverEvent;
                }
                else
                {
                    targetView.HoverEvent -= hoverEvent;
                }
            };
            var consumedCheck = new CheckBox
            {
                Text = "Consumed"
            };
            if(name == "Blue")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    blueHoverConsumed = args.IsSelected;
                };
            }
            else if(name == "Yellow")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    yellowHoverConsumed = args.IsSelected;
                };
            }
            else if(name == "Red")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    redHoverConsumed = args.IsSelected;
                };
            }
            else if(name == "Orange")
            {
                consumedCheck.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    orangeHoverConsumed = args.IsSelected;
                };
            }
            buttonList.Add(checkBox);
            buttonList.Add(consumedCheck);
            list.Add(buttonList);
        }
        public void MakeHoverList()
        {
            var buttonLayer = new View()
            {
                Size2D = new Size2D(700, 400),
                Position2D = new Position2D(550, 560),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            };

            var title = new TextLabel()
            {
                Text = "Hover"
            };
            buttonLayer.Add(title);

            MakeHoverEvent(buttonLayer, blueView, "Blue", BlueHover);
            MakeHoverEvent(buttonLayer, yellowView, "Yellow", YellowHover);
            MakeHoverEvent(buttonLayer, redView, "Red", RedHover);
            MakeHoverEvent(buttonLayer, orangeView, "Orange", OrangeHover);
            window.Add(buttonLayer);
        }

        public int GetIndex(string name)
        {
            if(name == "Blue")
            {
                return 0;
            }
            else if(name == "Yellow")
            {
                return 1;
            }
            else if(name == "Red")
            {
                return 2;
            }
            else if(name == "Orange")
            {
                return 3;
            }
            return -1;
        }

        public string GetName(int index)
        {
            switch(index)
            {
                case 0 :
                    return "Blue";
                case 1 :
                    return "Yellow";
                case 2 :
                    return "Red";
                case 3 :
                    return "Orange";
                default :
                    return "Unknown";
            }
        }

        public void MakeGestureEvent(View list, View targetView, string name)
        {
            var buttonList = new View()
            {
                Size2D = new Size2D(300, 70),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                },
            };
            // var viewText = new TextLabel
            // {
            //     Text = name+" : "
            // };
            // buttonList.Add(viewText);

            var tapCheckBox = new CheckBox
            {
                Text = "Tap"
            };

            tapCheckBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected)
                {
                    gestureDetector[GetIndex(name)].Add(tapGestureDetector[GetIndex(name)]);
                }
                else
                {
                    gestureDetector[GetIndex(name)].Remove(tapGestureDetector[GetIndex(name)]);
                }
            };

            var longCheckBox = new CheckBox
            {
                Text = "LongPress"
            };
            longCheckBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected)
                {
                    gestureDetector[GetIndex(name)].Add(longPressGestureDetector[GetIndex(name)]);
                }
                else
                {
                    gestureDetector[GetIndex(name)].Remove(longPressGestureDetector[GetIndex(name)]);
                }
            };

            var panCheckBox = new CheckBox
            {
                Text = "Pan"
            };
            panCheckBox.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if(args.IsSelected)
                {
                    gestureDetector[GetIndex(name)].Add(panGestureDetector[GetIndex(name)]);
                }
                else
                {
                    gestureDetector[GetIndex(name)].Remove(panGestureDetector[GetIndex(name)]);
                }
            };

            buttonList.Add(tapCheckBox);
            buttonList.Add(longCheckBox);
            buttonList.Add(panCheckBox);
            list.Add(buttonList);
        }

        public void MakeGestureList()
        {
            var buttonLayer = new View()
            {
                Size2D = new Size2D(700, 400),
                Position2D = new Position2D(1200, 560),
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            };
            var title = new TextLabel()
            {
                Text = "Gesture"
            };
            buttonLayer.Add(title);
            MakeGestureEvent(buttonLayer, blueView, "Blue");
            MakeGestureEvent(buttonLayer, yellowView, "Yellow");
            MakeGestureEvent(buttonLayer, redView, "Red");
            MakeGestureEvent(buttonLayer, orangeView, "Orange");
            window.Add(buttonLayer);
        }

        private bool BlueInterceptTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"blueView InterceptTouchEvent {args.Touch.GetState(0)} return {blueInterceptConsumed}\n");
            log.AddLog($" ->InterceptBlue View {args.Touch.GetState(0)} return {blueInterceptConsumed}\n");
            return blueInterceptConsumed;
        }

        private bool YellowInterceptTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"yellowView InterceptTouchEvent {args.Touch.GetState(0)} return {yellowInterceptConsumed}\n");
            log.AddLog($" ->InterceptYellow View {args.Touch.GetState(0)} return {yellowInterceptConsumed}\n");
            return yellowInterceptConsumed;
        }


        private bool RedInterceptTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"redView InterceptTouchEvent {args.Touch.GetState(0)} return {redInterceptConsumed}\n");
            log.AddLog($" ->InterceptRed View {args.Touch.GetState(0)} return {redInterceptConsumed}\n");
            return redInterceptConsumed;
        }


        private bool OrangeInterceptTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"orangeView InterceptTouchEvent {args.Touch.GetState(0)} return {orangeInterceptConsumed}\n");
            log.AddLog($" ->InterceptOrange View {args.Touch.GetState(0)} return {orangeInterceptConsumed}\n");
            return orangeInterceptConsumed;
        }

        private bool BlueTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"blueView TouchEvent {args.Touch.GetState(0)}\n");
            log.AddLog($" ->Blue View {args.Touch.GetState(0)}\n");
            bool ret = false;
            foreach(var detector in gestureDetector[0])
            {
                ret |= detector.HandleEvent(sender as View, args.Touch);
            }
            return blueConsumed | ret;
        }

        private bool YellowTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"yellowView TouchEvent {args.Touch.GetState(0)}\n");
            log.AddLog($" ->Yellow View {args.Touch.GetState(0)}\n");
            bool ret = false;
            foreach(var detector in gestureDetector[1])
            {
                ret |= detector.HandleEvent(sender as View, args.Touch);
            }
            return yellowConsumed | ret;
        }


        private bool RedTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"redView TouchEvent {args.Touch.GetState(0)}\n");
            log.AddLog($" ->Red View {args.Touch.GetState(0)}\n");
            bool ret = false;
            foreach(var detector in gestureDetector[2])
            {
                ret |= detector.HandleEvent(sender as View, args.Touch);
            }
            return redConsumed | ret;
        }


        private bool OrangeTouched(object sender, View.TouchEventArgs args)
        {
            Tizen.Log.Error("NUI", $"orangeView TouchEvent {args.Touch.GetState(0)}\n");
            log.AddLog($" ->Orange View {args.Touch.GetState(0)}\n");
            bool ret = false;
            foreach(var detector in gestureDetector[3])
            {
                ret |= detector.HandleEvent(sender as View, args.Touch);
            }
            return orangeConsumed | ret;
        }

        //// hover
        private bool BlueHover(object sender, View.HoverEventArgs args)
        {
            Tizen.Log.Error("NUI", $"blueView Hover {args.Hover.GetState(0)}\n");
            log.AddLog($" ->Blue Hover {args.Hover.GetState(0)}\n");
            return blueHoverConsumed;
        }

        private bool YellowHover(object sender, View.HoverEventArgs args)
        {
            Tizen.Log.Error("NUI", $"yellowView Hover {args.Hover.GetState(0)}\n");
            log.AddLog($" ->Yellow Hover {args.Hover.GetState(0)}\n");
            return yellowHoverConsumed;
        }


        private bool RedHover(object sender, View.HoverEventArgs args)
        {
            Tizen.Log.Error("NUI", $"redView Hover {args.Hover.GetState(0)}\n");
            log.AddLog($" ->Red Hover {args.Hover.GetState(0)}\n");
            return redHoverConsumed;
        }


        private bool OrangeHover(object sender, View.HoverEventArgs args)
        {
            Tizen.Log.Error("NUI", $"orangeView Hover {args.Hover.GetState(0)}\n");
            log.AddLog($" ->Orange Hover {args.Hover.GetState(0)}\n");
            return orangeHoverConsumed;
        }
        ///


        static View CreateButton(int index)
        {
            var rnd = new Random();

            var btn = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = $"Item {index}",
                LeaveRequired = true,
                BackgroundColor = Color.DarkOrange,
            };
            btn.HoverEvent += (s, e) =>
            {
                if(e.Hover.GetState(0) == PointStateType.Started)
                {
                    btn.BackgroundColor = Color.Red;
                }
                else if (e.Hover.GetState(0) == PointStateType.Leave)
                {
                    btn.BackgroundColor = Color.DarkOrange;
                }
                return true;
            };

            var item = Wrapping(btn);
            item.SizeWidth = 200;
            item.SizeHeight = 90;

            item.Position = new Position(200, 100 * (index / 3) );

            if (item is Button button)
            {
                button.Text = $"[{button.Text}]";
            }

            return item;
        }

        static View Wrapping(View view)
        {
            int cnt = new Random().Next(0, 4);

            for (int i = 0; i < cnt; i++)
            {
                var wrapper = new View();
                view.WidthSpecification = LayoutParamPolicies.MatchParent;
                view.HeightSpecification = LayoutParamPolicies.MatchParent;
                wrapper.Add(view);
                view = wrapper;
            }

            return view;
        }

        public void Deactivate()
        {
            NUIApplication.SetGeometryHittestEnabled(false);
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
