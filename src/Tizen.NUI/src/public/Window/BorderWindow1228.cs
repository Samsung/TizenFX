// /*
//  * Copyright(c) 2021 Samsung Electronics Co., Ltd.
//  *
//  * Licensed under the Apache License, Version 2.0 (the "License");
//  * you may not use this file except in compliance with the License.
//  * You may obtain a copy of the License at
//  *
//  * http://www.apache.org/licenses/LICENSE-2.0
//  *
//  * Unless required by applicable law or agreed to in writing, software
//  * distributed under the License is distributed on an "AS IS" BASIS,
//  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  * See the License for the specific language governing permissions and
//  * limitations under the License.
//  *
//  */

// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Linq;
// using System.Threading;
// using Tizen.NUI.BaseComponents;


// namespace Tizen.NUI
// {
//     public partial class Window
//     {
//         #region Constant Fields
//         internal static readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
//         internal static readonly string DefaultText = "BorderWindow";
//         internal static readonly string DefaultMinUrl = ResourcePath + "/images/Dali/ContactCard/gallery-small-2.jpg";
//         internal static readonly string DefaultMaxUrl = ResourcePath + "/images/Dali/ContactCard/gallery-small-3.jpg";
//         internal static readonly string DefaultPartialUrl = ResourcePath + "/images/Dali/ContactCard/gallery-small-4.jpg";
//         internal static readonly string DefaultTerminateUrl = ResourcePath + "/images/Dali/ContactCard/gallery-small-5.jpg";
//         internal static readonly Color DefaultBackgroundColor = new Color(1, 0, 0, 0.5f);
//         internal static readonly Color DefaultTransparent = new Color(0,0,0,0);
//         internal static readonly int DefaultBorderSize = 50;
//         #endregion //Constant Fields

//         #region Fields
//         private Layer borderWindowRootLayer = null;
//         private Layer borderWindowBottomLayer = null;
//         private bool isBorderWindow = false;

//         private TableView borderView = null;
//         private View gestureView = null;
//         private PanGestureDetector panGestureDetector;
//         private LongPressGestureDetector longPressGestureDetector;

//         private PanGestureDetector winPanGestureDetector;
//         private TapGestureDetector tapGestureDetector;
//         private PinchGestureDetector pinchGestureDetector;

//         private CommandType commandType = CommandType.Unknown;
//         private CurrentGesture currentGesture = CurrentGesture.None;
//         private Position2D prePosition;
//         private Size2D preSize;
//         private float preScale = 1;
//         private Window.BorderStyle style;

//         private Timer timer;

//         #endregion //Fields

//         #region Constructors
//         #endregion //Constructors

//         #region Distructors
//         #endregion //Distructors

//         #region Delegates
//         // public delegate void ResizeEventHandler(Size2D size);
//         // public delegate void PositionEventHandler(Position2D position);
//         #endregion //Delegates

//         #region Events
//         // private event ResizeEventHandler ResizeEvent;
//         // private event PositionEventHandler PositionEvent;
//         #endregion //Events

//         #region Enums
//         internal enum CommandType
//         {
//             Unknown = 0,
//             ResizeLeftSide = 1,
//             ResizeRightSide = 2,
//             ResizeHeightSide = 3,
//             ResizeLeftCorner = 4,
//             ResizeRightCorner = 5,
//             Move = 6,
//         }
//         internal enum CurrentGesture
//         {
//           None = 0,
//           TapGesture = 1,
//           PanGesture = 2,
//           PinchGesture = 3,
//         }
//         #endregion //Enums

//         #region Interfaces
//         #endregion //Interfaces

//         #region Properties
//         [EditorBrowsable(EditorBrowsableState.Never)]
//         public bool IsBorderEnabled => isBorderWindow;
//         #endregion //Properties

//         #region Indexers
//         #endregion //Indexers

//         #region Methods
//         internal void UpdateStyle(Window.BorderStyle customStyle)
//         {

