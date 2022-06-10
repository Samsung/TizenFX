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
extern alias TizenSystemInformation;
using TizenSystemInformation.Tizen.System;

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

        private Color overlayBackgroundColor;

        // for border area
        private View rootView = null;
        private View borderView = null;
        private View topView = null;
        private View contentsView = null;
        private View bottomView = null;
        private bool isTop = false;
        private bool isBottom = false;
        private float borderHeight = 0;
        private int screenWidth = 0;
        private int screenHeight = 0;
        #endregion //Fields

        #region Constructors
        #endregion //Constructors

        #region Distructors
        #endregion //Distructors

        #region Delegates
        internal delegate void BorderCloseDelegate();
        private BorderCloseDelegate borderCloseDelegate = null;

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

        /// <summary>
        /// This enum is the policy when resizing the border window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum BorderResizePolicyType
        {
          /// <summary>
          /// The window can be resized freely.
          /// </summary>
          Free = 0,
          /// <summary>
          /// The window is resized according to the ratio.
          /// </summary>
          KeepRatio = 1,
          /// <summary>
          /// The window is not resized and is fixed.
          /// </summary>
          Fixed = 2,
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
        /// Called when the border is closed.
        /// If the delegate is declared, the delegate is called, otherwise window is destroyed.
        /// </summary>
        internal void BorderDestroy()
        {
            if (borderCloseDelegate != null)
            {
                borderCloseDelegate();
            }
            else
            {
                Destroy();
            }
        }
        /// <summary>
        /// Enable the border window with IBorderInterface.
        /// This adds a border area to the Window.
        /// The border's UI is configured using IBorderInterface.
        /// Users can reisze and move by touching the border area.
        /// </summary>
        /// <param name="borderInterface">The IBorderInterface.</param>
        /// <param name="borderCloseDelegate">The BorderCloseDelegate. When close, this delegate is called.</param>
        /// <returns>Whether the border window is enabled</returns>
        internal bool EnableBorder(IBorderInterface borderInterface, BorderCloseDelegate borderCloseDelegate = null)
        {
            if (isBorderWindow == true)
            {
                Tizen.Log.Error("NUI", $"Already EnableBorderWindow\n");
                return false;
            }

            try
            {
                Information.TryGetValue<int>("http://tizen.org/feature/screen.width", out screenWidth);
                Information.TryGetValue<int>("http://tizen.org/feature/screen.height", out screenHeight);
            }
            catch (DllNotFoundException e)
            {
                Tizen.Log.Fatal("NUI", $"{e}\n");
            }

            if (borderInterface == null)
            {
                borderInterface = new DefaultBorder();
            }
            this.borderInterface = borderInterface;
            this.borderCloseDelegate = borderCloseDelegate;

            GetDefaultLayer().Name = "OriginalRootLayer";

            SetTransparency(true);
            BackgroundColor = Color.Transparent;
            borderInterface.BorderWindow = this;

            if (CreateBorder() == true)
            {
                
                using var realWindowSize = new Size2D(WindowSize.Width, WindowSize.Height);

                isBorderWindow = true;

                Resized += OnBorderWindowResized;

                borderInterface.OnCreated(borderView);

                // Increase the window size as much as the border area.
                borderHeight = 0;
                if (isTop) borderHeight += topView.SizeHeight;
                if (isBottom) borderHeight += bottomView.SizeHeight;
                
                if (borderInterface.MinSize != null)
                {
                    SetMinimizedSize(borderInterface.MinSize.Width, borderInterface.MinSize.Height + (int)borderHeight);
                }

                // When running the app for the first time, if it runs in full size, do Maximize(true).
                if (screenWidth != 0 && screenHeight != 0 &&
                    realWindowSize.Width >= screenWidth && realWindowSize.Height >= screenHeight &&
                    IsMaximized() == false)
                {
                    Maximize(true);
                    borderInterface.OnMaximize(true);
                    ResizedEventArgs e = new ResizedEventArgs();
                    e.WindowSize = WindowSize;
                    OnBorderWindowResized(this, e);
                }
                else
                {
                    WindowSize += new Size2D((int)borderInterface.BorderLineThickness * 2, (int)(borderHeight + borderInterface.BorderLineThickness * 2));
                }

                // If it is BorderResizePolicyType.KeepRatio type, it will be resized according to the ratio.
                if (borderInterface.ResizePolicy == BorderResizePolicyType.KeepRatio)
                {
                    AddAuxiliaryHint("wm.policy.win.resize_aspect_ratio", "1");
                }

                // Add a view to the border layer.
                GetBorderWindowBottomLayer().Add(rootView);

                InterceptTouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down && IsMaximized() == false)
                    {
                        Raise();
                    }
                    return false;
                };

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
                GrabTouchAfterLeave = true,
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
            else if ((yPosition > WindowSize.Height) || (isTop == true && yPosition < topView.SizeHeight))
            {
                direction = BorderDirection.Move;
            }

            return direction;
        }

        private void OverlayMode(bool enable)
        {
            if (borderInterface.OverlayMode == true)
            {
                if (enable == true)
                {
                    if (borderView != null)
                    {
                        overlayBackgroundColor = new Color(borderView.BackgroundColor);
                        borderView.BackgroundColor = Color.Transparent;
                        borderView.Hide();
                    }
                }
                else
                {
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

            borderInterface.OnResized(resizeWidth, resizeHeight);

             // reset borderHeight
            borderHeight = 0;
            if (isTop) borderHeight += topView.SizeHeight;
            if (isBottom) borderHeight += bottomView.SizeHeight;

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
                float height = (isTop == true) ? topView.SizeHeight : 0;
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
                float height = (isTop == true) ? topView.SizeHeight : 0;
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
