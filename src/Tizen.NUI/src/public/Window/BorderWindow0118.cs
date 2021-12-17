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
//         public class CustomBorder
//         {
//             internal View RootView {get; set;}

//             public Size2D MinSize {get; set;}

//             public Size2D MaxSize {get; set;}

//             public int Height {get; set;}

//             public int TouchThickness {get; set;}

//             public View MinimalizeIcon {get; set;}

//             public View MaximalizeIcon {get; set;}

//             public View PreviousIcon {get; set;}

//             public View CloseIcon {get; set;}

//             public Color BackgroundColor {get; set;}

//             public void Add(View view)
//             {
//                 if (RootView == null)
//                 {
//                     RootView = new View()
//                     {
//                         WidthResizePolicy = ResizePolicyType.FillToParent,
//                         HeightResizePolicy = ResizePolicyType.FillToParent,
//                     };
//                     RootView.Add(view);
//                 }
//                 else
//                 {
//                     RootView.Add(view);
//                 }
//             }
//         }
//         #region Constant Fields
//         private static readonly string ResourcePath = FrameworkInformation.ResourcePath;
//         // private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";

//         // Default Border Style
//         private static readonly string DefaultMinimalizeIcon = ResourcePath + "minimalize.png";
//         private static readonly string DefaultMaximalizeIcon = ResourcePath + "maximalize.png";
//         private static readonly string DefaultPreviousIcon = ResourcePath + "smallwindow.png";
//         private static readonly string DefaultCloseIcon = ResourcePath + "close.png";
//         private static readonly Color DefaultBackgroundColor = new Color(1, 1, 1, 0.3f);
//         private static readonly int DefaultBorderHeight = 50;
//         private static readonly int DefaultBorderTouchThickness = 20;
//         #endregion //Constant Fields

//         #region Fields
//         private Layer borderWindowRootLayer = null;
//         private Layer borderWindowBottomLayer = null;
//         private bool isBorderWindow = false;

//         // for border area
//         private View borderView = null;
//         private PanGestureDetector borderPanGestureDetector;

//         // for window area
//         private View windowView = null;
//         private PanGestureDetector winPanGestureDetector;
//         private TapGestureDetector winTapGestureDetector;
//         private PinchGestureDetector winPinchGestureDetector;
//         private bool isWinGestures = false;
//         private Timer timer;

//         private CommandType commandType = CommandType.None;
//         private CurrentGesture currentGesture = CurrentGesture.None;
//         private Position2D prePosition;
//         private Size2D preSize;
//         private float preScale = 1;
//         private Window.BorderStyle style;
//         #endregion //Fields

//         #region Constructors
//         #endregion //Constructors

//         #region Distructors
//         #endregion //Distructors

//         #region Delegates
//         #endregion //Delegates

//         #region Events
//         #endregion //Events

//         #region Enums
//         private enum CommandType
//         {
//             None = 0,
//             ResizeLeftSide = 1,
//             ResizeRightSide = 2,
//             ResizeHeightSide = 3,
//             ResizeLeftCorner = 4,
//             ResizeRightCorner = 5,
//             Move = 6,
//         }
//         private enum CurrentGesture
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

//         /// The BorderSytle is updated with the DefaultStyle and the CustomStyle set by the user.
//         private bool UpdateStyle(Window.BorderStyle customStyle)
//         {
//             style.MinimalizeIcon = (customStyle.MinimalizeIcon != "" && customStyle.MinimalizeIcon != null) ? customStyle.MinimalizeIcon : DefaultMinimalizeIcon;
//             style.MaximalizeIcon = (customStyle.MaximalizeIcon != "" && customStyle.MaximalizeIcon != null) ? customStyle.MaximalizeIcon : DefaultMaximalizeIcon;
//             style.PreviousIcon = (customStyle.PreviousIcon != "" && customStyle.PreviousIcon != null) ? customStyle.PreviousIcon : DefaultPreviousIcon;
//             style.CloseIcon = (customStyle.CloseIcon != "" && customStyle.CloseIcon != null) ? customStyle.CloseIcon : DefaultCloseIcon;
//             style.BackgroundColor = customStyle.BackgroundColor != null ? customStyle.BackgroundColor : DefaultBackgroundColor;
//             style.Height = customStyle.Height > 0 ? customStyle.Height : DefaultBorderHeight;
//             style.TouchThickness = customStyle.TouchThickness > 0 ? customStyle.TouchThickness : DefaultBorderTouchThickness;
//             style.MinSize = customStyle.MinSize != null ? customStyle.MinSize : null;
//             style.MaxSize = customStyle.MaxSize != null ? customStyle.MaxSize : null;