//           style.Text = (customStyle.Text  != "" && customStyle.Text  != null) ? customStyle.Text : DefaultText;
//           style.MinUrl = (customStyle.MinUrl != "" && customStyle.MinUrl != null) ? customStyle.MinUrl : DefaultMinUrl;
//           style.MaxUrl = (customStyle.MaxUrl != "" && customStyle.MaxUrl != null) ? customStyle.MaxUrl : DefaultMaxUrl;
//           style.PartialUrl = (customStyle.PartialUrl != "" && customStyle.PartialUrl != null) ? customStyle.PartialUrl : DefaultPartialUrl;
//           style.TerminateUrl = (customStyle.TerminateUrl != "" && customStyle.TerminateUrl != null) ? customStyle.TerminateUrl : DefaultTerminateUrl;
//           style.BackgroundColor = customStyle.BackgroundColor != null ? customStyle.BackgroundColor : DefaultBackgroundColor;
//           style.Transparent = customStyle.Transparent != null ? customStyle.Transparent : DefaultTransparent;
//           style.Height = customStyle.Height > 0 ? customStyle.Height : DefaultBorderSize;
//         }

//         public void EnableBorderWindow(Window.BorderStyle customStyle)
//         {
//           GetDefaultLayer().Name = "OriginalRootLayer";

//           UpdateStyle(customStyle);

//           // this is very critical for the code order. this should be placed after GetDefaultLayer()!
//           if (isBorderWindow == false)
//           {

//             Resized += OnBorderWindowResized;

//             isBorderWindow = true;

//             WindowSize += new Size2D(0, style.Height);

//             AddBorder();

//             AddGesture();

//             preSize = this.WindowSize;


//             // this.ResizeEvent += new ResizeEventHandler(OnWindowResize);
//             // this.PositionEvent += new PositionEventHandler(OnWindowPosition);

//           }
//         }

//         internal void AddBorder()
//         {
//             borderView = new TableView(1, 2)
//             {
//                 PositionUsesPivotPoint = true,
//                 PivotPoint = PivotPoint.Center,
//                 ParentOrigin = ParentOrigin.Center,
//                 WidthResizePolicy = ResizePolicyType.FillToParent,
//                 HeightResizePolicy = ResizePolicyType.FillToParent,
//                 BackgroundColor = style.BackgroundColor,
//                 CellPadding = new Vector2(10, 10),
//             };

//           View rightView = new View()
//           {
//             WidthResizePolicy = ResizePolicyType.FillToParent,
//             HeightResizePolicy = ResizePolicyType.FillToParent,
//             // WidthSpecification = LayoutParamPolicies.MatchParent,
//             // HeightSpecification = LayoutParamPolicies.MatchParent,

//             BackgroundColor = Color.Yellow,
//             // Layout = new LinearLayout()
//             // {
//             //     LinearOrientation = LinearLayout.Orientation.Horizontal,
//             //     LinearAlignment = LinearLayout.Alignment.End,
//             // },
//           };
//           TextLabel title = new TextLabel
//           {
//             Text = style.Text,
//             Size = new Size(100, 20),
//             // Position = new Position(10, 20),
//             PointSize = 10,
//           };

//           ImageView min = new ImageView()
//           {
//             Size = new Size(40, 20),
//             Position = new Position(50, 0),
//           };
//           min.SetImage(style.MinUrl);
//           min.TouchEvent += OnMinTouched;

//           ImageView max = new ImageView()
//           {
//             Size = new Size(40, 20),
//             Position = new Position(100, 0),
//           };
//           max.SetImage(style.MaxUrl);
//           max.TouchEvent += OnMaxTouched;

//           ImageView terminate = new ImageView()
//           {
//             Size = new Size(40, 20),
//             Position = new Position(150, 0),
//           };
//           terminate.SetImage(style.TerminateUrl);
//           terminate.TouchEvent += OnTerminateTouched;

//           rightView.Add(min);
//           rightView.Add(max);
//           rightView.Add(terminate);


//           borderView.AddChild(title, new TableView.CellPosition(0, 0));
//           borderView.AddChild(rightView, new TableView.CellPosition(0, 1));

