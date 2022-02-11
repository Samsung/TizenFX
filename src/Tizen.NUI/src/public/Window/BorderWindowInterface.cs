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

using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public abstract class BorderWindowInterface
    {
        #region Constant Fields
        // private static readonly string ResourcePath = FrameworkInformation.ResourcePath;
        private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";
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

        #endregion //Fields

        #region Enums

        #endregion //Enums

        #region Methods
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
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            ImageView minimalizeIcon = new ImageView()
            {
                ResourceUrl = DefaultMinimalizeIcon,
            };

            ImageView maximalizeIcon = new ImageView()
            {
                ResourceUrl = DefaultMaximalizeIcon,
            };

            ImageView closeIcon = new ImageView()
            {
                ResourceUrl = DefaultCloseIcon,
            };

            borderView.Add(minimalizeIcon);
            borderView.Add(maximalizeIcon);
            borderView.Add(closeIcon);
            rootView.Add(borderView);

            minimalizeIcon.TouchEvent += OnMinTouched;
            maximalizeIcon.TouchEvent += OnMaxTouched;
            closeIcon.TouchEvent += OnCloseTouched;

            return rootView;
        }


        public virtual bool OnMinTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Tizen.Log.Error("gab_test", $"OnMinTouched \n");
                // ClearWindowGesture();
                // TODO
                window.WindowSize = new Size2D(window.WindowSize.Width, Height);
            }
            return true;
        }

        public virtual bool OnMaxTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Tizen.Log.Error("gab_test", $"OnMaxTouched \n");
                // ClearWindowGesture();
                // preSize = window.WindowSize;
                //TODO
                window.WindowPositionSize = new Rectangle(0, 0, 1200, 700-Height);
            }
            return true;
        }

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