//             if ((style.MinSize != null && style.MaxSize != null) && (style.MinSize.Width > style.MaxSize.Width || style.MinSize.Height > style.MaxSize.Height))
//             {
//                 Tizen.Log.Fatal("NUI", $"[ERROR] min size({style.MinSize.Width}, {style.MinSize.Height}) cannot be greater than max size({style.MaxSize.Width}, {style.MaxSize.Height})\n");
//                 return false;
//             }
//             return true;
//         }

//         /// The BorderSytle is updated with the DefaultStyle and the CustomStyle set by the user.
//         private bool UpdateStyle(Window.CustomBorder customStyle)
//         {
//             style.Height = customStyle.Height > 0 ? customStyle.Height : style.Height;
//             style.TouchThickness = customStyle.TouchThickness > 0 ? customStyle.TouchThickness : style.TouchThickness;
//             style.MinSize = customStyle.MinSize != null ? customStyle.MinSize : style.MinSize;
//             style.MaxSize = customStyle.MaxSize != null ? customStyle.MaxSize : style.MaxSize;
//             style.BackgroundColor = customStyle.BackgroundColor != null ? customStyle.BackgroundColor : style.BackgroundColor;

//             if ((style.MinSize != null && style.MaxSize != null) && (style.MinSize.Width > style.MaxSize.Width || style.MinSize.Height > style.MaxSize.Height))
//             {
//                 Tizen.Log.Fatal("NUI", $"[ERROR] min size({style.MinSize.Width}, {style.MinSize.Height}) cannot be greater than max size({style.MaxSize.Width}, {style.MaxSize.Height})\n");
//                 return false;
//             }
//             return true;
//         }

//         private bool EnableBorderWindow(Window.BorderStyle customStyle, CustomBorder border)
//         {
//             GetDefaultLayer().Name = "OriginalRootLayer";

//             if (isBorderWindow == false)
//             {

//                 if (UpdateStyle(customStyle) == false)
//                 {
//                     return false;
//                 }

//                 Resized += OnBorderWindowResized;

//                 isBorderWindow = true;

//                 WindowSize += new Size2D(0, style.Height);

//                 if (border == null)
//                 {
//                     CreateBorder();
//                 }
//                 else
//                 {
//                     AddBorder(border);
//                 }

//                 AddInterceptGesture();

//                 preSize = WindowSize;

//                 isWinGestures = false;

//                 EnableFloatingMode(true);

//                 return true;
//             }
//             else
//             {
//                 Tizen.Log.Error("NUI", "The window border has already been enabled.\n");
//                 return false;
//             }
//         }

//         public bool EnableBorderWindow(CustomBorder customBorder = null)
//         {
//             Window.BorderStyle style = new Window.BorderStyle();
//             return EnableBorderWindow(style, customBorder);
//         }


//         /// <summary>
//         /// Enable the Border Window
//         /// </summary>
//         /// <returns> </returns>
//         [EditorBrowsable(EditorBrowsableState.Never)]
//         public bool EnableBorderWindow(Window.BorderStyle customStyle)
//         {
//             return EnableBorderWindow(customStyle, null);
//         }

//         /// Add border UI and add Gestures.
//         private void CreateBorder()
//         {
//             Tizen.Log.Error("gab_test", $"CreateBorder start!!!!\n");

//             borderView = new View()
//             {
//                 WidthResizePolicy = ResizePolicyType.FillToParent,
//                 HeightResizePolicy = ResizePolicyType.FillToParent,
//                 BackgroundColor = style.BackgroundColor,
//             };

//             View rightView = new View()
//             {
//                 Layout = new LinearLayout()
//                 {
//                     LinearOrientation = LinearLayout.Orientation.Horizontal,
//                 },
//                 WidthSpecification = LayoutParamPolicies.MatchParent,
//                 HeightSpecification = LayoutParamPolicies.MatchParent,
//             };

//             ImageView min = new ImageView()
//             {
//                 ResourceUrl = style.MinimalizeIcon,
//             };
//             min.TouchEvent += OnMinTouched;

//             ImageView max = new ImageView()
//             {
//                 ResourceUrl = style.MaximalizeIcon,
//             };
//             max.TouchEvent += OnMaxTouched;