//           panGestureDetector = new PanGestureDetector();
//           panGestureDetector.Attach(borderView);
//           panGestureDetector.Detected += OnPanGestureDetected;

//           GetBorderWindowBottomLayer().Add(borderView);
//         }

//         private bool OnMinTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Down)
//             {
//               Tizen.Log.Error("gab_test", $"OnMinTouched [{WindowSize.Width}, {style.Height}]\n");
//               this.WindowSize = new Size2D(WindowSize.Width, style.Height);
//             }
//             return true;
//         }

//         private bool OnMaxTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Down)
//             {
//               Tizen.Log.Error("gab_test", $"OnMaxTouched [800, 550]\n");
//               this.WindowSize = new Size2D(800, 600-style.Height);
//             }
//             return true;
//         }

//         private bool OnTerminateTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Down)
//             {
//               this.Destroy();
//             }
//             return true;
//         }


//         internal void AddGesture()
//         {
//             this.TouchEvent += OnInterceptedTouch;
//         }

//         private bool OnTick(object o, Timer.TickEventArgs e)
//         {
//             Tizen.Log.Error("gab_test", $"OnTick\n");

//             gestureView = new View()
//             {
//                 WidthResizePolicy = ResizePolicyType.FillToParent,
//                 HeightResizePolicy = ResizePolicyType.FillToParent,
//                 BackgroundColor = new Vector4(0, 1, 0, 0.5f),
//             };
//             gestureView.TouchEvent += (s, e) =>
//             {
//               return true;
//             };
//             GetBorderWindowRootLayer().Add(gestureView);

//             tapGestureDetector = new TapGestureDetector();
//             tapGestureDetector.Attach(gestureView);
//             tapGestureDetector.SetMaximumTapsRequired(3);
//             tapGestureDetector.Detected += OnTapGestureDetected;


//             pinchGestureDetector = new PinchGestureDetector();
//             pinchGestureDetector.Attach(gestureView);
//             pinchGestureDetector.Detected += OnPinchGestureDetected;


//             winPanGestureDetector = new PanGestureDetector();
//             winPanGestureDetector.Attach(gestureView);
//             winPanGestureDetector.Detected += OnWinPanGestureDetected;


//             this.TouchEvent -= OnInterceptedTouch;

//             return false;
//         }

//         private void OnInterceptedTouch(object sender, Window.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Down)
//             {
//               timer = new Timer(600);
//               timer.Tick += OnTick;
//               timer.Start();
//             }
//             else if (e.Touch.GetState(0) == PointStateType.Motion)
//             {
//               if (timer != null)
//               {
//                 timer.Stop();
//                 timer.Dispose();
//               }
//             }
//             else if (e.Touch.GetState(0) == PointStateType.Up)
//             {
//               Tizen.Log.Error("gab_test", $"OnInterceptedTouch {e.Touch.GetPointCount()}\n");
//               currentGesture = CurrentGesture.None;
//               if (timer != null)
//               {
//                 timer.Stop();
//                 timer.Dispose();
//               }
//             }
//         }

//         private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
//         {
//           Tizen.Log.Error("gab_test", $"OnTapGestureDetected {e.TapGesture.NumberOfTaps}, {e.TapGesture.NumberOfTouches}\n");
//           if (currentGesture <= CurrentGesture.TapGesture)
//           {
//             currentGesture = CurrentGesture.TapGesture;
//             if(e.TapGesture.NumberOfTaps == 2)
//             {
//               preSize = this.WindowSize;
//               this.WindowSize = new Size2D(800, 600-style.Height);
//             }
//             else if(e.TapGesture.NumberOfTaps == 3)
//             {
//               this.WindowSize = preSize;
//             }
//             else
//             {
//               winPanGestureDetector.Dispose();
//               pinchGestureDetector.Dispose();
//               tapGestureDetector.Dispose();

//               GetBorderWindowRootLayer().Remove(gestureView);
//               this.TouchEvent += OnInterceptedTouch;
//             }
//           }
//         }

