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
    // public delegate void ResizeEventHandler(Size2D size);
    // public delegate void PositionEventHandler(Position2D position);

    public partial class Window
    {
        #region Constant Fields
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        #endregion //Constant Fields

        #region Fields
        //ToDo: need to be removed, should be implemented properly
        internal TextLabel borderText;


        private Layer borderWindowRootLayer = null;
        private Layer borderWindowBottomLayer = null;
        private bool isBorderWindow = false;

        private View borderView = null;
        private View gestureView = null;
        private PanGestureDetector panGestureDetector;
        private LongPressGestureDetector longPressGestureDetector;
        private TapGestureDetector tapGestureDetector;
        // private event ResizeEventHandler ResizeEvent;
        // private event PositionEventHandler PositionEvent;
        private CommandType commandType = CommandType.Unknown;
        private Position2D prePosition;
        private Vector2 displacement;

        //ToDo: need to set default value, 50 is just for test
        private int bottomLayerSize = 50;
        //ToDo: remove this later, this is just for test
        private int testCnt = 0;
        #endregion //Fields

        #region Constructors
        #endregion //Constructors

        #region Distructors
        #endregion //Distructors

        #region Delegates
        #endregion //Delegates

        #region Events
        #endregion //Events

        #region Enums
        internal enum CommandType
        {
            Unknown = 0,
            ResizeLeftSide = 1,
            ResizeRightSide = 2,
            ResizeHeightSide = 3,
            ResizeLeftCorner = 4,
            ResizeRightCorner = 5,
            Move = 6,
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct BorderStyle
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public BorderStyle(string text, string minUrl, string maxUrl, string partialUrl, string terminateUrl, Color backgroundColor, Color transparent, int height)
            {
              Text = text;
              MinUrl = minUrl;
              MaxUrl = maxUrl;
              PartialUrl = partialUrl;
              TerminateUrl = terminateUrl;
              BackgroundColor = backgroundColor;
              Transparent = transparent;
              Height = height;
            }
            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string MinUrl {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string MaxUrl {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string PartialUrl {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string TerminateUrl {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color BackgroundColor {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color Transparent {get; set;}

            /// <summary>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int Height {get; set;}
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
        public void EnableBorderWindow()
        {
          GetDefaultLayer().Name = "OriginalRootLayer";

          // this is very critical for the code order. this should be placed after GetDefaultLayer()!
          if (isBorderWindow == false)
          {
            Resized += OnBorderWindowResized;

            isBorderWindow = true;

            WindowSize += new Size2D(0, bottomLayerSize);

            AddBorder();

            AddGesture();

            // this.ResizeEvent += new ResizeEventHandler(OnWindowResize);
            // this.PositionEvent += new PositionEventHandler(OnWindowPosition);

          }
        }

        internal void AddGesture()
        {


            this.TouchEvent += OnInterceptedTouch;
        }

        private void OnInterceptedTouch(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
              Tizen.Log.Error("NUI", $"OnInterceptedTouch {e.Touch.GetPointCount()}\n");
              gestureView = new View()
              {
                  WidthResizePolicy = ResizePolicyType.FillToParent,
                  HeightResizePolicy = ResizePolicyType.FillToParent,
                  BackgroundColor = new Vector4(0, 1, 0, 0.5f),
              };
              GetBorderWindowRootLayer().Add(gestureView);

              tapGestureDetector = new TapGestureDetector();
              tapGestureDetector.Attach(gestureView);
              tapGestureDetector.SetMaximumTapsRequired(2);
              tapGestureDetector.Detected += OnTapGestureDetected;

              // panGestureDetector.Attach(gestureView);

              this.TouchEvent -= OnInterceptedTouch;

            }
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", $"OnTapGestureDetected {e.TapGesture.NumberOfTaps}, {e.TapGesture.NumberOfTouches}\n");
             if(e.TapGesture.NumberOfTaps == 2)
             {
              this.WindowSize = new Size2D(500, 500-bottomLayerSize);
             }
             else
             {
               GetBorderWindowRootLayer().Remove(gestureView);
               this.TouchEvent += OnInterceptedTouch;
             }
        }

        // public void OnWindowResize(Size2D size)
        // {
        //     lock (locker)
        //     {
        //       Tizen.Log.Error("NUI", $"OnWindowResize !!\n");
        //       this.WindowSize += size;
        //     }
        // }

        // public void OnWindowPosition(Position2D position)
        // {
        //     this.WindowPosition += position;
        // }

        internal void EnableBorderWindowRootLayer(Size2D winSize, Position2D winPosition)
        {
          GetDefaultLayer().Name = "OriginalRootLayer";

          // this is very critical for the code order. this should be placed after GetDefaultLayer()!
          if (isBorderWindow == false)
          {
            isBorderWindow = true;

            this.WindowSize = winSize;
            this.WindowPosition = winPosition;

            GetBorderWindowRootLayer();

            GetBorderWindowBottomLayer();

            TestAddBorder();

            Resized += OnBorderWindowResized;
          }
        }

        internal void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
          Tizen.Log.Error("NUI", $"OnBorderWindowResized {WindowSize.Width},{WindowSize.Height}\n");
          Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, WindowSize.Width, WindowSize.Height);
          Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, WindowSize.Width, bottomLayerSize);

          if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }

          //ToDo: need to be modified, this is just for test
          if (borderText != null)
          {
              testCnt++;
              borderText.Text = $"test BorderWindow! click to enlarge win! cnt={testCnt}";
          }
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
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width, bottomLayerSize);
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

        internal void AddBorder()
        {
          borderView = new View()
          {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FillToParent,
            BackgroundColor = new Color(1, 0, 0, 0.5f),
            // Layout = new LinearLayout()
            // {
            //     LinearOrientation = LinearLayout.Orientation.Horizontal,
            //     LinearAlignment = LinearLayout.Alignment.End,
            // },
          };
          borderView.TouchEvent += (s, e) =>
          {
            return true;
          };

          ImageView min = new ImageView()
          {
            Size = new Size(40, 20),
            Position = new Position(150, 20),
          };
          min.SetImage(ResourcePath + "/images/Dali/ContactCard/gallery-small-2.jpg");
          min.TouchEvent += OnMinTouched;

          ImageView max = new ImageView()
          {
            Size = new Size(40, 20),
            Position = new Position(200, 20),
          };
          max.SetImage(ResourcePath + "/images/Dali/ContactCard/gallery-small-3.jpg");
          max.TouchEvent += OnMaxTouched;

          ImageView terminate = new ImageView()
          {
            Size = new Size(40, 20),
            Position = new Position(250, 20),
          };
          terminate.SetImage(ResourcePath + "/images/Dali/ContactCard/gallery-small-4.jpg");
          // terminate.TouchEvent += OnMaxTouched;

          borderView.Add(min);
          borderView.Add(max);
          borderView.Add(terminate);

          panGestureDetector = new PanGestureDetector();
          panGestureDetector.Attach(borderView);
          panGestureDetector.Detected += OnPanGestureDetected;

          GetBorderWindowBottomLayer().Add(borderView);
        }

        private bool OnMinTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              this.WindowSize = new Size2D(WindowSize.Width, bottomLayerSize);
            }
            return true;
        }

        private bool OnMaxTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              this.WindowSize = new Size2D(500, 500-bottomLayerSize);
            }
            return true;
        }


        private CommandType GetCommandType(PanGesture panGesture)
        {
           Tizen.Log.Error("NUI", $"IsResize {panGesture.Position.X}, {panGesture.Position.Y}\n");
          float xPosition = panGesture.Position.X;
          float yPosition = panGesture.Position.Y;
          // this.EnableFloatingMode(true);
          // this.RequestResizeToServer(ResizeDirection.TopLeft);

          // check left corner
          if (xPosition < 10 && yPosition > 40)
          {
              // this.RequestResizeToServer(ResizeDirection.TopRight);
              return CommandType.ResizeLeftCorner;
          }
          // check right corner
          else if (xPosition > this.WindowSize.Width - 10 && yPosition > 40)
          {
              return CommandType.ResizeRightCorner;
          }
          // check left side
          else if (xPosition < 10)
          {
              // this.RequestResizeToServer(ResizeDirection.TopRight);
              return CommandType.ResizeLeftSide;
          }
          // check right side;
          else if (xPosition > this.WindowSize.Width - 10)
          {
            return CommandType.ResizeRightSide;
          }
          else if (yPosition > 40)
          {
            return CommandType.ResizeHeightSide;
          }
          return CommandType.Move;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            // lock (locker)
            {
              PanGesture panGesture = e.PanGesture;

              Tizen.Log.Error("NUI", $"OnPanGestureDetected {panGesture.ScreenDisplacement.X},{panGesture.ScreenDisplacement.Y} start\n");

              if (panGesture.State == Gesture.StateType.Started)
              {
                // panGesture.Displacement.X : panGesture.Displacement.Y;
                commandType = GetCommandType(panGesture);
              }
              else if (panGesture.State == Gesture.StateType.Continuing)
              {
                if (commandType == CommandType.ResizeLeftCorner)
                {
                  // Rectangle rct = this.WindowPositionSize;
                  // this.WindowPositionSize = new Rectangle(rct.X + (int)panGesture.ScreenDisplacement.X, rct.Y, rct.Width + (int)-panGesture.ScreenDisplacement.X, rct.Height + (int)panGesture.ScreenDisplacement.Y);


                  this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
                if (commandType == CommandType.ResizeRightCorner)
                {
                  this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
                else if (commandType == CommandType.ResizeLeftSide)
                {
                  // this.WindowSize += new Size2D((int)-panGesture.ScreenDisplacement.X, 0);
                  // this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, 0);
                  // Rectangle rct = this.WindowPositionSize;
                  // Tizen.Log.Error("NUI", $"Before {rct.X},{rct.Y},{rct.Width},{rct.Height} \n");
                  // this.WindowPositionSize = new Rectangle(rct.X + (int)panGesture.ScreenDisplacement.X, rct.Y, rct.Width+(int)-panGesture.ScreenDisplacement.X, rct.Height);
                  // Tizen.Log.Error("NUI", $"After {rct.X},{rct.Y},{rct.Width},{rct.Height} \n");

                  this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);

                }
                else if (commandType == CommandType.ResizeRightSide)
                {
                  this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
                }
                else if (commandType == CommandType.ResizeHeightSide)
                {
                  this.WindowSize += new Size2D(0, (int)panGesture.ScreenDisplacement.Y);
                }
                else if (commandType == CommandType.Move)
                {
                  this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
                }
              }
              else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
              {
                commandType = CommandType.Unknown;
              }
              Tizen.Log.Error("NUI", $"OnPanGestureDetected {panGesture.ScreenDisplacement.X},{panGesture.ScreenDisplacement.Y} end\n");
            }
        }

        private void OnLongPressGestureDetected(object source, LongPressGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", $"OnLongPressGestureDetected\n");
        }


        //ToDo: need to be removed, should be implemented properly
        internal void TestAddBorder()
        {
            borderText = new TextLabel()
            {
                Text = "test BorderWindow! click to enlarge win!",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = new Color(1, 0, 0, 0.5f),
                PointSize = 15,
            };
            GetBorderWindowBottomLayer().Add(borderText);
            borderText.TouchEvent += onBorderTextTouched;
        }

        //ToDo: need to be removed, should be implemented properly
        private bool onBorderTextTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                // this.WindowPosition += new Position2D(10, 10);
                // this.WindowSize += new Size2D(10, 10);
            }
            return true;
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() + bottomLayerSize);
                size.SetHeight(height);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() - bottomLayerSize);
                size.SetHeight(height);
            }
        }
        #endregion //Methods

        #region Structs
        #endregion //Structs

        #region Classes
        #endregion //Classes
    }
}