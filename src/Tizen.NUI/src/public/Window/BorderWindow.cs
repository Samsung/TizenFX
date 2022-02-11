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

        // for window area
        private View windowView = null;
        private bool isWinGestures = false;
        private Timer timer;

        private CommandType commandType = CommandType.None;
        private CurrentGesture currentGesture = CurrentGesture.None;
        private Size2D preSize;
        private float preScale = 1;
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
        private enum CommandType
        {
            None = 0,
            ResizeLeftSide = 1,
            ResizeRightSide = 2,
            ResizeHeightSide = 3,
            ResizeLeftCorner = 4,
            ResizeRightCorner = 5,
            Move = 6,
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBorderEnabled => isBorderWindow;
        #endregion //Properties

        #region Indexers
        #endregion //Indexers

        #region Methods


        public bool EnableBorderWindow()
        {
            BorderWindow borderInterface = new BorderWindow();
            return EnableBorderWindow(borderInterface);
        }

        public bool EnableBorderWindow(BorderWindowInterface borderInterface)
        {
            if (isBorderWindow == true)
            {
                Tizen.Log.Error("gab_test", $"Already EnableBorderWindow\n");
                return false;
            }
            GetDefaultLayer().Name = "OriginalRootLayer";
            borderInterface.SetWindow(this);
            borderWindowInterface = borderInterface;

            Resized += OnBorderWindowResized;

            isBorderWindow = true;

            WindowSize += new Size2D(0, borderWindowInterface.Height);

            if (CreateBorder() == false)
            {
                WindowSize -= new Size2D(0, borderWindowInterface.Height);
                Resized -= OnBorderWindowResized;
                isBorderWindow = false;
                return false;
            }

            AddInterceptGesture();

            preSize = WindowSize;

            isWinGestures = false;

            EnableFloatingMode(true);

            return true;
        }

        private bool CreateBorder()
        {
            rootView = borderWindowInterface.CreateBorderView();
            if (rootView == null)
            {
                return false;
            }
            else
            {
                borderPanGestureDetector = new PanGestureDetector();
                borderPanGestureDetector.Attach(rootView);
                borderPanGestureDetector.Detected += OnPanGestureDetected;

                GetBorderWindowBottomLayer().Add(rootView);
                return true;
            }

        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            PanGesture panGesture = e.PanGesture;

            Tizen.Log.Error("gab_test", $"OnPanGestureDetected {panGesture.State}\n");

            if (panGesture.State == Gesture.StateType.Started)
            {
                commandType = GetCommandType(panGesture);
                Tizen.Log.Error("gab_test", $"OnPanGestureDetected {commandType}\n");
            }
            else if (panGesture.State == Gesture.StateType.Continuing)
            {
                if (commandType == CommandType.ResizeLeftCorner)
                {
                    WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
                if (commandType == CommandType.ResizeRightCorner)
                {
                    WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
                else if (commandType == CommandType.ResizeLeftSide)
                {
                    WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
                }
                else if (commandType == CommandType.ResizeRightSide)
                {
                    WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
                }
                else if (commandType == CommandType.ResizeHeightSide)
                {
                    WindowSize += new Size2D(0, (int)panGesture.ScreenDisplacement.Y);
                }
                else if (commandType == CommandType.Move)
                {
                    WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
            }
            else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
            {
                commandType = CommandType.None;
                ClearWindowGesture();
            }
        }

        private CommandType GetCommandType(PanGesture panGesture)
        {
            float xPosition = panGesture.Position.X;
            float yPosition = panGesture.Position.Y;

            // check left corner
            if (xPosition < borderWindowInterface.TouchThickness && yPosition > borderWindowInterface.Height - borderWindowInterface.TouchThickness)
            {
                RequestResizeToServer(ResizeDirection.BottomLeft);
                return CommandType.ResizeLeftCorner;
            }
            // check right corner
            else if (xPosition > WindowSize.Width - borderWindowInterface.TouchThickness && yPosition > borderWindowInterface.Height - borderWindowInterface.TouchThickness)
            {
                RequestResizeToServer(ResizeDirection.BottomRight);
                return CommandType.ResizeRightCorner;
            }
            // check left side
            else if (xPosition < borderWindowInterface.TouchThickness)
            {
                RequestResizeToServer(ResizeDirection.Left);
                return CommandType.ResizeLeftSide;
            }
            // check right side
            else if (xPosition > WindowSize.Width - borderWindowInterface.TouchThickness)
            {
                RequestResizeToServer(ResizeDirection.Right);
                return CommandType.ResizeRightSide;
            }
            // check bottom side
            else if (yPosition > borderWindowInterface.Height - borderWindowInterface.TouchThickness + 10)
            {
                RequestResizeToServer(ResizeDirection.Bottom);
                return CommandType.ResizeHeightSide;
            }
            // check move
            else
            {
                RequestMoveToServer();
                return CommandType.Move;
            }
        }

        // Register an intercept touch event on the window.
        private void AddInterceptGesture()
        {
            this.InterceptTouchEvent += OnWinInterceptedTouch;
        }

        private bool OnWinInterceptedTouch(object sender, Window.TouchEventArgs e)
        {
            Tizen.Log.Error("gab_test", $"OnWinInterceptedTouch {e.Touch.GetPointCount()} {e.Touch.GetState(0)}\n");

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
            Tizen.Log.Error("gab_test", $"OnTick\n");

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

            winPinchGestureDetector = new PinchGestureDetector();
            winPinchGestureDetector.Attach(windowView);
            winPinchGestureDetector.Detected += OnWinPinchGestureDetected;

            winPanGestureDetector = new PanGestureDetector();
            winPanGestureDetector.Attach(windowView);
            winPanGestureDetector.Detected += OnWinPanGestureDetected;

            this.InterceptTouchEvent -= OnWinInterceptedTouch;
            isWinGestures = true;
            return false;
        }

        internal void ClearWindowGesture()
        {
            if (isWinGestures)
            {
                winPanGestureDetector.Dispose();
                winPinchGestureDetector.Dispose();
                winTapGestureDetector.Dispose();

                isWinGestures = false;
                GetBorderWindowRootLayer().Remove(windowView);
                this.InterceptTouchEvent += OnWinInterceptedTouch;
            }
        }

        private void OnWinTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
          Tizen.Log.Error("gab_test", $"OnTapGestureDetected {e.TapGesture.NumberOfTaps}, {e.TapGesture.NumberOfTouches}\n");
          if (currentGesture <= CurrentGesture.TapGesture)
          {
              currentGesture = CurrentGesture.TapGesture;
              if (e.TapGesture.NumberOfTaps == 2)
              {
                  preSize = this.WindowSize;

                  // TODO
                  this.WindowSize = new Size2D(800, 600-borderWindowInterface.Height);
              }
              else if (e.TapGesture.NumberOfTaps == 3)
              {
                  this.WindowSize = preSize;
              }
              else
              {
                  ClearWindowGesture();
              }
          }
        }

        // TODO Currently, the client is resizing, but if the display server provides a function, use the display server api.
        private void OnWinPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
        {
            if (currentGesture <= CurrentGesture.PinchGesture)
            {
                Tizen.Log.Error("gab_test", $"OnPinchGestureDetected \n");
                if (e.PinchGesture.State == Gesture.StateType.Started)
                {
                    currentGesture = CurrentGesture.PinchGesture;
                    preScale = 1;
                    preSize = this.WindowSize;
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

        private void OnWinPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (currentGesture <= CurrentGesture.PanGesture /*&& panGesture.NumberOfTouches == 1*/)
            {
                PanGesture panGesture = e.PanGesture;
                Tizen.Log.Error("gab_test", $"OnWinPanGestureDetected {panGesture.State}\n");

                if (panGesture.State == Gesture.StateType.Started)
                {
                    currentGesture = CurrentGesture.PanGesture;
                    this.RequestMoveToServer();
                }
                else if (panGesture.State == Gesture.StateType.Continuing)
                {
                    this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
                else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
                {
                    currentGesture = CurrentGesture.None;
                    ClearWindowGesture();
                }
            }
        }

        private void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
            Tizen.Log.Error("gab_test", $"OnBorderWindowResized {WindowSize.Width},{WindowSize.Height}\n");
            int resizeWidth = WindowSize.Width;
            int resizeHeight = WindowSize.Height;
            // if (style.MinSize != null)
            // {
            //     resizeWidth = style.MinSize.Width > resizeWidth ? (int)style.MinSize.Width : resizeWidth;
            //     resizeHeight = style.MinSize.Height > resizeHeight ? (int)style.MinSize.Height : resizeHeight;
            // }

            // if (style.MaxSize != null)
            // {
            //     resizeWidth = style.MaxSize.Width < resizeWidth ? (int)style.MaxSize.Width : resizeWidth;
            //     resizeHeight = style.MaxSize.Height < resizeHeight ? (int)style.MaxSize.Height : resizeHeight;
            // }

            // if (resizeWidth != WindowSize.Width || resizeHeight != WindowSize.Height)
            // {
            //     WindowSize = new Size2D(resizeWidth, resizeHeight);
            // }
            Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
            Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth, borderWindowInterface.Height);

            if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
        }

        internal Layer GetBorderWindowBottomLayer()
        {
            if (borderWindowBottomLayer == null)
            {
                borderWindowBottomLayer = new Layer();
                borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.ParentOrigin.BottomCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.PivotPoint.BottomCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width, borderWindowInterface.Height);
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
                Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopLeft.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopLeft.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height-100);
                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }

            return borderWindowRootLayer;
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() + borderWindowInterface.Height);
                size.SetHeight(height);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() - borderWindowInterface.Height);
                size.SetHeight(height);
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