//         private void OnPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
//         {
//           if (currentGesture <= CurrentGesture.PinchGesture)
//           {
//             Tizen.Log.Error("gab_test", $"OnPinchGestureDetected {e.PinchGesture.Scale} { e.PinchGesture.State}\n");
//             if(e.PinchGesture.State == Gesture.StateType.Started)
//             {
//               currentGesture = CurrentGesture.PinchGesture;
//               // this.EnableFloatingMode(true);
//               // this.RequestResizeToServer(ResizeDirection.TopLeft);
//               preScale = 1;
//               preSize = this.WindowSize;
//             }
//             else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
//             {
//               currentGesture = CurrentGesture.None;
//               Tizen.Log.Error("gab_test", $"OnPinchGestureDetected currentGesture = CurrentGesture.None;\n");
//             }
//             if(preScale > e.PinchGesture.Scale)
//             {
//               this.WindowSize -= new Size2D(10, 10);
//             }
//             else
//             {
//               this.WindowSize += new Size2D(10, 10);
//             }
//             preScale = e.PinchGesture.Scale;
//           }
//         }

//         private void OnWinPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
//         {
//           if (currentGesture <= CurrentGesture.PanGesture /*&& panGesture.NumberOfTouches == 1*/)
//           {

//             PanGesture panGesture = e.PanGesture;
//             Tizen.Log.Error("gab_test", $"OnWinPanGestureDetected {panGesture.State}\n");

//             if (panGesture.State == Gesture.StateType.Started)
//             {
//               currentGesture = CurrentGesture.PanGesture;
//               this.EnableFloatingMode(true);
//               this.RequestMoveToServer();
//             }
//             else if (panGesture.State == Gesture.StateType.Continuing)
//             {
//                 this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//             }
//             else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
//             {
//               currentGesture = CurrentGesture.None;
//             }
//           }
//         }


//         // public void OnWindowResize(Size2D size)
//         // {
//         //     lock (locker)
//         //     {
//         //       Tizen.Log.Error("NUI", $"OnWindowResize !!\n");
//         //       this.WindowSize += size;
//         //     }
//         // }

//         // public void OnWindowPosition(Position2D position)
//         // {
//         //     this.WindowPosition += position;
//         // }

//         internal void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
//         {
//           Tizen.Log.Error("gab_test", $"OnBorderWindowResized {WindowSize.Width},{WindowSize.Height}\n");
//           Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, WindowSize.Width, WindowSize.Height);
//           Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, WindowSize.Width, style.Height);

//           if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }

//         }

//         internal Layer GetBorderWindowBottomLayer()
//         {
//             if (borderWindowBottomLayer == null)
//             {
//                 borderWindowBottomLayer = new Layer();
//                 borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
//                 Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.ParentOrigin.BottomCenter.SwigCPtr);
//                 Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.PivotPoint.BottomCenter.SwigCPtr);
//                 Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
//                 Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width, style.Height);
//                 borderWindowBottomLayer.LowerToBottom();
//                 if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
//             }
//             return borderWindowBottomLayer;
//         }

//         internal Layer GetBorderWindowRootLayer()
//         {
//             if (borderWindowRootLayer == null)
//             {
//                 borderWindowRootLayer = new Layer();
//                 borderWindowRootLayer.Name = "RootLayer";
//                 Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopLeft.SwigCPtr);
//                 Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopLeft.SwigCPtr);
//                 Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
//                 Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height-100);
//                 if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
//             }

//             return borderWindowRootLayer;
//         }



//         private CommandType GetCommandType(PanGesture panGesture)
//         {
//            Tizen.Log.Error("gab_test", $"IsResize {panGesture.Position.X}, {panGesture.Position.Y}\n");
//           float xPosition = panGesture.Position.X;
//           float yPosition = panGesture.Position.Y;

