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
        private IBorderInterface borderInterface = null;
        private Layer borderWindowRootLayer = null;
        private Layer borderWindowBottomLayer = null;
        private bool isBorderWindow = false;
        private bool isInterceptTouch = false;

        private Timer overlayTimer;
        private Color overlayBackgroundColor;

        // for border area
        private View rootView = null;
        private View borderView = null;
        private View topView = null;
        private View contentsView = null;
        private View bottomView = null;
        private bool isTop = false;
        private bool isBottom = false;
        uint borderHeight = 0;
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
        /// <summary>
        /// This is an enum for the resize direction or move value when the border area is touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum BorderDirection
        {
            None        = ResizeDirection.None,
            TopLeft     = ResizeDirection.TopLeft,
            Top         = ResizeDirection.Top,
            TopRight    = ResizeDirection.TopRight,
            Left        = ResizeDirection.Left,
            Right       = ResizeDirection.Right,
            BottomLeft  = ResizeDirection.BottomLeft,
            Bottom      = ResizeDirection.Bottom,
            BottomRight = ResizeDirection.BottomRight,
            Move,
        }
        #endregion //Enums

        #region Interfaces
        #endregion //Interfaces

        #region Properties
        /// <summary>
        /// Whether the border is enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBorderEnabled => isBorderWindow;
        #endregion //Properties

        #region Indexers
        #endregion //Indexers

        #region Methods
        /// <summary>
        /// Enable the border window with IBorderInterface.
        /// This adds a border area to the Window.
        /// The border's UI is configured using IBorderInterface.
        /// Users can reisze and move by touching the border area.
        /// </summary>
        /// <param name="borderInterface">The IBorderInterface.</param>
        /// <returns>Whether the border window is enabled</returns>
        internal bool EnableBorder(IBorderInterface borderInterface = null)
        {
            if (isBorderWindow == true)
            {
                Tizen.Log.Error("NUI", $"Already EnableBorderWindow\n");
                return false;
            }

            if (borderInterface == null)
            {
                borderInterface = new DefaultBorder();
            }
            this.borderInterface = borderInterface;

            GetDefaultLayer().Name = "OriginalRootLayer";

            if (CreateBorder() == true)
            {
                isBorderWindow = true;

                Resized += OnBorderWindowResized;

                // Increase the window size as much as the border area.
                if (isTop) borderHeight += borderInterface.BorderHeight;
                if (isBottom) borderHeight += borderInterface.BorderHeight;
                WindowSize += new Size2D((int)borderInterface.BorderLineThickness * 2, (int)(borderHeight + borderInterface.BorderLineThickness * 2));

                if (borderInterface.OverlayMode == true)
                {
                    rootView.InterceptTouchEvent += OverlayInterceptTouch;
                }

                // Add a view to the border layer.
                GetBorderWindowBottomLayer().Add(rootView);

                SetTransparency(true);
                BackgroundColor = Color.Transparent;
                borderInterface.BorderWindow = this;

                EnableFloatingMode(true);

                borderInterface.OnCreated(borderView);


                return true;
            }
            else
            {
                this.borderInterface.Dispose();
                return false;
            }
        }

        /// Create the border UI.
        private bool CreateBorder()
        {
            rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Transparent,
            };

            ushort padding = (ushort) borderInterface.BorderLineThickness;
            borderView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Transparent,
                Layout = new LinearLayout() {
                    LinearOrientation = LinearLayout.Orientation.Vertical, 
                    LinearAlignment = LinearLayout.Alignment.Top
                },
                Padding = new Extents(padding, padding, padding, padding),
            };
            borderInterface.CreateBorderView(borderView);

            topView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = borderInterface.BorderHeight,
                BackgroundColor = Color.Transparent,
            };

            contentsView = new View()
            {
                BackgroundColor = Color.Transparent,
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };

            bottomView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = borderInterface.BorderHeight,
                BackgroundColor = Color.Transparent,
            };

            // // Gets the Border's UI.
            if (borderInterface.CreateTopBorderView(topView) == true && topView != null)
            {
                borderView.Add(topView);
                isTop = true;
            }
            borderView.Add(contentsView);
            if (borderInterface.CreateBottomBorderView(bottomView) == true && bottomView != null)
            {
                borderView.Add(bottomView);
                isBottom = true;
            }
            rootView.Add(borderView);

            return isTop || isBottom;
        }

        /// <summary>
        /// Calculates which direction to resize or to move.
        /// </summary>
        /// <param name="xPosition">The X position.</param>
        /// <param name="yPosition">The Y position.</param>
        /// <returns>The BorderDirection</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BorderDirection GetDirection(float xPosition, float yPosition)
        {
            BorderDirection direction = BorderDirection.None;

            // check bottom left corner
            if (xPosition < borderInterface.TouchThickness && yPosition > WindowSize.Height + borderHeight - borderInterface.TouchThickness)
            {
                direction = BorderDirection.BottomLeft;
            }
            // check bottom right corner
            else if (xPosition > WindowSize.Width + borderInterface.BorderLineThickness * 2 - borderInterface.TouchThickness && yPosition > WindowSize.Height + borderHeight - borderInterface.TouchThickness)
            {
                direction = BorderDirection.BottomRight;
            }
            // check top left corner
            else if (xPosition < borderInterface.TouchThickness && yPosition <  borderInterface.TouchThickness)
            {
                direction = BorderDirection.TopLeft;
            }
            // check top right corner
            else if (xPosition > WindowSize.Width + borderInterface.BorderLineThickness * 2 - borderInterface.TouchThickness && yPosition < borderInterface.TouchThickness)
            {
                direction = BorderDirection.TopRight;
            }
            // check left side
            else if (xPosition < borderInterface.TouchThickness)
            {
                direction = BorderDirection.Left;
            }
            // check right side
            else if (xPosition > WindowSize.Width + borderInterface.BorderLineThickness*2 - borderInterface.TouchThickness)
            {
                direction = BorderDirection.Right;
            }
            // check bottom side
            else if (yPosition > WindowSize.Height + borderHeight + borderInterface.BorderLineThickness - borderInterface.TouchThickness)
            {
                direction = BorderDirection.Bottom;
            }
            // check top side
            else if (yPosition < borderInterface.TouchThickness)
            {
                direction = BorderDirection.Top;
            }
            // check move
            else if ((yPosition > WindowSize.Height) || (isTop == true && yPosition < borderInterface.BorderHeight))
            {
                direction = BorderDirection.Move;
            }

            return direction;
        }


        private bool OverlayInterceptTouch(object sender, View.TouchEventArgs e)
        {
            if (isInterceptTouch == true && overlayTimer != null)
            {
                overlayTimer.Start();
            }
            return false;
        }

        private bool OnTick(object o, Timer.TickEventArgs e)
        {
            GetBorderWindowBottomLayer().LowerToBottom();
            if (borderView != null)
            {
                borderView.Hide();
            }
            isInterceptTouch = false;

            overlayTimer.Stop();
            overlayTimer.Dispose();
            overlayTimer = null;
            return false;
        }

        // Intercept touch on window.
        private bool OnWinInterceptTouch(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                if (isInterceptTouch == false && overlayTimer == null)
                {
                    overlayTimer = new Timer(3000);
                    overlayTimer.Tick += OnTick;
                    overlayTimer.Start();
                    GetBorderWindowBottomLayer().RaiseToTop();
                    if (borderView != null)
                    {
                        borderView.Show();
                    }
                    isInterceptTouch = true;
                }
            }
            return false;
        }

        private void OverlayMode(bool enable)
        {
            if (borderInterface.OverlayMode == true)
            {
                if (enable == true)
                {
                    InterceptTouchEvent += OnWinInterceptTouch;
                    if (borderView != null)
                    {
                        overlayBackgroundColor = new Color(borderView.BackgroundColor);
                        borderView.BackgroundColor = Color.Transparent;
                        borderView.Hide();
                    }
                }
                else
                {
                    if (overlayTimer != null)
                    {
                        overlayTimer.Stop();
                        overlayTimer.Dispose();
                        overlayTimer = null;
                    }
                    isInterceptTouch = false;
                    InterceptTouchEvent -= OnWinInterceptTouch;
                    GetBorderWindowBottomLayer().LowerToBottom();
                    if (borderView != null)
                    {
                        borderView.BackgroundColor = overlayBackgroundColor;
                        borderView.Show();
                    }
                }
            }
        }


        // Called when the window size has changed.
        private void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
            Tizen.Log.Info("NUI", $"OnBorderWindowResized {e.WindowSize.Width},{e.WindowSize.Height}\n");
            int resizeWidth = e.WindowSize.Width;
            int resizeHeight = e.WindowSize.Height;
            if (borderInterface.MinSize != null)
            {
                resizeWidth = borderInterface.MinSize.Width > resizeWidth ? (int)borderInterface.MinSize.Width : resizeWidth;
                resizeHeight = borderInterface.MinSize.Height > resizeHeight ? (int)borderInterface.MinSize.Height : resizeHeight;
            }

            if (borderInterface.MaxSize != null)
            {
                resizeWidth = borderInterface.MaxSize.Width < resizeWidth ? (int)borderInterface.MaxSize.Width : resizeWidth;
                resizeHeight = borderInterface.MaxSize.Height < resizeHeight ? (int)borderInterface.MaxSize.Height : resizeHeight;
            }

            if (resizeWidth != e.WindowSize.Width || resizeHeight != e.WindowSize.Height)
            {
                WindowSize = new Size2D(resizeWidth, resizeHeight);
            }

            borderInterface.OnResized(resizeWidth, resizeHeight);

            if (borderInterface.OverlayMode == true && IsMaximized() == true)
            {
                Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
                Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth, resizeHeight);
                Interop.ActorInternal.SetPosition(GetBorderWindowRootLayer().SwigCPtr, 0, 0);
                if (contentsView != null)
                {
                    contentsView.SizeHeight = resizeHeight - borderHeight - borderInterface.BorderLineThickness * 2;
                }
                OverlayMode(true);
            }
            else
            {
                uint height = (isTop == true) ? borderInterface.BorderHeight : 0;
                Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
                Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth + borderInterface.BorderLineThickness * 2, resizeHeight + borderHeight + borderInterface.BorderLineThickness * 2);
                Interop.ActorInternal.SetPosition(GetBorderWindowRootLayer().SwigCPtr, 0, height + borderInterface.BorderLineThickness);
                if (contentsView != null)
                {
                    contentsView.SizeHeight = resizeHeight;
                }
                OverlayMode(false);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
        }

        internal Layer GetBorderWindowBottomLayer()
        {
            if (borderWindowBottomLayer == null)
            {
                borderWindowBottomLayer = new Layer();
                borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
                using Vector3 topCentor = new Vector3(0.5f, 0.0f, 0.5f);
                Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, topCentor.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, topCentor.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width + borderInterface.BorderLineThickness * 2, WindowSize.Height + borderInterface.BorderLineThickness * 2);
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
                using Vector3 topCentor = new Vector3(0.5f, 0.0f, 0.5f);
                Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, topCentor.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, topCentor.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height - borderHeight - borderInterface.BorderLineThickness * 2);
                uint height = (isTop == true) ? borderInterface.BorderHeight : 0;
                Interop.ActorInternal.SetPosition(borderWindowRootLayer.SwigCPtr, 0, height + borderInterface.BorderLineThickness);
                using PropertyValue propertyValue = new Tizen.NUI.PropertyValue((int)Tizen.NUI.ClippingModeType.ClipToBoundingBox);
                Tizen.NUI.Object.SetProperty(borderWindowRootLayer.SwigCPtr, Tizen.NUI.BaseComponents.View.Property.ClippingMode, propertyValue);

                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }

            return borderWindowRootLayer;
        }

        internal void DisposeBorder()
        {
            Resized -= OnBorderWindowResized;
            if (borderInterface.OverlayMode == true)
            {
                OverlayMode(false);
            }
            borderInterface.Dispose();
            GetBorderWindowBottomLayer().Dispose();
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() + borderHeight + borderInterface.BorderLineThickness * 2);
                var width = (ushort)(size.GetWidth() + borderInterface.BorderLineThickness * 2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true && !(borderInterface.OverlayMode == true && IsMaximized() == true))
            {
                var height = (ushort)(size.GetHeight() - borderHeight - borderInterface.BorderLineThickness * 2);
                var width = (ushort)(size.GetWidth() - borderInterface.BorderLineThickness * 2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }
        #endregion //Methods

        #region Structs
        #endregion //Structs

        #region Classes
        #endregion //Classes
    }



}
