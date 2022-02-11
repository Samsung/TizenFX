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
    public abstract class BorderWindowInterface
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
        private uint height = DefaultHeight;
        private uint borderLineThickness = DefaultLineThickness;
        private uint touchThickness = DefaultTouchThickness;
        private Color backgroundColor = DefaultBackgroundColor;
        private Window window = null;

        private Size2D minSize = DefaultMinSize;
        private Size2D maxSize = null;

        private ImageView minimalizeIcon;
        private ImageView maximalizeIcon;
        private ImageView closeIcon;
        private ImageView leftCornerIcon;
        private ImageView rightCornerIcon;

        #endregion //Fields

        #region Enums

        #endregion //Enums

        #region Methods

        /// <summary>
        /// Sets the minimum size at which the window is resized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinSize
        {
          get
          {
            return minSize;
          }
          set
          {
            minSize = value;
          }
        }

        /// <summary>
        /// Sets the maximum size at which the window is resized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MaxSize
        {
          get
          {
            return maxSize;
          }
          set
          {
            maxSize = value;
          }
        }

        /// <summary>
        /// Sets the height of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Height
        {
          get
          {
            return height;
          }
          set
          {
            height = value;
          }
        }

        /// <summary>
        /// Sets the thickness of the edge being touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TouchThickness
        {
          get
          {
            return touchThickness;
          }
          set
          {
            touchThickness = value;
          }
        }

        /// <summary>
        /// Sets the borderLineThickness of the edge being touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BorderLineThickness
        {
          get
          {
            return borderLineThickness;
          }
          set
          {
            borderLineThickness = value;
          }
        }

        /// <summary>
        /// Sets the background color of border area.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BackgroundColor
        {
          get
          {
            return backgroundColor;
          }
          set
          {
            backgroundColor = value;
          }
        }

        public Window Window 
        {
            get
            {
                return window;
            }
            internal set
            {
                this.window = value;
            }
        }

        internal void SetWindow(Window window)
        {
          this.window = window;
        }

        private View rootView;

        /// <summary>
        /// Create border UI. Users can override this method to draw border UI.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CreateBorderView(View rootView)
        {
            this.rootView = rootView;
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

        /// <summary>
        /// This is an event callback when the left corner icon is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnLeftCornerTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              window.ClearWindowGesture();
              if(window.IsMinimized() == true)
              {
                window.RequestResizeToServer(Window.ResizeDirection.TopLeft);
              }
              else
              {
                window.RequestResizeToServer(Window.ResizeDirection.BottomLeft);
              }
              window.ResetMinMax();
              ChangedMax();
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
              window.ClearWindowGesture();
              if(window.IsMinimized() == true)
              {
                window.RequestResizeToServer(Window.ResizeDirection.TopRight);
              }
              else
              {
                window.RequestResizeToServer(Window.ResizeDirection.BottomRight);
              }
              window.ResetMinMax();
              ChangedMax();
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
                window.ClearWindowGesture();
                window.Minimize(true);
                ChangedMax();
            }
            return true;
        }

        /// <summary>
        /// This is an event callback when the maximum button is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnMaxTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                bool isMax = window.IsMaximized();
                window.ClearWindowGesture();
                if (window.IsMaximized())
                {
                  window.Maximize(false);
                }
                else
                {
                  window.Maximize(true);
                }
                ChangedMax();
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
            }
            return true;
        }


        public void ChangedMax()
        {
          if (window.IsMaximized() == true)
          {
            maximalizeIcon.ResourceUrl = DarkPreviousIcon;
            minimalizeIcon.ResourceUrl = DarkMinimalizeIcon;
            closeIcon.ResourceUrl = DarkCloseIcon;
            leftCornerIcon.ResourceUrl = DarkLeftCornerIcon;
            rightCornerIcon.ResourceUrl = DarkRightCornerIcon;

            rootView.CornerRadius = new Vector4(0, 0, 0, 0);
            rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
            window.SetTransparency(false);
            window.BackgroundColor = Color.White;
            Tizen.Log.Error("gab_test", $"Current Max icon Small\n");
          }
          else
          {
            maximalizeIcon.ResourceUrl = MaximalizeIcon;
            minimalizeIcon.ResourceUrl = MinimalizeIcon;
            closeIcon.ResourceUrl = CloseIcon;
            leftCornerIcon.ResourceUrl = LeftCornerIcon;
            rightCornerIcon.ResourceUrl = RightCornerIcon;


            rootView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
            rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
            window.SetTransparency(true);
            window.BackgroundColor = Color.Transparent;
            Tizen.Log.Error("gab_test", $"Current NotMax icon Max\n");
          }
        }


        #endregion //Methods

    }
}