//             ImageView terminate = new ImageView()
//             {
//                 ResourceUrl = style.CloseIcon,
//             };
//             terminate.TouchEvent += OnTerminateTouched;

//             rightView.Add(min);
//             rightView.Add(max);
//             rightView.Add(terminate);

//             borderView.Add(rightView);

//             borderPanGestureDetector = new PanGestureDetector();
//             borderPanGestureDetector.Attach(borderView);
//             borderPanGestureDetector.Detected += OnPanGestureDetected;

//             GetBorderWindowBottomLayer().Add(borderView);
//             Tizen.Log.Error("gab_test", $"FindRootLayouts=={style.Height}\n");
//             FindRootLayouts(borderView, WindowSize.Width, style.Height);
//             Tizen.Log.Error("gab_test", $"CreateBorder end!!!!\n");
//         }



//         private bool AddBorder(CustomBorder border)
//         {
//             if (UpdateStyle(border) == false)
//             {
//                 return false;
//             }

//             borderView = border.RootView;

//             if (borderView == null)
//             {
//                 return false;
//             }
//             borderView.BackgroundColor = style.BackgroundColor;

//             if (border.MinimalizeIcon != null)
//             {
//                 border.MinimalizeIcon.TouchEvent += OnMinTouched;
//             }
//             if (border.MaximalizeIcon != null)
//             {
//                 border.MaximalizeIcon.TouchEvent += OnMaxTouched;
//             }
//             if (border.PreviousIcon != null)
//             {
//                 border.PreviousIcon.TouchEvent += OnPreviousTouched;
//             }
//             if (border.CloseIcon != null)
//             {
//                 border.CloseIcon.TouchEvent += OnTerminateTouched;
//             }

//             borderPanGestureDetector = new PanGestureDetector();
//             borderPanGestureDetector.Attach(borderView);
//             borderPanGestureDetector.Detected += OnPanGestureDetected;

//             GetBorderWindowBottomLayer().Add(borderView);
//             Tizen.Log.Error("gab_test", $"FindRootLayouts=={style.Height}\n");
//             FindRootLayouts(borderView, WindowSize.Width, style.Height);

//             return true;
//         }

//         private bool OnMinTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Up)
//             {
//                 Tizen.Log.Error("gab_test", $"OnMinTouched [{WindowSize.Width}, {style.Height}]\n");
//                 ClearWindowGesture();
//                 // TODO
//                 this.WindowSize = new Size2D(WindowSize.Width, style.Height);
//             }
//             return true;
//         }

//         private bool OnMaxTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Up)
//             {
//                 Tizen.Log.Error("gab_test", $"OnMaxTouched [800, 550]\n");
//                 ClearWindowGesture();
//                 //TODO
//                 this.WindowSize = new Size2D(1200, 900-style.Height);
//             }
//             return true;
//         }

//         private bool OnPreviousTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Up)
//             {
//                 Tizen.Log.Error("gab_test", $"OnMaxTouched [800, 550]\n");
//                 ClearWindowGesture();
//                 //TODO
//                 this.WindowSize = new Size2D(1200, 900-style.Height);
//             }
//             return true;
//         }

//         private bool OnTerminateTouched(object sender, View.TouchEventArgs e)
//         {
//             if (e.Touch.GetState(0) == PointStateType.Up)
//             {
//                 this.Destroy();
//             }
//             return true;
//         }


//         private CommandType GetCommandType(PanGesture panGesture)
//         {
//             float xPosition = panGesture.Position.X;
//             float yPosition = panGesture.Position.Y;

//             // check left corner
//             if (xPosition < style.TouchThickness && yPosition > style.Height - style.TouchThickness)
//             {
//                 this.RequestResizeToServer(ResizeDirection.BottomLeft);
//                 return CommandType.ResizeLeftCorner;
//             }
//             // check right corner
//             else if (xPosition > this.WindowSize.Width - style.TouchThickness && yPosition > style.Height - style.TouchThickness)
//             {
//                 this.RequestResizeToServer(ResizeDirection.BottomRight);
//                 return CommandType.ResizeRightCorner;
//             }
//             // check left side
//             else if (xPosition < style.TouchThickness)
//             {
//                 this.RequestResizeToServer(ResizeDirection.Left);
//                 return CommandType.ResizeLeftSide;
//             }
//             // check right side
//             else if (xPosition > this.WindowSize.Width - style.TouchThickness)
//             {
//                 this.RequestResizeToServer(ResizeDirection.Right);
//                 return CommandType.ResizeRightSide;
//             }
//             // check bottom side
//             else if (yPosition > style.Height - style.TouchThickness + 10)
//             {
//                 this.RequestResizeToServer(ResizeDirection.Bottom);
//                 return CommandType.ResizeHeightSide;
//             }
//             // check move
//             else
//             {
//                 this.RequestMoveToServer();
//                 return CommandType.Move;
//             }
//         }

