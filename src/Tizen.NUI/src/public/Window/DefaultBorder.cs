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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// This class creates a border UI.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultBorder : BindableObject, IDisposable, IBorderInterface
    {
        #region Constant Fields
        private static readonly string ResourcePath = FrameworkInformation.ResourcePath;
        private static readonly string MinimalizeIcon = ResourcePath + "minimalize.png";
        private static readonly string MaximalizeIcon = ResourcePath + "maximalize.png";
        private static readonly string CloseIcon = ResourcePath + "close.png";
        private static readonly string LeftCornerIcon = ResourcePath + "leftCorner.png";
        private static readonly string RightCornerIcon = ResourcePath + "rightCorner.png";

        private static readonly string DarkMinimalizeIcon = ResourcePath + "dark_minimalize.png";
        private static readonly string DarkPreviousIcon = ResourcePath + "dark_smallwindow.png";
        private static readonly string DarkCloseIcon = ResourcePath + "dark_close.png";
        private static readonly string DarkLeftCornerIcon = ResourcePath + "dark_leftCorner.png";
        private static readonly string DarkRightCornerIcon = ResourcePath + "dark_rightCorner.png";


        private const float DefaultHeight = 50;
        private const uint DefaultLineThickness = 5;
        private const uint DefaultTouchThickness = 0;
        private static readonly Color DefaultBackgroundColor = new Color(1, 1, 1, 0.3f);
        private static readonly Color DefaultClickedBackgroundColor = new Color(1, 1, 1, 0.4f);
        private static readonly Size2D DefaultMinSize = new Size2D(100, 0);
        #endregion //Constant Fields


        #region Fields
        private bool disposed = false;
        private Color backgroundColor;
        private View borderView;

        private ImageView minimalizeIcon;
        private ImageView maximalizeIcon;
        private ImageView closeIcon;
        private ImageView leftCornerIcon;
        private ImageView rightCornerIcon;

        private Window.BorderDirection direction = Window.BorderDirection.None;
        private float preScale = 0;

        private View windowView = null;
        private bool isWinGestures = false;
        private Timer timer;
        private Timer overlayTimer;

        private CurrentGesture currentGesture = CurrentGesture.None;

        private uint borderLineThickness;
        private Size2D minSize;
        private Size2D maxSize;
        private Window.BorderResizePolicyType resizePolicy;

        #endregion //Fields

        #region Events
        private PanGestureDetector borderPanGestureDetector;
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderLineThicknessProperty = BindableProperty.Create(nameof(BorderLineThickness), typeof(uint), typeof(DefaultBorder), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultBorder)bindable;
            if (newValue != null)
            {
                instance.borderLineThickness = (uint)newValue;
                instance.UpdateProperty();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultBorder)bindable;
            return instance.borderLineThickness;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinSizeProperty = BindableProperty.Create(nameof(MinSize), typeof(Size2D), typeof(DefaultBorder), default(Size2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultBorder)bindable;
            if (newValue != null)
            {
                instance.minSize = (Size2D)newValue;
                instance.UpdateProperty();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultBorder)bindable;
            return instance.minSize;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxSizeProperty = BindableProperty.Create(nameof(MaxSize), typeof(Size2D), typeof(DefaultBorder), default(Size2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultBorder)bindable;
            if (newValue != null)
            {
                instance.maxSize = (Size2D)newValue;
                instance.UpdateProperty();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultBorder)bindable;
            return instance.maxSize;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResizePolicyProperty = BindableProperty.Create(nameof(ResizePolicy), typeof(Window.BorderResizePolicyType), typeof(DefaultBorder), default(Window.BorderResizePolicyType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultBorder)bindable;
            if (newValue != null)
            {
                instance.resizePolicy = (Window.BorderResizePolicyType)newValue;
                instance.UpdateProperty();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultBorder)bindable;
            return instance.resizePolicy;
        });


        /// <summary>
        /// The thickness of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BorderLineThickness
        {
            get
            {
                return (uint)GetValue(BorderLineThicknessProperty);
            }
            set
            {
                SetValue(BorderLineThicknessProperty, value);
            }
        }

        /// <summary>
        /// The thickness of the border's touch area.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TouchThickness {get; set;}

        /// <summary>
        /// The height of the border.
        /// This value is the initial value used when creating borders.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderHeight {get; set;}

        /// <summary>
        /// The minimum size by which the window will small.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinSize
        {
            get
            {
                return (Size2D)GetValue(MinSizeProperty);
            }
            set
            {
                SetValue(MinSizeProperty, value);
            }
        }

        /// <summary>
        /// The maximum size by which the window will big.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MaxSize
        {
            get
            {
                return (Size2D)GetValue(MaxSizeProperty);
            }
            set
            {
                SetValue(MaxSizeProperty, value);
            }
        }

        /// <summary>
        /// The window with borders added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window BorderWindow {get; set;}

        /// <summary>
        /// Whether overlay mode.
        /// If overlay mode is true, the border area is hidden when the window is maximized.
        /// And if you touched at screen, the border area is shown on the screen.
        /// Default value is false;
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OverlayMode {get; set;}

        /// <summary>
        /// Set the window resizing policy.
        /// Default value is BorderResizePolicyType.Free;
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window.BorderResizePolicyType ResizePolicy
        {
            get
            {
                return (Window.BorderResizePolicyType)GetValue(ResizePolicyProperty);
            }
            set
            {
                SetValue(ResizePolicyProperty, value);
            }
        }

        /// <summary>
        /// Update properties
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateProperty()
        {
            BorderWindow?.UpdateProperty();
        }

        /// <summary>
        /// Creates a default border
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultBorder() : base()
        {
            BorderLineThickness = DefaultLineThickness;
            TouchThickness = DefaultTouchThickness;
            BorderHeight = DefaultHeight;
            MinSize = DefaultMinSize;
            OverlayMode = false;
            ResizePolicy = Window.BorderResizePolicyType.Free;
        }

        /// <summary>
        /// Create top border UI. User can override this method to draw top border UI.
        /// </summary>
        /// <param name="topView">The top view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CreateTopBorderView(View topView)
        {
            return false;
        }

        /// <summary>
        /// Create bottom border UI. User can override this method to draw bottom border UI.
        /// </summary>
        /// <param name="bottomView">The bottom view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CreateBottomBorderView(View bottomView)
        {
            if (bottomView == null)
            {
                return false;
            }
            bottomView.Layout = new RelativeLayout();

            minimalizeIcon = new ImageView()
            {
                Focusable = true,
                ResourceUrl = MinimalizeIcon,
                AccessibilityHighlightable = true,
            };

            maximalizeIcon = new ImageView()
            {
                Focusable = true,
                ResourceUrl = MaximalizeIcon,
                AccessibilityHighlightable = true,
            };

            closeIcon = new ImageView()
            {
                Focusable = true,
                ResourceUrl = CloseIcon,
                AccessibilityHighlightable = true,
            };

            leftCornerIcon = new ImageView()
            {
                Focusable = true,
                ResourceUrl = LeftCornerIcon,
                AccessibilityHighlightable = true,
            };

            rightCornerIcon = new ImageView()
            {
                Focusable = true,
                ResourceUrl = RightCornerIcon,
                AccessibilityHighlightable = true,
            };

            RelativeLayout.SetRightTarget(minimalizeIcon, maximalizeIcon);
            RelativeLayout.SetRightRelativeOffset(minimalizeIcon, 0.0f);
            RelativeLayout.SetHorizontalAlignment(minimalizeIcon, RelativeLayout.Alignment.End);
            RelativeLayout.SetRightTarget(maximalizeIcon, closeIcon);
            RelativeLayout.SetRightRelativeOffset(maximalizeIcon, 0.0f);
            RelativeLayout.SetHorizontalAlignment(maximalizeIcon, RelativeLayout.Alignment.End);
            RelativeLayout.SetRightTarget(closeIcon, rightCornerIcon);
            RelativeLayout.SetRightRelativeOffset(closeIcon, 0.0f);
            RelativeLayout.SetHorizontalAlignment(closeIcon, RelativeLayout.Alignment.End);
            RelativeLayout.SetRightRelativeOffset(rightCornerIcon, 1.0f);
            RelativeLayout.SetHorizontalAlignment(rightCornerIcon, RelativeLayout.Alignment.End);
            bottomView.Add(leftCornerIcon);
            bottomView.Add(minimalizeIcon);
            bottomView.Add(maximalizeIcon);
            bottomView.Add(closeIcon);
            bottomView.Add(rightCornerIcon);


            minimalizeIcon.TouchEvent += OnMinimizeIconTouched;
            maximalizeIcon.TouchEvent += OnMaximizeIconTouched;
            closeIcon.TouchEvent += OnCloseIconTouched;
            leftCornerIcon.TouchEvent += OnLeftBottomCornerIconTouched;
            rightCornerIcon.TouchEvent += OnRightBottomCornerIconTouched;

            minimalizeIcon.AccessibilityActivated += (s, e) =>
            {
                MinimizeBorderWindow();
            };
            maximalizeIcon.AccessibilityActivated += (s, e) =>
            {
                MaximizeBorderWindow();
            };
            closeIcon.AccessibilityActivated += (s, e) =>
            {
                CloseBorderWindow();
            };

            minimalizeIcon.AccessibilityNameRequested += (s, e) =>
            {
                e.Name = "Minimize";
            };
            maximalizeIcon.AccessibilityNameRequested += (s, e) =>
            {
                e.Name = "Maximize";
            };
            closeIcon.AccessibilityNameRequested += (s, e) =>
            {
                e.Name = "Close";
            };
            leftCornerIcon.AccessibilityNameRequested += (s, e) =>
            {
                e.Name = "Resize";
            };
            rightCornerIcon.AccessibilityNameRequested += (s, e) =>
            {
                e.Name = "Resize";
            };

            minimalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
            maximalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
            closeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
            leftCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
            rightCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);

            return true;
        }


        /// <summary>
        /// Create border UI. User can override this method to draw border UI.
        /// A top border and a bottom border are added to this view.
        /// </summary>
        /// <param name="borderView">The root view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CreateBorderView(View borderView)
        {
            if (borderView == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(borderView.BackgroundImage))
            {
                borderView.BackgroundColor = DefaultBackgroundColor;
            }
            borderView.BorderlineColor = new Color(0.5f, 0.5f, 0.5f, 0.3f);
            borderView.BorderlineWidth = 1.0f;
            borderView.BorderlineOffset = -1f;
            borderView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
            borderView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;

            // Register touch event for effect when border is touched.
            borderView.LeaveRequired = true;
            borderView.TouchEvent += OnBorderViewTouched;
            this.borderView = borderView;
        }

        private bool OnBorderViewTouched(object sender, View.TouchEventArgs e)
        {
            if (string.IsNullOrEmpty(borderView.BackgroundImage))
            {
                if (e.Touch.GetState(0) == PointStateType.Started)
                {
                    backgroundColor = new Color(borderView.BackgroundColor);
                    borderView.BackgroundColor = DefaultClickedBackgroundColor;
                }
                else if (e.Touch.GetState(0) == PointStateType.Finished ||
                        e.Touch.GetState(0) == PointStateType.Leave ||
                        e.Touch.GetState(0) == PointStateType.Interrupted)
                {
                    borderView.BackgroundColor = backgroundColor;
                }
            }
            return true;
        }

        /// Determines the behavior of pinch gesture.
        private void OnPinchGestureDetected(object source, PinchGestureDetector.DetectedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            if (e.PinchGesture.State == Gesture.StateType.Started)
            {
                preScale = e.PinchGesture.Scale;
            }
            else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
            {
                if (preScale > e.PinchGesture.Scale)
                {
                    if (BorderWindow.IsMaximized())
                    {
                        BorderWindow.Maximize(false);
                    }
                    else
                    {
                        BorderWindow.Minimize(true);
                        OnMinimize(true);
                    }
                }
                else
                {
                    BorderWindow.Maximize(true);
                }
            }
        }

        /// Determines the behavior of borders.
        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            PanGesture panGesture = e.PanGesture;

            if (panGesture.State == Gesture.StateType.Started && panGesture.Position != null)
            {
                direction = BorderWindow.GetDirection(panGesture.Position.X, panGesture.Position.Y);

                if (direction == Window.BorderDirection.Move)
                {
                    if (BorderWindow.IsMaximized() == true)
                    {
                        BorderWindow.Maximize(false);
                    }
                    else
                    {
                        OnRequestMove();
                        BorderWindow.RequestMoveToServer();
                    }
                }
                else if (direction != Window.BorderDirection.None && ResizePolicy != Window.BorderResizePolicyType.Fixed)
                {
                    OnRequestResize();
                    BorderWindow.RequestResizeToServer((Window.ResizeDirection)direction);
                }
            }
            else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
            {
                direction = Window.BorderDirection.None;
            }
        }

        /// <summary>
        /// This is an event callback when the left top corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnLeftTopCornerIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Down)
            {
              if (ResizePolicy != Window.BorderResizePolicyType.Fixed)
              {
                OnRequestResize();
                BorderWindow.RequestResizeToServer(Window.ResizeDirection.TopLeft);
              }
            }
            return true;
        }

        /// <summary>
        ///This is an event callback when the right bottom corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnRightTopCornerIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Down)
            {
              if (ResizePolicy != Window.BorderResizePolicyType.Fixed)
              {
                OnRequestResize();
                BorderWindow.RequestResizeToServer(Window.ResizeDirection.TopRight);
              }
            }
            return true;
        }


        /// <summary>
        /// This is an event callback when the left bottom corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnLeftBottomCornerIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Down)
            {
              if (ResizePolicy != Window.BorderResizePolicyType.Fixed)
              {
                OnRequestResize();
                BorderWindow.RequestResizeToServer(Window.ResizeDirection.BottomLeft);
              }
            }
            return true;
        }

        /// <summary>
        ///This is an event callback when the right bottom corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnRightBottomCornerIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Down)
            {
              if (ResizePolicy != Window.BorderResizePolicyType.Fixed)
              {
                OnRequestResize();
                BorderWindow.RequestResizeToServer(Window.ResizeDirection.BottomRight);
              }
            }
            return true;
        }


        /// <summary>
        /// Minimize border window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void MinimizeBorderWindow()
        {
            BorderWindow.Minimize(true);
            OnMinimize(true);
        }

        /// <summary>
        /// This is an event callback when the minimize icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnMinimizeIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Up)
            {
                MinimizeBorderWindow();
            }
            return true;
        }

        /// <summary>
        /// Maximize border window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void MaximizeBorderWindow()
        {
            if (BorderWindow.IsMaximized())
            {
              BorderWindow.Maximize(false);
            }
            else
            {
              BorderWindow.Maximize(true);
            }
        }

        /// <summary>
        /// This is an event callback when the maximum icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnMaximizeIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Up)
            {
                MaximizeBorderWindow();
            }
            return true;
        }

        /// <summary>
        /// Close border window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void CloseBorderWindow()
        {
            BorderWindow.BorderDestroy();
        }

        /// <summary>
        /// This is an event callback when the close icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnCloseIconTouched(object sender, View.TouchEventArgs e)
        {
            SetDispatchParentGestureEvents(sender as View, false);
            if (e != null && e.Touch.GetState(0) == PointStateType.Up)
            {
                CloseBorderWindow();
            }
            return true;
        }

        private void SetDispatchParentGestureEvents(View view, bool dispatch)
        {
            if (view != null)
            {
                // If this is set, my parents will not receive gesture events.
                // This is to prevent the move action by PanGesture when the icon is touched.
                view.DispatchParentGestureEvents = dispatch;
            }
        }


        private void UpdateIcons()
        {
            if (BorderWindow != null && borderView != null)
            {
                if (BorderWindow.IsMaximized() == true)
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
                    borderView.CornerRadius = new Vector4(0, 0, 0, 0);
                    borderView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
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
                    borderView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
                    borderView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
                }
            }
        }

        /// <summary>
        /// Called after the border UI is created.
        /// </summary>
        /// <param name="borderView">The border view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreated(View borderView)
        {
            if (borderView == null)
            {
                return;
            }
            this.borderView = borderView;

            BorderWindow.BackgroundColor = Color.Transparent;

            // Register to resize and move through pan gestures.
            borderPanGestureDetector = new PanGestureDetector();
            borderPanGestureDetector.Attach(borderView);
            borderPanGestureDetector.Detected += OnPanGestureDetected;

            UpdateIcons();
        }

        /// <summary>
        /// Called when requesting a resize
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnRequestResize() {}

        /// <summary>
        /// Called when the window is resized.
        /// </summary>
        /// <param name="width">The width of the resized window</param>
        /// <param name="height">The height of the resized window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnResized(int width, int height)
        {
            if (overlayTimer != null)
            {
                overlayTimer.Stop();
                overlayTimer.Dispose();
                overlayTimer = null;
            }
            UpdateIcons();
        }

        /// <summary>
        /// Called when requesting a move
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnRequestMove() {}

        /// <summary>
        /// Called when the window is moved.
        /// </summary>
        /// <param name="x">The x of the moved window</param>
        /// <param name="y">The y of the moved window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnMoved(int x, int y) {}

        /// <summary>
        /// Called when window has been moved the display server.
        /// </summary>
        /// <param name="x">The x of the has been moved window</param>
        /// <param name="y">The y of the has been moved window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnMoveCompleted(int x, int y) {}

        /// <summary>
        /// Called when window has been resized the display server.
        /// </summary>
        /// <param name="width">The width of the resized window</param>
        /// <param name="height">The height of the resized window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnResizeCompleted(int width, int height) {}

        /// <summary>
        /// Called when the window is maximized.
        /// </summary>
        /// <param name="isMaximized">If window is maximized or unmaximized.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnMaximize(bool isMaximized)
        {
            Tizen.Log.Info("NUI", $"OnMaximize {isMaximized}\n");
            if (BorderWindow.IsMaximized() == true)
            {
                BorderWindow.SetTransparency(false);
            }
            else
            {
                BorderWindow.SetTransparency(true);
            }

        }

        /// <summary>
        /// Called when the window is minimized.
        /// </summary>
        /// <param name="isMinimized">If window is mnimized or unminimized.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnMinimize(bool isMinimized)
        {
            UpdateIcons();
        }

        /// <summary>
        /// Called when there is a change in overlay mode.
        /// </summary>
        /// <param name="enabled">If true, borderView has entered overlayMode.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnOverlayMode(bool enabled)
        {
            if (borderView != null && OverlayMode == true)
            {
                Tizen.Log.Info("NUI", $"OnOverlayMode {enabled}\n");
                if (enabled == true)
                {
                    backgroundColor = new Color(borderView.BackgroundColor);
                    if (string.IsNullOrEmpty(borderView.BackgroundImage))
                    {
                        borderView.BackgroundColor = Color.Transparent;
                    }
                    borderView.Hide();
                }
                else
                {
                    if (string.IsNullOrEmpty(borderView.BackgroundImage))
                    {
                        borderView.BackgroundColor = backgroundColor;
                    }
                    borderView.Show();
                }
            }
        }

        /// <summary>
        /// Show the border when OverlayMode is true and the window is now Maximize.
        /// </summary>
        /// <param name="time">Time(ms) for borders to disappear again</param>
        /// <returns>True if border became show, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OverlayBorderShow(uint time = 3000)
        {
            if (BorderWindow != null && BorderWindow.IsMaximized())
            {
                if (overlayTimer == null)
                {
                    overlayTimer = new Timer(time);
                    overlayTimer.Tick += (s, e) =>
                    {
                        borderView?.Hide();
                        overlayTimer?.Stop();
                        overlayTimer?.Dispose();
                        overlayTimer = null;
                        return false;
                    };
                    overlayTimer.Start();
                    borderView?.Show();
                }
                else
                {
                    overlayTimer.Start();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hide the border when OverlayMode is true and the window is now Maximize.
        /// </summary>
        /// <returns>True if border became hide, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OverlayBorderHide()
        {
            if (BorderWindow != null && BorderWindow.IsMaximized())
            {
                borderView?.Hide();
                overlayTimer?.Stop();
                overlayTimer?.Dispose();
                overlayTimer = null;
                return true;
            }
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                borderView?.Dispose();
                windowView?.Dispose();
                borderPanGestureDetector?.Dispose();
                backgroundColor?.Dispose();
                minimalizeIcon?.Dispose();
                maximalizeIcon?.Dispose();
                closeIcon?.Dispose();
                leftCornerIcon?.Dispose();
                rightCornerIcon?.Dispose();
                timer?.Dispose();
                overlayTimer?.Dispose();
            }
            disposed = true;
        }

        #endregion //Methods

    }
}
