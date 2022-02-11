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
// using System.Reflection;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BorderWindowInterface
    {
        #region Constant Fields
        private static readonly string ResourcePath = FrameworkInformation.ResourcePath;
        // private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";
        private static readonly string DefaultMinimalizeIcon = ResourcePath + "minimalize.png";
        private static readonly string DefaultMaximalizeIcon = ResourcePath + "maximalize.png";
        private static readonly string DefaultPreviousIcon = ResourcePath + "smallwindow.png";
        private static readonly string DefaultCloseIcon = ResourcePath + "close.png";
        #endregion //Constant Fields

        #region Fields
        private int height = 50;
        private int touchThickness = 20;
        private Color backgroundColor = new Color(1, 1, 1, 0.3f);
        private Window window = null;

        private Size2D minSize = null;
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
        public int Height
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
        public int TouchThickness
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

        internal void SetWindow(Window window)
        {
          this.window = window;
        }

        /// <summary>
        /// Create border UI. Users can override this method to draw border UI.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual View CreateBorderView()
        {
            View rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = this.BackgroundColor,
            };

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
                ResourceUrl = DefaultMinimalizeIcon,
            };

            maximalizeIcon = new ImageView()
            {
                ResourceUrl = DefaultMaximalizeIcon,
            };

            closeIcon = new ImageView()
            {
                ResourceUrl = DefaultCloseIcon,
            };

            var leftCorner = new ImageView()
            {
              ResourceUrl = ResourcePath + "leftCorner.png",
            };

            var rightCorner = new ImageView()
            {
              ResourceUrl = ResourcePath + "rightCorner.png",
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

            return rootView;
        }

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
                Tizen.Log.Error("gab_test", $"OnMinTouched \n");
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
                Tizen.Log.Error("gab_test", $"OnMaxTouched {isMax}\n");
                window.ClearWindowGesture();
                if (window.IsMaximized())
                {
                  window.Maximize(false);
                  maximalizeIcon.ResourceUrl = DefaultMaximalizeIcon;
                }
                else
                {
                  window.Maximize(true);
                  maximalizeIcon.ResourceUrl = DefaultPreviousIcon;
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
                Tizen.Log.Error("gab_test", $"OnTerminateTouched \n");
                window.Destroy();
            }
            return true;
        }


        #endregion //Methods

    }
}
