using System;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.WindowSystem;
using System.Collections.Generic;

namespace Tizen.NUI.WindowSystem
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window win = Window.Instance;
            inputGesture = new InputGesture();

            win.WindowSize = new Size2D(500, 500);
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.White;

            View windowView = new View();
            windowView.Size2D = new Size2D(500, 500);
            windowView.BackgroundColor = Color.White;
            windowView.TouchEvent += OnTouchEvent;
            win.Add(windowView);

            centerLabel = new TextLabel("InputGesture Sample, Click to generate Return Key.");
            centerLabel.HorizontalAlignment = HorizontalAlignment.Center;
            centerLabel.VerticalAlignment = VerticalAlignment.Center;
            centerLabel.TextColor = Color.Black;
            centerLabel.PointSize = 12.0f;
            centerLabel.HeightResizePolicy = ResizePolicyType.FillToParent;
            centerLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            windowView.Add(centerLabel);

            repeatCounter = 0;
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
            {
                repeatCounter++;
                centerLabel.Text = "Return Key Pressed, counter: " + repeatCounter.ToString();
            }

            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "S" || e.Key.KeyPressedName == "s"))
            {
                if (edgeSwipeG == IntPtr.Zero)
                    edgeSwipeG = inputGesture.CreateEdgeSwipeData(2, GestureEdge.Left);

                if (edgeSwipeG == IntPtr.Zero)
                {
                    centerLabel.Text = "'S' Key Pressed. edgeSwipeG NULL!!";
                    return;
                }

                if (!edgeSwipeGrabbed)
                {
                    inputGesture.GrabGesture(edgeSwipeG);
                    centerLabel.Text = "'S' Key Pressed. edgeSwipe Grabbed";

                    inputGesture.EdgeSwipeEventHandler += _edgeSwipeEventHandler;
                    edgeSwipeGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabGesture(edgeSwipeG);
                    centerLabel.Text = "'S' Key Pressed. edgeSwipe Ungrabbed";
                    edgeSwipeGrabbed = false;
                }
            }
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "D" || e.Key.KeyPressedName == "d"))
            {
                if (edgeDragG == IntPtr.Zero)
                    edgeDragG = inputGesture.CreateEdgeDragData(2, GestureEdge.Right);

                if (edgeDragG == IntPtr.Zero)
                {
                    centerLabel.Text = "'D' Key Pressed. edgeDrag NULL!!!";
                    return;
                }

                if (!edgeDragGrabbed)
                {
                    inputGesture.GrabGesture(edgeDragG);
                    centerLabel.Text = "'D' Key Pressed. edgeDrag Grabbed";

                    inputGesture.EdgeDragEventHandler += _edgeDragEventHandler;
                    edgeDragGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabGesture(edgeDragG);
                    centerLabel.Text = "'D' Key Pressed. edgeDrag Ungrabbed";
                    edgeDragGrabbed = false;
                }
            }
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "T" || e.Key.KeyPressedName == "t"))
            {
                if (tapG == IntPtr.Zero)
                    tapG = inputGesture.CreateTapData(3, 2);

                if (tapG == IntPtr.Zero)
                {
                    centerLabel.Text = "'T' Key Pressed. Tap NULL!!!";
                    return;
                }

                if (!tapGrabbed)
                {
                    inputGesture.GrabGesture(tapG);
                    centerLabel.Text = "'T' Key Pressed. Tap Grabbed";

                    inputGesture.TapEventHandler += _tapEventHandler;
                    tapGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabGesture(tapG);
                    centerLabel.Text = "'T' Key Pressed. Tap Ungrabbed";
                    tapGrabbed = false;
                }
            }
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "P" || e.Key.KeyPressedName == "p"))
            {
                if (palmG == IntPtr.Zero)
                    palmG = inputGesture.CreatePalmCoverData();

                if (palmG == IntPtr.Zero)
                {
                    centerLabel.Text = "'P' Key Pressed. PalmCover NULL!!!";
                    return;
                }

                if (!palmCoverGrabbed)
                {
                    inputGesture.GrabGesture(palmG);
                    centerLabel.Text = "'P' Key Pressed. PalmCover Grabbed";

                    inputGesture.PalmCoverEventHandler += _palmCoverEventHandler;
                    palmCoverGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabGesture(palmG);
                    centerLabel.Text = "'P' Key Pressed. PalmCover Ungrabbed";
                    palmCoverGrabbed = false;
                }
            }
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "G" || e.Key.KeyPressedName == "g"))
            {
                if (edgeSwipeG == IntPtr.Zero)
                    edgeSwipeG = inputGesture.CreateEdgeSwipeData(1, GestureEdge.Left);

                if (edgeSwipeG == IntPtr.Zero)
                {
                    centerLabel.Text = "'G' Key Pressed. edgeSwipeG NULL!!";
                    return;
                }

                if (!edgeSwipeGrabbed)
                {
                    inputGesture.SetGestureGrabMode(edgeSwipeG, GestureGrabMode.Shared);
                    inputGesture.GrabGesture(edgeSwipeG);
                    centerLabel.Text = "'G' Key Pressed. edgeSwipe Shared Grabbed";

                    inputGesture.EdgeSwipeEventHandler += _edgeSwipeEventHandler;
                    edgeSwipeGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabGesture(edgeSwipeG);
                    centerLabel.Text = "'G' Key Pressed. edgeSwipe Ungrabbed";
                    edgeSwipeGrabbed = false;
                }
            }
        }

        private bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            touchCounter++;
            // if (e.Touch.GetState(0) == PointStateType.Down)
            // {
            //     centerLabel.Text = "Touch Down";
            // }
            // else if (e.Touch.GetState(0) == PointStateType.Up)
            // {
            //     centerLabel.Text = "Touch Up";
            // }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _edgeSwipeEventHandler(object sender, EdgeSwipeEventArgs e)
        {
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Sx: " + e.Sx + ", Sy: " + e.Sy + ", Edge: " + (GestureEdge)e.Edge);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _edgeDragEventHandler(object sender, EdgeDragEventArgs e)
        {
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Cx: " + e.Cx + ", Cy: " + e.Cy + ", Edge: " + (GestureEdge)e.Edge);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _tapEventHandler(object sender, TapEventArgs e)
        {
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Repeats: " + e.Fingers);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _palmCoverEventHandler(object sender, PalmCoverEventArgs e)
        {
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Duration: " + e.Duration + ", Cx: " + e.Cx + ", Cy: " + e.Cy + ", Size: " + e.Size + ", Pressure: " + e.Pressure);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private InputGesture inputGesture;
        IntPtr edgeSwipeG;
        IntPtr edgeDragG;
        IntPtr tapG;
        IntPtr palmG;
        private TextLabel centerLabel;
        int repeatCounter = 0;
        int touchCounter = 0;

        bool edgeSwipeGrabbed;
        bool edgeDragGrabbed;
        bool tapGrabbed;
        bool palmCoverGrabbed;
    }
}
