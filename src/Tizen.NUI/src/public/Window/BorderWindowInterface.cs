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
        private static readonly string MinimalizeIcon = ResourcePath + "minimalize.png";
        private static readonly string MaximalizeIcon = ResourcePath + "maximalize.png";
        private static readonly string PreviousIcon = ResourcePath + "smallwindow.png";
        private static readonly string CloseIcon = ResourcePath + "close.png";
        private static readonly string LeftCornerIcon = ResourcePath + "leftCorner.png";
        private static readonly string RightCornerIcon = ResourcePath + "rightCorner.png";
        private static readonly uint DefaultHeight = 50;
        private static readonly uint DefaultLineThickness = 10;
        private static readonly uint DefaultTouchThickness = 20;
        private static readonly Color DefaultBackgroundColor = new Color(1, 1, 1, 0.3f);
        private static readonly Size2D DefaultMinSize = new Size2D(200, (int)DefaultHeight);


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

        /// <summary>
        /// Create border UI. Users can override this method to draw border UI.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CreateBorderView(View rootView)
        {

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

            var leftCorner = new ImageView()
            {
                ResourceUrl = LeftCornerIcon,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
            };

            var rightCorner = new ImageView()
            {
              ResourceUrl = RightCornerIcon,
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
            };

            rootView.Add(leftCorner);
            borderView.Add(minimalizeIcon);
            borderView.Add(maximalizeIcon);
            borderView.Add(closeIcon);
            borderView.Add(rightCorner);
            rootView.Add(borderView);

            minimalizeIcon.TouchEvent += OnMinTouched;
            maximalizeIcon.TouchEvent += OnMaxTouched;
            closeIcon.TouchEvent += OnCloseTouched;
            leftCorner.TouchEvent += OnLeftCornerTouched;
            rightCorner.TouchEvent += OnRightCornerTouched;
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
              window.RequestResizeToServer(Window.ResizeDirection.BottomLeft);
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
              window.RequestResizeToServer(Window.ResizeDirection.BottomRight);
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
                  maximalizeIcon.ResourceUrl = MaximalizeIcon;
                }
                else
                {
                  window.Maximize(true);
                  maximalizeIcon.ResourceUrl = PreviousIcon;
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
            }
            return true;
        }


        #endregion //Methods

    }
}
