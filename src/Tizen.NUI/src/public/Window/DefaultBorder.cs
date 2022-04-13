/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This abstract class is needed to configure borderWindowUI.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultBorder : BorderInterface
    {
        #region Constant Fields
        private static readonly string ResourcePath = FrameworkInformation.ResourcePath;
        // private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";
        private static readonly string MinimalizeIcon = ResourcePath + "minimalize.png";
        private static readonly string MaximalizeIcon = ResourcePath + "maximalize.png";
        private static readonly string PreviousIcon = ResourcePath + "smallwindow.png";
        private static readonly string CloseIcon = ResourcePath + "close.png";
        private static readonly string LeftCornerIcon = ResourcePath + "leftCorner.png";
        private static readonly string RightCornerIcon = ResourcePath + "rightCorner.png";


        private static readonly string DarkMinimalizeIcon = ResourcePath + "dark_minimalize.png";
        private static readonly string DarkMaximalizeIcon = ResourcePath + "dark_maximalize.png";
        private static readonly string DarkPreviousIcon = ResourcePath + "dark_smallwindow.png";
        private static readonly string DarkCloseIcon = ResourcePath + "dark_close.png";
        private static readonly string DarkLeftCornerIcon = ResourcePath + "dark_leftCorner.png";
        private static readonly string DarkRightCornerIcon = ResourcePath + "dark_rightCorner.png";


        private static readonly uint DefaultHeight = 50;
        private static readonly uint DefaultLineThickness = 5;
        private static readonly uint DefaultTouchThickness = 20;
        private static readonly Color DefaultBackgroundColor = new Color(1, 1, 1, 0.3f);
        private static readonly Size2D DefaultMinSize = new Size2D(200, 0);
        #endregion //Constant Fields


        #region Fields
        private Color backgroundColor = DefaultBackgroundColor;
        private Window window = null;

        private ImageView minimalizeIcon;
        private ImageView maximalizeIcon;
        private ImageView closeIcon;
        private ImageView leftCornerIcon;
        private ImageView rightCornerIcon;

        private Window.ResizeDirection direction = Window.ResizeDirection.None;
        private float preScale = 0;

        private View windowView = null;
        private bool isWinGestures = false;
        private Timer timer;

        private CurrentGesture currentGesture = CurrentGesture.None;
        #endregion //Fields

        #region Events
        private PanGestureDetector borderPanGestureDetector;
        private PinchGestureDetector borderPinchGestureDetector;
        private PanGestureDetector winPanGestureDetector;
        private TapGestureDetector winTapGestureDetector;
        #endregion //Events

        #region Enums
        private enum CurrentGesture
        {
          None = 0,
          TapGesture = 1,
          PanGesture = 2,
          PinchGesture = 3,
        }
        #endregion //Enums

        #region Methods

        public Color GetDefaultBackgroundColor()
        {
            return DefaultBackgroundColor;
        }

        public virtual void SetWindow(Window window)
        {
          this.window = window;
        }

        public virtual Window GetWindow()
        {
            return window;
        }


        private View rootView;
        /// <summary>
        /// Create border UI. Users can override this method to draw border UI.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CreateBorderView(View rootView)
        {
            this.rootView = rootView;
            rootView.BackgroundColor = DefaultBackgroundColor;
            rootView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
            rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;

            View borderView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.End,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            minimalizeIcon = new ImageView()
            {
                ResourceUrl = MinimalizeIcon,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
            };

            maximalizeIcon = new ImageView()
            {
                ResourceUrl = MaximalizeIcon,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
            };

            closeIcon = new ImageView()
            {
                ResourceUrl = CloseIcon,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
            };

            leftCornerIcon = new ImageView()
            {
                ResourceUrl = LeftCornerIcon,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
            };

            rightCornerIcon = new ImageView()
            {
              ResourceUrl = RightCornerIcon,
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
            };

            rootView.Add(leftCornerIcon);
            borderView.Add(minimalizeIcon);
            borderView.Add(maximalizeIcon);
            borderView.Add(closeIcon);
            borderView.Add(rightCornerIcon);
            rootView.Add(borderView);

            minimalizeIcon.TouchEvent += OnMinTouched;
            maximalizeIcon.TouchEvent += OnMaxTouched;
            closeIcon.TouchEvent += OnCloseTouched;
            leftCornerIcon.TouchEvent += OnLeftCornerTouched;
            rightCornerIcon.TouchEvent += OnRightCornerTouched;         
        }
        
        /// Determines the behavior of pinch gesture.
        private void OnPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
        {
            Tizen.Log.Error("gab_test", $"OnPinchGestureDetected {e.PinchGesture.Scale}, {e.PinchGesture.State}\n");
            if (e.PinchGesture.State == Gesture.StateType.Started)
            {
                preScale = e.PinchGesture.Scale;
            }
            else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
            {
            Tizen.Log.Error("gab_test", $"OnPinchGestureDetected {preScale} {e.PinchGesture.Scale}\n");
            if (preScale > e.PinchGesture.Scale)
                {
                    if (window.IsMaximized())
                    {
                        window.Maximize(false);
                    }
                    else
                    {
                        window.Minimize(true);
                    }
                }
                else
                {
                    window.Maximize(true);
                }
            }
        }

        /// Determines the behavior of borders.
        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            PanGesture panGesture = e.PanGesture;

            if (panGesture.State == Gesture.StateType.Started)
            {
                Window.ResizeDirection direction = window.GetDirection(panGesture);
                if (direction == Window.ResizeDirection.Move)
                {
                    window.RequestMoveToServer();
                }
                else if (direction != Window.ResizeDirection.None)
                {
                    window.ResetMinMax();
                    window.RequestResizeToServer(direction);
                }
            }
            // else if (panGesture.State == Gesture.StateType.Continuing)
            // {
            //     if (direction == ResizeDirection.BottomLeft || direction == ResizeDirection.BottomRight || direction == ResizeDirection.TopLeft || direction == ResizeDirection.TopRight)
            //     {
            //         WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
            //     }
            //     else if (direction == ResizeDirection.Left || direction == ResizeDirection.Right)
            //     {
            //         WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
            //     }
            //     else if (direction == ResizeDirection.Bottom || direction == ResizeDirection.Top)
            //     {
            //         WindowSize += new Size2D(0, (int)panGesture.ScreenDisplacement.Y);
            //     }
            //     else if (direction == ResizeDirection.Move)
            //     {
            //         WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
            //     }
            // }
            else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
            {
                direction = Window.ResizeDirection.None;
                // ClearWindowGesture();
            }
        }


        /// <summary>
        /// This is an event callback when the left corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnLeftCornerTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              ClearWindowGesture();
              if(window.IsMinimized() == true)
              {
                window.RequestResizeToServer(Window.ResizeDirection.TopLeft);
              }
              else
              {
                window.RequestResizeToServer(Window.ResizeDirection.BottomLeft);
              }
              window.ResetMinMax();
            }
            return true;
        }

        /// <summary>
        ///This is an event callback when the right corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnRightCornerTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              ClearWindowGesture();
              if(window.IsMinimized() == true)
              {
                window.RequestResizeToServer(Window.ResizeDirection.TopRight);
              }
              else
              {
                window.RequestResizeToServer(Window.ResizeDirection.BottomRight);
              }
              window.ResetMinMax();
            }
            return true;
        }


        /// <summary>
        /// This is an event callback when the minimize button is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnMinTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                ClearWindowGesture();
                window.Minimize(true);
            }
            return true;
        }

        /// <summary>
        /// This is an event callback when the maximum button is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnMaxTouched(object sender, View.TouchEventArgs e)
        {
            Tizen.Log.Error("gab_test", $"OnMaxTouched\n");
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                ClearWindowGesture();
                if (window.IsMaximized())
                {
                  window.Maximize(false);
                }
                else
                {
                  window.Maximize(true);
                }
            }
            return true;
        }

        /// <summary>
        /// This is an event callback when the close button is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnCloseTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                window.Destroy();
                window = null;
            }
            return true;
        }


        private void ChangedMax()
        {
            if (window != null && rootView != null)
            {
                if (window.IsMaximized() == true)
                {
                    if (maximalizeIcon != null)
                    {
                        maximalizeIcon.ResourceUrl = DarkPreviousIcon;
                    }
                    if (minimalizeIcon != null)
                    {
                        minimalizeIcon.ResourceUrl = DarkMinimalizeIcon;
                    }
                    if (closeIcon != null)
                    {
                        closeIcon.ResourceUrl = DarkCloseIcon;
                    }
                    if (leftCornerIcon != null)
                    {
                        leftCornerIcon.ResourceUrl = DarkLeftCornerIcon;
                    }
                    if (rightCornerIcon != null)
                    {
                        rightCornerIcon.ResourceUrl = DarkRightCornerIcon;
                    }
                    rootView.CornerRadius = new Vector4(0, 0, 0, 0);
                    rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
                    window.SetTransparency(false);
                    window.BackgroundColor = Color.White;
                    Tizen.Log.Error("gab_test", $"Current Max icon Small\n");
                }
                else
                {
                    if (maximalizeIcon != null)
                    {
                        maximalizeIcon.ResourceUrl = MaximalizeIcon;
                    }
                    if (minimalizeIcon != null)
                    {
                        minimalizeIcon.ResourceUrl = MinimalizeIcon;
                    }
                    if (closeIcon != null)
                    {
                        closeIcon.ResourceUrl = CloseIcon;
                    }
                    if (leftCornerIcon != null)
                    {
                        leftCornerIcon.ResourceUrl = LeftCornerIcon;
                    }
                    if (rightCornerIcon != null)
                    {
                        rightCornerIcon.ResourceUrl = RightCornerIcon;
                    }
                    rootView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
                    rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
                    window.SetTransparency(true);
                    window.BackgroundColor = Color.Transparent;
                    Tizen.Log.Error("gab_test", $"Current NotMax icon Max\n");
                }
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreated(View rootView)
        {
            // Register to resize and move through pan gestures.
            borderPanGestureDetector = new PanGestureDetector();
            borderPanGestureDetector.Attach(rootView);
            borderPanGestureDetector.Detected += OnPanGestureDetected;

            // Register touch event for effect when border is touched.
            rootView.LeaveRequired = true;
            rootView.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Color bgColor = new Color(DefaultBackgroundColor);
                    bgColor.R = bgColor.R + 0.3f > 1.0f ? 1.0f : bgColor.R + 0.3f;
                    bgColor.G = bgColor.G + 0.3f > 1.0f ? 1.0f : bgColor.G + 0.3f;
                    bgColor.B = bgColor.B + 0.3f > 1.0f ? 1.0f : bgColor.B + 0.3f;
                    bgColor.A = bgColor.A + 0.1f > 1.0f ? 1.0f : bgColor.A + 0.1f;
                    rootView.BackgroundColor = bgColor;
                }
                else
                {
                    rootView.BackgroundColor = DefaultBackgroundColor;
                }
                return true;
            };   

            borderPinchGestureDetector = new PinchGestureDetector();
            borderPinchGestureDetector.Attach(rootView);
            borderPinchGestureDetector.Detected += OnPinchGestureDetected;

            AddInterceptGesture();

            Tizen.Log.Error("gab_test", $"OnCreated {window.Size.Width},{window.Size.Height}\n");
            if (window.Size.Width >= 1920 && window.Size.Height >= 1080)
            {
                window.Maximize(true);
            }
        }


        // Register an intercept touch event on the window.
        private void AddInterceptGesture()
        {
            isWinGestures = false;
            window.InterceptTouchEvent += OnWinInterceptedTouch;
        }

        // Intercept touch on window.
        private bool OnWinInterceptedTouch(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Stationary && e.Touch.GetPointCount() == 2)
            {
                if (isWinGestures == false && timer == null)
                {
                    timer = new Timer(300);
                    timer.Tick += OnTick;
                    timer.Start();
                }
            }
            else
            {
                currentGesture = CurrentGesture.None;
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
            return false;
        }

        // If two finger long press is done, create a windowView.
        // then, Register a gesture on the windowView to do a resize or move.
        private bool OnTick(object o, Timer.TickEventArgs e)
        {
            windowView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = new Vector4(1, 1, 1, 0.5f),
            };
            windowView.TouchEvent += (s, e) =>
            {
                return true;
            };
            window.Add(windowView);

            winTapGestureDetector = new TapGestureDetector();
            winTapGestureDetector.Attach(windowView);
            winTapGestureDetector.SetMaximumTapsRequired(3);
            winTapGestureDetector.Detected += OnWinTapGestureDetected;

            winPanGestureDetector = new PanGestureDetector();
            winPanGestureDetector.Attach(windowView);
            winPanGestureDetector.Detected += OnWinPanGestureDetected;

            window.InterceptTouchEvent -= OnWinInterceptedTouch;
            isWinGestures = true;
            return false;
        }

        public virtual void Dispose()
        {
            ClearWindowGesture();
            window.InterceptTouchEvent -= OnWinInterceptedTouch;
        }

        internal void ClearWindowGesture()
        {
            if (isWinGestures)
            {
                winPanGestureDetector.Dispose();
                winTapGestureDetector.Dispose();

                isWinGestures = false;
                window.Remove(windowView);
                window.InterceptTouchEvent += OnWinInterceptedTouch;
            }
        }

        // Behavior when the window is tapped.
        private void OnWinTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
          if (currentGesture <= CurrentGesture.TapGesture)
          {
              currentGesture = CurrentGesture.TapGesture;
              if (e.TapGesture.NumberOfTaps == 2)
              {
                  if (window.IsMaximized() == false)
                  {
                    window.Maximize(true);
                  }
                  else
                  {
                    window.Maximize(false);
                  }
              }
              else
              {
                  ClearWindowGesture();
              }
          }
        }

        // Window moves through pan gestures.
        private void OnWinPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (currentGesture <= CurrentGesture.PanGesture /*&& panGesture.NumberOfTouches == 1*/)
            {
                PanGesture panGesture = e.PanGesture;

                if (panGesture.State == Gesture.StateType.Started)
                {
                    currentGesture = CurrentGesture.PanGesture;
                    if (window.IsMaximized() == true)
                    {
                        window.Maximize(false);
                    }
                    else
                    {
                        window.RequestMoveToServer();
                    }
                }
                else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
                {
                    currentGesture = CurrentGesture.None;
                    ClearWindowGesture();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnResized(int width, int height)
        {
            ChangedMax();
        }


        public virtual uint GetBorderLineThickness()
        {
            return DefaultLineThickness;
        }

        public virtual uint GetTouchThickness()
        {
            return DefaultTouchThickness;
        }

        public virtual uint GetBorderHeight()
        {
            return DefaultHeight;
        }

        public virtual Size2D GetMinSize()
        {
            return DefaultMinSize;
        }

        public virtual Size2D GetMaxSize()
        {
            return null;
        }


        #endregion //Methods

    }
}
