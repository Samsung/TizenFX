/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class Window
    {
        #region Constant Fields
        #endregion //Constant Fields

        #region Fields
        private BorderWindowInterface borderWindowInterface = null;
        private Layer borderWindowRootLayer = null;
        private Layer borderWindowBottomLayer = null;
        private bool isBorderWindow = false;

        // for border area
        private View rootView = null;
        private View layerView = null;

        // for window area
        private View windowView = null;
        private bool isWinGestures = false;
        private Timer timer;

        private CurrentGesture currentGesture = CurrentGesture.None;
        private float preScale = 1;
        private ResizeDirection direction = ResizeDirection.None;
        private CurrentStyle currentStyle = CurrentStyle.DefaultStyle;
        #endregion //Fields

        #region Constructors
        #endregion //Constructors

        #region Distructors
        #endregion //Distructors

        #region Delegates
        #endregion //Delegates

        #region Events
        private PanGestureDetector borderPanGestureDetector;
        private PanGestureDetector winPanGestureDetector;
        private TapGestureDetector winTapGestureDetector;
        private PinchGestureDetector winPinchGestureDetector;
        #endregion //Events

        #region Enums
        private enum CurrentStyle
        {
            DefaultStyle = 1,
            CustomStyle = 2,
        }
        private enum CurrentGesture
        {
          None = 0,
          TapGesture = 1,
          PanGesture = 2,
          PinchGesture = 3,
        }
        #endregion //Enums

        #region Interfaces
        #endregion //Interfaces

        #region Properties
        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBorderEnabled => isBorderWindow;
        #endregion //Properties

        #region Indexers
        #endregion //Indexers

        #region Methods


        /// <summary>
        /// Enable the border window with BorderWindowInterface.
        /// This adds a border area to the Window.
        /// The border's UI is configured using BorderWindowInterface.
        /// Users can reisze and move by touching the border area.
        /// </summary>
        /// <param name="borderInterface">The BorderWindowInterface.</param>
        /// <returns>Whether the border window is enabled</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableBorderWindow(BorderWindowInterface borderInterface = null)
        {
            if (isBorderWindow == true)
            {
                Tizen.Log.Error("NUI", $"Already EnableBorderWindow\n");
                return false;
            }
            if (borderInterface == null)
            {
                // default border window style
                currentStyle = CurrentStyle.DefaultStyle;
                SetTransparency(true);
                BackgroundColor = Color.Transparent;
                borderInterface = new BorderWindow();
            }
            else
            {
                currentStyle = CurrentStyle.CustomStyle;
            }

            GetDefaultLayer().Name = "OriginalRootLayer";
            borderInterface.SetWindow(this);
            borderWindowInterface = borderInterface;

            Resized += OnBorderWindowResized;

            isBorderWindow = true;

            // The current window is as below
            //    *****
            //    *****
            // Increase the window size as much as the border area.
            ///  #######
            ///  #*****#
            ///  #*****#
            ///  #$$$$$#
            ///  #$$$$$#
            /// '#' is BorderLineThickness
            /// '$' is BorderHeight
            WindowSize += new Size2D((int)borderWindowInterface.BorderLineThickness * 2, (int)(borderWindowInterface.Height + borderWindowInterface.BorderLineThickness));

            if (CreateBorder() == false)
            {
                WindowSize -= new Size2D((int)borderWindowInterface.BorderLineThickness * 2, (int)(borderWindowInterface.Height + borderWindowInterface.BorderLineThickness));
                Resized -= OnBorderWindowResized;
                isBorderWindow = false;
                return false;
            }

            // This is necessary to intercept window gestures.
            AddInterceptGesture();

            // EnableFloatingMode(true);

            return true;
        }

        /// Create the border UI.
        private bool CreateBorder()
        {
            rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = borderWindowInterface.BackgroundColor,
            };

            // Gets the Border's UI.
            borderWindowInterface.CreateBorderView(rootView);
            if (rootView == null)
            {
                return false;
            }
            else
            {
                // The user may have directly changed the backgroundColor of the rootView. So, we save the BackgroundColor again.
                borderWindowInterface.BackgroundColor = new Color(rootView.BackgroundColor);

                // Add a view to the border layer.
                GetBorderWindowBottomLayer().Add(rootView);

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
                        Color bgColor = new Color(borderWindowInterface.BackgroundColor);
                        bgColor.R = bgColor.R + 0.3f > 1.0f ? 1.0f : bgColor.R + 0.3f;
                        bgColor.G = bgColor.G + 0.3f > 1.0f ? 1.0f : bgColor.G + 0.3f;
                        bgColor.B = bgColor.B + 0.3f > 1.0f ? 1.0f : bgColor.B + 0.3f;
                        bgColor.A = bgColor.A + 0.1f > 1.0f ? 1.0f : bgColor.A + 0.1f;
                        rootView.BackgroundColor = bgColor;
                    }
                    else
                    {
                        rootView.BackgroundColor = borderWindowInterface.BackgroundColor;
                    }
                    return true;
                };

                winPinchGestureDetector = new PinchGestureDetector();
                winPinchGestureDetector.Attach(rootView);
                winPinchGestureDetector.Detected += (s, e) =>
                {
                    Tizen.Log.Error("NUI", $"winPinchGestureDetector {e.PinchGesture.Scale}, {e.PinchGesture.State}\n");
                    if (e.PinchGesture.State == Gesture.StateType.Started)
                    {
                        preScale = 1;
                    }
                    else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
                    {
                    Tizen.Log.Error("NUI", $"winPinchGestureDetector {preScale} {e.PinchGesture.Scale}\n");
                    if (preScale > e.PinchGesture.Scale)
                        {
                            if (IsMaximized())
                            {
                               Maximize(false);
                            }
                            else
                            {
                               Minimize(true);
                            }
                        }
                        else
                        {
                           Maximize(true);
                        }
                        borderWindowInterface.ChangedMax();
                    }
                };

                return true;
            }
        }

        /// Determines the behavior of borders.
        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            PanGesture panGesture = e.PanGesture;

            if (panGesture.State == Gesture.StateType.Started)
            {
                SetDirection(panGesture);
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
                direction = ResizeDirection.None;
                ClearWindowGesture();
            }
            borderWindowInterface.ChangedMax();
        }

        private void SetDirection(PanGesture panGesture)
        {
            float xPosition = panGesture.Position.X;
            float yPosition = panGesture.Position.Y;
            direction = ResizeDirection.None;


            // check bottom left corner
            if (xPosition < borderWindowInterface.TouchThickness && yPosition > WindowSize.Height + borderWindowInterface.Height - borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.BottomLeft;
            }
            // check bottom right corner
            else if (xPosition > WindowSize.Width + borderWindowInterface.BorderLineThickness*2 - borderWindowInterface.TouchThickness && yPosition > WindowSize.Height + borderWindowInterface.Height - borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.BottomRight;
            }
            // check top left corner
            else if (xPosition < borderWindowInterface.TouchThickness && yPosition <  borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.TopLeft;
            }
            // check top right corner
            else if (xPosition > WindowSize.Width + borderWindowInterface.BorderLineThickness*2 - borderWindowInterface.TouchThickness && yPosition < borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.TopRight;
            }
            // check left side
            else if (xPosition < borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.Left;
            }
            // check right side
            else if (xPosition > WindowSize.Width + borderWindowInterface.BorderLineThickness*2 - borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.Right;
            }
            // check bottom side
            else if (yPosition > WindowSize.Height + borderWindowInterface.Height + borderWindowInterface.BorderLineThickness - borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.Bottom;
            }
            // check top side
            else if (yPosition < borderWindowInterface.TouchThickness)
            {
                direction = ResizeDirection.Top;
            }
            // check move
            else if (yPosition > WindowSize.Height)
            {
                direction = ResizeDirection.Move;
            }

            if (IsMaximized() == true)
            {
                Maximize(false);
            }
            else
            {
                if (direction == ResizeDirection.Move)
                {
                    RequestMoveToServer();
                }
                else if (direction != ResizeDirection.None)
                {
                    ResetMinMax();
                    RequestResizeToServer(direction);
                }
            }

        }

        // Register an intercept touch event on the window.
        private void AddInterceptGesture()
        {
            isWinGestures = false;
            this.InterceptTouchEvent += OnWinInterceptedTouch;
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
            GetBorderWindowRootLayer().Add(windowView);

            winTapGestureDetector = new TapGestureDetector();
            winTapGestureDetector.Attach(windowView);
            winTapGestureDetector.SetMaximumTapsRequired(3);
            winTapGestureDetector.Detected += OnWinTapGestureDetected;

            // winPinchGestureDetector = new PinchGestureDetector();
            // winPinchGestureDetector.Attach(windowView);
            // winPinchGestureDetector.Detected += OnWinPinchGestureDetected;

            winPanGestureDetector = new PanGestureDetector();
            winPanGestureDetector.Attach(windowView);
            winPanGestureDetector.Detected += OnWinPanGestureDetected;

            this.InterceptTouchEvent -= OnWinInterceptedTouch;
            isWinGestures = true;
            return false;
        }

        internal void DisposeBorder()
        {
            ClearWindowGesture();
            InterceptTouchEvent -= OnWinInterceptedTouch;
            Resized -= OnBorderWindowResized;
            if(winPinchGestureDetector!=null)
            {
                winPinchGestureDetector.Dispose();
            }
            GetBorderWindowBottomLayer().Dispose();
        }

        internal void ClearWindowGesture()
        {
            if (isWinGestures)
            {
                winPanGestureDetector.Dispose();
                winTapGestureDetector.Dispose();

                isWinGestures = false;
                GetBorderWindowRootLayer().Remove(windowView);
                this.InterceptTouchEvent += OnWinInterceptedTouch;
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
                  if (IsMaximized() == false)
                  {
                    Maximize(true);
                  }
                  else
                  {
                    Maximize(false);
                  }
                  borderWindowInterface.ChangedMax();
              }
              else
              {
                  ClearWindowGesture();
              }
          }
        }

        // Behavior when the window is pinched.
        // TODO Currently, the client is resizing, but if the display server provides a function, use the display server api.
        private void OnWinPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
        {
            if (currentGesture <= CurrentGesture.PinchGesture)
            {
                if (e.PinchGesture.State == Gesture.StateType.Started)
                {
                    currentGesture = CurrentGesture.PinchGesture;
                    preScale = 1;
                }
                else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
                {
                    currentGesture = CurrentGesture.None;
                    ClearWindowGesture();
                }
                else
                {
                    if (preScale > e.PinchGesture.Scale)
                    {
                        this.WindowSize -= new Size2D(10, 10);
                    }
                    else
                    {
                        this.WindowSize += new Size2D(10, 10);
                    }
                }
                preScale = e.PinchGesture.Scale;
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
                    if (IsMaximized() == true)
                    {
                        Maximize(false);
                    }
                    else
                    {
                        RequestMoveToServer();
                    }
                }
                else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
                {
                    currentGesture = CurrentGesture.None;
                    ClearWindowGesture();
                }
                borderWindowInterface.ChangedMax();
            }
        }

        // Called when the window size has changed.
        private void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
            bool isMax = IsMaximized();
            Tizen.Log.Error("gab_test", $"OnBorderWindowResized {e.WindowSize.Width},{e.WindowSize.Height}, {isMax}\n");
            int resizeWidth = e.WindowSize.Width;
            int resizeHeight = e.WindowSize.Height;
            if (borderWindowInterface.MinSize != null)
            {
                resizeWidth = borderWindowInterface.MinSize.Width > resizeWidth ? (int)borderWindowInterface.MinSize.Width : resizeWidth;
                resizeHeight = borderWindowInterface.MinSize.Height > resizeHeight ? (int)borderWindowInterface.MinSize.Height : resizeHeight;
            }

            if (borderWindowInterface.MaxSize != null)
            {
                resizeWidth = borderWindowInterface.MaxSize.Width < resizeWidth ? (int)borderWindowInterface.MaxSize.Width : resizeWidth;
                resizeHeight = borderWindowInterface.MaxSize.Height < resizeHeight ? (int)borderWindowInterface.MaxSize.Height : resizeHeight;
            }

            if (resizeWidth != e.WindowSize.Width || resizeHeight != e.WindowSize.Height)
            {
                WindowSize = new Size2D(resizeWidth, resizeHeight);
            }
            Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
            Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth+borderWindowInterface.BorderLineThickness*2, resizeHeight+borderWindowInterface.Height+borderWindowInterface.BorderLineThickness);

            if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
        }

        internal Layer GetBorderWindowBottomLayer()
        {
            if (borderWindowBottomLayer == null)
            {
                borderWindowBottomLayer = new Layer();
                borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width+borderWindowInterface.BorderLineThickness*2, WindowSize.Height+borderWindowInterface.BorderLineThickness);
                borderWindowBottomLayer.SetWindow(this);
                borderWindowBottomLayer.LowerToBottom();

                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }
            return borderWindowBottomLayer;
        }

        internal Layer GetBorderWindowRootLayer()
        {
            if (borderWindowRootLayer == null)
            {
                borderWindowRootLayer = new Layer();
                borderWindowRootLayer.Name = "RootLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height-borderWindowInterface.Height-borderWindowInterface.BorderLineThickness);
                Interop.ActorInternal.SetPosition(borderWindowRootLayer.SwigCPtr, 0, borderWindowInterface.BorderLineThickness);

                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }

            return borderWindowRootLayer;
        }

        internal View LayerView()
        {
            return layerView;
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() + borderWindowInterface.Height+borderWindowInterface.BorderLineThickness);
                var width = (ushort)(size.GetWidth() + borderWindowInterface.BorderLineThickness*2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() - borderWindowInterface.Height-borderWindowInterface.BorderLineThickness);
                var width = (ushort)(size.GetWidth() - borderWindowInterface.BorderLineThickness*2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }
        #endregion //Methods

        #region Structs
        #endregion //Structs

        #region Classes
        internal class BorderWindow : BorderWindowInterface
        {
        }
        #endregion //Classes
    }



}
