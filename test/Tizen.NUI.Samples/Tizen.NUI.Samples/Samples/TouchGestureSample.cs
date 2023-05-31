using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        private View root;
        // private View frontView;
        // private PanGestureDetector panGestureDetector;
        // private PinchGestureDetector pinchGestureDetector;
        // private TapGestureDetector tapGestureDetector;
        // private Vector3 startingScale = new Vector3(1.0f, 1.0f, 1.0f);

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            // View testView = new View()
            // {
            //      Size = new Size(300, 300, 0),
            //     Position = new Position(150, 270),
            //     BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 0.5f),
            // };
            // testView.HoverEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUITEST", $" HoverEvent \n");
            //     return true;
            // };
            // window.Add(testView);
            window.Hide();



            // Window subWindowOne = new Window("subwin1", new Rectangle(20, 20, 800, 800), false);
            // subWindowOne.BackgroundColor = Color.Red;
            window.InputPointerGrabEnabledSet(true);
            // Tizen.Log.Error("NUITEST", $"InputPointerGrabEnabledGet {subWindowOne.InputPointerGrabEnabledGet()}\n");
            // subWindowOne.PointerConstraintsUnlockPointer();
            window.MousePointerGrabEvent += (s, e) =>
            {
                Tizen.Log.Error("NUITEST", $"state {e.MousePointerGrab.State} \n");
                if (e.MousePointerGrab.State == MousePointerGrab.StateType.Move)
                {
                    Tizen.Log.Error("NUITEST", $"ScreenPosition {e.MousePointerGrab.ScreenPosition.X} {e.MousePointerGrab.ScreenPosition.Y} \n");

                }
                else if (e.MousePointerGrab.State == MousePointerGrab.StateType.RelativeMove)
                {
                    Tizen.Log.Error("NUITEST", $"DiffPosition {e.MousePointerGrab.DiffPosition.X} {e.MousePointerGrab.DiffPosition.Y} \n");
                }
            };

            window.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    window.PointerConstraintsLockPointer();
                }
            };

            // FocusManager.Instance.EnableDefaultAlgorithm(true);
            // Window window = NUIApplication.GetDefaultWindow();
            // root = new View();

            // // frontView = new ImageView("/home/puro/workspace/tizen/submit/dali-toolkit/automated-tests/resources/svg1.svg")
            // frontView = new View
            // {

            //     Size = new Size(300, 300, 0),
            //     Position = new Position(150, 270),
            //     BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 0.5f),
            //     // Scale = new Vector3(1.0f, 1.0f, 0.0f),
            // };
            // frontView.HoverEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUITEST", $"front HoverEvent\n");
            //     return false;
            // };
            // // frontView.TouchEvent += (s, e) =>
            // // {
            // //     if (e.Touch.GetState(0) == PointStateType.Down)
            // //     {
            // //         Tizen.Log.Error("NUITEST", $"front TouchDown\n");
            // //         // frontView.PositionUsesPivotPoint = true;
            // //         // Tizen.Log.Error("NUITEST", $"Position {e.Touch.GetLocalPosition(0).X} {e.Touch.GetLocalPosition(0).Y}\n");
            // //         // frontView.PivotPoint = new Position(e.Touch.GetLocalPosition(0).X / frontView.Size.Width, e.Touch.GetLocalPosition(0).Y / frontView.Size.Height);
            // //         // frontView.Position = new Position(e.Touch.GetScreenPosition(0).X, e.Touch.GetScreenPosition(0).Y);
            // //         // Tizen.Log.Error("NUITEST", $"PivotPoint {frontView.PivotPoint.X} {frontView.PivotPoint.Y}\n");
            // //     }
            // //     // if (e.Touch.GetMouseButton(0) == MouseButton.Primary)
            // //     // {
            // //     //     frontView.Scale *= 1.03f;
            // //     // }
            // //     // else if (e.Touch.GetMouseButton(0) == MouseButton.Secondary)
            // //     // {
            // //     //     frontView.Scale *= 0.9f;
            // //     // }
            // //     return false;
            // // };

            // // frontView.DispatchParentTouchEvents = false;


            // // GestureOptions.Instance.SetPinchGestureMinimumTouchEvents(1000);
            // // pinchGestureDetector = new PinchGestureDetector();
            // // pinchGestureDetector.Attach(frontView);
            // // pinchGestureDetector.Detected += (s, e) =>
            // // {
            // //     if (e.PinchGesture.State == Gesture.StateType.Started)
            // //     {
            // //         startingScale = (Vector3)e.View.Scale.Clone();
            // //         e.View.PositionUsesPivotPoint = true;
            // //         e.View.PivotPoint = new Position((e.PinchGesture.LocalCenterPoint.X ) / (e.View.Size.Width ), (e.PinchGesture.LocalCenterPoint.Y ) / (e.View.Size.Height ));
            // //         e.View.Position = new Position(e.PinchGesture.ScreenCenterPoint.X, e.PinchGesture.ScreenCenterPoint.Y);
            // //     }
            // //     e.View.Scale = startingScale * e.PinchGesture.Scale;
            // // };

            // // frontView.TouchEvent += (s, e) =>
            // // {
            // //     Tizen.Log.Error("NUI", $"frontView \n");
            // //     return false;
            // // };

            // // var middleView = new View
            // // {
            // //     Size = new Size(300, 300),
            // //     Position = new Position(250, 270),
            // //     BackgroundColor = Color.Blue,
            // //     Focusable = true,
            // //     FocusableInTouch = true,
            // // };
            // // middleView.TouchEvent += (s, e) =>
            // // {
            // //     Tizen.Log.Error("NUI", $"middleView \n");
            // //     return true;
            // // };


            // // FocusManager.Instance.FocusChanged += OnFocusChanged;

            // GestureOptions.Instance.SetDoubleTapTimeout(250);
            // tapGestureDetector = new TapGestureDetector();
            // tapGestureDetector.SetMaximumTapsRequired(3);
            // tapGestureDetector.SetMinimumTapsRequired(2);
            // tapGestureDetector.Attach(frontView);
            // tapGestureDetector.Detected += (s, e) =>
            // {
            //     Tizen.Log.Error("NUITEST", $"tapGestureDetector {e.TapGesture.NumberOfTaps}\n");
            // };


            // var tapGestureDetector1 = new TapGestureDetector();
            // tapGestureDetector1.SetMinimumTapsRequired(0);
            // tapGestureDetector1.SetMaximumTapsRequired(0);
            // tapGestureDetector1.Attach(frontView);
            // tapGestureDetector1.Detected += (s, e) =>
            // {
            //     Tizen.Log.Error("NUITEST", $"tapGestureDetector1 {e.TapGesture.NumberOfTaps}\n");
            // };

            // // middleView.Add(frontView);
            // window.Add(frontView);
        }

        private void TestGrab(object sender, Window.MousePointerGrabEventArgs e)
        {

        }

        // private void OnFocusChanged(object sender, NUI.FocusManager.FocusChangedEventArgs e)
        // {
        //     Tizen.Log.Debug("NUITEST", $"e.Previous.Name={e.Previous} e.Current.Name={e.Current}\n");
        // }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