//           // check left corner
//           if (xPosition < 10 && yPosition > 40)
//           {
//               this.EnableFloatingMode(true);
//               this.RequestResizeToServer(ResizeDirection.BottomLeft);
//               return CommandType.ResizeLeftCorner;
//           }
//           // check right corner
//           else if (xPosition > this.WindowSize.Width - 10 && yPosition > 40)
//           {
//               this.EnableFloatingMode(true);
//               this.RequestResizeToServer(ResizeDirection.BottomRight);
//               return CommandType.ResizeRightCorner;
//           }
//           // check left side
//           else if (xPosition < 10)
//           {
//               this.EnableFloatingMode(true);
//               this.RequestResizeToServer(ResizeDirection.Left);
//               return CommandType.ResizeLeftSide;
//           }
//           // check right side;
//           else if (xPosition > this.WindowSize.Width - 10)
//           {
//             this.EnableFloatingMode(true);
//             this.RequestResizeToServer(ResizeDirection.Right);
//             return CommandType.ResizeRightSide;
//           }
//           else if (yPosition > 40)
//           {
//             this.EnableFloatingMode(true);
//             this.RequestResizeToServer(ResizeDirection.Bottom);
//             return CommandType.ResizeHeightSide;
//           }
//           else
//           {
//             this.EnableFloatingMode(true);
//             this.RequestMoveToServer();
//           }
//           return CommandType.Move;
//         }

//         private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
//         {
//             // lock (locker)
//             {
//               PanGesture panGesture = e.PanGesture;

//               Tizen.Log.Error("gab_test", $"OnPanGestureDetected {panGesture.ScreenDisplacement.X},{panGesture.ScreenDisplacement.Y} {panGesture.State}\n");

//               if (panGesture.State == Gesture.StateType.Started)
//               {
//                 // panGesture.Displacement.X : panGesture.Displacement.Y;
//                 commandType = GetCommandType(panGesture);
//                 Tizen.Log.Error("gab_test", $"OnPanGestureDetected {commandType}\n");
//               }
//               else if (panGesture.State == Gesture.StateType.Continuing)
//               {
//                 if (commandType == CommandType.ResizeLeftCorner)
//                 {
//                   this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 if (commandType == CommandType.ResizeRightCorner)
//                 {
//                   this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 else if (commandType == CommandType.ResizeLeftSide)
//                 {
//                   this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
//                 }
//                 else if (commandType == CommandType.ResizeRightSide)
//                 {
//                   this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
//                 }
//                 else if (commandType == CommandType.ResizeHeightSide)
//                 {
//                   this.WindowSize += new Size2D(0, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 else if (commandType == CommandType.Move)
//                 {
//                   Tizen.Log.Error("gab_test", $"move before {this.WindowPosition.X} {this.WindowPosition.Y}\n");
//                   this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                   Tizen.Log.Error("gab_test", $"move after {this.WindowPosition.X} {this.WindowPosition.Y}\n");
//                 }
//               }
//               else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
//               {
//                 commandType = CommandType.Unknown;
//               }

//               preSize = this.WindowSize;
//             }
//         }

//         private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
//         {
//             if (isBorderWindow == true)
//             {
//                 var height = (ushort)(size.GetHeight() + style.Height);
//                 size.SetHeight(height);
//             }
//         }

//         private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
//         {
//             if (isBorderWindow == true)
//             {
//                 var height = (ushort)(size.GetHeight() - style.Height);
//                 size.SetHeight(height);
//             }
//         }
//         #endregion //Methods

//         #region Structs
//         [EditorBrowsable(EditorBrowsableState.Never)]
//         public struct BorderStyle
//         {

//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public BorderStyle(string text, string minUrl, string maxUrl, string partialUrl, string terminateUrl, Color backgroundColor, Color transparent, int height)
//             {
//               Text = text;
//               MinUrl = minUrl;
//               MaxUrl = maxUrl;
//               PartialUrl = partialUrl;
//               TerminateUrl = terminateUrl;
//               BackgroundColor = backgroundColor;
//               Transparent = transparent;
//               Height = height;
//             }
//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string Text {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string MinUrl {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string MaxUrl {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string PartialUrl {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string TerminateUrl {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public Color BackgroundColor {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public Color Transparent {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public int Height {get; set;}
//         }
//         #endregion //Structs

//         #region Classes
//         #endregion //Classes
//     }
// }