//         private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
//         {
//             PanGesture panGesture = e.PanGesture;

//             Tizen.Log.Error("gab_test", $"OnPanGestureDetected {panGesture.ScreenDisplacement.X},{panGesture.ScreenDisplacement.Y} {panGesture.State}\n");

//             if (panGesture.State == Gesture.StateType.Started)
//             {
//                 commandType = GetCommandType(panGesture);
//                 Tizen.Log.Error("gab_test", $"OnPanGestureDetected {commandType}\n");
//             }
//             else if (panGesture.State == Gesture.StateType.Continuing)
//             {
//                 if (commandType == CommandType.ResizeLeftCorner)
//                 {
//                     this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 if (commandType == CommandType.ResizeRightCorner)
//                 {
//                     this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 else if (commandType == CommandType.ResizeLeftSide)
//                 {
//                     this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
//                 }
//                 else if (commandType == CommandType.ResizeRightSide)
//                 {
//                     this.WindowSize += new Size2D((int)panGesture.ScreenDisplacement.X, 0);
//                 }
//                 else if (commandType == CommandType.ResizeHeightSide)
//                 {
//                     this.WindowSize += new Size2D(0, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 else if (commandType == CommandType.Move)
//                 {
//                     this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//             }
//             else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
//             {
//                 commandType = CommandType.None;
//                 ClearWindowGesture();
//             }

//             preSize = this.WindowSize;
//         }

//         private void FindRootLayouts(View rootNode, float parentWidth, float parentHeight)
//         {
//             if (rootNode.Layout != null)
//             {
//                 NUILog.Debug("LayoutController Root found:" + rootNode.Name);
//                 // rootNode has a layout, start measuring and layouting from here.
//                 MeasureAndLayout(rootNode, parentWidth, parentHeight);
//             }
//             else
//             {
//                 float rootWidth = rootNode.SizeWidth;
//                 float rootHeight = rootNode.SizeHeight;
//                 // Search children of supplied node for a layout.
//                 for (uint i = 0; i < rootNode.ChildCount; i++)
//                 {
//                     FindRootLayouts(rootNode.GetChildAt(i), rootWidth, rootHeight);
//                 }
//             }
//         }


//         // Starts of the actual measuring and layouting from the given root node.
//         // Can be called from multiple starting roots but in series.
//         // Get parent View's Size.  If using Legacy size negotiation then should have been set already.
//         // Parent not a View so assume it's a Layer which is the size of the window.
//         private void MeasureAndLayout(View root, float parentWidth, float parentHeight)
//         {
//             if (root.Layout != null)
//             {
//                 // Determine measure specification for root.
//                 // The root layout policy could be an exact size, be match parent or wrap children.
//                 // If wrap children then at most it can be the root parent size.
//                 // If match parent then should be root parent size.
//                 // If exact then should be that size limited by the root parent size.
//                 float widthSize = GetLengthSize(parentWidth, root.WidthSpecification);
//                 float heightSize = GetLengthSize(parentHeight, root.HeightSpecification);
//                 var widthMode = GetMode(root.WidthSpecification);
//                 var heightMode = GetMode(root.HeightSpecification);

//                 if (root.Layout.NeedsLayout(widthSize, heightSize, widthMode, heightMode))
//                 {
//                     var widthSpec = CreateMeasureSpecification(widthSize, widthMode);
//                     var heightSpec = CreateMeasureSpecification(heightSize, heightMode);

//                     // Start at root with it's parent's widthSpecification and heightSpecification
//                     MeasureHierarchy(root, widthSpec, heightSpec);
//                 }

//                 float positionX = root.PositionX;
//                 float positionY = root.PositionY;
//                 // Start at root which was just measured.
//                 PerformLayout(root, new LayoutLength(positionX),
//                                      new LayoutLength(positionY),
//                                      new LayoutLength(positionX) + root.Layout.MeasuredWidth.Size,
//                                      new LayoutLength(positionY) + root.Layout.MeasuredHeight.Size);
//             }
//         }

