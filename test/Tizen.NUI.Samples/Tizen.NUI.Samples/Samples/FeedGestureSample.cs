using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class FeedGestureSample : IExample
    {
        private View rootView;

        private PanGestureDetector panGestureDetectorOne;
        private PanGestureDetector panGestureDetectorTwo;
        private PanGestureDetector panGestureDetectorThree;


        private LongPressGestureDetector longPressGestureDetectorOne;
        private LongPressGestureDetector longPressGestureDetectorTwo;
        private LongPressGestureDetector longPressGestureDetectorThree;

        private TapGestureDetector tapGestureDetectorOne;
        private TapGestureDetector tapGestureDetectorTwo;
        private TapGestureDetector tapGestureDetectorThree;

        private Vector3 startingScale = new Vector3(1.0f, 1.0f, 1.0f);
        private float startingOrientation;
        private PinchGestureDetector pinchGestureDetector;
        private RotationGestureDetector rotationGestureDetector;

        public void Activate()
        {
            NUIApplication.SetGeometryHittestEnabled(true);

            rootView = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            CreateViewUseOneDetector();
            CreateViewUseTwoDetector();
        }

        private void CreateViewUseOneDetector()
        {
            Window window = NUIApplication.GetDefaultWindow();
            var redView = new View
            {
                Size = new Size(500, 500),
                Position = new Position(150, 170),
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
                ClippingMode = ClippingModeType.ClipToBoundingBox,
            };

            var blueView = new View
            {
                Size2D = new Size2D(300, 700),
                Position = new Position(100, 100),
                BackgroundColor = Color.Blue,
            };

            var textField = new TextField()
            {
                Text = "Input",
                Size2D = new Size2D(300, 100),
                BackgroundColor = Color.Orange
            };
            redView.Add(blueView);
            rootView.Add(redView);

            var textLabel = new TextLabel
            {
                Text = "Use One Detector",
                Size2D = new Size2D(300, 300),
                Position = new Position(150, 550),
            };

            rootView.Add(textLabel);
            window.Add(rootView);

            var tempView = new View()
            {
                Size2D = new Size2D(300, 100),
                Position = new Position(0, 600),
                BackgroundColor = Color.Black,
            };
            blueView.Add(tempView);
            tempView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"tempView.TouchEvent\n");
                return false;
            };


            TapOne(redView, blueView);
            PanOne(redView, blueView);
            LongPressOne(redView, blueView);
        }

        private void TapOne(View redView, View blueView)
        {
            tapGestureDetectorOne = new TapGestureDetector();
            tapGestureDetectorOne.Detected += (s, e) =>
            {
                if(e.TapGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Yellow;
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                 if(e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Interrupted)
                 {
                    redView.BackgroundColor = Color.Red;
                 }
                return tapGestureDetectorOne.HandleEvent(s as View, e.Touch);
            };

            blueView.TouchEvent += (s, e) =>
            {
                 if(e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Interrupted)
                 {
                    blueView.BackgroundColor = Color.Blue;
                 }
                return tapGestureDetectorOne.HandleEvent(s as View, e.Touch);
            };
        }

        private void PanOne(View redView, View blueView)
        {
            panGestureDetectorOne = new PanGestureDetector();
            panGestureDetectorOne.SetMaximumTouchesRequired(2);
            panGestureDetectorOne.Detected += (s, e) =>
            {
                if(e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    e.View.Position += new Position(e.PanGesture.ScreenDisplacement.X, e.PanGesture.ScreenDisplacement.Y);
                }
                // e.Handled = false;
            };

            redView.TouchEvent += (s, e) =>
            {
                return panGestureDetectorOne.HandleEvent(s as View, e.Touch);;
            };

            blueView.TouchEvent += (s, e) =>
            {
                return panGestureDetectorOne.HandleEvent(s as View, e.Touch);
            };
        }

        private void LongPressOne(View redView, View blueView)
        {
            longPressGestureDetectorOne = new LongPressGestureDetector();
            longPressGestureDetectorOne.Detected += (s, e) =>
            {
                if(e.LongPressGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Aqua;
                }
                else if (e.LongPressGesture.State == Gesture.StateType.Finished || e.LongPressGesture.State == Gesture.StateType.Cancelled)
                {
                    if(e.View == redView)
                    {
                        e.View.BackgroundColor = Color.Red;
                    }
                    if(e.View == blueView)
                    {
                        e.View.BackgroundColor = Color.Blue;
                    }
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                return longPressGestureDetectorOne.HandleEvent(s as View, e.Touch);
            };

            blueView.TouchEvent += (s, e) =>
            {
                return longPressGestureDetectorOne.HandleEvent(s as View, e.Touch);
            };
        }

        private void CreateViewUseTwoDetector()
        {
            Window window = NUIApplication.GetDefaultWindow();
            var redView = new View
            {
                Size = new Size(500, 500),
                Position = new Position(750, 170),
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
                ClippingMode = ClippingModeType.ClipToBoundingBox,
            };

            var blueView = new View
            {
                Size2D = new Size2D(300, 300),
                Position = new Position(100, 100),
                BackgroundColor = Color.Blue,
            };

            var textField = new TextField()
            {
                Text = "Input",
                Size2D = new Size2D(300, 100),
                BackgroundColor = Color.Orange
            };
            blueView.Add(textField);

            redView.Add(blueView);
            rootView.Add(redView);

            var textLabel = new TextLabel
            {
                Text = "Use Two Detector",
                Size2D = new Size2D(300, 300),
                Position = new Position(750, 550),
            };

            var blockView = new View
            {
                Size2D = new Size2D(300, 100),
                Position = new Position(200, 100),
                BackgroundColor = Color.BurlyWood,
            };
            blockView.TouchEvent += (s, e) =>
            {
                return true;
            };

            rootView.Add(textLabel);
            redView.Add(blockView);
            window.Add(rootView);


            // TapTwo(redView, blueView);
            PanTwo(redView, blueView);
            LongPressTwo(redView, blueView);
            // Pinch(redView, blueView);
            // Rotation(redView, blueView);
        }

        private void Rotation(View redView, View blueView)
        {
            rotationGestureDetector = new RotationGestureDetector();
            rotationGestureDetector.Detected += (s, e) =>
            {
                if (e.RotationGesture.State == Gesture.StateType.Started)
                {
                    startingOrientation = e.RotationGesture.Rotation;
                }
                else if (e.RotationGesture.State != Gesture.StateType.Cancelled)
                {
                    Tizen.Log.Error("NUI", $"Rotation startingOrientation {startingOrientation}, { e.RotationGesture.Rotation}\n");
                    e.View.RotateBy(new Radian(e.RotationGesture.Rotation), Vector3.ZAxis);
                }
            };

            // redView.TouchEvent += (s, e) =>
            // {
            //     return rotationGestureDetector.HandleEvent(s as View, e.Touch);
            // };

            blueView.TouchEvent += (s, e) =>
            {
                // blueView.Orientation = new Rotation(new Radian(0.01f), Vector3.ZAxis);
                // blueView.RotateBy(new Radian(0.01f), Vector3.ZAxis);
                // return true;
                return rotationGestureDetector.HandleEvent(s as View, e.Touch);
            };
        }

        private void Pinch(View redView, View blueView)
        {
            pinchGestureDetector = new PinchGestureDetector();
            pinchGestureDetector.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"Pinch state {e.PinchGesture.State}\n");
                if (e.PinchGesture.State == Gesture.StateType.Started)
                {
                    startingScale = (Vector3)e.View.Scale.Clone();
                }
                else if (e.PinchGesture.State != Gesture.StateType.Cancelled)
                {
                    e.View.Scale = startingScale * e.PinchGesture.Scale;
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                return pinchGestureDetector.HandleEvent(s as View, e.Touch);
            };

            // blueView.TouchEvent += (s, e) =>
            // {
            //     return pinchGestureDetector.HandleEvent(s as View, e.Touch);
            // };
        }

        private void TapTwo(View redView, View blueView)
        {
            tapGestureDetectorTwo = new TapGestureDetector();
            tapGestureDetectorTwo.Detected += (s, e) =>
            {
                if(e.TapGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Yellow;
                }
            };

            tapGestureDetectorThree = new TapGestureDetector();
            tapGestureDetectorThree.Detected += (s, e) =>
            {
                if(e.TapGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Yellow;
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                 if(e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Interrupted)
                 {
                    redView.BackgroundColor = Color.Red;
                 }
                return tapGestureDetectorThree.HandleEvent(s as View, e.Touch);
            };

            blueView.TouchEvent += (s, e) =>
            {
                 if(e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Interrupted)
                 {
                    blueView.BackgroundColor = Color.Blue;
                 }
                return tapGestureDetectorTwo.HandleEvent(s as View, e.Touch);
            };
        }

        private void PanTwo(View redView, View blueView)
        {
            panGestureDetectorTwo = new PanGestureDetector();
            panGestureDetectorTwo.SetMaximumTouchesRequired(2);
            panGestureDetectorTwo.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $" pan {e.PanGesture.State }\n");
                if(e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    e.View.Position += new Position(e.PanGesture.ScreenDisplacement.X, e.PanGesture.ScreenDisplacement.Y);
                }
            };

            panGestureDetectorThree = new PanGestureDetector();
            panGestureDetectorThree.SetMaximumTouchesRequired(2);
            panGestureDetectorThree.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $" pan {e.PanGesture.State }\n");
                if(e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    e.View.Position += new Position(e.PanGesture.ScreenDisplacement.X, e.PanGesture.ScreenDisplacement.Y);
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                bool ret = panGestureDetectorThree.HandleEvent(s as View, e.Touch);;
                return ret;
            };

            blueView.TouchEvent += (s, e) =>
            {
                bool ret = panGestureDetectorTwo.HandleEvent(s as View, e.Touch);
                if(ret) panGestureDetectorTwo.CancelAllOtherGestureDetectors();
                return ret;
            };
        }

        private void LongPressTwo(View redView, View blueView)
        {
            longPressGestureDetectorTwo = new LongPressGestureDetector();
            longPressGestureDetectorTwo.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $" long {e.LongPressGesture.State }\n");
                if(e.LongPressGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Aqua;
                }
                else if (e.LongPressGesture.State == Gesture.StateType.Finished || e.LongPressGesture.State == Gesture.StateType.Cancelled)
                {
                    if(e.View == redView)
                    {
                        e.View.BackgroundColor = Color.Red;
                    }
                    if(e.View == blueView)
                    {
                        e.View.BackgroundColor = Color.Blue;
                    }
                }
            };

            longPressGestureDetectorThree = new LongPressGestureDetector();
            longPressGestureDetectorThree.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $" long {e.LongPressGesture.State }\n");
                if(e.LongPressGesture.State == Gesture.StateType.Started)
                {
                    e.View.BackgroundColor = Color.Coral;
                }
                else if (e.LongPressGesture.State == Gesture.StateType.Finished || e.LongPressGesture.State == Gesture.StateType.Cancelled)
                {
                    if(e.View == redView)
                    {
                        e.View.BackgroundColor = Color.Red;
                    }
                    if(e.View == blueView)
                    {
                        e.View.BackgroundColor = Color.Blue;
                    }
                }
            };

            redView.TouchEvent += (s, e) =>
            {
                bool ret = longPressGestureDetectorThree.HandleEvent(s as View, e.Touch);
                // Tizen.Log.Error("NUI", $"redView long {ret}\n");
                return ret;
            };

            blueView.TouchEvent += (s, e) =>
            {
                bool ret = longPressGestureDetectorTwo.HandleEvent(s as View, e.Touch);
                // Tizen.Log.Error("NUI", $"blueView long {ret}\n");
                return ret;
            };
        }

        public void Deactivate()
        {
            NUIApplication.SetGeometryHittestEnabled(false);
            if (rootView != null)
            {
                NUIApplication.GetDefaultWindow().Remove(rootView);
                rootView.Dispose();
            }
        }
    }
}
