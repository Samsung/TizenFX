using System.Runtime.CompilerServices;
/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

            inputGesture = new InputGesture();
        }

        void Initialize()
        {
            Window win = Window.Instance;

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
                if (edgeSwipeData == null)
                    edgeSwipeData = new EdgeSwipeData(inputGesture, 2, GestureEdge.Left);

                if (edgeSwipeData == null)
                {
                    centerLabel.Text = "'S' Key Pressed. edgeSwipeG NULL!!";
                    return;
                }

                if (!edgeSwipeGrabbed)
                {
                    inputGesture.GrabEdgeSwipeGesture(edgeSwipeData);
                    centerLabel.Text = "'S' Key Pressed. edgeSwipe Grabbed";

                    inputGesture.EdgeSwipeEventHandler += _edgeSwipeEventHandler;
                    edgeSwipeGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabEdgeSwipeGesture(edgeSwipeData);
                    centerLabel.Text = "'S' Key Pressed. edgeSwipe Ungrabbed";
                    edgeSwipeGrabbed = false;
                }
            }

            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "D" || e.Key.KeyPressedName == "d"))
            {
                 if (edgeDragData == null)
                    edgeDragData = new EdgeDragData(inputGesture, 2, GestureEdge.Right);

                 if (edgeDragData == null)
                {
                    centerLabel.Text = "'D' Key Pressed. edgeDrag NULL!!!";
                    return;
                }

                if (!edgeDragGrabbed)
                {
                    inputGesture.GrabEdgeDragGesture(edgeDragData);
                    centerLabel.Text = "'D' Key Pressed. edgeDrag Grabbed";

                    inputGesture.EdgeDragEventHandler += _edgeDragEventHandler;
                    edgeDragGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabEdgeDragGesture(edgeDragData);
                    centerLabel.Text = "'D' Key Pressed. edgeDrag Ungrabbed";
                    edgeDragGrabbed = false;
                }
            }

            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "T" || e.Key.KeyPressedName == "t"))
            {
                 if (tapData == null)
                    tapData = new TapData(inputGesture, 3, 2);

                 if (tapData == null)
                {
                    centerLabel.Text = "'T' Key Pressed. Tap NULL!!!";
                    return;
                }

                if (!tapGrabbed)
                {
                    inputGesture.GrabTapGesture(tapData);
                    centerLabel.Text = "'T' Key Pressed. Tap Grabbed";

                    inputGesture.TapEventHandler += _tapEventHandler;
                    tapGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabTapGesture(tapData);
                    centerLabel.Text = "'T' Key Pressed. Tap Ungrabbed";
                    tapGrabbed = false;
                }
            }

            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "P" || e.Key.KeyPressedName == "p"))
            {
                 if (palmCoverData == null)
                    palmCoverData = new PalmCoverData(inputGesture);

                 if (palmCoverData == null)
                {
                    centerLabel.Text = "'P' Key Pressed. PalmCover NULL!!!";
                    return;
                }

                if (!palmCoverGrabbed)
                {
                    inputGesture.GrabPalmCoverGesture(palmCoverData);
                    centerLabel.Text = "'P' Key Pressed. PalmCover Grabbed";

                    inputGesture.PalmCoverEventHandler += _palmCoverEventHandler;
                    palmCoverGrabbed = true;
                }
                else
                {
                    inputGesture.UngrabPalmCoverGesture(palmCoverData);
                    centerLabel.Text = "'P' Key Pressed. PalmCover Ungrabbed";
                    palmCoverGrabbed = false;
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
            Log.Debug("GestureSample", "_edgeSwipeEventHandler callback");
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Sx: " + e.Sx + ", Sy: " + e.Sy + ", Edge: " + (GestureEdge)e.Edge);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _edgeDragEventHandler(object sender, EdgeDragEventArgs e)
        {
            Log.Debug("GestureSample", "_edgeDragEventHandler callback");
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Cx: " + e.Cx + ", Cy: " + e.Cy + ", Edge: " + (GestureEdge)e.Edge);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _tapEventHandler(object sender, TapEventArgs e)
        {
            Log.Debug("GestureSample", "_tapEventHandler callback");
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Fingers: " + e.Fingers + ", Repeats: " + e.Repeats);
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"> The sender object. </param>
        /// <param name="e"> Argument of Event. </param>
        private static void _palmCoverEventHandler(object sender, PalmCoverEventArgs e)
        {
            Log.Debug("GestureSample", "_palmCoverEventHandler callback");
            Log.Debug("GestureSample", "Mode: " + (GestureMode)e.Mode + ", Duration: " + e.Duration + ", Cx: " + e.Cx + ", Cy: " + e.Cy + ", Size: " + e.Size + ", Pressure: " + e.Pressure);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private InputGesture inputGesture;
        private EdgeSwipeData edgeSwipeData;
        private EdgeDragData edgeDragData;
        private TapData tapData;
        private PalmCoverData palmCoverData;

        private TextLabel centerLabel;
        int repeatCounter = 0;
        int touchCounter = 0;

        bool edgeSwipeGrabbed;
        bool edgeDragGrabbed;
        bool tapGrabbed;
        bool palmCoverGrabbed;
    }
}
