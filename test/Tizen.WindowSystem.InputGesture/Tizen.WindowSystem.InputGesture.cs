/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using Tizen.WindowSystem;

namespace Tizen.WindowSystem.InputGestureTest
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
            Window win = Window.Default;
            inputGesture = new InputGesture();

            win.WindowSize = new Size2D(500, 500);
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.White;

            View windowView = new View();
            windowView.Size2D = new Size2D(500, 500);
            windowView.BackgroundColor = Color.White;
            windowView.TouchEvent += OnTouchEvent;
            win.Add(windowView);

            centerLabel = new TextLabel("InputGesture Sample\n[S] EdgeSwipe  [D] EdgeDrag\n[T] Tap  [P] PalmCover\n[G] EdgeSwipe(Shared)");
            centerLabel.HorizontalAlignment = HorizontalAlignment.Center;
            centerLabel.VerticalAlignment = VerticalAlignment.Center;
            centerLabel.TextColor = Color.Black;
            centerLabel.PointSize = 12.0f;
            centerLabel.HeightResizePolicy = ResizePolicyType.FillToParent;
            centerLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            centerLabel.MultiLine = true;
            windowView.Add(centerLabel);
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }

            // [S] EdgeSwipe: 2 fingers, Left edge
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "S" || e.Key.KeyPressedName == "s"))
            {
                if (!edgeSwipeRegistered)
                {
                    inputGesture.RegisterEdgeSwipe(2, GestureEdge.Left);
                    inputGesture.EdgeSwipeDetected += OnEdgeSwipeDetected;
                    centerLabel.Text = "'S' Key Pressed. EdgeSwipe Registered";
                    edgeSwipeRegistered = true;
                }
                else
                {
                    inputGesture.EdgeSwipeDetected -= OnEdgeSwipeDetected;
                    inputGesture.UnregisterEdgeSwipe(2, GestureEdge.Left);
                    centerLabel.Text = "'S' Key Pressed. EdgeSwipe Unregistered";
                    edgeSwipeRegistered = false;
                }
            }

            // [D] EdgeDrag: 2 fingers, Right edge
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "D" || e.Key.KeyPressedName == "d"))
            {
                if (!edgeDragRegistered)
                {
                    inputGesture.RegisterEdgeDrag(2, GestureEdge.Right);
                    inputGesture.EdgeDragDetected += OnEdgeDragDetected;
                    centerLabel.Text = "'D' Key Pressed. EdgeDrag Registered";
                    edgeDragRegistered = true;
                }
                else
                {
                    inputGesture.EdgeDragDetected -= OnEdgeDragDetected;
                    inputGesture.UnregisterEdgeDrag(2, GestureEdge.Right);
                    centerLabel.Text = "'D' Key Pressed. EdgeDrag Unregistered";
                    edgeDragRegistered = false;
                }
            }

            // [T] Tap: 3 fingers, 2 repeats
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "T" || e.Key.KeyPressedName == "t"))
            {
                if (!tapRegistered)
                {
                    inputGesture.RegisterTap(3, 2);
                    inputGesture.TapDetected += OnTapDetected;
                    centerLabel.Text = "'T' Key Pressed. Tap Registered";
                    tapRegistered = true;
                }
                else
                {
                    inputGesture.TapDetected -= OnTapDetected;
                    inputGesture.UnregisterTap(3, 2);
                    centerLabel.Text = "'T' Key Pressed. Tap Unregistered";
                    tapRegistered = false;
                }
            }

            // [P] PalmCover
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "P" || e.Key.KeyPressedName == "p"))
            {
                if (!palmCoverRegistered)
                {
                    inputGesture.RegisterPalmCover();
                    inputGesture.PalmCoverDetected += OnPalmCoverDetected;
                    centerLabel.Text = "'P' Key Pressed. PalmCover Registered";
                    palmCoverRegistered = true;
                }
                else
                {
                    inputGesture.PalmCoverDetected -= OnPalmCoverDetected;
                    inputGesture.UnregisterPalmCover();
                    centerLabel.Text = "'P' Key Pressed. PalmCover Unregistered";
                    palmCoverRegistered = false;
                }
            }

            // [G] EdgeSwipe with Shared grab mode: 1 finger, Left edge
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "G" || e.Key.KeyPressedName == "g"))
            {
                if (!edgeSwipeSharedRegistered)
                {
                    inputGesture.RegisterEdgeSwipe(1, GestureEdge.Left, grabMode: GestureGrabMode.Shared);
                    inputGesture.EdgeSwipeDetected += OnEdgeSwipeDetected;
                    centerLabel.Text = "'G' Key Pressed. EdgeSwipe Shared Registered";
                    edgeSwipeSharedRegistered = true;
                }
                else
                {
                    inputGesture.EdgeSwipeDetected -= OnEdgeSwipeDetected;
                    inputGesture.UnregisterEdgeSwipe(1, GestureEdge.Left);
                    centerLabel.Text = "'G' Key Pressed. EdgeSwipe Shared Unregistered";
                    edgeSwipeSharedRegistered = false;
                }
            }
        }

        private bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            return true;
        }

        private void OnEdgeSwipeDetected(object sender, EdgeGestureEventArgs e)
        {
            Log.Debug("GestureSample", "EdgeSwipe - State: " + e.State + ", Fingers: " + e.Fingers + ", X: " + e.X + ", Y: " + e.Y + ", Edge: " + e.Edge);
        }

        private void OnEdgeDragDetected(object sender, EdgeGestureEventArgs e)
        {
            Log.Debug("GestureSample", "EdgeDrag - State: " + e.State + ", Fingers: " + e.Fingers + ", X: " + e.X + ", Y: " + e.Y + ", Edge: " + e.Edge);
        }

        private void OnTapDetected(object sender, TapEventArgs e)
        {
            Log.Debug("GestureSample", "Tap - State: " + e.State + ", Fingers: " + e.Fingers + ", Repeats: " + e.Repeats);
        }

        private void OnPalmCoverDetected(object sender, PalmCoverEventArgs e)
        {
            Log.Debug("GestureSample", "PalmCover - State: " + e.State + ", Duration: " + e.Duration + ", CenterX: " + e.CenterX + ", CenterY: " + e.CenterY + ", Size: " + e.Size + ", Pressure: " + e.Pressure);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private InputGesture inputGesture;
        private TextLabel centerLabel;

        bool edgeSwipeRegistered;
        bool edgeDragRegistered;
        bool tapRegistered;
        bool palmCoverRegistered;
        bool edgeSwipeSharedRegistered;
    }
}