//         private float GetLengthSize(float size, int specification)
//         {
//             // exact size provided so match width exactly
//             return (specification >= 0) ? specification : size;
//         }

//         private MeasureSpecification.ModeType GetMode(int specification)
//         {
//             if (specification >= 0 || specification == LayoutParamPolicies.MatchParent)
//             {
//                 return MeasureSpecification.ModeType.Exactly;
//             }
//             return MeasureSpecification.ModeType.Unspecified;
//         }

//         private MeasureSpecification CreateMeasureSpecification(float size, MeasureSpecification.ModeType mode)
//         {
//             return new MeasureSpecification(new LayoutLength(size), mode);
//         }

//         /// Starts measuring the tree, starting from the root layout.
//         private void MeasureHierarchy(View root, MeasureSpecification widthSpec, MeasureSpecification heightSpec)
//         {
//             // Does this View have a layout?
//             // Yes - measure the layout. It will call this method again for each of it's children.
//             // No -  reached leaf or no layouts set
//             //
//             // If in a leaf View with no layout, it's natural size is bubbled back up.
//             root.Layout?.Measure(widthSpec, heightSpec);
//         }

//         /// Performs the layouting positioning
//         private void PerformLayout(View root, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
//         {
//             root.Layout?.Layout(left, top, right, bottom);
//         }




//         /// Register an intercept touch event on the window.
//         private void AddInterceptGesture()
//         {
//             this.TouchEvent += OnWinInterceptedTouch;
//         }

//         private void OnWinInterceptedTouch(object sender, Window.TouchEventArgs e)
//         {
//             Tizen.Log.Error("gab_test", $"OnWinInterceptedTouch {e.Touch.GetPointCount()} {e.Touch.GetState(0)}\n");

//             if (e.Touch.GetState(0) == PointStateType.Stationary && e.Touch.GetPointCount() == 2)
//             {
//                 if (isWinGestures == false && timer == null)
//                 {
//                     timer = new Timer(300);
//                     timer.Tick += OnTick;
//                     timer.Start();
//                 }
//             }
//             else
//             {
//                 currentGesture = CurrentGesture.None;
//                 if (timer != null)
//                 {
//                     timer.Stop();
//                     timer.Dispose();
//                 }
//             }
//             // return false;
//         }

//         internal void ClearWindowGesture()
//         {
//             if (isWinGestures)
//             {
//                 winPanGestureDetector.Dispose();
//                 winPinchGestureDetector.Dispose();
//                 winTapGestureDetector.Dispose();

//                 isWinGestures = false;
//                 GetBorderWindowRootLayer().Remove(windowView);
//                 this.TouchEvent += OnWinInterceptedTouch;
//             }
//         }

//         /// If two finger long press is done, create a windowView.
//         /// then, Register a gesture on the windowView to do a resize or move.
//         private bool OnTick(object o, Timer.TickEventArgs e)
//         {
//             Tizen.Log.Error("gab_test", $"OnTick\n");

//             windowView = new View()
//             {
//                 WidthResizePolicy = ResizePolicyType.FillToParent,
//                 HeightResizePolicy = ResizePolicyType.FillToParent,
//                 BackgroundColor = new Vector4(1, 1, 1, 0.5f),
//             };
//             windowView.TouchEvent += (s, e) =>
//             {
//                 return true;
//             };
//             GetBorderWindowRootLayer().Add(windowView);

//             winTapGestureDetector = new TapGestureDetector();
//             winTapGestureDetector.Attach(windowView);
//             winTapGestureDetector.SetMaximumTapsRequired(3);
//             winTapGestureDetector.Detected += OnWinTapGestureDetected;

//             winPinchGestureDetector = new PinchGestureDetector();
//             winPinchGestureDetector.Attach(windowView);
//             winPinchGestureDetector.Detected += OnWinPinchGestureDetected;

//             winPanGestureDetector = new PanGestureDetector();
//             winPanGestureDetector.Attach(windowView);
//             winPanGestureDetector.Detected += OnWinPanGestureDetected;

//             this.TouchEvent -= OnWinInterceptedTouch;
//             isWinGestures = true;
//             return false;
//         }


//         private void OnWinTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
//         {
//           Tizen.Log.Error("gab_test", $"OnTapGestureDetected {e.TapGesture.NumberOfTaps}, {e.TapGesture.NumberOfTouches}\n");
//           if (currentGesture <= CurrentGesture.TapGesture)
//           {
//               currentGesture = CurrentGesture.TapGesture;
//               if (e.TapGesture.NumberOfTaps == 2)
//               {
//                   preSize = this.WindowSize;

//                   // TODO
//                   this.WindowSize = new Size2D(800, 600-style.Height);
//               }
//               else if (e.TapGesture.NumberOfTaps == 3)
//               {
//                   this.WindowSize = preSize;
//               }
//               else
//               {
//                   ClearWindowGesture();
//               }
//           }
//         }

//         // TODO Currently, the client is resizing, but if the display server provides a function, use the display server api.
//         private void OnWinPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
//         {
//             if (currentGesture <= CurrentGesture.PinchGesture)
//             {
//                 Tizen.Log.Error("gab_test", $"OnPinchGestureDetected {e.PinchGesture.Scale} { e.PinchGesture.State}\n");
//                 if (e.PinchGesture.State == Gesture.StateType.Started)
//                 {
//                     currentGesture = CurrentGesture.PinchGesture;
//                     preScale = 1;
//                     preSize = this.WindowSize;
//                 }
//                 else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
//                 {
//                     currentGesture = CurrentGesture.None;
//                     ClearWindowGesture();
//                 }
//                 else
//                 {
//                     if (preScale > e.PinchGesture.Scale)
//                     {
//                         this.WindowSize -= new Size2D(10, 10);
//                     }
//                     else
//                     {
//                         this.WindowSize += new Size2D(10, 10);
//                     }
//                 }
//                 preScale = e.PinchGesture.Scale;
//             }
//         }

//         private void OnWinPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
//         {
//             if (currentGesture <= CurrentGesture.PanGesture /*&& panGesture.NumberOfTouches == 1*/)
//             {
//                 PanGesture panGesture = e.PanGesture;
//                 Tizen.Log.Error("gab_test", $"OnWinPanGestureDetected {panGesture.State}\n");

//                 if (panGesture.State == Gesture.StateType.Started)
//                 {
//                     currentGesture = CurrentGesture.PanGesture;
//                     this.RequestMoveToServer();
//                 }
//                 else if (panGesture.State == Gesture.StateType.Continuing)
//                 {
//                     this.WindowPosition += new Position2D((int)panGesture.ScreenDisplacement.X, (int)panGesture.ScreenDisplacement.Y);
//                 }
//                 else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
//                 {
//                     currentGesture = CurrentGesture.None;
//                     ClearWindowGesture();
//                 }
//             }
//         }

//         private void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
//         {
//             Tizen.Log.Error("gab_test", $"OnBorderWindowResized {WindowSize.Width},{WindowSize.Height}\n");
//             int resizeWidth = WindowSize.Width;
//             int resizeHeight = WindowSize.Height;
//             if (style.MinSize != null)
//             {
//                 resizeWidth = style.MinSize.Width > resizeWidth ? (int)style.MinSize.Width : resizeWidth;
//                 resizeHeight = style.MinSize.Height > resizeHeight ? (int)style.MinSize.Height : resizeHeight;
//             }

//             if (style.MaxSize != null)
//             {
//                 resizeWidth = style.MaxSize.Width < resizeWidth ? (int)style.MaxSize.Width : resizeWidth;
//                 resizeHeight = style.MaxSize.Height < resizeHeight ? (int)style.MaxSize.Height : resizeHeight;
//             }

//             if (resizeWidth != WindowSize.Width || resizeHeight != WindowSize.Height)
//             {
//                 WindowSize = new Size2D(resizeWidth, resizeHeight);
//             }
//             Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
//             Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth, style.Height);

//             if (borderView != null)
//             {
//                 Tizen.Log.Error("gab_test", $"FindRootLayouts!!\n");
//                 FindRootLayouts(borderView, resizeWidth, style.Height);
//             }

//             if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
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
//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string MinimalizeIcon {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string MaximalizeIcon {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string PreviousIcon {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public string CloseIcon {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public Color BackgroundColor {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public int Height {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public int TouchThickness {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public Size2D MinSize {get; set;}

//             /// <summary>
//             /// </summary>
//             [EditorBrowsable(EditorBrowsableState.Never)]
//             public Size2D MaxSize {get; set;}
//         }
//         #endregion //Structs

//         #region Classes
//         #endregion //Classes
//     }
// }
